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
        public string senderId { get; set; }      // uid người gửi

        [FirestoreProperty]
        public string text { get; set; }         // nội dung text (có thể rỗng nếu chỉ gửi ảnh)

        [FirestoreProperty]
        public string imageUrl { get; set; }     // link ảnh (có thể null nếu chỉ gửi text)

        [FirestoreProperty]
        public Timestamp createdAt { get; set; } // thời gian gửi (UTC)
    }
}