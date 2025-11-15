namespace Main_Interface.User_Controls
{
    partial class SuaHoSoUser
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
            label2 = new Label();
            label3 = new Label();
            label11 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            tb_name = new TextBox();
            tb_gioitinh = new TextBox();
            tb_tuoi = new TextBox();
            tb_snhat = new TextBox();
            tb_hocvan = new TextBox();
            tb_nghe = new TextBox();
            tb_thoiquen = new TextBox();
            tb_gioithieu = new TextBox();
            tb_chieucao = new TextBox();
            tb_vitri = new TextBox();
            label12 = new Label();
            label13 = new Label();
            pb_avatar = new PictureBox();
            lv_nhieuAnh = new ListView();
            btn_chonAvatar = new Button();
            btn_chonNhieuAnh = new Button();
            btn_back = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_avatar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(378, 0);
            label1.Name = "label1";
            label1.Size = new Size(439, 62);
            label1.TabIndex = 0;
            label1.Text = " Sửa hồ sơ cá nhân";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 64);
            label2.Name = "label2";
            label2.Size = new Size(89, 31);
            label2.TabIndex = 2;
            label2.Text = "Họ Tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 106);
            label3.Name = "label3";
            label3.Size = new Size(111, 31);
            label3.TabIndex = 3;
            label3.Text = "Giới Tính:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(37, 153);
            label11.Name = "label11";
            label11.Size = new Size(58, 31);
            label11.TabIndex = 22;
            label11.Text = "Tuổi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(37, 204);
            label4.Name = "label4";
            label4.Size = new Size(119, 31);
            label4.TabIndex = 23;
            label4.Text = "Sinh Nhật:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(37, 249);
            label5.Name = "label5";
            label5.Size = new Size(104, 31);
            label5.TabIndex = 24;
            label5.Text = "Học Vấn:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(37, 297);
            label6.Name = "label6";
            label6.Size = new Size(157, 31);
            label6.TabIndex = 25;
            label6.Text = "Nghề Nghiệp:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(37, 347);
            label7.Name = "label7";
            label7.Size = new Size(124, 31);
            label7.TabIndex = 26;
            label7.Text = "Thói Quen:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(38, 395);
            label8.Name = "label8";
            label8.Size = new Size(123, 31);
            label8.TabIndex = 27;
            label8.Text = "Giới Thiệu:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(39, 444);
            label9.Name = "label9";
            label9.Size = new Size(122, 31);
            label9.TabIndex = 28;
            label9.Text = "Chiều Cao:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(39, 495);
            label10.Name = "label10";
            label10.Size = new Size(69, 31);
            label10.TabIndex = 29;
            label10.Text = "Vị Trí:";
            // 
            // tb_name
            // 
            tb_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_name.Location = new Point(224, 61);
            tb_name.Multiline = true;
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(332, 40);
            tb_name.TabIndex = 30;
            // 
            // tb_gioitinh
            // 
            tb_gioitinh.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_gioitinh.Location = new Point(224, 106);
            tb_gioitinh.Multiline = true;
            tb_gioitinh.Name = "tb_gioitinh";
            tb_gioitinh.Size = new Size(332, 40);
            tb_gioitinh.TabIndex = 31;
            // 
            // tb_tuoi
            // 
            tb_tuoi.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_tuoi.Location = new Point(224, 153);
            tb_tuoi.Multiline = true;
            tb_tuoi.Name = "tb_tuoi";
            tb_tuoi.Size = new Size(332, 40);
            tb_tuoi.TabIndex = 32;
            // 
            // tb_snhat
            // 
            tb_snhat.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_snhat.Location = new Point(224, 199);
            tb_snhat.Multiline = true;
            tb_snhat.Name = "tb_snhat";
            tb_snhat.Size = new Size(332, 40);
            tb_snhat.TabIndex = 33;
            // 
            // tb_hocvan
            // 
            tb_hocvan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_hocvan.Location = new Point(224, 248);
            tb_hocvan.Multiline = true;
            tb_hocvan.Name = "tb_hocvan";
            tb_hocvan.Size = new Size(332, 40);
            tb_hocvan.TabIndex = 34;
            // 
            // tb_nghe
            // 
            tb_nghe.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_nghe.Location = new Point(224, 294);
            tb_nghe.Multiline = true;
            tb_nghe.Name = "tb_nghe";
            tb_nghe.Size = new Size(332, 40);
            tb_nghe.TabIndex = 35;
            // 
            // tb_thoiquen
            // 
            tb_thoiquen.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_thoiquen.Location = new Point(224, 344);
            tb_thoiquen.Multiline = true;
            tb_thoiquen.Name = "tb_thoiquen";
            tb_thoiquen.Size = new Size(332, 40);
            tb_thoiquen.TabIndex = 36;
            // 
            // tb_gioithieu
            // 
            tb_gioithieu.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_gioithieu.Location = new Point(224, 392);
            tb_gioithieu.Multiline = true;
            tb_gioithieu.Name = "tb_gioithieu";
            tb_gioithieu.Size = new Size(332, 40);
            tb_gioithieu.TabIndex = 37;
            // 
            // tb_chieucao
            // 
            tb_chieucao.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_chieucao.Location = new Point(224, 440);
            tb_chieucao.Multiline = true;
            tb_chieucao.Name = "tb_chieucao";
            tb_chieucao.Size = new Size(332, 40);
            tb_chieucao.TabIndex = 38;
            // 
            // tb_vitri
            // 
            tb_vitri.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_vitri.Location = new Point(224, 486);
            tb_vitri.Multiline = true;
            tb_vitri.Name = "tb_vitri";
            tb_vitri.Size = new Size(332, 40);
            tb_vitri.TabIndex = 39;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(606, 65);
            label12.Name = "label12";
            label12.Size = new Size(85, 31);
            label12.TabIndex = 40;
            label12.Text = "Avatar:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(606, 248);
            label13.Name = "label13";
            label13.Size = new Size(60, 31);
            label13.TabIndex = 41;
            label13.Text = "Ảnh:";
            // 
            // pb_avatar
            // 
            pb_avatar.Location = new Point(697, 65);
            pb_avatar.Name = "pb_avatar";
            pb_avatar.Size = new Size(348, 155);
            pb_avatar.TabIndex = 42;
            pb_avatar.TabStop = false;
            // 
            // lv_nhieuAnh
            // 
            lv_nhieuAnh.Location = new Point(697, 248);
            lv_nhieuAnh.Name = "lv_nhieuAnh";
            lv_nhieuAnh.Size = new Size(345, 297);
            lv_nhieuAnh.TabIndex = 43;
            lv_nhieuAnh.UseCompatibleStateImageBehavior = false;
            // 
            // btn_chonAvatar
            // 
            btn_chonAvatar.BackColor = SystemColors.ActiveCaption;
            btn_chonAvatar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_chonAvatar.ForeColor = SystemColors.ControlText;
            btn_chonAvatar.Location = new Point(1051, 106);
            btn_chonAvatar.Name = "btn_chonAvatar";
            btn_chonAvatar.Size = new Size(121, 78);
            btn_chonAvatar.TabIndex = 44;
            btn_chonAvatar.Text = "Chọn ảnh";
            btn_chonAvatar.UseVisualStyleBackColor = false;
            // 
            // btn_chonNhieuAnh
            // 
            btn_chonNhieuAnh.BackColor = SystemColors.ActiveCaption;
            btn_chonNhieuAnh.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_chonNhieuAnh.ForeColor = SystemColors.ControlText;
            btn_chonNhieuAnh.Location = new Point(1051, 354);
            btn_chonNhieuAnh.Name = "btn_chonNhieuAnh";
            btn_chonNhieuAnh.Size = new Size(121, 78);
            btn_chonNhieuAnh.TabIndex = 45;
            btn_chonNhieuAnh.Text = "Chọn ảnh";
            btn_chonNhieuAnh.UseVisualStyleBackColor = false;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.DodgerBlue;
            btn_back.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.Location = new Point(37, 553);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(167, 65);
            btn_back.TabIndex = 46;
            btn_back.Text = "Quay lại";
            btn_back.UseVisualStyleBackColor = false;
            // 
            // SuaHoSoUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateBlue;
            ClientSize = new Size(1184, 645);
            Controls.Add(btn_back);
            Controls.Add(btn_chonNhieuAnh);
            Controls.Add(btn_chonAvatar);
            Controls.Add(lv_nhieuAnh);
            Controls.Add(pb_avatar);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(tb_vitri);
            Controls.Add(tb_chieucao);
            Controls.Add(tb_gioithieu);
            Controls.Add(tb_thoiquen);
            Controls.Add(tb_nghe);
            Controls.Add(tb_hocvan);
            Controls.Add(tb_snhat);
            Controls.Add(tb_tuoi);
            Controls.Add(tb_gioitinh);
            Controls.Add(tb_name);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label11);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SuaHoSoUser";
            Text = "SuaHoSoUser";
            ((System.ComponentModel.ISupportInitialize)pb_avatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label11;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox tb_name;
        private TextBox tb_gioitinh;
        private TextBox tb_tuoi;
        private TextBox tb_snhat;
        private TextBox tb_hocvan;
        private TextBox tb_nghe;
        private TextBox tb_thoiquen;
        private TextBox tb_gioithieu;
        private TextBox tb_chieucao;
        private TextBox tb_vitri;
        private Label label12;
        private Label label13;
        private PictureBox pb_avatar;
        private ListView lv_nhieuAnh;
        private Button btn_chonAvatar;
        private Button btn_chonNhieuAnh;
        private Button btn_back;
    }
}