namespace Main_Interface.User_Controls
{
    partial class LocUser : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelGioiTinh = new Label();
            labelTuoi = new Label();
            labelNoiSong = new Label();
            labelSoThich = new Label();
            labelHocVan = new Label();
            labelCongViec = new Label();
            comboGioiTinh = new ComboBox();
            textNoiSong = new TextBox();
            textSoThich = new TextBox();
            comboHocVan = new ComboBox();
            textCongViec = new TextBox();
            btnTimKiem = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.HotPink;
            labelTitle.Location = new Point(180, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(288, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Lọc Đối Tượng Phù Hợp";
            // 
            // labelGioiTinh
            // 
            labelGioiTinh.AutoSize = true;
            labelGioiTinh.Font = new Font("Segoe UI", 10F);
            labelGioiTinh.Location = new Point(60, 80);
            labelGioiTinh.Name = "labelGioiTinh";
            labelGioiTinh.Size = new Size(79, 23);
            labelGioiTinh.TabIndex = 1;
            labelGioiTinh.Text = "Giới tính:";
            // 
            // labelTuoi
            // 
            labelTuoi.AutoSize = true;
            labelTuoi.Font = new Font("Segoe UI", 10F);
            labelTuoi.Location = new Point(60, 120);
            labelTuoi.Name = "labelTuoi";
            labelTuoi.Size = new Size(71, 23);
            labelTuoi.TabIndex = 3;
            labelTuoi.Text = "Độ tuổi:";
            // 
            // labelNoiSong
            // 
            labelNoiSong.AutoSize = true;
            labelNoiSong.Font = new Font("Segoe UI", 10F);
            labelNoiSong.Location = new Point(60, 160);
            labelNoiSong.Name = "labelNoiSong";
            labelNoiSong.Size = new Size(83, 23);
            labelNoiSong.TabIndex = 6;
            labelNoiSong.Text = "Nơi sống:";
            // 
            // labelSoThich
            // 
            labelSoThich.AutoSize = true;
            labelSoThich.Font = new Font("Segoe UI", 10F);
            labelSoThich.Location = new Point(60, 200);
            labelSoThich.Name = "labelSoThich";
            labelSoThich.Size = new Size(76, 23);
            labelSoThich.TabIndex = 8;
            labelSoThich.Text = "Sở thích:";
            // 
            // labelHocVan
            // 
            labelHocVan.AutoSize = true;
            labelHocVan.Font = new Font("Segoe UI", 10F);
            labelHocVan.Location = new Point(60, 240);
            labelHocVan.Name = "labelHocVan";
            labelHocVan.Size = new Size(76, 23);
            labelHocVan.TabIndex = 10;
            labelHocVan.Text = "Học vấn:";
            // 
            // labelCongViec
            // 
            labelCongViec.AutoSize = true;
            labelCongViec.Font = new Font("Segoe UI", 10F);
            labelCongViec.Location = new Point(60, 280);
            labelCongViec.Name = "labelCongViec";
            labelCongViec.Size = new Size(89, 23);
            labelCongViec.TabIndex = 12;
            labelCongViec.Text = "Công việc:";
            // 
            // comboGioiTinh
            // 
            comboGioiTinh.Font = new Font("Segoe UI", 10F);
            comboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            comboGioiTinh.Location = new Point(180, 76);
            comboGioiTinh.Name = "comboGioiTinh";
            comboGioiTinh.Size = new Size(200, 31);
            comboGioiTinh.TabIndex = 2;
            // 
            // textNoiSong
            // 
            textNoiSong.Font = new Font("Segoe UI", 10F);
            textNoiSong.Location = new Point(180, 156);
            textNoiSong.Name = "textNoiSong";
            textNoiSong.Size = new Size(250, 30);
            textNoiSong.TabIndex = 7;
            // 
            // textSoThich
            // 
            textSoThich.Font = new Font("Segoe UI", 10F);
            textSoThich.Location = new Point(180, 196);
            textSoThich.Name = "textSoThich";
            textSoThich.Size = new Size(250, 30);
            textSoThich.TabIndex = 9;
            // 
            // comboHocVan
            // 
            comboHocVan.Font = new Font("Segoe UI", 10F);
            comboHocVan.Items.AddRange(new object[] { "Trung học", "Cao đẳng", "Đại học", "Sau đại học" });
            comboHocVan.Location = new Point(180, 236);
            comboHocVan.Name = "comboHocVan";
            comboHocVan.Size = new Size(200, 31);
            comboHocVan.TabIndex = 11;
            // 
            // textCongViec
            // 
            textCongViec.Font = new Font("Segoe UI", 10F);
            textCongViec.Location = new Point(180, 276);
            textCongViec.Name = "textCongViec";
            textCongViec.Size = new Size(250, 30);
            textCongViec.TabIndex = 13;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.LightPink;
            btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.Maroon;
            btnTimKiem.Location = new Point(220, 330);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(160, 40);
            btnTimKiem.TabIndex = 14;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.FromArgb(255, 100, 120);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(142, 23);
            label2.TabIndex = 15;
            label2.Text = "💖 SynHeart 💖";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.Items.AddRange(new object[] { "18 - 20 ", "20 - 30", "30  trở lên" });
            comboBox1.Location = new Point(180, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 31);
            comboBox1.TabIndex = 16;
            // 
            // locdoituong
            // 
            BackColor = Color.MistyRose;
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(labelTitle);
            Controls.Add(labelGioiTinh);
            Controls.Add(comboGioiTinh);
            Controls.Add(labelTuoi);
            Controls.Add(labelNoiSong);
            Controls.Add(textNoiSong);
            Controls.Add(labelSoThich);
            Controls.Add(textSoThich);
            Controls.Add(labelHocVan);
            Controls.Add(comboHocVan);
            Controls.Add(labelCongViec);
            Controls.Add(textCongViec);
            Controls.Add(btnTimKiem);
            Name = "locdoituong";
            Size = new Size(709, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelGioiTinh;
        private System.Windows.Forms.Label labelTuoi;
        private System.Windows.Forms.Label labelNoiSong;
        private System.Windows.Forms.Label labelSoThich;
        private System.Windows.Forms.Label labelHocVan;
        private System.Windows.Forms.Label labelCongViec;
        private System.Windows.Forms.ComboBox comboGioiTinh;
        private System.Windows.Forms.TextBox textNoiSong;
        private System.Windows.Forms.TextBox textSoThich;
        private System.Windows.Forms.ComboBox comboHocVan;
        private System.Windows.Forms.TextBox textCongViec;
        private System.Windows.Forms.Button btnTimKiem;
        private Label label2;
        private ComboBox comboBox1;
    }
}
