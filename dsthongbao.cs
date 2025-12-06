using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class dsthongbao : UserControl
    {
        public dsthongbao()
        {
            InitializeComponent();
            LoadRecentInteractions();
            LoadNotifications();
        }

        // ==========================
        // 1) TẢI DANH SÁCH TƯƠNG TÁC
        // ==========================
        private void LoadRecentInteractions()
        {
            // Dữ liệu mẫu
            List<string> avatarPaths = new List<string>()
            {
                "Images/u1.jpg",
                "Images/u2.jpg",
                "Images/u3.jpg",
                "Images/u4.jpg"
            };

            flpAvatars.Controls.Clear();

            foreach (var imgPath in avatarPaths)
            {
                PictureBox pic = new PictureBox();
                pic.Width = 65;
                pic.Height = 65;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Margin = new Padding(6);

                try
                {
                    pic.Image = Image.FromFile(imgPath);
                }
                catch
                {
                    pic.BackColor = Color.LightPink;
                    pic.Image = null; // Avatar lỗi
                }

                flpAvatars.Controls.Add(pic);
            }
        }

        // ==========================
        // 2) DANH SÁCH THÔNG BÁO
        // ==========================
        private void LoadNotifications()
        {
            // Fake data
            List<string> notifs = new List<string>()
            {
                "❤️ Anna đã thích bạn!",
                "💬 Brian vừa gửi bạn 1 tin nhắn.",
                "🔥 Bạn có 1 lượt match mới!",
                "📌 Lisa đã ghé thăm trang cá nhân bạn.",
                "💗 Một người bí mật đã Super Like bạn!"
            };

            pnlMessages.Controls.Clear();

            int y = 10;

            foreach (var text in notifs)
            {
                Label lbl = new Label();
                lbl.Text = text;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                lbl.AutoSize = true;
                lbl.Width = pnlMessages.Width - 30;
                lbl.Height = 40;
                lbl.Location = new Point(15, y);
                lbl.BackColor = Color.FromArgb(255, 240, 245);
                lbl.Padding = new Padding(10);
                lbl.BorderStyle = BorderStyle.FixedSingle;

                pnlMessages.Controls.Add(lbl);

                y += 55;
            }
        }

        // ==========================
        // 3) NÚT TÌM KIẾM
        // ==========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng tìm kiếm thông báo!", "Search");
        }

        // ==========================
        // 4) NÚT CÀI ĐẶT
        // ==========================
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở cài đặt thông báo!", "⚙️ Settings");
        }

        private void Thongbao_Load(object sender, EventArgs e)
        {

        }

        private void Thongbao_Load_1(object sender, EventArgs e)
        {

        }
    }
}
