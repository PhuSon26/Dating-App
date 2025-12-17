using LOGIN;
using LOGIN.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class UC_ThongBaoList : UserControl
    {
        private FirebaseAuthHelper _auth;
        private string _userId;

        public UC_ThongBaoList(FirebaseAuthHelper auth, string userId)
        {
            InitializeComponent();
            _auth = auth;
            _userId = userId;
        }

        private async void UC_ThongBaoList_Load(object sender, EventArgs e)
        {
            await LoadNotifications();
        }

        public async Task LoadNotifications()
        {
            flowLayoutPanel1.Controls.Clear();

           
            var list = await _auth.GetAllNotifications(_userId);

            if (list.Count == 0)
            {
                Label lblEmpty = new Label { Text = "Không có thông báo nào.", AutoSize = true, ForeColor = Color.Gray, Margin = new Padding(20) };
                flowLayoutPanel1.Controls.Add(lblEmpty);
                return;
            }

            foreach (var item in list)
            {
                if (item.Type != "message")
                {
                    Panel pnlItem = new Panel();
                    pnlItem.Size = new Size(flowLayoutPanel1.Width - 25, 70);
                    pnlItem.BackColor = Color.White;
                    pnlItem.Margin = new Padding(5);
                    pnlItem.Cursor = Cursors.Hand;

                    // Vạch màu phân loại bên trái
                    Panel pnlStrip = new Panel { Width = 5, Dock = DockStyle.Left };
                    if (item.Type == "match") pnlStrip.BackColor = Color.FromArgb(253, 41, 123);
                    else if (item.Type == "like") pnlStrip.BackColor = Color.Gold;
                    else pnlStrip.BackColor = Color.Gray;

                    // Tiêu đề
                    Label lblTitle = new Label { Text = item.Title, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(15, 10), AutoSize = true };

                    // Nội dung
                    Label lblBody = new Label { Text = item.Body, Font = new Font("Segoe UI", 9, FontStyle.Regular), Location = new Point(15, 35), AutoSize = true, ForeColor = Color.DimGray };

                    pnlItem.Controls.Add(lblBody);
                    pnlItem.Controls.Add(lblTitle);
                    pnlItem.Controls.Add(pnlStrip);

                    // Sự kiện click vào item
                    pnlItem.Click += (s, e) => { MessageBox.Show("Bạn chọn: " + item.Title); };

                    flowLayoutPanel1.Controls.Add(pnlItem);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}