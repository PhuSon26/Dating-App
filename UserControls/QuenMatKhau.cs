using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class FormQuenMatKhau : Form
    {
        private FirebaseAuthHelper auth;
        private string currentEmail;
        private Panel parentPanel;

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
        public FormQuenMatKhau(FirebaseAuthHelper auth, Panel parentPanel)
        {
            this.auth = auth;
            this.parentPanel = parentPanel;
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
                parentPanel.Controls.Clear();
                CapNhatMatKhau cnmk = new CapNhatMatKhau(auth, currentEmail, parentPanel);
                cnmk.TopLevel = false;
                cnmk.Dock = DockStyle.Fill;
                cnmk.FormBorderStyle = FormBorderStyle.None;
                parentPanel.Controls.Add(cnmk);
                cnmk.Show();
                this.Close();
                // Reset form
                // ResetForm();
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

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {
            // Disable nút xác nhận và textbox OTP ban đầu
            tb_maxacnhan.Enabled = false;
            btn_xacnhan.Enabled = false;
        }
    }
}