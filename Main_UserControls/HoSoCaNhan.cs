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
    public partial class HoSoCaNhan : UserControl
    {
        private Main MainForm;
        public HoSoCaNhan()
        {
            InitializeComponent();
        }
        public HoSoCaNhan(Main m)
        {
            InitializeComponent();
            MainForm = m;
        }
        private void HoSoCaNhan_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}