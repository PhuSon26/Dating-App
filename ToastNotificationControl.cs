using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class ToastNotificationControl : UserControl
    {
        private System.Windows.Forms.Timer _timerLife;
        private System.Windows.Forms.Timer _timerAnimation;
        private int _targetY;
        private ToastType _type;
        private bool _isClosing = false;
        private float _opacity = 0f;

        private PictureBox picIcon;
        private Label lblTitle;
        private Label lblContent;
        private Panel pnlColorStrip;
        private Button btnClose;
        private Control _parentContainer;
        private int _paddingRight = 20;
        private int _paddingBottom = 20;

        // Màu sắc theo type
        private Color _themeColor;
        private Color _bgColor;

        public ToastNotificationControl(string title, string content, Image avatar, ToastType type)
        {
            this.DoubleBuffered = true;
            _type = type;

            SetupCustomUI();

            lblTitle.Text = title;
            lblContent.Text = content;
            AdjustHeight();
            if (avatar != null)
            {
                picIcon.Image = avatar;
            }
            else
            {
                // Icon mặc định theo type
                SetDefaultIcon();
            }

            ApplyStyleByType();
            InitializeTimers();
        }

        private void SetupCustomUI()
        {
            // Setup UserControl
            this.Size = new Size(380, 100);
            this.BackColor = Color.White;
            this.Padding = new Padding(0);

            // Thanh màu bên trái 
            pnlColorStrip = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(4, this.Height),
                BackColor = Color.Gray
            };

            // Icon/Avatar
            picIcon = new PictureBox
            {
                Size = new Size(56, 56),
                Location = new Point(20, 22),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };

            // Cắt tròn avatar với viền
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, 56, 56);
            picIcon.Region = new Region(gp);

            // Title 
            lblTitle = new Label
            {
                Location = new Point(90, 20),
                Size = new Size(240, 28),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                BackColor = Color.Transparent,
                AutoEllipsis = true
            };

            // Content (Font mềm mại hơn)
            lblContent = new Label
            {
                Location = new Point(90, 48),
                Width = 260, 
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(117, 117, 117),
                BackColor = Color.Transparent,
                AutoSize = true, 
                MaximumSize = new Size(260, 120) 
            };

            // Nút đóng (X) - Thiết kế tối giản
            btnClose = new Button
            {
                Size = new Size(28, 28),
                Location = new Point(this.Width - 38, 10),
                Text = "✕",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(150, 150, 150),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 220, 220);
            btnClose.Click += (s, e) => { CloseNotification(); };

            // Hover effect cho nút close
            btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.FromArgb(80, 80, 80);
            btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(150, 150, 150);

            this.Controls.Add(btnClose);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblContent);
            this.Controls.Add(picIcon);
            this.Controls.Add(pnlColorStrip);

            // Click vào thông báo để đóng (trừ nút close)
            this.Click += (s, e) => { CloseNotification(); };
            lblTitle.Click += (s, e) => { CloseNotification(); };
            lblContent.Click += (s, e) => { CloseNotification(); };
            picIcon.Click += (s, e) => { CloseNotification(); };
        }

        private void SetDefaultIcon()
        {
            Bitmap bmp = new Bitmap(56, 56);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Vẽ nền tròn
                Color iconBg = Color.LightGray;
                switch (_type)
                {
                    case ToastType.Match:
                        iconBg = Color.FromArgb(255, 230, 240);
                        break;
                    case ToastType.Like:
                        iconBg = Color.FromArgb(255, 250, 205);
                        break;
                    case ToastType.Message:
                        iconBg = Color.FromArgb(230, 240, 255);
                        break;
                    case ToastType.System:
                        iconBg = Color.FromArgb(240, 240, 240);
                        break;
                }

                using (SolidBrush brush = new SolidBrush(iconBg))
                {
                    g.FillEllipse(brush, 0, 0, 55, 55);
                }

                // Vẽ icon/emoji
                string emoji = "🔔";
                switch (_type)
                {
                    case ToastType.Match:
                        emoji = "💖";
                        break;
                    case ToastType.Like:
                        emoji = "⭐";
                        break;
                    case ToastType.Message:
                        emoji = "💬";
                        break;
                    case ToastType.System:
                        emoji = "🔔";
                        break;
                }

                using (Font font = new Font("Segoe UI Emoji", 24, FontStyle.Regular))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(emoji, font, Brushes.Black, new RectangleF(0, 0, 56, 56), sf);
                }
            }
            picIcon.Image = bmp;
        }

        private void ApplyStyleByType()
        {
            switch (_type)
            {
                case ToastType.Match:
                    _themeColor = Color.FromArgb(253, 41, 123);
                    _bgColor = Color.FromArgb(255, 245, 250);
                    pnlColorStrip.BackColor = _themeColor;
                    break;
                case ToastType.Like:
                    _themeColor = Color.FromArgb(255, 193, 7);
                    _bgColor = Color.FromArgb(255, 252, 240);
                    pnlColorStrip.BackColor = _themeColor;
                    break;
                case ToastType.Message:
                    _themeColor = Color.FromArgb(0, 122, 255);
                    _bgColor = Color.FromArgb(240, 248, 255);
                    pnlColorStrip.BackColor = _themeColor;
                    break;
                default:
                    _themeColor = Color.FromArgb(108, 117, 125);
                    _bgColor = Color.White;
                    pnlColorStrip.BackColor = _themeColor;
                    break;
            }

            // Áp dụng màu nền nhẹ
            this.BackColor = _bgColor;
        }

        private void InitializeTimers()
        {
            _timerAnimation = new System.Windows.Forms.Timer { Interval = 5 };
            _timerAnimation.Tick += TimerAnimation_Tick;

            _timerLife = new System.Windows.Forms.Timer { Interval = 3000 }; 
            _timerLife.Tick += (s, arg) =>
            {
                _timerLife.Stop();
                _isClosing = true;
                _timerAnimation.Start();
            };
        }

        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            if (!_isClosing)
            {
                // Trượt lên
                if (this.Top > _targetY)
                {
                    this.Top -= 6; // Nhanh hơn
                    if (_opacity < 1f)
                    {
                        _opacity += 0.25f;
                        if (_opacity > 1f) _opacity = 1f;
                        this.Invalidate();
                    }
                }
                else
                {
                    this.Top = _targetY;
                    _opacity = 1f;
                    this.Invalidate();
                    _timerAnimation.Stop();
                    _timerLife.Start();
                }
            }
            else
            {
                // Trượt xuống
                this.Top += 6;
                _opacity -= 0.20f;
                if (_opacity < 0f) _opacity = 0f;
                this.Invalidate();

                if (_opacity <= 0 || this.Top > (_parentContainer?.Height ?? Screen.PrimaryScreen.WorkingArea.Height))
                {
                    _timerAnimation.Stop();
                    CloseNotification();
                }
            }
        }

        public void ShowInContainer(Control parentContainer)
        {
            _parentContainer = parentContainer;

            UpdatePosition();

            this.Top = _targetY + 60;
            _opacity = 0f;

            SetRoundedRegion();

            _parentContainer.Controls.Add(this);
            this.BringToFront();

            _timerAnimation.Start();
        }

        private void UpdatePosition()
        {
            if (_parentContainer == null) return;

            int x = _parentContainer.Width - this.Width - _paddingRight;

            int menuHeight = 85;
            _targetY = _parentContainer.Height - this.Height - menuHeight - _paddingBottom;

            if (_targetY < 10) _targetY = 10;

            if (!_timerAnimation.Enabled && !_isClosing)
            {
                this.Location = new Point(x, _targetY);
            }
        }

        private void CloseNotification()
        {
            _timerLife?.Stop();
            _timerLife?.Dispose();
            _timerAnimation?.Stop();
            _timerAnimation?.Dispose();

            if (_parentContainer != null && _parentContainer.Controls.Contains(this))
            {
                _parentContainer.Controls.Remove(this);
            }

            this.Dispose();
        }

        private void SetRoundedRegion()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 12; 
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Áp dụng opacity
            if (_opacity < 1f)
            {
                int alpha = (int)((1f - _opacity) * 255);
                Color overlayColor = Color.FromArgb(alpha, this.Parent?.BackColor ?? Color.FromArgb(240, 242, 245));

                using (SolidBrush brush = new SolidBrush(overlayColor))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }

            // Vẽ bóng đổ đẹp (shadow mềm mại)
            Rectangle shadowRect = new Rectangle(2, 2, this.Width - 4, this.Height - 4);
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                int radius = 12;
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, radius, radius, 180, 90);
                shadowPath.AddArc(shadowRect.X + shadowRect.Width - radius, shadowRect.Y, radius, radius, 270, 90);
                shadowPath.AddArc(shadowRect.X + shadowRect.Width - radius, shadowRect.Y + shadowRect.Height - radius, radius, radius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Y + shadowRect.Height - radius, radius, radius, 90, 90);
                shadowPath.CloseFigure();

                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb((int)(_opacity * 20), 0, 0, 0);
                    shadowBrush.SurroundColors = new[] { Color.Transparent };
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Vẽ viền mỏng
            using (Pen borderPen = new Pen(Color.FromArgb((int)(_opacity * 60), _themeColor), 1))
            {
                Rectangle borderRect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                int radius = 12;

                using (GraphicsPath borderPath = new GraphicsPath())
                {
                    borderPath.AddArc(borderRect.X, borderRect.Y, radius, radius, 180, 90);
                    borderPath.AddArc(borderRect.X + borderRect.Width - radius, borderRect.Y, radius, radius, 270, 90);
                    borderPath.AddArc(borderRect.X + borderRect.Width - radius, borderRect.Y + borderRect.Height - radius, radius, radius, 0, 90);
                    borderPath.AddArc(borderRect.X, borderRect.Y + borderRect.Height - radius, radius, radius, 90, 90);
                    borderPath.CloseFigure();

                    e.Graphics.DrawPath(borderPen, borderPath);
                }
            }
        }
        private void AdjustHeight()
        {
            // Đảm bảo Label đã có text trước khi đo
            // Khoảng cách lề trên (48) + Chiều cao Label + Khoảng cách lề dưới (15)
            int calculatedHeight = lblContent.Top + lblContent.Height + 15;

            // Đảm bảo chiều cao tối thiểu là 100
            if (calculatedHeight < 100) calculatedHeight = 100;

            this.Height = calculatedHeight;

            // Cập nhật lại thanh màu bên trái và nút đóng
            pnlColorStrip.Height = this.Height;
            btnClose.Location = new Point(this.Width - 38, 10);

            // Cập nhật lại bo tròn vùng hiển thị
            SetRoundedRegion();
        }

        private void ToastNotificationControl_Load(object sender, EventArgs e)
        {

        }
    }

}