using System;
using System.Drawing;
using System.Windows.Forms;
using Firebase.Auth;
using System.Text.Json;


namespace LOGIN
{
    public partial class FormDangNhap : Form
    {
        private FirebaseAuthHelper auth;
        public FormDangNhap(FirebaseAuthHelper auth)
        {
            this.auth = auth;
            InitializeComponent();
        }
        private void ll_quenmatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMatKhau f1 = new FormQuenMatKhau(this.auth);
            f1.ShowDialog();
        }

        private void ll_dangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy dk = new FormDangKy(this.auth);
            dk.ShowDialog();
        }

        private async void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string password = tb_matkhau.Text.Trim();
            try
            {
                string result = await auth.SignIn(email, password);
                var json = JsonDocument.Parse(result);
                Session.IdToken = json.RootElement.GetProperty("idToken").ToString();
                Session.LocalId = json.RootElement.GetProperty("localId").ToString();

                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại", ex.Message);
            }
        }
    }
}
