using System;
using System.Drawing;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace LOGIN.Main_UserControls.DanhSachNhanTin_UserControls
{
    public class UserChatitem : UserControl
    {
        private PictureBox picAvatar;
        private Label lblName;
        private Label lblLastMessage;
        private Label lblTime;
        private Label lblBadge;

        public string UserName => lblName.Text;
        public USER UserData { get; private set; }
        public ChatMeta MetaData { get; private set; }

        public UserChatitem(USER user, ChatMeta meta)
        {
            UserData = user;
            MetaData = meta;

            this.Width = 320;
            this.Height = 75;
            this.BackColor = Color.White;
            this.Margin = new Padding(5);
            this.Cursor = Cursors.Hand;

            InitializeComponents();
            BindData();
        }

        private void InitializeComponents()
        {
            picAvatar = new PictureBox
            {
                Width = 55,
                Height = 55,
                Left = 10,
                Top = 10,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            lblName = new Label
            {
                Left = 80,
                Top = 5,
                Width = 200,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            lblLastMessage = new Label
            {
                Left = 80,
                Top = 30,
                Width = 200,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray
            };

            lblTime = new Label
            {
                Left = 260,
                Top = 5,
                Width = 50,
                Font = new Font("Segoe UI", 8),
                TextAlign = ContentAlignment.TopRight,
                ForeColor = Color.Gray
            };

            lblBadge = new Label
            {
                Left = 260,
                Top = 35,
                Width = 30,
                Height = 20,
                BackColor = Color.Red,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Visible = false
            };

            this.Controls.Add(picAvatar);
            this.Controls.Add(lblName);
            this.Controls.Add(lblLastMessage);
            this.Controls.Add(lblTime);
            this.Controls.Add(lblBadge);

            // Event click toàn bộ item
            this.Click += (s, e) => this.OnClick(e);
            foreach (Control c in this.Controls)
                c.Click += (s, e) => this.OnClick(e);
        }

        private void BindData()
        {
            lblName.Text = UserData.ten ?? "Không tên";

            if (!string.IsNullOrEmpty(UserData.AvatarUrl))
            {
                try
                {
                    picAvatar.LoadAsync(UserData.AvatarUrl);
                }
                catch
                {
                   
                }
            }

            lblLastMessage.Text = MetaData.lastMessage ?? "";
            lblTime.Text = FormatTime(MetaData.lastTimestamp);

            // Hiển thị badge chưa đọc
            int unread = GetUnreadCount();
            if (unread > 0)
            {
                lblBadge.Text = unread.ToString();
                lblBadge.Visible = true;
            }
        }

        private int GetUnreadCount()
        {
            string me = Session.LocalId;

            if (me == MetaData.userA)
                return MetaData.unread_userA;
            else
                return MetaData.unread_userB;
        }
       

        private string FormatTime(Timestamp t)
        {
            if (t == null) return "";

            var dt = t.ToDateTime();
            if (dt.Date == DateTime.Now.Date)
                return dt.ToString("HH:mm");

            return dt.ToString("dd/MM");
        }
    }
}
