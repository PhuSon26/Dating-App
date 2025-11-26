using Dating_app_nhom3;
using LOGIN;
using Main_Interface.User_Controls;

namespace Main_Interface
{
    public partial class Main : Form
    {
        public NapVIP nv = new NapVIP();
        public FormDanhSachTinNhan dstn = new FormDanhSachTinNhan();
        public Thongtinuser ttuser = new Thongtinuser();
        public GhepDoi gd = new GhepDoi();
        public FirebaseAuthHelper auth;
        public Main()
        {
            InitializeComponent();
        }
        public Main(FirebaseAuthHelper auth)
        {
            InitializeComponent();
            this.auth = auth;
        }
        private void btn_vip_Click(object sender, EventArgs e)
        {
            LoadContent(nv);
        }
        private void btn_dsnt_Click(object sender, EventArgs e)
        {
            LoadContent(dstn);
        }

        private void btn_ghepdoi_Click(object sender, EventArgs e)
        {
            LoadContent(new GhepDoi(this));
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            LoadContent(new CaiDat(this));
        }

        private void btn_hscn_Click(object sender, EventArgs e)
        {
            LoadContent(ttuser);
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

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint_2(object sender, PaintEventArgs e)
        {

        }
        private void SetupButtons()
        {

            panelButtons.Controls.Clear();

            btn_vip = CreateNavButton("💎", "VIP", new Point(60, 10));
            btn_ghepdoi = CreateNavButton("❤️", "Ghép đôi", new Point(280, 10));
            btn_dsnt = CreateNavButton("💬", "Danh sách", new Point(500, 10));
            btn_hscn = CreateNavButton("👤", "Hồ sơ", new Point(720, 10));
            btn_caidat = CreateNavButton("⚙️", "Cài đặt", new Point(940, 10));


            // Gắn sự kiện click
            btn_vip.Click += btn_vip_Click;
            btn_ghepdoi.Click += btn_ghepdoi_Click;
            btn_dsnt.Click += btn_dsnt_Click;
            btn_hscn.Click += btn_hscn_Click;
            btn_caidat.Click += btn_caidat_Click;

            // Thêm nút vào panel
            panelButtons.Controls.AddRange(new Control[]
            {
                btn_vip, btn_ghepdoi, btn_dsnt, btn_hscn, btn_caidat
            });


        }

        // === Hàm tạo nút chung ===
        private Button CreateNavButton(string icon, string text)
        {
            var btn = new Button();
            btn.Size = new Size(180, 60);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(255, 130, 160);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.Text = $"{icon} {text}";
            btn.Cursor = Cursors.Hand;

            // Hiệu ứng hover
            btn.MouseEnter += (s, e) =>
                btn.BackColor = Color.FromArgb(255, 150, 180);
            btn.MouseLeave += (s, e) =>
                btn.BackColor = Color.FromArgb(255, 130, 160);

            return btn;
        }

        private void panelContent_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetupButtons();
            LoadContent(new GhepDoi(this));
        }

        private void panelButtons_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}