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
            textBox1 = new TextBox();
            btn_xacthuc = new RoundedButton();
            btn_back = new RoundedButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(336, 51);
            label1.Name = "label1";
            label1.Size = new Size(521, 81);
            label1.TabIndex = 0;
            label1.Text = "Đổi Mật Khẩu 🔒";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(216, 319);
            label3.Name = "label3";
            label3.Size = new Size(250, 38);
            label3.TabIndex = 2;
            label3.Text = "🔒 Mật khẩu mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(216, 421);
            label4.Name = "label4";
            label4.Size = new Size(377, 38);
            label4.TabIndex = 3;
            label4.Text = "🔒 Xác nhận mật khẩu mới";
            // 
            // tb_mk
            // 
            tb_mk.Enabled = false;
            tb_mk.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_mk.Location = new Point(599, 319);
            tb_mk.Multiline = true;
            tb_mk.Name = "tb_mk";
            tb_mk.Size = new Size(280, 43);
            tb_mk.TabIndex = 5;
            tb_mk.UseSystemPasswordChar = true;
            // 
            // tb_remk
            // 
            tb_remk.Enabled = false;
            tb_remk.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_remk.Location = new Point(599, 416);
            tb_remk.Multiline = true;
            tb_remk.Name = "tb_remk";
            tb_remk.Size = new Size(280, 43);
            tb_remk.TabIndex = 6;
            tb_remk.UseSystemPasswordChar = true;
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.FromArgb(58, 188, 175);
            btn_xacnhan.CornerRadius = 20;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(231, 507);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(648, 59);
            btn_xacnhan.TabIndex = 7;
            btn_xacnhan.Text = "Xác Nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(216, 220);
            label5.Name = "label5";
            label5.Size = new Size(297, 38);
            label5.TabIndex = 8;
            label5.Text = "🔒 Mật khẩu hiện tại";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(599, 222);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 43);
            textBox1.TabIndex = 9;
            textBox1.UseSystemPasswordChar = true;
            // 
            // btn_xacthuc
            // 
            btn_xacthuc.BackColor = Color.FromArgb(109, 216, 134);
            btn_xacthuc.CornerRadius = 20;
            btn_xacthuc.FlatStyle = FlatStyle.Flat;
            btn_xacthuc.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xacthuc.ForeColor = Color.White;
            btn_xacthuc.Location = new Point(919, 219);
            btn_xacthuc.Name = "btn_xacthuc";
            btn_xacthuc.Size = new Size(146, 43);
            btn_xacthuc.TabIndex = 10;
            btn_xacthuc.Text = "Xác thực";
            btn_xacthuc.UseVisualStyleBackColor = false;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(72, 209, 204);
            btn_back.CornerRadius = 30;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(-6, -50);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(148, 125);
            btn_back.TabIndex = 11;
            btn_back.Text = "🠔";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // DoiEmailMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 146, 228);
            Controls.Add(btn_back);
            Controls.Add(btn_xacthuc);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(btn_xacnhan);
            Controls.Add(tb_remk);
            Controls.Add(tb_mk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "DoiEmailMatKhau";
            Size = new Size(1175, 617);
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
        private TextBox textBox1;
        private RoundedButton btn_xacthuc;
        private RoundedButton btn_back;
    }
}