using Google.Cloud.Firestore;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using System.IO;
using Firebase.Storage;
using Firebase.Auth;

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

            // ===== KẾT NỐI VỚI FIRESTORE =====
            // File serviceAccountKey.json phải nằm cạnh LOGIN.exe
            string credPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "serviceAccountKey.json");

            // Cho SDK biết dùng file key nào
            Environment.SetEnvironmentVariable(
                "GOOGLE_APPLICATION_CREDENTIALS",
                credPath);

            // ProjectId xem ở Project settings / General
            db = FirestoreDb.Create("login-bb104");
        }

        // Hàm chung gửi POST request
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

        // Đăng ký tài khoản mới
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

        // Đăng xuất (trên desktop chỉ cần xóa token)
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
        // ==============================
        // XÓA TÀI KHOẢN TRONG FIREBASE AUTH
        // ==============================
        public Task<string> DeleteAccountAsync(string idToken)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:delete?key={apiKey}";
            var data = new
            {
                idToken = idToken
            };
            return PostAsync(url, data);  
        }
        // ==============================
        // XÓA HỒ SƠ USER TRONG FIRESTORE
        // ==============================
        public async Task DeleteUserInfoAsync(string uid)
        {
            // collection Users / document {uid}
            var docRef = db.Collection("Users").Document(uid);
            await docRef.DeleteAsync();
        }
        // =======================================================
        // API CUNG CẤP THÔNG TIN – LƯU VÀO FIRESTORE (KHÔNG RTDB)
        // Collection: "Users", Document id = user.Id
        // =======================================================
        public async Task CreateOrUpdateUserInfoAsync(USER user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Id))
                throw new ArgumentException("user.Id đang trống – phải truyền uid Firebase vào USER.Id.");

            // Lấy reference tới document /Users/{Id}
            DocumentReference docRef = db.Collection("Users").Document(user.Id);

            // Vì USER có [FirestoreData] + [FirestoreProperty] nên
            // SetAsync(user) là đủ, không cần Dictionary
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
        /// Lưu tin nhắn vào subcollection:
        ///   Matches/{matchId}/messages
        /// Đồng thời cập nhật trường lastMessage trong document Matches/{matchId}.
        /// </summary>
        /// <param name="matchId">Id document trong collection Matches</param>
        /// <param name="senderId">uid người gửi</param>
        /// <param name="text">nội dung text (có thể rỗng nếu chỉ gửi ảnh)</param>
        /// <param name="localImagePath">đường dẫn ảnh local, null nếu không gửi ảnh</param>
        /// <returns>Đối tượng ChatMessage đã gửi</returns>
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
                // "message_images" là tên folder trên Firebase Storage
                imageUrl = await uploadFile(localImagePath, "message_images");
            }

            // 2. Tạo object ChatMessage
            var msg = new ChatMessage
            {
                senderId = senderId,
                text = text ?? string.Empty,
                imageUrl = imageUrl,
                createdAt = Timestamp.FromDateTime(DateTime.UtcNow)
            };

            // 3. Ghi vào subcollection Matches/{matchId}/messages
            DocumentReference matchDoc = db.Collection("Matches").Document(matchId);
            CollectionReference messagesCol = matchDoc.Collection("messages");
            await messagesCol.AddAsync(msg);

            // 4. Cập nhật lastMessage trong document Matches/{matchId}
            string lastMsgPreview;
            if (!string.IsNullOrWhiteSpace(text))
                lastMsgPreview = text;
            else
                lastMsgPreview = "[Hình ảnh]";

            await matchDoc.UpdateAsync("lastMessage", lastMsgPreview);

            return msg;
        }
        public async Task<USER> getUser()
        {
            if (string.IsNullOrEmpty(userID)) return null;
            DocumentReference docRef = db.Collection("Users").Document(userID);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists) return null;
            return snapshot.ConvertTo<USER>();
        }
    }
}