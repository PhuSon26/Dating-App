namespace Main_Interface.User_Controls.CaiDat_UserControls
{
    partial class DoiEmailMatKhau
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            tb_mk = new TextBox();
            tb_remk = new TextBox();
            btn_xacnhan = new RoundedButton();
            label5 = new Label();
            tb_mkHientai = new TextBox();
            btn_xacthuc = new RoundedButton();
            btn_back = new RoundedButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(294, 38);
            label1.Name = "label1";
            label1.Size = new Size(418, 65);
            label1.TabIndex = 0;
            label1.Text = "Đổi Mật Khẩu 🔒";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(189, 239);
            label3.Name = "label3";
            label3.Size = new Size(194, 30);
            label3.TabIndex = 2;
            label3.Text = "🔒 Mật khẩu mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(189, 316);
            label4.Name = "label4";
            label4.Size = new Size(293, 30);
            label4.TabIndex = 3;
            label4.Text = "🔒 Xác nhận mật khẩu mới";
            // 
            // tb_mk
            // 
            tb_mk.Enabled = false;
            tb_mk.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_mk.Location = new Point(524, 239);
            tb_mk.Margin = new Padding(3, 2, 3, 2);
            tb_mk.Multiline = true;
            tb_mk.Name = "tb_mk";
            tb_mk.Size = new Size(246, 33);
            tb_mk.TabIndex = 5;
            tb_mk.UseSystemPasswordChar = false;
            tb_mk.PasswordChar = '●';
            // 
            // tb_remk
            // 
            tb_remk.Enabled = false;
            tb_remk.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_remk.Location = new Point(524, 312);
            tb_remk.Margin = new Padding(3, 2, 3, 2);
            tb_remk.Multiline = true;
            tb_remk.Name = "tb_remk";
            tb_remk.Size = new Size(246, 33);
            tb_remk.TabIndex = 6;
            tb_remk.UseSystemPasswordChar = false;
            tb_remk.PasswordChar = '●';
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.FromArgb(58, 188, 175);
            btn_xacnhan.CornerRadius = 20;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(202, 380);
            btn_xacnhan.Margin = new Padding(3, 2, 3, 2);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(567, 44);
            btn_xacnhan.TabIndex = 7;
            btn_xacnhan.Text = "Xác Nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            btn_xacnhan.Click += btn_xacnhan_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(189, 165);
            label5.Name = "label5";
            label5.Size = new Size(231, 30);
            label5.TabIndex = 8;
            label5.Text = "🔒 Mật khẩu hiện tại";
            // 
            // tb_mkHientai
            // 
            tb_mkHientai.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_mkHientai.Location = new Point(524, 166);
            tb_mkHientai.Margin = new Padding(3, 2, 3, 2);
            tb_mkHientai.Multiline = true;
            tb_mkHientai.Name = "tb_mkHientai";
            tb_mkHientai.Size = new Size(246, 33);
            tb_mkHientai.TabIndex = 9;
            tb_mkHientai.UseSystemPasswordChar = false;
            tb_mkHientai.PasswordChar = '●';
            // 
            // btn_xacthuc
            // 
            btn_xacthuc.BackColor = Color.FromArgb(109, 216, 134);
            btn_xacthuc.CornerRadius = 20;
            btn_xacthuc.FlatStyle = FlatStyle.Flat;
            btn_xacthuc.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xacthuc.ForeColor = Color.White;
            btn_xacthuc.Location = new Point(804, 164);
            btn_xacthuc.Margin = new Padding(3, 2, 3, 2);
            btn_xacthuc.Name = "btn_xacthuc";
            btn_xacthuc.Size = new Size(128, 32);
            btn_xacthuc.TabIndex = 10;
            btn_xacthuc.Text = "Xác thực";
            btn_xacthuc.UseVisualStyleBackColor = false;
            btn_xacthuc.Click += btn_xacthuc_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(72, 209, 204);
            btn_back.CornerRadius = 30;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(-5, -38);
            btn_back.Margin = new Padding(3, 2, 3, 2);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(130, 94);
            btn_back.TabIndex = 11;
            btn_back.Text = "🠔";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // DoiEmailMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            Controls.Add(btn_back);
            Controls.Add(btn_xacthuc);
            Controls.Add(tb_mkHientai);
            Controls.Add(label5);
            Controls.Add(btn_xacnhan);
            Controls.Add(tb_remk);
            Controls.Add(tb_mk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DoiEmailMatKhau";
            Size = new Size(1028, 463);
            Load += DoiEmailMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox tb_mk;
        private TextBox tb_remk;
        private RoundedButton btn_xacnhan;
        private Label label5;
        private TextBox tb_mkHientai;
        private RoundedButton btn_xacthuc;
        private RoundedButton btn_back;
    }
}