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
        private Panel panel1;
        private Label lblGioiThieu;

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
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(lblGioiThieu);
            panel1.Location = new Point(20, 100);
            panel1.Name = "panel1";
            panel1.Size = new Size(1135, 450);
            panel1.TabIndex = 1;
            // 
            // lblGioiThieu
            // 
            lblGioiThieu.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGioiThieu.Location = new Point(0, 0);
            lblGioiThieu.Name = "lblGioiThieu";
            lblGioiThieu.Size = new Size(1100, 695);
            lblGioiThieu.TabIndex = 0;
            lblGioiThieu.Text = resources.GetString("lblGioiThieu.Text");
            // 
            // GioiThieuUngDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1175, 595);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "GioiThieuUngDung";
            Text = "Giới Thiệu Ứng Dụng";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
