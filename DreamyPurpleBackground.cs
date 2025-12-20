using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Main_Interface.UI_Backgrounds
{
    public class DreamyPurpleBackground : Panel
    {
        public DreamyPurpleBackground()
        {
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;

            // Gradient tím mộng mơ
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(170, 130, 255), // tím lavender
                Color.FromArgb(255, 182, 193), // hồng pastel
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }

            // Glow mờ
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(-200, -150, Width + 400, Height + 300);
                using (PathGradientBrush glow = new PathGradientBrush(path))
                {
                    glow.CenterColor = Color.FromArgb(60, Color.White);
                    glow.SurroundColors = new Color[] { Color.Transparent };
                    g.FillPath(glow, path);
                }
            }
        }
    }
}
