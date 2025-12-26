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
        private Label lblParent;
        public PictureBox pbSpinner;

        // Constructor cho Form
        public LoadingSpinner(Form parent)
        {
            parentForm = parent;
            InitializeSpinner();
            parentForm.Resize += (s, e) => CenterSpinner();
        }

        // Constructor cho UserControl
        public LoadingSpinner(UserControl parent)
        {
            uc = parent;
            InitializeSpinner();
            uc.Resize += (s, e) => CenterSpinner();
        }

        // Constructor cho Label (hiển thị bên cạnh label)
        public LoadingSpinner(Label label)
        {
            lblParent = label;
            InitializeSpinner();
            lblParent.Resize += (s, e) => PositionNextToLabel();
        }

        private void InitializeSpinner()
        {
            pbSpinner = new PictureBox();
            pbSpinner.Size = new Size(603, 100); 
            pbSpinner.SizeMode = PictureBoxSizeMode.Zoom;
            pbSpinner.BackColor = Color.Transparent;
            pbSpinner.Visible = false;
            pbSpinner.BackColor = Color.FromArgb(255, 245, 250);

            // Load GIF từ resource
            pbSpinner.Image = LOGIN.Properties.Resource.loading;

            pbSpinner.BringToFront();

            // Thêm vào parent phù hợp
            if (parentForm != null)
                parentForm.Controls.Add(pbSpinner);
            else if (uc != null)
                uc.Controls.Add(pbSpinner);
            else if (lblParent != null && lblParent.Parent != null)
                lblParent.Parent.Controls.Add(pbSpinner);

            // Căn vị trí
            if (lblParent != null) PositionNextToLabel();
            else CenterSpinner();
        }

        // Căn giữa Form/UserControl
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

        // Căn bên phải label, căn giữa theo chiều cao label
        private void PositionNextToLabel()
        {
            if (lblParent != null)
            {
                pbSpinner.Location = new Point(
                    lblParent.Right + 180, 0
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
