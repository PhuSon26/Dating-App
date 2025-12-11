using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LOGIN.Models; // Đảm bảo import Models của bạn

namespace LOGIN
{
    public  partial class IncomingCallForm : Form
    {
        private PictureBox picAvatar;
        private Label lblName;
        private Label lblStatus;
        private Button btnAccept;
        private Button btnReject;
        private System.Windows.Forms.Timer animTimer;
        private int targetY;

        public IncomingCallForm(string callerName, Image callerAvatar = null)
        {
            // 1. Cấu hình Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(350, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 30, 48); // Màu nền tối sang trọng
            this.DoubleBuffered = true;

            // Bo tròn góc Form
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // 2. Avatar (Hình tròn)
            picAvatar = new PictureBox();
            picAvatar.Size = new Size(120, 120);
            picAvatar.Location = new Point((this.Width - 120) / 2, 50);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            // Nếu có ảnh thì dùng, không thì dùng ảnh mặc định trong Resources
            if (callerAvatar != null)
                picAvatar.Image = callerAvatar;
            else
                picAvatar.BackColor = Color.Gray; // Hoặc load ảnh default từ Resource

            // Làm tròn avatar
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(gp);

            // 3. Tên người gọi
            lblName = new Label();
            lblName.Text = callerName;
            lblName.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.AutoSize = false;
            lblName.Size = new Size(this.Width, 40);
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblName.Location = new Point(0, 190);

            // 4. Trạng thái
            lblStatus = new Label();
            lblStatus.Text = "Đang gọi video cho bạn...";
            lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblStatus.ForeColor = Color.Silver;
            lblStatus.AutoSize = false;
            lblStatus.Size = new Size(this.Width, 30);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Location = new Point(0, 230);

            // 5. Nút Từ chối (Đỏ)
            btnReject = CreateCircleButton("✖", Color.FromArgb(255, 69, 58), 60);
            btnReject.Location = new Point(50, 320);
            btnReject.Click += (s, e) => {
                this.DialogResult = DialogResult.No;
                this.Close();
            };

            // 6. Nút Nghe máy (Xanh)
            btnAccept = CreateCircleButton("📞", Color.FromArgb(48, 209, 88), 60);
            btnAccept.Location = new Point(240, 320);
            btnAccept.Click += (s, e) => {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            };

            // Add controls
            this.Controls.Add(picAvatar);
            this.Controls.Add(lblName);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnReject);
            this.Controls.Add(btnAccept);

            // Hiệu ứng đổ bóng/Gradient nền (Optional)
            this.Paint += IncomingCallForm_Paint;
        }

        // Tạo nút tròn đẹp
        private Button CreateCircleButton(string text, Color color, int size)
        {
            Button btn = new Button();
            btn.Size = new Size(size, size);
            btn.Text = text;
            btn.Font = new Font("Segoe UI Emoji", 20);
            btn.ForeColor = Color.White;
            btn.BackColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, size, size);
            btn.Region = new Region(p);

            return btn;
        }

        private void IncomingCallForm_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ viền gradient cho đẹp
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(20, 30, 48), Color.FromArgb(36, 59, 85), 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        // Import DLL để bo tròn Form
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}