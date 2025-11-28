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
            lblLogo = new Label();
            btn_thongbao = new RoundedButton();
            panelContent = new Panel();
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
            panelMain.Controls.Add(lblLogo);
            panelMain.Controls.Add(btn_thongbao);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1050, 688);
            panelMain.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(255, 105, 150);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Padding = new Padding(0, 15, 0, 0);
            lblLogo.Size = new Size(397, 80);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "💖 SynHeart 💖";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_thongbao
            // 
            btn_thongbao.BackColor = Color.FromArgb(235, 140, 46);
            btn_thongbao.CornerRadius = 20;
            btn_thongbao.FlatStyle = FlatStyle.Flat;
            btn_thongbao.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_thongbao.ForeColor = Color.Yellow;
            btn_thongbao.Location = new Point(907, 0);
            btn_thongbao.Margin = new Padding(3, 2, 3, 2);
            btn_thongbao.Name = "btn_thongbao";
            btn_thongbao.Size = new Size(143, 76);
            btn_thongbao.TabIndex = 3;
            btn_thongbao.Text = "🔔";
            btn_thongbao.UseVisualStyleBackColor = false;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(255, 250, 253);
            panelContent.Location = new Point(0, 77);
            panelContent.Margin = new Padding(18, 15, 18, 15);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1050, 548);
            panelContent.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 619);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(0, 4, 0, 4);
            panelButtons.Size = new Size(1050, 69);
            panelButtons.TabIndex = 2;
            // 
            // btn_vip
            // 
            btn_vip.Location = new Point(0, 0);
            btn_vip.Name = "btn_vip";
            btn_vip.TabIndex = 0;
            // 
            // btn_ghepdoi
            // 
            btn_ghepdoi.Location = new Point(0, 0);
            btn_ghepdoi.Name = "btn_ghepdoi";
            btn_ghepdoi.TabIndex = 0;
            // 
            // btn_dsnt
            // 
            btn_dsnt.Location = new Point(0, 0);
            btn_dsnt.Name = "btn_dsnt";
            btn_dsnt.TabIndex = 0;
            // 
            // btn_hscn
            // 
            btn_hscn.Location = new Point(0, 0);
            btn_hscn.Name = "btn_hscn";
            btn_hscn.TabIndex = 0;
            // 
            // btn_caidat
            // 
            btn_caidat.Location = new Point(0, 0);
            btn_caidat.Name = "btn_caidat";
            btn_caidat.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1050, 688);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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
        private RoundedButton btn_thongbao;
    }
}