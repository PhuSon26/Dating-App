using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using LOGIN;
using System.Threading.Tasks;


namespace Main_Interface.User_Controls
{
    public partial class NhanTin : UserControl
    {
        private FlowLayoutPanel pnlChatContainer;
        private Panel pnlBottom;
        private TextBox txtMessage;
        private Button btnSend;

        private string currentUserId;
        private string conversationId;
        private Main MainForm;

        private readonly HttpClient http = new HttpClient();
        private System.Windows.Forms.Timer messageTimer;

       
        public NhanTin(Main m) 
        {
            MainForm = m;
        }

      
        public void LoadConversation(string userId, string convId)
        {
            currentUserId = userId;
            conversationId = convId;

            pnlChatContainer.Controls.Clear();

            if (!string.IsNullOrEmpty(conversationId))
                messageTimer.Start();
        }

        private void SetupCustomUI()
        {
            pnlChatContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.White
            };
          

            pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke
            };

            btnSend = new Button
            {
                Text = "Gửi",
                Size = new Size(80, 40),
                Dock = DockStyle.Right,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White
            };
            btnSend.Click += BtnSend_Click;

            txtMessage = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F)
            };

            pnlBottom.Controls.Add(txtMessage);
            pnlBottom.Controls.Add(btnSend);

            Controls.Add(pnlChatContainer);
            Controls.Add(pnlBottom);
        }

        // =========================== Load Messages ===========================
        private List<string> loadedMessageIds = new List<string>();

      

        // =========================== Bubble UI ===========================
       

        // =========================== Send Message ===========================
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string content = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(content)) return;

            txtMessage.Clear();

            var data = new
            {
                ConversationId = conversationId,
                SenderId = currentUserId,
                Content = content
            };

            try
            {
                await http.PostAsJsonAsync("/api/chat/send", data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi API: " + ex.Message);
            }
        }

       

      
    }
}
