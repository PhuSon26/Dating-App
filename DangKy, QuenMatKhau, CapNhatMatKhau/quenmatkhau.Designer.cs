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
            pnlTips = new Panel();
            lblTipsBody = new Label();
            lblTipsTitle = new Label();
            lblLeftDesc = new Label();
            lblLeftTitle = new Label();
            label1 = new Label();
            pnlRight = new Panel();
            ll_back = new LinkLabel();
            btn_xacnhan = new RoundedButton();
            tblCodeRow = new TableLayoutPanel();
            pnlCodeBox = new Panel();
            tb_maxacnhan = new TextBox();
            btn_nhanma = new RoundedButton();
            label2 = new Label();
            pnlEmailBox = new Panel();
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
            tblCodeRow.SuspendLayout();
            pnlCodeBox.SuspendLayout();
            pnlEmailBox.SuspendLayout();
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
            pnlLeft.Controls.Add(label1);
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
            lblTipsBody.Text = "• Kiểm tra Spam/Quảng cáo nếu chưa thấy email.\r\n• Mã có thể đến chậm 30–60 giây.";
            // 
            // lblTipsTitle
            // 
            lblTipsTitle.AutoSize = true;
            lblTipsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTipsTitle.ForeColor = Color.White;
            lblTipsTitle.Location = new Point(14, 8);
            lblTipsTitle.Name = "lblTipsTitle";
            lblTipsTitle.Size = new Size(93, 20);
            lblTipsTitle.TabIndex = 0;
            lblTipsTitle.Text = "Gợi ý nhanh";
            // 
            // lblLeftDesc
            // 
            lblLeftDesc.Font = new Font("Segoe UI", 10.5F);
            lblLeftDesc.ForeColor = Color.FromArgb(245, 245, 245);
            lblLeftDesc.Location = new Point(22, 130);
            lblLeftDesc.Name = "lblLeftDesc";
            lblLeftDesc.Size = new Size(260, 64);
            lblLeftDesc.TabIndex = 2;
            lblLeftDesc.Text = "Nhập email để nhận mã xác nhận.\r\nNhập mã rồi bấm Xác nhận để tiếp tục.";
            // 
            // lblLeftTitle
            // 
            lblLeftTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.White;
            lblLeftTitle.Location = new Point(22, 54);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(260, 72);
            lblLeftTitle.TabIndex = 1;
            lblLeftTitle.Text = "Lấy lại mật khẩu";
            lblLeftTitle.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 18);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "♡ SynHeart ♡";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(248, 248, 252);
            pnlRight.Controls.Add(ll_back);
            pnlRight.Controls.Add(btn_xacnhan);
            pnlRight.Controls.Add(tblCodeRow);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(pnlEmailBox);
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
            // ll_back
            // 
            ll_back.ActiveLinkColor = Color.FromArgb(60, 120, 230);
            ll_back.AutoSize = true;
            ll_back.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ll_back.LinkColor = Color.FromArgb(73, 140, 255);
            ll_back.Location = new Point(30, 294);
            ll_back.Name = "ll_back";
            ll_back.Size = new Size(155, 19);
            ll_back.TabIndex = 7;
            ll_back.TabStop = true;
            ll_back.Text = "← Quay lại đăng nhập";
            ll_back.VisitedLinkColor = Color.FromArgb(73, 140, 255);
            ll_back.LinkClicked += ll_back_LinkClicked;
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.FromArgb(160, 90, 255);
            btn_xacnhan.CornerRadius = 20;
            btn_xacnhan.FlatAppearance.BorderSize = 0;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(30, 244);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(360, 46);
            btn_xacnhan.TabIndex = 6;
            btn_xacnhan.Text = "Xác nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            btn_xacnhan.Click += btn_xacnhan_Click;
            // 
            // tblCodeRow
            // 
            tblCodeRow.ColumnCount = 2;
            tblCodeRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCodeRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            tblCodeRow.Controls.Add(pnlCodeBox, 0, 0);
            tblCodeRow.Controls.Add(btn_nhanma, 1, 0);
            tblCodeRow.Location = new Point(30, 196);
            tblCodeRow.Margin = new Padding(0);
            tblCodeRow.Name = "tblCodeRow";
            tblCodeRow.RowCount = 1;
            tblCodeRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCodeRow.Size = new Size(360, 44);
            tblCodeRow.TabIndex = 5;
            // 
            // pnlCodeBox
            // 
            pnlCodeBox.BackColor = Color.White;
            pnlCodeBox.Controls.Add(tb_maxacnhan);
            pnlCodeBox.Dock = DockStyle.Fill;
            pnlCodeBox.Location = new Point(3, 3);
            pnlCodeBox.Name = "pnlCodeBox";
            pnlCodeBox.Padding = new Padding(14, 10, 14, 8);
            pnlCodeBox.Size = new Size(236, 38);
            pnlCodeBox.TabIndex = 0;
            // 
            // tb_maxacnhan
            // 
            tb_maxacnhan.BorderStyle = BorderStyle.None;
            tb_maxacnhan.Dock = DockStyle.Fill;
            tb_maxacnhan.Font = new Font("Segoe UI", 11F);
            tb_maxacnhan.Location = new Point(14, 10);
            tb_maxacnhan.Margin = new Padding(0);
            tb_maxacnhan.Name = "tb_maxacnhan";
            tb_maxacnhan.Size = new Size(208, 20);
            tb_maxacnhan.TabIndex = 0;
            // 
            // btn_nhanma
            // 
            btn_nhanma.BackColor = Color.FromArgb(73, 140, 255);
            btn_nhanma.CornerRadius = 20;
            btn_nhanma.Dock = DockStyle.Fill;
            btn_nhanma.FlatAppearance.BorderSize = 0;
            btn_nhanma.FlatStyle = FlatStyle.Flat;
            btn_nhanma.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_nhanma.ForeColor = Color.White;
            btn_nhanma.Location = new Point(254, 2);
            btn_nhanma.Margin = new Padding(12, 2, 0, 2);
            btn_nhanma.Name = "btn_nhanma";
            btn_nhanma.Size = new Size(106, 40);
            btn_nhanma.TabIndex = 1;
            btn_nhanma.Text = "Nhận mã";
            btn_nhanma.UseVisualStyleBackColor = false;
            btn_nhanma.Click += btn_nhanma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(20, 23, 38);
            label2.Location = new Point(30, 172);
            label2.Name = "label2";
            label2.Size = new Size(93, 19);
            label2.TabIndex = 4;
            label2.Text = "Mã xác nhận";
            // 
            // pnlEmailBox
            // 
            pnlEmailBox.BackColor = Color.White;
            pnlEmailBox.Controls.Add(tb_email);
            pnlEmailBox.Location = new Point(30, 124);
            pnlEmailBox.Name = "pnlEmailBox";
            pnlEmailBox.Padding = new Padding(14, 10, 14, 8);
            pnlEmailBox.Size = new Size(360, 40);
            pnlEmailBox.TabIndex = 3;
            // 
            // tb_email
            // 
            tb_email.BorderStyle = BorderStyle.None;
            tb_email.Dock = DockStyle.Fill;
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(14, 10);
            tb_email.Margin = new Padding(0);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(332, 20);
            tb_email.TabIndex = 0;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelEmail.ForeColor = Color.FromArgb(20, 23, 38);
            labelEmail.Location = new Point(30, 100);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(45, 19);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Email";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.FromArgb(90, 95, 120);
            lblSubTitle.Location = new Point(30, 70);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(262, 19);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Thực hiện theo 2 bước để xác minh email.";
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
            lblTitle.Text = "Khôi phục mật khẩu";
            lblTitle.UseCompatibleTextRendering = true;
            // 
            // FormQuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 242, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(bgPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormQuenMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += FormQuenMatKhau_Load;
            bgPanel.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            tblCard.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlTips.ResumeLayout(false);
            pnlTips.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            tblCodeRow.ResumeLayout(false);
            pnlCodeBox.ResumeLayout(false);
            pnlCodeBox.PerformLayout();
            pnlEmailBox.ResumeLayout(false);
            pnlEmailBox.PerformLayout();
            ResumeLayout(false);
        }
    }
}
