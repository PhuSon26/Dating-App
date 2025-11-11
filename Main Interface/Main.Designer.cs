namespace Main_Interface
{
    partial class Main
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
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(255, 245, 250);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(lblLogo);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1200, 800);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(255, 250, 253);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 101);
            panelContent.Margin = new Padding(20);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1200, 599);
            panelContent.TabIndex = 0;
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
            panelButtons.Controls.Add(btn_vip);
            panelButtons.Controls.Add(btn_ghepdoi);
            panelButtons.Controls.Add(btn_dsnt);
            panelButtons.Controls.Add(btn_hscn);
            panelButtons.Controls.Add(btn_caidat);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 700);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(0, 5, 0, 5);
            panelButtons.Size = new Size(1200, 100);
            panelButtons.TabIndex = 2;
            // 
            // btn_vip
            // 
            btn_vip.Location = new Point(0, 0);
            btn_vip.Name = "btn_vip";
            btn_vip.Size = new Size(75, 23);
            btn_vip.TabIndex = 0;
            btn_vip.Click += btn_vip_Click;
            // 
            // btn_ghepdoi
            // 
            btn_ghepdoi.Location = new Point(0, 0);
            btn_ghepdoi.Name = "btn_ghepdoi";
            btn_ghepdoi.Size = new Size(75, 23);
            btn_ghepdoi.TabIndex = 1;
            btn_ghepdoi.Click += btn_ghepdoi_Click;
            // 
            // btn_dsnt
            // 
            btn_dsnt.Location = new Point(0, 0);
            btn_dsnt.Name = "btn_dsnt";
            btn_dsnt.Size = new Size(75, 23);
            btn_dsnt.TabIndex = 2;
            btn_dsnt.Click += btn_dsnt_Click;
            // 
            // btn_hscn
            // 
            btn_hscn.Location = new Point(0, 0);
            btn_hscn.Name = "btn_hscn";
            btn_hscn.Size = new Size(75, 23);
            btn_hscn.TabIndex = 3;
            btn_hscn.Click += btn_hscn_Click;
            // 
            // btn_caidat
            // 
            btn_caidat.Location = new Point(0, 0);
            btn_caidat.Name = "btn_caidat";
            btn_caidat.Size = new Size(75, 23);
            btn_caidat.TabIndex = 4;
            btn_caidat.Click += btn_caidat_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 800);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "💖 SynHeart - Hẹn hò cùng cảm xúc";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private Panel panelMain;
        private Label lblLogo;
        private Panel panelButtons;
        private Button btn_vip;
        private Button btn_ghepdoi;
        private Button btn_dsnt;
        private Button btn_hscn;
        private Button btn_caidat;
        private Panel panelContent;
    }
}

