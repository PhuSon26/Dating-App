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
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(72, 209, 204);
            btn_back.CornerRadius = 30;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(0, -55);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(148, 125);
            btn_back.TabIndex = 12;
            btn_back.Text = "🠔";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // DanhSachChan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            Controls.Add(btn_back);
            Controls.Add(flp_list);
            Controls.Add(label1);
            Name = "DanhSachChan";
            Size = new Size(1175, 595);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flp_list;
        private RoundedButton btn_back;
    }
}