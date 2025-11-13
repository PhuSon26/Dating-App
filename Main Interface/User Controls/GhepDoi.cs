using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;  // dùng System.Drawing
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class GhepDoi : UserControl
    {
        // Chỉ định rõ System.Drawing.Image
        private List<System.Drawing.Image> images = new List<System.Drawing.Image>();

        public GhepDoi()
        {
            InitializeComponent();
            this.Load += GhepDoi_Load;
        }

        private void GhepDoi_Load(object sender, EventArgs e)
        {
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
                flpanel_pictures.Controls.Add(pb); // flpanel_pictures là FlowLayoutPanel của bạn
            }
        }
    }
}
