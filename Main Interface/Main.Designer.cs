namespace Main_Interface
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_vip = new Button();
            btn_ghepdoi = new Button();
            btn_hscn = new Button();
            btn_dsnt = new Button();
            btn_caidat = new Button();
            panelMain = new Panel();
            label1 = new Label();
            panelControl = new Panel();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // btn_vip
            // 
            btn_vip.BackgroundImage = Properties.Resources.Screenshot_2025_10_31_224543;
            btn_vip.BackgroundImageLayout = ImageLayout.Stretch;
            btn_vip.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_vip.Location = new Point(-2, 754);
            btn_vip.Name = "btn_vip";
            btn_vip.Size = new Size(243, 139);
            btn_vip.TabIndex = 0;
            btn_vip.UseVisualStyleBackColor = true;
            btn_vip.Click += btn_vip_Click;
            // 
            // btn_ghepdoi
            // 
            btn_ghepdoi.BackgroundImage = Properties.Resources.Screenshot_2025_10_31_225126;
            btn_ghepdoi.BackgroundImageLayout = ImageLayout.Stretch;
            btn_ghepdoi.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ghepdoi.Location = new Point(236, 754);
            btn_ghepdoi.Name = "btn_ghepdoi";
            btn_ghepdoi.Size = new Size(241, 139);
            btn_ghepdoi.TabIndex = 1;
            btn_ghepdoi.UseVisualStyleBackColor = true;
            btn_ghepdoi.Click += btn_ghepdoi_Click;
            // 
            // btn_hscn
            // 
            btn_hscn.BackgroundImage = Properties.Resources.free_user_icon_3296_thumb;
            btn_hscn.BackgroundImageLayout = ImageLayout.Stretch;
            btn_hscn.FlatStyle = FlatStyle.Flat;
            btn_hscn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_hscn.Location = new Point(712, 754);
            btn_hscn.Name = "btn_hscn";
            btn_hscn.Size = new Size(240, 139);
            btn_hscn.TabIndex = 2;
            btn_hscn.UseVisualStyleBackColor = true;
            btn_hscn.Click += btn_hscn_Click;
            // 
            // btn_dsnt
            // 
            btn_dsnt.BackgroundImage = Properties.Resources.download;
            btn_dsnt.BackgroundImageLayout = ImageLayout.Stretch;
            btn_dsnt.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_dsnt.Location = new Point(473, 754);
            btn_dsnt.Name = "btn_dsnt";
            btn_dsnt.Size = new Size(244, 139);
            btn_dsnt.TabIndex = 3;
            btn_dsnt.UseVisualStyleBackColor = true;
            btn_dsnt.Click += btn_dsnt_Click;
            // 
            // btn_caidat
            // 
            btn_caidat.BackgroundImage = Properties.Resources.images;
            btn_caidat.BackgroundImageLayout = ImageLayout.Stretch;
            btn_caidat.FlatStyle = FlatStyle.Flat;
            btn_caidat.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_caidat.Location = new Point(947, 754);
            btn_caidat.Name = "btn_caidat";
            btn_caidat.Size = new Size(240, 139);
            btn_caidat.TabIndex = 4;
            btn_caidat.UseVisualStyleBackColor = true;
            btn_caidat.Click += btn_caidat_Click;
            // 
            // panelMain
            // 
            panelMain.BackgroundImage = Properties.Resources.hinh_nen_tinh_yeu_141;
            panelMain.BackgroundImageLayout = ImageLayout.Stretch;
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(panelControl);
            panelMain.Location = new Point(-2, 1);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1183, 756);
            panelMain.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Pink;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.HotPink;
            label1.Location = new Point(391, 0);
            label1.Name = "label1";
            label1.Size = new Size(493, 81);
            label1.TabIndex = 7;
            label1.Text = "💖 SynHeart 💖";
            // 
            // panelControl
            // 
            panelControl.Location = new Point(3, 753);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(1180, 139);
            panelControl.TabIndex = 6;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1182, 884);
            Controls.Add(panelMain);
            Controls.Add(btn_caidat);
            Controls.Add(btn_vip);
            Controls.Add(btn_hscn);
            Controls.Add(btn_ghepdoi);
            Controls.Add(btn_dsnt);
            Name = "Main";
            Text = "Form1";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_vip;
        private Button btn_ghepdoi;
        private Button btn_hscn;
        private Button btn_dsnt;
        private Button btn_caidat;
        private Panel panelMain;
        private Panel panelControl;
        private Label label1;
    }
}
