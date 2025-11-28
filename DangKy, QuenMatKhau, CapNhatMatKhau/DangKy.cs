using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LOGIN
{
    public partial class FormDangKy : Form
    {
        private FirebaseAuthHelper auth;
        public event Action backClicked;
        public FormDangKy()
        {
            InitializeComponent();
        }

        public FormDangKy(FirebaseAuthHelper auth)
        {
            this.auth = auth;
            InitializeComponent();
        }
        private void dangky_Load(object sender, EventArgs e)
        {

        }

        private async void btn_dangky_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string password = tb_password.Text.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu");
                return;
            }
            if (string.IsNullOrEmpty(tb_rePassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận");
                return;
            }
            if (tb_rePassword.Text != password)
            {
                MessageBox.Show("Mật khẩu xác nhận chưa hợp lệ");
                return;
            }
            try
            {
                string result = await auth.SignUp(email, password);
                var json = JsonDocument.Parse(result);
                Session.IdToken = json.RootElement.GetProperty("idToken").GetString();
                Session.LocalId = json.RootElement.GetProperty("localId").GetString();

                MessageBox.Show("Đăng ký thành công");
                this.Close();
                var fThongTin = new CungCapThongTin(Session.LocalId, email, auth);
                fThongTin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thất bại", ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ll_back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            backClicked?.Invoke();
        }
    }
}
