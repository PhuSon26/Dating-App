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
        public string email;
        public string password;
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
            this.email = email;
            this.password = password;
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
        // Trong class FirebaseAuthHelper

        public async Task<string> UpdatePasswordInApp(string idToken, string newPassword)
        {
            // URL API update profile (bao gồm password)
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:update?key={apiKey}";

            var data = new
            {
                idToken = idToken,
                password = newPassword,
                returnSecureToken = true // Quan trọng: Yêu cầu trả về Token mới
            };

            // Gọi hàm PostAsync có sẵn của bạn
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

        public async Task<USER> getUser()
        {
            if (string.IsNullOrEmpty(userID)) return null;
            DocumentReference docRef = db.Collection("Users").Document(userID);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists) return null;
            return snapshot.ConvertTo<USER>();
        }
        /*
        public async Task<string> UploadAvatarAsync(string filePath, string userId)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var task = new FirebaseStorage("login-bb104.appspot.com")
                    .Child("avatars")
                    .Child(userId + ".jpg")
                    .PutAsync(stream);

                string downloadUrl = await task;
                return downloadUrl;
            }
        }
        public async Task<List<string>> UploadPhotosAsync(List<string> filePaths, string userId)
        {
            List<string> urls = new List<string>();
            foreach (var filePath in filePaths)
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    string fileName = Path.GetFileName(filePath);
                    var task = new FirebaseStorage("login-bb104.appspot.com")
                        .Child("users_photos")
                        .Child(userId)
                        .Child(fileName)
                        .PutAsync(stream);

                    string url = await task;
                    urls.Add(url);
                }
            }
            return urls;
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
        */
    }
}