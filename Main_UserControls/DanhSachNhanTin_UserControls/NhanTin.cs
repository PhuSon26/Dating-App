using Google.Cloud.Firestore;
using LOGIN;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class NhanTin : UserControl
    {
        private FlowLayoutPanel pnlChatContainer;
        private Panel pnlBottom;
        private TextBox txtMessage;
        private Button btnSend;

        private readonly FirebaseAuthHelper firebase = new FirebaseAuthHelper("login-bb104");

        private FirestoreChangeListener listener;

        private USER targetUser;       // Người đang chat với mình
        private string myUserId;       // Id của mình
        private string conversationId; // A_B

        public NhanTin(USER user)
        {
            targetUser = user;
            myUserId = Session.LocalId;
            conversationId = firebase.GetConversationId(myUserId, targetUser.Id);

            InitializeComponent();
            SetupCustomUI();
        }

        // ======================================================
        // ====================== UI CHAT ========================
        // ======================================================
        private void SetupCustomUI()
        {
            // Panel chứa bubble chat
            pnlChatContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.White
            };

            // Panel nhập tin
            pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke
            };

            // Button gửi
            btnSend = new Button
            {
                Text = "Gửi",
                Size = new Size(80, 40),
                Dock = DockStyle.Right,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White
            };
            btnSend.Click += BtnSend_Click;

            // Ô nhập
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

        // ======================================================
        // ====================== LOAD LISTENER =================
        // ======================================================
        private void NhanTin_Load(object sender, EventArgs e)
        {
            // Bắt đầu lắng nghe realtime
            listener = firebase.ListenToMessages(
                myUserId,
                targetUser.Id,
                UpdateUIWithMessages
            );

            // Reset số tin chưa đọc
            firebase.ResetUnread(myUserId, targetUser.Id);
        }

        // ======================================================
        // ======================= GỬI TIN =======================
        // ======================================================
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            await firebase.SendMessage(myUserId, targetUser.Id, text);
            await firebase.UpdateChatMeta(myUserId, targetUser.Id, text);

            txtMessage.Clear();
        }

        // ======================================================
        // ====================== HIỂN THỊ TIN ===================
        // ======================================================
        private void UpdateUIWithMessages(List<Messagemodels> messages)
        {
            pnlChatContainer.Invoke(new Action(() =>
            {
                pnlChatContainer.Controls.Clear();

                foreach (var msg in messages)
                    pnlChatContainer.Controls.Add(CreateBubble(msg));

                pnlChatContainer.ScrollControlIntoView(
                    pnlChatContainer.Controls[pnlChatContainer.Controls.Count - 1]
                );
            }));
        }

        // ======================================================
        // =================== TẠO BUBBLE UI ====================
        // ======================================================
        private Control CreateBubble(Messagemodels msg)
        {
            bool isMine = msg.fromUserId == myUserId;

            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(300, 0),
                BackColor = isMine ? Color.LightBlue : Color.LightGray,
                Padding = new Padding(10),
                Margin = new Padding(10),
            };

            Label lbl = new Label
            {
                Text = msg.text,
                AutoSize = true,
                Font = new Font("Segoe UI", 11F)
            };

            bubble.Controls.Add(lbl);

            FlowLayoutPanel wrapper = new FlowLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                FlowDirection = isMine ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            wrapper.Controls.Add(bubble);
            return wrapper;
        }
    }
}
