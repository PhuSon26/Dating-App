using LOGIN;
using Google.Cloud.Firestore;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class UserChatitem : UserControl
{
    private PictureBox picAvatar;
    private Label lblName;
    private Label lblLastMessage;
    private Label lblTime;
    private Label lblBadge;

    public event Action<USER> OnOpenChat;

    public string UserName => lblName.Text;
    public USER UserData { get; private set; }
    public ChatMeta MetaData { get; private set; }
    private FirebaseAuthHelper firebase;

    public UserChatitem()
    {
        InitializeComponents();
        this.Width = 580;
        this.Height = 150;
        this.Margin = new Padding(5);
        this.Cursor = Cursors.Hand;
    }

    public UserChatitem(USER user, ChatMeta meta, FirebaseAuthHelper firebase) : this()
    {
        UserData = user;
        MetaData = meta;
        this.firebase = firebase;

        BindData();
    }

    private void InitializeComponents()
    {
        picAvatar = new PictureBox
        {
            Width = 130,
            Height = 130,
            Left = 10,
            Top = 10,
            SizeMode = PictureBoxSizeMode.StretchImage,
            BorderStyle = BorderStyle.FixedSingle
        };

        lblName = new Label
        {
            Left = 150,
            Top = 10,
            Width = 150,
            AutoSize = true,
            Height = 45,
            BackColor = Color.Transparent,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(50, 50, 50)
        };

        lblLastMessage = new Label
        {
            Left = 150,
            Top = 60,
            Width = 350,          
            Height = 40,          
            Font = new Font("Segoe UI", 10),
            ForeColor = Color.FromArgb(50, 50, 50),
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.TopLeft,
            UseCompatibleTextRendering = true,
            AutoSize = false,     
            AutoEllipsis = true  
        };
        lblTime = new Label
        {
            Left = 480,
            Top = 10,
            Width = 50,
            BackColor = Color.Transparent,
            AutoSize = true,
            Font = new Font("Segoe UI", 16),
            TextAlign = ContentAlignment.TopRight,
            ForeColor = Color.FromArgb(50, 50, 50)
        };

        lblBadge = new Label
        {
            Left = 520,
            Top = 40,
            Width = 30,
            Height = 20,
            BackColor = Color.FromArgb(255, 255, 99, 71), // tomato red
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Visible = false
        };

        this.Controls.Add(picAvatar);
        this.Controls.Add(lblName);
        this.Controls.Add(lblLastMessage);
        this.Controls.Add(lblTime);
        this.Controls.Add(lblBadge);

        this.Click += HandleClick;
        foreach (Control c in this.Controls)
            c.Click += HandleClick;
    }

    private void HandleClick(object sender, EventArgs e)
    {
        OnOpenChat?.Invoke(UserData);
    }

    private void BindData()
    {
        lblName.Text = UserData.ten ?? "Anonymous";

        if (!string.IsNullOrEmpty(UserData.AvatarUrl))
        {
            try { picAvatar.Image = firebase.Base64ToImage(UserData.AvatarUrl); } catch { }
        }

        lblLastMessage.Text = MetaData.lastMessage ?? "";
        lblTime.Text = FormatTime(MetaData.lastTimestamp);

        int unread = GetUnreadCount();
        if (unread > 0)
        {
            lblBadge.Text = unread.ToString();
            lblBadge.Visible = true;
        }
    }

    private int GetUnreadCount()
    {
        string me = Session.LocalId;

        if (me == MetaData.userA)
            return MetaData.unread_userA;
        else
            return MetaData.unread_userB;
    }

    private string FormatTime(Timestamp t)
    {
        if (t == null) return "";

        var dt = t.ToDateTime();
        if (dt.Date == DateTime.Now.Date)
            return dt.ToString("HH:mm");

        return dt.ToString("dd/MM");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Gradient background SynHeart
        using (LinearGradientBrush brush = new LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(255, 240, 242, 245), // xám nhạt xanh
            Color.FromArgb(255, 255, 192, 203), // pastel hồng
            LinearGradientMode.Horizontal))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // Bo góc 20px
        using (GraphicsPath path = RoundedRect(this.ClientRectangle, 20))
        {
            this.Region = new Region(path);
        }
    }

    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;

        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}
