namespace Dating_app_nhom3
{
    partial class Thongtinuser : UserControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            ptb_avt = new PictureBox();
            tb_tennguoidung = new TextBox();
            btn_chinhsua = new Button();
            label_id = new Label();
            tb_id = new TextBox();
            label_gioitinh = new Label();
            cb_gioitinh = new ComboBox();
            label_sinhnhat = new Label();
            dtp_sinhnhat = new DateTimePicker();
            label_diachi = new Label();
            tb_diachi = new TextBox();
            label_sothich = new Label();
            tb_sothich = new TextBox();
            label_congviec = new Label();
            tb_congviec = new TextBox();
            label_hocvan = new Label();
            tb_hocvan = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)ptb_avt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(50, 500);
            label1.Name = "label1";
            label1.Size = new Size(0, 23);
            label1.TabIndex = 19;
            // 
            // ptb_avt
            // 
            ptb_avt.BorderStyle = BorderStyle.FixedSingle;
            ptb_avt.Cursor = Cursors.Hand;
            ptb_avt.Location = new Point(50, 80);
            ptb_avt.Name = "ptb_avt";
            ptb_avt.Size = new Size(170, 170);
            ptb_avt.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_avt.TabIndex = 1;
            ptb_avt.TabStop = false;
            // 
            // tb_tennguoidung
            // 
            tb_tennguoidung.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tb_tennguoidung.Location = new Point(515, 66);
            tb_tennguoidung.Multiline = true;
            tb_tennguoidung.Name = "tb_tennguoidung";
            tb_tennguoidung.PlaceholderText = "Tên người dùng";
            tb_tennguoidung.Size = new Size(320, 37);
            tb_tennguoidung.TabIndex = 3;
            // 
            // btn_chinhsua
            // 
            btn_chinhsua.BackColor = Color.FromArgb(255, 190, 200);
            btn_chinhsua.FlatAppearance.BorderSize = 0;
            btn_chinhsua.FlatStyle = FlatStyle.Flat;
            btn_chinhsua.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_chinhsua.Location = new Point(372, 514);
            btn_chinhsua.Name = "btn_chinhsua";
            btn_chinhsua.Size = new Size(463, 50);
            btn_chinhsua.TabIndex = 18;
            btn_chinhsua.Text = "✏️ Chỉnh sửa hồ sơ";
            btn_chinhsua.UseVisualStyleBackColor = false;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(372, 127);
            label_id.Name = "label_id";
            label_id.Size = new Size(125, 23);
            label_id.TabIndex = 4;
            label_id.Text = "ID người dùng:";
            // 
            // tb_id
            // 
            tb_id.Location = new Point(515, 127);
            tb_id.Name = "tb_id";
            tb_id.Size = new Size(320, 30);
            tb_id.TabIndex = 5;
            // 
            // label_gioitinh
            // 
            label_gioitinh.AutoSize = true;
            label_gioitinh.Location = new Point(372, 178);
            label_gioitinh.Name = "label_gioitinh";
            label_gioitinh.Size = new Size(79, 23);
            label_gioitinh.TabIndex = 6;
            label_gioitinh.Text = "Giới tính:";
            // 
            // cb_gioitinh
            // 
            cb_gioitinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cb_gioitinh.Location = new Point(515, 170);
            cb_gioitinh.Name = "cb_gioitinh";
            cb_gioitinh.Size = new Size(320, 31);
            cb_gioitinh.TabIndex = 7;
            // 
            // label_sinhnhat
            // 
            label_sinhnhat.AutoSize = true;
            label_sinhnhat.Location = new Point(372, 226);
            label_sinhnhat.Name = "label_sinhnhat";
            label_sinhnhat.Size = new Size(87, 23);
            label_sinhnhat.TabIndex = 8;
            label_sinhnhat.Text = "Sinh nhật:";
            // 
            // dtp_sinhnhat
            // 
            dtp_sinhnhat.Format = DateTimePickerFormat.Short;
            dtp_sinhnhat.Location = new Point(515, 220);
            dtp_sinhnhat.Name = "dtp_sinhnhat";
            dtp_sinhnhat.Size = new Size(320, 30);
            dtp_sinhnhat.TabIndex = 9;
            // 
            // label_diachi
            // 
            label_diachi.AutoSize = true;
            label_diachi.Location = new Point(372, 283);
            label_diachi.Name = "label_diachi";
            label_diachi.Size = new Size(66, 23);
            label_diachi.TabIndex = 10;
            label_diachi.Text = "Địa chỉ:";
            // 
            // tb_diachi
            // 
            tb_diachi.Location = new Point(515, 280);
            tb_diachi.Name = "tb_diachi";
            tb_diachi.Size = new Size(320, 30);
            tb_diachi.TabIndex = 11;
            // 
            // label_sothich
            // 
            label_sothich.AutoSize = true;
            label_sothich.Location = new Point(372, 341);
            label_sothich.Name = "label_sothich";
            label_sothich.Size = new Size(76, 23);
            label_sothich.TabIndex = 12;
            label_sothich.Text = "Sở thích:";
            // 
            // tb_sothich
            // 
            tb_sothich.Location = new Point(515, 334);
            tb_sothich.Name = "tb_sothich";
            tb_sothich.Size = new Size(320, 30);
            tb_sothich.TabIndex = 13;
            // 
            // label_congviec
            // 
            label_congviec.AutoSize = true;
            label_congviec.Location = new Point(372, 403);
            label_congviec.Name = "label_congviec";
            label_congviec.Size = new Size(89, 23);
            label_congviec.TabIndex = 14;
            label_congviec.Text = "Công việc:";
            // 
            // tb_congviec
            // 
            tb_congviec.Location = new Point(515, 396);
            tb_congviec.Name = "tb_congviec";
            tb_congviec.Size = new Size(320, 30);
            tb_congviec.TabIndex = 15;
            // 
            // label_hocvan
            // 
            label_hocvan.AutoSize = true;
            label_hocvan.Location = new Point(372, 464);
            label_hocvan.Name = "label_hocvan";
            label_hocvan.Size = new Size(76, 23);
            label_hocvan.TabIndex = 16;
            label_hocvan.Text = "Học vấn:";
            // 
            // tb_hocvan
            // 
            tb_hocvan.Location = new Point(515, 457);
            tb_hocvan.Name = "tb_hocvan";
            tb_hocvan.Size = new Size(320, 30);
            tb_hocvan.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.FromArgb(255, 100, 120);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(142, 23);
            label2.TabIndex = 0;
            label2.Text = "💖 SynHeart 💖";
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 8F);
            button1.Location = new Point(75, 260);
            button1.Name = "button1";
            button1.Size = new Size(120, 46);
            button1.TabIndex = 2;
            button1.Text = "Thay đổi Avatar";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(255, 100, 120);
            label3.Location = new Point(458, 18);
            label3.Name = "label3";
            label3.Size = new Size(262, 31);
            label3.TabIndex = 20;
            label3.Text = "Thông Tin Người Dùng";
            // 
            // Thongtinuser
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 230, 230);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ptb_avt);
            Controls.Add(button1);
            Controls.Add(tb_tennguoidung);
            Controls.Add(label_id);
            Controls.Add(tb_id);
            Controls.Add(label_gioitinh);
            Controls.Add(cb_gioitinh);
            Controls.Add(label_sinhnhat);
            Controls.Add(dtp_sinhnhat);
            Controls.Add(label_diachi);
            Controls.Add(tb_diachi);
            Controls.Add(label_sothich);
            Controls.Add(tb_sothich);
            Controls.Add(label_congviec);
            Controls.Add(tb_congviec);
            Controls.Add(label_hocvan);
            Controls.Add(tb_hocvan);
            Controls.Add(btn_chinhsua);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            ForeColor = Color.Black;
            Name = "Thongtinuser";
            Size = new Size(1198, 620);
            Load += Thongtinuser_Load;
            ((System.ComponentModel.ISupportInitialize)ptb_avt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox ptb_avt;
        private TextBox tb_tennguoidung;
        private Button btn_chinhsua;
        private Label label_id, label_gioitinh, label_sinhnhat, label_diachi, label_sothich, label_congviec, label_hocvan;
        private TextBox tb_id, tb_diachi, tb_sothich, tb_congviec, tb_hocvan;
        private ComboBox cb_gioitinh;
        private DateTimePicker dtp_sinhnhat;
        private Label label2;
        private Button button1;
        private Label label3;
    }
}
