using System;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using Main_Interface;

namespace LOGIN
{
    public partial class FormDangNhap : Form
    {
        public FirebaseAuthHelper auth;

        private Image _bgScaled;            // nền đã scale đúng kích thước form
        private FormQuenMatKhau _qmk;
        private FormDangKy _dk;

        public FormDangNhap(FirebaseAuthHelper auth)
        {
            this.auth = auth;
            InitializeComponent();
        }

      

       
       
        private void ShowOverlay(Form f)
        {
            // Ẩn UI đăng nhập, giữ nền (không Controls.Clear để tránh tạo lại form)
            pnlCard.Visible = false;
            pnlFooter.Visible = false;

            if (f.Parent == null)
            {
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.FormBorderStyle = FormBorderStyle.None;
                panel.Controls.Add(f);
            }

            f.BringToFront();
            f.Show();
        }

        private void HideOverlay(Form f)
        {
            if (f != null && f.Parent == panel)
            {
                panel.Controls.Remove(f);
                f.Hide();
            }

            pnlCard.Visible = true;
            pnlFooter.Visible = true;
            pnlCard.BringToFront();
        }

        private void ll_quenmatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_qmk == null)
            {
                _qmk = new FormQuenMatKhau(this.auth);
                _qmk.backClicked += () => HideOverlay(_qmk);
            }
            ShowOverlay(_qmk);
        }

        private void ll_dangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_dk == null)
            {
                _dk = new FormDangKy(this.auth);
                _dk.backClicked += () => HideOverlay(_dk);
            }
            ShowOverlay(_dk);
        }

        private async void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string password = tb_matkhau.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu");
                return;
            }

            try
            {
                string result = await auth.SignIn(email, password);
                var json = JsonDocument.Parse(result);

                Session.IdToken = json.RootElement.GetProperty("idToken").ToString();
                Session.LocalId = json.RootElement.GetProperty("localId").ToString();
                auth.userID = Session.LocalId;

                bool hasUserInfo = await auth.CheckUserExist(Session.LocalId);
                if (!hasUserInfo)
                {
                    CungCapThongTin cctt = new CungCapThongTin(Session.LocalId, email, auth);
                    this.Hide();
                    cctt.Show();
                    return;
                }

                MessageBox.Show("Đăng nhập thành công");
                Main m = new Main(auth);
                this.Hide();
                m.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại", ex.Message);
            }
        }

        private void tb_matkhau_TextChanged(object sender, EventArgs e) { }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _bgScaled?.Dispose();
            base.OnFormClosed(e);
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // giảm flicker :contentReference[oaicite:0]{index=0}

            // chỉ center khi đã có size thật
            panel.SizeChanged += (s, ev) => CenterCard();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ApplyBackgroundOnce();
            CenterCard();

            // đảm bảo footer nằm trên cùng
            pnlFooter.BringToFront();
            pnlCard.BringToFront();
        }

        private void CenterCard()
        {
            if (pnlCard == null || panel == null) return;

            int footerH = pnlFooter?.Height ?? 0;

            int w = panel.ClientSize.Width;
            int h = panel.ClientSize.Height - footerH;

            if (w <= 0 || h <= 0) return;

            pnlCard.Left = Math.Max(0, (w - pnlCard.Width) / 2);
            pnlCard.Top = Math.Max(0, (h - pnlCard.Height) / 2);
        }

        private void ApplyBackgroundOnce()
        {
            if (panel.ClientSize.Width <= 0 || panel.ClientSize.Height <= 0) return;

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "login_bg.jpg");
            if (!System.IO.File.Exists(path)) return;

            _bgScaled?.Dispose();

            using (var original = ImageLoader.LoadUnlocked(path))
            {
                _bgScaled = new Bitmap(original, panel.ClientSize.Width, panel.ClientSize.Height);
            }

            panel.BackgroundImage = _bgScaled;
            panel.BackgroundImageLayout = ImageLayout.Stretch; // tăng hiệu năng hơn Tile cho ảnh lớn :contentReference[oaicite:1]{index=1}
        }

    }
}
