using System;
using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class FormDangKy
    {
        private System.ComponentModel.IContainer components = null;

        // Background (gradient)
        private Panel pnlBackground;

        // Root (center card)
        private TableLayoutPanel tblRoot;

        // Card layout (same format as FormDangNhap)
        private Panel pnlCard;
        private TableLayoutPanel tblCard;
        private Panel pnlLeft;
        private Panel pnlRight;

        // Left
        private Label lblBrand;
        private Label lblLeftTitle;
        private Label lblLeftDesc;

        // Right
        private Label lblTitle;

        private Label label1;          // Email
        private TextBox tb_email;
        private Panel lineEmail;

        private Label label2;          // Mật khẩu
        private TextBox tb_password;
        private Panel linePassword;

        private Label label4;          // Xác nhận mật khẩu
        private TextBox tb_rePassword;
        private Panel lineRePassword;

        private RoundedGlossyButton btn_dangky;
        private LinkLabel ll_back;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlBackground = new Panel();
            tblRoot = new TableLayoutPanel();

            pnlCard = new Panel();
            tblCard = new TableLayoutPanel();
            pnlLeft = new Panel();
            pnlRight = new Panel();

            lblBrand = new Label();
            lblLeftTitle = new Label();
            lblLeftDesc = new Label();

            lblTitle = new Label();

            label1 = new Label();
            tb_email = new TextBox();
            lineEmail = new Panel();

            label2 = new Label();
            tb_password = new TextBox();
            linePassword = new Panel();

            label4 = new Label();
            tb_rePassword = new TextBox();
            lineRePassword = new Panel();

            btn_dangky = new RoundedGlossyButton();
            ll_back = new LinkLabel();

            pnlBackground.SuspendLayout();
            tblRoot.SuspendLayout();
            pnlCard.SuspendLayout();
            tblCard.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();

            // ========= THEME (Lavender Sunset - same as login) =========
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
            // pnlBackground (gradient)
            // 
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.BackColor = Color.FromArgb(245, 240, 250);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Paint += pnlBackground_Paint;
            pnlBackground.Controls.Add(tblRoot);

            // 
            // tblRoot (center card)
            // 
            tblRoot.ColumnCount = 3;
            tblRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRoot.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tblRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRoot.RowCount = 3;
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoot.Dock = DockStyle.Fill;
            tblRoot.BackColor = Color.Transparent;
            tblRoot.Controls.Add(pnlCard, 1, 1);
            tblRoot.Name = "tblRoot";

            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.FromArgb(240, 232, 249);
            pnlCard.Controls.Add(tblCard);
            pnlCard.Margin = new Padding(0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(831, 365);

            // 
            // tblCard
            // 
            tblCard.ColumnCount = 2;
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCard.RowCount = 1;
            tblCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCard.Dock = DockStyle.Fill;
            tblCard.Controls.Add(pnlLeft, 0, 0);
            tblCard.Controls.Add(pnlRight, 1, 0);
            tblCard.Name = "tblCard";

            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(231, 216, 245);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Padding = new Padding(24, 21, 24, 21);
            pnlLeft.Controls.Add(lblLeftDesc);
            pnlLeft.Controls.Add(lblLeftTitle);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Name = "pnlLeft";

            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.FromArgb(213, 63, 140);
            lblBrand.Location = new Point(24, 21);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(211, 37);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "💘SynHeart💘";

            // 
            // lblLeftTitle
            // 
            lblLeftTitle.AutoSize = true;
            lblLeftTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.FromArgb(59, 7, 100);
            lblLeftTitle.Location = new Point(24, 90);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(207, 32);
            lblLeftTitle.TabIndex = 1;
            lblLeftTitle.Text = "Tạo tài khoản mới";

            // 
            // lblLeftDesc
            // 
            lblLeftDesc.Font = new Font("Segoe UI", 10F);
            lblLeftDesc.ForeColor = Color.FromArgb(107, 33, 168);
            lblLeftDesc.Location = new Point(27, 161);
            lblLeftDesc.Name = "lblLeftDesc";
            lblLeftDesc.Size = new Size(341, 135);
            lblLeftDesc.TabIndex = 2;
            lblLeftDesc.Text = "Nhập email và mật khẩu để đăng ký.\r\nSau đó bạn có thể đăng nhập ngay.";

            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(247, 236, 247);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Padding = new Padding(32, 27, 32, 27);
            pnlRight.Controls.Add(lblTitle);

            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(tb_email);
            pnlRight.Controls.Add(lineEmail);

            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(tb_password);
            pnlRight.Controls.Add(linePassword);

            pnlRight.Controls.Add(label4);
            pnlRight.Controls.Add(tb_rePassword);
            pnlRight.Controls.Add(lineRePassword);

            pnlRight.Controls.Add(btn_dangky);
            pnlRight.Controls.Add(ll_back);

            pnlRight.Name = "pnlRight";

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(59, 7, 100);
            lblTitle.Location = new Point(32, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(104, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng ký";

            // 
            // label1 (Email)
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F);
            label1.ForeColor = Color.FromArgb(107, 33, 168);
            label1.Location = new Point(33, 80);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 1;
            label1.Text = "Email";

            // 
            // tb_email
            // 
            tb_email.BackColor = Color.White;
            tb_email.BorderStyle = BorderStyle.None;
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.ForeColor = Color.FromArgb(59, 7, 100);
            tb_email.Location = new Point(37, 102);
            tb_email.Margin = new Padding(3, 2, 3, 2);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(315, 20);
            tb_email.TabIndex = 2;

            // 
            // lineEmail
            // 
            lineEmail.BackColor = Color.FromArgb(192, 132, 252);
            lineEmail.Location = new Point(37, 126);
            lineEmail.Margin = new Padding(3, 2, 3, 2);
            lineEmail.Name = "lineEmail";
            lineEmail.Size = new Size(315, 1);
            lineEmail.TabIndex = 3;

            // 
            // label2 (Mật khẩu)
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.5F);
            label2.ForeColor = Color.FromArgb(107, 33, 168);
            label2.Location = new Point(33, 140);
            label2.Name = "label2";
            label2.Size = new Size(62, 17);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu";

            // 
            // tb_password
            // 
            tb_password.BackColor = Color.White;
            tb_password.BorderStyle = BorderStyle.None;
            tb_password.Font = new Font("Segoe UI", 11F);
            tb_password.ForeColor = Color.FromArgb(59, 7, 100);
            tb_password.Location = new Point(37, 162);
            tb_password.Margin = new Padding(3, 2, 3, 2);
            tb_password.Name = "tb_password";
            tb_password.Size = new Size(315, 20);
            tb_password.TabIndex = 5;
            tb_password.UseSystemPasswordChar = true;

            // 
            // linePassword
            // 
            linePassword.BackColor = Color.FromArgb(192, 132, 252);
            linePassword.Location = new Point(37, 186);
            linePassword.Margin = new Padding(3, 2, 3, 2);
            linePassword.Name = "linePassword";
            linePassword.Size = new Size(315, 1);
            linePassword.TabIndex = 6;

            // 
            // label4 (Xác nhận mật khẩu)
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.ForeColor = Color.FromArgb(107, 33, 168);
            label4.Location = new Point(33, 200);
            label4.Name = "label4";
            label4.Size = new Size(116, 17);
            label4.TabIndex = 7;
            label4.Text = "Xác nhận mật khẩu";

            // 
            // tb_rePassword
            // 
            tb_rePassword.BackColor = Color.White;
            tb_rePassword.BorderStyle = BorderStyle.None;
            tb_rePassword.Font = new Font("Segoe UI", 11F);
            tb_rePassword.ForeColor = Color.FromArgb(59, 7, 100);
            tb_rePassword.Location = new Point(37, 222);
            tb_rePassword.Margin = new Padding(3, 2, 3, 2);
            tb_rePassword.Name = "tb_rePassword";
            tb_rePassword.Size = new Size(315, 20);
            tb_rePassword.TabIndex = 8;
            tb_rePassword.UseSystemPasswordChar = true;

            // 
            // lineRePassword
            // 
            lineRePassword.BackColor = Color.FromArgb(192, 132, 252);
            lineRePassword.Location = new Point(37, 246);
            lineRePassword.Margin = new Padding(3, 2, 3, 2);
            lineRePassword.Name = "lineRePassword";
            lineRePassword.Size = new Size(315, 1);
            lineRePassword.TabIndex = 9;

            // 
            // btn_dangky
            // 
            btn_dangky.BackColor = Color.FromArgb(213, 63, 140);
            btn_dangky.FlatAppearance.BorderSize = 0;
            btn_dangky.FlatStyle = FlatStyle.Flat;
            btn_dangky.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_dangky.ForeColor = Color.White;
            btn_dangky.Location = new Point(37, 265);
            btn_dangky.Margin = new Padding(3, 2, 3, 2);
            btn_dangky.Name = "btn_dangky";
            btn_dangky.Size = new Size(315, 36);
            btn_dangky.TabIndex = 10;
            btn_dangky.Text = "Đăng ký";
            btn_dangky.UseVisualStyleBackColor = false;
            btn_dangky.Click += btn_dangky_Click;

            // 
            // ll_back
            // 
            ll_back.ActiveLinkColor = Color.FromArgb(184, 50, 128);
            ll_back.AutoSize = true;
            ll_back.Font = new Font("Segoe UI", 9F);
            ll_back.LinkColor = Color.FromArgb(147, 51, 234);
            ll_back.VisitedLinkColor = Color.FromArgb(107, 33, 168);
            ll_back.Location = new Point(37, 312);
            ll_back.Name = "ll_back";
            ll_back.Size = new Size(155, 15);
            ll_back.TabIndex = 11;
            ll_back.TabStop = true;
            ll_back.Text = "Đã có tài khoản? Đăng nhập";
            ll_back.LinkClicked += ll_back_LinkClicked;

            // 
            // FormDangKy
            // 
            AcceptButton = btn_dangky;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 250);
            ClientSize = new Size(962, 488);
            Controls.Add(pnlBackground);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Ký - SynHeart";
            Load += dangky_Load;

            pnlBackground.ResumeLayout(false);
            tblRoot.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            tblCard.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        // Gradient nền nhẹ (không dùng ảnh, không nặng)
        private void pnlBackground_Paint(object sender, PaintEventArgs e)
        {
            var rect = pnlBackground.ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            // Top: #FFF1F2 (255,241,242)  -> Bottom: #EDE9FE (237,233,254)
            using var br = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect,
                Color.FromArgb(255, 255, 241, 242),
                Color.FromArgb(255, 237, 233, 254),
                90f
            );
            e.Graphics.FillRectangle(br, rect);
        }

        #endregion
    }
}
