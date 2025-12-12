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
            btn_back = new RoundedButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(348, 7);
            label1.Name = "label1";
            label1.Size = new Size(287, 47);
            label1.TabIndex = 0;
            label1.Text = "Danh Sách Chặn";
            // 
            // flp_list
            // 
            flp_list.AutoScroll = true;
            flp_list.Location = new Point(0, 52);
            flp_list.Margin = new Padding(3, 2, 3, 2);
            flp_list.Name = "flp_list";
            flp_list.Size = new Size(1028, 478);
            flp_list.TabIndex = 1;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(72, 209, 204);
            btn_back.CornerRadius = 30;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(0, -41);
            btn_back.Margin = new Padding(3, 2, 3, 2);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(130, 94);
            btn_back.TabIndex = 12;
            btn_back.Text = "🠔";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // DanhSachChan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            Controls.Add(btn_back);
            Controls.Add(flp_list);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DanhSachChan";
            Size = new Size(1028, 628);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flp_list;
        private RoundedButton btn_back;
    }
}