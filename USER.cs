using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Google.Cloud.Firestore;
using Firebase.Storage;

namespace LOGIN
{
    [FirestoreData]
    public class USER
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string ten { get; set; }

        [FirestoreProperty]
        public string gioitinh { get; set; }

        [FirestoreProperty]
        public int tuoi { get; set; }

        [FirestoreProperty]
        public string snhat { get; set; }

        [FirestoreProperty]
        public string hocvan { get; set; }

        [FirestoreProperty]
        public string nghenghiep { get; set; }

        [FirestoreProperty]
        public string thoiquen { get; set; }

        [FirestoreProperty]
        public string gthieu { get; set; }

        [FirestoreProperty]
        public int chieucao { get; set; }
        [FirestoreProperty]
        public string vitri { get; set; }

        [FirestoreProperty]
        public string AvatarUrl { get; set; }

        [FirestoreProperty]
        public List<string> photos { get; set; }

        [FirestoreProperty]
        public bool isVip { get; set; }
    }
}

