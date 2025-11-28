using LOGIN;
using System.Windows.Forms;

namespace Dating_app_nhom3
{
    public partial class Thongtinuser : UserControl
    {
        public USER u;
        public FirebaseAuthHelper auth;
        public Thongtinuser(FirebaseAuthHelper auth, USER u)
        {
            InitializeComponent();
            this.u = u;
            this.auth = auth;
            cb_chinhsua.MouseEnter += (s, e) => cb_chinhsua.BackColor = Color.FromArgb(255, 210, 220);
            cb_chinhsua.MouseLeave += (s, e) => cb_chinhsua.BackColor = Color.FromArgb(255, 190, 200);
        }
        private async void cb_chinhsua_Click(object sender, EventArgs e)
        {
            if (cb_chinhsua.Text.Contains("Chỉnh sửa"))
            {
                cb_chinhsua.Text = "✅ Xác nhận";
                tb_tennguoidung.Enabled = true;
                cb_gioitinh.Enabled = true;
                dtp_sinhnhat.Enabled = true;
                tb_diachi.Enabled = true;
                tb_sothich.Enabled = true;
                tb_congviec.Enabled = true;
                tb_hocvan.Enabled = true;
                num_chieucao.Enabled = true;
                tb_gioithieu.Enabled = true;
            }
            else
            {
                var updatedUser = new USER
                {
                    ten = tb_tennguoidung.Text,
                    gioitinh = cb_gioitinh.Text,
                    snhat = dtp_sinhnhat.Value.ToString("yyyy-MM-dd"),
                    vitri = tb_diachi.Text,
                    thoiquen = tb_sothich.Text,
                    nghenghiep = tb_congviec.Text,
                    hocvan = tb_hocvan.Text,
                    chieucao = float.Parse(num_chieucao.Text),
                    gthieu = tb_gioithieu.Text
                };
                try
                {
                    //await auth.saveUserInfo(updatedUser.Id, updatedUser);
                    var docRef = auth.db.Collection("Users").Document(Session.LocalId);
                    await docRef.SetAsync(updatedUser);
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
                catch { }
                cb_chinhsua.Text = "✏️ Chỉnh sửa hồ sơ";
                tb_tennguoidung.Enabled = false;
                cb_gioitinh.Enabled = false;
                dtp_sinhnhat.Enabled = false;
                tb_diachi.Enabled = false;
                tb_sothich.Enabled = false;
                tb_congviec.Enabled = false;
                tb_hocvan.Enabled = false;
                num_chieucao.Enabled = false;
                tb_gioithieu.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ptb_avt_Click(object sender, EventArgs e)
        {

        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {

        }

        public async void setUserInfo(LOGIN.USER u)
        {
            if (u == null) return;
            tb_tennguoidung.Text = u.ten;
            cb_gioitinh.Text = u.gioitinh;
            dtp_sinhnhat.Text = u.snhat;
            tb_congviec.Text = u.nghenghiep;
            tb_diachi.Text = u.vitri;
            tb_hocvan.Text = u.hocvan;
            tb_sothich.Text = u.thoiquen;
            num_chieucao.Text = u.chieucao.ToString();
            tb_gioithieu.Text = u.gthieu;
            if (!string.IsNullOrEmpty(u.AvatarUrl))
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var bytes = await client.GetByteArrayAsync(u.AvatarUrl);
                        using (var ms = new MemoryStream(bytes))
                        {
                            ptb_avt.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch { MessageBox.Show("Không tải được ảnh đại diện!"); }
            }
        }

        private void giaodiennguoidung_Load(object sender, EventArgs e)
        {

        }

        private void Thongtinuser_Load(object sender, EventArgs e)
        {

        }

        private void cb_chinhsua_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label_congviec_Click(object sender, EventArgs e)
        {

        }
    }
}
