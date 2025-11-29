using System.Drawing;
using System.Windows.Forms;

namespace LOGIN
{
    partial class FormDangNhap : Form
    {
        private Label label1;
        private Label label2;
        private TextBox tb_email;
        private TextBox tb_matkhau;
        private RoundedButton btn_dangnhap;
        private LinkLabel ll_quenmatkhau;
        private LinkLabel ll_dangky;
        private void InitializeComponent()
        {
            label1 = new Label();
            tb_email = new TextBox();
            label2 = new Label();
            tb_matkhau = new TextBox();
            btn_dangnhap = new RoundedButton();
            ll_quenmatkhau = new LinkLabel();
            ll_dangky = new LinkLabel();
            panel = new Panel();
            label3 = new Label();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(70, 70, 70);
            label1.Location = new Point(201, 132);
            label1.Name = "label1";
            label1.Size = new Size(87, 34);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(321, 134);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(244, 32);
            tb_email.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            label2.Location = new Point(201, 182);
            label2.Name = "label2";
            label2.Size = new Size(120, 34);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu";
            // 
            // tb_matkhau
            // 
            tb_matkhau.Font = new Font("Segoe UI", 11F);
            tb_matkhau.Location = new Point(321, 184);
            tb_matkhau.Name = "tb_matkhau";
            tb_matkhau.Size = new Size(244, 32);
            tb_matkhau.TabIndex = 4;
            tb_matkhau.UseSystemPasswordChar = true;
            tb_matkhau.TextChanged += tb_matkhau_TextChanged;
            // 
            // btn_dangnhap
            // 
            btn_dangnhap.BackColor = Color.FromArgb(255, 111, 145);
            btn_dangnhap.FlatAppearance.BorderSize = 0;
            btn_dangnhap.FlatStyle = FlatStyle.Flat;
            btn_dangnhap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_dangnhap.ForeColor = Color.White;
            btn_dangnhap.Location = new Point(201, 252);
            btn_dangnhap.Name = "btn_dangnhap";
            btn_dangnhap.Size = new Size(364, 50);
            btn_dangnhap.TabIndex = 5;
            btn_dangnhap.Text = "Đăng Nhập";
            btn_dangnhap.UseVisualStyleBackColor = false;
            btn_dangnhap.Click += btn_dangnhap_Click;
            // 
            // ll_quenmatkhau
            // 
            ll_quenmatkhau.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ll_quenmatkhau.LinkColor = Color.FromArgb(0, 102, 204);
            ll_quenmatkhau.Location = new Point(201, 331);
            ll_quenmatkhau.Name = "ll_quenmatkhau";
            ll_quenmatkhau.Size = new Size(189, 48);
            ll_quenmatkhau.TabIndex = 6;
            ll_quenmatkhau.TabStop = true;
            ll_quenmatkhau.Text = "Quên mật khẩu?";
            ll_quenmatkhau.LinkClicked += ll_quenmatkhau_LinkClicked;
            // 
            // ll_dangky
            // 
            ll_dangky.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ll_dangky.LinkColor = Color.FromArgb(0, 102, 204);
            ll_dangky.Location = new Point(449, 331);
            ll_dangky.Name = "ll_dangky";
            ll_dangky.Size = new Size(116, 40);
            ll_dangky.TabIndex = 7;
            ll_dangky.TabStop = true;
            ll_dangky.Text = "Đăng ký";
            ll_dangky.LinkClicked += ll_dangky_LinkClicked;
            // 
            // panel
            // 
            panel.Controls.Add(label3);
            panel.Controls.Add(ll_dangky);
            panel.Controls.Add(label2);
            panel.Controls.Add(label1);
            panel.Controls.Add(ll_quenmatkhau);
            panel.Controls.Add(tb_email);
            panel.Controls.Add(btn_dangnhap);
            panel.Controls.Add(tb_matkhau);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(800, 450);
            panel.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DeepPink;
            label3.Location = new Point(224, 9);
            label3.Name = "label3";
            label3.Size = new Size(364, 60);
            label3.TabIndex = 8;
            label3.Text = "💖 SynHeart 💖";
            // 
            // FormDangNhap
            // 
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - SynHeart";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }
        private Panel panel;
        private Label label3;
    }
}
