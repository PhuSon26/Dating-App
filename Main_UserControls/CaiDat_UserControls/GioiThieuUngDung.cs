using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class GioiThieuUngDung : UserControl
    {
        private Main MainForm;
        public GioiThieuUngDung()
        {
            InitializeComponent();
        }
        public GioiThieuUngDung(Main m)
        {
            InitializeComponent();
            MainForm = m;
        }

        public void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.LoadContent(new CaiDat(MainForm));
        }
    }
}