using Main_Interface.User_Controls;

namespace Main_Interface
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
        private void btn_vip_Click(object sender, EventArgs e)
        {
            LoadControl(new NapVIP());
        }

        private void btn_dsnt_Click(object sender, EventArgs e)
        {
            LoadControl(new DanhSachNhanTin());
        }

        private void btn_ghepdoi_Click(object sender, EventArgs e)
        {
            LoadControl(new GhepDoi());
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            LoadControl(new CaiDat());
        }

        private void btn_hscn_Click(object sender, EventArgs e)
        {
            LoadControl(new HoSoCaNhan());
        }
    }
}
