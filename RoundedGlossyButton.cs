using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LOGIN
{
    public class RoundedGlossyButton : Button
    {
        public int CornerRadius { get; set; } = 20;

        public RoundedGlossyButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.LightSeaGreen;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            GraphicsPath path = GetRoundedRect(rect, CornerRadius);

            // Fill button
            using (SolidBrush brush = new SolidBrush(this.BackColor))
                e.Graphics.FillPath(brush, path);

            // Glossy effect top
            Rectangle glossRect = new Rectangle(0, 0, Width, Height / 2);
            using (LinearGradientBrush glossBrush = new LinearGradientBrush(
                glossRect,
                Color.FromArgb(80, 255, 255, 255),
                Color.FromArgb(0, 255, 255, 255),
                LinearGradientMode.Vertical))
            {
                GraphicsPath glossPath = GetRoundedRect(glossRect, CornerRadius);
                e.Graphics.FillPath(glossBrush, glossPath);
            }

            // Draw text centered
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(Text, Font, textBrush, rect, sf);
            }

            this.Region = new Region(path);
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
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

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = ControlPaint.Light(this.BackColor);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = ControlPaint.Dark(this.BackColor, -0.1f);
            this.Cursor = Cursors.Default;
        }
    }
}
