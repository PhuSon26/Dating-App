using Dating_app_nhom3;
using LOGIN;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using Main_Interface.User_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace LOGIN
{
    public partial class FormDanhSachTinNhan : UserControl
    {
        private FirebaseAuthHelper firebase;
        private string myUserId = Session.LocalId;

        public FormDanhSachTinNhan()
        {
            InitializeComponent();
            firebase = new FirebaseAuthHelper("login - bb104");
        }

        // ==================================================
        // ===================== FORM LOAD ==================
        // ==================================================
        private async void FormDanhSachTinNhan_Load(object sender, EventArgs e)
        {
            await LoadMatchedUsers();
        }

        // ==================================================
        // ========= LẤY DANH SÁCH USER ĐÃ MATCH =============
        // ==================================================
        private async Task LoadMatchedUsers()
        {
            try
            {
               
                List<string> matchedUserIds = await firebase.GetMatchedUsers(myUserId);

                // 2. Lấy toàn bộ ChatMeta có liên quan đến user
                Dictionary<string, ChatMeta> metas =
                    (await firebase.GetAllChatMeta(myUserId))
                    .ToDictionary(m => m.Id, m => m);

                flowLayoutPanel1.Controls.Clear();

                // 3. Tạo list để sort theo lastTimestamp
                var items = new List<(UserChatitem item, Timestamp time)>();

                foreach (string otherId in matchedUserIds)
                {
                    USER otherUser = await firebase.GetUserById(otherId);

                    string metaId1 = $"{myUserId}_{otherId}";
                    string metaId2 = $"{otherId}_{myUserId}";

                    ChatMeta meta = null;

                    // kiểm tra meta của cặp này
                    if (metas.ContainsKey(metaId1)) meta = metas[metaId1];
                    else if (metas.ContainsKey(metaId2)) meta = metas[metaId2];

                    UserChatitem item;

                    if (meta != null)
                    {
                        // Có tin nhắn rồi
                        item = new UserChatitem(otherUser, meta);
                        items.Add((item, meta.lastTimestamp));
                    }
                    else
                    {
                        
                        ChatMeta emptyMeta = new ChatMeta
                        {
                            Id = metaId1,
                            lastMessage = "Hãy bắt đầu cuộc trò chuyện!",
                            lastTimestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                            unread_userA = 0,
                            unread_userB = 0,
                            userA = myUserId,
                            userB = otherId
                        };

                        item = new UserChatitem(otherUser, emptyMeta);

                        // Sắp xếp xuống dưới cùng vì chưa có chat
                        items.Add((item, Timestamp.FromDateTime(DateTime.UnixEpoch)));
                    }
                }

                // 4. Sort danh sách chat
                foreach (var x in items.OrderByDescending(i => i.time))
                {
                    // click → mở chat
                    x.item.Click += (s, e) => OpenChatWindow(x.item.UserData);
                    flowLayoutPanel1.Controls.Add(x.item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chat: " + ex.Message);
            }
        }



        // ==================================================
        // =================== MỞ CHAT =======================
        // ==================================================
        private void OpenChatWindow(USER user)
        {
            var chat = new NhanTin(user);
            chat.Show();
        }


        // ==================================================
        // =============== CLICK AVATAR ======================
        // ==================================================
        private void picAvatarNguoiDung_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở trang cá nhân!");
        }

        // ==================================================
        // ================== TÌM KIẾM =======================
        // ==================================================
       private void btnTimKiem_Click(object sender, EventArgs e)
{
    string keyword = txtTimKiem.Text.Trim().ToLower();

    foreach (Control c in flowLayoutPanel1.Controls)
    {
        if (c is UserChatitem item)
        {
            item.Visible = item.UserName.ToLower().Contains(keyword);
        }
    }
}


        // ==================================================
        // ===================== BACK ========================
        // ==================================================
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
