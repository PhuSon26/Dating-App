using Main_Interface.User_Controls;

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
            header = new Panel();
            label3 = new Label();
            picAvatarOtherUser = new PictureBox();
            lb_otherUserName = new Label();
            flp = new FlowLayoutPanel();
            cmstrip = new ContextMenuStrip(components);
            ntin = new Panel();
            nt = new NhanTin();
            header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarOtherUser).BeginInit();
            SuspendLayout();
            // 
            // header
            // 
            header.BackColor = Color.MistyRose;
            header.Controls.Add(label3);
            //header.Controls.Add(cmstrip);
            header.Controls.Add(picAvatarOtherUser);
            header.Controls.Add(lb_otherUserName);
            header.Dock = DockStyle.Top;
            header.ForeColor = Color.Black;
            header.Location = new Point(0, 0);
            header.Margin = new Padding(3, 2, 3, 2);
            header.Name = "header";
            header.Size = new Size(1045, 80);
            header.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Baskerville Old Face", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(2, 25);
            label3.Name = "label3";
            label3.Size = new Size(270, 27);
            label3.TabIndex = 1;
            label3.Text = "Love begins with a message";
            // 
            // picAvatarOtherUser
            // 
            picAvatarOtherUser.BackColor = Color.LightGray;
            picAvatarOtherUser.Location = new Point(930, 0);
            picAvatarOtherUser.Margin = new Padding(3, 2, 3, 2);
            picAvatarOtherUser.Name = "picAvatarOtherUser";
            picAvatarOtherUser.Size = new Size(120, 80);
            picAvatarOtherUser.TabIndex = 3;
            picAvatarOtherUser.TabStop = false;
            // 
            // lb_otherUserName
            // 
            lb_otherUserName.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_otherUserName.Location = new Point(450, 15);
            lb_otherUserName.Margin = new Padding(3, 2, 3, 2);
            lb_otherUserName.Name = "lb_otherUserName";
            lb_otherUserName.Text = "Anonymous";
            lb_otherUserName.AutoSize = true;
            lb_otherUserName.Size = new Size(1000, 100);
            lb_otherUserName.TabIndex = 1;
            // 
            // flp
            // 
            flp.AutoScroll = true;
            flp.BackgroundImageLayout = ImageLayout.Center;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Location = new Point(0, 80);
            flp.Margin = new Padding(3, 2, 3, 2);
            flp.Name = "flp";
            flp.Size = new Size(249, 493);
            flp.Dock = DockStyle.Left;
            flp.Width = 250;
            flp.TabIndex = 1;
            flp.WrapContents = false;
            // 
            // cmstrip
            // 
            cmstrip.ImageScalingSize = new Size(20, 20);
            cmstrip.Name = "contextMenuStrip1";
            cmstrip.Size = new Size(61, 4);
            // 
            // ntin
            // 
            ntin.Location = new Point(249, 80);
            ntin.Name = "ntin";
            ntin.Size = new Size();
            ntin.Dock = DockStyle.Fill;
            ntin.TabIndex = 0;
            ntin.Controls.Add(nt);
            nt.Dock = DockStyle.Fill;
            // 
            // FormDanhSachTinNhan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            Controls.Add(ntin);  
            Controls.Add(flp);    
            Controls.Add(header);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDanhSachTinNhan";
            Size = new Size(1045, 573);
            header.ResumeLayout(false);
            header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarOtherUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel header;
        private PictureBox picAvatarOtherUser;
        private Label lb_otherUserName;
        private Label label3;
        private FlowLayoutPanel flp;
        private ContextMenuStrip cmstrip;
        private Panel ntin;
        private NhanTin nt;
    }
}