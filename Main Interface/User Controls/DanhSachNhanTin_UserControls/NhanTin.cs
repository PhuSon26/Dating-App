using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class NhanTin : UserControl
    {
        public NhanTin()
        {
            InitializeComponent();
        }
        private void AddMyMessage(string text, DateTime time)
        {
            // Panel chứa 1 tin nhắn
            Panel pnl = new Panel();
            pnl.AutoSize = true;
            pnl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnl.BackColor = Color.MediumOrchid;       // màu bong bóng của mình
            pnl.Padding = new Padding(10);
            pnl.MaximumSize = new Size(flpMessages.Width * 3 / 5, 0); // max 60% chiều rộng
            pnl.BorderStyle = BorderStyle.None;

            // Label nội dung
            Label lblText = new Label();
            lblText.AutoSize = true;
            lblText.Text = text;
            lblText.ForeColor = Color.White;
            lblText.Font = new Font("Segoe UI", 10);
            lblText.MaximumSize = new Size(pnl.MaximumSize.Width - 10, 0); // xuống dòng nếu dài

            // Label thời gian
            Label lblTime = new Label();
            lblTime.AutoSize = true;
            lblTime.Text = time.ToString("HH:mm");
            lblTime.Font = new Font("Segoe UI", 7);
            lblTime.ForeColor = Color.Lavender;
            lblTime.Margin = new Padding(0, 3, 0, 0);

            // Sắp xếp vị trí trong Panel
            lblText.Location = new Point(0, 0);
            lblTime.Location = new Point(0, lblText.Height + 3);

            pnl.Controls.Add(lblText);
            pnl.Controls.Add(lblTime);

            // margin để đẩy bong bóng về bên phải
            //      left, top, right, bottom
            pnl.Margin = new Padding(flpMessages.Width / 5, 5, 10, 5);

            flpMessages.Controls.Add(pnl);
            flpMessages.ScrollControlIntoView(pnl); // auto scroll xuống cuối
        }
        private void AddOtherMessage(string text, DateTime time)
        {
            Panel pnl = new Panel();
            pnl.AutoSize = true;
            pnl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnl.BackColor = Color.White;             // màu bong bóng của đối phương
            pnl.Padding = new Padding(10);
            pnl.MaximumSize = new Size(flpMessages.Width * 3 / 5, 0);
            pnl.BorderStyle = BorderStyle.None;

            Label lblText = new Label();
            lblText.AutoSize = true;
            lblText.Text = text;
            lblText.ForeColor = Color.Black;
            lblText.Font = new Font("Segoe UI", 10);
            lblText.MaximumSize = new Size(pnl.MaximumSize.Width - 10, 0);

            Label lblTime = new Label();
            lblTime.AutoSize = true;
            lblTime.Text = time.ToString("HH:mm");
            lblTime.Font = new Font("Segoe UI", 7);
            lblTime.ForeColor = Color.Gray;
            lblTime.Margin = new Padding(0, 3, 0, 0);

            lblText.Location = new Point(0, 0);
            lblTime.Location = new Point(0, lblText.Height + 3);

            pnl.Controls.Add(lblText);
            pnl.Controls.Add(lblTime);

            // margin để nó nằm bên trái
            pnl.Margin = new Padding(10, 5, flpMessages.Width / 5, 5);

            flpMessages.Controls.Add(pnl);
            flpMessages.ScrollControlIntoView(pnl);
        }
        private void NhanTin_Load(object sender, EventArgs e)
        {

        }
    }
}
