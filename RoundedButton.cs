using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    public int CornerRadius { get; set; } = 20;

    public RoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = Color.FromArgb(100, 149, 237); // Mặc định xanh dương
        this.ForeColor = Color.White;

        this.MouseEnter += RoundedButton_MouseEnter;
        this.MouseLeave += RoundedButton_MouseLeave;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        if (DesignMode) return;

        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Bo tròn
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        GraphicsPath path = GetRoundedRectPath(rect, CornerRadius);
        this.Region = new Region(path);

        // Hiệu ứng bóng
        Rectangle glossRect = new Rectangle(0, 0, this.Width, this.Height / 2);
        using (LinearGradientBrush glossBrush = new LinearGradientBrush(
            glossRect,
            Color.FromArgb(80, 255, 255, 255),
            Color.FromArgb(0, 255, 255, 255),
            LinearGradientMode.Vertical))
        {
            GraphicsPath glossPath = GetRoundedRectPath(glossRect, CornerRadius);
            pevent.Graphics.FillPath(glossBrush, glossPath);
        }

        // Shadow dưới
        Rectangle shadowRect = new Rectangle(2, this.Height - 4, this.Width - 4, 4);
        using (LinearGradientBrush shadowBrush = new LinearGradientBrush(
            shadowRect,
            Color.FromArgb(0, 0, 0, 0),
            Color.FromArgb(40, 0, 0, 0),
            LinearGradientMode.Vertical))
        {
            pevent.Graphics.FillRectangle(shadowBrush, shadowRect);
        }
    }

    private void RoundedButton_MouseEnter(object sender, EventArgs e)
    {
        Color originalColor = this.BackColor;
        int r = Math.Min(255, originalColor.R + 20);
        int g = Math.Min(255, originalColor.G + 20);
        int b = Math.Min(255, originalColor.B + 20);
        this.BackColor = Color.FromArgb(r, g, b);
        this.Cursor = Cursors.Hand;
    }

    private void RoundedButton_MouseLeave(object sender, EventArgs e)
    {
        this.BackColor = Color.FromArgb(100, 149, 237); // Trả về màu mặc định
        this.Cursor = Cursors.Default;
    }

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
}