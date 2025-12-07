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

namespace LOGIN.Main_UserControls.DanhSachNhanTin_UserControls
{
    public partial class HoSoNguoiKhac : Form
    {
        private USER u;
        private FirebaseAuthHelper auth;
        public HoSoNguoiKhac(USER u, FirebaseAuthHelper auth)
        {
            InitializeComponent();
            this.u = u;
            this.auth = auth;
        }
        private void HoSoNguoiKhac_Load(object sender, EventArgs e)
        {
            if (u == null) return;

            lb_tennguoidung.Text = string.IsNullOrEmpty(u.ten) ? "Anonymous" : u.ten;
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

            ptb_avt.Image = auth.Base64ToImage(u.AvatarUrl);
            ptb_avt.SizeMode = PictureBoxSizeMode.Zoom;

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
                    catch { }
                }
            }
        }
    }
}
