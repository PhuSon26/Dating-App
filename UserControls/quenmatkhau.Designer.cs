using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class FormQuenMatKhau : Form
    {
        private Label labelEmail;
        private TextBox tb_email;
        private Button btn_xacnhan;
        private LinkLabel ll_back;

        private void InitializeComponent()
        {
            labelEmail = new Label();
            tb_email = new TextBox();
            btn_xacnhan = new Button();
            ll_back = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            tb_maxacnhan = new TextBox();
            btn_nhanma = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmail.ForeColor = Color.FromArgb(70, 70, 70);
            labelEmail.Location = new Point(173, 182);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(67, 32);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(330, 182);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(220, 32);
            tb_email.TabIndex = 2;
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.FromArgb(255, 111, 145);
            btn_xacnhan.FlatAppearance.BorderSize = 0;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(173, 304);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(377, 59);
            btn_xacnhan.TabIndex = 3;
            btn_xacnhan.Text = "Xác Nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            btn_xacnhan.Click += btn_xacnhan_Click;
            // 
            // ll_back
            // 
            ll_back.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ll_back.LinkColor = Color.FromArgb(0, 102, 204);
            ll_back.Location = new Point(521, 378);
            ll_back.Name = "ll_back";
            ll_back.Size = new Size(220, 38);
            ll_back.TabIndex = 4;
            ll_back.TabStop = true;
            ll_back.Text = "← Quay lại đăng nhập";
            ll_back.LinkClicked += ll_back_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(255, 80, 100);
            label1.Location = new Point(263, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 50);
            label1.TabIndex = 5;
            label1.Text = "💖 SynHeart 💖";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            label2.Location = new Point(173, 238);
            label2.Name = "label2";
            label2.Size = new Size(142, 39);
            label2.TabIndex = 6;
            label2.Text = "Mã Xác Nhận";
            // 
            // tb_maxacnhan
            // 
            tb_maxacnhan.Font = new Font("Segoe UI", 11F);
            tb_maxacnhan.Location = new Point(330, 238);
            tb_maxacnhan.Name = "tb_maxacnhan";
            tb_maxacnhan.Size = new Size(220, 32);
            tb_maxacnhan.TabIndex = 7;
            // 
            // btn_nhanma
            // 
            btn_nhanma.BackColor = SystemColors.GradientActiveCaption;
            btn_nhanma.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_nhanma.Location = new Point(575, 304);
            btn_nhanma.Name = "btn_nhanma";
            btn_nhanma.Size = new Size(166, 59);
            btn_nhanma.TabIndex = 8;
            btn_nhanma.Text = "Nhận Mã Xác Nhận";
            btn_nhanma.UseVisualStyleBackColor = false;
            btn_nhanma.Click += btn_nhanma_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 80, 100);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 133);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔒 Quên Mật Khẩu";
            lblTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // FormQuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(800, 450);
            Controls.Add(btn_nhanma);
            Controls.Add(tb_maxacnhan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(labelEmail);
            Controls.Add(tb_email);
            Controls.Add(btn_xacnhan);
            Controls.Add(ll_back);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormQuenMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu - SynHeart";
            Load += quenmatkhau_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private TextBox tb_maxacnhan;
        private Button btn_nhanma;
        private Label lblTitle;
    }
}
