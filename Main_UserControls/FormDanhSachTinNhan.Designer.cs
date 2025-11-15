namespace Dating_app_nhom3
{
    partial class FormDanhSachTinNhan
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            btnTimKiem = new RoundedButton();
            label3 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            picAvatarNguoiDung = new PictureBox();
            txtTimKiem = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarNguoiDung).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MistyRose;
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(picAvatarNguoiDung);
            panel1.Controls.Add(txtTimKiem);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(-2, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1196, 107);
            panel1.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.CornerRadius = 20;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(945, 33);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(125, 48);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Baskerville Old Face", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(2, 33);
            label3.Name = "label3";
            label3.Size = new Size(343, 34);
            label3.TabIndex = 1;
            label3.Text = "Love begins with a message";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.Center;
            flowLayoutPanel1.Location = new Point(73, 104);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1123, 624);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // picAvatarNguoiDung
            // 
            picAvatarNguoiDung.BackColor = Color.LightGray;
            picAvatarNguoiDung.Location = new Point(1076, 16);
            picAvatarNguoiDung.Name = "picAvatarNguoiDung";
            picAvatarNguoiDung.Size = new Size(100, 81);
            picAvatarNguoiDung.TabIndex = 3;
            picAvatarNguoiDung.TabStop = false;
            picAvatarNguoiDung.Click += picAvatarNguoiDung_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(350, 33);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(589, 48);
            txtTimKiem.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.InfoText;
            button1.Location = new Point(12, 167);
            button1.Name = "button1";
            button1.Size = new Size(42, 179);
            button1.TabIndex = 3;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            // 
            // FormDanhSachTinNhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            Controls.Add(button1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "FormDanhSachTinNhan";
            Size = new Size(1194, 723);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarNguoiDung).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox picAvatarNguoiDung;
        private TextBox txtTimKiem;
        private RoundedButton btnTimKiem;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private ContextMenuStrip contextMenuStrip1;
        private Button button1;
    }
}