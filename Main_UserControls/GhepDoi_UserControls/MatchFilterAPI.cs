using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN.Main_UserControls.GhepDoi_UserControls
{
    public class MatchFilterAPI
    {
        public readonly FirestoreDb db;

        public MatchFilterAPI(string id)
        {
            db = FirestoreDb.Create(id);
        }

        public async Task<List<USER>> FilterUsers(FilterModel filter)
        {
            CollectionReference userRef = db.Collection("Users");
            Query query = userRef;
            if (!string.IsNullOrEmpty(filter.GioiTinh) && filter.GioiTinh != "Tất cả")
            {
                query = query.WhereEqualTo("gioitinh", filter.GioiTinh);
            }
            if (filter.DoTuoi.HasValue)
            {
                query = query.WhereLessThanOrEqualTo("tuoi", filter.DoTuoi.Value);
            }
            if (!string.IsNullOrWhiteSpace(filter.NoiSong))
            {
                query = query.WhereEqualTo("vitri", filter.NoiSong);
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<USER> ans = new List<USER>();
            foreach(var doc in snapshot.Documents)
            {
                ans.Add(doc.ConvertTo<USER>());
            }
            if (filter.ChieuCaoMin.HasValue)
            {
                ans = ans.Where(u => u.chieucao >= filter.ChieuCaoMin.Value).ToList();
            }
            return ans;
        }
        public static bool CheckFilter(USER user, FilterModel f)
        {
            if (user == null) return false;

            if (!string.IsNullOrEmpty(f.GioiTinh))
            {
                if (!string.Equals(user.gioitinh, f.GioiTinh, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            if (f.DoTuoi.HasValue)
            {
                if (user.tuoi != f.DoTuoi.Value)  
                    return false;
            }

            if (f.ChieuCaoMin.HasValue)
            {
                if (user.chieucao < f.ChieuCaoMin.Value)
                    return false;
            }

            if (!string.IsNullOrEmpty(f.NoiSong))
            {
                if (!string.Equals(user.vitri, f.NoiSong, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }
    }
}
