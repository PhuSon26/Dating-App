using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LOGIN
{
    public class LoadingSpinner
    {
        private Form parentForm;
        private UserControl uc;
        public PictureBox pbSpinner;

        public LoadingSpinner(Form parent)
        {
            parentForm = parent;
            InitializeSpinner();

            // Khi form resize, cập nhật vị trí spinner
            parentForm.Resize += (s, e) => CenterSpinner();
        }

        public LoadingSpinner(UserControl parent)
        {
            uc = parent;
            InitializeSpinner();

            // Khi UserControl resize, cập nhật vị trí spinner
            uc.Resize += (s, e) => CenterSpinner();
        }

        private void InitializeSpinner()
        {
            pbSpinner = new PictureBox();
            pbSpinner.Size = new Size(300, 300);
            pbSpinner.SizeMode = PictureBoxSizeMode.Zoom;
            pbSpinner.Visible = false;

            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "loading.gif");

            if (File.Exists(defaultPath))
            {
                pbSpinner.Image = Image.FromFile(defaultPath);
            }
            else
            {
                // Nếu không có file gif, tạo ảnh tạm "Loading..." để không lỗi
                Bitmap bmp = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    g.DrawString("Loading...", new Font("Segoe UI", 10, FontStyle.Bold),
                                 Brushes.Gray, new PointF(10, 40));
                }
                pbSpinner.Image = bmp;
            }

            pbSpinner.BringToFront();

            if (parentForm != null)
                parentForm.Controls.Add(pbSpinner);
            else if (uc != null)
                uc.Controls.Add(pbSpinner);

            CenterSpinner();
        }

        private void CenterSpinner()
        {
            if (parentForm != null)
            {
                pbSpinner.Location = new Point(
                    parentForm.ClientSize.Width / 2 - pbSpinner.Width / 2,
                    parentForm.ClientSize.Height / 2 - pbSpinner.Height / 2
                );
            }
            else if (uc != null)
            {
                pbSpinner.Location = new Point(
                    uc.ClientSize.Width / 2 - pbSpinner.Width / 2,
                    uc.ClientSize.Height / 2 - pbSpinner.Height / 2
                );
            }
        }

        // Hiển thị spinner
        public void Show()
        {
            pbSpinner.Visible = true;
            pbSpinner.BringToFront();
            Application.DoEvents();
        }

        // Ẩn spinner
        public void Hide()
        {
            pbSpinner.Visible = false;
            Application.DoEvents();
        }
    }
}
