using Main_Interface.User_Controls;

namespace Main_Interface
{
    public partial class Main : Form
    {
        private NapVIP nv = new NapVIP();
        private DanhSachNhanTin dsnt = new DanhSachNhanTin();
        private GhepDoi gd = new GhepDoi();
        private CaiDat cd = new CaiDat();
        private HoSoCaNhan hscn = new HoSoCaNhan();
        public Main()
        {
            InitializeComponent();
        }
        private void btn_vip_Click(object sender, EventArgs e)
        {
            LoadContent(nv);
        }
        private void btn_dsnt_Click(object sender, EventArgs e)
        {
            LoadContent(dsnt);
        }

        private void btn_ghepdoi_Click(object sender, EventArgs e)
        {
            LoadContent(gd);
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            LoadContent(new CaiDat(this));
        }

        private void btn_hscn_Click(object sender, EventArgs e)
        {
            LoadContent(hscn);
        }
        private Button activeButton = null;

        private Button CreateNavButton(string icon, string label, Point location)
        {
            var btn = new Button();
            btn.Size = new Size(160, 80);
            btn.Location = location;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Font = new Font("Segoe UI Emoji", 14, FontStyle.Regular);
            btn.ForeColor = Color.Gray;
            btn.Text = $"{icon}\n{label}";

          
            btn.MouseEnter += (s, e) =>
            {
                if (btn != activeButton)
                    btn.ForeColor = Color.FromArgb(255, 130, 160);
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn != activeButton)
                    btn.ForeColor = Color.Gray;
            };

            // Khi click
            btn.Click += (s, e) => SetActiveButton(btn);
            return btn;
        }

        private void SetActiveButton(Button btn)
        {
            if (activeButton != null)
                activeButton.ForeColor = Color.Gray;

            activeButton = btn;
            activeButton.ForeColor = Color.FromArgb(255, 90, 130); // Hồng đậm hơn
        }
        public void LoadContent(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
