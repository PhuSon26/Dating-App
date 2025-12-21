using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class CapNhatMatKhau : Form
    {
        private bool _uiWired;

        private void CapNhatMatKhau_Load(object sender, EventArgs e)
        {
            if (_uiWired) return;
            _uiWired = true;

            DoubleBuffered = true;

            EnableDoubleBuffer(bgPanel);
            EnableDoubleBuffer(pnlCard);
            EnableDoubleBuffer(pnlLeft);
            EnableDoubleBuffer(pnlRight);
            EnableDoubleBuffer(pnlTips);

            bgPanel.Paint += BgPanel_Paint;
            bgPanel.Resize += (_, __) =>
            {
                CenterCardLayout();
                bgPanel.Invalidate();
            };

            Shown += (_, __) => CenterCardLayout();
            CenterCardLayout();

            ApplyRoundedWithBorder(pnlCard, 18, Color.FromArgb(230, 230, 240));

            pnlLeft.Paint += PnlLeft_Paint;
            pnlTips.Paint += PnlTips_Paint;

            pnlPassBox.Paint += (_, pe) => DrawSoftBorder(pe.Graphics, pnlPassBox.ClientRectangle, 14, Color.FromArgb(210, 195, 255));
            pnlConfirmBox.Paint += (_, pe) => DrawSoftBorder(pe.Graphics, pnlConfirmBox.ClientRectangle, 14, Color.FromArgb(210, 195, 255));
        }

        private static void EnableDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(c, true, null);
        }

        private void CenterCardLayout()
        {
            if (bgPanel == null || pnlCard == null) return;
            int x = (bgPanel.ClientSize.Width - pnlCard.Width) / 2;
            int y = (bgPanel.ClientSize.Height - pnlCard.Height) / 2;
            pnlCard.Location = new Point(Math.Max(0, x), Math.Max(0, y));
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var b = new SolidBrush(Color.FromArgb(245, 242, 255)))
                g.FillRectangle(b, bgPanel.ClientRectangle);

            var s = bgPanel.ClientSize;

            DrawBubble(g, s, -0.05f, 0.50f, 0.62f, Color.FromArgb(55, 175, 150, 255));
            DrawBubble(g, s, 0.62f, 0.20f, 0.30f, Color.FromArgb(50, 190, 175, 255));
            DrawBubble(g, s, 0.70f, 0.68f, 0.52f, Color.FromArgb(45, 255, 120, 185));
            DrawBubble(g, s, 0.96f, 0.22f, 0.22f, Color.FromArgb(35, 175, 150, 255));

            DrawBubble(g, s, 0.18f, 0.16f, 0.20f, Color.FromArgb(30, 255, 120, 185));
            DrawBubble(g, s, 0.38f, 0.86f, 0.24f, Color.FromArgb(28, 190, 175, 255));
            DrawBubble(g, s, 0.86f, 0.82f, 0.28f, Color.FromArgb(24, 175, 150, 255));
            DrawBubble(g, s, 0.48f, 0.10f, 0.18f, Color.FromArgb(22, 255, 120, 185));

            DrawBubble(g, s, 0.10f, 0.78f, 0.20f, Color.FromArgb(20, 190, 175, 255));
            DrawBubble(g, s, 0.52f, 0.76f, 0.22f, Color.FromArgb(18, 175, 150, 255));
            DrawBubble(g, s, 0.34f, 0.36f, 0.16f, Color.FromArgb(18, 190, 175, 255));
            DrawBubble(g, s, 0.78f, 0.44f, 0.16f, Color.FromArgb(16, 255, 120, 185));

            DrawBubble(g, s, 0.26f, 0.58f, 0.14f, Color.FromArgb(16, 190, 175, 255));
            DrawBubble(g, s, 0.58f, 0.48f, 0.14f, Color.FromArgb(14, 175, 150, 255));
            DrawBubble(g, s, 0.90f, 0.48f, 0.12f, Color.FromArgb(14, 255, 120, 185));
        }

        private static void DrawBubble(Graphics g, Size canvas, float cxPct, float cyPct, float diameterPct, Color color)
        {
            float baseLen = Math.Min(canvas.Width, canvas.Height);
            float d = baseLen * diameterPct;

            float cx = canvas.Width * cxPct;
            float cy = canvas.Height * cyPct;

            float x = cx - d / 2f;
            float y = cy - d / 2f;

            using var brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y, d, d);
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var r = pnlLeft.ClientRectangle;
            using var br = new LinearGradientBrush(
                r,
                Color.FromArgb(140, 90, 255),
                Color.FromArgb(255, 90, 180),
                LinearGradientMode.Vertical);

            g.FillRectangle(br, r);
        }

        private void PnlTips_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, pnlTips.Width - 1, pnlTips.Height - 1);
            using var path = RoundedRect(rect, 14);

            using (var fill = new SolidBrush(Color.FromArgb(55, 255, 255, 255)))
                g.FillPath(fill, path);

            using (var pen = new Pen(Color.FromArgb(120, 255, 255, 255), 1f))
                g.DrawPath(pen, path);
        }

        private void ApplyRoundedWithBorder(Control c, int radius, Color borderColor)
        {
            c.Paint += (_, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, c.Width - 1, c.Height - 1);
                using var path = RoundedRect(rect, radius);
                c.Region = new Region(path);

                using var pen = new Pen(borderColor, 1f);
                pe.Graphics.DrawPath(pen, path);
            };

            c.Resize += (_, __) => c.Invalidate();
        }

        private void DrawSoftBorder(Graphics g, Rectangle rect, int radius, Color color)
        {
            rect = new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            using var path = RoundedRect(rect, radius);
            using var pen = new Pen(color, 1f);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawPath(pen, path);
        }

        private GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}





