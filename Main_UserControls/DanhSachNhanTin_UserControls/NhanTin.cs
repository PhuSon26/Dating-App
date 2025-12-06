using System;
using System.Drawing;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class NhanTin : UserControl
    {
        public NhanTin()
        {
            InitializeComponent();
        }

        private void NhanTin_Load(object sender, EventArgs e)
        {
            // Test demo
            AddMessage("Hello, bạn khỏe không?", false);
            AddMessage("Mình khỏe nè!", true);
        }

        // ==============================
        //      HÀM TẠO BONG BÓNG CHAT
        // ==============================
        public void AddMessage(string text, bool isMe)
        {
            // Panel dòng hiển thị bubble
            Panel row = new Panel();
            row.AutoSize = true;
            row.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            row.Width = flPanel_tinNhan.ClientSize.Width - 30; // width full
            row.BackColor = Color.Transparent;

            // Bubble
            Panel bubble = new Panel();
            bubble.AutoSize = true;
            bubble.MaximumSize = new Size(400, 0);
            bubble.Padding = new Padding(10);
            bubble.BackColor = isMe ? Color.DeepSkyBlue : Color.LightGray;
            bubble.Margin = new Padding(5, 3, 5, 3);

            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 11);

            bubble.Controls.Add(lbl);
            row.Controls.Add(bubble);

            // ⭐ CANH TRÁI/PHẢI ĐÚNG WINFORMS
            if (isMe)
            {
                bubble.Location = new Point(
                    row.Width - bubble.PreferredSize.Width - 10,   // sát mép phải
                    0
                );
            }
            else
            {
                bubble.Location = new Point(0, 0); // sát trái
            }

            flPanel_tinNhan.Controls.Add(row);
            flPanel_tinNhan.ScrollControlIntoView(row);
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_message.Text)) return;

            AddMessage(tb_message.Text, true);
            tb_message.Text = "";
        }
    }
}
