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
            panel.Controls.Clear();
            FormQuenMatKhau qmk = new FormQuenMatKhau(this.auth);
            qmk.TopLevel = false;
            qmk.Dock = DockStyle.Fill;
            qmk.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(qmk);
            qmk.Show();

            qmk.backClicked += () =>
            {
                panel.Controls.Clear();
                FormDangNhap dn = new FormDangNhap(this.auth);
                dn.TopLevel = false;
                dn.FormBorderStyle = FormBorderStyle.None;
                dn.Dock = DockStyle.Fill;
                panel.Controls.Add(dn);
                dn.Show();
            };
        }

        private void ll_dangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel.Controls.Clear();
            FormDangKy dk = new FormDangKy(this.auth);
            dk.TopLevel = false;
            dk.Dock = DockStyle.Fill;
            dk.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(dk);
            dk.Show();

            dk.backClicked += () =>
            {
                panel.Controls.Clear();
                FormDangNhap dn = new FormDangNhap(this.auth);
                dn.TopLevel = false;
                dn.FormBorderStyle = FormBorderStyle.None;
                dn.Dock = DockStyle.Fill;
                panel.Controls.Add(dn);
                dn.Show();
            };
        }

        private async void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string password = tb_matkhau.Text.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khảu");
                return;
            }
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

        private void tb_matkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
