using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class NapVIP : UserControl
    {
        private System.Windows.Forms.Timer blinkTimer;
        private GlossyButton hoveredButton;
        private bool isBlinkVisible = true;

        public NapVIP()
        {
            InitializeComponent();
            SetupBlinkTimer();
        }

        private void SetupBlinkTimer()
        {
            blinkTimer = new System.Windows.Forms.Timer();
            blinkTimer.Interval = 500;
            blinkTimer.Tick += BlinkTimer_Tick;
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if (hoveredButton != null)
            {
                isBlinkVisible = !isBlinkVisible;
                hoveredButton.IsBlinking = isBlinkVisible;
                hoveredButton.Invalidate();
            }
        }

        private void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(255, 105, 180),
                Color.FromArgb(219, 112, 147),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        private void FeaturePanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.FromArgb(255, 182, 193), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void VIPButton_MouseEnter(object sender, EventArgs e)
        {
            hoveredButton = sender as GlossyButton;
            blinkTimer.Start();
        }

        private void VIPButton_MouseLeave(object sender, EventArgs e)
        {
            hoveredButton = null;
            blinkTimer.Stop();
            GlossyButton button = sender as GlossyButton;
            button.IsBlinking = false;
            button.Invalidate();
        }

        private void VIPButton_Click(object sender, EventArgs e)
        {
            GlossyButton button = sender as GlossyButton;
            MessageBox.Show($"Purchasing {button.Title} for {button.Price}\nRedirecting to payment...",
                "VIP Upgrade", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blinkTimer?.Stop();
                blinkTimer?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class GlossyButton : Control
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public bool IsBlinking { get; set; }

        public GlossyButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = GetRoundedRectangle(ClientRectangle, 40);

            Color baseColor = IsBlinking ? Color.FromArgb(255, 215, 0) : Color.FromArgb(255, 105, 180);
            Color darkColor = IsBlinking ? Color.FromArgb(218, 165, 32) : Color.FromArgb(219, 112, 147);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                ClientRectangle, baseColor, darkColor, LinearGradientMode.Vertical))
            {
                g.FillPath(brush, path);
            }

            Rectangle glossRect = new Rectangle(10, 10, Width - 20, Height / 2);
            GraphicsPath glossPath = GetRoundedRectangle(glossRect, 30);
            using (LinearGradientBrush glossBrush = new LinearGradientBrush(
                glossRect,
                Color.FromArgb(120, 255, 255, 255),
                Color.FromArgb(20, 255, 255, 255),
                LinearGradientMode.Vertical))
            {
                g.FillPath(glossBrush, glossPath);
            }

            using (Pen pen = new Pen(Color.FromArgb(200, 255, 255, 255), 3))
            {
                g.DrawPath(pen, path);
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using (Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold))
            using (Font priceFont = new Font("Segoe UI", 18, FontStyle.Bold))
            {
                RectangleF titleRect = new RectangleF(0, Height / 2 - 25, Width, 20);
                g.DrawString(Title, titleFont, Brushes.White, titleRect, sf);

                RectangleF priceRect = new RectangleF(0, Height / 2 + 5, Width, 30);
                g.DrawString(Price, priceFont, Brushes.White, priceRect, sf);
            }

            if (IsBlinking)
            {
                using (Pen glowPen = new Pen(Color.FromArgb(150, 255, 255, 0), 6))
                {
                    g.DrawPath(glowPen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}