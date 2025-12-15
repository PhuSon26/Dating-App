using Dating_app_nhom3;
using LOGIN;
using LOGIN.Models;
using Main_Interface.User_Controls;
using System;
using System.Drawing;
using System.Dynamic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;



namespace Main_Interface
{
    public partial class Main : Form
    {
        public NapVIP nv;
        public FormDanhSachTinNhan dstn;
        public GhepDoi gd;
        public Thongtinuser ttuser;
        public FirebaseAuthHelper auth;
        public CaiDat cd;
        public USER u;
       
        private bool loadedHscn = false;
        private bool loadedVip = false;
        private bool loadedDs = false;
        private bool loadedGhepDoi = false;
        private bool loadedCaiDat = false;
        private bool isBusy = false;
        System.Windows.Forms.Timer callCheckTimer;
        public Main(FirebaseAuthHelper auth)
        {
            InitializeComponent();
            this.auth = auth;
            callCheckTimer = new System.Windows.Forms.Timer();
            callCheckTimer.Interval = 3000;
            callCheckTimer.Tick += CallCheckTimer_Tick;
            SetupButtons();
        }

        public async void Main_Load(object sender, EventArgs e)
        {
            this.btn_ghepdoi.Enabled = false;
            this.btn_dsnt.Enabled = false;
            this.btn_caidat.Enabled = false;
            this.btn_hscn.Enabled = false;
            //  this.btn_thongbao.Enabled = false;
            LoadingSpinner loading = new LoadingSpinner(this);
            loading.pbSpinner.BackColor = Color.FromArgb(255, 250, 253);
            loading.Show();
            try
            {
                u = await auth.getUser();
                if (u != null)

                { Session.LocalId = u.Id;
                    InitVideoSystem();
                    auth.OnNotificationReceived += FbHelper_OnNotificationReceived;
                    auth.StartListeningNotification(u.Id);
                    gd = new GhepDoi(this);
                    LoadContent(gd);

                    
                    callCheckTimer.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }

            finally
            {
                loading.Hide();
               
            }
            this.btn_ghepdoi.Enabled = true;
            this.btn_dsnt.Enabled = true;
            this.btn_caidat.Enabled = true;
            this.btn_hscn.Enabled = true;
           


            }

     

        private void FbHelper_OnNotificationReceived(LOGIN.Models.NotificationModel noti)
        {
          
            if (this.InvokeRequired)
            {

                this.Invoke(new Action(() => ShowNotificationUI(noti)));
            }
            else
            {
                ShowNotificationUI(noti);
            }
        }

        private void ShowNotificationUI(LOGIN.Models.NotificationModel noti)
        {
            // 1. Chuyển đổi từ string Type của Model sang Enum ToastType của Form
            ToastType typeEnum = ToastType.System;
            Image iconImg = null; // Hoặc set ảnh mặc định tùy ý

            switch (noti.Type)
            {
                case "message":
                    typeEnum = ToastType.Message;
                    // Nếu muốn hiện avatar người gửi, bạn cần tải ảnh từ noti.DataID (SenderID)
                    // Tuy nhiên để thông báo hiện nhanh, ta tạm để null hoặc icon mặc định
                    break;
                case "like":
                    typeEnum = ToastType.Like;
                    break;
                case "match":
                    typeEnum = ToastType.Match;
                    break;
                case "event":
                    typeEnum = ToastType.System;
                    break;
                default:
                    typeEnum = ToastType.System;
                    break;
            }

            
            thongbaonoi toast = new thongbaonoi(noti.Title, noti.Body, iconImg, typeEnum);

            // Hàm ShowInParent đã được bạn viết sẵn trong thongbaonoi.cs để trượt lên
            toast.ShowInParent(this);
        }

      

        // Sự kiện khi click vào bong bóng thông báo
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            string dataId = notifyIcon1.Tag as string;
            // TODO: Xử lý chuyển trang dựa vào dataId
            // Ví dụ: if (dataId.StartsWith("chat_")) { LoadContent(dstn); }
        }


        private async void CallCheckTimer_Tick(object sender, EventArgs e)
        {
            // Tạm dừng timer để tránh chạy chồng chéo
            callCheckTimer.Stop();

            try
            {

                var pendingCall = await auth.CheckForPendingCalls(Session.LocalId);

                if (pendingCall != null)
                {

                    HandleIncomingCall(pendingCall);
                }
            }
            finally
            {
                // Chạy lại timer
                callCheckTimer.Start();
            }
        }

        private void btn_vip_Click(object sender, EventArgs e)
        {
            if (!loadedVip)
            {
                nv = new NapVIP();
                loadedVip = true;
            }
            LoadContent(nv);
        }

        private void btn_dsnt_Click(object sender, EventArgs e)
        {
            if (!loadedDs)
            {
                dstn = new FormDanhSachTinNhan(this, u);
                loadedDs = true;
            }
            LoadContent(dstn);
        }

        private void btn_ghepdoi_Click(object sender, EventArgs e)
        {
            if (!loadedGhepDoi)
            {
                gd = new GhepDoi(this);
                loadedGhepDoi = true;
            }
            LoadContent(gd);
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            if (!loadedCaiDat)
            {
                cd = new CaiDat(this);
                loadedCaiDat = true;
            }
            LoadContent(cd);
        }

        private async void btn_hscn_Click(object sender, EventArgs e)
        {
            LoadingSpinner loading = new LoadingSpinner(this);
            if (!loadedHscn)
            {
                ttuser = new Thongtinuser(auth, u);
                ttuser.setUserInfo(u);
                loadedHscn = true;
            }

            LoadContent(ttuser);
            loading.Hide();
        }

        private Button activeButton = null;

        private Button CreateNavButton(string icon, string label, Point location)
        {
            var btn = new Button();
            btn.Size = new Size(160, 80);
            btn.Location = location;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Font = new Font("Segoe UI Emoji", 14, FontStyle.Regular);
            btn.ForeColor = Color.Gray;

            btn.Text = $"{icon}\n{label}";

            btn.MouseEnter += (s, e) =>
            {
                if (btn != activeButton)
                    btn.ForeColor = Color.FromArgb(255, 130, 160);
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != activeButton)
                    btn.ForeColor = Color.Gray;
            };

            // Click
            btn.Click += (s, e) => SetActiveButton(btn);

            return btn;
        }

        private void SetActiveButton(Button btn)
        {
            if (activeButton != null)
                activeButton.ForeColor = Color.Gray;

            activeButton = btn;
            activeButton.ForeColor = Color.FromArgb(255, 90, 130); // hồng đậm
        }

        public UserControl CurrentControl { get; private set; }

        public void LoadContent(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);

            CurrentControl = uc;
        }

        private void SetupButtons()
        {
            panelButtons.Controls.Clear();

            int buttonCount = 5; // số nút còn lại
            int panelWidth = panelButtons.Width;
            int spacing = 10; // khoảng cách tối thiểu giữa các nút

            // Tính chiều rộng nút sao cho vừa khít
            int totalSpacing = spacing * (buttonCount + 1);
            int buttonWidth = (panelWidth - totalSpacing) / buttonCount;
            int y = 10; // vị trí top cố định

            // Tạo vị trí X cho từng nút
            int x = spacing;
            btn_ghepdoi = CreateNavButton("❤️", "Ghép đôi", new Point(x, y));
            btn_ghepdoi.Width = buttonWidth;

            x += buttonWidth + spacing;
            btn_dsnt = CreateNavButton("💬", "Tin nhắn", new Point(x, y));
            btn_dsnt.Width = buttonWidth;

            x += buttonWidth + spacing;
            btn_hscn = CreateNavButton("👤", "Hồ sơ", new Point(x, y));
            btn_hscn.Width = buttonWidth;

            x += buttonWidth + spacing;
            btn_caidat = CreateNavButton("⚙️", "Cài đặt", new Point(x, y));
            btn_caidat.Width = buttonWidth;

            x += buttonWidth + spacing;
            btn_thongbao = CreateNavButton("🔔", "Thông báo", new Point(x, y));

            // Gắn sự kiện click
            btn_ghepdoi.Click += btn_ghepdoi_Click;
            btn_dsnt.Click += btn_dsnt_Click;
            btn_hscn.Click += btn_hscn_Click;
            btn_caidat.Click += btn_caidat_Click;
            btn_thongbao.Click += btn_thongbao_Click;

            panelButtons.Controls.AddRange(new Control[]
            {
        btn_ghepdoi, btn_dsnt, btn_hscn, btn_caidat, btn_thongbao,
            });
        }
        private void btn_thongbao_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị UserControl danh sách
            UC_ThongBaoList ucNoti = new UC_ThongBaoList(auth, Session.LocalId);
            LoadContent(ucNoti);

            // Highlight nút (Nếu dùng logic SetActiveButton)
            SetActiveButton(btn_thongbao);
        }


        private Button CreateNavButton(string icon, string text)
        {
            var btn = new Button();
            btn.Size = new Size(262, 60);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(255, 130, 160);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.Text = $"{icon} {text}";
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
                btn.BackColor = Color.FromArgb(255, 150, 180);

            btn.MouseLeave += (s, e) =>
                btn.BackColor = Color.FromArgb(255, 130, 160);

            return btn;
        }

        private void btn_ghepdoi_Click_1(object sender, EventArgs e)
        {

        }
        private async void btnLike_Click(object sender, EventArgs e)
        {

        }
        public void InitVideoSystem()
        {


            auth.OnIncomingCall += HandleIncomingCall;


            auth.ListenForIncomingCall(Session.LocalId);
        }

        private async void HandleIncomingCall(VideoCall call)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleIncomingCall(call)));
                return;
            }
            string callername = call.CallerName;

            Image avatar = null;
            try
            {

                USER caller = await auth.GetUserById(call.CallerId);
                if (caller != null)
                {
                    // Lấy tên thật trong hồ sơ (nếu có)
                    if (!string.IsNullOrEmpty(caller.ten))
                        callername = caller.ten;

                    // Lấy Avatar thật (Convert từ Base64)
                    // Lưu ý: Đảm bảo user có trường AvatarUrl hoặc AvatarBase64 tùy model của bạn
                    if (!string.IsNullOrEmpty(caller.AvatarUrl))
                    {
                        avatar = auth.Base64ToImage(caller.AvatarUrl);
                    }
                }

            }
            catch { }

            // 2. PHÁT NHẠC CHUÔNG (Tùy chọn - Cực kỳ khuyến khích)
            //  System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\admin\Desktop\nhac_chuong_iphone_11_pro_max-www_tiengdong_com.mp3");

            //  try { player.PlayLooping(); } catch { }


            using (var incomingForm = new IncomingCallForm(callername, avatar))
            {

                incomingForm.TopMost = true;

                var result = incomingForm.ShowDialog();

                // Tắt nhạc chuông
                //   try { player.Stop(); } catch { }

                if (result == DialogResult.Yes)
                {
                    // --- CHẤP NHẬN ---
                    var vcForm = new VideoCallForm(
                        Session.LocalId,
                        u.ten,
                        call.CallerId,
                        callername,
                        auth,
                        call.CallId
                    );
                    vcForm.Show();
                    _ = vcForm.AnswerIncoming(call);
                }
                else
                {
                    // --- TỪ CHỐI ---
                    try
                    {
                        _ = auth.RejectCall(call.CallId);
                    }
                    catch { }
                }
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
