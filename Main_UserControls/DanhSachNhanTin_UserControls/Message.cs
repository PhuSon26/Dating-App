using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN.Main_UserControls.DanhSachNhanTin_UserControls
{
    [FirestoreData]
  
    public class Messagemodels
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public string fromUserId { get; set; }

        [FirestoreProperty]
        public string toUserId { get; set; }

        [FirestoreProperty]
        public string text { get; set; }

        [FirestoreProperty]
        public Timestamp timestamp { get; set; }

        [FirestoreProperty]
        public string ChatId { get; set; }
    }


}
