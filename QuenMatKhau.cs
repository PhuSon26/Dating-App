using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class FormQuenMatKhau : Form
    {
        private FirebaseAuthHelper auth;

        public FormQuenMatKhau()
        {
            InitializeComponent();
        }
        public FormQuenMatKhau(FirebaseAuthHelper auth)
        {
            this.auth = auth;
            InitializeComponent();
        }

        private async void btn_xacnhan_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            try
            {
                await auth.SendPasswordReset(email);
                MessageBox.Show("Đã gửi mã xác nhận");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã xác nhận không hợp lệ", ex.Message);
            }
        }
    }
}
