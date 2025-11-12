namespace Main_Interface.User_Controls.CaiDat_UserControls
{
    partial class DanhSachChan
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
            flp_list = new FlowLayoutPanel();
            roundedButton1 = new RoundedButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(398, 9);
            label1.Name = "label1";
            label1.Size = new Size(358, 60);
            label1.TabIndex = 0;
            label1.Text = "Danh Sách Chặn";
            // 
            // flp_list
            // 
            flp_list.AutoScroll = true;
            flp_list.Location = new Point(0, 69);
            flp_list.Name = "flp_list";
            flp_list.Size = new Size(1173, 529);
            flp_list.TabIndex = 1;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.FromArgb(72, 209, 204);
            roundedButton1.CornerRadius = 30;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(0, -55);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(148, 125);
            roundedButton1.TabIndex = 12;
            roundedButton1.Text = "🠔";
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // DanhSachChan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(1175, 595);
            Controls.Add(roundedButton1);
            Controls.Add(flp_list);
            Controls.Add(label1);
            Name = "DanhSachChan";
            Text = "DanhSachChan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flp_list;
        private RoundedButton roundedButton1;
    }
}