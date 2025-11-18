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
            label1 = new Label();
            pb_avatar = new PictureBox();
            btn_goiVideo = new Button();
            btn_goi = new Button();
            tb_userName = new TextBox();
            btn_back = new Button();
            flPanel_tinNhan = new FlowLayoutPanel();
            flpMessages = new FlowLayoutPanel();
            tb_message = new TextBox();
            btn = new Button();
            btn_anh = new Button();
            btn_icon = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_avatar).BeginInit();
            flPanel_tinNhan.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(pb_avatar);
            panelHeader.Controls.Add(btn_goiVideo);
            panelHeader.Controls.Add(btn_goi);
            panelHeader.Controls.Add(tb_userName);
            panelHeader.Controls.Add(btn_back);
            panelHeader.Location = new Point(-1, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1189, 74);
            panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.CausesValidation = false;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(650, 18);
            label1.Name = "label1";
            label1.Size = new Size(281, 46);
            label1.TabIndex = 4;
            label1.Text = "💖 SynHeart 💖";
            // 
            // pb_avatar
            // 
            pb_avatar.Location = new Point(155, 4);
            pb_avatar.Name = "pb_avatar";
            pb_avatar.Size = new Size(116, 76);
            pb_avatar.TabIndex = 0;
            pb_avatar.TabStop = false;
            // 
            // btn_goiVideo
            // 
            btn_goiVideo.BackColor = Color.Cyan;
            btn_goiVideo.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_goiVideo.Location = new Point(1066, -2);
            btn_goiVideo.Name = "btn_goiVideo";
            btn_goiVideo.Size = new Size(123, 76);
            btn_goiVideo.TabIndex = 3;
            btn_goiVideo.Text = "📹";
            btn_goiVideo.UseVisualStyleBackColor = false;
            // 
            // btn_goi
            // 
            btn_goi.BackColor = Color.Lime;
            btn_goi.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_goi.ForeColor = SystemColors.ControlText;
            btn_goi.Location = new Point(947, -2);
            btn_goi.Name = "btn_goi";
            btn_goi.Size = new Size(123, 76);
            btn_goi.TabIndex = 2;
            btn_goi.Text = "📞";
            btn_goi.UseVisualStyleBackColor = false;
            // 
            // tb_userName
            // 
            tb_userName.Location = new Point(267, 3);
            tb_userName.Multiline = true;
            tb_userName.Name = "tb_userName";
            tb_userName.Size = new Size(353, 74);
            tb_userName.TabIndex = 1;
            // 
            // btn_back
            // 
            btn_back.AllowDrop = true;
            btn_back.BackColor = SystemColors.ActiveCaption;
            btn_back.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.Location = new Point(0, -24);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(161, 104);
            btn_back.TabIndex = 0;
            btn_back.Text = "⬅";
            btn_back.UseVisualStyleBackColor = false;
            // 
            // flPanel_tinNhan
            // 
            flPanel_tinNhan.BackgroundImage = Properties.Resources.images__1_;
            flPanel_tinNhan.BackgroundImageLayout = ImageLayout.Stretch;
            flPanel_tinNhan.Controls.Add(flpMessages);
            flPanel_tinNhan.Location = new Point(-1, 79);
            flPanel_tinNhan.Name = "flPanel_tinNhan";
            flPanel_tinNhan.Size = new Size(1189, 458);
            flPanel_tinNhan.TabIndex = 1;
            // 
            // flpMessages
            // 
            flpMessages.AutoScroll = true;
            flpMessages.BackColor = Color.Transparent;
            flpMessages.FlowDirection = FlowDirection.TopDown;
            flpMessages.Location = new Point(3, 3);
            flpMessages.Name = "flpMessages";
            flpMessages.Size = new Size(1184, 450);
            flpMessages.TabIndex = 0;
            flpMessages.WrapContents = false;
            // 
            // tb_message
            // 
            tb_message.Location = new Point(248, 543);
            tb_message.Multiline = true;
            tb_message.Name = "tb_message";
            tb_message.Size = new Size(830, 56);
            tb_message.TabIndex = 4;
            // 
            // btn
            // 
            btn.BackColor = SystemColors.MenuHighlight;
            btn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn.Location = new Point(1065, 538);
            btn.Name = "btn";
            btn.Size = new Size(124, 56);
            btn.TabIndex = 0;
            btn.Text = "Gửi ➤";
            btn.UseVisualStyleBackColor = false;
            // 
            // btn_anh
            // 
            btn_anh.BackColor = SystemColors.Info;
            btn_anh.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_anh.ForeColor = Color.IndianRed;
            btn_anh.Location = new Point(-1, 538);
            btn_anh.Name = "btn_anh";
            btn_anh.Size = new Size(124, 56);
            btn_anh.TabIndex = 5;
            btn_anh.Text = "Ảnh 🖼️";
            btn_anh.UseVisualStyleBackColor = false;
            // 
            // btn_icon
            // 
            btn_icon.BackColor = SystemColors.MenuHighlight;
            btn_icon.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_icon.ForeColor = Color.DarkGreen;
            btn_icon.Location = new Point(118, 538);
            btn_icon.Name = "btn_icon";
            btn_icon.Size = new Size(124, 56);
            btn_icon.TabIndex = 6;
            btn_icon.Text = "Icon 😊";
            btn_icon.UseVisualStyleBackColor = false;
            // 
            // NhanTin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_icon);
            Controls.Add(btn_anh);
            Controls.Add(btn);
            Controls.Add(tb_message);
            Controls.Add(flPanel_tinNhan);
            Controls.Add(panelHeader);
            Name = "NhanTin";
            Size = new Size(1189, 593);
            Load += NhanTin_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_avatar).EndInit();
            flPanel_tinNhan.ResumeLayout(false);
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
        private Label label1;
        private FlowLayoutPanel flpMessages;
    }
}