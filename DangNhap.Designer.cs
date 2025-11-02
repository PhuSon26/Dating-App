using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class FormDangNhap : Form
    {
        private Label lblTitle;
        private Label label1;
        private Label label2;
        private TextBox tb_email;
        private TextBox tb_matkhau;
        private Button btn_dangnhap;
        private LinkLabel ll_quenmatkhau;
        private LinkLabel ll_dangky;
        private void InitializeComponent()
        {
            lblTitle = new Label();
            label1 = new Label();
            tb_email = new TextBox();
            label2 = new Label();
            tb_matkhau = new TextBox();
            btn_dangnhap = new Button();
            ll_quenmatkhau = new LinkLabel();
            ll_dangky = new LinkLabel();
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
            btn_dangnhap.Click += btn_dangnhap_Click;
            // 
            // ll_quenmatkhau
            // 
            ll_quenmatkhau.Font = new Font("Segoe UI", 10F);
            ll_quenmatkhau.LinkColor = Color.FromArgb(0, 102, 204);
            ll_quenmatkhau.Location = new Point(100, 290);
            ll_quenmatkhau.Name = "ll_quenmatkhau";
            ll_quenmatkhau.Size = new Size(138, 23);
            ll_quenmatkhau.TabIndex = 6;
            ll_quenmatkhau.TabStop = true;
            ll_quenmatkhau.Text = "Quên mật khẩu?";
            ll_quenmatkhau.LinkClicked += ll_quenmatkhau_LinkClicked;
            // ll_dangky
            // 
            ll_dangky.Font = new Font("Segoe UI", 10F);
            ll_dangky.LinkColor = Color.FromArgb(0, 102, 204);
            ll_dangky.Location = new Point(260, 290);
            ll_dangky.Name = "ll_dangky";
            ll_dangky.Size = new Size(100, 23);
            ll_dangky.TabIndex = 7;
            ll_dangky.TabStop = true;
            ll_dangky.Text = "Đăng ký";
            ll_dangky.LinkClicked += ll_dangky_LinkClicked;
            // FormDangNhap
            // 
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(480, 360);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(tb_email);
            Controls.Add(label2);
            Controls.Add(tb_matkhau);
            Controls.Add(btn_dangnhap);
            Controls.Add(ll_quenmatkhau);
            Controls.Add(ll_dangky);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - SynHeart";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
