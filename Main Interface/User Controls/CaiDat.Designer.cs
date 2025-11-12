namespace Main_Interface.User_Controls
{
    partial class CaiDat
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
            btn_csHoSo = new Button();
            btn_doiEmailMk = new Button();
            btn_xoaTk = new Button();
            btn_dsChan = new Button();
            btn_gioithieuUngDung = new Button();
            cb_tatThongbao = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(507, 10);
            label1.Name = "label1";
            label1.Size = new Size(174, 60);
            label1.TabIndex = 0;
            label1.Text = "Cài Đặt";
            // 
            // btn_csHoSo
            // 
            btn_csHoSo.BackColor = Color.FromArgb(100, 149, 237);
            btn_csHoSo.FlatAppearance.BorderSize = 0;
            btn_csHoSo.FlatStyle = FlatStyle.Flat;
            btn_csHoSo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_csHoSo.ForeColor = Color.White;
            btn_csHoSo.Location = new Point(207, 100);
            btn_csHoSo.Name = "btn_csHoSo";
            btn_csHoSo.Size = new Size(748, 60);
            btn_csHoSo.TabIndex = 1;
            btn_csHoSo.Text = "✏️ Chỉnh sửa hồ sơ";
            btn_csHoSo.UseVisualStyleBackColor = false;
            btn_csHoSo.Click += btn_csHoSo_Click;
            btn_csHoSo.Paint += Button_Paint;
            btn_csHoSo.MouseEnter += Button_MouseEnter;
            btn_csHoSo.MouseLeave += Button_MouseLeave;
            // 
            // btn_doiEmailMk
            // 
            btn_doiEmailMk.BackColor = Color.FromArgb(72, 209, 204);
            btn_doiEmailMk.FlatAppearance.BorderSize = 0;
            btn_doiEmailMk.FlatStyle = FlatStyle.Flat;
            btn_doiEmailMk.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_doiEmailMk.ForeColor = Color.White;
            btn_doiEmailMk.Location = new Point(207, 180);
            btn_doiEmailMk.Name = "btn_doiEmailMk";
            btn_doiEmailMk.Size = new Size(748, 60);
            btn_doiEmailMk.TabIndex = 2;
            btn_doiEmailMk.Text = "🔐 Đổi email và mật khẩu";
            btn_doiEmailMk.UseVisualStyleBackColor = false;
            btn_doiEmailMk.Click += btn_doiEmailMk_Click;
            btn_doiEmailMk.Paint += Button_Paint;
            btn_doiEmailMk.MouseEnter += Button_MouseEnter;
            btn_doiEmailMk.MouseLeave += Button_MouseLeave;
            // 
            // btn_xoaTk
            // 
            btn_xoaTk.BackColor = Color.FromArgb(220, 53, 69);
            btn_xoaTk.FlatAppearance.BorderSize = 0;
            btn_xoaTk.FlatStyle = FlatStyle.Flat;
            btn_xoaTk.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xoaTk.ForeColor = Color.White;
            btn_xoaTk.Location = new Point(207, 260);
            btn_xoaTk.Name = "btn_xoaTk";
            btn_xoaTk.Size = new Size(748, 60);
            btn_xoaTk.TabIndex = 3;
            btn_xoaTk.Text = "🗑️ Xóa tài khoản";
            btn_xoaTk.UseVisualStyleBackColor = false;
            btn_xoaTk.Paint += Button_Paint;
            btn_xoaTk.MouseEnter += Button_MouseEnter;
            btn_xoaTk.MouseLeave += Button_MouseLeave;
            // 
            // btn_dsChan
            // 
            btn_dsChan.BackColor = Color.FromArgb(255, 165, 0);
            btn_dsChan.FlatAppearance.BorderSize = 0;
            btn_dsChan.FlatStyle = FlatStyle.Flat;
            btn_dsChan.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_dsChan.ForeColor = Color.White;
            btn_dsChan.Location = new Point(207, 340);
            btn_dsChan.Name = "btn_dsChan";
            btn_dsChan.Size = new Size(748, 60);
            btn_dsChan.TabIndex = 4;
            btn_dsChan.Text = "🚫 Danh sách chặn";
            btn_dsChan.UseVisualStyleBackColor = false;
            btn_dsChan.Click += btn_dsChan_Click;
            btn_dsChan.Paint += Button_Paint;
            btn_dsChan.MouseEnter += Button_MouseEnter;
            btn_dsChan.MouseLeave += Button_MouseLeave;
            // 
            // btn_gioithieuUngDung
            // 
            btn_gioithieuUngDung.BackColor = Color.FromArgb(108, 117, 125);
            btn_gioithieuUngDung.FlatAppearance.BorderSize = 0;
            btn_gioithieuUngDung.FlatStyle = FlatStyle.Flat;
            btn_gioithieuUngDung.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_gioithieuUngDung.ForeColor = Color.White;
            btn_gioithieuUngDung.Location = new Point(207, 500);
            btn_gioithieuUngDung.Name = "btn_gioithieuUngDung";
            btn_gioithieuUngDung.Size = new Size(748, 60);
            btn_gioithieuUngDung.TabIndex = 5;
            btn_gioithieuUngDung.Text = "ℹ️ Giới thiệu ứng dụng";
            btn_gioithieuUngDung.UseVisualStyleBackColor = false;
            btn_gioithieuUngDung.Click += btn_gioithieuUngDung_Click;
            btn_gioithieuUngDung.Paint += Button_Paint;
            btn_gioithieuUngDung.MouseEnter += Button_MouseEnter;
            btn_gioithieuUngDung.MouseLeave += Button_MouseLeave;
            // 
            // cb_tatThongbao
            // 
            cb_tatThongbao.Appearance = Appearance.Button;
            cb_tatThongbao.BackColor = Color.FromArgb(153, 102, 255);
            cb_tatThongbao.FlatAppearance.BorderSize = 0;
            cb_tatThongbao.FlatAppearance.CheckedBackColor = Color.FromArgb(102, 51, 204);
            cb_tatThongbao.FlatStyle = FlatStyle.Flat;
            cb_tatThongbao.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cb_tatThongbao.ForeColor = Color.White;
            cb_tatThongbao.Location = new Point(207, 420);
            cb_tatThongbao.Name = "cb_tatThongbao";
            cb_tatThongbao.Size = new Size(748, 60);
            cb_tatThongbao.TabIndex = 9;
            cb_tatThongbao.Text = "🔔 Tắt Thông Báo";
            cb_tatThongbao.TextAlign = ContentAlignment.MiddleCenter;
            cb_tatThongbao.UseVisualStyleBackColor = false;
            cb_tatThongbao.Paint += Button_Paint;
            cb_tatThongbao.MouseEnter += Button_MouseEnter;
            cb_tatThongbao.MouseLeave += Button_MouseLeave;
            // 
            // CaiDat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            Controls.Add(cb_tatThongbao);
            Controls.Add(btn_gioithieuUngDung);
            Controls.Add(btn_dsChan);
            Controls.Add(btn_xoaTk);
            Controls.Add(btn_doiEmailMk);
            Controls.Add(btn_csHoSo);
            Controls.Add(label1);
            Name = "CaiDat";
            Size = new Size(1193, 642);
            Load += CaiDat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_csHoSo;
        private Button btn_doiEmailMk;
        private Button btn_xoaTk;
        private Button btn_dsChan;
        private Button btn_gioithieuUngDung;
        private Button btn_tatthongbao;
        private CheckBox cb_tatThongbao;
    }
}