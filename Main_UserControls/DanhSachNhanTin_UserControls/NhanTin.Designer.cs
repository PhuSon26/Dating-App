namespace Main_Interface.User_Controls
{
    partial class NhanTin
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
            panelHeader = new Panel();
            pb_avatar = new PictureBox();
            btn_goiVideo = new Button();
            btn_goi = new Button();
            tb_userName = new TextBox();
            btn_back = new Button();
            flPanel_tinNhan = new FlowLayoutPanel();
            tb_message = new TextBox();
            btn = new Button();
            btn_anh = new Button();
            btn_icon = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_avatar).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(pb_avatar);
            panelHeader.Controls.Add(btn_goiVideo);
            panelHeader.Controls.Add(btn_goi);
            panelHeader.Controls.Add(tb_userName);
            panelHeader.Controls.Add(btn_back);
            panelHeader.Location = new Point(-1, 2);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1040, 56);
            panelHeader.TabIndex = 0;
           // panelHeader.Paint += this.panelHeader_Paint;
            // 
            // pb_avatar
            // 
            pb_avatar.Location = new Point(196, -2);
            pb_avatar.Margin = new Padding(3, 2, 3, 2);
            pb_avatar.Name = "pb_avatar";
            pb_avatar.Size = new Size(122, 57);
            pb_avatar.TabIndex = 0;
            pb_avatar.TabStop = false;
            // 
            // btn_goiVideo
            // 
            btn_goiVideo.BackColor = Color.Cyan;
            btn_goiVideo.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_goiVideo.Location = new Point(933, -2);
            btn_goiVideo.Margin = new Padding(3, 2, 3, 2);
            btn_goiVideo.Name = "btn_goiVideo";
            btn_goiVideo.Size = new Size(108, 57);
            btn_goiVideo.TabIndex = 3;
            btn_goiVideo.Text = "📹";
            btn_goiVideo.UseVisualStyleBackColor = false;
            // 
            // btn_goi
            // 
            btn_goi.BackColor = Color.Lime;
            btn_goi.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_goi.ForeColor = SystemColors.ControlText;
            btn_goi.Location = new Point(829, -2);
            btn_goi.Margin = new Padding(3, 2, 3, 2);
            btn_goi.Name = "btn_goi";
            btn_goi.Size = new Size(108, 57);
            btn_goi.TabIndex = 2;
            btn_goi.Text = "📞";
            btn_goi.UseVisualStyleBackColor = false;
            // 
            // tb_userName
            // 
            tb_userName.Location = new Point(316, 0);
            tb_userName.Margin = new Padding(3, 2, 3, 2);
            tb_userName.Multiline = true;
            tb_userName.Name = "tb_userName";
            tb_userName.Size = new Size(515, 56);
            tb_userName.TabIndex = 1;
            // 
            // btn_back
            // 
            btn_back.AllowDrop = true;
            btn_back.BackColor = SystemColors.ActiveCaption;
            btn_back.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.Location = new Point(0, -18);
            btn_back.Margin = new Padding(3, 2, 3, 2);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(198, 78);
            btn_back.TabIndex = 0;
            btn_back.Text = "⬅";
            btn_back.UseVisualStyleBackColor = false;
            // 
            // flPanel_tinNhan
            // 
            flPanel_tinNhan.Location = new Point(-1, 59);
            flPanel_tinNhan.Margin = new Padding(3, 2, 3, 2);
            flPanel_tinNhan.Name = "flPanel_tinNhan";
            flPanel_tinNhan.Size = new Size(1040, 344);
            flPanel_tinNhan.TabIndex = 1;
           // flPanel_tinNhan.Paint += flPanel_tinNhan_Paint;
            // 
            // tb_message
            // 
            tb_message.Location = new Point(217, 407);
            tb_message.Margin = new Padding(3, 2, 3, 2);
            tb_message.Multiline = true;
            tb_message.Name = "tb_message";
            tb_message.Size = new Size(727, 43);
            tb_message.TabIndex = 4;
            // 
            // btn
            // 
            btn.BackColor = SystemColors.MenuHighlight;
            btn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn.Location = new Point(932, 404);
            btn.Margin = new Padding(3, 2, 3, 2);
            btn.Name = "btn";
            btn.Size = new Size(108, 42);
            btn.TabIndex = 0;
            btn.Text = "Gửi";
            btn.UseVisualStyleBackColor = false;
            // 
            // btn_anh
            // 
            btn_anh.BackColor = SystemColors.MenuHighlight;
            btn_anh.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_anh.Location = new Point(-1, 404);
            btn_anh.Margin = new Padding(3, 2, 3, 2);
            btn_anh.Name = "btn_anh";
            btn_anh.Size = new Size(108, 42);
            btn_anh.TabIndex = 5;
            btn_anh.Text = "Ảnh";
            btn_anh.UseVisualStyleBackColor = false;
            // 
            // btn_icon
            // 
            btn_icon.BackColor = SystemColors.MenuHighlight;
            btn_icon.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_icon.Location = new Point(103, 404);
            btn_icon.Margin = new Padding(3, 2, 3, 2);
            btn_icon.Name = "btn_icon";
            btn_icon.Size = new Size(108, 42);
            btn_icon.TabIndex = 6;
            btn_icon.Text = "Icon";
            btn_icon.UseVisualStyleBackColor = false;
            // 
            // NhanTin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_icon);
            Controls.Add(btn_anh);
            Controls.Add(btn);
            Controls.Add(tb_message);
            Controls.Add(flPanel_tinNhan);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NhanTin";
            Size = new Size(1040, 445);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_avatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Button btn_back;
        private Button btn_goi;
        private TextBox tb_userName;
        private Button btn_goiVideo;
        private PictureBox pb_avatar;
        private FlowLayoutPanel flPanel_tinNhan;
        private Button btn;
        private TextBox tb_message;
        private Button btn_anh;
        private Button btn_icon;
    }
}