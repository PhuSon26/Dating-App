using System;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class CapNhatMatKhau : Form
    {
        private FirebaseAuthHelper auth;
        private string email;
        public event Action backClicked;
        public event Action updateSuccessed;
        private Panel parentPanel;
        public CapNhatMatKhau(FirebaseAuthHelper auth, string email, Panel parentPanel)
        {
            this.auth = auth;
            this.email = email;
            this.parentPanel = parentPanel;
            InitializeComponent();

            btn_xacnhan.Click += Btn_xacnhan_Click;
        }

        private async void Btn_xacnhan_Click(object sender, EventArgs e)
        {
            string matkhauMoi = tb_email.Text.Trim();
            string nhapLai = tb_maxacnhan.Text.Trim();

            if (string.IsNullOrEmpty(matkhauMoi) || string.IsNullOrEmpty(nhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!");
                return;
            }

            if (matkhauMoi != nhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            try
            {
                await auth.UpdatePassword(email, matkhauMoi);
                MessageBox.Show("Cập nhật mật khẩu thành công!");

                parentPanel.Controls.Clear();
                var dn = new FormDangNhap(auth);
                dn.TopLevel = false;
                dn.Dock = DockStyle.Fill;
                dn.FormBorderStyle = FormBorderStyle.None;
                parentPanel.Controls.Add(dn);
                this.Close();
                dn.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật mật khẩu: " + ex.Message);
            }
        }
    }
}