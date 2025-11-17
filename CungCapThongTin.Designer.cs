namespace LOGIN
{
    partial class CungCapThongTin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblTitle = new Label();
            picAvatar = new PictureBox();
            btnUploadAvatar = new RoundedButton();
            lblName = new Label();
            txtName = new TextBox();
            lblGender = new Label();
            cbGender = new ComboBox();
            lblAge = new Label();
            numAge = new NumericUpDown();
            lblBirthday = new Label();
            dateBirthday = new DateTimePicker();
            lblEducation = new Label();
            txtEducation = new TextBox();
            lblJob = new Label();
            txtJob = new TextBox();
            lblHobby = new Label();
            txtHobby = new TextBox();
            lblHeight = new Label();
            numHeight = new NumericUpDown();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblIntro = new Label();
            txtIntro = new RichTextBox();
            lblPhotos = new Label();
            flowImages = new FlowLayoutPanel();
            btnAddPhoto = new RoundedButton();
            btnSave = new RoundedButton();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(picAvatar);
            panelMain.Controls.Add(btnUploadAvatar);
            panelMain.Controls.Add(lblName);
            panelMain.Controls.Add(txtName);
            panelMain.Controls.Add(lblGender);
            panelMain.Controls.Add(cbGender);
            panelMain.Controls.Add(lblAge);
            panelMain.Controls.Add(numAge);
            panelMain.Controls.Add(lblBirthday);
            panelMain.Controls.Add(dateBirthday);
            panelMain.Controls.Add(lblEducation);
            panelMain.Controls.Add(txtEducation);
            panelMain.Controls.Add(lblJob);
            panelMain.Controls.Add(txtJob);
            panelMain.Controls.Add(lblHobby);
            panelMain.Controls.Add(txtHobby);
            panelMain.Controls.Add(lblHeight);
            panelMain.Controls.Add(numHeight);
            panelMain.Controls.Add(lblAddress);
            panelMain.Controls.Add(txtAddress);
            panelMain.Controls.Add(lblIntro);
            panelMain.Controls.Add(txtIntro);
            panelMain.Controls.Add(lblPhotos);
            panelMain.Controls.Add(flowImages);
            panelMain.Controls.Add(btnAddPhoto);
            panelMain.Controls.Add(btnSave);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1175, 677);
            panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 82, 82);
            lblTitle.Location = new Point(354, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(345, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cung Cấp Thông Tin";
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(180, 80);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 1;
            picAvatar.TabStop = false;
            // 
            // btnUploadAvatar
            // 
            btnUploadAvatar.BackColor = Color.FromArgb(100, 149, 237);
            btnUploadAvatar.CornerRadius = 20;
            btnUploadAvatar.FlatStyle = FlatStyle.Flat;
            btnUploadAvatar.ForeColor = Color.White;
            btnUploadAvatar.Location = new Point(180, 240);
            btnUploadAvatar.Name = "btnUploadAvatar";
            btnUploadAvatar.Size = new Size(150, 35);
            btnUploadAvatar.TabIndex = 2;
            btnUploadAvatar.Text = "Tải ảnh đại diện";
            btnUploadAvatar.UseVisualStyleBackColor = false;
            btnUploadAvatar.Click += btnUploadAvatar_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(40, 300);
            lblName.Name = "lblName";
            lblName.TabIndex = 3;
            lblName.Text = "Tên";
            // 
            // txtName
            // 
            txtName.Location = new Point(200, 300);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 4;
            // 
            // lblGender
            // 
            lblGender.Location = new Point(40, 355);
            lblGender.Name = "lblGender";
            lblGender.TabIndex = 5;
            lblGender.Text = "Giới tính";
            // 
            // cbGender
            // 
            cbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGender.Location = new Point(200, 355);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(250, 28);
            cbGender.TabIndex = 6;
            // 
            // lblAge
            // 
            lblAge.Location = new Point(40, 410);
            lblAge.Name = "lblAge";
            lblAge.TabIndex = 7;
            lblAge.Text = "Tuổi";
            // 
            // numAge
            // 
            numAge.Location = new Point(200, 410);
            numAge.Name = "numAge";
            numAge.TabIndex = 8;
            // 
            // lblBirthday
            // 
            lblBirthday.Location = new Point(40, 465);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.TabIndex = 9;
            lblBirthday.Text = "Sinh nhật";
            // 
            // dateBirthday
            // 
            dateBirthday.Location = new Point(200, 465);
            dateBirthday.Name = "dateBirthday";
            dateBirthday.Size = new Size(250, 27);
            dateBirthday.TabIndex = 10;
            // 
            // lblEducation
            // 
            lblEducation.Location = new Point(40, 520);
            lblEducation.Name = "lblEducation";
            lblEducation.TabIndex = 11;
            lblEducation.Text = "Học vấn";
            // 
            // txtEducation
            // 
            txtEducation.Location = new Point(200, 520);
            txtEducation.Multiline = true;
            txtEducation.Name = "txtEducation";
            txtEducation.Size = new Size(250, 27);
            txtEducation.TabIndex = 12;
            // 
            // lblJob
            // 
            lblJob.Location = new Point(40, 575);
            lblJob.Name = "lblJob";
            lblJob.TabIndex = 13;
            lblJob.Text = "Nghề nghiệp";
            // 
            // txtJob
            // 
            txtJob.Location = new Point(200, 575);
            txtJob.Multiline = true;
            txtJob.Name = "txtJob";
            txtJob.Size = new Size(250, 27);
            txtJob.TabIndex = 14;
            // 
            // lblHobby
            // 
            lblHobby.Location = new Point(599, 300);
            lblHobby.Name = "lblHobby";
            lblHobby.TabIndex = 15;
            lblHobby.Text = "Thói quen";
            // 
            // txtHobby
            // 
            txtHobby.Location = new Point(780, 300);
            txtHobby.Multiline = true;
            txtHobby.Name = "txtHobby";
            txtHobby.Size = new Size(250, 27);
            txtHobby.TabIndex = 16;
            // 
            // lblHeight
            // 
            lblHeight.Location = new Point(599, 355);
            lblHeight.Name = "lblHeight";
            lblHeight.TabIndex = 17;
            lblHeight.Text = "Chiều cao (cm)";
            // 
            // numHeight
            // 
            numHeight.Location = new Point(780, 356);
            numHeight.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.TabIndex = 18;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(599, 414);
            lblAddress.Name = "lblAddress";
            lblAddress.TabIndex = 19;
            lblAddress.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(780, 411);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(250, 27);
            txtAddress.TabIndex = 20;
            // 
            // lblIntro
            // 
            lblIntro.Location = new Point(599, 470);
            lblIntro.Name = "lblIntro";
            lblIntro.TabIndex = 21;
            lblIntro.Text = "Giới thiệu";
            // 
            // txtIntro
            // 
            txtIntro.Location = new Point(780, 470);
            txtIntro.Name = "txtIntro";
            txtIntro.Size = new Size(250, 128);
            txtIntro.TabIndex = 22;
            // 
            // lblPhotos
            // 
            lblPhotos.Location = new Point(599, 80);
            lblPhotos.Name = "lblPhotos";
            lblPhotos.TabIndex = 23;
            lblPhotos.Text = "Ảnh của bạn";
            // 
            // flowImages
            // 
            flowImages.AutoScroll = true;
            flowImages.Location = new Point(721, 80);
            flowImages.Name = "flowImages";
            flowImages.Size = new Size(420, 150);
            flowImages.TabIndex = 24;
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.BackColor = Color.FromArgb(100, 149, 237);
            btnAddPhoto.CornerRadius = 20;
            btnAddPhoto.FlatStyle = FlatStyle.Flat;
            btnAddPhoto.ForeColor = Color.White;
            btnAddPhoto.Location = new Point(862, 236);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(150, 35);
            btnAddPhoto.TabIndex = 25;
            btnAddPhoto.Text = "Thêm ảnh";
            btnAddPhoto.UseVisualStyleBackColor = false;
            btnAddPhoto.Click += btnAddPhoto_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(255, 82, 82);
            btnSave.CornerRadius = 20;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(469, 620);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 45);
            btnSave.TabIndex = 26;
            btnSave.Text = "Lưu thông tin";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // CungCapThongTin
            // 
            ClientSize = new Size(1175, 677);
            Controls.Add(panelMain);
            Name = "CungCapThongTin";
            Text = "Thông tin cá nhân";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.DateTimePicker dateBirthday;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.TextBox txtEducation;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label lblHobby;
        private System.Windows.Forms.TextBox txtHobby;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.RichTextBox txtIntro;
        private System.Windows.Forms.Label lblPhotos;
        private System.Windows.Forms.FlowLayoutPanel flowImages;
        private RoundedButton btnUploadAvatar;
        private RoundedButton btnAddPhoto;
        private RoundedButton btnSave;
    }
}
