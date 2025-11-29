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
            // ==== TONE MÀU & FONT ====
            this.BackColor = Color.FromArgb(255, 240, 245); // hồng pastel đẹp
            this.Font = new Font("Segoe UI Semibold", 10.5F); // font đẹp, hiện đại

            lblTitle = new Label();
            lblTen = new Label();
            txtTen = new TextBox();
            lblGioiTinh = new Label();
            cbGioiTinh = new ComboBox();
            lblTuoi = new Label();
            nudTuoi = new NumericUpDown();
            lblHocVan = new Label();
            txtHocVan = new TextBox();
            lblNgheNghiep = new Label();
            txtNgheNghiep = new TextBox();
            lblThoiQuen = new Label();
            txtThoiQuen = new TextBox();
            lblGioiThieu = new Label();
            txtGioiThieu = new TextBox();
            lblChieuCao = new Label();
            nudChieuCao = new NumericUpDown();
            lblViTri = new Label();
            txtViTri = new TextBox();
            btnHoanTat = new RoundedButton();
            btnBoQua = new RoundedButton();
            lb_snhat = new Label();
            dtp_snhat = new DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)nudTuoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudChieuCao).BeginInit();
            SuspendLayout();

            // ===== TITLE =====
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 20F);
            lblTitle.ForeColor = Color.FromArgb(255, 120, 140);
            lblTitle.Location = new Point(220, 20);
            lblTitle.Text = "CUNG CẤP THÔNG TIN HỒ SƠ";

            // ===== Họ tên =====
            lblTen.AutoSize = true;
            lblTen.Location = new Point(30, 100);
            lblTen.Text = "Họ và tên";

            txtTen.Location = new Point(150, 95);
            txtTen.Size = new Size(280, 30);

            // ===== Giới tính =====
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(30, 150);
            lblGioiTinh.Text = "Giới tính";

            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cbGioiTinh.Location = new Point(150, 145);
            cbGioiTinh.Size = new Size(150, 30);

            // ===== Tuổi =====
            lblTuoi.AutoSize = true;
            lblTuoi.Location = new Point(30, 200);
            lblTuoi.Text = "Tuổi";

            nudTuoi.Location = new Point(150, 195);
            nudTuoi.Minimum = 18;
            nudTuoi.Maximum = 80;
            nudTuoi.Value = 18;
            nudTuoi.Size = new Size(90, 30);

            // ===== Sinh nhật =====
            lb_snhat.AutoSize = true;
            lb_snhat.Location = new Point(30, 250);
            lb_snhat.Text = "Sinh nhật";

            dtp_snhat.Location = new Point(150, 245);
            dtp_snhat.Format = DateTimePickerFormat.Short;
            dtp_snhat.Size = new Size(200, 30);

            // ===== Học vấn =====
            lblHocVan.AutoSize = true;
            lblHocVan.Location = new Point(30, 300);
            lblHocVan.Text = "Học vấn";

            txtHocVan.Location = new Point(150, 295);
            txtHocVan.Size = new Size(280, 30);

            // ===== Nghề nghiệp =====
            lblNgheNghiep.AutoSize = true;
            lblNgheNghiep.Location = new Point(30, 350);
            lblNgheNghiep.Text = "Nghề nghiệp";

            txtNgheNghiep.Location = new Point(150, 345);
            txtNgheNghiep.Size = new Size(280, 30);

            // ===== Thói quen =====
            lblThoiQuen.AutoSize = true;
            lblThoiQuen.Location = new Point(30, 400);
            lblThoiQuen.Text = "Thói quen";

            txtThoiQuen.Location = new Point(150, 395);
            txtThoiQuen.Size = new Size(280, 30);

            // ===== Giới thiệu =====
            lblGioiThieu.AutoSize = true;
            lblGioiThieu.Location = new Point(30, 450);
            lblGioiThieu.Text = "Giới thiệu";

            txtGioiThieu.Location = new Point(150, 445);
            txtGioiThieu.Size = new Size(380, 90);
            txtGioiThieu.Multiline = true;
            txtGioiThieu.ScrollBars = ScrollBars.Vertical;

            // ===== Chiều cao =====
            lblChieuCao.AutoSize = true;
            lblChieuCao.Location = new Point(500, 100);
            lblChieuCao.Text = "Chiều cao (cm)";

            nudChieuCao.Location = new Point(650, 95);
            nudChieuCao.Minimum = 130;
            nudChieuCao.Maximum = 220;
            nudChieuCao.Value = 160;
            nudChieuCao.Size = new Size(90, 30);

            // ===== Vị trí =====
            lblViTri.AutoSize = true;
            lblViTri.Location = new Point(500, 150);
            lblViTri.Text = "Vị trí";

            txtViTri.Location = new Point(650, 145);
            txtViTri.Size = new Size(200, 30);

            // ===== BUTTON: HOÀN TẤT =====
            btnHoanTat.Text = "Hoàn tất";
            btnHoanTat.BackColor = Color.FromArgb(255, 130, 150);
            btnHoanTat.ForeColor = Color.White;
            btnHoanTat.FlatStyle = FlatStyle.Flat;
            btnHoanTat.FlatAppearance.BorderSize = 0;
            btnHoanTat.Location = new Point(620, 480);
            btnHoanTat.Size = new Size(120, 45);
            btnHoanTat.Click += btnHoanTat_Click;

            // ===== BUTTON: BỎ QUA =====
            btnBoQua.Text = "Bỏ qua";
            btnBoQua.BackColor = Color.LightGray;
            btnBoQua.FlatStyle = FlatStyle.Flat;
            btnBoQua.FlatAppearance.BorderSize = 0;
            btnBoQua.Location = new Point(750, 480);
            btnBoQua.Size = new Size(120, 45);
            btnBoQua.Click += btnBoQua_Click;

            // ===== ADD CONTROLS =====
            Controls.Add(lblTitle);
            Controls.Add(lblTen);
            Controls.Add(txtTen);
            Controls.Add(lblGioiTinh);
            Controls.Add(cbGioiTinh);
            Controls.Add(lblTuoi);
            Controls.Add(nudTuoi);
            Controls.Add(lb_snhat);
            Controls.Add(dtp_snhat);
            Controls.Add(lblHocVan);
            Controls.Add(txtHocVan);
            Controls.Add(lblNgheNghiep);
            Controls.Add(txtNgheNghiep);
            Controls.Add(lblThoiQuen);
            Controls.Add(txtThoiQuen);
            Controls.Add(lblGioiThieu);
            Controls.Add(txtGioiThieu);
            Controls.Add(lblChieuCao);
            Controls.Add(nudChieuCao);
            Controls.Add(lblViTri);
            Controls.Add(txtViTri);
            Controls.Add(btnHoanTat);
            Controls.Add(btnBoQua);

            // ===== FORM =====
            ClientSize = new Size(900, 550);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cung cấp thông tin";

            ((System.ComponentModel.ISupportInitialize)nudTuoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudChieuCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label lblTuoi;
        private System.Windows.Forms.NumericUpDown nudTuoi;
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
        private RoundedButton btnHoanTat;
        private RoundedButton btnBoQua;
        private Label lb_snhat;
        private DateTimePicker dtp_snhat;
    }
}