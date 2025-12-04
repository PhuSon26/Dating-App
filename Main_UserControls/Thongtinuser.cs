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
        public Image selectedAvatar;
        public List<Image> selectedPhotos = new List<Image>();
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
                return;
            }

            // =============================
            // LƯU THÔNG TIN USER
            // =============================
            u.ten = lb_tennguoidung.Text;
            u.gioitinh = cb_gioitinh.Text;
            u.snhat = dtp_sinhnhat.Value.ToString("yyyy-MM-dd");
            u.vitri = tb_diachi.Text;
            u.thoiquen = tb_sothich.Text;
            u.nghenghiep = tb_congviec.Text;
            u.hocvan = tb_hocvan.Text;
            u.chieucao = float.Parse(num_chieucao.Text);
            u.gthieu = tb_gioithieu.Text;

            // =============================
            // LƯU AVATAR
            // =============================
            if (selectedAvatar != null)
            {
                try
                {
                    u.AvatarUrl = auth.ImageToBase64(selectedAvatar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi upload avatar: " + ex.Message);
                }
            }

            // =============================
            // LƯU NHIỀU ẢNH
            // =============================
            if (selectedPhotos.Count > 0)
            {
                if (u.photos == null) u.photos = new List<string>();

                foreach (var img in selectedPhotos)
                    u.photos.Add(auth.ImageToBase64(img));
            }

            // =============================
            // CẬP NHẬT FIREBASE
            // =============================
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

            // RESET UI
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
                    selectedAvatar = Image.FromFile(ofd.FileName);
                    ptb_avt.Image = selectedAvatar;
                    ptb_avt.SizeMode = PictureBoxSizeMode.Zoom;
                    ptb_avt.Margin = new Padding(5);
                    ptb_avt.BorderStyle = BorderStyle.FixedSingle;
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
                    foreach (string file in ofd.FileNames)
                    {
                        Image img = Image.FromFile(file);
                        selectedPhotos.Add(img);
                        PictureBox pic = new PictureBox();
                        pic.Image = Image.FromFile(ofd.FileName);
                        pic.SizeMode = PictureBoxSizeMode.Zoom;
                        pic.Width = 350;
                        pic.Height = 200;
                        pic.Margin = new Padding(5);
                        pic.BorderStyle = BorderStyle.FixedSingle;
                        pic.Cursor = Cursors.Hand;

                        // Nếu muốn click vào ảnh để phóng to hoặc xóa
                        pic.Click += (s, ev) =>
                        {
                            if (MessageBox.Show("Xóa ảnh này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                flp.Controls.Remove(pic);
                                pic.Dispose();
                            }
                        };

                        flp.Controls.Add(pic);
                    }
                }
            }
        }
    }
}
