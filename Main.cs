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
using LOGIN.Properties;



namespace Main_Interface
{
    public partial class Main : Form
    {
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
        public List<USER> FilteredUsers { get; set; } = null;

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
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.panelContent.BackColor = Color.FromArgb(240, 242, 245);

            // 2. Thiết lập thanh Menu (panelButtons) màu trắng cho nổi bật
            this.panelButtons.BackColor = Color.White;
            // Thêm đường viền bóng mờ cho menu (tùy chọn, ở đây mình set màu đơn giản trước)
            this.panelButtons.Padding = new Padding(0, 0, 0, 2); // Tạo khoảng hở

            this.btn_ghepdoi.Enabled = false;
            this.btn_dsnt.Enabled = false;
            this.btn_caidat.Enabled = false;
            this.btn_hscn.Enabled = false;
            //  this.btn_thongbao.Enabled = false;
            LoadingSpinner loading = new LoadingSpinner(this.lblLogo);
            loading.Show();
            try
            {
                u = await auth.getUser();
                if (u != null)

                {
                    Session.LocalId = u.Id;
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


            var toast = new ToastNotificationControl(noti.Title, noti.Body, iconImg, typeEnum);

           
            toast.ShowInContainer(this);
        }





        private async void CallCheckTimer_Tick(object sender, EventArgs e)
        {
            if (isBusy) return; // Tránh chạy lồng nhau
            isBusy = true;
            callCheckTimer.Stop();

            try
            {
                var pendingCall = await auth.CheckForPendingCalls(Session.LocalId);
                if (pendingCall != null)
                {
                    HandleIncomingCall(pendingCall);
                }
            }
            catch { /* Handle error */ }
            finally
            {
                isBusy = false;
                callCheckTimer.Start();
            }
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
            // Tăng kích thước nút một chút cho dễ bấm
            btn.Size = new Size(180, 70);
            btn.Location = location;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.White; // Nền trắng hòa vào thanh menu
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;

            // Dùng Font Segoe UI Emoji để icon và chữ đẹp hơn
            btn.Font = new Font("Segoe UI Semibold", 11, FontStyle.Regular);
            btn.ForeColor = Color.FromArgb(117, 125, 133); // Màu xám nhạt khi chưa chọn

            btn.Text = $"{icon}  {label}"; // Thêm khoảng cách giữa icon và chữ

            // Hiệu ứng Hover: Nền hồng rất nhạt
            btn.MouseEnter += (s, e) =>
            {
                if (btn != activeButton)
                {
                    btn.BackColor = Color.FromArgb(255, 240, 245); // Hồng phấn nhạt
                    btn.ForeColor = Color.FromArgb(253, 41, 123);  // Hồng Tinder
                }
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != activeButton)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(117, 125, 133);
                }
            };

            btn.Click += (s, e) => SetActiveButton(btn);

            return btn;
        }

        private void SetActiveButton(Button btn)
        {
            if (activeButton != null)
            {
                // Reset nút cũ về trạng thái thường
                activeButton.BackColor = Color.White;
                activeButton.ForeColor = Color.FromArgb(117, 125, 133);
                activeButton.Font = new Font("Segoe UI Semibold", 11, FontStyle.Regular);
            }

            activeButton = btn;
            // Highlight nút mới: Chữ màu Hồng đậm, Font đậm hơn
            activeButton.ForeColor = Color.FromArgb(253, 41, 123); // Màu thương hiệu
            activeButton.BackColor = Color.White; // Giữ nền trắng cho sạch
            activeButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        public UserControl CurrentControl { get; private set; }

        public void LoadContent(UserControl uc)
        {
            if (uc == null)
            {
               
                if (gd == null) gd = new GhepDoi(this);
                uc = gd;
            }

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
           
            UC_ThongBaoList ucNoti = new UC_ThongBaoList(auth, Session.LocalId);
            LoadContent(ucNoti);

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


            System.Media.SoundPlayer player = new System.Media.SoundPlayer(LOGIN.Properties.Resource.nhaccho);

            try { player.PlayLooping(); } catch { }


            using (var incomingForm = new IncomingCallForm(callername, avatar))
            {

                incomingForm.TopMost = true;

                var result = incomingForm.ShowDialog();

                try { player.Stop(); } catch { }

                if (result == DialogResult.Yes)
                {

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

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
