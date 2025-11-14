namespace Main_Interface
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelMain;
        private Label lblLogo;
        private Panel panelButtons;
        private Button btn_vip;
        private Button btn_ghepdoi;
        private Button btn_dsnt;
        private Button btn_hscn;
        private Button btn_caidat;

        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelContent = new Panel();
            lblLogo = new Label();
            panelButtons = new Panel();
            btn_vip = new Button();
            btn_ghepdoi = new Button();
            btn_dsnt = new Button();
            btn_hscn = new Button();
            btn_caidat = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoSize = true;
            panelMain.BackColor = Color.FromArgb(255, 245, 250);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(lblLogo);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1200, 926);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(255, 250, 253);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 101);
            panelContent.Margin = new Padding(20);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1200, 733);
            panelContent.TabIndex = 0;
            panelContent.Paint += panelContent_Paint_3;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(255, 105, 150);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Padding = new Padding(0, 20, 0, 0);
            lblLogo.Size = new Size(493, 101);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "💖 SynHeart 💖";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 834);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(0, 5, 0, 5);
            panelButtons.Size = new Size(1200, 92);
            panelButtons.TabIndex = 2;
            panelButtons.Paint += panelButtons_Paint_1;
            // 
            // btn_vip
            // 
            btn_vip.Location = new Point(0, 0);
            btn_vip.Name = "btn_vip";
            btn_vip.Size = new Size(75, 23);
            btn_vip.TabIndex = 0;
            // 
            // btn_ghepdoi
            // 
            btn_ghepdoi.Location = new Point(0, 0);
            btn_ghepdoi.Name = "btn_ghepdoi";
            btn_ghepdoi.Size = new Size(75, 23);
            btn_ghepdoi.TabIndex = 0;
            // 
            // btn_dsnt
            // 
            btn_dsnt.Location = new Point(0, 0);
            btn_dsnt.Name = "btn_dsnt";
            btn_dsnt.Size = new Size(75, 23);
            btn_dsnt.TabIndex = 0;
            // 
            // btn_hscn
            // 
            btn_hscn.Location = new Point(0, 0);
            btn_hscn.Name = "btn_hscn";
            btn_hscn.Size = new Size(75, 23);
            btn_hscn.TabIndex = 0;
            // 
            // btn_caidat
            // 
            btn_caidat.Location = new Point(0, 0);
            btn_caidat.Name = "btn_caidat";
            btn_caidat.Size = new Size(75, 23);
            btn_caidat.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 926);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "💖 SynHeart - Hẹn hò cùng cảm xúc";
            Load += Main_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        public Panel panelContent;
    }
}