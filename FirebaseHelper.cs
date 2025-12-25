using Amazon.ElasticBeanstalk.Model;
using Amazon.ElasticLoadBalancing.Model;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Google.Cloud.Firestore;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using LOGIN.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN
{
    public class FirebaseAuthHelper
    {
        private readonly string apiKey;
        public FirestoreDb db;
        public string userID;
        public string email;
        public string password;
        public FirebaseClient rtcClient;
        private IDisposable callListener;
        private IDisposable iceListener;

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
            rtcClient = new FirebaseClient(
               "https://login-bb104-default-rtdb.firebaseio.com/"
           );


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


            // ==== KHÔNG DÙNG FIREBASE STORAGE NỮA ====
            string imageBase64 = null;
            if (!string.IsNullOrWhiteSpace(localImagePath))
                imageBase64 = ImageFileToBase64(localImagePath);

            var msg = new ChatMessage
            {
                senderId = senderId,
                text = text ?? string.Empty,

                imageUrl = null,                // không dùng
                imageBase64 = imageBase64,      // dùng base64

                createdAt = Timestamp.FromDateTime(DateTime.UtcNow),
                isRecalled = false,
                isDeleted = false
            };

            CollectionReference messagesCol = db.Collection("messages");
            DocumentReference addedMsgDoc = await messagesCol.AddAsync(msg);

            msg.messageId = addedMsgDoc.Id;

            // cập nhật preview tin nhắn (text hoặc "[Hình ảnh]")
            string lastMsgPreview = !string.IsNullOrWhiteSpace(text) ? text : "[Hình ảnh]";

            // cập nhật trường lastMessage trong Matches nếu có
            try
            {
                DocumentReference matchDoc = db.Collection("Matches").Document(matchId);
                var matchSnapshot = await matchDoc.GetSnapshotAsync();

                if (!matchSnapshot.Exists)
                {
                    await matchDoc.SetAsync(new Dictionary<string, object>
        {
            { "lastMessage", lastMsgPreview },
            { "createdAt", Timestamp.FromDateTime(DateTime.UtcNow) },
            { "users", new List<string> { senderId } }
        });
                }
                else
                {
                    await matchDoc.UpdateAsync("lastMessage", lastMsgPreview);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Không thể cập nhật lastMessage: " + ex.Message);
            }

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
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "AvatarMacDinh.jpg");

            if (img == null)
            {
                img = Image.FromFile(defaultPath);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public Image Base64ToImage(string base64)
        {
            string defaultPath = Path.Combine(
                                Application.StartupPath,
                                "Properties",
                                "Resources",
                                "Images", "AvatarMacDinh.png"
                            );

            // ✅ Nếu base64 rỗng => thử dùng ảnh mặc định, hoặc ảnh tạm
            if (string.IsNullOrEmpty(base64))
            {
                if (File.Exists(defaultPath))
                {
                    return Image.FromFile(defaultPath);
                }
                else
                {
                    // ✅ Không có file ảnh mặc định => tạo ảnh tạm để tránh lỗi
                    Bitmap bmp = new Bitmap(100, 100);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.LightGray);
                        g.DrawString("No Avatar", new Font("Segoe UI", 9, FontStyle.Bold),
                                     Brushes.Black, new PointF(10, 40));
                    }
                    return bmp;
                }
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                // ✅ Nếu base64 bị lỗi, vẫn fallback như trên
                if (File.Exists(defaultPath))
                    return Image.FromFile(defaultPath);

                Bitmap bmp = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.LightGray);
                    g.DrawString("Invalid Img", new Font("Segoe UI", 9, FontStyle.Bold),
                                 Brushes.Black, new PointF(10, 40));
                }
                return bmp;
            }
        }
        public async Task<List<USER>> GetRandomSuggest(string userId, int limit)
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
                    .Where(u => u.Id != userId)
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
                ChatId = conversationId,

                // NEW
                deletedFor = new List<string>(),
                isRecalled = false,
                recalledBy = "",
                recalledAt = (Timestamp?)null
            });
        }

        public async Task DeleteMessageForMeAsync(string messageId, string myUserId)
        {
            var msgRef = db.Collection("messages").Document(messageId);

            await msgRef.UpdateAsync(new Dictionary<string, object>
    {
        { "deletedFor", FieldValue.ArrayUnion(myUserId) }
    });
        }


        public async Task RecallMessageForAllAsync(string messageId, string myUserId)
        {
            var msgRef = db.Collection("messages").Document(messageId);
            var snap = await msgRef.GetSnapshotAsync();
            if (!snap.Exists) return;

            // Chặn thu hồi nếu không phải người gửi
            if (snap.TryGetValue("fromUserId", out string fromUserId))
            {
                if (fromUserId != myUserId)
                    throw new InvalidOperationException("Chỉ người gửi mới được thu hồi tin nhắn.");
            }

            await msgRef.UpdateAsync(new Dictionary<string, object>
{
    { "isRecalled", true },
    { "recalledBy", myUserId },
    { "recalledAt", Timestamp.GetCurrentTimestamp() },
    { "text", "" },
    { "imageUrl", FieldValue.Delete }
});
        }


        public string GetConversationId(string u1, string u2)
        {
            return string.Compare(u1, u2) < 0 ? $"{u1}_{u2}" : $"{u2}_{u1}";
        }


        public FirestoreChangeListener ListenToMessages(
     string myUserId,  // ✅ ĐỔI TÊN từ user1
     string targetUserId,  // ✅ ĐỔI TÊN từ user2
     Action<List<Messagemodels>> onMessagesChanged)
        {
            string chatId = GetConversationId(myUserId, targetUserId);

            System.Diagnostics.Debug.WriteLine($"🔍 Bắt đầu listen chatId: {chatId}");

            var messagesRef = db.Collection("messages")
                                .WhereEqualTo("ChatId", chatId);

            return messagesRef.Listen(snapshot =>
            {
                System.Diagnostics.Debug.WriteLine($"🔔 LISTENER TRIGGERED! Có {snapshot.Documents.Count} tin nhắn");

                List<Messagemodels> messages = new();

                foreach (var doc in snapshot.Documents)
                {
                    System.Diagnostics.Debug.WriteLine($"  📄 Doc ID: {doc.Id}");

                    // Check deletedFor
                    if (doc.TryGetValue("deletedFor", out List<string> deletedFor) &&
                        deletedFor != null && deletedFor.Contains(myUserId))  // ✅ SỬA user1 → myUserId
                    {
                        System.Diagnostics.Debug.WriteLine($"    ❌ Bỏ qua tin này (đã xóa phía tôi)");
                        continue;
                    }

                    var msg = doc.ConvertTo<Messagemodels>();
                    msg.Id = doc.Id;

                    // Check reaction
                    if (doc.TryGetValue("reaction", out Dictionary<string, string> reaction))
                    {
                        msg.reaction = reaction;
                        System.Diagnostics.Debug.WriteLine($"    💗 Có {reaction?.Count ?? 0} reactions");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"    ⚪ Không có reaction");
                    }

                    // Check thu hồi
                    if (doc.TryGetValue("isRecalled", out bool isRecalled) && isRecalled)
                    {
                        msg.text = "Tin nhắn đã được thu hồi";
                        msg.imageBase64 = null;
                        System.Diagnostics.Debug.WriteLine($"    🔙 Tin đã thu hồi");
                    }

                    messages.Add(msg);
                }

                // Sắp xếp
                messages = messages.OrderBy(m =>
                {
                    try { return m.timestamp.ToDateTime(); }
                    catch { return DateTime.MinValue; }
                }).ToList();

                System.Diagnostics.Debug.WriteLine($"✅ Gọi callback với {messages.Count} tin nhắn");
                onMessagesChanged(messages);
            });
        }
        public FirestoreChangeListener ListenToChatMeta(string user1, string user2, Action<ChatMeta> onMetaChanged)
        {
            string conversationId = GetConversationId(user1, user2);
            DocumentReference docRef = db.Collection("ChatMeta").Document(conversationId);

            return docRef.Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    ChatMeta meta = snapshot.ConvertTo<ChatMeta>();
                    meta.Id = snapshot.Id;
                    onMetaChanged?.Invoke(meta);
                }
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

                    string other = arr.FirstOrDefault(u => u != currentUserId);


                    if (!string.IsNullOrEmpty(other))
                    {
                        results.Add(other);
                    }
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
                    unread_userB = 0,
                    blockedBy = new List<string>()
                };

                await metaRef1.SetAsync(meta);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LỖI TẠO CHAT META: " + ex.Message);
            }
        }
        // =============================================
        // ============  VIDEO CALL MODULE  ============
        // =============================================


        /// <summary>
        /// Khởi tạo module VideoCall
        /// </summary>




        public event Action<VideoCall> OnIncomingCall;
        public event Action<VideoCall> OnCallAccepted;
        public event Action<VideoCall> OnCallRejected;
        public event Action<VideoCall> OnCallEnded;
        public event Action<IceCandidate> OnIceCandidate;

        /// <summary>
        /// Gửi lời mời gọi video
        /// </summary>
        public async Task<string> SendCallOffer(
            string callerId,
            string callerName,
            string receiverId,
            string offerSdp)
        {
            string callId = Guid.NewGuid().ToString();

            var callData = new VideoCall
            {
                CallId = callId,
                CallerId = callerId,
                CallerName = callerName,
                ReceiverId = receiverId,
                Offer = offerSdp,
                Status = "ringing",
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };

            await rtcClient
                .Child("video_calls")
                .Child(callId)
                .PutAsync(callData);

            return callId;
        }

        /// <summary>
        /// Lắng nghe các cuộc gọi đến user hiện tại
        /// </summary>
        public void ListenForIncomingCall(string userId)
        {
            if (callListener != null) return;


            callListener = rtcClient
                .Child("video_calls")
                .AsObservable<VideoCall>()
                .Subscribe(d =>
                {
                    if (d.Object == null) return;

                    var call = d.Object;

                    if (call.ReceiverId == userId && call.Status == "ringing")
                    {
                        // Kiểm tra thời gian để tránh nhận lại cuộc gọi cũ đã kết thúc
                        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        if (now - call.Timestamp < 10000) // Trong vòng 10 giây
                        {
                            OnIncomingCall?.Invoke(call);
                        }
                    }

                    if (call.CallerId == userId && call.Status == "accepted")
                        OnCallAccepted?.Invoke(call);

                    if ((call.CallerId == userId || call.ReceiverId == userId))
                    {
                        if (call.Status == "rejected") OnCallRejected?.Invoke(call);
                        if (call.Status == "ended") OnCallEnded?.Invoke(call);
                    }
                });
        }

        /// <summary>
        /// Trả lời cuộc gọi (send answer SDP)
        /// </summary>
        public async Task AcceptCall(string callId, string answerSdp)
        {
            await rtcClient
                .Child("video_calls")
                .Child(callId)
                .PatchAsync(new
                {
                    answer = answerSdp,
                    status = "accepted"
                });
        }

        /// <summary>
        /// Từ chối cuộc gọi
        /// </summary>
        public async Task RejectCall(string callId)
        {
            await rtcClient
                .Child("video_calls")
                .Child(callId)
                .PatchAsync(new { status = "rejected" });
        }

        /// <summary>
        /// Kết thúc cuộc gọi
        /// </summary>
        public async Task EndCall(string callId)
        {
            await rtcClient
                .Child("video_calls")
                .Child(callId)
                .PatchAsync(new { status = "ended" });
        }


        // =====================
        // ICE CANDIDATES
        // =====================

        public async Task SendIceCandidate(
    string callId, string userId,
    string candidate, string sdpMid, int index)
        {
            // Thêm kiểm tra an toàn
            if (rtcClient == null)
            {
                System.Diagnostics.Debug.WriteLine("LỖI: rtcClient chưa được khởi tạo!");
                return;
            }
            if (string.IsNullOrEmpty(callId))
            {
                System.Diagnostics.Debug.WriteLine("LỖI: callId bị null, chưa thể gửi candidate.");
                return;
            }

            var data = new IceCandidate
            {
                UserId = userId,
                Candidate = candidate,
                SdpMid = sdpMid,
                SdpMLineIndex = index
            };

            try
            {
                await rtcClient
                    .Child("ice_candidates")
                    .Child(callId)
                    .PostAsync(data);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi gửi ICE: " + ex.Message);
            }
        }

        public void ListenIceCandidate(string callId, string localUserId)
        {
            iceListener = rtcClient
                .Child("ice_candidates")
                .Child(callId)
                .AsObservable<IceCandidate>()
                .Subscribe(d =>
                {
                    if (d.Object == null) return;

                    var ice = d.Object;
                    if (ice.UserId != localUserId)
                        OnIceCandidate?.Invoke(ice);
                });

        }
        public void StopVideoCallListeners()
        {
            iceListener?.Dispose();
            iceListener = null;
        }
        public async Task UpdateMediaStatus(string callId, string userId, string type, string state)
        {
            try
            {
                // Lưu vào path: calls/{callId}/states/{userId}/{type}
                await rtcClient
                    .Child("video_calls")
                    .Child(callId)
                    .Child("states")
                    .Child(userId)
                    .Child(type) // "mic" hoặc "cam"
                    .PutAsync(state); // "on" hoặc "off"
            }
            catch { }
        }
        public event Action<string, string> OnMediaStatusChanged;

        public void ListenMediaStatus(string callId, string remoteUserId)
        {
            rtcClient
               .Child("video_calls")
               .Child(callId)
               .Child("states")
               .Child(remoteUserId)
               .AsObservable<string>()
               .Subscribe(d =>
               {
                   if (d.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate
        && !string.IsNullOrEmpty(d.Key)
        && !string.IsNullOrEmpty(d.Object))
                   {
                       OnMediaStatusChanged?.Invoke(d.Key, d.Object);
                   }
               });
        }
        //Kiểm tra gọi
        public async Task<VideoCall> CheckForPendingCalls(string myUserId)
        {
            try
            {
                var calls = await rtcClient
                    .Child("video_calls")
                    .OnceAsync<VideoCall>();

                foreach (var item in calls)
                {
                    var call = item.Object;
                    long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    if (call.ReceiverId == myUserId && call.Status == "ringing" && (now - call.Timestamp) < 30000)
                    {
                        return call;
                    }
                }
            }
            catch { }
            return null; // Không có ai gọi
        }
        public async Task BlockUser(string myId, string targetId)
        {
            string chatId = GetConversationId(myId, targetId);
            var docRef = db.Collection("ChatMeta").Document(chatId);
            await docRef.UpdateAsync("blockedBy", FieldValue.ArrayUnion(myId));
        }

        // Unblock
        public async Task UnblockUser(string myId, string targetId)
        {
            string chatId = GetConversationId(myId, targetId);
            var docRef = db.Collection("ChatMeta").Document(chatId);
            await docRef.UpdateAsync("blockedBy", FieldValue.ArrayRemove(myId));
        }

        // =================== KIỂM TRA BLOCK ===================
        public async Task<List<string>> GetBlockedList(string myId, string targetId)
        {
            string chatId = GetConversationId(myId, targetId);
            var doc = await db.Collection("ChatMeta").Document(chatId).GetSnapshotAsync();
            if (!doc.Exists) return new List<string>();
            if (doc.TryGetValue("blockedBy", out List<string> blocked))
                return blocked;
            return new List<string>();
        }

        public async Task<bool> IsBlocked(string myId, string targetId)
        {
            var blocked = await GetBlockedList(myId, targetId);
            return blocked.Contains(targetId); // người kia block mình
        }
        public async Task AddReaction(string messageId, string userId, string emoji)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"📝 AddReaction - MessageId: {messageId}, UserId: {userId}, Emoji: {emoji}");

                var docRef = db.Collection("messages").Document(messageId);

                // Kiểm tra document có tồn tại không
                var snapshot = await docRef.GetSnapshotAsync();
                if (!snapshot.Exists)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Document {messageId} KHÔNG TỒN TẠI!");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"✅ Document tồn tại, đang cập nhật...");

                await docRef.UpdateAsync(new Dictionary<string, object>
        {
            { $"reaction.{userId}", emoji }
        });

                System.Diagnostics.Debug.WriteLine($"✅ Đã cập nhật reaction thành công!");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ LỖI AddReaction: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"   StackTrace: {ex.StackTrace}");
                throw;
            }
        }
        public async Task RemoveReaction(string messageId, string userId)
        {
            var msgRef = db.Collection("messages").Document(messageId);
            await msgRef.UpdateAsync($"reaction.{userId}", FieldValue.Delete);
        }

        ///THÔNG BÁO

        public event Action<NotificationModel> OnNotificationReceived;
        public void StartListeningNotification(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return;
            DateTime appStartTime = DateTime.UtcNow;

            var observable = rtcClient
                .Child("notifications")
                .Child(userId) // Dùng userId động, không hardcode "user_id_123"
                .OrderByKey()
                .LimitToLast(1)
                .AsObservable<NotificationModel>();

            observable.Subscribe(d =>
            {
                // Chỉ xử lý khi có dữ liệu thêm mới hoặc cập nhật
                if (d.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                {
                    var noti = d.Object;


                    if (noti != null)
                    {
                        DateTime notiTime;
                        bool isValidTime = DateTime.TryParse(noti.Timestamp, out notiTime);

                        if (isValidTime)
                        {
                            DateTime notiTimeUTC = notiTime.ToUniversalTime();
                            if (notiTimeUTC > appStartTime)
                            {
                                OnNotificationReceived?.Invoke(noti);
                            }
                        }
                    }
                }
            });
        }





        public async Task<List<NotificationModel>> GetAllNotifications(string userId)
        {
            try
            {
                var items = await rtcClient
                    .Child("notifications")
                    .Child(userId)
                    .OrderByKey()
                    .LimitToLast(20) // Lấy 20 thông báo gần nhất
                    .OnceAsync<NotificationModel>();

                List<NotificationModel> list = new List<NotificationModel>();

                foreach (var item in items)
                {
                    var noti = item.Object;
                    noti.Id = item.Key;
                    list.Insert(0, noti);
                }
                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi lấy danh sách thông báo: " + ex.Message);
                return new List<NotificationModel>();
            }
        }

        public async Task PushNotificationAsync(string senderId, string senderName, string receiverId, string content, string type)
        {
            try
            {
                var noti = new NotificationModel
                {
                    Title = senderName,
                    Body = content,
                    Type = type,        // "like", "match", "message"
                    DataID = senderId,  // Gửi kèm ID người gửi
                    Timestamp = DateTime.UtcNow.ToString("o")
                };

                // Ghi vào nhánh notifications/{receiverId}
                await rtcClient.Child("notifications")
                               .Child(receiverId)
                               .PostAsync(noti);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi gửi thông báo: " + ex.Message);
            }
        }



        public async Task<bool> SaveLikeAction(string myId, string targetId)
        {
            try
            {
                // 1. KIỂM TRA: Tìm xem đã có bản ghi nào chưa
                QuerySnapshot checkSnap = await db.Collection("Likes")
                    .WhereEqualTo("fromUserId", myId)
                    .WhereEqualTo("toUserId", targetId)
                    .Limit(1) // Chỉ cần tìm thấy 1 cái là đủ kết luận
                    .GetSnapshotAsync();

                // 2. KẾT LUẬN: Nếu tìm thấy (>0) nghĩa là đã like rồi
                if (checkSnap.Count > 0)
                {
                    return false; // Trả về false để báo là "Đã like rồi"
                }

                // 3. THỰC HIỆN: Nếu chưa có thì mới thêm mới
                var likeData = new
                {
                    fromUserId = myId,
                    toUserId = targetId,
                    createdAt = Timestamp.GetCurrentTimestamp()
                };

                await db.Collection("Likes").AddAsync(likeData);
                return true; // Trả về true báo thành công
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                return false;
            }
        }
        public async Task<bool> CheckIfUserLikedMe(string myId, string targetId)
        {
            try
            {


                QuerySnapshot snap = await db.Collection("Likes")
                    .WhereEqualTo("fromUserId", targetId)
                    .WhereEqualTo("toUserId", myId)
                    .Limit(1) // Chỉ cần tìm thấy 1 cái là đủ
                    .GetSnapshotAsync();

                return snap.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task CreateMatchRecord(string user1, string user2)
        {
            string matchId = GetConversationId(user1, user2);

            DocumentSnapshot doc = await db.Collection("Matches").Document(matchId).GetSnapshotAsync();
            if (doc.Exists) return;

            var matchData = new
            {
                users = new System.Collections.Generic.List<string> { user1, user2 }, // Mảng users để query
                createdAt = Timestamp.GetCurrentTimestamp(),
                lastMessage = "You matched!",
                id = matchId
            };

            await db.Collection("Matches").Document(matchId).SetAsync(matchData);
        }
















        public string ImageFileToBase64(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
                return null;

            using (var img = Image.FromFile(imagePath))
            {
                return ImageToBase64(img); // hàm có sẵn trong file :contentReference[oaicite:2]{index=2}
            }
        }
        public async Task SendImageToConversationAsync(string fromUserId, string toUserId, string localImagePath)
        {
            if (string.IsNullOrWhiteSpace(fromUserId))
                throw new ArgumentException("fromUserId trống", nameof(fromUserId));

            if (string.IsNullOrWhiteSpace(toUserId))
                throw new ArgumentException("toUserId trống", nameof(toUserId));

            if (string.IsNullOrWhiteSpace(localImagePath) || !File.Exists(localImagePath))
                throw new ArgumentException("localImagePath không hợp lệ", nameof(localImagePath));

            string conversationId = GetConversationId(fromUserId, toUserId);
            string imageBase64 = ImageFileToBase64(localImagePath);

            var msgRef = db.Collection("messages").Document();

            await msgRef.SetAsync(new Dictionary<string, object>
    {
        { "fromUserId", fromUserId },
        { "toUserId", toUserId },
        { "text", "" },
        { "timestamp", Timestamp.GetCurrentTimestamp() },
        { "ChatId", conversationId },

        { "imageBase64", imageBase64 },

        { "reaction", new Dictionary<string, string>() },
        { "deletedFor", new List<string>() },
        { "isRecalled", false },
        { "recalledBy", "" },
        { "recalledAt", null }
    });

            await UpdateChatMeta(fromUserId, toUserId, "[Hình ảnh]");
        }
        public async Task<int> GetUserCountAsync()
        {
            var usersRef = db.Collection("Users");

            var snapshot = await usersRef
                .Count()
                .GetSnapshotAsync();

            return (int)snapshot.Count;
        }


        public async Task DeleteNotificationAsync(string userId, string notificationId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(notificationId)) return;

                await rtcClient
                    .Child("notifications")
                    .Child(userId)
                    .Child(notificationId)
                    .DeleteAsync();

                System.Diagnostics.Debug.WriteLine($"✅ Đã xóa thông báo: {notificationId}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi xóa thông báo: " + ex.Message);
            }
        }
    }
    }
