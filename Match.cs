using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
namespace LOGIN
{
    [FirestoreData]
    public class Match
    {
        // createdAt: timestamp trong Firestore
        [FirestoreProperty]
        public Timestamp createdAt { get; set; }   // CHÚ Ý: Timestamp (chữ T hoa)

        // lastMessage: string
        [FirestoreProperty]
        public string lastMessage { get; set; }

        // users: mảng 2 userId
        [FirestoreProperty]
        public List<string> users { get; set; }
    }
}
