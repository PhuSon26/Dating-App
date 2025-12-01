using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LOGIN
{
    // Enum phân loại (Giữ nguyên)
    public enum ToastType
    {
        Match,
        Like,
        Message,
        System
    }

    public partial class thongbaonoi : Form
    {
        private System.Windows.Forms.Timer _timerLife;
        private System.Windows.Forms.Timer _timerAnimation;
        private int _targetY;
        private ToastType _type;
        private bool _isClosing = false;

        // Các Control
        private PictureBox picIcon;
        private Label lblTitle;
        private Label lblContent;
        private Panel pnlColorStrip;
        private Form _parentForm;
        private int _paddingRight = 20;
        private int _paddingBottom = 20;

        public thongbaonoi(string title, string content, Image avatar, ToastType type)
        {
            InitializeComponent();

            // Cài đặt giao diện (bao gồm cả lệnh bỏ viền)
            SetupCustomUI();

            // Gán dữ liệu
            lblTitle.Text = title;
            lblContent.Text = content;
            if (avatar != null) picIcon.Image = avatar;
            _type = type;

            ApplyStyleByType();

            // Khởi tạo Timer (Nhưng CHƯA chạy ngay, đợi gọi ShowInParent mới chạy)
            InitializeTimers();
        }

        private void SetupCustomUI()
        {
            // --- 1. QUAN TRỌNG: BỎ VIỀN VÀ SETUP FORM ---
            this.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            this.ShowInTaskbar = false; // Không hiện dưới thanh taskbar
            this.TopMost = true;        // Luôn nổi lên trên
            this.Size = new Size(350, 90);
            this.Padding = new Padding(0);
            this.BackColor = Color.White;

            // --- 2. Tạo các Control con ---
            pnlColorStrip = new Panel { Dock = DockStyle.Left, Width = 6 };

            picIcon = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Cắt tròn avatar
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, 50, 50);
            picIcon.Region = new Region(gp);

            lblTitle = new Label
            {
                Location = new Point(85, 15),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true
            };

            lblContent = new Label
            {
                Location = new Point(85, 40),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                Size = new Size(250, 40)
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblContent);
            this.Controls.Add(picIcon);
            this.Controls.Add(pnlColorStrip);

            // Sự kiện click đóng
            this.Click += (s, e) => { this.Close(); };
        }

        private void ApplyStyleByType()
        {
            switch (_type)
            {
                case ToastType.Match:
                    pnlColorStrip.BackColor = Color.FromArgb(253, 41, 123);
                    lblTitle.ForeColor = Color.FromArgb(253, 41, 123);
                    break;
                case ToastType.Like:
                    pnlColorStrip.BackColor = Color.Gold;
                    lblTitle.ForeColor = Color.Goldenrod;
                    break;
                case ToastType.Message:
                    pnlColorStrip.BackColor = Color.FromArgb(0, 122, 255);
                    lblTitle.ForeColor = Color.Black;
                    break;
                default:
                    pnlColorStrip.BackColor = Color.Gray;
                    break;
            }
        }

        // --- KHỞI TẠO TIMER RIÊNG ---
        private void InitializeTimers()
        {
            _timerAnimation = new System.Windows.Forms.Timer { Interval = 10 };
            _timerAnimation.Tick += TimerAnimation_Tick;

            _timerLife = new System.Windows.Forms.Timer { Interval = 4000 };
            _timerLife.Tick += (s, arg) =>
            {
                _timerLife.Stop();
                _isClosing = true;
                _timerAnimation.Start(); // Bắt đầu trượt xuống
            };
        }

        // --- HÀM LOGIC ANIMATION ---
        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            if (!_isClosing)
            {
                // Trượt lên
                if (this.Top > _targetY)
                {
                    this.Top -= 5;
                    this.Opacity += 0.1;
                }
                else
                {
                    // Đến đích
                    this.Top = _targetY;
                    _timerAnimation.Stop();
                    _timerLife.Start();
                }
            }
            else
            {
                // Trượt xuống (Đóng)
                this.Top += 5;
                this.Opacity -= 0.1;

                if (this.Opacity <= 0)
                {
                    _timerAnimation.Stop();
                    this.Close();
                }
            }
        }


        public void ShowInParent(Form parentForm)
        {
            _parentForm = parentForm;
            this.Owner = parentForm;

            // 1. Đăng ký sự kiện: Khi cha di chuyển, con di chuyển theo
            _parentForm.LocationChanged += ParentForm_LocationChanged;

            // 2. Đăng ký sự kiện: Khi cha thay đổi kích thước (Resize), con cũng cập nhật vị trí
            _parentForm.SizeChanged += ParentForm_LocationChanged;

            // 3. Tính toán vị trí ban đầu
            UpdatePosition();

            // 4. Hiệu ứng trượt lên (giữ nguyên logic cũ)
            // Đặt vị trí thấp hơn đích đến 50px
            this.Top = _targetY + 50;
            this.Opacity = 0;

            // Cắt bo tròn
            SetRoundedRegion();

            this.Show();
            _timerAnimation.Start();
        }

        // --- HÀM TÍNH LẠI VỊ TRÍ ---
        private void UpdatePosition()
        {
            if (_parentForm == null) return;

            // Tính X (Bám góc phải)
            int x = _parentForm.Location.X + _parentForm.Width - this.Width - _paddingRight;

            // Tính Y Đích đến (Bám góc dưới)
            _targetY = _parentForm.Location.Y + _parentForm.Height - this.Height - _paddingBottom;

            // Nếu animation đã chạy xong (thông báo đang đứng yên), thì cập nhật luôn vị trí Y
            // Nếu animation đang chạy (đang trượt), ta chỉ cập nhật X, còn Y để Timer lo
            if (!_timerAnimation.Enabled && !_isClosing)
            {
                this.Location = new Point(x, _targetY);
            }
            else
            {
                // Chỉ cập nhật X để nó không bị trôi ngang
                this.Left = x;
            }
        }

        // --- SỰ KIỆN KHI FORM CHA DI CHUYỂN ---
        private void ParentForm_LocationChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        // --- QUAN TRỌNG: HỦY SỰ KIỆN KHI ĐÓNG ---
        // Bạn phải override hàm OnFormClosed để gỡ sự kiện, tránh lỗi bộ nhớ
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_parentForm != null)
            {
                _parentForm.LocationChanged -= ParentForm_LocationChanged;
                _parentForm.SizeChanged -= ParentForm_LocationChanged;
            }
            base.OnFormClosed(e);
        }

        // Hàm phụ trợ để cắt bo tròn Form
        private void SetRoundedRegion()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Độ bo tròn
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        // Vẽ thêm viền mỏng (Optional) để thông báo rõ nét hơn trên nền trắng
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ viền màu xám nhạt bao quanh
            using (Pen p = new Pen(Color.LightGray, 1))
            {
                int r = 20; // Bán kính bo khớp với Region
                // Vẽ bo tròn theo thủ công (hoặc vẽ chữ nhật đơn giản nếu lười)
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void thongbaonoi_Load(object sender, EventArgs e)
        {

        }
    }
}