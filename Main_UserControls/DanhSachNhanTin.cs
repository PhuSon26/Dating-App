using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class DanhSachNhanTin : UserControl
    {
        private Main MainForm;
        public DanhSachNhanTin()
        {
            InitializeComponent();
        }
        public DanhSachNhanTin(Main m)
        {
            InitializeComponent();
            MainForm = m;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DanhSachNhanTin_Load(object sender, EventArgs e)
        {

        }
    }
}