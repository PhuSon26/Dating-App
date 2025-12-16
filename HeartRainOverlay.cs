using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public sealed class HeartRainOverlay : Control
{
    private sealed class Heart
    {
        public float X, Y, Vx, Vy, Size, Rot, RotSpeed, Life, MaxLife;
    }

    private readonly List<Heart> _hearts = new();
    private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer { Interval = 16 };
    private readonly Stopwatch _sw = new();
    private readonly Random _rng = new();

    private int _spawnRemaining;
    private float _spawnRatePerSec;

    private Bitmap _bgSnapshot; // snapshot UI bên dưới

    public HeartRainOverlay()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.UserPaint, true);

        Dock = DockStyle.Fill;
        Visible = false;

        _timer.Tick += (_, __) => TickFrame();
    }

    // chụp UI của parent (bao gồm cả các control con)
    private void CaptureBackground()
    {
        if (Parent == null || Parent.ClientSize.Width <= 0 || Parent.ClientSize.Height <= 0) return;

        _bgSnapshot?.Dispose();
        _bgSnapshot = new Bitmap(Parent.ClientSize.Width, Parent.ClientSize.Height);
        Parent.DrawToBitmap(_bgSnapshot, new Rectangle(Point.Empty, _bgSnapshot.Size));
    }

    public void Trigger(int totalHearts = 80, int durationMs = 1200)
    {
        if (totalHearts <= 0 || durationMs <= 0) return;

        CaptureBackground();      // <<< quan trọng
        BringToFront();
        Visible = true;

        _spawnRemaining = totalHearts;
        _spawnRatePerSec = totalHearts / (durationMs / 1000f);

        _sw.Restart();
        _timer.Start();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (Visible) CaptureBackground();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // vẽ lại snapshot để “giữ nguyên UI ghép đôi”
        if (_bgSnapshot != null)
            e.Graphics.DrawImageUnscaled(_bgSnapshot, 0, 0);
        else
            e.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);
    }

    private void TickFrame()
    {
        float dt = (float)_sw.Elapsed.TotalSeconds;
        _sw.Restart();
        if (dt <= 0) dt = 0.016f;
        if (dt > 0.05f) dt = 0.05f;

        if (_spawnRemaining > 0)
        {
            int spawnNow = (int)Math.Floor(_spawnRatePerSec * dt);
            if (spawnNow < 1) spawnNow = 1;
            if (spawnNow > _spawnRemaining) spawnNow = _spawnRemaining;

            for (int i = 0; i < spawnNow; i++) SpawnOne();
            _spawnRemaining -= spawnNow;
        }

        for (int i = _hearts.Count - 1; i >= 0; i--)
        {
            var h = _hearts[i];
            h.X += h.Vx * dt;
            h.Y += h.Vy * dt;
            h.Rot += h.RotSpeed * dt;
            h.Life += dt;

            if (h.Y > Height + 80 || h.Life >= h.MaxLife)
                _hearts.RemoveAt(i);
        }

        Invalidate();

        if (_spawnRemaining <= 0 && _hearts.Count == 0)
        {
            _timer.Stop();
            _sw.Reset();
            Visible = false;
            _bgSnapshot?.Dispose();
            _bgSnapshot = null;
        }
    }

    private void SpawnOne()
    {
        float w = Math.Max(1, Width);
        float startX = (float)_rng.NextDouble() * w;
        float startY = -30f - (float)_rng.NextDouble() * 120f;

        float size = 18f + (float)_rng.NextDouble() * 28f;
        float vy = 220f + (float)_rng.NextDouble() * 280f;
        float vx = -40f + (float)_rng.NextDouble() * 80f;

        _hearts.Add(new Heart
        {
            X = startX,
            Y = startY,
            Vx = vx,
            Vy = vy,
            Size = size,
            Rot = (float)(_rng.NextDouble() * 20 - 10),
            RotSpeed = -180f + (float)_rng.NextDouble() * 360f,
            Life = 0f,
            MaxLife = 2.6f + (float)_rng.NextDouble() * 1.2f
        });
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using var font = new Font("Segoe UI Emoji", 24f, FontStyle.Regular, GraphicsUnit.Pixel);
        const string heartChar = "❤";

        foreach (var h in _hearts)
        {
            float t = h.Life / h.MaxLife;
            float alpha = (t > 0.75f) ? (1f - (t - 0.75f) / 0.25f) : 1f;
            int a = (int)(alpha * 255);
            if (a < 0) a = 0;
            if (a > 255) a = 255;

            using var brush = new SolidBrush(Color.FromArgb(a, 255, 0, 60));

            var state = g.Save();
            g.TranslateTransform(h.X, h.Y);
            g.RotateTransform(h.Rot);

            float scale = h.Size / 32f;
            g.ScaleTransform(scale, scale);

            var sz = g.MeasureString(heartChar, font);
            g.DrawString(heartChar, font, brush, -sz.Width / 2f, -sz.Height / 2f);

            g.Restore(state);
        }
    }
}
