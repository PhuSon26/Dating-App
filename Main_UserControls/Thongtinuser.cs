using LOGIN;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Dating_app_nhom3
{
    public partial class Thongtinuser : UserControl
    {
        public USER u;
        public FirebaseAuthHelper auth;
        private ImageList imgList;

        public Thongtinuser(FirebaseAuthHelper auth, USER u)
        {
            InitializeComponent();
            this.u = u;
            this.auth = auth;
            imgList = new ImageList();
            cb_chinhsua.MouseEnter += (s, e) => cb_chinhsua.BackColor = Color.FromArgb(255, 210, 220);
            cb_chinhsua.MouseLeave += (s, e) => cb_chinhsua.BackColor = Color.FromArgb(255, 190, 200);
        }

        private async void cb_chinhsua_Click(object sender, EventArgs e)
        {
            if (cb_chinhsua.Text.Contains("Chỉnh sửa"))
            {
                cb_chinhsua.Text = "✅ Xác nhận";
                btn_avatar.Enabled = true;
                btn_themAnh.Enabled = true;
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
                    ten = lb_tennguoidung.Text,
                    gioitinh = cb_gioitinh.Text,
                    snhat = dtp_sinhnhat.Value.ToString("yyyy-MM-dd"),
                    vitri = tb_diachi.Text,
                    thoiquen = tb_sothich.Text,
                    nghenghiep = tb_congviec.Text,
                    hocvan = tb_hocvan.Text,
                    chieucao = float.Parse(num_chieucao.Text),
                    gthieu = tb_gioithieu.Text,
                };

                try
                {
                    var docRef = auth.db.Collection("Users").Document(Session.LocalId);
                    await docRef.SetAsync(updatedUser);
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
                catch { }

                cb_chinhsua.Text = "✏️ Chỉnh sửa hồ sơ";
                btn_avatar.Enabled = false;
                btn_themAnh.Enabled = false;
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

        public async void setUserInfo(USER u)
        {
            if (u == null) return;

            lb_tennguoidung.Text = u.ten;
            cb_gioitinh.Text = u.gioitinh;

            if (!string.IsNullOrEmpty(u.snhat) && DateTime.TryParse(u.snhat, out DateTime ngay))
                dtp_sinhnhat.Value = ngay;
            else
                dtp_sinhnhat.Value = DateTime.Today;

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
                catch
                {
                    MessageBox.Show("Không tải được ảnh đại diện!");
                }
            }
        }
        /*
        private async void btn_avatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif; *.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    ptb_avt.Image = Image.FromFile(filePath);
                    ptb_avt.SizeMode = PictureBoxSizeMode.Zoom;

                    try
                    {
                        string url = await auth.UploadAvatarAsync(filePath, Session.LocalId);
                        u.AvatarUrl = url;
                        await auth.CreateOrUpdateUserInfoAsync(u);

                        MessageBox.Show("Cập nhật avatar thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi upload avatar: " + ex.Message);
                    }
                }
            }
        }

        private async void btn_themAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif; *.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<string> selectedFiles = ofd.FileNames.ToList();

                    try
                    {
                        List<string> urls = await auth.UploadPhotosAsync(selectedFiles, Session.LocalId);

                        if (u.photos == null) u.photos = new List<string>();
                        u.photos.AddRange(urls);
                        await auth.CreateOrUpdateUserInfoAsync(u);

                        // Hiển thị trong FlowLayoutPanel
                        foreach (string file in selectedFiles)
                        {
                            PictureBox pb = new PictureBox();
                            pb.Image = Image.FromFile(file);
                            pb.SizeMode = PictureBoxSizeMode.Zoom;
                            pb.Size = new Size(flp.Width - 20, 180);
                            pb.Margin = new Padding(5);
                            flp.Controls.Add(pb);
                        }

                        MessageBox.Show("Upload ảnh thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi upload ảnh: " + ex.Message);
                    }
                }
            }
        }
        */
    }
}
