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

      

        // --- [QUAN TRỌNG] HÀM DỰNG LAYOUT TINDER ---
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

            // Tạo lưới chứa thẻ (Grid)
            mainGrid = new FlowLayoutPanel();
            mainGrid.Location = new Point(20, 50);
            mainGrid.Size = new Size(this.Width - 40, this.Height - 60);
            mainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainGrid.AutoScroll = true;
            mainGrid.WrapContents = true; // Tự động xuống dòng khi hết chỗ
            this.Controls.Add(mainGrid);

            if (_heartOverlay == null)
                _heartOverlay = new HeartRainOverlay();

            this.Controls.Add(_heartOverlay);
            _heartOverlay.BringToFront();
        }

        // Sửa hàm hiển thị User
        private void ShowListUsers(List<USER> users)
        {
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

                mainGrid.Controls.Add(card);
            }
        }

        // Xử lý sự kiện khi bấm nút trên thẻ
        private async void Card_OnLikeClicked(object sender, USER targetUser)
        {
            _heartOverlay?.Trigger(totalHearts: 120, durationMs: 1400);

            MessageBox.Show($"Đã thích {targetUser.ten}! Hy vọng sẽ có kết quả tốt.", "LoveMatch");

            ProfileCard card = sender as ProfileCard;
            mainGrid.Controls.Remove(card);
        }

        private void Card_OnPassClicked(object sender, USER targetUser)
        {
            // Logic bỏ qua
            ProfileCard card = sender as ProfileCard;
            mainGrid.Controls.Remove(card);
        }

      

        private async void AddImageToPanel(string url)
        {
            PictureBox pb = new PictureBox();
            // CHỈNH SỬA QUAN TRỌNG: Kích thước ảnh phải full thẻ
            pb.Size = new Size(360, 400);
            pb.SizeMode = PictureBoxSizeMode.Zoom; // Hoặc CenterImage để đẹp hơn
            pb.BackColor = Color.Black;
            pb.Margin = new Padding(0); // Không cách lề

            try
            {
                if (!string.IsNullOrEmpty(url) && url.StartsWith("http"))
                    pb.Image = await LoadImageFromUrl(url);
                else if (!string.IsNullOrEmpty(url))
                    pb.Image = authHelper.Base64ToImage(url);
            }
            catch
            {
                pb.BackColor = Color.DarkGray;
            }

            flpanel_pictures.Controls.Add(pb);
        }

        // --- CÁC HÀM LOGIC CŨ GIỮ NGUYÊN ---
        private async Task<Image> LoadImageFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var bytes = await client.GetByteArrayAsync(url);
                    using (var ms = new MemoryStream(bytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
                catch { return null; }
            }
        }

        private async void GhepDoi_Load(object sender, EventArgs e)
        {
            this.btn_kothich.Enabled = false;
            this.btn_loc.Enabled = false;
            this.btn_tim.Enabled = false;
            LoadingSpinner loading = new LoadingSpinner(this);
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
                suggestedUsers = await authHelper.GetRandomSuggest(userId, 10);
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
            MainForm.LoadContent(new LocUser(MainForm));
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
            if (suggestedUsers == null || suggestedUsers.Count == 0) return;

            USER targetUser = suggestedUsers[suggestIndex];
            string targetUserId = targetUser.Id;

            btn_tim.Enabled = false;

            try
            {
                bool isSuccess = await authHelper.SaveLikeAction(myUserId, targetUserId);

                // like fail -> chuyển người khác, KHÔNG mưa tim
                if (!isSuccess)
                {
                    NextSuggestUser();
                    return;
                }

                // like OK -> mưa tim
                _heartOverlay?.Trigger(totalHearts: 120, durationMs: 1400);

                bool isMatch = await authHelper.CheckIfUserLikedMe(myUserId, targetUserId);

                if (isMatch)
                {
                    await authHelper.CreateMatchRecord(myUserId, targetUserId);

                    // match -> mưa tim nhiều hơn (tuỳ)
                    _heartOverlay?.Trigger(totalHearts: 220, durationMs: 1700);

                    MessageBox.Show($"It's a Match! Bạn và {targetUser.ten} đã thích nhau.", "Chúc mừng");
                }

                NextSuggestUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                btn_tim.Enabled = true;
            }
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