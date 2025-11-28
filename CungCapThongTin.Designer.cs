namespace LOGIN
{
    partial class CungCapThongTin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblTuoi = new System.Windows.Forms.Label();
            this.nudTuoi = new System.Windows.Forms.NumericUpDown();
            this.lblSNhat = new System.Windows.Forms.Label();
            this.txtSNhat = new System.Windows.Forms.TextBox();
            this.lblHocVan = new System.Windows.Forms.Label();
            this.txtHocVan = new System.Windows.Forms.TextBox();
            this.lblNgheNghiep = new System.Windows.Forms.Label();
            this.txtNgheNghiep = new System.Windows.Forms.TextBox();
            this.lblThoiQuen = new System.Windows.Forms.Label();
            this.txtThoiQuen = new System.Windows.Forms.TextBox();
            this.lblGioiThieu = new System.Windows.Forms.Label();
            this.txtGioiThieu = new System.Windows.Forms.TextBox();
            this.lblChieuCao = new System.Windows.Forms.Label();
            this.nudChieuCao = new System.Windows.Forms.NumericUpDown();
            this.lblViTri = new System.Windows.Forms.Label();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChieuCao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(331, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CUNG CẤP THÔNG TIN HỒ SƠ";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(26, 70);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(54, 15);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Họ và tên";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(120, 67);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(250, 23);
            this.txtTen.TabIndex = 0;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(26, 104);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(52, 15);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGioiTinh.Location = new System.Drawing.Point(120, 101);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(121, 23);
            this.cbGioiTinh.TabIndex = 1;
            // 
            // lblTuoi
            // 
            this.lblTuoi.AutoSize = true;
            this.lblTuoi.Location = new System.Drawing.Point(26, 138);
            this.lblTuoi.Name = "lblTuoi";
            this.lblTuoi.Size = new System.Drawing.Size(30, 15);
            this.lblTuoi.TabIndex = 5;
            this.lblTuoi.Text = "Tuổi";
            // 
            // nudTuoi
            // 
            this.nudTuoi.Location = new System.Drawing.Point(120, 136);
            this.nudTuoi.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudTuoi.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudTuoi.Name = "nudTuoi";
            this.nudTuoi.Size = new System.Drawing.Size(80, 23);
            this.nudTuoi.TabIndex = 2;
            this.nudTuoi.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // lblSNhat
            // 
            this.lblSNhat.AutoSize = true;
            this.lblSNhat.Location = new System.Drawing.Point(26, 172);
            this.lblSNhat.Name = "lblSNhat";
            this.lblSNhat.Size = new System.Drawing.Size(83, 15);
            this.lblSNhat.TabIndex = 7;
            this.lblSNhat.Text = "Sở thích / Sở nhất";
            // 
            // txtSNhat
            // 
            this.txtSNhat.Location = new System.Drawing.Point(120, 169);
            this.txtSNhat.Name = "txtSNhat";
            this.txtSNhat.Size = new System.Drawing.Size(250, 23);
            this.txtSNhat.TabIndex = 3;
            // 
            // lblHocVan
            // 
            this.lblHocVan.AutoSize = true;
            this.lblHocVan.Location = new System.Drawing.Point(26, 206);
            this.lblHocVan.Name = "lblHocVan";
            this.lblHocVan.Size = new System.Drawing.Size(50, 15);
            this.lblHocVan.TabIndex = 9;
            this.lblHocVan.Text = "Học vấn";
            // 
            // txtHocVan
            // 
            this.txtHocVan.Location = new System.Drawing.Point(120, 203);
            this.txtHocVan.Name = "txtHocVan";
            this.txtHocVan.Size = new System.Drawing.Size(250, 23);
            this.txtHocVan.TabIndex = 4;
            // 
            // lblNgheNghiep
            // 
            this.lblNgheNghiep.AutoSize = true;
            this.lblNgheNghiep.Location = new System.Drawing.Point(26, 240);
            this.lblNgheNghiep.Name = "lblNgheNghiep";
            this.lblNgheNghiep.Size = new System.Drawing.Size(75, 15);
            this.lblNgheNghiep.TabIndex = 11;
            this.lblNgheNghiep.Text = "Nghề nghiệp";
            // 
            // txtNgheNghiep
            // 
            this.txtNgheNghiep.Location = new System.Drawing.Point(120, 237);
            this.txtNgheNghiep.Name = "txtNgheNghiep";
            this.txtNgheNghiep.Size = new System.Drawing.Size(250, 23);
            this.txtNgheNghiep.TabIndex = 5;
            // 
            // lblThoiQuen
            // 
            this.lblThoiQuen.AutoSize = true;
            this.lblThoiQuen.Location = new System.Drawing.Point(26, 274);
            this.lblThoiQuen.Name = "lblThoiQuen";
            this.lblThoiQuen.Size = new System.Drawing.Size(60, 15);
            this.lblThoiQuen.TabIndex = 13;
            this.lblThoiQuen.Text = "Thói quen";
            // 
            // txtThoiQuen
            // 
            this.txtThoiQuen.Location = new System.Drawing.Point(120, 271);
            this.txtThoiQuen.Name = "txtThoiQuen";
            this.txtThoiQuen.Size = new System.Drawing.Size(250, 23);
            this.txtThoiQuen.TabIndex = 6;
            // 
            // lblGioiThieu
            // 
            this.lblGioiThieu.AutoSize = true;
            this.lblGioiThieu.Location = new System.Drawing.Point(26, 308);
            this.lblGioiThieu.Name = "lblGioiThieu";
            this.lblGioiThieu.Size = new System.Drawing.Size(58, 15);
            this.lblGioiThieu.TabIndex = 15;
            this.lblGioiThieu.Text = "Giới thiệu";
            // 
            // txtGioiThieu
            // 
            this.txtGioiThieu.Location = new System.Drawing.Point(120, 305);
            this.txtGioiThieu.Multiline = true;
            this.txtGioiThieu.Name = "txtGioiThieu";
            this.txtGioiThieu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGioiThieu.Size = new System.Drawing.Size(350, 70);
            this.txtGioiThieu.TabIndex = 7;
            // 
            // lblChieuCao
            // 
            this.lblChieuCao.AutoSize = true;
            this.lblChieuCao.Location = new System.Drawing.Point(420, 70);
            this.lblChieuCao.Name = "lblChieuCao";
            this.lblChieuCao.Size = new System.Drawing.Size(66, 15);
            this.lblChieuCao.TabIndex = 17;
            this.lblChieuCao.Text = "Chiều cao (cm)";
            // 
            // nudChieuCao
            // 
            this.nudChieuCao.Location = new System.Drawing.Point(510, 68);
            this.nudChieuCao.Maximum = new decimal(new int[] {
            220,
            0,
            0,
            0});
            this.nudChieuCao.Minimum = new decimal(new int[] {
            130,
            0,
            0,
            0});
            this.nudChieuCao.Name = "nudChieuCao";
            this.nudChieuCao.Size = new System.Drawing.Size(80, 23);
            this.nudChieuCao.TabIndex = 8;
            this.nudChieuCao.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // lblViTri
            // 
            this.lblViTri.AutoSize = true;
            this.lblViTri.Location = new System.Drawing.Point(420, 104);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(32, 15);
            this.lblViTri.TabIndex = 19;
            this.lblViTri.Text = "Vị trí";
            // 
            // txtViTri
            // 
            this.txtViTri.Location = new System.Drawing.Point(510, 101);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(180, 23);
            this.txtViTri.TabIndex = 9;
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.Location = new System.Drawing.Point(510, 335);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(90, 30);
            this.btnHoanTat.TabIndex = 10;
            this.btnHoanTat.Text = "Hoàn tất";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            this.btnHoanTat.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(600, 335);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(90, 30);
            this.btnBoQua.TabIndex = 11;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // CungCapThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 400);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnHoanTat);
            this.Controls.Add(this.txtViTri);
            this.Controls.Add(this.lblViTri);
            this.Controls.Add(this.nudChieuCao);
            this.Controls.Add(this.lblChieuCao);
            this.Controls.Add(this.txtGioiThieu);
            this.Controls.Add(this.lblGioiThieu);
            this.Controls.Add(this.txtThoiQuen);
            this.Controls.Add(this.lblThoiQuen);
            this.Controls.Add(this.txtNgheNghiep);
            this.Controls.Add(this.lblNgheNghiep);
            this.Controls.Add(this.txtHocVan);
            this.Controls.Add(this.lblHocVan);
            this.Controls.Add(this.txtSNhat);
            this.Controls.Add(this.lblSNhat);
            this.Controls.Add(this.nudTuoi);
            this.Controls.Add(this.lblTuoi);
            this.Controls.Add(this.cbGioiTinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CungCapThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cung cấp thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.nudTuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChieuCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label lblTuoi;
        private System.Windows.Forms.NumericUpDown nudTuoi;
        private System.Windows.Forms.Label lblSNhat;
        private System.Windows.Forms.TextBox txtSNhat;
        private System.Windows.Forms.Label lblHocVan;
        private System.Windows.Forms.TextBox txtHocVan;
        private System.Windows.Forms.Label lblNgheNghiep;
        private System.Windows.Forms.TextBox txtNgheNghiep;
        private System.Windows.Forms.Label lblThoiQuen;
        private System.Windows.Forms.TextBox txtThoiQuen;
        private System.Windows.Forms.Label lblGioiThieu;
        private System.Windows.Forms.TextBox txtGioiThieu;
        private System.Windows.Forms.Label lblChieuCao;
        private System.Windows.Forms.NumericUpDown nudChieuCao;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnBoQua;
    }
}
