namespace Main_Interface.User_Controls
{
    partial class GioiThieuUngDung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private Label label1;

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

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GioiThieuUngDung));
            label1 = new Label();
            btn_back = new RoundedButton();
            panel1 = new Panel();
            lblGioiThieu = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(400, 20);
            label1.Name = "label1";
            label1.Size = new Size(418, 54);
            label1.TabIndex = 0;
            label1.Text = "Giới Thiệu Ứng Dụng";
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(72, 209, 204);
            btn_back.CornerRadius = 30;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(-5, -54);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(148, 125);
            btn_back.TabIndex = 0;
            btn_back.Text = "🠔";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(lblGioiThieu);
            panel1.Location = new Point(22, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(1129, 708);
            panel1.TabIndex = 1;
            // lblGioiThieu
            lblGioiThieu.Font = new Font("Segoe UI", 16F, FontStyle.Regular);
            lblGioiThieu.ForeColor = Color.Black;
            lblGioiThieu.BackColor = Color.Transparent; // trong suốt
            lblGioiThieu.TextAlign = ContentAlignment.TopCenter; // canh giữa ngang
            lblGioiThieu.MaximumSize = new Size(panel1.Width - 20, 0);
            lblGioiThieu.AutoSize = true;
            lblGioiThieu.Padding = new Padding(10); // cách viền panel
            lblGioiThieu.Text =
            "🌸 Chào mừng bạn đến với SynHeart! 🌸\n" +
            "SynHeart là ứng dụng hẹn hò hiện đại, nơi bạn có thể kết nối với những người có cùng sở thích, chia sẻ niềm vui, và tìm thấy một nửa đích thực của mình. " +
            "Chúng tôi tin rằng mỗi người đều xứng đáng tìm thấy hạnh phúc, và SynHeart ra đời với sứ mệnh tạo ra một môi trường an toàn, thân thiện và đầy cảm hứng cho việc kết nối.\n" +

            "❤️ Với SynHeart, bạn có thể:\n" +
            "- Tìm kiếm và kết nối với những người phù hợp dựa trên sở thích và giá trị chung.\n" +
            "- Gửi và nhận lời nhắn chân thành, thể hiện cá tính và sự quan tâm.\n" +

            "💌 Chúng tôi xin gửi lời cảm ơn sâu sắc đến bạn – những người đã tin tưởng và lựa chọn SynHeart. " +
            "Mỗi lượt kết nối, mỗi câu chuyện tình yêu bắt đầu từ app đều là niềm tự hào và động lực để chúng tôi không ngừng cải tiến và mang đến trải nghiệm tốt nhất.\n" +

            "✨ Chúng tôi hy vọng SynHeart sẽ giúp bạn mở ra những mối quan hệ ý nghĩa, gặp gỡ những người bạn đáng yêu, và tạo nên những kỷ niệm đáng nhớ.\n" +

            "🌟 Xin chúc bạn một hành trình hẹn hò vui vẻ, tràn đầy tiếng cười, và tìm thấy tình yêu đích thực. Hãy mở lòng, trải nghiệm và tận hưởng từng khoảnh khắc trên SynHeart!\n" +
            "🎉 Chào mừng bạn đến với SynHeart – nơi trái tim tìm thấy nhau! 💖";

            panel1.Controls.Add(lblGioiThieu);            // 
            // GioiThieuUngDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            Controls.Add(btn_back);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "GioiThieuUngDung";
            Size = new Size(1175, 595);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedButton btn_back;
        private Panel panel1;
        private Label lblGioiThieu;
    }
}