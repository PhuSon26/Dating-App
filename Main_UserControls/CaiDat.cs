using LOGIN;
using Main_Interface.User_Controls.CaiDat_UserControls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class CaiDat : UserControl
    {
        public readonly FirebaseAuthHelper _auth =
     new FirebaseAuthHelper("AIzaSyDg9nNBc3h74QjNl2obv6pH1Y29RQQ8TjU");
        public Main MainForm;
        public DoiEmailMatKhau dmk;
        public GioiThieuUngDung gthieu;
        public DanhSachChan dsc;
        public CaiDat()
        {
            InitializeComponent();
            SetButtonRoundedCorners();
        }
        public CaiDat(Main m)
        {
            InitializeComponent();
            MainForm = m;
            dmk = new DoiEmailMatKhau(MainForm);
            gthieu = new GioiThieuUngDung(MainForm);
        }
        public void LoadUserControl(UserControl uc)
        {
            MainForm.panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            MainForm.panelContent.Controls.Add(uc);
        }

        private void CaiDat_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }
        private void btn_doiEmailMk_Click(object sender, EventArgs e)
        {
            LoadUserControl(dmk);
        }

        private void btn_gioithieuUngDung_Click(object sender, EventArgs e)
        {
            LoadUserControl(gthieu);
        }

        private void btn_dsChan_Click(object sender, EventArgs e)
        {
            dsc = new DanhSachChan(MainForm, MainForm.auth);
            LoadUserControl(dsc);
        }

        // Set rounded corners for all buttons
        private void SetButtonRoundedCorners()
        {
            int radius = 20;
            SetRoundedButton(btn_doiEmailMk, radius);
            SetRoundedButton(btn_xoaTk, radius);
            SetRoundedButton(btn_dsChan, radius);
            SetRoundedButton(btn_gioithieuUngDung, radius);
            SetRoundedButton(cb_tatThongbao, radius);
        }

        // Create rounded rectangle path
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Apply rounded corners to button
        private void SetRoundedButton(Control button, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = GetRoundedRectPath(rect, radius);
            button.Region = new Region(path);
        }

        // Paint glossy effect on buttons
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create glossy gradient
            Rectangle glossRect = new Rectangle(0, 0, btn.Width, btn.Height / 2);
            using (LinearGradientBrush glossBrush = new LinearGradientBrush(
                glossRect,
                Color.FromArgb(80, 255, 255, 255),
                Color.FromArgb(0, 255, 255, 255),
                LinearGradientMode.Vertical))
            {
                GraphicsPath glossPath = GetRoundedRectPath(glossRect, 20);
                e.Graphics.FillPath(glossBrush, glossPath);
            }

            // Add subtle shadow at bottom
            Rectangle shadowRect = new Rectangle(2, btn.Height - 4, btn.Width - 4, 4);
            using (LinearGradientBrush shadowBrush = new LinearGradientBrush(
                shadowRect,
                Color.FromArgb(0, 0, 0, 0),
                Color.FromArgb(40, 0, 0, 0),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(shadowBrush, shadowRect);
            }
        }

        // Mouse enter effect - brighten button
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            if (btn == null) return;

            Color originalColor = btn.BackColor;
            int r = Math.Min(255, originalColor.R + 20);
            int g = Math.Min(255, originalColor.G + 20);
            int b = Math.Min(255, originalColor.B + 20);
            btn.BackColor = Color.FromArgb(r, g, b);
            btn.Cursor = Cursors.Hand;
        }

        // Mouse leave effect - restore original color
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            if (btn == null) return;

            // Restore original colors
            if (btn == btn_doiEmailMk)
                btn.BackColor = Color.FromArgb(72, 209, 204);
            else if (btn == btn_xoaTk)
                btn.BackColor = Color.FromArgb(220, 53, 69);
            else if (btn == btn_dsChan)
                btn.BackColor = Color.FromArgb(255, 165, 0);
            else if (btn == btn_gioithieuUngDung)
                btn.BackColor = Color.FromArgb(108, 117, 125);
            else if (btn == cb_tatThongbao)
                btn.BackColor = cb_tatThongbao.Checked ?
                    Color.FromArgb(102, 51, 204) : Color.FromArgb(153, 102, 255);

            btn.Cursor = Cursors.Default;
        }

        private void cb_tatThongbao_CheckedChanged(object sender, EventArgs e)
        {
            cb_tatThongbao.Text = cb_tatThongbao.Checked ? "🔕 Tắt Thông Báo" : "🔔 Bật Thông Báo";
        }



        private async void btn_xoaTk_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn chắc chắn muốn xóa tài khoản? Thao tác này không thể hoàn tác.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            try
            {
                string idToken = Session.IdToken;   // đã lưu sau khi đăng nhập / đăng ký
                string uid = Session.LocalId;

                // 1. Xóa trên Firebase Auth
                await _auth.DeleteAccountAsync(idToken);

                // 2. Xóa hồ sơ trên Firestore
                await _auth.DeleteUserInfoAsync(uid);

                MessageBox.Show("Tài khoản đã được xóa.");

                Application.Restart(); // hoặc đóng hết form về màn hình login
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa tài khoản: " + ex.Message);
            }
        }
        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            FirebaseAuthHelper auth = MainForm.auth;
            MainForm.Hide();
            FormDangNhap dn = new FormDangNhap(auth);
            dn.Show();
        }
    }
}