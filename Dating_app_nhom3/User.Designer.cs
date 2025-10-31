namespace Dating_app_nhom3
{
    partial class UserChat_item
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblTenNguoiDung = new Label();
            lblTinNhanCuoi = new Label();
            lblThoiGian = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTenNguoiDung
            // 
            lblTenNguoiDung.AutoSize = true;
            lblTenNguoiDung.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenNguoiDung.Location = new Point(59, 0);
            lblTenNguoiDung.Name = "lblTenNguoiDung";
            lblTenNguoiDung.Size = new Size(70, 28);
            lblTenNguoiDung.TabIndex = 1;
            lblTenNguoiDung.Text = "label1";
            // 
            // lblTinNhanCuoi
            // 
            lblTinNhanCuoi.AutoSize = true;
            lblTinNhanCuoi.Location = new Point(59, 33);
            lblTinNhanCuoi.Name = "lblTinNhanCuoi";
            lblTinNhanCuoi.Size = new Size(50, 20);
            lblTinNhanCuoi.TabIndex = 2;
            lblTinNhanCuoi.Text = "label1";
            // 
            // lblThoiGian
            // 
            lblThoiGian.AutoSize = true;
            lblThoiGian.Location = new Point(400, 33);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(50, 20);
            lblThoiGian.TabIndex = 3;
            lblThoiGian.Text = "label1";
            // 
            // UserChat_item
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            Controls.Add(lblThoiGian);
            Controls.Add(lblTinNhanCuoi);
            Controls.Add(lblTenNguoiDung);
            Controls.Add(pictureBox1);
            Name = "UserChat_item";
            Size = new Size(489, 60);
            MouseEnter += UserChat_item_MouseLeave;
            MouseLeave += UserChat_item_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblTenNguoiDung;
        private Label lblTinNhanCuoi;
        private Label lblThoiGian;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
    }
}
