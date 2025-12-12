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
        public int cnt_users_filtered = 0;
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

            if (!string.IsNullOrWhiteSpace(filter.NoiSong))
            {
                query = query.WhereEqualTo("vitri", filter.NoiSong);
            }

            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            List<USER> ans = snapshot.Documents
                .Select(d => d.ConvertTo<USER>())
                .ToList();

            if (filter.DoTuoi.HasValue)
            {
                ans = ans.Where(u => u.tuoi <= filter.DoTuoi.Value).ToList();
            }

            if (filter.ChieuCaoMin.HasValue)
            {
                ans = ans.Where(u => u.chieucao >= filter.ChieuCaoMin.Value).ToList();
            }
            cnt_users_filtered = ans.Count;
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
