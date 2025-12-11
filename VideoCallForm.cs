using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using LOGIN.Models;
using LOGIN;
using Firebase.Database.Query;

namespace LOGIN
{
    public partial class VideoCallForm : Form
    {
        private readonly FirebaseAuthHelper firebase;
        private readonly string localUserId;
        private readonly string localUserName;
        private readonly string remoteUserId;
        private readonly string remoteUserName;
        private string callId;
        private readonly bool isIncoming;

        private bool isMuted = false;
        private bool callStarted = false;

        // Constructor cho cuộc gọi đi (outgoing)
        public VideoCallForm(
            string localUserId,
            string localUserName,
            string remoteUserId,
            string remoteUserName,
            FirebaseAuthHelper firebase)
        {
            InitializeComponent();
            this.firebase = firebase;
            this.localUserId = localUserId;
            this.localUserName = localUserName;
            this.remoteUserId = remoteUserId;
            this.remoteUserName = remoteUserName;
            this.isIncoming = false;

            InitUI();
            this.FormClosing += VideoCallForm_FormClosing;
        }

        // Constructor cho cuộc gọi đến (incoming)
        public VideoCallForm(
            string localUserId,
            string localUserName,
            string remoteUserId,
            string remoteUserName,
            FirebaseAuthHelper firebase,
            string callId)
        {
            InitializeComponent();
            this.firebase = firebase;
            this.localUserId = localUserId;
            this.localUserName = localUserName;
            this.remoteUserId = remoteUserId;
            this.remoteUserName = remoteUserName;
            this.callId = callId;
            this.isIncoming = true;

            InitUI();
            this.FormClosing += VideoCallForm_FormClosing;
        }

        private async Task InitWebRTC()
        {
            try
            {
                // 1. Khởi tạo WebView2
                await webView.EnsureCoreWebView2Async(null);

                // 2. Đăng ký sự kiện tự động cấp quyền (Giữ nguyên phần này như bài trước)
                webView.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;

                // --- ĐOẠN SỬA ĐỔI QUAN TRỌNG ---
                // Thay vì dùng NavigateToString, ta lưu HTML ra file tạm để tạo "Secure Context"
                string tempFileName = $"VideoCall_{Guid.NewGuid()}.html";

                // Lấy đường dẫn file tạm
                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "VideoCall_Temp.html");

                // Lấy nội dung HTML từ Resources
                string htmlContent = Properties.Resource.CallVD;

                // Ghi ra file
                System.IO.File.WriteAllText(tempPath, htmlContent);

                // Điều hướng WebView tới file này
                webView.CoreWebView2.Navigate(tempPath);
                // -------------------------------

                await Task.Delay(1000);
                System.Diagnostics.Debug.WriteLine("WebRTC initialized via File Protocol");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo WebRTC: {ex.Message}", "Lỗi");
            }
        }

        // ---------------------- UI -----------------------
        private Button btnEnd;
        private Button btnMute;
        private Label lblStatus;
        private WebView2 webView;

        private void InitUI()
        {
            this.Text = $"Video Call - {remoteUserName}";
            this.Width = 900;
            this.Height = 650;
            this.BackColor = System.Drawing.Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;

            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(webView);

            Panel bottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = System.Drawing.Color.FromArgb(30, 30, 30)
            };
            Controls.Add(bottom);

            btnEnd = new Button
            {
                Text = "End Call",
                BackColor = System.Drawing.Color.Red,
                ForeColor = System.Drawing.Color.White,
                Width = 100,
                Height = 40,
                Left = 20,
                Top = 15,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnEnd.FlatAppearance.BorderSize = 0;
            btnEnd.Click += async (s, e) => await EndCall();
            bottom.Controls.Add(btnEnd);

            btnMute = new Button
            {
                Text = "🎤 Mute",
                BackColor = System.Drawing.Color.Gray,
                ForeColor = System.Drawing.Color.White,
                Width = 100,
                Height = 40,
                Left = 140,
                Top = 15,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMute.FlatAppearance.BorderSize = 0;
            btnMute.Click += ToggleMute;
            bottom.Controls.Add(btnMute);

            lblStatus = new Label
            {
                Text = isIncoming ? "Incoming call..." : "Calling...",
                ForeColor = System.Drawing.Color.White,
                Top = 25,
                Left = 260,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            bottom.Controls.Add(lblStatus);
        }

        // ---------------- JS BRIDGE ---------------------

        private string EscapeForJs(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\n", "\\n")
                    .Replace("\r", "\\r");
        }

        private async Task CallJs(string fn, string arg)
        {
            try
            {
                string script = $"{fn}(\"{EscapeForJs(arg)}\");";
                await webView.ExecuteScriptAsync(script);
                System.Diagnostics.Debug.WriteLine($"JS called: {fn}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi CallJs: {ex.Message}");
            }
        }

        // ---------------- OUTGOING CALL (Cuộc gọi đi) ----------------

        public async Task StartOutgoingCall()
        {
            try
            {
                lblStatus.Text = "Đang kết nối...";

                // 1. Khởi tạo WebRTC trước để sẵn sàng
                await InitWebRTC();
                webView.CoreWebView2.WebMessageReceived += OnWebMessageReceived;

                // 2. Đăng ký sự kiện TỪ FIREBASE
                firebase.OnCallAccepted += OnCallAcceptedHandler;
                firebase.OnCallRejected += OnCallRejectedHandler;
                firebase.OnCallEnded += OnCallEndedHandler;
                firebase.OnIceCandidate += OnIceCandidateReceived; // Đăng ký cái này luôn

                // 3. Tạo Offer và Gửi lên Firebase
                // Lưu ý: JS phải trả về "offer:..." sau khi gọi createOffer
                await CallJs("createOffer", "");

                // Code gửi Firebase sẽ được thực hiện bên trong OnWebMessageReceived khi nhận được "offer:..." từ JS

                System.Diagnostics.Debug.WriteLine($"Đang khởi tạo cuộc gọi tới {remoteUserName}...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
                this.Close();
            }
        }



        // ---------------- INCOMING CALL (Cuộc gọi đến) ----------------


        public async Task AnswerIncoming(VideoCall call)
        {
            try
            {
                lblStatus.Text = "Đang trả lời...";
                await InitWebRTC();

                // Đăng ký nhận message từ WebView2
                webView.CoreWebView2.WebMessageReceived += OnWebMessageReceived;

                // Đăng ký events
                firebase.OnCallEnded += OnCallEndedHandler;
                firebase.OnIceCandidate += OnIceCandidateReceived;

                // Lắng nghe ICE candidates
                firebase.ListenIceCandidate(call.CallId, localUserId);

                // LƯU callId nếu chưa lưu
                this.callId = call.CallId;

                // Set remote offer into JS — giả sử JS có function setRemoteOffer(sdp)
                if (!string.IsNullOrEmpty(call.Offer))
                {
                    await CallJs("setRemoteOffer", call.Offer);
                    // Sau khi vừa setRemoteOffer, JS nên tạo answer và post message "answer:<sdp>" => OnWebMessageReceived sẽ gửi AcceptCall
                }

                System.Diagnostics.Debug.WriteLine("Đã sẵn sàng nhận offer");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi AnswerIncoming: {ex.Message}");
                MessageBox.Show($"Lỗi trả lời cuộc gọi: {ex.Message}", "Lỗi");
                this.Close();
            }
        }


        // ---------------- XỬ LÝ MESSAGE TỪ WEBVIEW2 ----------------

        private async void OnWebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                var msg = e.TryGetWebMessageAsString();
                System.Diagnostics.Debug.WriteLine($"Nhận message từ JS: {msg}");

                if (msg.StartsWith("offer:"))
                {
                    string sdp = msg.Substring(6);

                    // Gửi offer lên Firebase
                    callId = await firebase.SendCallOffer(
                        localUserId,
                        localUserName,
                        remoteUserId,
                        sdp
                    );

                    lblStatus.Text = "Đang chờ phản hồi...";

                    // Bắt đầu lắng nghe ICE candidates
                    firebase.ListenIceCandidate(callId, localUserId);
                }
                else if (msg.StartsWith("answer:"))
                {
                    string answer = msg.Substring(7);
                    await firebase.AcceptCall(callId, answer);
                    lblStatus.Text = "Đã kết nối";
                    callStarted = true;
                }
                else if (msg.StartsWith("candidate:"))
                {
                    var data = msg.Substring(10).Split('|');
                    if (data.Length >= 3)
                    {
                        await firebase.SendIceCandidate(
                            callId,
                            localUserId,
                            data[0],
                            data[1],
                            int.Parse(data[2])
                        );
                    }
                }
                else if (msg == "connected")
                {
                    lblStatus.Text = "✓ Đã kết nối";
                    callStarted = true;
                }
                else if (msg == "disconnected")
                {
                    lblStatus.Text = "Mất kết nối";
                    await EndCall();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi OnWebMessageReceived: {ex.Message}");
            }
        }

        // ---------------- XỬ LÝ ICE CANDIDATES ----------------

        private async void OnIceCandidateReceived(IceCandidate candidate)
        {
            try
            {
                if (candidate.UserId != localUserId)
                {
                    string candidateData = $"{candidate.Candidate}|{candidate.SdpMid}|{candidate.SdpMLineIndex}";

                    this.Invoke(new Action(async () =>
                    {
                        await CallJs("addIceCandidate", candidateData);
                        System.Diagnostics.Debug.WriteLine("Đã thêm ICE candidate từ remote");
                    }));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi OnIceCandidateReceived: {ex.Message}");
            }
        }

        // ---------------- XỬ LÝ CALL EVENTS ----------------

        private async void OnCallAcceptedHandler(VideoCall call)
        {
            if (call.CallId != callId) return;

            this.Invoke(new Action(async () =>
            {
                try
                {
                    lblStatus.Text = "Đang kết nối...";

                    // Set remote answer
                    if (!string.IsNullOrEmpty(call.Answer))
                    {
                        await CallJs("setRemoteAnswer", call.Answer);
                        callStarted = true;
                        System.Diagnostics.Debug.WriteLine("Call accepted, đã set remote answer");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Lỗi OnCallAcceptedHandler: {ex.Message}");
                }
            }));
        }

        private void OnCallRejectedHandler(VideoCall call)
        {
            if (call.CallId != callId) return;

            this.Invoke(new Action(() =>
            {
                MessageBox.Show($"{remoteUserName} đã từ chối cuộc gọi", "Thông báo");
                this.Close();
            }));
        }

        private void OnCallEndedHandler(VideoCall call)
        {
            if (call.CallId != callId) return;

            this.Invoke(new Action(() =>
            {
                lblStatus.Text = "Cuộc gọi đã kết thúc";
                this.Close();
            }));
        }

        // ---------------- END CALL ----------------

        private async Task EndCall()
        {
            try
            {
                if (!string.IsNullOrEmpty(callId))
                {
                    await firebase.EndCall(callId);
                }

                // Hủy đăng ký events
                firebase.OnCallAccepted -= OnCallAcceptedHandler;
                firebase.OnCallRejected -= OnCallRejectedHandler;
                firebase.OnCallEnded -= OnCallEndedHandler;
                firebase.OnIceCandidate -= OnIceCandidateReceived;

                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi EndCall: {ex.Message}");
                this.Close();
            }
        }

        // ---------------- MUTE ----------------

        private void ToggleMute(object sender, EventArgs e)
        {
            isMuted = !isMuted;
            btnMute.Text = isMuted ? "🔇 Unmute" : "🎤 Mute";
            btnMute.BackColor = isMuted ? System.Drawing.Color.DarkRed : System.Drawing.Color.Gray;

            webView.ExecuteScriptAsync($"toggleMute({(isMuted ? "true" : "false")});");
        }

        // ---------------- FORM CLOSING ----------------

        private void VideoCallForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                firebase.StopVideoCallListeners();

                // Hủy đăng ký tất cả events
                firebase.OnCallAccepted -= OnCallAcceptedHandler;
                firebase.OnCallRejected -= OnCallRejectedHandler;
                firebase.OnCallEnded -= OnCallEndedHandler;
                firebase.OnIceCandidate -= OnIceCandidateReceived;

                if (webView?.CoreWebView2 != null)
                {
                    webView.CoreWebView2.WebMessageReceived -= OnWebMessageReceived;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi FormClosing: {ex.Message}");
            }
        }

        private void VideoCallForm_Load(object sender, EventArgs e)
        {

        }
        private void CoreWebView2_PermissionRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2PermissionRequestedEventArgs e)
        {
            // Tự động cho phép Camera và Microphone
            if (e.PermissionKind == Microsoft.Web.WebView2.Core.CoreWebView2PermissionKind.Camera ||
                e.PermissionKind == Microsoft.Web.WebView2.Core.CoreWebView2PermissionKind.Microphone)
            {
                e.State = Microsoft.Web.WebView2.Core.CoreWebView2PermissionState.Allow;
            }
        }
    }
}