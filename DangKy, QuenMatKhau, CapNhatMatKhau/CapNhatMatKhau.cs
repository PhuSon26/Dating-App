using System;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class CapNhatMatKhau : Form
    {
        private FirebaseAuthHelper auth;
        private string email;
        private string sentOTP;

        public CapNhatMatKhau(FirebaseAuthHelper auth, string email, string otp)
        {
            this.auth = auth;
            this.email = email;
            this.sentOTP = otp;
            InitializeComponent();
        }

        private async void Btn_xacnhan_Click(object sender, EventArgs e)
        {
            string newPass = tb_email.Text.Trim(); // Ô nhập mk mới
            string confirmPass = tb_maxacnhan.Text.Trim(); // Ô xác nhận

            // 1. Kiểm tra khớp mật khẩu
            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            // 2. Thực hiện cập nhật
            // Vì đã xác nhận OTP thành công ở màn hình trước, tại đây ta ép cập nhật
            bool success = await auth.AdminResetPassword(email, newPass);

            if (success)
            {
                MessageBox.Show("Cập nhật mật khẩu thành công! Hãy đăng nhập lại.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, không tìm thấy tài khoản.");
            }
        }


        private void btn_xacnhan_Click_1(object sender, EventArgs e)
        {

        }
    }
}