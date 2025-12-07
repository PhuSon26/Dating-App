namespace LOGIN
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
            picAvatarNguoiDung = new PictureBox();
            txtTimKiem = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarNguoiDung).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MistyRose;
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(picAvatarNguoiDung);
            panel1.Dock = DockStyle.Top;
            panel1.Controls.Add(txtTimKiem);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 80);
            panel1.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.CornerRadius = 20;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(920, 25);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(109, 36);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Baskerville Old Face", 22F, FontStyle.Italic);
            label3.Location = new Point(2, 25);
            label3.Name = "label3";
            label3.Size = new Size(200, 27);
            label3.TabIndex = 1;
            label3.Text = "Love begins with a message";
            // 
            // picAvatarNguoiDung
            // 
            picAvatarNguoiDung.Location = new Point(900, 0);
            picAvatarNguoiDung.Size = new Size(125, 80);
            picAvatarNguoiDung.Name = "picAvatarNguoiDung";
            picAvatarNguoiDung.TabIndex = 2;
            picAvatarNguoiDung.TabStop = false;
            picAvatarNguoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picAvatarNguoiDung.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 16F);
            txtTimKiem.Location = new Point(430, 25);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(480, 36);
            txtTimKiem.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.BackColor = Color.FromArgb(255, 240, 245);
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // FormDanhSachTinNhan
            // 
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Name = "FormDanhSachTinNhan";
            Size = new Size(1045, 570);
            Load += FormDanhSachTinNhan_Load;
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
    }
}