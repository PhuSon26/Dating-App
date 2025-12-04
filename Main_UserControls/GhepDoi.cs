using LOGIN;
using LOGIN.Main_UserControls.GhepDoi_UserControls;
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
using static System.Net.WebRequestMethods;

namespace Main_Interface.User_Controls
{
    public partial class GhepDoi : UserControl
    {
        private List<System.Drawing.Image> images = new List<System.Drawing.Image>();
        private Main MainForm;
        private LocUser loc;
        private MatchFilterAPI filterAPI;
        private List<USER> filteredUsers = new List<USER>();
        private int current_index = 0;
        private FirebaseAuthHelper auth;
        public GhepDoi()
        {
            InitializeComponent();
            this.Load += GhepDoi_Load;
        }
        public GhepDoi(Main m)
        {
            InitializeComponent();
            this.Load += GhepDoi_Load;
            MainForm = m;
            this.auth = m.auth;
            loc = new LocUser(MainForm);
            //filterAPI = new MatchFilterAPI("login - bb104");
        }

        private void ShowUser(USER u)
        {
            flpanel_pictures.Controls.Clear();

            tb_name.Text = u.ten;
            tb_tuoi.Text = u.tuoi.ToString();
            tb_snhat.Text = u.snhat;
            tb_hocvan.Text = u.hocvan;
            tb_nghe.Text = u.nghenghiep;
            tb_chieucao.Text = u.chieucao.ToString();
            tb_thoiquen.Text = u.thoiquen;
            tb_vitri.Text = u.vitri;
            tb_gioithieu.Text = u.gthieu;

            // Avatar
            if (!string.IsNullOrEmpty(u.AvatarUrl))
            {
                try
                {
                    avatar.Image = auth.Base64ToImage(u.AvatarUrl);
                    avatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }
            }

            // Many photos
            flpanel_pictures.Controls.Clear();

            if (u.photos != null)
            {
                foreach (var b64 in u.photos)
                {
                    try
                    {
                        PictureBox pb = new PictureBox();
                        pb.Image = auth.Base64ToImage(b64);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Size = new Size(flpanel_pictures.Width - 20, 180);
                        pb.Margin = new Padding(5);
                        flpanel_pictures.Controls.Add(pb);
                    }
                    catch { }
                }
            }

        }
        private async Task LoadFilteredUsers(FilterModel filter)
        {
            filteredUsers = await filterAPI.FilterUsers(filter);

            current_index = 0;

            if (filteredUsers.Count > 0)
                ShowUser(filteredUsers[0]);
            else
                MessageBox.Show("Không tìm thấy người phù hợp!");
        }

        private void GhepDoi_Load(object sender, EventArgs e)
        {
            /*
            // Thư mục chứa ảnh demo
            string folder = @"C:\Users\leson\OneDrive\Documents\uit\html lab3"; // đổi theo nơi bạn lưu ảnh
            if (!System.IO.Directory.Exists(folder))
            {
                MessageBox.Show("Tạo thư mục DemoImages và bỏ vài tấm ảnh vào nhé!");
                return;
            }

            string[] files = System.IO.Directory.GetFiles(folder, "*.png"); // hoặc *.jpg
            foreach (var file in files)
            {
                // Chỉ định rõ System.Drawing.Image
                System.Drawing.Image img = System.Drawing.Image.FromFile(file);
                images.Add(img);

                PictureBox pb = new PictureBox();
                pb.Image = img;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Size = new Size(300, 300);
                pb.Margin = new Padding(10);
                flpanel_pictures.Controls.Add(pb);
            }
            */
        }
        public void LoadUserControl(UserControl uc)
        {
            MainForm.panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            MainForm.panelContent.Controls.Add(uc);
        }
        public void LoadFilteredUsers(List<USER> users)
        {
            flpanel_pictures.Controls.Clear();

            foreach (var u in users)
            {
                PictureBox pb = new PictureBox()
                {
                    Width = 250,
                    Height = 250,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Margin = new Padding(10)
                };

                // Load avatar
                if (!string.IsNullOrEmpty(u.AvatarUrl))
                {
                    var req = System.Net.WebRequest.Create(u.AvatarUrl);
                    using (var res = req.GetResponse())
                    using (var stream = res.GetResponseStream())
                    {
                        pb.Image = Image.FromStream(stream);
                    }
                }

                pb.Click += (s, e) =>
                {
                    tb_name.Text = u.ten;
                    tb_tuoi.Text = u.tuoi.ToString();
                    tb_hocvan.Text = u.hocvan;
                    tb_nghe.Text = u.nghenghiep;
                    tb_chieucao.Text = u.chieucao.ToString();
                    tb_vitri.Text = u.vitri;
                };

                flpanel_pictures.Controls.Add(pb);
            }
        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            LoadUserControl(loc);
        }

        private void GhepDoi_Load_1(object sender, EventArgs e)
        {

        }

        private void nextUser()
        {
            if (filteredUsers.Count == 0) return;
            current_index++;
            if (current_index >= filteredUsers.Count) current_index = 0;
            ShowUser(filteredUsers[current_index]);
        }
        private void btn_kothich_Click(object sender, EventArgs e)
        {
            nextUser();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            nextUser();
        }
    }
}