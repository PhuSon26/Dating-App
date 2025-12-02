using Google.Cloud.Firestore;
using LOGIN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        // ===========================================
        // SET USER INFO
        // ===========================================
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

            // Avatar
            if (!string.IsNullOrEmpty(u.AvatarUrl))
            {
                try
                {
                    ptb_avt.Image = auth.Base64ToImage(u.AvatarUrl);
                    ptb_avt.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    MessageBox.Show("Không tải được ảnh đại diện!");
                }
            }

            // Many photos
            flp.Controls.Clear();

            if (u.photos != null)
            {
                foreach (var b64 in u.photos)
                {
                    try
                    {
                        PictureBox pb = new PictureBox();
                        pb.Image = auth.Base64ToImage(b64);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Size = new Size(flp.Width - 20, 180);
                        pb.Margin = new Padding(5);
                        flp.Controls.Add(pb);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        // ===========================================
        // NÚT CHỈNH SỬA
        // ===========================================
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
                // Cập nhật thông tin
                u.ten = lb_tennguoidung.Text;
                u.gioitinh = cb_gioitinh.Text;
                u.snhat = dtp_sinhnhat.Value.ToString("yyyy-MM-dd");
                u.vitri = tb_diachi.Text;
                u.thoiquen = tb_sothich.Text;
                u.nghenghiep = tb_congviec.Text;
                u.hocvan = tb_hocvan.Text;
                u.chieucao = float.Parse(num_chieucao.Text);
                u.gthieu = tb_gioithieu.Text;

                try
                {
                    var docRef = auth.db.Collection("Users").Document(Session.LocalId);
                    await docRef.SetAsync(u, SetOptions.MergeAll);

                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu firestore: " + ex.Message);
                }

                // Đóng chế độ chỉnh sửa
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

        // ===========================================
        // UPLOAD AVATAR
        // ===========================================
        private async void btn_avatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif; *.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(ofd.FileName);

                    ptb_avt.Image = img;
                    ptb_avt.SizeMode = PictureBoxSizeMode.Zoom;

                    try
                    {
                        string base64 = auth.ImageToBase64(img);

                        u.AvatarUrl = base64;

                        var docRef = auth.db.Collection("Users").Document(Session.LocalId);
                        await docRef.SetAsync(new { AvatarUrl = base64 }, SetOptions.MergeAll);

                        MessageBox.Show("Cập nhật avatar thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi upload avatar: " + ex.Message);
                    }
                }
            }
        }

        // ===========================================
        // UPLOAD NHIỀU ẢNH
        // ===========================================
        private async void btn_themAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif; *.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var images = ofd.FileNames.Select(f => Image.FromFile(f)).ToList();

                    if (u.photos == null) u.photos = new List<string>();

                    u.photos.AddRange(images.Select(img => auth.ImageToBase64(img)));

                    try
                    {
                        var docRef = auth.db.Collection("Users").Document(Session.LocalId);
                        await docRef.SetAsync(new { photos = u.photos }, SetOptions.MergeAll);

                        foreach (var img in images)
                        {
                            PictureBox pb = new PictureBox();
                            pb.Image = img;
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
    }
}
