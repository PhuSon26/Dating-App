using LOGIN;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Main_Interface.User_Controls.CaiDat_UserControls
{
    public partial class DanhSachChan : UserControl
    {
        private Main MainForm;
        private FirebaseAuthHelper auth;

        public DanhSachChan()
        {
            InitializeComponent();
        }

        public DanhSachChan(Main m, FirebaseAuthHelper auth)
        {
            InitializeComponent();
            MainForm = m;
            this.auth = auth;
            loadBlockedUsers();
        }

        private async void loadBlockedUsers()
        {
            flp_list.Controls.Clear();
            var allMetas = await auth.GetAllChatMeta(Session.LocalId);

            foreach (var meta in allMetas)
            {
                // Khởi tạo blockedBy nếu null
                var blockedBy = meta.blockedBy ?? new List<string>();
                if (!blockedBy.Contains(Session.LocalId)) continue; // chỉ lấy người mình block

                string otherUserId = meta.userA == Session.LocalId ? meta.userB : meta.userA;
                var user = await auth.GetUserById(otherUserId);
                if (user == null) continue;

                var panelItem = new UserBlockItemPanel(user, meta, auth);
                panelItem.UnBlockClicked += async (u, panel) =>
                {
                    // Unblock user
                    await auth.UnblockUser(Session.LocalId, u.Id);

                    // Remove panel khỏi FlowLayoutPanel
                    flp_list.Controls.Remove(panel);
                    panel.Dispose();
                };

                flp_list.Controls.Add(panelItem);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.LoadContent(new CaiDat(MainForm));
        }
    }

    // Panel cho từng user bị block
    public class UserBlockItemPanel : Panel
    {
        public UserChatitem UserItem { get; set; }
        public Button btn_unblock { get; set; }

        public event Action<USER, UserBlockItemPanel> UnBlockClicked;

        public UserBlockItemPanel(USER u, ChatMeta meta, FirebaseAuthHelper auth)
        {
            this.Width = 580;
            this.Height = 100;
            this.Margin = new Padding(5);
            this.BackColor = Color.Transparent;

            // Tạo UserChatitem
            UserItem = new UserChatitem(u, meta, auth)
            {
                Location = new Point(0, 0),
                Width = 480,
                Height = 100
            };

            // Tạo nút Unblock bên phải
            btn_unblock = new Button
            {
                Text = "Unblock",
                Width = 80,
                Height = 30,
                Left = 490,
                Top = (this.Height - 30) / 2,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn_unblock.FlatAppearance.BorderSize = 0;

            btn_unblock.Click += (s, e) =>
            {
                UnBlockClicked?.Invoke(u, this);
            };

            this.Controls.Add(UserItem);
            this.Controls.Add(btn_unblock);
        }
    }
}
