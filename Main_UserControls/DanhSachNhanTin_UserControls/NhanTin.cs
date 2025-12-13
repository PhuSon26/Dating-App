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

namespace Main_Interface.User_Controls
{
    public partial class NhanTin : UserControl
    {
        private Panel pnlHeader;
        private PictureBox picAvatar;
        private Label lblUserName;
        private Label lblStatus;
        private Button btnBack;
        private Button btnVideoCall; 
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
            this.firebase = m.auth;
            loading = new LoadingSpinner(this);
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
            btnVideoCall = new Button
            {
                Text = "🎥",
                Size = new Size(50, 50),
                Location = new Point(pnlHeader.Width - 220, 15),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 20F),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnVideoCall.FlatAppearance.BorderSize = 0;
            btnVideoCall.Click += BtnVideoCall_Click;

            // Bo tròn nút video call
            System.Drawing.Drawing2D.GraphicsPath pathVideo = new System.Drawing.Drawing2D.GraphicsPath();
            pathVideo.AddEllipse(0, 0, btnVideoCall.Width, btnVideoCall.Height);
            btnVideoCall.Region = new Region(pathVideo);

            // NÚT REFRESH
            Button btnRefresh = new Button
            {
                Text = "🔄",
                Size = new Size(50, 30),
                Location = new Point(pnlHeader.Width - 150, 25),
                BackColor = Color.FromArgb(50, 150, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += async (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine("Đang refresh...");
                await LoadExistingMessages();
            };

           

            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(picAvatar);
            pnlHeader.Controls.Add(lblUserName);
            pnlHeader.Controls.Add(lblStatus);
            pnlHeader.Controls.Add(btnRefresh);
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
            loading.pbSpinner.BackColor = Color.FromArgb(240, 242, 245);
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
                System.Diagnostics.Debug.WriteLine($"=== ĐANG TẢI TIN NHẮN ===");
                System.Diagnostics.Debug.WriteLine($"ConversationId đang dùng: {conversationId}");
                System.Diagnostics.Debug.WriteLine($"MyUserId: {myUserId}");
                System.Diagnostics.Debug.WriteLine($"TargetUserId: {targetUser.Id}");

                // BỎ .OrderBy() ĐỂ TRÁNH LỖI INDEX
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

                // SẮP XẾP TRONG CODE THAY VÌ TRONG QUERY
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

                System.Diagnostics.Debug.WriteLine($"Đã sắp xếp {messages.Count} tin nhắn");

                if (messages.Count > 0)
                {
                    UpdateUIWithMessages(messages);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Không có tin nhắn nào");
                    UpdateUIWithMessages(new List<Messagemodels>());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi LoadExistingMessages: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
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

            // 1. Nếu danh sách rỗng hoặc null -> Xóa hết hiển thị thông báo rỗng
            if (messages == null || messages.Count == 0)
            {
                pnlChatContainer.Controls.Clear();
              
                return;
            }

            bool isAtBottom = IsScrolledToBottom();

            if (currentMessages.Count == 0 || (messages.Count > 0 && messages.Last().fromUserId == myUserId))
            {
                isAtBottom = true;
            }

            pnlChatContainer.SuspendLayout(); // Tạm dừng vẽ để đỡ giật

           
            int startIndex = 0;

            // Nếu UI đang có tin nhắn, ta chỉ lấy những tin mới hơn tin cuối cùng hiện tại
            if (currentMessages.Count > 0 && messages.Count >= currentMessages.Count)
            {
                // Giả sử messages luôn là list đầy đủ và đã sort, ta chỉ cần vẽ phần đuôi
                startIndex = currentMessages.Count;
            }
            else
            {
                // Trường hợp load lần đầu hoặc refresh -> Vẽ lại từ đầu
                pnlChatContainer.Controls.Clear();
                startIndex = 0;
            }

            // 3. Vòng lặp chỉ chạy qua các tin nhắn MỚI
            string lastDate = "";

            // Lấy ngày của tin nhắn cuối cùng đang hiện (nếu có) để so sánh separator
            if (startIndex > 0 && currentMessages.Count > 0)
            {
                try
                {
                    lastDate = currentMessages.Last().timestamp.ToDateTime().ToLocalTime().ToString("dd/MM/yyyy");
                }
                catch { }
            }

            for (int i = startIndex; i < messages.Count; i++)
            {
                var msg = messages[i];
                DateTime msgDateTime;
                try { msgDateTime = msg.timestamp.ToDateTime().ToLocalTime(); }
                catch { msgDateTime = DateTime.Now; }

                // Kiểm tra ngày để thêm thanh ngăn cách
                string msgDate = msgDateTime.ToString("dd/MM/yyyy");
                if (msgDate != lastDate)
                {
                    pnlChatContainer.Controls.Add(CreateDateSeparator(msgDateTime));
                    lastDate = msgDate;
                }

                // Thêm tin nhắn
                pnlChatContainer.Controls.Add(CreateBubble(msg));
            }

            currentMessages = messages;
            pnlChatContainer.ResumeLayout();
            if (isAtBottom)
            {
                // Hack nhẹ: Đợi UI vẽ xong mới cuộn
                Task.Run(async () =>
                {
                    await Task.Delay(50); // Đợi 50ms cho layout ổn định
                    this.Invoke(new Action(() =>
                    {
                        ScrollToBottom();
                    }));
                });
            }

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
            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(400, 0),
                MinimumSize = new Size(80, 0),
                BackColor = isMine ? Color.FromArgb(37, 211, 102) : Color.White,
                Padding = new Padding(12, 8, 12, 8),
                Margin = new Padding(5, 3, 5, 3),
            };
            bubble.Paint += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 15;
                Rectangle rect = new Rectangle(0, 0, bubble.Width - 1, bubble.Height - 1);
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                bubble.Region = new Region(path);
                if (!isMine)
                {
                    e.Graphics.DrawPath(new Pen(Color.FromArgb(220, 220, 220)), path);
                }
            };
            bubble.Cursor = Cursors.Hand;
            Label lblText = new Label
            {
                Text = msg.text ?? "",
                AutoSize = true,
                MaximumSize = new Size(370, 0),
                Font = new Font("Segoe UI", 10F),
                ForeColor = isMine ? Color.White : Color.Black,
                Padding = new Padding(0)
            };
            DateTime msgTime;
            try
            {
                msgTime = msg.timestamp.ToDateTime().ToLocalTime();
            }
            catch
            {
                msgTime = DateTime.Now;
            }
            Label lblTime = new Label
            {
                Text = msgTime.ToString("HH:mm"),
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                ForeColor = isMine ? Color.FromArgb(200, 255, 200) : Color.Gray,
                TextAlign = ContentAlignment.BottomRight,
                Padding = new Padding(0, 3, 0, 0)
            };
            TableLayoutPanel innerLayout = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(0)
            };
            innerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerLayout.Controls.Add(lblText, 0, 0);
            innerLayout.Controls.Add(lblTime, 0, 1);
            bubble.Controls.Add(innerLayout);

            // ================= REACTION =================
            FlowLayoutPanel pnlReaction = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 5, 0, 0)
            };

            if (msg.reaction != null && msg.reaction.Count > 0)
            {
                // Tính số lượng reaction cùng emoji
                var emojiCount = msg.reaction.Values
                    .GroupBy(v => v)
                    .ToDictionary(g => g.Key, g => g.Count());

                foreach (var kvp in emojiCount)
                {
                    string emojiName = kvp.Key;
                    int count = kvp.Value;

                    Panel pnlEmoji = new Panel
                    {
                        AutoSize = true,
                        Margin = new Padding(2)
                    };

                    PictureBox pb = new PictureBox
                    {
                        Size = new Size(20, 20),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    try
                    {
                        string path = Path.Combine(Application.StartupPath, "Images", $"{emojiName}.png");
                        pb.Image = Image.FromFile(path);
                    }
                    catch
                    {
                        continue;
                    }

                    Label lblCount = new Label
                    {
                        Text = count > 1 ? count.ToString() : "",
                        Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                        ForeColor = Color.Black,
                        AutoSize = true,
                        Location = new Point(pb.Width - 8, pb.Height - 10),
                        BackColor = Color.Transparent
                    };

                    pnlEmoji.Controls.Add(pb);
                    pnlEmoji.Controls.Add(lblCount);

                    pnlReaction.Controls.Add(pnlEmoji);
                }
            }

            innerLayout.Controls.Add(pnlReaction, 0, 2);
            innerLayout.RowCount = 3;
            innerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // ================= CLICK VÀ HIỆN POPUP EMOJI =================
            void AttachClick(Control parent)
            {
                parent.Click += (s, e) => { ShowEmojiPopup(bubble, msg); };
                foreach (Control c in parent.Controls)
                    AttachClick(c);
            }
            AttachClick(bubble);
            // ================= WRAPPER =================
            Panel wrapper = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = isMine ? DockStyle.Right : DockStyle.Left,
                Margin = new Padding(0, 2, 0, 2),
                Padding = new Padding(10, 0, 10, 0)
            };
            wrapper.Controls.Add(bubble);
            // ===== Context menu: Xóa phía tôi / Thu hồi =====
            var menu = new ContextMenuStrip();

            menu.Items.Add("Xóa phía tôi", null, async (_, __) =>
            {
                await firebase.DeleteMessageForMeAsync(msg.Id, Session.LocalId);
            });

            // Chỉ người gửi mới được thu hồi
            if (msg.fromUserId == Session.LocalId)
            {
                menu.Items.Add("Thu hồi (cả 2 bên)", null, async (_, __) =>
                {
                    await firebase.RecallMessageForAllAsync(msg.Id, Session.LocalId);
                });
            }

            // Gán cho wrapper + bubble + các control con (để bấm chuột phải ở đâu cũng hiện menu)
            void AttachMenu(Control parent)
            {
                parent.ContextMenuStrip = menu;
                foreach (Control c in parent.Controls) AttachMenu(c);
            }
            AttachMenu(wrapper);

            return wrapper;
        }

        private void ShowEmojiPopup(Control bubble, Messagemodels msg)
        {
            // Tạo Form nhỏ làm popup
            Form popup = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ShowInTaskbar = false,
                TopMost = true,
                BackColor = Color.Fuchsia,
                TransparencyKey = Color.Fuchsia
            };
            FlowLayoutPanel emojiPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5)
            };

            string[] emojiNames = { "like", "tim", "haha", "sad", "wow", "phanno" };
            foreach (var name in emojiNames)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(26, 26), // emoji nhỏ
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(2)
                };

                try
                {
                    string path = Path.Combine(Application.StartupPath, "Images", $"{name}.png");
                    pb.Image = Image.FromFile(path);
                }
                catch { continue; }

                pb.Click += async (s, e) =>
                {
                    if (msg.reaction == null) msg.reaction = new Dictionary<string, string>();
                    msg.reaction[myUserId] = name;
                    await firebase.AddReaction(msg.Id, myUserId, name);
                    UpdateUIWithMessages(currentMessages);
                    popup.Close();
                };

                emojiPanel.Controls.Add(pb);
            }

            popup.Controls.Add(emojiPanel);
            emojiPanel.PerformLayout();
            popup.Size = emojiPanel.PreferredSize;

            Point screenPoint = bubble.PointToScreen(Point.Empty);

            if (msg.fromUserId != Session.LocalId)
            {
                // Tin nhắn của người khác => popup bên phải bubble
                popup.Location = new Point(screenPoint.X + bubble.Width + 5, screenPoint.Y);
            }
            else
            {
                // Tin nhắn của mình => popup bên trái bubble
                popup.Location = new Point(screenPoint.X - popup.Width - 5, screenPoint.Y);
            }

            // Click ra ngoài để đóng popup
            popup.Deactivate += (s, e) => { popup.Close(); };

            popup.Show();
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
    }
}