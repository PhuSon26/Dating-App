namespace LOGIN
{
    partial class dsthongbao
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

        #region Designer

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnSearch = new Button();
            btnSettings = new Button();
            pnlNewMatches = new Panel();
            lblNewMatches = new Label();
            flpAvatars = new FlowLayoutPanel();
            pnlRecentList = new Panel();
            lblRecentTitle = new Label();
            pnlMessages = new Panel();
            pnlHeader.SuspendLayout();
            pnlNewMatches.SuspendLayout();
            pnlRecentList.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnSearch);
            pnlHeader.Controls.Add(btnSettings);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 15, 20, 15);
            pnlHeader.Size = new Size(881, 70);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DeepPink;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔔 Thông báo";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.LightPink;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Emoji", 14F);
            btnSearch.Location = new Point(1381, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(45, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.BackColor = Color.LightPink;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI Emoji", 14F);
            btnSettings.Location = new Point(1431, 15);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(45, 40);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "⚙️";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // pnlNewMatches
            // 
            pnlNewMatches.Controls.Add(lblNewMatches);
            pnlNewMatches.Controls.Add(flpAvatars);
            pnlNewMatches.Dock = DockStyle.Top;
            pnlNewMatches.Location = new Point(0, 70);
            pnlNewMatches.Name = "pnlNewMatches";
            pnlNewMatches.Padding = new Padding(20);
            pnlNewMatches.Size = new Size(881, 140);
            pnlNewMatches.TabIndex = 1;
            // 
            // lblNewMatches
            // 
            lblNewMatches.AutoSize = true;
            lblNewMatches.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNewMatches.ForeColor = Color.DeepPink;
            lblNewMatches.Location = new Point(0, 0);
            lblNewMatches.Name = "lblNewMatches";
            lblNewMatches.Size = new Size(269, 32);
            lblNewMatches.TabIndex = 0;
            lblNewMatches.Text = "💗 Tương tác gần đây";
            // 
            // flpAvatars
            // 
            flpAvatars.AutoScroll = true;
            flpAvatars.Dock = DockStyle.Bottom;
            flpAvatars.Location = new Point(20, 30);
            flpAvatars.Name = "flpAvatars";
            flpAvatars.Size = new Size(841, 90);
            flpAvatars.TabIndex = 1;
            flpAvatars.WrapContents = false;
            // 
            // pnlRecentList
            // 
            pnlRecentList.Controls.Add(lblRecentTitle);
            pnlRecentList.Controls.Add(pnlMessages);
            pnlRecentList.Dock = DockStyle.Top;
            pnlRecentList.Location = new Point(0, 210);
            pnlRecentList.Name = "pnlRecentList";
            pnlRecentList.Padding = new Padding(20);
            pnlRecentList.Size = new Size(881, 350);
            pnlRecentList.TabIndex = 0;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRecentTitle.ForeColor = Color.DeepPink;
            lblRecentTitle.Location = new Point(0, 0);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(297, 32);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "📋 Danh sách thông báo";
            // 
            // pnlMessages
            pnlMessages.Dock = DockStyle.Top;
            pnlMessages.Padding = new Padding(20, 10, 20, 10);
            pnlMessages.AutoSize = true;
            pnlMessages.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // 
            // Thongbao
            // 
            AutoScroll = true;
            BackColor = Color.FromArgb(255, 245, 250);
            Controls.Add(pnlRecentList);
            Controls.Add(pnlNewMatches);
            Controls.Add(pnlHeader);

            Name = "Thongbao";
            Size = new Size(881, 693);
            BackColor = Color.White;
            Load += Thongbao_Load_1;
            
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNewMatches.ResumeLayout(false);
            pnlNewMatches.PerformLayout();
            pnlRecentList.ResumeLayout(false);
            pnlRecentList.PerformLayout();
            ResumeLayout(false);
     
        }

        #endregion

        private Panel pnlHeader;
        private Button btnSettings;
        private Button btnSearch;
        private Label lblTitle;

        private Panel pnlNewMatches;
        private Label lblNewMatches;
        private FlowLayoutPanel flpAvatars;

        private Panel pnlRecentList;
        private Label lblRecentTitle;
        private Panel pnlMessages;
    }
}
