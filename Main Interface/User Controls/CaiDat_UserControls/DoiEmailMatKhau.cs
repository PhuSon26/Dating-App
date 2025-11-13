using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls.CaiDat_UserControls
{
    public partial class DoiEmailMatKhau : UserControl
    {
        private Main MainForm;
        public DoiEmailMatKhau()
        {
            InitializeComponent();
        }
        public DoiEmailMatKhau(Main m)
        {
            InitializeComponent();
            MainForm = m;
        }

        private void DoiEmailMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.LoadContent(new CaiDat(MainForm));
        }
    }
}
