namespace Main_Interface.User_Controls
{
    partial class DanhSachNhanTin
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
            label1 = new Label();
            listView1 = new ListView();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(481, 13);
            label1.Name = "label1";
            label1.Size = new Size(215, 60);
            label1.TabIndex = 0;
            label1.Text = "Tin Nhắn";
            // 
            // listView1
            // 
            listView1.Location = new Point(0, 98);
            listView1.Name = "listView1";
            listView1.Size = new Size(1182, 668);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(41, 13);
            label2.Name = "label2";
            label2.Size = new Size(359, 62);
            label2.TabIndex = 2;
            label2.Text = "💖 SynHeart 💖";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(763, 13);
            label3.Name = "label3";
            label3.Size = new Size(359, 62);
            label3.TabIndex = 3;
            label3.Text = "💖 SynHeart 💖";
            // 
            // DanhSachNhanTin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.HotPink;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listView1);
            Controls.Add(label1);
            Name = "DanhSachNhanTin";
            Size = new Size(1182, 766);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
        private Label label2;
        private Label label3;
    }
}