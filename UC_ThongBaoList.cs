using Google.Api.Gax;
using LOGIN;
using LOGIN.Models;
using Main_Interface;
using Main_Interface.User_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        private void UC_ThongBaoList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            _ = LoadNotifications();
        }



        public async Task LoadNotifications()
        {
            try
            {
                // 1. Lấy dữ liệu ngoài luồng UI
                var list = await _auth.GetAllNotifications(_userId);

                // 2. Cập nhật UI an toàn
                this.Invoke(new Action(() => {
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.BringToFront();
                    var displayList = list?.Where(item => item.Type != "message").ToList();
                    if (displayList == null || displayList.Count == 0)
                    {
                        ShowEmptyState();
                        return;
                    }

                    foreach (var item in displayList)
                    {
                        Panel pnlItem = CreateNotificationPanel(item);
                        flowLayoutPanel1.Controls.Add(pnlItem);
                    }

                    flowLayoutPanel1.PerformLayout();
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải thông báo: " + ex.Message);
            }
        }

       
        private Panel CreateNotificationPanel(NotificationModel item)
        {
            Panel pnlItem = new Panel
            {
                // Sử dụng ClientSize để lấy kích thước thực tế trừ đi thanh cuộn
                Size = new Size(flowLayoutPanel1.ClientSize.Width - 10, 75),
                BackColor = Color.White,
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            // Vạch màu trang trí bên trái
            Panel pnlStrip = new Panel { Width = 6, Dock = DockStyle.Left };
            pnlStrip.BackColor = (item.Type == "match") ? Color.DeepPink : (item.Type == "like" ? Color.Gold : Color.Gray);

            Label lblTitle = new Label
            {
                Text = item.Title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblBody = new Label
            {
                Text = item.Body,
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 38),
                ForeColor = Color.DimGray,
                AutoSize = true
            };

            pnlItem.Controls.AddRange(new Control[] { lblTitle, lblBody, pnlStrip });
            pnlItem.Click += async (s, e) => await HandleNotificationClick(item, pnlItem);

            return pnlItem;
        }
        private void ShowEmptyState()
        {
            // Đảm bảo chạy trên luồng UI
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowEmptyState));
                return;
            }

            flowLayoutPanel1.Controls.Clear();

            // Tạo Label thông báo trống
            Label lblEmpty = new Label
            {
                Text = "Bạn chưa có thông báo nào mới! ✨",
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = Color.DeepPink,
                TextAlign = ContentAlignment.MiddleCenter,
                // Ép kích thước theo chiều rộng của FlowLayoutPanel
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                // Tăng chiều cao để nội dung không bị sát mép trên
                Height = 200,
                Margin = new Padding(10, 50, 10, 0)
            };

            flowLayoutPanel1.Controls.Add(lblEmpty);

            // Cập nhật lại bố cục
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel1.Invalidate(); // Ép vẽ lại
        }


        private async Task HandleNotificationClick(NotificationModel item, Panel pnlItem)
        {
            try
            {
                // 1. Lấy thông tin đối phương (DataID là ID của người gửi)
                USER otherUser = await _auth.GetUserById(item.DataID);
                if (otherUser == null) return;

                Main mainForm = this.ParentForm as Main;
                if (item.Type == "like")
                {
                    ChiTietUser detailForm = new ChiTietUser(mainForm,otherUser,this);
                    mainForm.LoadContent(detailForm);
                    
                }
                else if (item.Type == "match")
                {
                    NhanTin chatForm = new NhanTin(otherUser, mainForm);
                    mainForm.LoadContent(chatForm);
                }

                
                await _auth.DeleteNotificationAsync(_userId, item.Id);

               
                flowLayoutPanel1.Controls.Remove(pnlItem);
                pnlItem.Dispose();

                int panelCount = 0;
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    // Chỉ đếm những Panel không phải là pnlCenter/pnlContainer của trạng thái trống
                    if (c is Panel && c.Controls.Count > 0 && !(c.Controls[0] is Label && c.Controls[0].Text.Contains("✨")))
                    {
                        panelCount++;
                    }
                }

                if (panelCount == 0)
                {
                    ShowEmptyState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý thông báo: " + ex.Message);
            }
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          
        }
        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.Width = flowLayoutPanel1.ClientSize.Width - 10;
            }
        }
    }
}