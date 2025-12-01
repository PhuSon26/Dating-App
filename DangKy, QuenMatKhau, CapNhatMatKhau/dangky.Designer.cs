namespace LOGIN
{
    partial class FormDangKy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_dangky = new RoundedButton();
            tb_password = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tb_email = new TextBox();
            label4 = new Label();
            tb_rePassword = new TextBox();
            label5 = new Label();
            label3 = new Label();
            ll_back = new LinkLabel();
            SuspendLayout();
            // 
            // btn_dangky
            // 
            btn_dangky.AutoSize = true;
            btn_dangky.BackColor = Color.FromArgb(255, 111, 145);
            btn_dangky.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_dangky.ForeColor = Color.White;
            btn_dangky.Location = new Point(164, 337);
            btn_dangky.Name = "btn_dangky";
            btn_dangky.Size = new Size(451, 57);
            btn_dangky.TabIndex = 15;
            btn_dangky.Text = "Đăng ký";
            btn_dangky.UseVisualStyleBackColor = false;
            btn_dangky.Click += btn_dangky_Click;
            // 
            // tb_password
            // 
            tb_password.Font = new Font("Segoe UI", 12F);
            tb_password.Location = new Point(378, 219);
            tb_password.Name = "tb_password";
            tb_password.PasswordChar = '●';
            tb_password.Size = new Size(237, 34);
            tb_password.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(163, 223);
            label2.Name = "label2";
            label2.Size = new Size(106, 30);
            label2.TabIndex = 13;
            label2.Text = "Mật Khẩu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 230, 230);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(163, 164);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 11;
            label1.Text = "Email";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 12F);
            tb_email.Location = new Point(378, 160);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(236, 34);
            tb_email.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(163, 282);
            label4.Name = "label4";
            label4.Size = new Size(203, 30);
            label4.TabIndex = 17;
            label4.Text = "Xác Nhận Mật Khẩu";
            // 
            // tb_rePassword
            // 
            tb_rePassword.Font = new Font("Segoe UI", 12F);
            tb_rePassword.Location = new Point(377, 278);
            tb_rePassword.Name = "tb_rePassword";
            tb_rePassword.PasswordChar = '*';
            tb_rePassword.Size = new Size(237, 34);
            tb_rePassword.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(255, 230, 230);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.ForeColor = Color.FromArgb(250, 80, 100);
            label5.Location = new Point(251, 66);
            label5.Name = "label5";
            label5.Size = new Size(300, 43);
            label5.TabIndex = 19;
            label5.Text = "Đăng Ký Tài Khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(255, 230, 230);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(255, 80, 100);
            label3.Location = new Point(281, 9);
            label3.Name = "label3";
            label3.Size = new Size(232, 38);
            label3.TabIndex = 20;
            label3.Text = "💖 SynHeart 💖";
            label3.Click += label3_Click;
            // 
            // ll_back
            // 
            ll_back.AutoSize = true;
            ll_back.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ll_back.Location = new Point(637, 343);
            ll_back.Name = "ll_back";
            ll_back.Size = new Size(130, 38);
            ll_back.TabIndex = 21;
            ll_back.TabStop = true;
            ll_back.Text = "Quay Lại";
            ll_back.LinkClicked += ll_back_LinkClicked;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(800, 450);
            Controls.Add(ll_back);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(tb_rePassword);
            Controls.Add(label4);
            Controls.Add(btn_dangky);
            Controls.Add(tb_password);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tb_email);
            Name = "FormDangKy";
            Text = "Đăng Ký - SynHeart";
            Load += dangky_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedButton btn_dangky;
        private TextBox tb_password;
        private Label label2;
        private Label label1;
        private TextBox tb_email;
        private Label label4;
        private TextBox tb_rePassword;
        private Label label5;
        private Label label3;
        private LinkLabel ll_back;
    }
}