using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main_Interface;

namespace LOGIN
{
    public partial class CungCapThongTin : Form
    {
        FirebaseAuthHelper auth;
        public string avatarFilePath;
        public List<string> photoFilePaths = new List<string>();
        public CungCapThongTin()
        {
            InitializeComponent();
        }
        public CungCapThongTin(FirebaseAuthHelper auth)
        {
            InitializeComponent();
            this.auth = auth;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var user = new USER
            {
                ten = txtName.Text,
                gioitinh = cbGender.SelectedItem?.ToString(),
                tuoi = (int)numAge.Value,
                chieucao = (float)numHeight.Value,
                snhat = dateBirthday.Value.ToString("yyyy-MM-dd"),
                hocvan = txtEducation.Text,
                nghenghiep = txtJob.Text,
                thoiquen = txtHobby.Text,
                gthieu = txtIntro.Text,
                vitri = txtAddress.Text,
                isVip = false
            };


            if (!string.IsNullOrEmpty(avatarFilePath))
            {
                user.AvatarUrl = await auth.uploadFile(avatarFilePath, "avatars");
            }
            user.photos = new List<string>();
            foreach (var path in photoFilePaths)
            {
                var url = await auth.uploadFile(path, "photos");
                user.photos.Add(url);
            }
            var docRef = auth.db.Collection("Users").Document(Session.LocalId);
            await docRef.SetAsync(user);

            MessageBox.Show("Lưu thông tin người dùng thành công!");
            this.Hide();
            Main MainForm = new Main();
            MainForm.Show();
        }

        private void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                avatarFilePath = ofd.FileName;
                using (var fs = new FileStream(avatarFilePath, FileMode.Open, FileAccess.Read))
                {
                    Image img = Image.FromStream(fs);
                    picAvatar.Image = (Image)img.Clone();
                }
            }
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                photoFilePaths.AddRange(ofd.FileNames);
                foreach (var path in ofd.FileNames)
                {
                    PictureBox pb = new PictureBox();
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs);
                        pb.Image = (Image)img.Clone();
                    }
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Size = new Size(100, 100);
                    flowImages.Controls.Add(pb);
                }
            }
        }
    }
}
