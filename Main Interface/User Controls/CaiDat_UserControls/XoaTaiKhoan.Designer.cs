namespace Main_Interface.User_Controls.CaiDat_UserControls
{
    partial class XoaTaiKhoan
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
            btn_huy = new Button();
            btn_xacnhan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(145, 48);
            label1.Name = "label1";
            label1.Size = new Size(499, 54);
            label1.TabIndex = 0;
            label1.Text = "Xác Nhận Xóa Tài Khoản?";
            // 
            // btn_huy
            // 
            btn_huy.BackColor = Color.SkyBlue;
            btn_huy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_huy.Location = new Point(194, 245);
            btn_huy.Name = "btn_huy";
            btn_huy.Size = new Size(167, 51);
            btn_huy.TabIndex = 1;
            btn_huy.Text = "Hủy";
            btn_huy.UseVisualStyleBackColor = false;
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.BackColor = Color.Tomato;
            btn_xacnhan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xacnhan.Location = new Point(434, 245);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(167, 51);
            btn_xacnhan.TabIndex = 2;
            btn_xacnhan.Text = "Xác Nhận";
            btn_xacnhan.UseVisualStyleBackColor = false;
            // 
            // XoaTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_xacnhan);
            Controls.Add(btn_huy);
            Controls.Add(label1);
            Name = "XoaTaiKhoan";
            Text = "XoaTaiKhoan";
            Load += XoaTaiKhoan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_huy;
        private Button btn_xacnhan;
    }
}