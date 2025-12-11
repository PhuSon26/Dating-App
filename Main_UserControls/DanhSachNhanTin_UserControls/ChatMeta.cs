using Google.Cloud.Firestore;
using System;

namespace LOGIN.Main_UserControls.DanhSachNhanTin_UserControls
{
    [FirestoreData]
    public class ChatMeta
    {
        // Document Id (ví dụ "userA_userB")
        [FirestoreDocumentId]
        public string Id { get; set; }

        // Lưu hai user của cuộc hội thoại (để query dễ dàng)
        [FirestoreProperty]
        public string userA { get; set; }

        [FirestoreProperty]
        public string userB { get; set; }

        // Tin nhắn cuối cùng (preview)
        [FirestoreProperty]
        public string lastMessage { get; set; }

        // Thời gian tin nhắn cuối
        [FirestoreProperty]
        public Timestamp lastTimestamp { get; set; }

        // Số tin chưa đọc tương ứng với userA / userB
        [FirestoreProperty]
        public int unread_userA { get; set; }

        [FirestoreProperty]
        public int unread_userB { get; set; }

        [FirestoreProperty]

        public List<string> blockedBy { get; set; }
        // --- Helper methods ---

        // Trả về id của người còn lại trong cặp (dùng trong UI)
        public string OtherUserId(string myId)
        {
            if (string.IsNullOrEmpty(myId)) return null;

            if (string.Equals(userA, myId, StringComparison.OrdinalIgnoreCase)) return userB;
            if (string.Equals(userB, myId, StringComparison.OrdinalIgnoreCase)) return userA;

            // Nếu userA/userB không được set, cố gắng lấy từ Id (id dạng "a_b")
            if (!string.IsNullOrEmpty(Id) && Id.Contains("_"))
            {
                var parts = Id.Split('_', 2);
                if (parts.Length == 2)
                {
                    return parts[0] == myId ? parts[1] : (parts[1] == myId ? parts[0] : null);
                }
            }

            return null;
        }

        // Trả về unread count cho user hiện tại
        public int GetUnreadFor(string myId)
        {
            if (string.IsNullOrEmpty(myId)) return 0;
            if (string.Equals(userA, myId, StringComparison.OrdinalIgnoreCase)) return unread_userA;
            if (string.Equals(userB, myId, StringComparison.OrdinalIgnoreCase)) return unread_userB;

            // fallback: nếu Id chứa myId thì đoán vị trí
            if (!string.IsNullOrEmpty(Id) && Id.Contains("_"))
            {
                var parts = Id.Split('_', 2);
                if (parts.Length == 2)
                {
                    if (parts[0] == myId) return unread_userA;
                    if (parts[1] == myId) return unread_userB;
                }
            }
            return 0;
        }
    }
}
