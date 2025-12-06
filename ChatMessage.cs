using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
namespace LOGIN
{
    [FirestoreData]
    public class ChatMessage
    {
        [FirestoreProperty]
        public string senderId { get; set; }

        [FirestoreProperty]
        public string text { get; set; }

        [FirestoreProperty]
        public string imageUrl { get; set; }

        [FirestoreProperty]
        public Timestamp createdAt { get; set; }

        // tin nhắn đã bị thu hồi chưa
        [FirestoreProperty]
        public bool isRecalled { get; set; } = false;

        // xoá vĩnh viễn (nếu muốn soft-delete)
        [FirestoreProperty]
        public bool isDeleted { get; set; } = false;

        // Id document trong subcollection messages – KHÔNG gắn FirestoreProperty
        // để không ghi field này lên Firestore (property không có attribute sẽ bị bỏ qua). 
        public string messageId { get; set; }
    }
}