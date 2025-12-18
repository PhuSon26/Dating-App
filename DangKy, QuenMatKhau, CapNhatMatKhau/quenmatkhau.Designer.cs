using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class FormQuenMatKhau : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Panel bgPanel;

        private Panel pnlCard;
        private TableLayoutPanel tblCard;

        private Panel pnlLeft;
        private Panel pnlRight;

        private Label label1;          // brand (SynHeart)
        private Label lblLeftTitle;    // "Lấy lại mật khẩu"
        private Label lblLeftDesc;     // mô tả
        private Panel pnlTips;
        private Label lblTipsTitle;
        private Label lblTipsBody;

        private Label lblTitle;        // "Khôi phục mật khẩu"
        private Label lblSubTitle;     // mô tả ngắn

        private Label labelEmail;      // "Email"
        private Panel pnlEmailBox;
        private TextBox tb_email;

        private Label label2;          // "Mã xác nhận"
        private TableLayoutPanel tblCodeRow;
        private Panel pnlCodeBox;
        private TextBox tb_maxacnhan;
        private RoundedButton btn_nhanma;

        private RoundedButton btn_xacnhan;
        private LinkLabel ll_back;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            bgPanel = new Panel();
            pnlCard = new Panel();
            tblCard = new TableLayoutPanel();
            pnlLeft = new Panel();
            pnlRight = new Panel();

            label1 = new Label();
            lblLeftTitle = new Label();
            lblLeftDesc = new Label();
            pnlTips = new Panel();
            lblTipsTitle = new Label();
            lblTipsBody = new Label();

            lblTitle = new Label();
            lblSubTitle = new Label();

            labelEmail = new Label();
            pnlEmailBox = new Panel();
            tb_email = new TextBox();

            label2 = new Label();
            tblCodeRow = new TableLayoutPanel();
            pnlCodeBox = new Panel();
            tb_maxacnhan = new TextBox();
            btn_nhanma = new RoundedButton();

            btn_xacnhan = new RoundedButton();
            ll_back = new LinkLabel();

            bgPanel.SuspendLayout();
            pnlCard.SuspendLayout();
            tblCard.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlTips.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlEmailBox.SuspendLayout();
            tblCodeRow.SuspendLayout();
            pnlCodeBox.SuspendLayout();
            SuspendLayout();

            // ===== Form =====
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            BackColor = Color.FromArgb(245, 242, 255);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormQuenMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += FormQuenMatKhau_Load;

            // ===== bgPanel =====
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.BackColor = Color.FromArgb(245, 242, 255);
            bgPanel.Controls.Add(pnlCard);

            // ===== pnlCard (tăng chiều cao để không khuất viền button + chữ) =====
            pnlCard.BackColor = Color.White;
            pnlCard.Size = new Size(720, 320);
            pnlCard.Location = new Point((800 - 720) / 2, (450 - 320) / 2);
            pnlCard.Anchor = AnchorStyles.None;
            pnlCard.Padding = new Padding(0);
            pnlCard.Controls.Add(tblCard);

            // ===== tblCard =====
            tblCard.Dock = DockStyle.Fill;
            tblCard.Margin = new Padding(0);
            tblCard.Padding = new Padding(0);
            tblCard.ColumnCount = 2;
            tblCard.RowCount = 1;
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCard.Controls.Add(pnlLeft, 0, 0);
            tblCard.Controls.Add(pnlRight, 1, 0);

            // ===== pnlLeft (gradient sẽ vẽ ở code-behind; ở đây chỉ set layout) =====
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.BackColor = Color.FromArgb(150, 60, 220); // fallback
            pnlLeft.Padding = new Padding(22, 20, 18, 18);
            pnlLeft.Controls.Add(pnlTips);
            pnlLeft.Controls.Add(lblLeftDesc);
            pnlLeft.Controls.Add(lblLeftTitle);
            pnlLeft.Controls.Add(label1);

            // brand
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 18);
            label1.Text = "♡ SynHeart";

            // Left big title (tăng Height để khỏi xuống dòng bị cắt chữ)
            lblLeftTitle.AutoSize = false;
            lblLeftTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.White;
            lblLeftTitle.Location = new Point(22, 54);
            lblLeftTitle.Size = new Size(260, 60);   // quan trọng: đủ cao để không bị “mất chữ”
            lblLeftTitle.Text = "Lấy lại mật khẩu";
            lblLeftTitle.TextAlign = ContentAlignment.TopLeft;

            // Left desc (tăng Height để không khuất dòng cuối)
            lblLeftDesc.AutoSize = false;
            lblLeftDesc.Font = new Font("Segoe UI", 10.5F);
            lblLeftDesc.ForeColor = Color.FromArgb(245, 245, 245);
            lblLeftDesc.Location = new Point(22, 118);
            lblLeftDesc.Size = new Size(260, 64);
            lblLeftDesc.Text = "Nhập email để nhận mã xác nhận.\r\nNhập mã rồi bấm Xác nhận để tiếp tục.";

            // Tips box (tăng Height để không khuất bullet)
            pnlTips.BackColor = Color.FromArgb(55, 255, 255, 255);
            pnlTips.Location = new Point(22, 198);
            pnlTips.Size = new Size(260, 102);
            pnlTips.Padding = new Padding(14, 10, 12, 10);
            pnlTips.Controls.Add(lblTipsBody);
            pnlTips.Controls.Add(lblTipsTitle);

            lblTipsTitle.AutoSize = true;
            lblTipsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTipsTitle.ForeColor = Color.White;
            lblTipsTitle.Location = new Point(14, 8);
            lblTipsTitle.Text = "Gợi ý nhanh";

            lblTipsBody.AutoSize = false;
            lblTipsBody.Font = new Font("Segoe UI", 9.5F);
            lblTipsBody.ForeColor = Color.White;
            lblTipsBody.Location = new Point(14, 34);
            lblTipsBody.Size = new Size(232, 62);
            lblTipsBody.Text = "• Kiểm tra Spam/Quảng cáo nếu chưa thấy email.\r\n• Mã có thể đến chậm 30–60 giây.";

            // ===== pnlRight =====
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.BackColor = Color.FromArgb(248, 248, 252);
            pnlRight.Padding = new Padding(28, 24, 28, 24);

            // Right title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(20, 23, 38);
            lblTitle.Location = new Point(28, 22);
            lblTitle.Text = "Khôi phục mật khẩu";

            // subtitle
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.FromArgb(90, 95, 120);
            lblSubTitle.Location = new Point(30, 66);
            lblSubTitle.Text = "Thực hiện theo 2 bước để xác minh email.";

            // Email label
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelEmail.ForeColor = Color.FromArgb(20, 23, 38);
            labelEmail.Location = new Point(30, 98);
            labelEmail.Text = "Email";

            // Email box (kéo dài + canh đều)
            pnlEmailBox.BackColor = Color.White;
            pnlEmailBox.Location = new Point(30, 122);
            pnlEmailBox.Size = new Size(360, 40);
            pnlEmailBox.Padding = new Padding(14, 10, 14, 8);

            tb_email.BorderStyle = BorderStyle.None;
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Dock = DockStyle.Fill;
            tb_email.Margin = new Padding(0);
            pnlEmailBox.Controls.Add(tb_email);

            // Code label
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(20, 23, 38);
            label2.Location = new Point(30, 176);
            label2.Text = "Mã xác nhận";

            // Code row: textbox + button (đủ cao để không cắt viền)
            tblCodeRow.Location = new Point(30, 200);
            tblCodeRow.Size = new Size(360, 44);
            tblCodeRow.ColumnCount = 2;
            tblCodeRow.RowCount = 1;
            tblCodeRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCodeRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            tblCodeRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCodeRow.Margin = new Padding(0);
            tblCodeRow.Padding = new Padding(0);

            // Code box
            pnlCodeBox.BackColor = Color.White;
            pnlCodeBox.Dock = DockStyle.Fill;
            pnlCodeBox.Padding = new Padding(14, 10, 14, 8);

            tb_maxacnhan.BorderStyle = BorderStyle.None;
            tb_maxacnhan.Font = new Font("Segoe UI", 11F);
            tb_maxacnhan.Dock = DockStyle.Fill;
            tb_maxacnhan.Margin = new Padding(0);
            pnlCodeBox.Controls.Add(tb_maxacnhan);

            // btn_nhanma
            btn_nhanma.Dock = DockStyle.Fill;
            btn_nhanma.BackColor = Color.FromArgb(73, 140, 255);
            btn_nhanma.FlatAppearance.BorderSize = 0;
            btn_nhanma.FlatStyle = FlatStyle.Flat;
            btn_nhanma.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_nhanma.ForeColor = Color.White;
            btn_nhanma.Margin = new Padding(12, 2, 0, 2);   // quan trọng: chừa dưới để không bị “cắt viền”
            btn_nhanma.Text = "Nhận mã";
            btn_nhanma.UseVisualStyleBackColor = false;
            btn_nhanma.Click += btn_nhanma_Click;

            tblCodeRow.Controls.Add(pnlCodeBox, 0, 0);
            tblCodeRow.Controls.Add(btn_nhanma, 1, 0);

            // btn_xacnhan (tăng Height + chừa dưới)
            btn_xacnhan.BackColor = Color.FromArgb(160, 90, 255);
            btn_xacnhan.FlatAppearance.BorderSize = 0;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(30, 258);
            btn_xacnhan.Size = new Size(360, 46);
            btn_xacnhan.Margin = new Padding(0, 12, 0, 0);
            btn_xacnhan.Text = "Xác nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            btn_xacnhan.Click += btn_xacnhan_Click;

            // back link
            ll_back.AutoSize = true;
            ll_back.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ll_back.LinkColor = Color.FromArgb(73, 140, 255);
            ll_back.ActiveLinkColor = Color.FromArgb(60, 120, 230);
            ll_back.VisitedLinkColor = Color.FromArgb(73, 140, 255);
            ll_back.Location = new Point(30, 312);
            ll_back.Text = "← Quay lại đăng nhập";
            ll_back.LinkClicked += ll_back_LinkClicked;

            // Add right controls
            pnlRight.Controls.Add(ll_back);
            pnlRight.Controls.Add(btn_xacnhan);
            pnlRight.Controls.Add(tblCodeRow);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(pnlEmailBox);
            pnlRight.Controls.Add(labelEmail);
            pnlRight.Controls.Add(lblSubTitle);
            pnlRight.Controls.Add(lblTitle);

            Controls.Add(bgPanel);

            bgPanel.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            tblCard.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlTips.ResumeLayout(false);
            pnlTips.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlEmailBox.ResumeLayout(false);
            pnlEmailBox.PerformLayout();
            tblCodeRow.ResumeLayout(false);
            pnlCodeBox.ResumeLayout(false);
            pnlCodeBox.PerformLayout();
            ResumeLayout(false);
        }
    }
}
