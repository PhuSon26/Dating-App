using Google.Api;
using System.Windows.Forms;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
//using static System.Net.Mime.MediaTypeNames;

namespace Main_Interface.User_Controls
{
    partial class MatchForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchForm));
            pb_avatarUser1 = new PictureBox();
            pb_avatarUser2 = new PictureBox();
            lblMatch = new Label();
            lb_user1 = new Label();
            lb_user2 = new Label();
            lblTagline = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser2).BeginInit();
            SuspendLayout();
            // 
            // pb_avatarUser1
            // 
            pb_avatarUser1.BackColor = Color.Transparent;
            pb_avatarUser1.Location = new Point(24, 128);
            pb_avatarUser1.Margin = new Padding(3, 4, 3, 4);
            pb_avatarUser1.Name = "pb_avatarUser1";
            pb_avatarUser1.Size = new Size(229, 230);
            pb_avatarUser1.SizeMode = PictureBoxSizeMode.Zoom;
            pb_avatarUser1.TabIndex = 7;
            pb_avatarUser1.TabStop = false;
            // 
            // pb_avatarUser2
            // 
            pb_avatarUser2.BackColor = Color.Transparent;
            pb_avatarUser2.Location = new Point(809, 128);
            pb_avatarUser2.Margin = new Padding(3, 4, 3, 4);
            pb_avatarUser2.Name = "pb_avatarUser2";
            pb_avatarUser2.Size = new Size(229, 230);
            pb_avatarUser2.SizeMode = PictureBoxSizeMode.Zoom;
            pb_avatarUser2.TabIndex = 6;
            pb_avatarUser2.TabStop = false;
            // 
            // lblMatch
            // 
            lblMatch.AutoSize = true;
            lblMatch.BackColor = Color.Transparent;
            lblMatch.Font = new Font("Snap ITC", 58F, FontStyle.Bold);
            lblMatch.ForeColor = Color.DeepPink;
            lblMatch.Location = new Point(273, -1);
            lblMatch.Name = "lblMatch";
            lblMatch.Size = new Size(538, 125);
            lblMatch.TabIndex = 5;
            lblMatch.Text = "MATCH!";
            // 
            // lb_user1
            // 
            lb_user1.AutoSize = true;
            lb_user1.BackColor = Color.Transparent;
            lb_user1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lb_user1.ForeColor = Color.Black;
            lb_user1.Location = new Point(60, 360);
            lb_user1.Name = "txtNameUser1";
            lb_user1.Size = new Size(86, 32);
            lb_user1.TabIndex = 4;
            lb_user1.Text = "User 1";
            // 
            // lb_user2
            // 
            lb_user2.AutoSize = true;
            lb_user2.BackColor = Color.Transparent;
            lb_user2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lb_user2.ForeColor = Color.Black;
            lb_user2.Location = new Point(845, 360);
            lb_user2.Name = "txtNameUser2";
            lb_user2.Size = new Size(86, 32);
            lb_user2.TabIndex = 3;
            lb_user2.Text = "User 2";
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.BackColor = Color.Transparent;
            lblTagline.Font = new Font("Viner Hand ITC", 26F, FontStyle.Italic);
            lblTagline.ForeColor = Color.IndianRed;
            lblTagline.Location = new Point(203, 582);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(650, 71);
            lblTagline.TabIndex = 0;
            lblTagline.Text = "Pairing up? Say less — it’s us.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            string path = Path.Combine(Application.StartupPath, "Resources", "Theme.png");
            BackgroundImage = Image.FromFile(path);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1059, 748);
            Controls.Add(lblTagline);
            Controls.Add(lb_user2);
            Controls.Add(lb_user1);
            Controls.Add(lblMatch);
            Controls.Add(pb_avatarUser2);
            Controls.Add(pb_avatarUser1);
            Load += Match_Load;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MatchForm";
            Text = "Match";
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_avatarUser1;
        private PictureBox pb_avatarUser2;
        private Label lblMatch;
        private Label lb_user1;
        private Label lb_user2;
        private Label lblTagline;
    }
}
