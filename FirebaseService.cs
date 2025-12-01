using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Reactive.Linq; // Cần thiết cho AsObservable
using System.Threading.Tasks;

namespace LOGIN
{
    // 1. Mô hình dữ liệu (Map đúng với Firebase)
    public class NotificationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; } // Match, Like, Message
        public string CreatedAt { get; set; }
    }

    public class FirebaseService
    {
        private readonly FirebaseClient firebase;

        // Thay URL của bạn vào đây
        private const string DB_URL = "https://login-bb104-default-rtdb.firebaseio.com/notifications";

        public FirebaseService()
        {
            // Không cần AuthSecret cho chế độ Test Mode
            firebase = new FirebaseClient(DB_URL);
        }

        // --- HÀM 1: LẮNG NGHE (Nhận thông báo về) ---
        public void ListenToNotifications(Action<NotificationModel> onReceived)
        {
            var observable = firebase
                .Child("notifications")
                .AsObservable<NotificationModel>()
                .Subscribe(d =>
                {
                    // Chỉ lấy sự kiện Thêm mới (Insert)
                    if (d.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                    {
                        if (d.Object != null)
                        {
                            onReceived(d.Object);
                        }
                    }
                });
        }

        // --- HÀM 2: GỬI (Để test chức năng) ---
        public async Task SendFakeNotification(string title, string content, string type)
        {
            var notif = new NotificationModel
            {
                Title = title,
                Content = content,
                Type = type,
                CreatedAt = DateTime.Now.ToString()
            };

            // Đẩy dữ liệu lên node "notifications"
            await firebase.Child("notifications").PostAsync(notif);
        }
    }
}