using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dating_app_nhom3
{
    public partial class FormDanhSachTinNhan : UserControl
    {
        private UserChat_item myControl;
        public FormDanhSachTinNhan()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                UserChat_item control = new UserChat_item();
                control.Location = new Point(10, 10 + i * 110); // x = 10, y cách nhau 110
                control.Size = new Size(300, 100); // kích thước UserControl
                this.Controls.Add(control); // thêm vào Form
            }
        }

        private void picAvatarNguoiDung_Click(object sender, EventArgs e)
        {

        }
    }
}
