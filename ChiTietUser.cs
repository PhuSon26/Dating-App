using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Main_Interface;
using Main_Interface.User_Controls;
using LOGIN.Models;

namespace LOGIN
{
    public partial class ChiTietUser : UserControl
    {
        private USER user;
        private Main MainForm;
        private FlowLayoutPanel mainContainer;
        private GhepDoi _previousScreen = null;
        private UC_ThongBaoList _thongBaoScreen;
        private NhanTin nt = null;
        public ChiTietUser(Main main, USER u, GhepDoi prev)
        {
            this.MainForm = main;
            this.user = u;
            this._previousScreen = prev;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            SetupUI();
        }
        public ChiTietUser(Main main, USER u, NhanTin nt)
        {
            this.MainForm = main;
            this.user = u;
            this.nt = nt;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            SetupUI();
        }
        public ChiTietUser(Main main, USER u, UC_ThongBaoList tb)
        {
            this.MainForm = main;
            this.user = u;
            this._thongBaoScreen = tb; 
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Container chính
            mainContainer = new FlowLayoutPanel();
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.AutoScroll = true;
            mainContainer.FlowDirection = FlowDirection.TopDown;
            mainContainer.WrapContents = false;
            mainContainer.Padding = new Padding(0, 0, 0, 50);
            this.Controls.Add(mainContainer);

            // 2. Header và Nút Quay lại
            Panel pnlHeader = new Panel();
            pnlHeader.Size = new Size(MainForm.Width, 60);
            pnlHeader.Margin = new Padding(0, 0, 0, 10);

            RoundedButton btnBack = new RoundedButton();
            btnBack.Text = "⬅";
            btnBack.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            //btnBack.ForeColor = Color.FromArgb(253, 41, 123);
            //btnBack.BackColor = Color.White;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Location = new Point(0, -40);
            btnBack.Size = new Size(120, 100);
            btnBack.Click += (s, e) =>
            {
                if (_thongBaoScreen != null)
                {
                    // Quay lại danh sách thông báo
                    MainForm.LoadContent(_thongBaoScreen);
                }
                else if (_previousScreen != null)
                {
                    // Quay lại màn hình Ghép đôi
                    MainForm.LoadContent(_previousScreen);
                }
                else if (nt != null)
                {
                    // Quay lại màn hình Nhắn tin
                    MainForm.LoadContent(nt);
                }
                else
                {
                    // Nếu không xác định được, quay về màn hình Ghép đôi mặc định
                    // Truyền Session.LocalId hoặc biến tương ứng của bạn vào đây
                    MainForm.LoadContent(new GhepDoi(MainForm));
                }

            };

            pnlHeader.Controls.Add(btnBack);
            mainContainer.Controls.Add(pnlHeader);

            // 3. Các phần nội dung
            AddProfileHeader();
            AddBasicInfoSection();

            AddSectionTitle("Giới thiệu bản thân");
            Label lblBio = new Label();
            lblBio.Text = string.IsNullOrEmpty(user.gthieu) ? "Người dùng chưa viết giới thiệu." : user.gthieu;
            lblBio.Font = new Font("Segoe UI", 11);
            lblBio.ForeColor = Color.DimGray;
            lblBio.AutoSize = true;
            lblBio.MaximumSize = new Size(MainForm.panelContent.Width - 60, 0);
            lblBio.Margin = new Padding(30, 5, 30, 20);
            mainContainer.Controls.Add(lblBio);

            AddSectionTitle("Sở thích & Thói quen");
            AddHobbiesSection();

            AddSectionTitle("Thư viện ảnh");
            AddPhotoGallery();
        }

        // --- HÀM TẢI ẢNH ---
        private async void LoadImageToPictureBox(PictureBox pb, string source)
        {
            try
            {
                if (string.IsNullOrEmpty(source)) return;

                if (source.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var data = await client.GetByteArrayAsync(source);
                        using (var ms = new MemoryStream(data)) pb.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    byte[] imageBytes = Convert.FromBase64String(source);
                    using (var ms = new MemoryStream(imageBytes)) pb.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                pb.BackColor = Color.FromArgb(30, 30, 30);
            }
        }

        // ================================================================
        // [MỚI] LOGIC HIỂN THỊ ẢNH FULL TRONG FORM MAIN (KHÔNG FULL SCREEN)
        // ================================================================
        private void ShowFullScreenImage(Image img)
        {
            if (img == null) return;

            // 1. Tạo một Panel phủ kín MainForm
            Panel overlayPanel = new Panel();
            overlayPanel.Dock = DockStyle.Fill; // Lấp đầy form cha
            overlayPanel.BackColor = Color.Black; 
            overlayPanel.Name = "ImageOverlay"; // Đặt tên để dễ tìm/xóa

            // 2. PictureBox hiển thị ảnh
            PictureBox pbFull = new PictureBox();
            pbFull.Dock = DockStyle.Fill;
            pbFull.Image = (Image)img.Clone();
            pbFull.SizeMode = PictureBoxSizeMode.Zoom; 
            pbFull.BackColor = Color.Black;
            overlayPanel.Controls.Add(pbFull);

            // 3. Nút đóng (X)
            Label lblClose = new Label();
            lblClose.Text = "✖";
            lblClose.ForeColor = Color.White;
            lblClose.Font = new Font("Arial", 18, FontStyle.Bold);
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.BackColor = Color.Transparent;
            // Đặt nút đóng ở góc phải trên cùng của Panel
            lblClose.Location = new Point(MainForm.Width - 60, 20);
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Sự kiện đóng Overlay
            EventHandler closeAction = (s, e) =>
            {
                MainForm.Controls.Remove(overlayPanel); // Gỡ khỏi MainForm
                overlayPanel.Dispose(); // Giải phóng bộ nhớ
            };

            lblClose.Click += closeAction;
            pbFull.Click += closeAction; 

            overlayPanel.Controls.Add(lblClose);
            lblClose.BringToFront();

            // 4. Thêm Panel vào MainForm và đưa lên trên cùng
            MainForm.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
        }

        private void AddProfileHeader()
        {
            FlowLayoutPanel pnlProfile = new FlowLayoutPanel();
            pnlProfile.FlowDirection = FlowDirection.TopDown;
            pnlProfile.AutoSize = true;
            pnlProfile.Width = MainForm.panelContent.Width - 40;
            pnlProfile.Margin = new Padding(20, 0, 20, 20);
            pnlProfile.WrapContents = false;

            // Avatar to
            PictureBox pbAvatar = new PictureBox();
            pbAvatar.Size = new Size(350, 350);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbAvatar.Margin = new Padding((pnlProfile.Width - 350) / 2, 0, 0, 10);
            pbAvatar.Cursor = Cursors.Hand;

            // Gán sự kiện click
            pbAvatar.Click += (s, e) => ShowFullScreenImage(pbAvatar.Image);

            if (!string.IsNullOrEmpty(user.AvatarUrl))
                LoadImageToPictureBox(pbAvatar, user.AvatarUrl);
            else
                pbAvatar.BackColor = Color.LightGray;

            pnlProfile.Controls.Add(pbAvatar);

            Label lblName = new Label();
            lblName.Text = $"{user.ten}, {user.tuoi}";
            lblName.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblName.AutoSize = true;
            lblName.ForeColor = Color.Black;
            lblName.Margin = new Padding((pnlProfile.Width - lblName.PreferredWidth) / 2, 0, 0, 0);
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
            p.Size = new Size(210, 70);
            p.Margin = new Padding(10);
            p.BackColor = Color.FromArgb(248, 249, 250);

            p.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    Rectangle r = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                    e.Graphics.DrawRectangle(pen, r);
                }
            };

            Label lblIcon = new Label { Text = icon, Font = new Font("Segoe UI Emoji", 20), Location = new Point(10, 15), AutoSize = true, BackColor = Color.Transparent };
            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(75, 12), AutoSize = true, BackColor = Color.Transparent };
            Label lblValue = new Label
            {
                Text = string.IsNullOrEmpty(value) ? "---" : value,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(75, 35),
                AutoSize = true,
                MaximumSize = new Size(130, 0),
                BackColor = Color.Transparent
            };

            p.Controls.Add(lblIcon);
            p.Controls.Add(lblTitle);
            p.Controls.Add(lblValue);
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

                lblTag.Paint += (s, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, lblTag.ClientRectangle, Color.FromArgb(253, 41, 123), ButtonBorderStyle.Solid);
                };

                pnlTags.Controls.Add(lblTag);
            }
            mainContainer.Controls.Add(pnlTags);
        }

        private void AddPhotoGallery()
        {
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

            foreach (string imgSource in user.photos)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(150, 200);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Margin = new Padding(5);
                pb.BackColor = Color.Black;
                pb.Cursor = Cursors.Hand;

                pb.Click += (s, e) => ShowFullScreenImage(pb.Image);

                LoadImageToPictureBox(pb, imgSource);
                pnlGallery.Controls.Add(pb);
            }
            mainContainer.Controls.Add(pnlGallery);
        }

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

        private void ChiTietUser_Load(object sender, EventArgs e)
        {

        }
    }
}