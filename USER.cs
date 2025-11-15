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
        public string Name { get; set; }

        [FirestoreProperty]
        public string Gender { get; set; }

        [FirestoreProperty]
        public int Age { get; set; }

        [FirestoreProperty]
        public string AvatarUrl { get; set; }

    }
}
