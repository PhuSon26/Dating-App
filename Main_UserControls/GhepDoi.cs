using Google.Cloud.Firestore;
using LOGIN;
using LOGIN.Main_UserControls.GhepDoi_UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D; // Thêm thư viện vẽ
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace Main_Interface.User_Controls
{
    public partial class GhepDoi : UserControl
    {
       
        private Panel pnlCard;       // Cái thẻ màu trắng
        private Panel pnlInfo;       // Vùng chứa tên, tuổi bên trong thẻ
        private Panel pnlActions;    // Vùng chứa nút Tim/X
        
        // ----------------------------------

        private readonly HttpClient _client = new HttpClient();
        private Main MainForm;
        private LocUser loc;
        private MatchFilterAPI filterAPI;
        private FirebaseAuthHelper authHelper;
        private List<USER> suggestedUsers = new List<USER>();
        public FirestoreDb db;

        private int suggestIndex = 0;
        string myUserId = Session.LocalId;
        private USER myUser;
        private FlowLayoutPanel mainGrid;
        private HeartRainOverlay _heartOverlay;
        public GhepDoi()
        {
            InitializeComponent();
            authHelper = new FirebaseAuthHelper("login-bb104");
        }
        public GhepDoi(Main m)
        {
          
           InitializeComponent();
            MainForm = m;
            authHelper = new FirebaseAuthHelper("login-bb104");
            loc = new LocUser(MainForm);
            filterAPI = new MatchFilterAPI("login-bb104");
            db = FirestoreDb.Create("login-bb104");
            SetupTinderLayout();
        }
        private void SetupTinderLayout()
        {
            // Cài đặt nền chung
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.Controls.Clear(); // Xóa hết control cũ

            // Tạo tiêu đề "Gợi ý cho bạn" giống video
            Label lblTitle = new Label();
            lblTitle.Text = "Gợi ý cho bạn";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 10);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            btn_loc = new RoundedButton();
            btn_loc.Text = "🔍 Bộ lọc";
            btn_loc.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            //btn_loc.BackColor = Color.White;
            //btn_loc.ForeColor = Color.FromArgb(253, 41, 123); // Màu hồng thương hiệu
            btn_loc.FlatStyle = FlatStyle.Flat;
            btn_loc.FlatAppearance.BorderColor = Color.FromArgb(253, 41, 123);
            btn_loc.FlatAppearance.BorderSize = 1;
            btn_loc.Size = new Size(120, 55);

            // Đặt vị trí ở góc trên bên phải
            btn_loc.Location = new Point(this.Width - 120, 0);
            btn_loc.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo vào góc phải để không bị lệch khi resize
            btn_loc.Cursor = Cursors.Hand;

   
            btn_loc.Click += btn_loc_Click;

            this.Controls.Add(btn_loc);

            // Tạo lưới chứa thẻ (Grid)
            mainGrid = new FlowLayoutPanel();
            mainGrid.Location = new Point(20, 50);
            mainGrid.Size = new Size(this.Width - 40, this.Height - 60);
            mainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainGrid.AutoScroll = true;
            mainGrid.WrapContents = true; 

            typeof(Control).GetProperty("DoubleBuffered",
    System.Reflection.BindingFlags.NonPublic |
    System.Reflection.BindingFlags.Instance)
    ?.SetValue(mainGrid, true, null);
            mainGrid.Padding = new Padding(10);
            this.Controls.Add(mainGrid);

            if (_heartOverlay == null)
                _heartOverlay = new HeartRainOverlay();

            this.Controls.Add(_heartOverlay);
            _heartOverlay.BringToFront();
        }

        // Sửa hàm hiển thị User
        private void ShowListUsers(List<USER> users)
        {
            mainGrid.SuspendLayout();
            mainGrid.Controls.Clear();
            if (users == null) return;

            foreach (var u in users)
            {
                // Tạo thẻ từ UserControl mới làm
                ProfileCard card = new ProfileCard();
                card.SetData(u);

                // Đăng ký sự kiện
                card.OnLikeClicked += Card_OnLikeClicked;
                card.OnPassClicked += Card_OnPassClicked;
                card.OnCardClicked += (sender, selectedUser) =>
                {
                   
                    MainForm.LoadContent(new ChiTietUser(MainForm, selectedUser, this));
                };

                mainGrid.Controls.Add(card);
            }
            mainGrid.ResumeLayout();
        }


        private async void Card_OnLikeClicked(object sender, USER targetUser)
        {
            
            ProfileCard card = sender as ProfileCard;
            if (card == null) return;
            card.Enabled = false;

            try
            {
               
                bool iAlreadyLiked = await authHelper.CheckIfUserLikedMe(targetUser.Id, myUserId);
                if (iAlreadyLiked)
                {
                    MessageBox.Show($"Bạn đã thích {targetUser.ten} rồi!", "Thông báo");
                    mainGrid.Controls.Remove(card);
                    return;
                }

             
                bool isSuccess = await authHelper.SaveLikeAction(myUserId, targetUser.Id);

                if (isSuccess)
                {
                 
                    bool isMatch = await authHelper.CheckIfUserLikedMe(myUserId, targetUser.Id);

                    if (isMatch)
                    {
                       
                        _heartOverlay?.Trigger(totalHearts: 250, durationMs: 2000);
                        await authHelper.CreateMatchRecord(myUserId, targetUser.Id);

                        MatchForm matched = new MatchForm(myUser, targetUser, authHelper);
                        matched.ShowDialog();
                    }
                    else
                    {
                       
                        _heartOverlay?.Trigger(totalHearts: 120, durationMs: 1400);
                        MessageBox.Show($"Đã thích {targetUser.ten}!", "LoveMatch");
                    }

                   
                    mainGrid.Controls.Remove(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện Like: " + ex.Message);
                card.Enabled = true; // Bật lại card nếu lỗi để user thử lại
            }
        }

        private void Card_OnPassClicked(object sender, USER targetUser)
        {
            // Logic bỏ qua
            ProfileCard card = sender as ProfileCard;
            mainGrid.Controls.Remove(card);
        }
        private async void GhepDoi_Load(object sender, EventArgs e)
        {
            this.btn_kothich.Enabled = false;
            this.btn_loc.Enabled = false;
            this.btn_tim.Enabled = false;
            LoadingSpinner loading = new LoadingSpinner(MainForm.lblLogo);
            loading.Show();
            myUser = await authHelper.GetUserById(myUserId);
            // Nếu vừa lọc xong → load danh sách lọc
            if (MainForm.FilteredUsers != null && MainForm.FilteredUsers.Count > 0)
            {
                suggestedUsers = MainForm.FilteredUsers;
              
                ShowListUsers(suggestedUsers);

                MainForm.FilteredUsers = null; // reset
            }
            else
            {
                // Ngược lại → random user bình thường
                await LoadSuggestUsers(myUserId);
            }
            loading.Hide();
            this.btn_kothich.Enabled = true;
            this.btn_loc.Enabled = true;
            this.btn_tim.Enabled = true;
        }

        private async Task LoadSuggestUsers(string userId)
        {
            try
            {
                int totalUsers = await authHelper.GetUserCountAsync();
                suggestedUsers = await authHelper.GetRandomSuggest(userId, totalUsers);
                if (suggestedUsers == null || suggestedUsers.Count == 0)
                {
                    MessageBox.Show("Hết người để quẹt rồi!");
                    return;
                }
               ShowListUsers(suggestedUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LoadUserControl(UserControl uc)
        {
            MainForm.panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            MainForm.panelContent.Controls.Add(uc);
        }
      

        private void btn_loc_Click(object sender, EventArgs e)
        {
            MainForm.LoadContent(loc);
        }
        private void NextSuggestUser()
        {
            if (suggestedUsers.Count == 0) return;
            suggestIndex++;
            if (suggestIndex >= suggestedUsers.Count) suggestIndex = 0;
            ShowListUsers(suggestedUsers);
        }

        private void btn_kothich_Click(object sender, EventArgs e)
        {
            NextSuggestUser();
        }

        private async void btn_tim_Click(object sender, EventArgs e)
        {
           
        }

        public void LoadFilteredUsers(List<USER> users)
        {
            // Kiểm tra danh sách trả về từ bộ lọc
            if (users == null || users.Count == 0)
            {
                MessageBox.Show("Không tìm thấy ai phù hợp với bộ lọc này!", "Thông báo");
                return;
            }

           
            this.suggestedUsers = users;


            ShowListUsers(suggestedUsers);

            MessageBox.Show($"Đã tìm thấy {users.Count} người phù hợp!", "Kết quả lọc");
        }

        // Nếu code cũ của bạn có gọi hàm này để chuyển UserControl, hãy giữ lại
    
      
        private void Flpanel_pictures_MouseWheel(object sender, MouseEventArgs e) { }
        private void panelPictures_Paint(object sender, PaintEventArgs e) { }
        private void btn_timVIP_Click(object sender, EventArgs e) { }
        private void panelQuet_Paint(object sender, PaintEventArgs e) { }
        private void panelThongTin_Paint(object sender, PaintEventArgs e) { }
        private void flpanel_pictures_Paint(object sender, PaintEventArgs e) { }
        private void panelPictures_Paint_1(object sender, PaintEventArgs e) { }
    }

}