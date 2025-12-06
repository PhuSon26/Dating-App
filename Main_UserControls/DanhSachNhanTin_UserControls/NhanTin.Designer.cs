namespace Main_Interface.User_Controls
{
    partial class NhanTin
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flPanel_tinNhan;
        private Panel panelBottom;
        private TextBox tb_message;
        private Button btn_send;
        private Button btn_anh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flPanel_tinNhan = new FlowLayoutPanel();
            panelBottom = new Panel();
            btn_anh = new Button();
            tb_message = new TextBox();
            btn_send = new Button();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // flPanel_tinNhan
            // 
            flPanel_tinNhan.AutoScroll = true;
            flPanel_tinNhan.BackColor = Color.WhiteSmoke;
            flPanel_tinNhan.Dock = DockStyle.Top;
            flPanel_tinNhan.FlowDirection = FlowDirection.TopDown;
            flPanel_tinNhan.Location = new Point(0, 0);
            flPanel_tinNhan.Name = "flPanel_tinNhan";
            flPanel_tinNhan.Padding = new Padding(10);
            flPanel_tinNhan.Size = new Size(700, 400);
            flPanel_tinNhan.TabIndex = 1;
            flPanel_tinNhan.WrapContents = false;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.WhiteSmoke;
            panelBottom.Controls.Add(btn_send);
            panelBottom.Controls.Add(tb_message);
            panelBottom.Controls.Add(btn_anh);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 403);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(700, 60);
            panelBottom.TabIndex = 0;
            // 
            // btn_anh
            // 
            btn_anh.Font = new Font("Segoe UI Emoji", 16F);
            btn_anh.Location = new Point(10, 10);
            btn_anh.Name = "btn_anh";
            btn_anh.Size = new Size(50, 40);
            btn_anh.TabIndex = 0;
            btn_anh.Text = "📷";
            // 
            // tb_message
            // 
            tb_message.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tb_message.Font = new Font("Segoe UI", 11F);
            tb_message.Location = new Point(65, 10);
            tb_message.Multiline = true;
            tb_message.Name = "tb_message";
            tb_message.Size = new Size(550, 40);
            tb_message.TabIndex = 1;
            //
            // btn_send
            //
            btn_send.BackColor = Color.DeepSkyBlue;
            btn_send.FlatStyle = FlatStyle.Flat;
            btn_send.FlatAppearance.BorderSize = 0;
            btn_send.Size = new Size(85, 40);        
            btn_send.Location = new Point(615, 10);
            btn_send.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_send.Text = "Gửi";                    
            btn_send.Name = "btn_send";
            btn_send.TabIndex = 2;
            btn_send.UseVisualStyleBackColor = false;
            btn_send.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btn_send.Click += btn_send_Click;
            // 
            // NhanTin
            // 
            Controls.Add(panelBottom);
            Controls.Add(flPanel_tinNhan);
            Name = "NhanTin";
            Size = new Size(700, 463);
            Load += NhanTin_Load;
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }
    }
}
