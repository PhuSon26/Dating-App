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
        private Main MainForm;
        private SuaHoSoUser suahoso;
        private DoiEmailMatKhau dmk;
        private GioiThieuUngDung gthieu;
        private DanhSachChan dsc;
        public CaiDat()
        {
            InitializeComponent();
            SetButtonRoundedCorners();
        }
        public CaiDat(Main m)
        {
            InitializeComponent();
            MainForm = m;
            suahoso = new SuaHoSoUser(MainForm);
            dmk = new DoiEmailMatKhau(MainForm);
            gthieu = new GioiThieuUngDung(MainForm);
            dsc = new DanhSachChan(MainForm);
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

        private void btn_csHoSo_Click(object sender, EventArgs e)
        {
            LoadUserControl(suahoso);
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

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            FirebaseAuthHelper auth = MainForm.auth;
            MainForm.Hide();
            FormDangNhap dn = new FormDangNhap(auth);
            dn.Show();
        }
    }
}