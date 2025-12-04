using LOGIN;
using static System.Net.WebRequestMethods;

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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            ptb_avt = new PictureBox();
            lb_tennguoidung = new Label();
            cb_chinhsua = new CheckBox();
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
            btn_avatar = new RoundedButton();
            label3 = new Label();
            label_chieucao = new Label();
            num_chieucao = new NumericUpDown();
            label_gioithieu = new Label();
            tb_gioithieu = new TextBox();
            imageListAnh = new ImageList(components);
            btn_themAnh = new RoundedButton();
            flp = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)ptb_avt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_chieucao).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(50, 500);
            label1.Name = "label1";
            label1.Size = new Size(0, 19);
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
            // lb_tennguoidung
            // 
            lb_tennguoidung.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tennguoidung.Location = new Point(450, 60);
            lb_tennguoidung.Name = "tb_tennguoidung";
            lb_tennguoidung.Size = new Size(320, 37);
            lb_tennguoidung.TabIndex = 3;
            lb_tennguoidung.Text = "Anonymous";
            lb_tennguoidung.AutoSize = true;
            // 
            // cb_chinhsua
            // 
            cb_chinhsua.Appearance = Appearance.Button;
            cb_chinhsua.BackColor = Color.FromArgb(255, 190, 200);
            cb_chinhsua.FlatAppearance.BorderSize = 0;
            cb_chinhsua.FlatStyle = FlatStyle.Flat;
            cb_chinhsua.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            cb_chinhsua.Location = new Point(268, 545);
            cb_chinhsua.Name = "cb_chinhsua";
            cb_chinhsua.Size = new Size(436, 50);
            cb_chinhsua.TabIndex = 18;
            cb_chinhsua.Text = "✏️ Chỉnh sửa hồ sơ";
            cb_chinhsua.TextAlign = ContentAlignment.MiddleCenter;
            cb_chinhsua.UseVisualStyleBackColor = false;
            cb_chinhsua.Click += cb_chinhsua_Click;
            // 
            // label_gioitinh
            // 
            label_gioitinh.AutoSize = true;
            label_gioitinh.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_gioitinh.Location = new Point(268, 128);
            label_gioitinh.Name = "label_gioitinh";
            label_gioitinh.Size = new Size(80, 21);
            label_gioitinh.TabIndex = 6;
            label_gioitinh.Text = "Giới tính:";
            // 
            // cb_gioitinh
            // 
            cb_gioitinh.Enabled = false;
            cb_gioitinh.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cb_gioitinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cb_gioitinh.Location = new Point(384, 128);
            cb_gioitinh.Name = "cb_gioitinh";
            cb_gioitinh.Size = new Size(320, 29);
            cb_gioitinh.TabIndex = 7;
            // 
            // label_sinhnhat
            // 
            label_sinhnhat.AutoSize = true;
            label_sinhnhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_sinhnhat.Location = new Point(268, 178);
            label_sinhnhat.Name = "label_sinhnhat";
            label_sinhnhat.Size = new Size(87, 21);
            label_sinhnhat.TabIndex = 8;
            label_sinhnhat.Text = "Sinh nhật:";
            // 
            // dtp_sinhnhat
            // 
            dtp_sinhnhat.Enabled = false;
            dtp_sinhnhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtp_sinhnhat.Format = DateTimePickerFormat.Short;
            dtp_sinhnhat.Location = new Point(384, 178);
            dtp_sinhnhat.Name = "dtp_sinhnhat";
            dtp_sinhnhat.Size = new Size(320, 29);
            dtp_sinhnhat.TabIndex = 9;
            // 
            // label_diachi
            // 
            label_diachi.AutoSize = true;
            label_diachi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_diachi.Location = new Point(268, 231);
            label_diachi.Name = "label_diachi";
            label_diachi.Size = new Size(67, 21);
            label_diachi.TabIndex = 10;
            label_diachi.Text = "Địa chỉ:";
            // 
            // tb_diachi
            // 
            tb_diachi.Enabled = false;
            tb_diachi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_diachi.Location = new Point(384, 231);
            tb_diachi.Name = "tb_diachi";
            tb_diachi.Size = new Size(320, 29);
            tb_diachi.TabIndex = 11;
            // 
            // label_sothich
            // 
            label_sothich.AutoSize = true;
            label_sothich.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_sothich.Location = new Point(268, 278);
            label_sothich.Name = "label_sothich";
            label_sothich.Size = new Size(76, 21);
            label_sothich.TabIndex = 12;
            label_sothich.Text = "Sở thích:";
            // 
            // tb_sothich
            // 
            tb_sothich.Enabled = false;
            tb_sothich.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_sothich.Location = new Point(384, 278);
            tb_sothich.Name = "tb_sothich";
            tb_sothich.Size = new Size(320, 29);
            tb_sothich.TabIndex = 13;
            // 
            // label_congviec
            // 
            label_congviec.AutoSize = true;
            label_congviec.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_congviec.Location = new Point(268, 331);
            label_congviec.Name = "label_congviec";
            label_congviec.Size = new Size(89, 21);
            label_congviec.TabIndex = 14;
            label_congviec.Text = "Công việc:";
            // 
            // tb_congviec
            // 
            tb_congviec.Enabled = false;
            tb_congviec.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_congviec.Location = new Point(384, 328);
            tb_congviec.Name = "tb_congviec";
            tb_congviec.Size = new Size(320, 29);
            tb_congviec.TabIndex = 15;
            // 
            // label_hocvan
            // 
            label_hocvan.AutoSize = true;
            label_hocvan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_hocvan.Location = new Point(268, 381);
            label_hocvan.Name = "label_hocvan";
            label_hocvan.Size = new Size(76, 21);
            label_hocvan.TabIndex = 16;
            label_hocvan.Text = "Học vấn:";
            // 
            // tb_hocvan
            // 
            tb_hocvan.Enabled = false;
            tb_hocvan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_hocvan.Location = new Point(384, 374);
            tb_hocvan.Name = "tb_hocvan";
            tb_hocvan.Size = new Size(320, 29);
            tb_hocvan.TabIndex = 17;
            // 
            // btn_avatar
            // 
            btn_avatar.BackColor = Color.WhiteSmoke;
            btn_avatar.CornerRadius = 20;
            btn_avatar.Enabled = false;
            btn_avatar.FlatStyle = FlatStyle.Popup;
            btn_avatar.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_avatar.ForeColor = Color.White;
            btn_avatar.Location = new Point(50, 260);
            btn_avatar.Name = "btn_avatar";
            btn_avatar.Size = new Size(170, 46);
            btn_avatar.TabIndex = 2;
            btn_avatar.Text = "Đổi Avatar";
            btn_avatar.UseVisualStyleBackColor = false;
            btn_avatar.Click += btn_avatar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(255, 100, 120);
            label3.Location = new Point(380, 10);
            label3.Name = "label3";
            label3.Size = new Size(346, 41);
            label3.TabIndex = 20;
            label3.Text = "Thông Tin Người Dùng";
            // 
            // label_chieucao
            // 
            label_chieucao.AutoSize = true;
            label_chieucao.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_chieucao.Location = new Point(268, 428);
            label_chieucao.Name = "label_chieucao";
            label_chieucao.Size = new Size(89, 21);
            label_chieucao.TabIndex = 21;
            label_chieucao.Text = "Chiều cao:";
            // 
            // num_chieucao
            // 
            num_chieucao.Enabled = false;
            num_chieucao.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_chieucao.Location = new Point(384, 421);
            num_chieucao.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            num_chieucao.Name = "num_chieucao";
            num_chieucao.Size = new Size(320, 29);
            num_chieucao.TabIndex = 22;
            // 
            // label_gioithieu
            // 
            label_gioithieu.AutoSize = true;
            label_gioithieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_gioithieu.Location = new Point(269, 478);
            label_gioithieu.Name = "label_gioithieu";
            label_gioithieu.Size = new Size(89, 21);
            label_gioithieu.TabIndex = 23;
            label_gioithieu.Text = "Giới thiệu:";
            // 
            // tb_gioithieu
            // 
            tb_gioithieu.Enabled = false;
            tb_gioithieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_gioithieu.Location = new Point(384, 469);
            tb_gioithieu.Multiline = true;
            tb_gioithieu.Name = "tb_gioithieu";
            tb_gioithieu.PlaceholderText = "Nhập giới thiệu bản thân";
            tb_gioithieu.Size = new Size(320, 61);
            tb_gioithieu.TabIndex = 24;
            // 
            // imageListAnh
            // 
            imageListAnh.ColorDepth = ColorDepth.Depth32Bit;
            imageListAnh.ImageSize = new Size(120, 120);
            imageListAnh.TransparentColor = Color.Transparent;
            // 
            // btn_themAnh
            // 
            btn_themAnh.BackColor = Color.WhiteSmoke;
            btn_themAnh.CornerRadius = 20;
            btn_themAnh.Enabled = false;
            btn_themAnh.FlatStyle = FlatStyle.Flat;
            btn_themAnh.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_themAnh.ForeColor = Color.White;
            btn_themAnh.Location = new Point(747, 545);
            btn_themAnh.Name = "btn_themAnh";
            btn_themAnh.Size = new Size(300, 50);
            btn_themAnh.TabIndex = 23;
            btn_themAnh.Text = "➕ Thêm ảnh";
            btn_themAnh.UseVisualStyleBackColor = false;
            btn_themAnh.Click += btn_themAnh_Click;
            // 
            // flp
            // 
            flp.AutoScroll = true;
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Location = new Point(747, 66);
            flp.Name = "flp";
            flp.Size = new Size(320, 460);
            flp.TabIndex = 22;
            flp.WrapContents = false;
            // 
            // Thongtinuser
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            Controls.Add(label_chieucao);
            Controls.Add(flp);
            Controls.Add(btn_themAnh);
            Controls.Add(num_chieucao);
            Controls.Add(label_gioithieu);
            Controls.Add(tb_gioithieu);
            Controls.Add(label3);
            Controls.Add(ptb_avt);
            Controls.Add(btn_avatar);
            Controls.Add(lb_tennguoidung);
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
            Controls.Add(cb_chinhsua);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            ForeColor = Color.Black;
            Name = "Thongtinuser";
            Size = new Size(1198, 620);
            ((System.ComponentModel.ISupportInitialize)ptb_avt).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_chieucao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox ptb_avt;
        private Label lb_tennguoidung;
        private CheckBox cb_chinhsua;
        private Label label_gioitinh, label_sinhnhat, label_diachi, label_sothich, label_congviec, label_hocvan;
        private TextBox tb_diachi, tb_sothich, tb_congviec, tb_hocvan;
        private Label label_chieucao, label_gioithieu;
        private TextBox tb_gioithieu;
        private NumericUpDown num_chieucao;
        private ComboBox cb_gioitinh;
        private DateTimePicker dtp_sinhnhat;
        private RoundedButton btn_avatar;
        private Label label3;
        private RoundedButton btn_themAnh;
        private ImageList imageListAnh;
        private FlowLayoutPanel flp;
    }
}
