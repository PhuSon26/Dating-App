using System.Drawing;
using System.Windows.Forms;

namespace Dating_app_nhom3
{
    partial class quenmatkhau  : Form
    {
        private Label lblTitle;
        private Label labelEmail;
        private TextBox tb_email;
        private Button btn_xacnhan;
        private LinkLabel linkLabel_back;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            labelEmail = new Label();
            tb_email = new TextBox();
            btn_xacnhan = new Button();
            linkLabel_back = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            tb_maxacnhan = new TextBox();
            btn_nhanma = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 80, 100);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(657, 138);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔒 Quên Mật Khẩu";
            lblTitle.TextAlign = ContentAlignment.BottomCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI", 11F);
            labelEmail.ForeColor = Color.FromArgb(70, 70, 70);
            labelEmail.Location = new Point(91, 182);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 23);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(228, 182);
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
            btn_xacnhan.Location = new Point(248, 323);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(160, 40);
            btn_xacnhan.TabIndex = 3;
            btn_xacnhan.Text = "Xác Nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            btn_xacnhan.Click += btn_xacnhan_Click;
            // 
            // linkLabel_back
            // 
            linkLabel_back.Font = new Font("Segoe UI", 10F);
            linkLabel_back.LinkColor = Color.FromArgb(0, 102, 204);
            linkLabel_back.Location = new Point(457, 384);
            linkLabel_back.Name = "linkLabel_back";
            linkLabel_back.Size = new Size(200, 38);
            linkLabel_back.TabIndex = 4;
            linkLabel_back.TabStop = true;
            linkLabel_back.Text = "← Quay lại đăng nhập";
            linkLabel_back.LinkClicked += linkLabel_back_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(255, 80, 100);
            label1.Location = new Point(1, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 38);
            label1.TabIndex = 5;
            label1.Text = "💖 SynHeart 💖";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            label2.Location = new Point(91, 241);
            label2.Name = "label2";
            label2.Size = new Size(131, 23);
            label2.TabIndex = 6;
            label2.Text = "Mã Xác Nhận";
            // 
            // tb_maxacnhan
            // 
            tb_maxacnhan.Font = new Font("Segoe UI", 11F);
            tb_maxacnhan.Location = new Point(228, 238);
            tb_maxacnhan.Name = "tb_maxacnhan";
            tb_maxacnhan.Size = new Size(119, 32);
            tb_maxacnhan.TabIndex = 7;
            // 
            // btn_nhanma
            // 
            btn_nhanma.BackColor = SystemColors.GradientActiveCaption;
            btn_nhanma.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_nhanma.Location = new Point(383, 241);
            btn_nhanma.Name = "btn_nhanma";
            btn_nhanma.Size = new Size(129, 29);
            btn_nhanma.TabIndex = 8;
            btn_nhanma.Text = "Nhận Mã Xác Nhận";
            btn_nhanma.UseVisualStyleBackColor = false;
            // 
            // quenmatkhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(657, 422);
            Controls.Add(btn_nhanma);
            Controls.Add(tb_maxacnhan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(labelEmail);
            Controls.Add(tb_email);
            Controls.Add(btn_xacnhan);
            Controls.Add(linkLabel_back);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "quenmatkhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu - SynHeart";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private TextBox tb_maxacnhan;
        private Button btn_nhanma;
    }
}
