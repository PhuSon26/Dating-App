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
            panel1 = new Panel();
            btnSearch = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            ColAvatar = new DataGridViewImageColumn();
            btnBoChan = new DataGridViewButtonColumn();
            panel2 = new Panel();
            btnBoChann = new Button();
            btnBack = new Button();
            label3 = new Label();
            flp_list.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
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
            flp_list.BackgroundImage = Properties.Resources._8239_jpg_wh860;
            flp_list.BackgroundImageLayout = ImageLayout.Stretch;
            flp_list.Controls.Add(panel1);
            flp_list.Controls.Add(dataGridView1);
            flp_list.Controls.Add(panel2);
            flp_list.Location = new Point(0, 69);
            flp_list.Name = "flp_list";
            flp_list.Size = new Size(1173, 529);
            flp_list.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1181, 84);
            panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.Info;
            btnSearch.Location = new Point(923, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 60);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(270, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(625, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(96, 30);
            label2.Name = "label2";
            label2.Size = new Size(111, 31);
            label2.TabIndex = 0;
            label2.Text = "TÌM KIẾM";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colName, ColAvatar, btnBoChan });
            dataGridView1.Location = new Point(3, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(541, 415);
            dataGridView1.TabIndex = 1;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.ReadOnly = true;
            Name.Width = 125;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.FillWeight = 40F;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 80;
            colName.Name = "colName";
            // 
            // ColAvatar
            // 
            ColAvatar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColAvatar.HeaderText = "avatar";
            ColAvatar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColAvatar.MinimumWidth = 50;
            ColAvatar.Name = "ColAvatar";
            ColAvatar.Resizable = DataGridViewTriState.True;
            ColAvatar.Width = 56;
            // 
            // btnBoChan
            // 
            btnBoChan.HeaderText = "";
            btnBoChan.MinimumWidth = 6;
            btnBoChan.Name = "btnBoChan";
            btnBoChan.Width = 125;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnBack);
            panel2.Controls.Add(btnBoChann);
            panel2.Location = new Point(550, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(588, 405);
            panel2.TabIndex = 2;
            // 
            // btnBoChann
            // 
            btnBoChann.BackColor = SystemColors.MenuHighlight;
            btnBoChann.Location = new Point(55, 235);
            btnBoChann.Name = "btnBoChann";
            btnBoChann.Size = new Size(94, 57);
            btnBoChann.TabIndex = 0;
            btnBoChann.Text = "🔓  Bỏ chặn";
            btnBoChann.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GrayText;
            btnBack.Location = new Point(491, 235);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 57);
            btnBack.TabIndex = 1;
            btnBack.Text = "🔙 Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tiger", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Lime;
            label3.Location = new Point(17, 125);
            label3.Name = "label3";
            label3.Size = new Size(547, 20);
            label3.TabIndex = 2;
            label3.Text = "Sometimes a second chance can change everything.";
            // 
            // DanhSachChan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            Controls.Add(flp_list);
            Controls.Add(label1);
            Name = "DanhSachChan";
            Size = new Size(1175, 595);
            flp_list.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flp_list;
        private RoundedButton btn_back;
        private Panel panel1;
        private Label label2;
        private Button btnSearch;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewImageColumn ColAvatar;
        private DataGridViewButtonColumn btnBoChan;
        private Panel panel2;
        private Button btnBack;
        private Button btnBoChann;
        private Label label3;
    }
}