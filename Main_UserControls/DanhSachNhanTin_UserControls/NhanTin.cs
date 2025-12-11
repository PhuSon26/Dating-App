using Google.Cloud.Firestore;
using LOGIN;
using LOGIN.Main_UserControls.DanhSachNhanTin_UserControls;
using LOGIN.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private USER targetUser;
        private string myUserId;
        private string conversationId;
        private List<Messagemodels> currentMessages = new List<Messagemodels>();

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
                Text = "📹",
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
            pnlChatContainer = new FlowLayoutPanel
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

            // Thêm controls vào form
            Controls.Add(pnlChatContainer);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
        }
        private async void BtnVideoCall_Click(object sender, EventArgs e)
        {
            try
            {
                btnVideoCall.Enabled = false;

                System.Diagnostics.Debug.WriteLine($"Bắt đầu gọi video tới {targetUser.ten}");

                // Hiển thị form video call
                VideoCallForm videoForm = new VideoCallForm(
                    myUserId,
                  "bạn",
                    targetUser.Id,
                    targetUser.ten,
                    firebase
                );

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
        private void OnIncomingVideoCall(VideoCall call)
        {
            // Chỉ xử lý nếu cuộc gọi từ người đang chat
            if (call.CallerId != targetUser.Id) return;

            System.Diagnostics.Debug.WriteLine($"Nhận cuộc gọi video từ {call.CallerName}");

            this.Invoke(new Action(async () =>
            {
                // Hiển thị dialog xác nhận
                var result = MessageBox.Show(
                    $"{call.CallerName} đang gọi video cho bạn.\n\nBạn có muốn trả lời không?",
                    "Cuộc gọi đến",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Trả lời cuộc gọi
                        VideoCallForm videoForm = new VideoCallForm(
                            myUserId,
                            Session.LocalId ?? "Bạn",
                            call.CallerId,
                            call.CallerName,
                            firebase,
                            call.CallId
                        );

                        videoForm.Show();
                        await videoForm.AnswerIncoming(call);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi trả lời cuộc gọi: {ex.Message}", "Lỗi");
                        System.Diagnostics.Debug.WriteLine($"Lỗi answer call: {ex.Message}");
                    }
                }
                else
                {
                    // Từ chối cuộc gọi
                    try
                    {
                        await firebase.RejectCall(call.CallId);
                        System.Diagnostics.Debug.WriteLine("Đã từ chối cuộc gọi");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lỗi reject call: {ex.Message}");
                    }
                }
            }));
        }

        /// <summary>
        /// Xử lý khi cuộc gọi được chấp nhận
        /// </summary>
        private void OnVideoCallAccepted(VideoCall call)
        {
            System.Diagnostics.Debug.WriteLine($"Cuộc gọi {call.CallId} đã được chấp nhận");
            // VideoCallForm sẽ xử lý phần này
        }

        /// <summary>
        /// Xử lý khi cuộc gọi bị từ chối
        /// </summary>
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

        /// <summary>
        /// Xử lý khi cuộc gọi kết thúc
        /// </summary>
        private void OnVideoCallEnded(VideoCall call)
        {
            System.Diagnostics.Debug.WriteLine($"Cuộc gọi {call.CallId} đã kết thúc");
            // VideoCallForm sẽ tự đóng
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

        // ======================================================
        // ====================== LOAD LISTENER =================
        // ======================================================
        private async void NhanTin_Load(object sender, EventArgs e)
        {
            this.btnBack.Enabled = false;
            this.btnSend.Enabled = false;
            this.picAvatar.Enabled = false;
            LoadingSpinner loading = new LoadingSpinner(this);
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
                        return m.timestamp.ToDateTime();
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
            string text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || text == "Nhập tin nhắn...") return;

            string messageToSend = text;
            txtMessage.Clear();
            txtMessage.Text = "Nhập tin nhắn...";
            txtMessage.ForeColor = Color.Gray;

            btnSend.Enabled = false;

            try
            {
                System.Diagnostics.Debug.WriteLine($"Đang gửi tin: {messageToSend}");

                await firebase.SendMessage(myUserId, targetUser.Id, messageToSend);
                await firebase.UpdateChatMeta(myUserId, targetUser.Id, messageToSend);

                System.Diagnostics.Debug.WriteLine("Tin đã gửi thành công");

                // TẢI LẠI TIN NHẮN SAU KHI GỬI
                await Task.Delay(500); // Đợi Firestore cập nhật
                await LoadExistingMessages();
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
            System.Diagnostics.Debug.WriteLine($"=== UpdateUIWithMessages BẮT ĐẦU ===");
            System.Diagnostics.Debug.WriteLine($"Số tin nhắn: {messages?.Count ?? 0}");
            System.Diagnostics.Debug.WriteLine($"InvokeRequired: {pnlChatContainer.InvokeRequired}");

            if (pnlChatContainer.InvokeRequired)
            {
                System.Diagnostics.Debug.WriteLine("Đang Invoke...");
                pnlChatContainer.Invoke(new Action(() => UpdateUIWithMessages(messages)));
                return;
            }

            System.Diagnostics.Debug.WriteLine("Bắt đầu cập nhật UI...");

            bool shouldScrollToBottom = false;
            if (pnlChatContainer.Controls.Count > 0)
            {
                shouldScrollToBottom = pnlChatContainer.VerticalScroll.Value >=
                    pnlChatContainer.VerticalScroll.Maximum - pnlChatContainer.Height - 50;
            }
            else
            {
                shouldScrollToBottom = true;
            }

            pnlChatContainer.SuspendLayout();
            pnlChatContainer.Controls.Clear();
            System.Diagnostics.Debug.WriteLine("Đã clear controls");

            if (messages == null || messages.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("Hiển thị UI rỗng");
                Label lblEmpty = new Label
                {
                    Text = "Chưa có tin nhắn nào.\nHãy bắt đầu cuộc trò chuyện!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Padding = new Padding(0, 50, 0, 0),
                    Dock = DockStyle.Top
                };
                pnlChatContainer.Controls.Add(lblEmpty);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Đang tạo bubble cho {messages.Count} tin nhắn");
                string lastDate = "";

                foreach (var msg in messages)
                {
                    System.Diagnostics.Debug.WriteLine($"Tin: {msg.text} từ {msg.fromUserId}");

                    DateTime msgDateTime;
                    try
                    {
                        msgDateTime = msg.timestamp.ToDateTime();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lỗi convert timestamp: {ex.Message}");
                        msgDateTime = DateTime.Now;
                    }

                    string msgDate = msgDateTime.ToString("dd/MM/yyyy");
                    if (msgDate != lastDate)
                    {
                        pnlChatContainer.Controls.Add(CreateDateSeparator(msgDateTime));
                        lastDate = msgDate;
                    }

                    pnlChatContainer.Controls.Add(CreateBubble(msg));
                }

                System.Diagnostics.Debug.WriteLine($"Đã tạo {pnlChatContainer.Controls.Count} controls");
            }

            pnlChatContainer.ResumeLayout();
            System.Diagnostics.Debug.WriteLine("ResumeLayout hoàn thành");

            if (shouldScrollToBottom && pnlChatContainer.Controls.Count > 0)
            {
                pnlChatContainer.ScrollControlIntoView(
                    pnlChatContainer.Controls[pnlChatContainer.Controls.Count - 1]
                );
                System.Diagnostics.Debug.WriteLine("Đã scroll xuống");
            }

            currentMessages = messages;
            System.Diagnostics.Debug.WriteLine($"=== UpdateUIWithMessages KẾT THÚC ===");
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
                msgTime = msg.timestamp.ToDateTime();
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

            // Thay đổi chính ở đây
            Panel wrapper = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = isMine ? DockStyle.Right : DockStyle.Left,  // Sát phải nếu của mình, sát trái nếu của người khác
                Margin = new Padding(0, 2, 0, 2),
                Padding = new Padding(10, 0, 10, 0)  // Thêm padding để không sát mép quá
            };
            wrapper.Controls.Add(bubble);

            return wrapper;
        }
        private void flPanel_tinNhan_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            listener?.StopAsync();
            base.OnHandleDestroyed(e);
        }
    }
}