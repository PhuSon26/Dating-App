using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            try
            {
                string result = await auth.SignUp(email, password);
                var json = JsonDocument.Parse(result);
                Session.IdToken = json.RootElement.GetProperty("idToken").GetString();
                Session.LocalId = json.RootElement.GetProperty("localId").GetString();

                MessageBox.Show("Đăng ký thành công");
                this.Close();
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
