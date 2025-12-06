using System.Windows.Forms;

namespace LOGIN
{
    partial class CapNhatMatKhau
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
            tb_maxacnhan = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lblTitle = new Label();
            labelEmail = new Label();
            tb_email = new TextBox();
            btn_xacnhan = new RoundedButton();
            linkLabel_back = new LinkLabel();
            SuspendLayout();
            // 
            // tb_maxacnhan
            // 
            tb_maxacnhan.Font = new Font("Segoe UI", 11F);
            tb_maxacnhan.Location = new Point(292, 255);
            tb_maxacnhan.Name = "tb_maxacnhan";
            tb_maxacnhan.Size = new Size(220, 32);
            tb_maxacnhan.TabIndex = 16;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            label2.Location = new Point(122, 258);
            label2.Name = "label2";
            label2.Size = new Size(131, 23);
            label2.TabIndex = 15;
            label2.Text = "Xác Nhận Mật Khẩu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(255, 80, 100);
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 38);
            label1.TabIndex = 14;
            label1.Text = "💖 SynHeart 💖";
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 80, 100);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 138);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "🔒 Cập Nhật Mật Khẩu";
            lblTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI", 11F);
            labelEmail.ForeColor = Color.FromArgb(70, 70, 70);
            labelEmail.Location = new Point(122, 202);
            labelEmail.Name = "labelEmail";
            labelEmail.TabIndex = 10;
            labelEmail.Text = "Mật Khẩu";
            // 
            // tb_email
            // 
            tb_email.Font = new Font("Segoe UI", 11F);
            tb_email.Location = new Point(292, 193);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(220, 32);
            tb_email.TabIndex = 11;
            tb_email.PasswordChar = '●';
            tb_email.UseSystemPasswordChar = false;
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.FromArgb(255, 111, 145);
            btn_xacnhan.CornerRadius = 20;
            btn_xacnhan.FlatAppearance.BorderSize = 0;
            btn_xacnhan.FlatStyle = FlatStyle.Flat;
            btn_xacnhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_xacnhan.ForeColor = Color.White;
            btn_xacnhan.Location = new Point(292, 333);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(187, 40);
            btn_xacnhan.TabIndex = 12;
            btn_xacnhan.Text = "Cập Nhật";
            btn_xacnhan.UseVisualStyleBackColor = false;
            // 
            // linkLabel_back
            // 
            linkLabel_back.Font = new Font("Segoe UI", 10F);
            linkLabel_back.LinkColor = Color.FromArgb(0, 102, 204);
            linkLabel_back.Location = new Point(522, 393);
            linkLabel_back.Name = "linkLabel_back";
            linkLabel_back.Size = new Size(200, 38);
            linkLabel_back.TabIndex = 13;
            linkLabel_back.TabStop = true;
            linkLabel_back.Text = "← Quay lại đăng nhập";
            // 
            // CapNhatMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(800, 450);
            Controls.Add(tb_maxacnhan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(labelEmail);
            Controls.Add(tb_email);
            Controls.Add(btn_xacnhan);
            Controls.Add(linkLabel_back);
            Name = "CapNhatMatKhau";
            Text = "Capnhatmatkhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tb_maxacnhan;
        private Label label2;
        private Label label1;
        private Label lblTitle;
        private Label labelEmail;
        private TextBox tb_email;
        private RoundedButton btn_xacnhan;
        private LinkLabel linkLabel_back;
    }
}