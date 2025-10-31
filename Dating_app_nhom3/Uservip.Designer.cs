namespace Dating_app_nhom3
{
    partial class Uservip : Form 
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
            panelProfile = new Panel();
            lblLogo = new Label();
            btnChangeAvatar = new Button();
            lblUserID_Profile = new Label();
            lblVipBadge = new Label();
            lblUserName = new Label();
            picAvatar = new PictureBox();
            panelDetails = new Panel();
            btnEditProfile = new Button();
            txtHocVan = new TextBox();
            lblHocVan = new Label();
            txtCongViec = new TextBox();
            lblCongViec = new Label();
            txtSoThich = new TextBox();
            lblSoThich = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            dtpSinhNhat = new DateTimePicker();
            lblSinhNhat = new Label();
            cmbGioiTinh = new ComboBox();
            lblGioiTinh = new Label();
            txtID = new TextBox();
            lblID = new Label();
            txtTenNguoiDung = new TextBox();
            lblTenNguoiDung = new Label();
            lblTitle = new Label();
            panelProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // panelProfile
            // 
            panelProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelProfile.BackColor = Color.FromArgb(52, 73, 94);
            panelProfile.Controls.Add(lblLogo);
            panelProfile.Controls.Add(btnChangeAvatar);
            panelProfile.Controls.Add(lblUserID_Profile);
            panelProfile.Controls.Add(lblVipBadge);
            panelProfile.Controls.Add(lblUserName);
            panelProfile.Controls.Add(picAvatar);
            panelProfile.Location = new Point(12, 12);
            panelProfile.Name = "panelProfile";
            panelProfile.Size = new Size(268, 651);
            panelProfile.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.FromArgb(255, 215, 0);
            lblLogo.Location = new Point(3, 14);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(262, 32);
            lblLogo.TabIndex = 5;
            lblLogo.Text = "♡SynHeart ♡";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnChangeAvatar
            // 
            btnChangeAvatar.BackColor = Color.FromArgb(74, 93, 114);
            btnChangeAvatar.FlatAppearance.BorderSize = 0;
            btnChangeAvatar.FlatStyle = FlatStyle.Flat;
            btnChangeAvatar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeAvatar.ForeColor = Color.White;
            btnChangeAvatar.Location = new Point(59, 256);
            btnChangeAvatar.Name = "btnChangeAvatar";
            btnChangeAvatar.Size = new Size(150, 30);
            btnChangeAvatar.TabIndex = 4;
            btnChangeAvatar.Text = "Thay đổi Avatar";
            btnChangeAvatar.UseVisualStyleBackColor = false;
            // 
            // lblUserID_Profile
            // 
            lblUserID_Profile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserID_Profile.ForeColor = Color.FromArgb(189, 195, 199);
            lblUserID_Profile.Location = new Point(3, 403);
            lblUserID_Profile.Name = "lblUserID_Profile";
            lblUserID_Profile.Size = new Size(262, 23);
            lblUserID_Profile.TabIndex = 3;
            lblUserID_Profile.Text = "ID: 123456789";
            lblUserID_Profile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVipBadge
            // 
            lblVipBadge.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVipBadge.ForeColor = Color.FromArgb(255, 215, 0);
            lblVipBadge.Location = new Point(3, 368);
            lblVipBadge.Name = "lblVipBadge";
            lblVipBadge.Size = new Size(262, 23);
            lblVipBadge.TabIndex = 2;
            lblVipBadge.Text = "👑 THÀNH VIÊN VIP 👑";
            lblVipBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(3, 327);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(262, 30);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Tên Người Dùng";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(44, 62, 80);
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(59, 100);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // panelDetails
            // 
            panelDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDetails.BackColor = Color.FromArgb(52, 73, 94);
            panelDetails.Controls.Add(btnEditProfile);
            panelDetails.Controls.Add(txtHocVan);
            panelDetails.Controls.Add(lblHocVan);
            panelDetails.Controls.Add(txtCongViec);
            panelDetails.Controls.Add(lblCongViec);
            panelDetails.Controls.Add(txtSoThich);
            panelDetails.Controls.Add(lblSoThich);
            panelDetails.Controls.Add(txtDiaChi);
            panelDetails.Controls.Add(lblDiaChi);
            panelDetails.Controls.Add(dtpSinhNhat);
            panelDetails.Controls.Add(lblSinhNhat);
            panelDetails.Controls.Add(cmbGioiTinh);
            panelDetails.Controls.Add(lblGioiTinh);
            panelDetails.Controls.Add(txtID);
            panelDetails.Controls.Add(lblID);
            panelDetails.Controls.Add(txtTenNguoiDung);
            panelDetails.Controls.Add(lblTenNguoiDung);
            panelDetails.Controls.Add(lblTitle);
            panelDetails.Location = new Point(286, 12);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(587, 651);
            panelDetails.TabIndex = 1;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditProfile.BackColor = Color.FromArgb(255, 215, 0);
            btnEditProfile.FlatAppearance.BorderSize = 0;
            btnEditProfile.FlatStyle = FlatStyle.Flat;
            btnEditProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditProfile.ForeColor = Color.FromArgb(26, 26, 26);
            btnEditProfile.Location = new Point(135, 592);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(326, 40);
            btnEditProfile.TabIndex = 17;
            btnEditProfile.Text = "✎ Chỉnh sửa hồ sơ";
            btnEditProfile.UseVisualStyleBackColor = false;
            // 
            // txtHocVan
            // 
            txtHocVan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHocVan.BackColor = Color.FromArgb(44, 62, 80);
            txtHocVan.BorderStyle = BorderStyle.FixedSingle;
            txtHocVan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHocVan.ForeColor = Color.White;
            txtHocVan.Location = new Point(157, 345);
            txtHocVan.Name = "txtHocVan";
            txtHocVan.Size = new Size(427, 29);
            txtHocVan.TabIndex = 16;
            // 
            // lblHocVan
            // 
            lblHocVan.AutoSize = true;
            lblHocVan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHocVan.ForeColor = Color.FromArgb(189, 195, 199);
            lblHocVan.Location = new Point(25, 351);
            lblHocVan.Name = "lblHocVan";
            lblHocVan.Size = new Size(76, 23);
            lblHocVan.TabIndex = 15;
            lblHocVan.Text = "Học vấn:";
            // 
            // txtCongViec
            // 
            txtCongViec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCongViec.BackColor = Color.FromArgb(44, 62, 80);
            txtCongViec.BorderStyle = BorderStyle.FixedSingle;
            txtCongViec.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCongViec.ForeColor = Color.White;
            txtCongViec.Location = new Point(157, 304);
            txtCongViec.Name = "txtCongViec";
            txtCongViec.Size = new Size(427, 29);
            txtCongViec.TabIndex = 14;
            // 
            // lblCongViec
            // 
            lblCongViec.AutoSize = true;
            lblCongViec.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCongViec.ForeColor = Color.FromArgb(189, 195, 199);
            lblCongViec.Location = new Point(25, 306);
            lblCongViec.Name = "lblCongViec";
            lblCongViec.Size = new Size(89, 23);
            lblCongViec.TabIndex = 13;
            lblCongViec.Text = "Công việc:";
            // 
            // txtSoThich
            // 
            txtSoThich.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSoThich.BackColor = Color.FromArgb(44, 62, 80);
            txtSoThich.BorderStyle = BorderStyle.FixedSingle;
            txtSoThich.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoThich.ForeColor = Color.White;
            txtSoThich.Location = new Point(157, 261);
            txtSoThich.Name = "txtSoThich";
            txtSoThich.Size = new Size(427, 29);
            txtSoThich.TabIndex = 12;
            // 
            // lblSoThich
            // 
            lblSoThich.AutoSize = true;
            lblSoThich.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSoThich.ForeColor = Color.FromArgb(189, 195, 199);
            lblSoThich.Location = new Point(25, 261);
            lblSoThich.Name = "lblSoThich";
            lblSoThich.Size = new Size(76, 23);
            lblSoThich.TabIndex = 11;
            lblSoThich.Text = "Sở thích:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiaChi.BackColor = Color.FromArgb(44, 62, 80);
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiaChi.ForeColor = Color.White;
            txtDiaChi.Location = new Point(157, 214);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(427, 29);
            txtDiaChi.TabIndex = 10;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiaChi.ForeColor = Color.FromArgb(189, 195, 199);
            lblDiaChi.Location = new Point(25, 216);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(66, 23);
            lblDiaChi.TabIndex = 9;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // dtpSinhNhat
            // 
            dtpSinhNhat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpSinhNhat.CalendarFont = new Font("Segoe UI", 9.75F);
            dtpSinhNhat.CalendarTitleBackColor = Color.FromArgb(44, 62, 80);
            dtpSinhNhat.CalendarTitleForeColor = Color.White;
            dtpSinhNhat.CustomFormat = "dd/MM/yyyy";
            dtpSinhNhat.Font = new Font("Segoe UI", 9.75F);
            dtpSinhNhat.Format = DateTimePickerFormat.Custom;
            dtpSinhNhat.Location = new Point(157, 168);
            dtpSinhNhat.Name = "dtpSinhNhat";
            dtpSinhNhat.Size = new Size(427, 29);
            dtpSinhNhat.TabIndex = 8;
            // 
            // lblSinhNhat
            // 
            lblSinhNhat.AutoSize = true;
            lblSinhNhat.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSinhNhat.ForeColor = Color.FromArgb(189, 195, 199);
            lblSinhNhat.Location = new Point(25, 174);
            lblSinhNhat.Name = "lblSinhNhat";
            lblSinhNhat.Size = new Size(87, 23);
            lblSinhNhat.TabIndex = 7;
            lblSinhNhat.Text = "Sinh nhật:";
            // 
            // cmbGioiTinh
            // 
            cmbGioiTinh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbGioiTinh.BackColor = Color.FromArgb(44, 62, 80);
            cmbGioiTinh.FlatStyle = FlatStyle.Flat;
            cmbGioiTinh.Font = new Font("Segoe UI", 9.75F);
            cmbGioiTinh.ForeColor = Color.White;
            cmbGioiTinh.FormattingEnabled = true;
            cmbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbGioiTinh.Location = new Point(157, 126);
            cmbGioiTinh.Name = "cmbGioiTinh";
            cmbGioiTinh.Size = new Size(427, 29);
            cmbGioiTinh.TabIndex = 6;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGioiTinh.ForeColor = Color.FromArgb(189, 195, 199);
            lblGioiTinh.Location = new Point(25, 126);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(79, 23);
            lblGioiTinh.TabIndex = 5;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtID.BackColor = Color.FromArgb(44, 62, 80);
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtID.ForeColor = Color.White;
            txtID.Location = new Point(157, 81);
            txtID.Name = "txtID";
            txtID.Size = new Size(427, 29);
            txtID.TabIndex = 4;
            txtID.TextChanged += txtID_TextChanged;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblID.ForeColor = Color.FromArgb(189, 195, 199);
            lblID.Location = new Point(25, 81);
            lblID.Name = "lblID";
            lblID.Size = new Size(125, 23);
            lblID.TabIndex = 3;
            lblID.Text = "ID người dùng:";
            // 
            // txtTenNguoiDung
            // 
            txtTenNguoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenNguoiDung.BackColor = Color.FromArgb(44, 62, 80);
            txtTenNguoiDung.BorderStyle = BorderStyle.FixedSingle;
            txtTenNguoiDung.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenNguoiDung.ForeColor = Color.White;
            txtTenNguoiDung.Location = new Point(157, 36);
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(427, 29);
            txtTenNguoiDung.TabIndex = 2;
            // 
            // lblTenNguoiDung
            // 
            lblTenNguoiDung.AutoSize = true;
            lblTenNguoiDung.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenNguoiDung.ForeColor = Color.FromArgb(189, 195, 199);
            lblTenNguoiDung.Location = new Point(25, 36);
            lblTenNguoiDung.Name = "lblTenNguoiDung";
            lblTenNguoiDung.Size = new Size(134, 23);
            lblTenNguoiDung.TabIndex = 1;
            lblTenNguoiDung.Text = "Tên người dùng:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(3, -3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(279, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thông Tin Người Dùng";
            // 
            // Uservip
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(885, 675);
            Controls.Add(panelDetails);
            Controls.Add(panelProfile);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(800, 580);
            Name = "Uservip";
            Text = "Thông Tin User VIP";
            panelProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
        private System.Windows.Forms.Label lblTenNguoiDung;
        private System.Windows.Forms.ComboBox cmbGioiTinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpSinhNhat;
        private System.Windows.Forms.Label lblSinhNhat;
        private System.Windows.Forms.TextBox txtHocVan;
        private System.Windows.Forms.Label lblHocVan;
        private System.Windows.Forms.TextBox txtCongViec;
        private System.Windows.Forms.Label lblCongViec;
        private System.Windows.Forms.TextBox txtSoThich;
        private System.Windows.Forms.Label lblSoThich;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblVipBadge;
        private System.Windows.Forms.Label lblUserID_Profile;
        private System.Windows.Forms.Button btnChangeAvatar;
        private System.Windows.Forms.Label lblLogo;
    }
}