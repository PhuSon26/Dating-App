using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIN
{
    public class Match
    {
        private FirestoreDb db;
        private string currentUserId;

        public Match(string projectId, string currentUserId)
        {
            
            if (string.IsNullOrEmpty(projectId)) projectId = "login-bb104";

            db = FirestoreDb.Create(projectId);
            this.currentUserId = currentUserId;
        }

        public async Task<bool> LikeUser(string targetUserId)
        {
          
            string likeDocId = $"{currentUserId}_{targetUserId}";
            DocumentReference likeRef = db.Collection("Likes").Document(likeDocId);

           
            await likeRef.SetAsync(new Dictionary<string, object>
            {
                { "fromUserId", currentUserId },
                { "toUserId", targetUserId },
                { "createdAt", Timestamp.GetCurrentTimestamp() }
            });

          
            string theirLikeDocId = $"{targetUserId}_{currentUserId}";
            DocumentSnapshot snapshot = await db.Collection("Likes").Document(theirLikeDocId).GetSnapshotAsync();

            if (snapshot.Exists)
            {
              
                var users = new List<string> { currentUserId, targetUserId };
                users.Sort();
                string matchId = string.Join("_", users);

                var matchesRef = db.Collection("Matches").Document(matchId);

               
                await matchesRef.SetAsync(new Dictionary<string, object>
                {
                    { "users", new List<string>{ currentUserId, targetUserId } }, // Mảng chứa 2 UID
                    { "createdAt", Timestamp.GetCurrentTimestamp() },
                    { "lastMessage", "" }
                });

                return true; 
            }

            return false; 
        }
    }
}
