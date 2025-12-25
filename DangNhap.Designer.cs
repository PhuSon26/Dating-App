using System;
using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        private DoubleBufferedPanel panel;

        private Panel pnlCard;
        private TableLayoutPanel tblCard;
        private Panel pnlLeft;
        private Panel pnlRight;

        private Label lblBrand;
        private Label lblLeftTitle;
        private Label lblLeftDesc;

        private Label lblTitle;
        private Label lblEmail;
        private TextBox tb_email;
        private Panel lineEmail;

        private Label lblPassword;
        private TextBox tb_matkhau;
        private Panel linePassword;

        private LinkLabel ll_quenmatkhau;
        private RoundedGlossyButton btn_dangnhap;
        private LinkLabel ll_dangky;

        private Panel pnlFooter;
        private Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel = new DoubleBufferedPanel();
            pnlCard = new Panel();
            tblCard = new TableLayoutPanel();
            pnlLeft = new Panel();
            lblLeftDesc = new Label();
            lblLeftTitle = new Label();
            lblBrand = new Label();
            pnlRight = new Panel();
            lblTitle = new Label();
            lblEmail = new Label();
            tb_email = new TextBox();
            lineEmail = new Panel();
            lblPassword = new Label();
            tb_matkhau = new TextBox();
            linePassword = new Panel();
            ll_quenmatkhau = new LinkLabel();
            btn_dangnhap = new RoundedGlossyButton();
            ll_dangky = new LinkLabel();
            pnlFooter = new Panel();
            lblFooter = new Label();

            panel.SuspendLayout();
            pnlCard.SuspendLayout();
            tblCard.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();

            // ========= THEME (Lavender Sunset) =========
            // Card:    #F0E8F9 (240,232,249)
            // Left:    #E7D8F5 (231,216,245)
            // Right:   #F7ECF7 (247,236,247)
            // Accent:  #D53F8C (213,63,140)
            // Text:    #3B0764 (59,7,100)
            // TextSub: #6B21A8 (107,33,168)
            // Line:    #C084FC (192,132,252)
            // Link:    #9333EA (147,51,234)
            // LinkAct: #B83280 (184,50,128)

            // 
            // panel (background image)
            // 
            panel.BackColor = Color.White;
            panel.BackgroundImage = Properties.Resource._1d30fd11dcb3000984acf40b7a8eff57;
            panel.BackgroundImageLayout = ImageLayout.Stretch;
            panel.Controls.Add(pnlCard);
            panel.Controls.Add(pnlFooter);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(962, 488);
            panel.TabIndex = 0;

            // 
            // pnlFooter (opaque)
            // 
            pnlFooter.BackColor = Color.FromArgb(231, 216, 245);
            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 458);
            pnlFooter.Margin = new Padding(3, 2, 3, 2);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(962, 30);
            pnlFooter.TabIndex = 2;

            // 
            // lblFooter
            // 
            lblFooter.Dock = DockStyle.Fill;
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = Color.FromArgb(107, 33, 168);
            lblFooter.Location = new Point(0, 0);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(962, 30);
            lblFooter.TabIndex = 0;
            lblFooter.Text = "Copyright © SynHeart";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlCard (opaque)
            // 
            pnlCard.BackColor = Color.FromArgb(240, 232, 249);
            pnlCard.Controls.Add(tblCard);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Margin = new Padding(3, 2, 3, 2);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(831, 365);
            pnlCard.TabIndex = 1;

            // 
            // tblCard
            // 
            tblCard.ColumnCount = 2;
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCard.Controls.Add(pnlLeft, 0, 0);
            tblCard.Controls.Add(pnlRight, 1, 0);
            tblCard.Dock = DockStyle.Fill;
            tblCard.Location = new Point(0, 0);
            tblCard.Margin = new Padding(3, 2, 3, 2);
            tblCard.Name = "tblCard";
            tblCard.RowCount = 1;
            tblCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCard.Size = new Size(831, 365);
            tblCard.TabIndex = 0;

            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(231, 216, 245);
            pnlLeft.Controls.Add(lblLeftDesc);
            pnlLeft.Controls.Add(lblLeftTitle);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(3, 2);
            pnlLeft.Margin = new Padding(3, 2, 3, 2);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(24, 21, 24, 21);
            pnlLeft.Size = new Size(409, 361);
            pnlLeft.TabIndex = 0;

            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.FromArgb(213, 63, 140);
            lblBrand.Location = new Point(24, 21);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(211, 37);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "💘SynHeart💘";

            // 
            // lblLeftTitle
            // 
            lblLeftTitle.AutoSize = true;
            lblLeftTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.FromArgb(59, 7, 100);
            lblLeftTitle.Location = new Point(24, 90);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(209, 32);
            lblLeftTitle.TabIndex = 1;
            lblLeftTitle.Text = "Kết nối tài khoản";

            // 
            // lblLeftDesc
            // 
            lblLeftDesc.Font = new Font("Segoe UI", 10F);
            lblLeftDesc.ForeColor = Color.FromArgb(107, 33, 168);
            lblLeftDesc.Location = new Point(27, 161);
            lblLeftDesc.Name = "lblLeftDesc";
            lblLeftDesc.Size = new Size(341, 135);
            lblLeftDesc.TabIndex = 0;
            lblLeftDesc.Text = "Đăng nhập để tiếp tục.\r\n\r\n";

            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(247, 236, 247);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Controls.Add(lblEmail);
            pnlRight.Controls.Add(tb_email);
            pnlRight.Controls.Add(lineEmail);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(tb_matkhau);
            pnlRight.Controls.Add(linePassword);
            pnlRight.Controls.Add(ll_quenmatkhau);
            pnlRight.Controls.Add(btn_dangnhap);
            pnlRight.Controls.Add(ll_dangky);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(418, 2);
            pnlRight.Margin = new Padding(3, 2, 3, 2);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(32, 27, 32, 27);
            pnlRight.Size = new Size(410, 361);
            pnlRight.TabIndex = 1;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(59, 7, 100);
            lblTitle.Location = new Point(32, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(139, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng nhập";

            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = Color.FromArgb(107, 33, 168);
            lblEmail.Location = new Point(33, 90);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 17);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";

            // 
            // tb_email
            // 
            tb_email.BackColor = Color.White;
            tb_email.BorderStyle = BorderStyle.None;
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.ForeColor = Color.FromArgb(59, 7, 100);
            tb_email.Location = new Point(37, 112);
            tb_email.Margin = new Padding(3, 2, 3, 2);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(315, 20);
            tb_email.TabIndex = 0;

            // 
            // lineEmail
            // 
            lineEmail.BackColor = Color.FromArgb(192, 132, 252);
            lineEmail.Location = new Point(37, 136);
            lineEmail.Margin = new Padding(3, 2, 3, 2);
            lineEmail.Name = "lineEmail";
            lineEmail.Size = new Size(315, 1);
            lineEmail.TabIndex = 2;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F);
            lblPassword.ForeColor = Color.FromArgb(107, 33, 168);
            lblPassword.Location = new Point(33, 161);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(62, 17);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu";

            // 
            // tb_matkhau
            // 
            tb_matkhau.BackColor = Color.White;
            tb_matkhau.BorderStyle = BorderStyle.None;
            tb_matkhau.Font = new Font("Segoe UI", 11F);
            tb_matkhau.ForeColor = Color.FromArgb(59, 7, 100);
            tb_matkhau.Location = new Point(37, 184);
            tb_matkhau.Margin = new Padding(3, 2, 3, 2);
            tb_matkhau.Name = "tb_matkhau";
            tb_matkhau.Size = new Size(315, 20);
            tb_matkhau.TabIndex = 1;
            tb_matkhau.UseSystemPasswordChar = true;
            tb_matkhau.TextChanged += tb_matkhau_TextChanged;

            // 
            // linePassword
            // 
            linePassword.BackColor = Color.FromArgb(192, 132, 252);
            linePassword.Location = new Point(37, 208);
            linePassword.Margin = new Padding(3, 2, 3, 2);
            linePassword.Name = "linePassword";
            linePassword.Size = new Size(315, 1);
            linePassword.TabIndex = 4;

            // 
            // ll_quenmatkhau
            // 
            ll_quenmatkhau.ActiveLinkColor = Color.FromArgb(184, 50, 128);
            ll_quenmatkhau.AutoSize = true;
            ll_quenmatkhau.Font = new Font("Segoe UI", 9F);
            ll_quenmatkhau.LinkColor = Color.FromArgb(147, 51, 234);
            ll_quenmatkhau.VisitedLinkColor = Color.FromArgb(107, 33, 168);
            ll_quenmatkhau.Location = new Point(270, 221);
            ll_quenmatkhau.Name = "ll_quenmatkhau";
            ll_quenmatkhau.Size = new Size(89, 15);
            ll_quenmatkhau.TabIndex = 2;
            ll_quenmatkhau.TabStop = true;
            ll_quenmatkhau.Text = "Quên mật khẩu";
            ll_quenmatkhau.LinkClicked += ll_quenmatkhau_LinkClicked;

            // 
            // btn_dangnhap
            // 
            btn_dangnhap.BackColor = Color.FromArgb(213, 63, 140);
            btn_dangnhap.FlatAppearance.BorderSize = 0;
            btn_dangnhap.FlatStyle = FlatStyle.Flat;
            btn_dangnhap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_dangnhap.ForeColor = Color.White;
            btn_dangnhap.Location = new Point(37, 255);
            btn_dangnhap.Margin = new Padding(3, 2, 3, 2);
            btn_dangnhap.Name = "btn_dangnhap";
            btn_dangnhap.Size = new Size(315, 33);
            btn_dangnhap.TabIndex = 3;
            btn_dangnhap.Text = "Đăng nhập";
            btn_dangnhap.UseVisualStyleBackColor = false;
            btn_dangnhap.Click += btn_dangnhap_Click;

            // 
            // ll_dangky
            // 
            ll_dangky.ActiveLinkColor = Color.FromArgb(184, 50, 128);
            ll_dangky.AutoSize = true;
            ll_dangky.Font = new Font("Segoe UI", 9F);
            ll_dangky.LinkColor = Color.FromArgb(147, 51, 234);
            ll_dangky.VisitedLinkColor = Color.FromArgb(107, 33, 168);
            ll_dangky.Location = new Point(37, 304);
            ll_dangky.Name = "ll_dangky";
            ll_dangky.Size = new Size(183, 15);
            ll_dangky.TabIndex = 4;
            ll_dangky.TabStop = true;
            ll_dangky.Text = "Chưa có tài khoản? Đăng ký ngay";
            ll_dangky.LinkClicked += ll_dangky_LinkClicked;

            // 
            // FormDangNhap
            // 
            AcceptButton = btn_dangnhap;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 488);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += FormDangNhap_Load;

            panel.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            tblCard.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
