using Main_Interface;
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
        private Main MainForm;
        public FormDanhSachTinNhan(Main m)
        {
            InitializeComponent();
            MainForm = m;
            for (int i = 0; i < 10; i++)
            {
                UserChat_item user = new UserChat_item();
                user.Size = new Size(300, 100); // kích thước UserControl
                flp.Controls.Add(user);
            }
        }

        private void picAvatarNguoiDung_Click(object sender, EventArgs e)
        {

        }
    }
}
