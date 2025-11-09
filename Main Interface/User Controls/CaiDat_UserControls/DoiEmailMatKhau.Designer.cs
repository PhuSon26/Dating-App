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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tb_email = new TextBox();
            tb_mk = new TextBox();
            tb_remk = new TextBox();
            btn_xacnhan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(380, 41);
            label1.Name = "label1";
            label1.Size = new Size(382, 46);
            label1.TabIndex = 0;
            label1.Text = "Đổi Email Và Mật Khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(231, 164);
            label2.Name = "label2";
            label2.Size = new Size(149, 38);
            label2.TabIndex = 1;
            label2.Text = "Email mới";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(231, 261);
            label3.Name = "label3";
            label3.Size = new Size(203, 38);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(231, 350);
            label4.Name = "label4";
            label4.Size = new Size(330, 38);
            label4.TabIndex = 3;
            label4.Text = "Xác nhận mật khẩu mới";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_email.Location = new Point(567, 159);
            tb_email.Multiline = true;
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(280, 43);
            tb_email.TabIndex = 4;
            // 
            // tb_mk
            // 
            tb_mk.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_mk.Location = new Point(567, 256);
            tb_mk.Multiline = true;
            tb_mk.Name = "tb_mk";
            tb_mk.Size = new Size(280, 43);
            tb_mk.TabIndex = 5;
            // 
            // tb_remk
            // 
            tb_remk.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_remk.Location = new Point(567, 345);
            tb_remk.Multiline = true;
            tb_remk.Name = "tb_remk";
            tb_remk.Size = new Size(280, 43);
            tb_remk.TabIndex = 6;
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.Orchid;
            btn_xacnhan.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xacnhan.Location = new Point(238, 443);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(609, 59);
            btn_xacnhan.TabIndex = 7;
            btn_xacnhan.Text = "Xác Nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            // 
            // DoiEmailMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1175, 595);
            Controls.Add(btn_xacnhan);
            Controls.Add(tb_remk);
            Controls.Add(tb_mk);
            Controls.Add(tb_email);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DoiEmailMatKhau";
            Text = "DoiEmailMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tb_email;
        private TextBox tb_mk;
        private TextBox tb_remk;
        private Button btn_xacnhan;
    }
}