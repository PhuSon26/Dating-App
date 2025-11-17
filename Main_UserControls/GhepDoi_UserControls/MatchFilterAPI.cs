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
            CollectionReference userRef = db.Collection("User");
            Query query = userRef;
            if (!string.IsNullOrEmpty(filter.GioiTinh) && filter.GioiTinh != "Tất cả")
            {
                query = query.WhereEqualTo("gioitinh", filter.GioiTinh);
            }
            if (filter.DoTuoi.HasValue)
            {
                query = query.WhereLessThanOrEqualTo("tuoi", filter.DoTuoi.Value);
            }
            if (filter.ChieuCaoMin.HasValue)
            {
                query = query.WhereGreaterThanOrEqualTo("chieucao", filter.ChieuCaoMin.Value);
            }
            if (!string.IsNullOrWhiteSpace(filter.NoiSong))
            {
                query = query.WhereEqualTo("noisong", filter.NoiSong);
            }
            if (!string.IsNullOrWhiteSpace(filter.SoThich))
            {
                query = query.WhereArrayContains("sothich", filter.SoThich);
            }
            if (!string.IsNullOrWhiteSpace(filter.HocVan))
            {
                query = query.WhereEqualTo("hocvan", filter.HocVan);
            }
            if (!string.IsNullOrWhiteSpace(filter.CongViec))
            {
                query = query.WhereEqualTo("congviec", filter.CongViec);
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<USER> ans = new List<USER>();
            foreach(var doc in snapshot.Documents)
            {
                ans.Add(doc.ConvertTo<USER>());
            }
            return ans;
        }
    }
}
