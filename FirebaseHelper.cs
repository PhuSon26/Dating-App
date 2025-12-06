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
        /// Lấy tất cả document trong collection "Matches"
        /// mà mảng users có chứa userId truyền vào.
        /// </summary>
        public async Task<List<Match>> GetMatchesAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("userId trống", nameof(userId));

            // Query: whereArrayContains("users", userId)
            // theo cú pháp array-contains của Firestore
            var query = db.Collection("Matches")
                          .WhereArrayContains("users", userId);

            QuerySnapshot snap = await query.GetSnapshotAsync();

            List<Match> matches = new List<Match>();

            foreach (DocumentSnapshot doc in snap.Documents)
            {
                if (!doc.Exists) continue;

                Match m = doc.ConvertTo<Match>();

                // Nếu muốn gán luôn doc.Id cho matchID:
                // if (string.IsNullOrEmpty(m.matchID))
                //     m.matchID = doc.Id;

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
    }
}