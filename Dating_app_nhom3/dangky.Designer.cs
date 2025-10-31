namespace Dating_app_nhom3
{
    partial class dangky
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
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.FromArgb(255, 111, 145);
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.White;
            button1.Location = new Point(295, 384);
            button1.Name = "button1";
            button1.Size = new Size(158, 38);
            button1.TabIndex = 15;
            button1.Text = "Đăng ký";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(378, 250);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(237, 34);
            textBox2.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(163, 250);
            label2.Name = "label2";
            label2.Size = new Size(98, 30);
            label2.TabIndex = 13;
            label2.Text = "Mật Khẩu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 230, 230);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(163, 190);
            label1.Name = "label1";
            label1.Size = new Size(125, 30);
            label1.TabIndex = 11;
            label1.Text = "Địa chỉ Email";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(378, 190);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(236, 34);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(163, 312);
            label4.Name = "label4";
            label4.Size = new Size(186, 30);
            label4.TabIndex = 17;
            label4.Text = "Xác Nhận Mật Khẩu";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(378, 312);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(237, 34);
            textBox3.TabIndex = 18;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(255, 230, 230);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.ForeColor = Color.FromArgb(250, 80, 100);
            label5.Location = new Point(251, 86);
            label5.Name = "label5";
            label5.Size = new Size(300, 43);
            label5.TabIndex = 19;
            label5.Text = "Đăng Ký Tài Khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(255, 230, 230);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(255, 80, 100);
            label3.Location = new Point(1, 9);
            label3.Name = "label3";
            label3.Size = new Size(232, 38);
            label3.TabIndex = 20;
            label3.Text = "💖 SynHeart 💖";
            // 
            // dangky
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 230, 230);
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "dangky";
            Text = "Đăng Ký - SynHeart";
            Load += dangky_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private LinkLabel linkLabel1;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private Label label3;
    }
}