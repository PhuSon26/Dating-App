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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Match));
            pb_avatarUser1 = new PictureBox();
            pb_avatarUser2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser2).BeginInit();
            SuspendLayout();
            // 
            // pb_avatarUser1
            // 
            pb_avatarUser1.Location = new Point(25, 203);
            pb_avatarUser1.Name = "pb_avatarUser1";
            pb_avatarUser1.Size = new Size(196, 168);
            pb_avatarUser1.TabIndex = 0;
            pb_avatarUser1.TabStop = false;
            // 
            // pb_avatarUser2
            // 
            pb_avatarUser2.Location = new Point(963, 203);
            pb_avatarUser2.Name = "pb_avatarUser2";
            pb_avatarUser2.Size = new Size(196, 168);
            pb_avatarUser2.TabIndex = 1;
            pb_avatarUser2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(447, 282);
            label1.Name = "label1";
            label1.Size = new Size(308, 106);
            label1.TabIndex = 2;
            label1.Text = "Match!";
            // 
            // Match
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1181, 612);
            Controls.Add(label1);
            Controls.Add(pb_avatarUser2);
            Controls.Add(pb_avatarUser1);
            Name = "Match";
            Text = "Match";
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_avatarUser2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_avatarUser1;
        private PictureBox pb_avatarUser2;
        private Label label1;
    }
}