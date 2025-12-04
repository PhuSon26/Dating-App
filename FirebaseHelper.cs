using Google.Cloud.Firestore;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        public FirebaseAuthHelper(string apiKey)
        {
            this.apiKey = apiKey;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"D:\api\key.json");
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

        // Đăng nhập
        public Task<string> SignIn(string email, string password)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}";
            var data = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };
            return PostAsync(url, data);
        }

        // Gửi email reset password
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

        public async Task<string> signInAndSetUser(string email,string password)
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

        public async Task<USER> getUser()
        {
            if (string.IsNullOrEmpty(userID)) return null;
            DocumentReference docRef = db.Collection("Users").Document(userID);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists) return null;
            return snapshot.ConvertTo<USER>();
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

            var messagesRef = db.Collection("messages")
                                .WhereEqualTo("ChatId", chatId)
                                .OrderBy("timestamp");

            return messagesRef.Listen(snapshot =>
            {
                List<Messagemodels> messages = new();

                foreach (var doc in snapshot.Documents)
                {
                    var msg = doc.ConvertTo<Messagemodels>();
                    msg.Id = doc.Id;
                    messages.Add(msg);
                }

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
        public async Task EnsureChatMeta(string u1, string u2)
        {
            string id = GetConversationId(u1, u2);

            var doc = db.Collection("ChatMeta").Document(id);
            var snap = await doc.GetSnapshotAsync();

            if (!snap.Exists)
            {
                await doc.SetAsync(new
                {
                    userA = (u1.CompareTo(u2) < 0) ? u1 : u2,
                    userB = (u1.CompareTo(u2) < 0) ? u2 : u1,
                    lastMessage = "",
                    lastTimestamp = Timestamp.GetCurrentTimestamp(),
                    unread_userA = 0,
                    unread_userB = 0
                });
            }
        }







        public async Task<List<string>> GetMatchedUsers(string currentUserId)
        {
            List<string> ids = new();
            //var matchRef = db.Collection("Matches").Document(currentUserId).Collection("matched");
            //var snap = await matchRef.GetSnapshotAsync();

            //foreach (var doc in snap.Documents)
            //{
            //    ids.Add(doc.Id);
            //}

            return ids;
        }


    }
}
