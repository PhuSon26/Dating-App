using Google.Cloud.Firestore;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Firebase.Storage;
using Firebase.Auth;
using Amazon.ElasticBeanstalk.Model;
using Amazon.ElasticLoadBalancing.Model;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;

namespace LOGIN
{
    public class FirebaseAuthHelper
    {
        private readonly string apiKey;
        public FirestoreDb db;
        public string userID;
        public string email;
        public string password;

        public FirebaseAuthHelper(string apiKey)
        {
            this.apiKey = apiKey;

            string credPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "serviceAccountKey.json");

            Environment.SetEnvironmentVariable(
                "GOOGLE_APPLICATION_CREDENTIALS",
                credPath);

            db = FirestoreDb.Create("login-bb104");
        }
        private async Task<string> PostAsync(string url, object data)
        {
            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                throw new Exception($"Firebase Error: {err}");
            }

            return await response.Content.ReadAsStringAsync();
        }
        public Task<string> SignUp(string email, string password)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}";
            var data = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };
            return PostAsync(url, data);
        }

        public Task<string> SignIn(string email, string password)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}";
            var data = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };
            this.email = email;
            this.password = password;
            return PostAsync(url, data);
        }

        public Task<string> SendPasswordReset(string email)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={apiKey}";
            var data = new
            {
                requestType = "PASSWORD_RESET",
                email = email
            };
            return PostAsync(url, data);
        }
        public void SignOut(ref string idToken, ref string refreshToken)
        {
            idToken = null;
            refreshToken = null;
        }

        public Task<string> VerifyIdToken(string idToken)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:lookup?key={apiKey}";
            var data = new
            {
                idToken = idToken
            };
            return PostAsync(url, data);
        }

        public async Task<string> UpdatePassword(string email, string newPassword)
        {
            var signInResult = await SignIn(email, newPassword);
            var idToken = JsonSerializer.Deserialize<JsonElement>(signInResult).GetProperty("idToken").GetString();

            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:update?key={apiKey}";
            var data = new
            {
                idToken = idToken,
                password = newPassword,
                returnSecureToken = true
            };
            return await PostAsync(url, data);
        }

        public async Task<string> UpdatePasswordInApp(string idToken, string newPassword)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:update?key={apiKey}";

            var data = new
            {
                idToken = idToken,
                password = newPassword,
                returnSecureToken = true
            };

            return await PostAsync(url, data);
        }

        public Task<string> DeleteAccountAsync(string idToken)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:delete?key={apiKey}";
            var data = new
            {
                idToken = idToken
            };
            return PostAsync(url, data);
        }

        public async Task DeleteUserInfoAsync(string uid)
        {
            var docRef = db.Collection("Users").Document(uid);
            await docRef.DeleteAsync();
        }

        public async Task CreateOrUpdateUserInfoAsync(USER user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Id))
                throw new ArgumentException("user.Id đang trống – phải truyền uid Firebase vào USER.Id.");

            DocumentReference docRef = db.Collection("Users").Document(user.Id);
            await docRef.SetAsync(user, SetOptions.Overwrite);
        }

        public async Task<bool> CheckUserExist(string userId)
        {
            DocumentReference doc = db.Collection("Users").Document(userId);
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            return snap.Exists;
        }

        public async Task saveUserInfo(string userId, USER u)
        {
            DocumentReference doc = db.Collection("Users").Document(userId);
            await doc.SetAsync(u);
        }

        public async Task<string> signInAndSetUser(string email, string password)
        {
            var result = await SignIn(email, password);
            var json = JsonSerializer.Deserialize<JsonElement>(result);
            userID = json.GetProperty("localId").GetString();
            return userID;
        }

        public async Task<string> uploadFile(string localFilepath, string firebasefolder)
        {
            using (var stream = new FileStream(localFilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var task = new FirebaseStorage("login-bb104.appspot.com")
                    .Child(firebasefolder)
                    .Child(Path.GetFileName(localFilepath))
                    .PutAsync(stream);

                return await task;
            }
        }

        /// <summary>
        /// Gửi tin nhắn (text + optional ảnh) vào cuộc trò chuyện của một match.
        /// Lưu tin nhắn vào subcollection Matches/{matchId}/messages
        /// Đồng thời cập nhật trường lastMessage trong document Matches/{matchId}.
        /// </summary>
        public async Task<ChatMessage> SendMessageAsync(
            string matchId,
            string senderId,
            string text,
            string localImagePath = null)
        {
            if (string.IsNullOrWhiteSpace(matchId))
                throw new ArgumentException("matchId trống", nameof(matchId));

            if (string.IsNullOrWhiteSpace(senderId))
                throw new ArgumentException("senderId trống", nameof(senderId));

            if (string.IsNullOrWhiteSpace(text) &&
                string.IsNullOrWhiteSpace(localImagePath))
                throw new ArgumentException("Phải có text hoặc ảnh.");

            // 1. Nếu có ảnh → upload lên Firebase Storage, lấy URL
            string imageUrl = null;
            if (!string.IsNullOrWhiteSpace(localImagePath))
            {
                imageUrl = await uploadFile(localImagePath, "message_images");
            }

            // 2. Tạo object ChatMessage
            var msg = new ChatMessage
            {
                senderId = senderId,
                text = text ?? string.Empty,
                imageUrl = imageUrl,
                createdAt = Timestamp.FromDateTime(DateTime.UtcNow),
                isRecalled = false,
                isDeleted = false
            };

            // 3. Ghi vào subcollection Matches/{matchId}/messages
            DocumentReference matchDoc = db.Collection("Matches").Document(matchId);
            CollectionReference messagesCol = matchDoc.Collection("messages");
            DocumentReference addedMsgDoc = await messagesCol.AddAsync(msg);   // AddAsync trả về DocumentReference có Id 

            // lưu lại Id document vào object để dùng khi xoá/thu hồi
            msg.messageId = addedMsgDoc.Id;

            // 4. Cập nhật lastMessage trong document Matches/{matchId}
            string lastMsgPreview = !string.IsNullOrWhiteSpace(text) ? text : "[Hình ảnh]";
            await matchDoc.UpdateAsync("lastMessage", lastMsgPreview);  // Update field theo mẫu docs 

            return msg;
        }


        // ==============================================
        // HÀM GET MATCHES (ĐÃ TÁCH RIÊNG KHÔNG CHÈN NHẦM)
        // ==============================================
        public async Task<List<Match>> GetMatchesAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("userId trống", nameof(userId));

            var query = db.Collection("Matches")
                          .WhereArrayContains("users", userId);

            QuerySnapshot snap = await query.GetSnapshotAsync();

            List<Match> matches = new List<Match>();

            foreach (DocumentSnapshot doc in snap.Documents)
            {
                if (!doc.Exists) continue;

                Match m = doc.ConvertTo<Match>();

                matches.Add(m);
            }

            return matches;
        }
        public async Task<USER> getUser()
        {
            if (string.IsNullOrEmpty(userID)) return null;
            DocumentReference docRef = db.Collection("Users").Document(userID);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists) return null;
            return snapshot.ConvertTo<USER>();
        }
        public async Task UploadAvatarAsync(Image avatarImage, string userId)
        {
            string base64 = ImageToBase64(avatarImage);
            var docRef = db.Collection("Users").Document(userId);
            await docRef.SetAsync(new { AvatarBase64 = base64 }, SetOptions.MergeAll);
        }

        public async Task UploadPhotosAsync(List<Image> images, string userId)
        {
            var docRef = db.Collection("Users").Document(userId);
            List<string> base64List = new List<string>();
            foreach (var img in images)
                base64List.Add(ImageToBase64(img));

            await docRef.SetAsync(new { PhotosBase64 = base64List }, SetOptions.MergeAll);
        }
        public string ImageToBase64(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public Image Base64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
        public async Task<List<USER>> GetRandomSuggest(string userId, int limit = 5)
        {
            try
            {
                var usersCollection = db.Collection("Users");
                var snapshot = await usersCollection.GetSnapshotAsync();

                var allUsers = snapshot.Documents
                                       .Select(d =>
                                       {
                                           var user = d.ConvertTo<USER>();
                                           user.Id = d.Id;
                                           return user;
                                       })
                                       .ToList();

                // Tìm user hiện tại
                var currentUser = allUsers.FirstOrDefault(u => u.Id == userId);
                if (currentUser == null)
                    return new List<USER>();

                // Lọc user hợp lệ
                var randomUsers = allUsers
                    .Where(u => u.Id != userId &&
                                !string.IsNullOrEmpty(u.gioitinh) &&
                                u.gioitinh != currentUser.gioitinh)
                    .OrderBy(u => Guid.NewGuid())
                    .Take(limit)
                    .ToList();

                return randomUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi GetRandomSuggest: " + ex.Message);
                return new List<USER>();
            }
        }
        public async Task SendMessage(string fromUser, string toUser, string text)
        {
            string conversationId = GetConversationId(fromUser, toUser);

            var msgRef = db.Collection("messages").Document();

            await msgRef.SetAsync(new
            {
                fromUserId = fromUser,
                toUserId = toUser,
                text = text,
                timestamp = Timestamp.GetCurrentTimestamp(),
                ChatId = conversationId
            });
        }


        public string GetConversationId(string u1, string u2)
        {
            return string.Compare(u1, u2) < 0 ? $"{u1}_{u2}" : $"{u2}_{u1}";
        }


        public FirestoreChangeListener ListenToMessages(
    string user1,
    string user2,
    Action<List<Messagemodels>> onMessagesChanged)
        {
            string chatId = GetConversationId(user1, user2);

            // BỎ .OrderBy() để tránh lỗi index
            var messagesRef = db.Collection("messages")
                                .WhereEqualTo("ChatId", chatId);

            return messagesRef.Listen(snapshot =>
            {
                List<Messagemodels> messages = new();

                foreach (var doc in snapshot.Documents)
                {
                    var msg = doc.ConvertTo<Messagemodels>();
                    msg.Id = doc.Id;
                    messages.Add(msg);
                }

                // Sắp xếp trong code
                messages = messages.OrderBy(m =>
                {
                    try { return m.timestamp.ToDateTime(); }
                    catch { return DateTime.MinValue; }
                }).ToList();

                onMessagesChanged(messages);
            });
        }
        public async Task UpdateChatMeta(string fromUser, string toUser, string text)
        {
            string conversationId = GetConversationId(fromUser, toUser);

            var metaRef = db.Collection("ChatMeta").Document(conversationId);

            string unreadField =
                (fromUser.CompareTo(toUser) < 0)
                ? "unread_userB"
                : "unread_userA";

            await metaRef.SetAsync(
                new Dictionary<string, object>
                {
            { "lastMessage", text },
            { "lastTimestamp", Timestamp.GetCurrentTimestamp() },
            { unreadField, FieldValue.Increment(1) }
                },
                SetOptions.MergeAll
            );
        }
        public async Task ResetUnread(string u1, string u2)
        {
            string conversationId = GetConversationId(u1, u2);

            var metaRef = db.Collection("ChatMeta").Document(conversationId);

            string unreadField =
                (u1.CompareTo(u2) < 0)
                ? "unread_userA"
                : "unread_userB";

            await metaRef.UpdateAsync(unreadField, 0);
        }
        public async Task<USER> GetUserById(string userId)
        {
            var doc = await db.Collection("Users").Document(userId).GetSnapshotAsync();
            if (!doc.Exists) return null;

            var u = doc.ConvertTo<USER>();
            u.Id = doc.Id;  // đảm bảo không null
            return u;
        }
        public async Task<List<ChatMeta>> GetAllChatMeta(string userId)
        {
            var collection = db.Collection("ChatMeta");

            var snap = await collection
                .WhereEqualTo("userA", userId)
                .GetSnapshotAsync();

            var snap2 = await collection
                .WhereEqualTo("userB", userId)
                .GetSnapshotAsync();

            List<ChatMeta> metas = new();

            foreach (var doc in snap.Documents)
            {
                var m = doc.ConvertTo<ChatMeta>();
                metas.Add(m);
            }

            foreach (var doc in snap2.Documents)
            {
                var m = doc.ConvertTo<ChatMeta>();
                metas.Add(m);
            }

            return metas;
        }
        public async Task<List<string>> GetMatchedUsers(string currentUserId)
        {
            var snap = await db.Collection("Matches").GetSnapshotAsync();
            List<string> results = new();

            foreach (var doc in snap.Documents)
            {
                var arr = doc.GetValue<List<string>>("users");

                if (arr != null && arr.Contains(currentUserId))
                {
                    string other = arr.First(u => u != currentUserId);
                    results.Add(other);
                }
            }
            return results;
        }
        public async Task CreateChatMeta(string userA, string userB)
        {
            try
            {
                string metaId1 = $"{userA}_{userB}";
                string metaId2 = $"{userB}_{userA}";

                var metaRef1 = db.Collection("ChatMeta").Document(metaId1);
                var metaRef2 = db.Collection("ChatMeta").Document(metaId2);

                var doc1 = await metaRef1.GetSnapshotAsync();
                var doc2 = await metaRef2.GetSnapshotAsync();

                // Nếu meta đã tồn tại thì không tạo lại
                if (doc1.Exists || doc2.Exists)
                    return;

                ChatMeta meta = new ChatMeta
                {
                    Id = metaId1,
                    userA = userA,
                    userB = userB,
                    lastMessage = "",
                    lastTimestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                    unread_userA = 0,
                    unread_userB = 0
                };

                await metaRef1.SetAsync(meta);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LỖI TẠO CHAT META: " + ex.Message);
            }
        }
    }
}
