using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.IO;

namespace LOGIN
{
    public static class FirebaseAdminService
    {
        public static void Init()
        {
            if (FirebaseApp.DefaultInstance != null) return;

            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "serviceAccountKey.json");

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(path)
            });
        }
    }
}
