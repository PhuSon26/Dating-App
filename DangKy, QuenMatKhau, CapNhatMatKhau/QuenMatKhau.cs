using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class FormQuenMatKhau : Form
    {
        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            // Căn giữa lại pnlCard khi form resize (dù FixedSingle vẫn an toàn)
            foreach (Control c in Controls)
            {
                if (c is Panel bg)
                {
                    bg.Resize += (_, __) => CenterCard(bg);
                    bg.Paint += BgPanel_Paint;
                    bg.ControlAdded += (_, __) => bg.Invalidate();
                    CenterCard(bg);
                }
            }

            // Bo góc card + vẽ border
            ApplyRoundedWithBorder(pnlCard, 18, Color.FromArgb(230, 230, 240));

            // Left gradient + tips
            pnlLeft.Paint += PnlLeft_Paint;
            pnlTips.Paint += PnlTips_Paint;

            // Viền mỏng cho ô nhập (để giống UI bạn thích)
            pnlEmailBox.Paint += (_, pe) => DrawSoftBorder(pe.Graphics, pnlEmailBox.ClientRectangle, 14, Color.FromArgb(210, 195, 255));
            pnlCodeBox.Paint += (_, pe) => DrawSoftBorder(pe.Graphics, pnlCodeBox.ClientRectangle, 14, Color.FromArgb(210, 195, 255));
        }

        private void CenterCard(Panel bg)
        {
            if (pnlCard == null) return;
            int x = (bg.ClientSize.Width - pnlCard.Width) / 2;
            int y = (bg.ClientSize.Height - pnlCard.Height) / 2;
            pnlCard.Location = new Point(Math.Max(0, x), Math.Max(0, y));
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // nền nhẹ
            using (var b = new SolidBrush(Color.FromArgb(245, 242, 255)))
                g.FillRectangle(b, ((Control)sender).ClientRectangle);

            // các “bóng tròn” trang trí
            DrawCircle(g, new Rectangle(-60, 110, 240, 240), Color.FromArgb(70, 160, 120, 255));
            DrawCircle(g, new Rectangle(500, 40, 170, 170), Color.FromArgb(60, 170, 160, 255));
            DrawCircle(g, new Rectangle(420, 260, 220, 220), Color.FromArgb(55, 255, 140, 190));
        }

        private void DrawCircle(Graphics g, Rectangle rect, Color color)
        {
            using var br = new SolidBrush(color);
            g.FillEllipse(br, rect);
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var r = ((Control)sender).ClientRectangle;
            using var br = new LinearGradientBrush(
                r,
                Color.FromArgb(140, 90, 255),
                Color.FromArgb(255, 90, 180),
                LinearGradientMode.Vertical);

            g.FillRectangle(br, r);
        }

        private void PnlTips_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawSoftBorder(g, pnlTips.ClientRectangle, 14, Color.FromArgb(120, 255, 255, 255));
        }

        private void ApplyRoundedWithBorder(Control c, int radius, Color borderColor)
        {
            c.Paint += (_, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, c.Width - 1, c.Height - 1);
                using var path = RoundedRect(rect, radius);
                c.Region = new Region(path);

                using var pen = new Pen(borderColor, 1f);
                pe.Graphics.DrawPath(pen, path);
            };

            c.Resize += (_, __) => c.Invalidate();
        }

        private void DrawSoftBorder(Graphics g, Rectangle rect, int radius, Color color)
        {
            rect = new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            using var path = RoundedRect(rect, radius);
            using var pen = new Pen(color, 1f);
            g.DrawPath(pen, path);
        }

        private GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
        private FirebaseAuthHelper auth;
        private string currentEmail;

        // Lưu trữ OTP tạm thời (static để dùng chung giữa các form)
        private static Dictionary<string, (string otp, DateTime expiry)> otpStorage = new Dictionary<string, (string, DateTime)>();

        public event Action backClicked;

        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        public FormQuenMatKhau(FirebaseAuthHelper auth)
        {
            this.auth = auth;
            InitializeComponent();
        }

        // ====================
        // NÚT GỬI MÃ OTP
        // ====================
        private async void btn_nhanma_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();

            // Validate email
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: Kiểm tra email có tồn tại trong hệ thống không (Firebase/Database)
            // if (!await CheckEmailExists(email)) { ... }

            // Tạo OTP 6 chữ số
            string otp = GenerateOTP();

            // Lưu OTP (có hiệu lực 5 phút)
            SaveOTPToStorage(email, otp, DateTime.Now.AddMinutes(5));
            currentEmail = email; // Lưu email hiện tại

            // Gửi email
            bool success = await EmailHelper.SendOTPEmail(email, otp);

            if (success)
            {
                MessageBox.Show("Mã OTP đã được gửi đến email của bạn!\n" +
                               "Vui lòng kiểm tra và nhập mã vào ô bên dưới.",
                               "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Enable textbox nhập OTP
                tb_maxacnhan.Enabled = true;
                btn_xacnhan.Enabled = true;
            }
        }

        // ====================
        // NÚT XÁC NHẬN OTP
        // ====================
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            string otpNhap = tb_maxacnhan.Text.Trim();

            // Kiểm tra đã gửi OTP chưa
            if (string.IsNullOrEmpty(currentEmail))
            {
                MessageBox.Show("Vui lòng nhấn 'Nhận Mã' trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đã nhập OTP chưa
            if (string.IsNullOrWhiteSpace(otpNhap))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác thực OTP
            if (VerifyOTP(currentEmail, otpNhap))
            {
                MessageBox.Show("Xác thực thành công!\nBạn có thể đặt mật khẩu mới.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển sang form đổi mật khẩu
                var formDoiMatKhau = new CapNhatMatKhau(auth, currentEmail);
                formDoiMatKhau.ShowDialog();

                // Reset form
                ResetForm();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng hoặc đã hết hạn!\nVui lòng thử lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================
        // HÀM TẠO OTP 6 CHỮ SỐ
        // ====================
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // ====================
        // LƯU OTP VÀO BỘ NHỚ TẠM
        // ====================
        private void SaveOTPToStorage(string email, string otp, DateTime expiryTime)
        {
            // Xóa OTP cũ nếu có
            if (otpStorage.ContainsKey(email))
            {
                otpStorage.Remove(email);
            }

            // Lưu OTP mới
            otpStorage[email] = (otp, expiryTime);
        }

        // ====================
        // XÁC THỰC OTP
        // ====================
        public static bool VerifyOTP(string email, string otp)
        {
            // Kiểm tra email có tồn tại trong storage không
            if (!otpStorage.ContainsKey(email))
            {
                return false;
            }

            var (storedOtp, expiry) = otpStorage[email];

            // Kiểm tra OTP đã hết hạn chưa
            if (DateTime.Now > expiry)
            {
                otpStorage.Remove(email); // Xóa OTP hết hạn
                return false;
            }

            // Kiểm tra OTP có đúng không
            if (storedOtp == otp)
            {
                otpStorage.Remove(email); // Xóa OTP sau khi xác thực thành công
                return true;
            }

            return false;
        }

        // ====================
        // VALIDATE EMAIL
        // ====================
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // ====================
        // RESET FORM
        // ====================
        private void ResetForm()
        {
            tb_email.Clear();
            tb_maxacnhan.Clear();
            tb_maxacnhan.Enabled = false;
            btn_xacnhan.Enabled = false;
            currentEmail = null;
        }

        // ====================
        // NÚT QUAY LẠI
        // ====================
        private void ll_back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            backClicked?.Invoke();
        }

        
    }
}