namespace Main_Interface.User_Controls
{
    partial class NapVIP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label featuresTitle;
        private System.Windows.Forms.Panel featurePanel1;
        private System.Windows.Forms.Panel featurePanel2;
        private System.Windows.Forms.Panel featurePanel3;
        private System.Windows.Forms.Panel featurePanel4;
        private System.Windows.Forms.Label featureLabel1;
        private System.Windows.Forms.Label featureLabel2;
        private System.Windows.Forms.Label featureLabel3;
        private System.Windows.Forms.Label featureLabel4;
        private System.Windows.Forms.Label packageTitle;
        private GlossyButton btnVIP1Month;
        private GlossyButton btnVIP3Months;
        private GlossyButton btnVIP6Months;
        private GlossyButton btnVIP1Year;

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            titleLabel = new Label();
            contentPanel = new Panel();
            featuresTitle = new Label();
            featurePanel1 = new Panel();
            featureLabel1 = new Label();
            featurePanel2 = new Panel();
            featureLabel2 = new Label();
            featurePanel3 = new Panel();
            featureLabel3 = new Label();
            featurePanel4 = new Panel();
            featureLabel4 = new Label();
            packageTitle = new Label();
            btnVIP1Month = new GlossyButton();
            btnVIP3Months = new GlossyButton();
            btnVIP6Months = new GlossyButton();
            btnVIP1Year = new GlossyButton();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            featurePanel1.SuspendLayout();
            featurePanel2.SuspendLayout();
            featurePanel3.SuspendLayout();
            featurePanel4.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1193, 100);
            headerPanel.TabIndex = 0;
            headerPanel.Paint += HeaderPanel_Paint;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(380, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(455, 62);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "♥ Upgrade to VIP ♥";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.Transparent;
            contentPanel.Controls.Add(featuresTitle);
            contentPanel.Controls.Add(featurePanel1);
            contentPanel.Controls.Add(featurePanel2);
            contentPanel.Controls.Add(featurePanel3);
            contentPanel.Controls.Add(featurePanel4);
            contentPanel.Controls.Add(packageTitle);
            contentPanel.Controls.Add(btnVIP1Month);
            contentPanel.Controls.Add(btnVIP3Months);
            contentPanel.Controls.Add(btnVIP6Months);
            contentPanel.Controls.Add(btnVIP1Year);
            contentPanel.Location = new Point(52, 189);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1086, 525);
            contentPanel.TabIndex = 1;
            // 
            // featuresTitle
            // 
            featuresTitle.AutoSize = true;
            featuresTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            featuresTitle.ForeColor = Color.FromArgb(139, 69, 19);
            featuresTitle.Location = new Point(20, 12);
            featuresTitle.Name = "featuresTitle";
            featuresTitle.Size = new Size(249, 37);
            featuresTitle.TabIndex = 0;
            featuresTitle.Text = "Các tính năng VIP:";
            // 
            // featurePanel1
            // 
            featurePanel1.BackColor = Color.White;
            featurePanel1.Controls.Add(featureLabel1);
            featurePanel1.Location = new Point(20, 75);
            featurePanel1.Margin = new Padding(3, 4, 3, 4);
            featurePanel1.Name = "featurePanel1";
            featurePanel1.Size = new Size(350, 62);
            featurePanel1.TabIndex = 1;
            featurePanel1.Paint += FeaturePanel_Paint;
            // 
            // featureLabel1
            // 
            featureLabel1.AutoSize = true;
            featureLabel1.BackColor = Color.Transparent;
            featureLabel1.Font = new Font("Segoe UI", 12F);
            featureLabel1.ForeColor = Color.FromArgb(70, 70, 70);
            featureLabel1.Location = new Point(15, 16);
            featureLabel1.Name = "featureLabel1";
            featureLabel1.Size = new Size(221, 28);
            featureLabel1.TabIndex = 0;
            featureLabel1.Text = "✓ Biết được ai thích bạn";
            // 
            // featurePanel2
            // 
            featurePanel2.BackColor = Color.White;
            featurePanel2.Controls.Add(featureLabel2);
            featurePanel2.Location = new Point(20, 162);
            featurePanel2.Margin = new Padding(3, 4, 3, 4);
            featurePanel2.Name = "featurePanel2";
            featurePanel2.Size = new Size(350, 62);
            featurePanel2.TabIndex = 2;
            featurePanel2.Paint += FeaturePanel_Paint;
            // 
            // featureLabel2
            // 
            featureLabel2.AutoSize = true;
            featureLabel2.BackColor = Color.Transparent;
            featureLabel2.Font = new Font("Segoe UI", 12F);
            featureLabel2.ForeColor = Color.FromArgb(70, 70, 70);
            featureLabel2.Location = new Point(15, 16);
            featureLabel2.Name = "featureLabel2";
            featureLabel2.Size = new Size(314, 28);
            featureLabel2.TabIndex = 0;
            featureLabel2.Text = "✓ Nhắn trực tiếp không cần Match";
            // 
            // featurePanel3
            // 
            featurePanel3.BackColor = Color.White;
            featurePanel3.Controls.Add(featureLabel3);
            featurePanel3.Location = new Point(20, 250);
            featurePanel3.Margin = new Padding(3, 4, 3, 4);
            featurePanel3.Name = "featurePanel3";
            featurePanel3.Size = new Size(350, 62);
            featurePanel3.TabIndex = 3;
            featurePanel3.Paint += FeaturePanel_Paint;
            // 
            // featureLabel3
            // 
            featureLabel3.AutoSize = true;
            featureLabel3.BackColor = Color.Transparent;
            featureLabel3.Font = new Font("Segoe UI", 12F);
            featureLabel3.ForeColor = Color.FromArgb(70, 70, 70);
            featureLabel3.Location = new Point(15, 16);
            featureLabel3.Name = "featureLabel3";
            featureLabel3.Size = new Size(294, 28);
            featureLabel3.TabIndex = 0;
            featureLabel3.Text = "✓ Thả tim vô hạn trong quẹt đôi";
            // 
            // featurePanel4
            // 
            featurePanel4.BackColor = Color.White;
            featurePanel4.Controls.Add(featureLabel4);
            featurePanel4.Location = new Point(20, 338);
            featurePanel4.Margin = new Padding(3, 4, 3, 4);
            featurePanel4.Name = "featurePanel4";
            featurePanel4.Size = new Size(350, 62);
            featurePanel4.TabIndex = 4;
            featurePanel4.Paint += FeaturePanel_Paint;
            // 
            // featureLabel4
            // 
            featureLabel4.AutoSize = true;
            featureLabel4.BackColor = Color.Transparent;
            featureLabel4.Font = new Font("Segoe UI", 12F);
            featureLabel4.ForeColor = Color.FromArgb(70, 70, 70);
            featureLabel4.Location = new Point(15, 19);
            featureLabel4.Name = "featureLabel4";
            featureLabel4.Size = new Size(262, 28);
            featureLabel4.TabIndex = 0;
            featureLabel4.Text = "✓ Mở khóa button siêu thích";
            // 
            // packageTitle
            // 
            packageTitle.AutoSize = true;
            packageTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            packageTitle.ForeColor = Color.FromArgb(139, 69, 19);
            packageTitle.Location = new Point(595, 12);
            packageTitle.Name = "packageTitle";
            packageTitle.Size = new Size(245, 37);
            packageTitle.TabIndex = 5;
            packageTitle.Text = "Chọn loại gói VIP:";
            // 
            // btnVIP1Month
            // 
            btnVIP1Month.Cursor = Cursors.Hand;
            btnVIP1Month.IsBlinking = false;
            btnVIP1Month.Location = new Point(411, 91);
            btnVIP1Month.Margin = new Padding(3, 4, 3, 4);
            btnVIP1Month.Name = "btnVIP1Month";
            btnVIP1Month.Price = "50k";
            btnVIP1Month.Size = new Size(300, 100);
            btnVIP1Month.TabIndex = 6;
            btnVIP1Month.Title = "1 Month VIP";
            btnVIP1Month.Click += VIPButton_Click;
            btnVIP1Month.MouseEnter += VIPButton_MouseEnter;
            btnVIP1Month.MouseLeave += VIPButton_MouseLeave;
            // 
            // btnVIP3Months
            // 
            btnVIP3Months.Cursor = Cursors.Hand;
            btnVIP3Months.IsBlinking = false;
            btnVIP3Months.Location = new Point(742, 91);
            btnVIP3Months.Margin = new Padding(3, 4, 3, 4);
            btnVIP3Months.Name = "btnVIP3Months";
            btnVIP3Months.Price = "125k";
            btnVIP3Months.Size = new Size(300, 100);
            btnVIP3Months.TabIndex = 7;
            btnVIP3Months.Title = "3 Months VIP";
            btnVIP3Months.Click += VIPButton_Click;
            btnVIP3Months.MouseEnter += VIPButton_MouseEnter;
            btnVIP3Months.MouseLeave += VIPButton_MouseLeave;
            // 
            // btnVIP6Months
            // 
            btnVIP6Months.Cursor = Cursors.Hand;
            btnVIP6Months.IsBlinking = false;
            btnVIP6Months.Location = new Point(411, 266);
            btnVIP6Months.Margin = new Padding(3, 4, 3, 4);
            btnVIP6Months.Name = "btnVIP6Months";
            btnVIP6Months.Price = "225k";
            btnVIP6Months.Size = new Size(300, 100);
            btnVIP6Months.TabIndex = 8;
            btnVIP6Months.Title = "6 Months VIP";
            btnVIP6Months.Click += VIPButton_Click;
            btnVIP6Months.MouseEnter += VIPButton_MouseEnter;
            btnVIP6Months.MouseLeave += VIPButton_MouseLeave;
            // 
            // btnVIP1Year
            // 
            btnVIP1Year.Cursor = Cursors.Hand;
            btnVIP1Year.IsBlinking = false;
            btnVIP1Year.Location = new Point(742, 266);
            btnVIP1Year.Margin = new Padding(3, 4, 3, 4);
            btnVIP1Year.Name = "btnVIP1Year";
            btnVIP1Year.Price = "450k";
            btnVIP1Year.Size = new Size(300, 100);
            btnVIP1Year.TabIndex = 9;
            btnVIP1Year.Title = "1 Year VIP";
            btnVIP1Year.Click += VIPButton_Click;
            btnVIP1Year.MouseEnter += VIPButton_MouseEnter;
            btnVIP1Year.MouseLeave += VIPButton_MouseLeave;
            // 
            // NapVIP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            Controls.Add(headerPanel);
            Controls.Add(contentPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NapVIP";
            Size = new Size(1193, 735);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            featurePanel1.ResumeLayout(false);
            featurePanel1.PerformLayout();
            featurePanel2.ResumeLayout(false);
            featurePanel2.PerformLayout();
            featurePanel3.ResumeLayout(false);
            featurePanel3.PerformLayout();
            featurePanel4.ResumeLayout(false);
            featurePanel4.PerformLayout();
            ResumeLayout(false);
        }
    }
}