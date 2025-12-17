using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using LOGIN; // Để dùng class USER

public partial class ProfileCard : UserControl
{
    private PictureBox pbAvatar;
    private Label lblNameAge;
    private Label lblLocation;
    private Label lblBio;
    private FlowLayoutPanel flowTags; // Chứa các tag sở thích
    private Button btnLike;
    private Button btnPass;
    private USER _currentUser; // Lưu user hiện tại để xử lý logic

    public event EventHandler<USER> OnCardClicked;
    public event EventHandler<USER> OnLikeClicked;
    public event EventHandler<USER> OnPassClicked;

    public ProfileCard()
    {
        this.Size = new Size(320, 480); // Kích thước thẻ giống video
        this.BackColor = Color.White;
        this.DoubleBuffered = true; // Chống giật hình
        this.Margin = new Padding(15); // Khoảng cách giữa các thẻ

        InitializeUI();
    }

    private void InitializeUI()
    {
        this.Cursor = Cursors.Hand;
        // 1. Ảnh đại diện (Chiếm 50% thẻ)
        pbAvatar = new PictureBox();
        pbAvatar.Size = new Size(320, 240);
        pbAvatar.Location = new Point(0, 0);
        pbAvatar.SizeMode = PictureBoxSizeMode.Zoom; // Hoặc StretchImage tùy ảnh
        pbAvatar.BackColor = Color.WhiteSmoke;
        this.Controls.Add(pbAvatar);

        // 2. Tên và Tuổi
        lblNameAge = new Label();
        lblNameAge.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblNameAge.ForeColor = Color.Black;
        lblNameAge.AutoSize = true;
        lblNameAge.Location = new Point(15, 250);
        this.Controls.Add(lblNameAge);

        // 3. Vị trí
        lblLocation = new Label();
        lblLocation.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        lblLocation.ForeColor = Color.Gray;
        lblLocation.AutoSize = true;
        lblLocation.Location = new Point(15, 280);
        this.Controls.Add(lblLocation);

        // 4. Bio (Mô tả ngắn)
        lblBio = new Label();
        lblBio.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        lblBio.ForeColor = Color.DimGray;
        lblBio.Size = new Size(290, 40); // Giới hạn chiều cao
        lblBio.Location = new Point(15, 305);
        lblBio.AutoEllipsis = true; // Tự thêm dấu ... nếu dài
        this.Controls.Add(lblBio);

        // 5. Khu vực Tags (Sở thích)
        flowTags = new FlowLayoutPanel();
        flowTags.Size = new Size(290, 60);
        flowTags.Location = new Point(15, 350);
        flowTags.FlowDirection = FlowDirection.LeftToRight;
        this.Controls.Add(flowTags);

        // 6. Nút Thích (Màu Hồng)
        btnLike = CreateRoundedButton("♥ Thích", Color.FromArgb(233, 30, 99), Color.White);
        btnLike.Location = new Point(165, 420);
        btnLike.Click += (s, e) => OnLikeClicked?.Invoke(this, _currentUser);
        this.Controls.Add(btnLike);

        // 7. Nút Bỏ qua (Màu Xám)
        btnPass = CreateRoundedButton("✖ Bỏ qua", Color.WhiteSmoke, Color.Black);
        btnPass.Location = new Point(15, 420);
        btnPass.Click += (s, e) => OnPassClicked?.Invoke(this, _currentUser);
        this.Controls.Add(btnPass);
        AddHoverEffect();
    }
    private void AddHoverEffect()
    {
        // Khi chuột vào -> Đổi màu nền nhẹ
        this.MouseEnter += (s, e) => { this.BackColor = Color.FromArgb(250, 240, 245); }; // Màu hồng phấn rất nhạt

        // Khi chuột ra -> Trả về màu trắng
        this.MouseLeave += (s, e) => { this.BackColor = Color.White; };

        // Áp dụng cho cả các thành phần con (để không bị mất hiệu ứng khi chuột đè lên label)
        pbAvatar.MouseEnter += (s, e) => { this.BackColor = Color.FromArgb(250, 240, 245); };
        pbAvatar.MouseLeave += (s, e) => { this.BackColor = Color.White; };

        lblNameAge.MouseEnter += (s, e) => { this.BackColor = Color.FromArgb(250, 240, 245); };
        lblNameAge.MouseLeave += (s, e) => { this.BackColor = Color.White; };
    }


    public void SetData(USER user)
    {
        _currentUser = user;
        lblNameAge.Text = $"{user.ten}, {user.tuoi}";
        lblLocation.Text = string.IsNullOrEmpty(user.vitri) ? "📍 Không rõ" : $"📍 {user.vitri}";
        lblBio.Text = user.gthieu ?? "Chưa có giới thiệu.";
      
        // Load ảnh (Bạn cần logic async load ảnh ở đây hoặc truyền Image vào)
        // Ví dụ tạm:
        if (!string.IsNullOrEmpty(user.AvatarUrl))
            pbAvatar.ImageLocation = user.AvatarUrl;

        // Tạo các Tags
        flowTags.Controls.Clear();
        // Giả sử user.thoiquen là chuỗi "Du lịch, Đọc sách" -> Cắt chuỗi
        if (!string.IsNullOrEmpty(user.thoiquen))
        {
            var interests = user.thoiquen.Split(',');
            foreach (var item in interests)
            {
                flowTags.Controls.Add(CreateTagLabel(item.Trim()));
            }
        }
        this.Click += TriggerOpenDetail;

        if (pbAvatar != null) pbAvatar.Click += TriggerOpenDetail;
        if (lblNameAge != null) lblNameAge.Click += TriggerOpenDetail;
        if (lblBio != null) lblBio.Click += TriggerOpenDetail;
    }
    private void TriggerOpenDetail(object sender, EventArgs e)
    {
       
        if (_currentUser != null)
        {
            OnCardClicked?.Invoke(this, _currentUser);
        }
    }

    // --- CÁC HÀM TRANG TRÍ (BO GÓC) ---

    // Vẽ bo góc cho toàn bộ Card
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        int radius = 20; // Độ bo tròn
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, radius, radius, 180, 90);
        path.AddArc(Width - radius, 0, radius, radius, 270, 90);
        path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
        path.AddArc(0, Height - radius, radius, radius, 90, 90);
        path.CloseAllFigures();
        this.Region = new Region(path);

        // Vẽ viền mờ cho đẹp
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (Pen p = new Pen(Color.LightGray, 1))
        {
            e.Graphics.DrawPath(p, path);
        }
    }

    // Tạo Label dạng "Viên thuốc" cho Tag
    private Label CreateTagLabel(string text)
    {
        Label lbl = new Label();
        lbl.Text = text;
        lbl.AutoSize = true;
        lbl.Padding = new Padding(8, 4, 8, 4);
        lbl.BackColor = Color.FromArgb(240, 240, 240);
        lbl.ForeColor = Color.Black;
        lbl.Font = new Font("Segoe UI", 8);
        lbl.Margin = new Padding(0, 0, 5, 5); // Cách nhau ra

        // Hack nhỏ để label có bo góc (hoặc dùng Paint event nếu cần đẹp hơn)
        lbl.Paint += (s, e) =>
        {
            e.Graphics.Clear(lbl.BackColor);
            // Vẽ bo góc cho tag ở đây nếu cần cầu kỳ
            TextRenderer.DrawText(e.Graphics, text, lbl.Font, new Point(4, 2), lbl.ForeColor);
        };
        return lbl;
    }

    // Tạo nút bo tròn
    private Button CreateRoundedButton(string text, Color backColor, Color foreColor)
    {
        Button btn = new Button();
        btn.Text = text;
        btn.Size = new Size(130, 45);
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.BackColor = backColor;
        btn.ForeColor = foreColor;
        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;

        // Sự kiện vẽ bo góc cho nút
        btn.Paint += (s, e) =>
        {
            Rectangle r = new Rectangle(0, 0, btn.Width, btn.Height);
            int rad = 20;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, rad, rad, 180, 90);
            gp.AddArc(r.Right - rad, r.Y, rad, rad, 270, 90);
            gp.AddArc(r.Right - rad, r.Bottom - rad, rad, rad, 0, 90);
            gp.AddArc(r.X, r.Bottom - rad, rad, rad, 90, 90);
            gp.CloseFigure();
            btn.Region = new Region(gp);
        };
        return btn;
    }

    private void ProfileCard_Load(object sender, EventArgs e)
    {

    }
}