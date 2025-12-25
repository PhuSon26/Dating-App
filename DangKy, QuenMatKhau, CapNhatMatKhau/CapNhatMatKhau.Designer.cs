
using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class CapNhatMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        private Panel bgPanel;

        private Panel pnlCard;
        private TableLayoutPanel tblCard;

        private Panel pnlLeft;
        private Label lblBrand;
        private Label lblLeftTitle;
        private Label lblLeftDesc;
        private Panel pnlTips;
        private Label lblTipsTitle;
        private Label lblTipsBody;

        private Panel pnlRight;
        private Label lblTitle;
        private Label lblSubTitle;

        private Label labelEmail;     // "Mật khẩu mới"
        private Panel pnlPassBox;
        private TextBox tb_email;     // password (giữ tên biến cũ)

        private Label label2;         // "Xác nhận mật khẩu"
        private Panel pnlConfirmBox;
        private TextBox tb_maxacnhan; // confirm (giữ tên biến cũ)

        private RoundedButton btn_xacnhan;
        private LinkLabel linkLabel_back;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            bgPanel = new Panel();
            pnlCard = new Panel();
            tblCard = new TableLayoutPanel();
            pnlLeft = new Panel();
            pnlTips = new Panel();
            lblTipsBody = new Label();
            lblTipsTitle = new Label();
            lblLeftDesc = new Label();
            lblLeftTitle = new Label();
            lblBrand = new Label();
            pnlRight = new Panel();
            linkLabel_back = new LinkLabel();
            btn_xacnhan = new RoundedButton();
            pnlConfirmBox = new Panel();
            tb_maxacnhan = new TextBox();
            label2 = new Label();
            pnlPassBox = new Panel();
            tb_email = new TextBox();
            labelEmail = new Label();
            lblSubTitle = new Label();
            lblTitle = new Label();
            bgPanel.SuspendLayout();
            pnlCard.SuspendLayout();
            tblCard.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlTips.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlConfirmBox.SuspendLayout();
            pnlPassBox.SuspendLayout();
            SuspendLayout();
            // 
            // bgPanel
            // 
            bgPanel.BackColor = Color.FromArgb(245, 242, 255);
            bgPanel.Controls.Add(pnlCard);
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.Location = new Point(0, 0);
            bgPanel.Name = "bgPanel";
            bgPanel.Size = new Size(800, 450);
            bgPanel.TabIndex = 0;
            // 
            // pnlCard
            // 
            pnlCard.Anchor = AnchorStyles.None;
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(tblCard);
            pnlCard.Location = new Point(40, 65);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(720, 320);
            pnlCard.TabIndex = 0;
            // 
            // tblCard
            // 
            tblCard.ColumnCount = 2;
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCard.Controls.Add(pnlLeft, 0, 0);
            tblCard.Controls.Add(pnlRight, 1, 0);
            tblCard.Dock = DockStyle.Fill;
            tblCard.Location = new Point(0, 0);
            tblCard.Margin = new Padding(0);
            tblCard.Name = "tblCard";
            tblCard.RowCount = 1;
            tblCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCard.Size = new Size(720, 320);
            tblCard.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(150, 60, 220);
            pnlLeft.Controls.Add(pnlTips);
            pnlLeft.Controls.Add(lblLeftDesc);
            pnlLeft.Controls.Add(lblLeftTitle);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(3, 3);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(22, 20, 18, 18);
            pnlLeft.Size = new Size(294, 314);
            pnlLeft.TabIndex = 0;
            // 
            // pnlTips
            // 
            pnlTips.BackColor = Color.Transparent;
            pnlTips.Controls.Add(lblTipsBody);
            pnlTips.Controls.Add(lblTipsTitle);
            pnlTips.Location = new Point(22, 200);
            pnlTips.Name = "pnlTips";
            pnlTips.Padding = new Padding(14, 10, 12, 10);
            pnlTips.Size = new Size(260, 102);
            pnlTips.TabIndex = 3;
            // 
            // lblTipsBody
            // 
            lblTipsBody.Font = new Font("Segoe UI", 9.5F);
            lblTipsBody.ForeColor = Color.White;
            lblTipsBody.Location = new Point(14, 34);
            lblTipsBody.Name = "lblTipsBody";
            lblTipsBody.Size = new Size(232, 62);
            lblTipsBody.TabIndex = 1;
            lblTipsBody.Text = "• Nên dùng 8+ ký tự.\r\n• Kết hợp chữ, số và ký tự đặc biệt.";
            // 
            // lblTipsTitle
            // 
            lblTipsTitle.AutoSize = true;
            lblTipsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTipsTitle.ForeColor = Color.White;
            lblTipsTitle.Location = new Point(14, 8);
            lblTipsTitle.Name = "lblTipsTitle";
            lblTipsTitle.Size = new Size(102, 20);
            lblTipsTitle.TabIndex = 0;
            lblTipsTitle.Text = "Mẹo bảo mật";
            // 
            // lblLeftDesc
            // 
            lblLeftDesc.Font = new Font("Segoe UI", 10.5F);
            lblLeftDesc.ForeColor = Color.FromArgb(245, 245, 245);
            lblLeftDesc.Location = new Point(22, 130);
            lblLeftDesc.Name = "lblLeftDesc";
            lblLeftDesc.Size = new Size(260, 64);
            lblLeftDesc.TabIndex = 2;
            lblLeftDesc.Text = "Tạo mật khẩu mới để tiếp tục sử dụng tài khoản.\r\nVui lòng nhập và xác nhận lại.";
            // 
            // lblLeftTitle
            // 
            lblLeftTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.White;
            lblLeftTitle.Location = new Point(22, 54);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(260, 72);
            lblLeftTitle.TabIndex = 1;
            lblLeftTitle.Text = "Cập nhật mật khẩu";
            lblLeftTitle.UseCompatibleTextRendering = true;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(22, 18);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(101, 20);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "♡ SynHeart ♡";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(248, 248, 252);
            pnlRight.Controls.Add(linkLabel_back);
            pnlRight.Controls.Add(btn_xacnhan);
            pnlRight.Controls.Add(pnlConfirmBox);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(pnlPassBox);
            pnlRight.Controls.Add(labelEmail);
            pnlRight.Controls.Add(lblSubTitle);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(303, 3);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(28, 24, 28, 24);
            pnlRight.Size = new Size(414, 314);
            pnlRight.TabIndex = 1;
            // 
            // linkLabel_back
            // 
            linkLabel_back.ActiveLinkColor = Color.FromArgb(60, 120, 230);
            linkLabel_back.AutoSize = true;
            linkLabel_back.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            linkLabel_back.LinkColor = Color.FromArgb(73, 140, 255);
            linkLabel_back.Location = new Point(30, 294);
            linkLabel_back.Name = "linkLabel_back";
            linkLabel_back.Size = new Size(155, 19);
            linkLabel_back.TabIndex = 7;
            linkLabel_back.TabStop = true;
            linkLabel_back.Text = "← Quay lại đăng nhập";
            linkLabel_back.VisitedLinkColor = Color.FromArgb(73, 140, 255);
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.FromArgb(73, 140, 255);
            btn_xacnhan.CornerRadius = 20;
            btn_xacnhan.FlatAppearance.BorderSize = 0;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(30, 244);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(360, 46);
            btn_xacnhan.TabIndex = 6;
            btn_xacnhan.Text = "Cập nhật";
            btn_xacnhan.UseVisualStyleBackColor = false;
            // 
            // pnlConfirmBox
            // 
            pnlConfirmBox.BackColor = Color.White;
            pnlConfirmBox.Controls.Add(tb_maxacnhan);
            pnlConfirmBox.Location = new Point(30, 196);
            pnlConfirmBox.Name = "pnlConfirmBox";
            pnlConfirmBox.Padding = new Padding(14, 10, 14, 8);
            pnlConfirmBox.Size = new Size(360, 40);
            pnlConfirmBox.TabIndex = 5;
            // 
            // tb_maxacnhan
            // 
            tb_maxacnhan.BorderStyle = BorderStyle.None;
            tb_maxacnhan.Dock = DockStyle.Fill;
            tb_maxacnhan.Font = new Font("Segoe UI", 11F);
            tb_maxacnhan.Location = new Point(14, 10);
            tb_maxacnhan.Margin = new Padding(0);
            tb_maxacnhan.Name = "tb_maxacnhan";
            tb_maxacnhan.PasswordChar = '●';
            tb_maxacnhan.Size = new Size(332, 20);
            tb_maxacnhan.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(20, 23, 38);
            label2.Location = new Point(30, 172);
            label2.Name = "label2";
            label2.Size = new Size(135, 19);
            label2.TabIndex = 4;
            label2.Text = "Xác nhận mật khẩu";
            // 
            // pnlPassBox
            // 
            pnlPassBox.BackColor = Color.White;
            pnlPassBox.Controls.Add(tb_email);
            pnlPassBox.Location = new Point(30, 124);
            pnlPassBox.Name = "pnlPassBox";
            pnlPassBox.Padding = new Padding(14, 10, 14, 8);
            pnlPassBox.Size = new Size(360, 40);
            pnlPassBox.TabIndex = 3;
            // 
            // tb_email
            // 
            tb_email.BorderStyle = BorderStyle.None;
            tb_email.Dock = DockStyle.Fill;
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(14, 10);
            tb_email.Margin = new Padding(0);
            tb_email.Name = "tb_email";
            tb_email.PasswordChar = '●';
            tb_email.Size = new Size(332, 20);
            tb_email.TabIndex = 0;
            tb_email.TextChanged += tb_email_TextChanged;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelEmail.ForeColor = Color.FromArgb(20, 23, 38);
            labelEmail.Location = new Point(30, 100);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(101, 19);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Mật khẩu mới";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.FromArgb(90, 95, 120);
            lblSubTitle.Location = new Point(30, 70);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(261, 19);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Nhập mật khẩu mới và xác nhận lại 1 lần.";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(20, 23, 38);
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 0, 0, 8);
            lblTitle.Size = new Size(380, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cập nhật mật khẩu";
            lblTitle.UseCompatibleTextRendering = true;
            // 
            // CapNhatMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 242, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(bgPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CapNhatMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            bgPanel.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            tblCard.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlTips.ResumeLayout(false);
            pnlTips.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlConfirmBox.ResumeLayout(false);
            pnlConfirmBox.PerformLayout();
            pnlPassBox.ResumeLayout(false);
            pnlPassBox.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
    }
}
