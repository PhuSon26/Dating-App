namespace Main_Interface.User_Controls
{
    partial class Match
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
            pb_avatarUser1 = new PictureBox();
            pb_avatarUser2 = new PictureBox();
            label1 = new Label();
            txtNameUser1 = new TextBox();
            txtNameUser2 = new TextBox();
            lblLogo = new Label();
            button1 = new Button();
            btnBack = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser2).BeginInit();
            SuspendLayout();
            // 
            // pb_avatarUser1
            // 
            pb_avatarUser1.Location = new Point(23, 195);
            pb_avatarUser1.Name = "pb_avatarUser1";
            pb_avatarUser1.Size = new Size(175, 139);
            pb_avatarUser1.TabIndex = 0;
            pb_avatarUser1.TabStop = false;
            // 
            // pb_avatarUser2
            // 
            pb_avatarUser2.Location = new Point(584, 195);
            pb_avatarUser2.Name = "pb_avatarUser2";
            pb_avatarUser2.Size = new Size(171, 150);
            pb_avatarUser2.TabIndex = 1;
            pb_avatarUser2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Snap ITC", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(204, 229);
            label1.Name = "label1";
            label1.Size = new Size(374, 103);
            label1.TabIndex = 2;
            label1.Text = "Match!";
            // 
            // txtNameUser1
            // 
            txtNameUser1.Location = new Point(50, 378);
            txtNameUser1.Name = "txtNameUser1";
            txtNameUser1.Size = new Size(125, 27);
            txtNameUser1.TabIndex = 3;
            // 
            // txtNameUser2
            // 
            txtNameUser2.Location = new Point(604, 378);
            txtNameUser2.Name = "txtNameUser2";
            txtNameUser2.Size = new Size(125, 27);
            txtNameUser2.TabIndex = 4;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(255, 105, 150);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Padding = new Padding(0, 20, 0, 0);
            lblLogo.Size = new Size(493, 101);
            lblLogo.TabIndex = 5;
            lblLogo.Text = "💖 SynHeart 💖";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Info;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = Properties.Resources.icons8_match_482;
            button1.Location = new Point(317, 420);
            button1.Name = "button1";
            button1.Size = new Size(119, 51);
            button1.TabIndex = 6;
            button1.Text = "MATCH";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.Image = Properties.Resources.icons8_back_64;
            btnBack.Location = new Point(1093, 293);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(86, 71);
            btnBack.TabIndex = 7;
            btnBack.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Viner Hand ITC", 28.2F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(143, 508);
            label2.Name = "label2";
            label2.Size = new Size(696, 76);
            label2.TabIndex = 8;
            label2.Text = "Pairing up? Say less — it’s us.";
            // 
            // Match
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.a_red_heart_on_the_wooden_with_pink_background_love_concept_ai_generative_photo;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1181, 612);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(button1);
            Controls.Add(lblLogo);
            Controls.Add(txtNameUser2);
            Controls.Add(txtNameUser1);
            Controls.Add(label1);
            Controls.Add(pb_avatarUser2);
            Controls.Add(pb_avatarUser1);
            Name = "Match";
            Text = "Match";
            Load += Match_Load;
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_avatarUser1;
        private PictureBox pb_avatarUser2;
        private Label label1;
        private TextBox txtNameUser1;
        private TextBox txtNameUser2;

        private Label lblLogo;
        private Button button1;
        private Button btnBack;
        private Label label2;
    }
}