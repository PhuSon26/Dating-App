using System;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class FormQuenMatKhau : Form
    {
        private FirebaseAuthHelper auth;
        private string currentEmail;
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
        private async void btn_nhanma_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }

            try
            {
                currentEmail = email;
                string otp = new Random().Next(100000, 999999).ToString();

                TempOTPStore.Add(email, otp);

                await EmailHelper.SendOTPEmail(email, otp);

                MessageBox.Show("Mã xác nhận đã được gửi. Vui lòng kiểm tra email!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi OTP: " + ex.Message);
            }
        }
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            string otpNhap = tb_maxacnhan.Text.Trim();

            if (string.IsNullOrEmpty(currentEmail))
            {
                MessageBox.Show("Bạn cần nhấn 'Nhận Mã Xác Nhận' trước.");
                return;
            }

            if (TempOTPStore.IsValid(currentEmail, otpNhap))
            {
                MessageBox.Show("Xác nhận OTP thành công!");

                var formDoiMatKhau = new CapNhatMatKhau(auth, currentEmail);
                formDoiMatKhau.ShowDialog();

                TempOTPStore.Remove(currentEmail);
                currentEmail = null;
            }
            else
            {
                MessageBox.Show("Mã xác nhận không hợp lệ!");
            }
        }

        private void ll_back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            backClicked?.Invoke();
        }
    }
}
