using Google.Cloud.Firestore;
using LOGIN;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using LOGIN.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Main_Interface.User_Controls
{
    public partial class NhanTin : UserControl
    {
        private readonly FirebaseAuthHelper auth;
        private readonly Main mainForm;
        private Button btnSendImage;
        

        public NhanTin(Main mainForm /* + các tham số khác nếu có */)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.auth = mainForm.auth;
            
        }
        private string currentMatchId;
        private Panel pnlHeader;
        private PictureBox picAvatar;
        private Label lblUserName;
        private Label lblStatus;
        private Button btnBack;
        private RoundedButton btnVideoCall; 
        private FlowLayoutPanel pnlChatContainer;
        private Panel pnlBottom;
        private TextBox txtMessage;
        private RoundedGlossyButton btnSend;
        private Main MainForm;

        private readonly FirebaseAuthHelper firebase;
        private FirestoreChangeListener listener;
        private FirestoreChangeListener blockListener;

        private USER targetUser;
        private string myUserId;
        private string conversationId;
        private List<Messagemodels> currentMessages = new List<Messagemodels>();

        private bool isBlocked = false;
        private RoundedGlossyButton btnBlock;
        LoadingSpinner loading;

        public NhanTin(USER user, Main m)
        {
            targetUser = user;
            myUserId = Session.LocalId;


            if (m.auth == null)
            {
                m.auth = new FirebaseAuthHelper("login-bb104");
             
            }
            this.firebase = m.auth;

            conversationId = firebase.GetConversationId(myUserId, targetUser.Id);

            InitializeComponent();
            this.Load += NhanTin_Load;
            SetupCustomUI();
            MainForm = m;

          
            this.auth = m.auth;
            this.firebase = m.auth;

            loading = new LoadingSpinner(MainForm.lblLogo);
        }
        // ======================================================
        // ====================== UI CHAT ========================
        // ======================================================
        private void SetupCustomUI()
        {
            this.BackColor = Color.White;

            // HEADER - Thông tin người chat
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(37, 211, 102),
                Padding = new Padding(10)
            };

            // Nút quay lại
            btnBack = new Button
            {
                Text = "←",
                Size = new Size(50, 50),
                Location = new Point(10, 15),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += BtnBack_Click;

            // Avatar
            picAvatar = new PictureBox
            {
                Width = 60,
                Height = 60,
                Location = new Point(70, 15),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White
            };
            picAvatar.Cursor = Cursors.Hand;
            picAvatar.Click += PicAvatar_Click;
            // Bo tròn avatar
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);

            picAvatar.Image = firebase.Base64ToImage(targetUser.AvatarUrl);
            lblUserName = new Label
            {
                Text = string.IsNullOrWhiteSpace(targetUser.ten) ? "Anonymous" : targetUser.ten,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(130, 20)
            };

            lblStatus = new Label
            {
                Text = "Đang hoạt động",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(220, 255, 220),
                AutoSize = true,
                Location = new Point(130, 43)
            };
            ///Nút Call video
            btnVideoCall = new RoundedButton
            {
                Text = "🎥",
                Size = new Size(120, 80),
                Location = new Point(pnlHeader.Width - 240, 0),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnVideoCall.FlatAppearance.BorderSize = 0;
            btnVideoCall.Click += BtnVideoCall_Click;

            // Bo tròn nút video call
            System.Drawing.Drawing2D.GraphicsPath pathVideo = new System.Drawing.Drawing2D.GraphicsPath();
            pathVideo.AddEllipse(0, 0, btnVideoCall.Width, btnVideoCall.Height);
            btnVideoCall.Region = new Region(pathVideo);

            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(picAvatar);
            pnlHeader.Controls.Add(lblUserName);
            pnlHeader.Controls.Add(lblStatus);
          
            pnlHeader.Controls.Add(btnVideoCall);
          

            // PANEL CHỨA TIN NHẮN
            pnlChatContainer = new DoubleBufferedFlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(240, 242, 245),
                Padding = new Padding(10, 10, 10, 10)
            };

            // PANEL NHẬP TIN NHẮN
            pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            // Viền trên cho panel nhập tin
            pnlBottom.Paint += (s, e) =>
            {
                e.Graphics.DrawLine(
                    new Pen(Color.FromArgb(220, 220, 220)),
                    0, 0, pnlBottom.Width, 0
                );
            };

            // BUTTON GỬI
            btnSend = new RoundedGlossyButton
            {
                Text = "➤",
                Size = new Size(50, 50),
                Dock = DockStyle.Right,
                BackColor = Color.FromArgb(37, 211, 102),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.Click += BtnSend_Click;

            // Ô NHẬP TIN NHẮN
            txtMessage = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F),
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(10)
            };

            // Placeholder text
            txtMessage.Text = "Nhập tin nhắn...";
            txtMessage.ForeColor = Color.Gray;

            txtMessage.Enter += (s, e) =>
            {
                if (txtMessage.Text == "Nhập tin nhắn...")
                {
                    txtMessage.Text = "";
                    txtMessage.ForeColor = Color.Black;
                }
            };

            txtMessage.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    txtMessage.Text = "Nhập tin nhắn...";
                    txtMessage.ForeColor = Color.Gray;
                }
            };

            // Cho phép Enter để gửi
            txtMessage.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !e.Control)
                {
                    e.SuppressKeyPress = true;
                    BtnSend_Click(null, null);
                }
            };

            Panel txtContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0)
            };
            txtContainer.Controls.Add(txtMessage);

            pnlBottom.Controls.Add(txtContainer);
            pnlBottom.Controls.Add(btnSend);
            SetupBlockButton();

            // Thêm controls vào form
            Controls.Add(pnlChatContainer);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            btnSendImage = new Button
            {
                Text = "📷",
                Size = new Size(50, 50),
                Dock = DockStyle.Left,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Font = new Font("Segoe UI Emoji", 14F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            btnSendImage.FlatAppearance.BorderSize = 0;
            btnSendImage.Click += btnSendImage_Click;

            // thêm nút vào panel chứa ô nhập tin nhắn
            pnlBottom.Controls.Add(btnSendImage);
        }
        private async void BtnVideoCall_Click(object sender, EventArgs e)
        {
            if (Session.IsBusy) return;
            try
            {
                btnVideoCall.Enabled = false;
                Session.IsBusy = true;
                System.Diagnostics.Debug.WriteLine($"Bắt đầu gọi video tới {targetUser.ten}");

                string myName ="Người Dùng";


                VideoCallForm videoForm = new VideoCallForm(
                    myUserId,
                    myName
                  ,
                    targetUser.Id,
                    targetUser.ten,
                    firebase
                );
                videoForm.FormClosed += (s, args) =>
                {
                    Session.IsBusy = false;
                };

                videoForm.Show();

                // Bắt đầu cuộc gọi
                await videoForm.StartOutgoingCall();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo video call: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Lỗi video call: {ex.Message}");
            }
            finally
            {
                btnVideoCall.Enabled = true;
            }
        }
      

       

      
        private void OnVideoCallRejected(VideoCall call)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(
                    $"{targetUser.ten} đã từ chối cuộc gọi",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }));
        }

       
        private void PicAvatar_Click(object sender, EventArgs e)
        {
            HoSoNguoiKhac hsnk = new HoSoNguoiKhac(targetUser, firebase);
            hsnk.ShowDialog();
        }

        // ======================================================
        // ==================== QUAY LẠI ========================
        // ======================================================
        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Dừng listener
            listener?.StopAsync();
            MainForm.LoadContent(MainForm.dstn);
        }

        private async void SetupBlockButton()
        {
            btnBlock = new RoundedGlossyButton
            {
                Size = new Size(120, 80),
                Location = new Point(pnlHeader.Width - 120, 0),
                BackColor = Color.Red,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnBlock.FlatAppearance.BorderSize = 0;
            btnBlock.Click += async (s, e) =>
            {
                btnSend.Enabled = false;
                btnBack.Enabled = false;
                btnBlock.Enabled = false;
                btnSendImage.Enabled = false;
                loading.Show();
                if (!isBlocked)
                {
                    await firebase.BlockUser(myUserId, targetUser.Id);
                }
                else
                {
                    await firebase.UnblockUser(myUserId, targetUser.Id);
                }
                await LoadBlockState();
                loading.Hide();
                btnBlock.Enabled = true;
                btnBack.Enabled = true;
                btnSend.Enabled = true;
                btnSendImage.Enabled = true;
            };
            pnlHeader.Controls.Add(btnBlock);
            await LoadBlockState();
        }
        /*
        private async Task LoadBlockState()
        {
            if (isBlocked)
            {
                btnBlock.Text = "Unblock";
                btnSend.Enabled = false;
                txtMessage.Enabled = false;
                txtMessage.Text = "Đã bị chặn";
            }
            else
            {
                btnBlock.Text = "Block";
                btnSend.Enabled = true;
                txtMessage.Enabled = true;
                txtMessage.Text = "Nhập tin nhắn...";
            }
        }
        */
        private async Task LoadBlockState()
        {
            try
            {
                var blockedList = await firebase.GetBlockedList(myUserId, targetUser.Id);
                bool iAmBlocked = blockedList.Contains(targetUser.Id); // người kia block mình
                bool iBlocked = blockedList.Contains(myUserId);        // mình block người kia

                isBlocked = iAmBlocked || iBlocked;

                if (iBlocked)
                {
                    btnBlock.Text = "Unblock";
                    btnSend.Enabled = false;
                    txtMessage.Enabled = false;
                    txtMessage.Text = "Bạn đã chặn người này";
                }
                else if (iAmBlocked)
                {
                    btnBlock.Text = "Block";
                    btnSend.Enabled = false;
                    txtMessage.Enabled = false;
                    txtMessage.Text = "Bạn đã bị chặn";
                }
                else
                {
                    btnBlock.Text = "Block";
                    btnSend.Enabled = true;
                    txtMessage.Enabled = true;
                    txtMessage.Text = "Nhập tin nhắn...";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi LoadBlockState: " + ex.Message);
            }
        }


        // ======================================================
        // ====================== LOAD LISTENER =================
        // ======================================================
        private async void NhanTin_Load(object sender, EventArgs e)
        {
            this.btnBack.Enabled = false;
            this.btnSend.Enabled = false;
            this.picAvatar.Enabled = false;
            this.btnBlock.Enabled = false;
            loading.Show();
            System.Diagnostics.Debug.WriteLine($"NhanTin_Load - MyUserId: {myUserId}, TargetUserId: {targetUser.Id}");
            System.Diagnostics.Debug.WriteLine($"ConversationId: {conversationId}");

            ShowLoadingMessage();

            try
            {
                // Tạo ChatMeta nếu chưa có
                await firebase.CreateChatMeta(myUserId, targetUser.Id);

                System.Diagnostics.Debug.WriteLine("Đang tải tin nhắn cũ...");

                // TẢI TIN NHẮN CŨ TRƯỚC
                await LoadExistingMessages();
                StartBlockListener();

                System.Diagnostics.Debug.WriteLine("Đang bắt đầu listener...");

                // SAU ĐÓ MỚI BẮT ĐẦU LISTENER
                listener = firebase.ListenToMessages(
                    myUserId,
                    targetUser.Id,
                    UpdateUIWithMessages
                );

                System.Diagnostics.Debug.WriteLine("Listener đã bắt đầu");

                // Reset số tin chưa đọc
                await firebase.ResetUnread(myUserId, targetUser.Id);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LỖI: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khởi tạo chat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loading.Hide();
            this.btnBack.Enabled = true;
            this.btnSend.Enabled = true;
            this.picAvatar.Enabled = true;
            this.btnBlock.Enabled = true;
        }
        private void StartBlockListener()
        {
            string chatId = firebase.GetConversationId(myUserId, targetUser.Id);

            blockListener = firebase.db.Collection("ChatMeta").Document(chatId)
                .Listen(snapshot =>
                {
                    if (!snapshot.Exists) return;

                    List<string> blockedBy;
                    if (!snapshot.TryGetValue("blockedBy", out blockedBy))
                    {
                        blockedBy = new List<string>(); // chưa bị ai block
                    }

                    bool iAmBlocked = blockedBy.Contains(targetUser.Id); // người kia block mình

                    if (iAmBlocked != isBlocked)
                    {
                        this.Invoke(new Action(async () =>
                        {
                            isBlocked = iAmBlocked;
                            await LoadBlockState();
                        }));
                    }
                });
        }
        // TẢI TIN NHẮN CŨ
        private async Task LoadExistingMessages()
        {
            try
            {
              

              
                var messagesRef = firebase.db.Collection("messages")
                                    .WhereEqualTo("ChatId", conversationId);

                var snapshot = await messagesRef.GetSnapshotAsync();

                System.Diagnostics.Debug.WriteLine($"Tìm thấy {snapshot.Documents.Count} tin nhắn");

                List<Messagemodels> messages = new List<Messagemodels>();

                foreach (var doc in snapshot.Documents)
                {
                    var msg = doc.ConvertTo<Messagemodels>();
                    msg.Id = doc.Id;
                    messages.Add(msg);
                }

                
                messages = messages.OrderBy(m =>
                {
                    try
                    {
                        if (m.timestamp == null) return DateTime.Now;

                        return m.timestamp.ToDateTime().ToLocalTime();
                    }
                    catch
                    {
                        return DateTime.MinValue;
                    }
                }).ToList();

              

                if (messages.Count > 0)
                {
                    UpdateUIWithMessages(messages);
                }
                else
                {
                   
                    UpdateUIWithMessages(new List<Messagemodels>());
                }
            }
            catch (Exception ex)
            {
               
                UpdateUIWithMessages(new List<Messagemodels>());
            }
        }

        private void ShowLoadingMessage()
        {
            if (pnlChatContainer.InvokeRequired)
            {
                pnlChatContainer.Invoke(new Action(ShowLoadingMessage));
                return;
            }

            pnlChatContainer.Controls.Clear();
            Label lblLoading = new Label
            {
                Text = "Đang tải tin nhắn...",
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0, 20, 0, 0)
            };
            pnlChatContainer.Controls.Add(lblLoading);
        }

        // ======================================================
        // ======================= GỬI TIN =======================
        // ======================================================
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            if (isBlocked) return;
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || text == "Nhập tin nhắn...") return;

            string messageToSend = text;
            txtMessage.Clear();
          

            btnSend.Enabled = false;

            try
            {
                System.Diagnostics.Debug.WriteLine($"Đang gửi tin: {messageToSend}");

                await firebase.SendMessage(myUserId, targetUser.Id, messageToSend);
                await firebase.UpdateChatMeta(myUserId, targetUser.Id, messageToSend);
                await firebase.PushNotificationAsync(
                    Session.LocalId,
                    "user",
                    targetUser.Id,
                    messageToSend,
                    "message"
                    );

                System.Diagnostics.Debug.WriteLine("Tin đã gửi thành công");

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi gửi tin: {ex.Message}");
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMessage.Text = messageToSend;
                txtMessage.ForeColor = Color.Black;
            }
            finally
            {
                btnSend.Enabled = true;
                txtMessage.Focus();
            }
        }

        // ======================================================
        // ====================== HIỂN THỊ TIN ===================
        // ======================================================
        private void UpdateUIWithMessages(List<Messagemodels> messages)
        {
            if (pnlChatContainer.InvokeRequired)
            {
                pnlChatContainer.Invoke(new Action(() => UpdateUIWithMessages(messages)));
                return;
            }


            // Nếu rỗng
            if (messages == null || messages.Count == 0)
            {
                pnlChatContainer.Controls.Clear();
                return;
            }

            bool isAtBottom = IsScrolledToBottom();

            // Nếu tin mới là của mình => tự động scroll
            if (currentMessages.Count == 0 || (messages.Count > 0 && messages.Last().fromUserId == myUserId))
            {
                isAtBottom = true;
            }

            pnlChatContainer.SuspendLayout();



            var newMsgs = messages.Where(m => !currentMessages.Any(cm => cm.Id == m.Id)).ToList();
            if (newMsgs.Count > 0)
            {
                UpdateIncrementally(messages); // Logic cũ của bạn để thêm tin mới vẫn ổn
            }
            foreach (var msg in messages)
            {
                var oldMsg = currentMessages.FirstOrDefault(cm => cm.Id == msg.Id);
                if (oldMsg != null)
                {
                    // Kiểm tra xem Reaction có thay đổi không
                    if (IsReactionChanged(oldMsg, msg))
                    {
                        // CHỈ cập nhật thanh reaction, KHÔNG vẽ lại cả tin nhắn
                        UpdateReactionUIOnly(msg.Id, msg.reaction);

                        // Cập nhật lại data trong list local
                        oldMsg.reaction = msg.reaction;
                    }
                }
            }
            currentMessages = messages;
            pnlChatContainer.ResumeLayout();

            if (isAtBottom)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(50);
                    this.Invoke(new Action(() => ScrollToBottom()));
                });
            }
        }

        // ===== HELPER METHODS =====

        private bool ShouldRedrawAll(List<Messagemodels> newMessages)
        {
            // Vẽ lại toàn bộ nếu:
            // 1. Lần đầu load (chưa có tin)
            if (currentMessages.Count == 0) return true;

            // 2. Số lượng tin giảm (có tin bị xóa)
            if (newMessages.Count < currentMessages.Count) return true;

            // 3. Có reaction thay đổi
            foreach (var newMsg in newMessages)
            {
                var oldMsg = currentMessages.FirstOrDefault(m => m.Id == newMsg.Id);
                if (IsReactionChanged(oldMsg, newMsg)) return true;
            }

            // 4. Có tin bị thu hồi
            foreach (var newMsg in newMessages)
            {
                var oldMsg = currentMessages.FirstOrDefault(m => m.Id == newMsg.Id);
                if (oldMsg != null && oldMsg.text != newMsg.text) return true;
            }

            return false;
        }

        private void UpdateIncrementally(List<Messagemodels> messages)
        {
            string lastDate = "";

            if (currentMessages.Count > 0)
            {
                try
                {
                    lastDate = currentMessages.Last().timestamp.ToDateTime().ToLocalTime().ToString("dd/MM/yyyy");
                }
                catch { }
            }

            // Chỉ thêm tin mới (sau tin cuối cùng hiện tại)
            int startIndex = currentMessages.Count;

            for (int i = startIndex; i < messages.Count; i++)
            {
                var msg = messages[i];
                DateTime msgDateTime;
                try { msgDateTime = msg.timestamp.ToDateTime().ToLocalTime(); }
                catch { msgDateTime = DateTime.Now; }

                string msgDate = msgDateTime.ToString("dd/MM/yyyy");
                if (msgDate != lastDate)
                {
                    pnlChatContainer.Controls.Add(CreateDateSeparator(msgDateTime));
                    lastDate = msgDate;
                }

                pnlChatContainer.Controls.Add(CreateBubble(msg));
            }
        }

        private bool IsReactionChanged(Messagemodels oldMsg, Messagemodels newMsg)
        {
            if (oldMsg == null) return false;
            if (oldMsg.reaction == null && newMsg.reaction == null) return false;
            if (oldMsg.reaction == null || newMsg.reaction == null) return true;

            if (oldMsg.reaction.Count != newMsg.reaction.Count) return true;

            foreach (var kvp in newMsg.reaction)
            {
                if (!oldMsg.reaction.ContainsKey(kvp.Key) || oldMsg.reaction[kvp.Key] != kvp.Value)
                    return true;
            }

            return false;
        }
       
        private void ScrollToBottom()
        {
            // Cách cuộn triệt để nhất trong WinForms
            pnlChatContainer.AutoScrollPosition = new Point(0, pnlChatContainer.VerticalScroll.Maximum);
            pnlChatContainer.VerticalScroll.Value = pnlChatContainer.VerticalScroll.Maximum;
            pnlChatContainer.PerformLayout();
        }

        private bool IsScrolledToBottom()
        {
            // Kiểm tra xem thanh cuộn có đang ở gần đáy không
            int totalHeight = pnlChatContainer.VerticalScroll.Maximum;
            int visibleHeight = pnlChatContainer.ClientSize.Height;
            int currentPos = pnlChatContainer.VerticalScroll.Value;

            // Cho phép sai số 50px
            return (totalHeight - visibleHeight - currentPos) < 50;
        }

        // ======================================================
        // =================== NGĂN CÁCH NGÀY ====================
        // ======================================================
        private Control CreateDateSeparator(DateTime date)
        {
            Panel separator = new Panel
            {
                Height = 40,
                Width = pnlChatContainer.Width - 30,
                Margin = new Padding(0, 10, 0, 10)
            };

            Label lblDate = new Label
            {
                Text = GetDateText(date),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                BackColor = Color.White,
                Padding = new Padding(10, 5, 10, 5),
                TextAlign = ContentAlignment.MiddleCenter
            };

            separator.Resize += (s, e) =>
            {
                lblDate.Location = new Point(
                    (separator.Width - lblDate.Width) / 2,
                    (separator.Height - lblDate.Height) / 2
                );
            };

            separator.Controls.Add(lblDate);
            return separator;
        }

        private string GetDateText(DateTime date)
        {
            var today = DateTime.Today;
            var diff = (today - date.Date).Days;

            if (diff == 0) return "Hôm nay";
            if (diff == 1) return "Hôm qua";
            if (diff < 7) return date.ToString("dddd, dd/MM");
            return date.ToString("dd/MM/yyyy");
        }

        // ======================================================
        // =================== TẠO BUBBLE UI ====================
        // ======================================================
        private Control CreateBubble(Messagemodels msg)
        {
            bool isMine = msg.fromUserId == myUserId;

            Panel wrapper = CreateWrapper(isMine);
            Panel bubble = CreateBubblePanel(isMine);
            wrapper.Name = msg.Id;

            TableLayoutPanel layout = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 1
            };

            Label textLabel = null;
            PictureBox imageBox = null;

            if (!string.IsNullOrWhiteSpace(msg.text))
            {
                textLabel = CreateTextLabel(msg.text, isMine);
                layout.Controls.Add(textLabel);
            }

            if (!string.IsNullOrWhiteSpace(msg.imageBase64))
            {
                imageBox = CreateImageBox(msg.imageBase64);
                layout.Controls.Add(imageBox);
            }

            layout.Controls.Add(CreateTimeLabel(msg));
            var reactionBar = CreateReactionBar(msg);
            if (reactionBar != null)
                layout.Controls.Add(reactionBar);

            bubble.Controls.Add(layout);
            wrapper.Controls.Add(bubble);

            // ✅ GÁN DOUBLE CLICK CHO TẤT CẢ CONTROLS
            AttachDoubleClickHandler(bubble, msg);
            AttachDoubleClickHandler(layout, msg);
            if (textLabel != null) AttachDoubleClickHandler(textLabel, msg);
            if (imageBox != null) AttachDoubleClickHandler(imageBox, msg);

            AttachContextMenu(bubble, msg, isMine);

            return wrapper;
        }
        private void AttachDoubleClickHandler(Control control, Messagemodels msg)
        {
            control.Cursor = Cursors.Hand; // Hiển thị con trỏ tay
            control.DoubleClick += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"🖱️ Double click detected trên {control.GetType().Name}");
                ShowEmojiPopup(control, msg);
            };
        }


     
        private Panel CreateWrapper(bool isMine)
        {
            return new Panel
            {
                AutoSize = true,
                Dock = isMine ? DockStyle.Right : DockStyle.Left,
                Padding = new Padding(10, 0, 10, 0),
                Margin = new Padding(0, 2, 0, 2)
            };
        }
        private Panel CreateBubblePanel(bool isMine)
        {
            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(400, 0),
                BackColor = isMine ? Color.FromArgb(37, 211, 102) : Color.White,
                Padding = new Padding(12, 8, 12, 8)
            };

            bubble.Paint += (s, e) =>
            {
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                int r = 15;
                Rectangle rect = new Rectangle(0, 0, bubble.Width - 1, bubble.Height - 1);
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                bubble.Region = new Region(path);
                if (!isMine)
                    e.Graphics.DrawPath(Pens.LightGray, path);
            };

            return bubble;
        }
        private Label CreateTextLabel(string text, bool isMine)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                MaximumSize = new Size(370, 0),
                Font = new Font("Segoe UI", 10F),
                ForeColor = isMine ? Color.White : Color.Black
            };
        }
        private PictureBox CreateImageBox(string base64)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(250, 250),
                SizeMode = PictureBoxSizeMode.CenterImage, // Hiển thị icon loading ở giữa
                Margin = new Padding(0, 5, 0, 5),
                Cursor = Cursors.Hand,
                BackColor = Color.WhiteSmoke // Màu nền tạm
            };

           
            Task.Run(() =>
            {
                try
                {
                    Image img = firebase.Base64ToImage(base64); // Hàm nặng

                    // Quay lại UI thread để gán ảnh
                    pb.Invoke(new Action(() =>
                    {
                        pb.Image = img;
                        pb.SizeMode = PictureBoxSizeMode.Zoom; // Chuyển về Zoom khi đã có ảnh
                    }));
                }
                catch { /* Xử lý lỗi ảnh hỏng */ }
            });

            return pb;
        }
        private Label CreateTimeLabel(Messagemodels msg)
        {
            DateTime time = msg.timestamp.ToDateTime().ToLocalTime();

            return new Label
            {
                Text = time.ToString("HH:mm"),
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                Anchor = AnchorStyles.Right
            };
        }
        private void AttachContextMenu(Control target, Messagemodels msg, bool isMine)
        {
            var menu = new ContextMenuStrip();

            menu.Items.Add("Xóa phía tôi", null, async (_, __) =>
                await firebase.DeleteMessageForMeAsync(msg.Id, Session.LocalId));

            if (isMine)
            {
                menu.Items.Add("Thu hồi (cả 2 bên)", null, async (_, __) =>
                    await firebase.RecallMessageForAllAsync(msg.Id, Session.LocalId));
            }

            target.ContextMenuStrip = menu;
        }
        private void ShowEmojiPopup(Control sourceControl, Messagemodels msg)
        {
            System.Diagnostics.Debug.WriteLine($"🎭 ShowEmojiPopup được gọi cho tin: {msg.Id}");

            // Tạo Form nhỏ làm popup
            Form popup = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ShowInTaskbar = false,
                TopMost = true,
                BackColor = Color.Lime,        
                TransparencyKey = Color.Lime,
                Padding = new Padding(5)
            };

            FlowLayoutPanel emojiPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5),
                BackColor = Color.Transparent
            };

            // Thêm border cho popup
            /*
            popup.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, popup.Width - 1, popup.Height - 1);
                }
            };
            */

            string[] emojiNames = { "like", "tim", "haha", "sad", "wow", "phanno" };

            foreach (var name in emojiNames)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(30, 30), // Tăng kích thước để dễ click hơn
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(3),
                    Name = name,
                    BackColor = Color.Transparent
                };

                try
                {
                    pb.Image = (Image)LOGIN.Properties.Resource.ResourceManager.GetObject(name);
                    System.Diagnostics.Debug.WriteLine($"  ✅ Load emoji {name} thành công");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"  ❌ Lỗi load emoji {name}: {ex.Message}");
                    continue;
                }

                // Hiệu ứng hover
                pb.MouseEnter += (s, e) =>
                {
                    pb.BackColor = Color.FromArgb(240, 240, 240);
                };

                pb.MouseLeave += (s, e) =>
                {
                    pb.BackColor = Color.Transparent;
                };

                pb.Click += async (s, e) =>
                {
                    popup.Close();

                    try
                    {
                        if (msg.reaction == null)
                            msg.reaction = new Dictionary<string, string>();
                        string oldReaction = msg.reaction.ContainsKey(myUserId) ? msg.reaction[myUserId] : null;


                        msg.reaction[myUserId] = name;
                        UpdateReactionUIOnly(msg.Id, msg.reaction);

                        try
                        {
                            // 4. Gửi lên Firebase (Chạy ngầm)
                            await firebase.AddReaction(msg.Id, myUserId, name);
                        }
                        catch (Exception ex)
                        {
                            // Nếu lỗi, hoàn tác lại UI và Model
                            if (oldReaction != null) msg.reaction[myUserId] = oldReaction;
                            else msg.reaction.Remove(myUserId);

                            UpdateReactionUIOnly(msg.Id, msg.reaction); // Vẽ lại cái cũ
                            MessageBox.Show("Không thể thả cảm xúc: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"❌ Lỗi khi react: {ex.Message}");
                        MessageBox.Show($"Lỗi reaction: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                emojiPanel.Controls.Add(pb);
            }

            popup.Controls.Add(emojiPanel);
            emojiPanel.PerformLayout();
            popup.Size = new Size(
                emojiPanel.PreferredSize.Width + 10,
                emojiPanel.PreferredSize.Height + 10
            );

            // Tính toán vị trí popup
            Point screenPoint = sourceControl.PointToScreen(Point.Empty);

            if (msg.fromUserId != myUserId)
            {
                // Tin nhắn của người khác => popup bên phải
                popup.Location = new Point(screenPoint.X + sourceControl.Width + 5, screenPoint.Y);
            }
            else
            {
                // Tin nhắn của mình => popup bên trái
                popup.Location = new Point(screenPoint.X - popup.Width - 5, screenPoint.Y);
            }

            System.Diagnostics.Debug.WriteLine($"📍 Popup location: {popup.Location}");

            // Click ra ngoài để đóng popup
            popup.Deactivate += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine("❌ Popup đã đóng (deactivate)");
                popup.Close();
            };

            popup.Show();
            System.Diagnostics.Debug.WriteLine("✅ Popup đã hiển thị");
        }
        private void UpdateReactionUIOnly(string msgId, Dictionary<string, string> newReactions)
        {
            if (pnlChatContainer.InvokeRequired)
            {
                pnlChatContainer.Invoke(new Action(() => UpdateReactionUIOnly(msgId, newReactions)));
                return;
            }

            // Tìm Control bao ngoài (Wrapper) dựa trên Name = msg.Id
            Control[] wrappers = pnlChatContainer.Controls.Find(msgId, false);
            if (wrappers.Length == 0) return;

            Panel wrapper = wrappers[0] as Panel;
            Panel bubble = wrapper.Controls[0] as Panel; // Bubble nằm trong Wrapper
            TableLayoutPanel layout = bubble.Controls[0] as TableLayoutPanel; // Layout nằm trong Bubble

            // Tìm thanh ReactionBar cũ để xóa (nếu có)
            Control oldReactionBar = layout.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "ReactionBar");
            if (oldReactionBar != null)
            {
                layout.Controls.Remove(oldReactionBar);
                oldReactionBar.Dispose();
            }

            // Tạo dummy message object để tái sử dụng hàm CreateReactionBar
            Messagemodels dummyMsg = new Messagemodels { reaction = newReactions };
            Control newReactionBar = CreateReactionBar(dummyMsg);

            if (newReactionBar != null)
            {
                layout.Controls.Add(newReactionBar);
            }
        }
        private void flPanel_tinNhan_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            listener?.StopAsync();
            blockListener?.StopAsync();
            base.OnHandleDestroyed(e);
        }
        private async void btnSendImage_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Multiselect = false;

                if (dlg.ShowDialog() != DialogResult.OK) return;

                string localPath = dlg.FileName;

                // GỬI ẢNH VÀO collection "messages" (đúng nơi UI đang đọc)
                await firebase.SendImageToConversationAsync(Session.LocalId, targetUser.Id, localPath);
            }
        }
        public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
        {
            public DoubleBufferedFlowLayoutPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.UserPaint, true);
                this.UpdateStyles();
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                    return cp;
                }
            }
        }
        private Control CreateReactionBar(Messagemodels msg)
        {
            if (msg.reaction == null || msg.reaction.Count == 0)
                return null;

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Name = "ReactionBar",
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(5, 2, 5, 0)
            };

            var grouped = msg.reaction.Values
                .GroupBy(x => x)
                .Select(g => new { Emoji = g.Key, Count = g.Count() });

            foreach (var g in grouped)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(18, 18),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = (Image)LOGIN.Properties.Resource.ResourceManager.GetObject(g.Emoji)
                };

                Label lbl = new Label
                {
                    Text = g.Count.ToString(),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8F)
                };

                panel.Controls.Add(pb);
                panel.Controls.Add(lbl);
            }

            return panel;
        }


    }
}