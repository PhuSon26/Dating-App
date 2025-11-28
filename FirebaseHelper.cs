using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace LOGIN
{
    public class FirebaseAuthHelper
    {
        private readonly string apiKey;

        // FirestoreDb để lưu hồ sơ user
        private readonly FirestoreDb db;

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

        // ==============================
        // HÀM CHUNG GỬI POST REQUEST
        // ==============================
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

        // ==============================
        // ĐĂNG KÝ TÀI KHOẢN MỚI (AUTH)
        // ==============================
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

        // ==============================
        // ĐĂNG NHẬP (AUTH)
        // ==============================
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

        // ==============================
        // GỬI EMAIL RESET PASSWORD
        // ==============================
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

        // ==============================
        // ĐĂNG XUẤT (XÓA TOKEN TRONG APP)
        // ==============================
        public void SignOut(ref string idToken, ref string refreshToken)
        {
            idToken = null;
            refreshToken = null;
        }

        // ==============================
        // KIỂM TRA TOKEN CÒN HỢP LỆ KHÔNG
        // ==============================
        public Task<string> VerifyIdToken(string idToken)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:lookup?key={apiKey}";
            var data = new
            {
                idToken = idToken
            };
            return PostAsync(url, data);
        }

        // ==============================
        // ĐỔI MẬT KHẨU (bạn chỉnh sau cũng được)
        // ==============================
        public async Task<string> UpdatePassword(string email, string newPassword)
        {
            var signInResult = await SignIn(email, newPassword);
            var idToken = JsonSerializer.Deserialize<JsonElement>(signInResult)
                                      .GetProperty("idToken").GetString();

            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:update?key={apiKey}";
            var data = new
            {
                idToken = idToken,
                password = newPassword,
                returnSecureToken = true
            };
            return await PostAsync(url, data);
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

        // (tùy, có thể dùng khi load hồ sơ)
        public async Task<USER?> GetUserInfoAsync(string uid)
        {
            DocumentReference docRef = db.Collection("Users").Document(uid);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists) return null;

            return snapshot.ConvertTo<USER>();
        }
    }
}
