using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        private List<string> pendingIceCandidates = new List<string>();
        private string currentTempHtmlPath = "";

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
                await webView.EnsureCoreWebView2Async(null);
                webView.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;

                // --- ĐOẠN SỬA ĐỔI ---
                string tempFileName = $"VideoCall_{Guid.NewGuid()}.html";

                // Dùng biến toàn cục currentTempHtmlPath để lưu đường dẫn
                currentTempHtmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), tempFileName);

                // Ghi nội dung ra file này
                System.IO.File.WriteAllText(currentTempHtmlPath, Properties.Resource.CallVD);

                // Load đúng file vừa tạo
                webView.CoreWebView2.Navigate(currentTempHtmlPath);
                webView.WebMessageReceived += WebView_WebMessageReceived;
                // --------------------

                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi WebRTC: {ex.Message}");
            }
        }
        private async void WebView_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            
            string message = e.TryGetWebMessageAsString();

            if (message == "hangup")
            {

                await EndCall();
            }
        }


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

            

        }

        // ---------------- JS BRIDGE ---------------------

        private string EscapeForJs(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\r", "")      
                    .Replace("\n", "\\n"); 
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
               
                await InitWebRTC();

                // Đăng ký nhận message từ WebView2
                webView.CoreWebView2.WebMessageReceived += OnWebMessageReceived;

                // Đăng ký events
                firebase.OnCallEnded += OnCallEndedHandler;
                firebase.OnIceCandidate += OnIceCandidateReceived;

                // Lắng nghe ICE candidates
                firebase.ListenIceCandidate(call.CallId, localUserId);

               
                this.callId = call.CallId;
                firebase.OnMediaStatusChanged += OnRemoteMediaStatusChanged;
                firebase.ListenMediaStatus(callId, remoteUserId);

                // Set remote offer into JS — giả sử JS có function setRemoteOffer(sdp)
                if (!string.IsNullOrEmpty(call.Offer))
                {
                    await CallJs("setRemoteOffer", call.Offer);
                   
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

                    // Đăng ký event
                    firebase.OnMediaStatusChanged += OnRemoteMediaStatusChanged;

                    // Bắt đầu lắng nghe trạng thái của đối phương
                    firebase.ListenMediaStatus(callId, remoteUserId);

                    // Bắt đầu lắng nghe ICE candidates
                    firebase.ListenIceCandidate(callId, localUserId);
                    foreach (var pendingMsg in pendingIceCandidates)
                    {
                        ProcessCandidateMsg(pendingMsg);
                    }
                    pendingIceCandidates.Clear();
                }
                else if (msg.StartsWith("answer:"))
                {
                    string answer = msg.Substring(7);
                    await firebase.AcceptCall(callId, answer);
                   
                    callStarted = true;
                }
                else if (msg.StartsWith("candidate:"))
                {
                    if (string.IsNullOrEmpty(callId))
                    {
                        pendingIceCandidates.Add(msg);
                    }
                    else
                    {
                        ProcessCandidateMsg(msg);
                    }
                }
                else if (msg == "connected")
                {
                   
                    callStarted = true;
                }
                else if (msg == "disconnected")
                {
                   
                    await EndCall();
                }
                if (msg.StartsWith("mic:") || msg.StartsWith("cam:"))
                {
                    if (string.IsNullOrEmpty(callId)) return;
                    var parts = msg.Split(':');
                    string type = parts[0]; // mic hoặc cam
                    string state = parts[1]; // on hoặc off

                    // Gửi trạng thái này lên Firebase
                    await firebase.UpdateMediaStatus(callId, localUserId, type, state);
                }
               


            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi OnWebMessageReceived: {ex.Message}");
            }
        }
        // Hàm này sẽ được gọi khi Firebase báo người kia thay đổi Mic/Cam
        private void OnRemoteMediaStatusChanged(string type, string state)
        {
            if (this.IsDisposed || webView == null || webView.CoreWebView2 == null)
            {
                return; 
            }
            this.Invoke(new Action(async () =>
            {
                System.Diagnostics.Debug.WriteLine($"[C#] Nhận update từ Remote: Type={type}, State={state}");
                await webView.ExecuteScriptAsync($"updateRemoteState('{type}', '{state}')");
            }));
           
        }
        private async void ProcessCandidateMsg(string msg)
        {
            try
            {
                var data = msg.Substring(10).Split('|');
                if (data.Length >= 3)
                {
                    await firebase.SendIceCandidate(callId, localUserId, data[0], data[1], int.Parse(data[2]));
                }
            }
            catch { }
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

      
        // ---------------- FORM CLOSING ----------------

        private void VideoCallForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(callId))
                {
                    
                    _ = firebase.EndCall(callId);
                }
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
                if (!string.IsNullOrEmpty(currentTempHtmlPath) && System.IO.File.Exists(currentTempHtmlPath))
                {
                    System.IO.File.Delete(currentTempHtmlPath);
                }
                if (webView != null && webView.CoreWebView2 != null)
                {
                    
                    webView.Dispose();
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