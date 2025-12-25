using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace LOGIN
{
    // Mô hình dữ liệu (Map đúng với Firebase)
   

    public class FirebaseService
    {
        private readonly FirebaseClient firebase;

        private const string DB_URL = "https://login-bb104-default-rtdb.firebaseio.com/notifications";

        public FirebaseService()
        {
            // Không cần AuthSecret cho chế độ Test Mode
            firebase = new FirebaseClient(DB_URL);
        }

        // --- HÀM 1: LẮNG NGHE (Nhận thông báo về) ---
      
        // --- HÀM 2: GỬI (Để test chức năng) ---
       
    }
}