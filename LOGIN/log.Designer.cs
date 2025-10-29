using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class Form1 : Form
    {
        private Label lblTitle;
        private Label label1;
        private Label label2;
        private TextBox tb_email;
        private TextBox tb_matkhau;
        private Button btn_dangnhap;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            label1 = new Label();
            tb_email = new TextBox();
            label2 = new Label();
            tb_matkhau = new TextBox();
            btn_dangnhap = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 80, 100);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 90);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💖 SynHeart 💖";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.FromArgb(70, 70, 70);
            label1.Location = new Point(80, 120);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(180, 115);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(200, 32);
            tb_email.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            label2.Location = new Point(80, 170);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu";
            // 
            // tb_matkhau
            // 
            tb_matkhau.Font = new Font("Segoe UI", 11F);
            tb_matkhau.Location = new Point(180, 165);
            tb_matkhau.Name = "tb_matkhau";
            tb_matkhau.Size = new Size(200, 32);
            tb_matkhau.TabIndex = 4;
            tb_matkhau.UseSystemPasswordChar = true;
            // 
            // btn_dangnhap
            // 
            btn_dangnhap.BackColor = Color.FromArgb(255, 111, 145);
            btn_dangnhap.FlatAppearance.BorderSize = 0;
            btn_dangnhap.FlatStyle = FlatStyle.Flat;
            btn_dangnhap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_dangnhap.ForeColor = Color.White;
            btn_dangnhap.Location = new Point(160, 230);
            btn_dangnhap.Name = "btn_dangnhap";
            btn_dangnhap.Size = new Size(160, 40);
            btn_dangnhap.TabIndex = 5;
            btn_dangnhap.Text = "Đăng Nhập";
            btn_dangnhap.UseVisualStyleBackColor = false;
            btn_dangnhap.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Font = new Font("Segoe UI", 10F);
            linkLabel1.LinkColor = Color.FromArgb(0, 102, 204);
            linkLabel1.Location = new Point(100, 290);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(100, 23);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.Font = new Font("Segoe UI", 10F);
            linkLabel2.LinkColor = Color.FromArgb(0, 102, 204);
            linkLabel2.Location = new Point(260, 290);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(100, 23);
            linkLabel2.TabIndex = 7;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Đăng ký";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(480, 360);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(tb_email);
            Controls.Add(label2);
            Controls.Add(tb_matkhau);
            Controls.Add(btn_dangnhap);
            Controls.Add(linkLabel1);
            Controls.Add(linkLabel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - SynHeart";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
