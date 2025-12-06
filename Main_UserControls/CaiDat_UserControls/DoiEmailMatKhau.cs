using LOGIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Main_Interface.User_Controls.CaiDat_UserControls
{
    public partial class DoiEmailMatKhau : UserControl
    {
        private Main MainForm;
        private FirebaseAuthHelper auth;
        public DoiEmailMatKhau()
        {
            InitializeComponent();
        }
        public DoiEmailMatKhau(Main m)
        {
            InitializeComponent();
            MainForm = m;
            auth = m.auth;
        }
        private void DoiEmailMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.LoadContent(new CaiDat(MainForm));
        }

        // Trong Main_Interface.User_Controls.CaiDat_UserControls.DoiEmailMatKhau

        private async void btn_xacnhan_Click(object sender, EventArgs e)
        {
            string matkhauMoi = tb_mk.Text.Trim();
            string nhapLai = tb_remk.Text.Trim();

            if (string.IsNullOrEmpty(matkhauMoi) || string.IsNullOrEmpty(nhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu mới!");
                return;
            }

            if (matkhauMoi != nhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            try
            {
                var signInResult = await auth.SignIn(auth.email, auth.password);
                var jsonSignIn = System.Text.Json.JsonDocument.Parse(signInResult);
                string currentIdToken = jsonSignIn.RootElement.GetProperty("idToken").GetString();

                string updateResult = await auth.UpdatePasswordInApp(currentIdToken, matkhauMoi);

                var jsonUpdate = System.Text.Json.JsonDocument.Parse(updateResult);
                string newIdToken = jsonUpdate.RootElement.GetProperty("idToken").GetString();
                string newRefreshToken = jsonUpdate.RootElement.GetProperty("refreshToken").GetString();
                Session.IdToken = newIdToken;
                auth.password = matkhauMoi;

                MessageBox.Show("Cập nhật mật khẩu thành công!");

                tb_mk.Text = "";
                tb_remk.Text = "";
                tb_mkHientai.Text = "";
                tb_mk.Enabled = false;
                tb_remk.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật mật khẩu: " + ex.Message);
            }
        }
        private void btn_xacthuc_Click(object sender, EventArgs e)
        {
            string mk_hientai = tb_mkHientai.Text.Trim();
            if (mk_hientai == auth.password)
            {
                MessageBox.Show("Xác thực thành công, nhập mật khẩu cần đổi");
                tb_mk.Enabled = true;
                tb_remk.Enabled = true;
            }
            else
            {
                MessageBox.Show("Sai mật khẩu!");
            }
        }
    }
}