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
            comboGioiTinh = new ComboBox();
            textNoiSong = new TextBox();
            btnTimKiem = new Button();
            num_dotuoi = new NumericUpDown();
            num_chieucao = new NumericUpDown();
            label1 = new Label();
            btn_back = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)num_dotuoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_chieucao).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            labelTitle.ForeColor = Color.HotPink;
            labelTitle.Location = new Point(320, 50);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(417, 47);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Lọc Đối Tượng Phù Hợp";
            // 
            // labelGioiTinh
            // 
            labelGioiTinh.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGioiTinh.Location = new Point(320, 170);
            labelGioiTinh.Name = "labelGioiTinh";
            labelGioiTinh.Size = new Size(180, 40);
            labelGioiTinh.TabIndex = 1;
            labelGioiTinh.Text = "Giới tính:";
            labelGioiTinh.AutoSize = true;
            // 
            // labelTuoi
            // 
            labelTuoi.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTuoi.Location = new Point(320, 250);
            labelTuoi.Name = "labelTuoi";
            labelTuoi.Size = new Size(180, 40);
            labelTuoi.TabIndex = 3;
            labelTuoi.AutoSize = true;
            labelTuoi.Text = "Độ tuổi:";
            // 
            // labelNoiSong
            // 
            labelNoiSong.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNoiSong.Location = new Point(320, 430);
            labelNoiSong.Name = "labelNoiSong";
            labelNoiSong.Size = new Size(180, 40);
            labelNoiSong.TabIndex = 7;
            labelNoiSong.Text = "Nơi sống:";
            labelNoiSong.AutoSize = true;
            // 
            // comboGioiTinh
            // 
            comboGioiTinh.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Tất cả" });
            comboGioiTinh.Location = new Point(520, 170);
            comboGioiTinh.Name = "comboGioiTinh";
            comboGioiTinh.Size = new Size(350, 33);
            comboGioiTinh.TabIndex = 2;
            comboGioiTinh.SelectedIndex = 2;
            // 
            // textNoiSong
            // 
            textNoiSong.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textNoiSong.Location = new Point(520, 430);
            textNoiSong.Name = "textNoiSong";
            textNoiSong.Size = new Size(350, 32);
            textNoiSong.TabIndex = 8;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.LightPink;
            btnTimKiem.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.Maroon;
            btnTimKiem.Location = new Point(320, 550);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(560, 66);
            btnTimKiem.TabIndex = 9;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // num_dotuoi
            // 
            num_dotuoi.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_dotuoi.Location = new Point(520, 250);
            num_dotuoi.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            num_dotuoi.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            num_dotuoi.Name = "num_dotuoi";
            num_dotuoi.Size = new Size(350, 32);
            num_dotuoi.TabIndex = 4;
            num_dotuoi.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // num_chieucao
            // 
            num_chieucao.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_chieucao.Location = new Point(520, 340);
            num_chieucao.Maximum = new decimal(new int[] { 220, 0, 0, 0 });
            num_chieucao.Minimum = new decimal(new int[] { 140, 0, 0, 0 });
            num_chieucao.Name = "num_chieucao";
            num_chieucao.Size = new Size(350, 32);
            num_chieucao.TabIndex = 6;
            num_chieucao.Value = new decimal(new int[] { 160, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); 
            label1.Location = new Point(320, 340);
            label1.Name = "label1";
            label1.Size = new Size(180, 40);
            label1.TabIndex = 5;
            label1.AutoSize = true;
            label1.Text = "Chiều cao:";
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(72, 209, 204);
            btn_back.CornerRadius = 30;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 70F, FontStyle.Bold);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(0, -50);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(150, 120);
            btn_back.TabIndex = 10;
            btn_back.Text = "🠔";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // LocUser
            // 
            BackColor = Color.MistyRose;
            Controls.Add(labelTitle);
            Controls.Add(labelGioiTinh);
            Controls.Add(comboGioiTinh);
            Controls.Add(labelTuoi);
            Controls.Add(num_dotuoi);
            Controls.Add(label1);
            Controls.Add(num_chieucao);
            Controls.Add(labelNoiSong);
            Controls.Add(textNoiSong);
            Controls.Add(btnTimKiem);
            Controls.Add(btn_back);
            Name = "LocUser";
            Size = new Size(1198, 620);
            ((System.ComponentModel.ISupportInitialize)num_dotuoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_chieucao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelGioiTinh;
        private Label labelTuoi;
        private Label labelNoiSong;
        private ComboBox comboGioiTinh;
        private TextBox textNoiSong;
        private Button btnTimKiem;
        private NumericUpDown num_dotuoi;
        private NumericUpDown num_chieucao;
        private Label label1;
        private RoundedButton btn_back;
    }
}
