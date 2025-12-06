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

        // ============================================
        // SEND MESSAGE (ĐÃ SỬA NGOẶC, TÁCH HÀM)
        // ============================================
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

            string imageUrl = null;
            if (!string.IsNullOrWhiteSpace(localImagePath))
            {
                imageUrl = await uploadFile(localImagePath, "message_images");
            }

            var msg = new ChatMessage
            {
                senderId = senderId,
                text = text ?? string.Empty,
                imageUrl = imageUrl,
                createdAt = Timestamp.FromDateTime(DateTime.UtcNow)
            };

            DocumentReference matchDoc = db.Collection("Matches").Document(matchId);
            CollectionReference messagesCol = matchDoc.Collection("messages");
            await messagesCol.AddAsync(msg);

            string lastMsgPreview;
            if (!string.IsNullOrWhiteSpace(text))
                lastMsgPreview = text;
            else
                lastMsgPreview = "[Hình ảnh]";

            await matchDoc.UpdateAsync("lastMessage", lastMsgPreview);

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
    }
}
