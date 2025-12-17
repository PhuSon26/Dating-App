using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using LOGIN;
using Main_Interface.User_Controls;
using Main_Interface;

namespace LOGIN
{
    public partial class ChiTietUser : UserControl
    {
        private USER user;
        private Main MainForm;
        private FlowLayoutPanel mainContainer; // Panel chính để cuộn

        public ChiTietUser(Main main, USER u)
        {
            // Không cần InitializeComponent() nếu không dùng Designer file
            this.MainForm = main;
            this.user = u;

            // Cài đặt chung cho UserControl
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Tạo Container chính (Cho phép cuộn dọc)
            mainContainer = new FlowLayoutPanel();
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.AutoScroll = true;
            mainContainer.FlowDirection = FlowDirection.TopDown;
            mainContainer.WrapContents = false; // Xếp chồng theo chiều dọc
            mainContainer.Padding = new Padding(0, 0, 0, 50); // Padding đáy để không bị sát mép
            this.Controls.Add(mainContainer);

            // 2. Nút Quay lại (Sticky ở trên cùng hoặc thêm vào đầu list)
            Panel pnlHeader = new Panel();
            pnlHeader.Size = new Size(MainForm.Width, 50);
            pnlHeader.Margin = new Padding(0);

            Button btnBack = new Button();
            btnBack.Text = "⬅ Quay lại";
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.ForeColor = Color.FromArgb(253, 41, 123);
            btnBack.Location = new Point(20, 15);
            btnBack.Size = new Size(120, 40);
            btnBack.Click += (s, e) => { MainForm.LoadContent(new GhepDoi(MainForm)); };
            pnlHeader.Controls.Add(btnBack);
            mainContainer.Controls.Add(pnlHeader);

            // 3. Ảnh đại diện & Tên
            AddProfileHeader();

            // 4. Thông tin chi tiết (Nghề, Học vấn, Chiều cao...)
            AddBasicInfoSection();

            // 5. Giới thiệu (Bio)
            AddSectionTitle("Giới thiệu bản thân");
            Label lblBio = new Label();
            lblBio.Text = string.IsNullOrEmpty(user.gthieu) ? "Người dùng chưa viết giới thiệu." : user.gthieu;
            lblBio.Font = new Font("Segoe UI", 11);
            lblBio.ForeColor = Color.DimGray;
            lblBio.AutoSize = true;
            lblBio.MaximumSize = new Size(MainForm.panelContent.Width - 60, 0); // Tự xuống dòng
            lblBio.Margin = new Padding(30, 5, 30, 20);
            mainContainer.Controls.Add(lblBio);

            // 6. Sở thích (Tags)
            AddSectionTitle("Sở thích & Thói quen");
            AddHobbiesSection();

            // 7. Thư viện ảnh (User.photos)
            AddSectionTitle("Thư viện ảnh");
            AddPhotoGallery();
        }

        // --- CÁC HÀM CON DỰNG GIAO DIỆN ---

        private async void AddProfileHeader()
        {
            // Panel chứa ảnh và tên
            FlowLayoutPanel pnlProfile = new FlowLayoutPanel();
            pnlProfile.FlowDirection = FlowDirection.TopDown;
            pnlProfile.AutoSize = true;
            pnlProfile.Width = MainForm.panelContent.Width - 40;
            pnlProfile.Margin = new Padding(20, 0, 20, 20);
            pnlProfile.WrapContents = false;

            // Ảnh đại diện tròn/vuông bo góc
            PictureBox pbAvatar = new PictureBox();
            pbAvatar.Size = new Size(150, 150);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbAvatar.Margin = new Padding((pnlProfile.Width - 150) / 2, 0, 0, 10); // Căn giữa

            // Load Avatar Async
            if (!string.IsNullOrEmpty(user.AvatarUrl))
            {
                // Giả lập load ảnh, bạn có thể thay bằng hàm LoadImageFromUrl của bạn
                pbAvatar.ImageLocation = user.AvatarUrl;
            }
            else
            {
                pbAvatar.BackColor = Color.LightGray; // Ảnh mặc định
            }
            pnlProfile.Controls.Add(pbAvatar);

            // Tên và Tuổi
            Label lblName = new Label();
            lblName.Text = $"{user.ten}, {user.tuoi}";
            lblName.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblName.AutoSize = true;
            lblName.ForeColor = Color.Black;
            lblName.Margin = new Padding((pnlProfile.Width - 100) / 2, 0, 0, 0); // Cố gắng căn giữa tương đối
            pnlProfile.Controls.Add(lblName);

          

            mainContainer.Controls.Add(pnlProfile);
        }

        private void AddBasicInfoSection()
        {
            FlowLayoutPanel pnlInfo = new FlowLayoutPanel();
            pnlInfo.Width = MainForm.panelContent.Width - 40;
            pnlInfo.AutoSize = true;
            pnlInfo.FlowDirection = FlowDirection.LeftToRight;
            pnlInfo.Margin = new Padding(20, 0, 20, 20);

            // Thêm từng mục thông tin
            pnlInfo.Controls.Add(CreateInfoItem("💼", "Nghề nghiệp", user.nghenghiep));
            pnlInfo.Controls.Add(CreateInfoItem("🎓", "Học vấn", user.hocvan));
            pnlInfo.Controls.Add(CreateInfoItem("📏", "Chiều cao", user.chieucao > 0 ? $"{user.chieucao} cm" : "Chưa cập nhật"));
            pnlInfo.Controls.Add(CreateInfoItem("⚧", "Giới tính", user.gioitinh));
            pnlInfo.Controls.Add(CreateInfoItem("🎂", "Sinh nhật", user.snhat));
            pnlInfo.Controls.Add(CreateInfoItem("📍", "Nơi sống", user.vitri));

            mainContainer.Controls.Add(pnlInfo);
        }

        private Panel CreateInfoItem(string icon, string title, string value)
        {
            Panel p = new Panel();
            // Tăng chiều rộng từ 180 lên 210 để chữ dài không bị xuống dòng xấu
            p.Size = new Size(210, 70);
            p.Margin = new Padding(10); // Tăng khoảng cách giữa các ô
            p.BackColor = Color.FromArgb(248, 249, 250);

            // Bo tròn góc cho ô thông tin (Tuỳ chọn, giúp đẹp hơn)
            p.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    Rectangle r = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                    e.Graphics.DrawRectangle(pen, r);
                }
            };

            // 1. Icon: Giữ nguyên vị trí
            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 20), // Icon to hơn chút
                Location = new Point(10, 15),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // 2. Tiêu đề (Nghề nghiệp...): Đẩy X từ 50 lên 75 để tránh bị Icon đè
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(75, 12), // SỬA TẠI ĐÂY (50 -> 75)
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // 3. Giá trị (IT, 67cm...): Cũng đẩy X lên 75
            Label lblValue = new Label
            {
                Text = string.IsNullOrEmpty(value) ? "---" : value,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(75, 35), // SỬA TẠI ĐÂY (50 -> 75)
                AutoSize = true,
                MaximumSize = new Size(130, 0), // Giới hạn chiều ngang để tự xuống dòng nếu quá dài
                BackColor = Color.Transparent
            };

            p.Controls.Add(lblIcon);
            p.Controls.Add(lblTitle);
            p.Controls.Add(lblValue);

            // Đưa Icon lên trên cùng về mặt hiển thị (Z-order) để chắc chắn không bị đè
            lblIcon.BringToFront();

            return p;
        }

        private void AddHobbiesSection()
        {
            if (string.IsNullOrEmpty(user.thoiquen)) return;

            FlowLayoutPanel pnlTags = new FlowLayoutPanel();
            pnlTags.Width = MainForm.panelContent.Width - 60;
            pnlTags.AutoSize = true;
            pnlTags.Margin = new Padding(30, 5, 30, 20);

            var hobbies = user.thoiquen.Split(',');
            foreach (var hobby in hobbies)
            {
                Label lblTag = new Label();
                lblTag.Text = hobby.Trim();
                lblTag.AutoSize = true;
                lblTag.Padding = new Padding(10, 5, 10, 5);
                lblTag.BackColor = Color.White;
                lblTag.ForeColor = Color.FromArgb(253, 41, 123);
                lblTag.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTag.Margin = new Padding(0, 0, 10, 10);

                // Vẽ viền cho tag
                lblTag.Paint += (s, e) => {
                    ControlPaint.DrawBorder(e.Graphics, lblTag.ClientRectangle, Color.FromArgb(253, 41, 123), ButtonBorderStyle.Solid);
                };

                pnlTags.Controls.Add(lblTag);
            }
            mainContainer.Controls.Add(pnlTags);
        }

        private void AddPhotoGallery()
        {
            // Kiểm tra list ảnh
            if (user.photos == null || user.photos.Count == 0)
            {
                Label lblEmpty = new Label { Text = "Chưa có ảnh nào khác.", AutoSize = true, Margin = new Padding(30, 5, 0, 20), ForeColor = Color.Gray };
                mainContainer.Controls.Add(lblEmpty);
                return;
            }

            FlowLayoutPanel pnlGallery = new FlowLayoutPanel();
            pnlGallery.Width = MainForm.panelContent.Width - 40;
            pnlGallery.AutoSize = true;
            pnlGallery.Margin = new Padding(20, 0, 20, 20);

            foreach (string imgUrl in user.photos)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(150, 200); // Kích thước ảnh trong gallery
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Margin = new Padding(5);
                pb.BackColor = Color.Black;

                // Load ảnh Async
                try
                {
                    pb.ImageLocation = imgUrl;
                }
                catch { }

                pnlGallery.Controls.Add(pb);
            }
            mainContainer.Controls.Add(pnlGallery);
        }

        // Hàm tiện ích tạo tiêu đề mục
        private void AddSectionTitle(string title)
        {
            Label lbl = new Label();
            lbl.Text = title;
            lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.AutoSize = true;
            lbl.Margin = new Padding(20, 10, 0, 5);
            mainContainer.Controls.Add(lbl);
        }
    }
}