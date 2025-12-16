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
        // --- CÁC PANEL GIAO DIỆN TINDER ---
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
        }

        // --- SỰ KIỆN LOAD: GỌI HÀM DỰNG GIAO DIỆN ---
        private async void GhepDoi_Load(object sender, EventArgs e)
        {
            // 1. Dựng giao diện Tinder
            SetupTinderLayout();

            // 2. Logic cũ của bạn
            this.btn_kothich.Enabled = false;
            this.btn_loc.Enabled = false;
            this.btn_tim.Enabled = false;

            // LoadingSpinner loading = new LoadingSpinner(this); // (Tạm ẩn để test giao diện)
            // loading.Show();

            try
            {
                myUser = await authHelper.GetUserById(myUserId);
                await LoadSuggestUsers(myUserId);
            }
            catch { }

            // loading.Hide();
            this.btn_kothich.Enabled = true;
            this.btn_loc.Enabled = true;
            this.btn_tim.Enabled = true;
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
            // Gọi lại logic like cũ của bạn
            // Ví dụ: await authHelper.SaveLikeAction(myUserId, targetUser.Id);

            MessageBox.Show($"Đã thích {targetUser.ten}! Hy vọng sẽ có kết quả tốt.", "LoveMatch");

            // Xóa thẻ khỏi màn hình cho đẹp
            ProfileCard card = sender as ProfileCard;
            mainGrid.Controls.Remove(card);
        }

        private void Card_OnPassClicked(object sender, USER targetUser)
        {
            // Logic bỏ qua
            ProfileCard card = sender as ProfileCard;
            mainGrid.Controls.Remove(card);
        }

        private void ShowUser(USER u)
        {
            flpanel_pictures.Controls.Clear();

            if (u == null) return;

            // Load ảnh
            if (u.photos != null && u.photos.Count > 0)
            {
                foreach (string photoUrl in u.photos)
                {
                    AddImageToPanel(photoUrl);
                }
            }
            else // Nếu không có ảnh, hiện avatar
            {
                AddImageToPanel(u.AvatarUrl);
            }

            // Gán dữ liệu vào các Textbox (đã được làm đẹp)
            tb_name.Text = u.ten ?? "No Name";
            tb_tuoi.Text = u.tuoi > 0 ? u.tuoi.ToString() : "";
            tb_snhat.Text = u.snhat;
            tb_hocvan.Text = !string.IsNullOrEmpty(u.hocvan) ? "🎓 " + u.hocvan : "";
            tb_nghe.Text = !string.IsNullOrEmpty(u.nghenghiep) ? "💼 " + u.nghenghiep : "";
            tb_vitri.Text = !string.IsNullOrEmpty(u.vitri) ? "📍 " + u.vitri : "";

            // Xử lý text dài quá thì cắt bớt
            if (tb_name.Text.Length > 15) tb_name.Text = tb_name.Text.Substring(0, 15) + "...";
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
                suggestIndex = 0;
                ShowUser(suggestedUsers[0]);

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
        public void LoadFilteredUsers(List<USER> users)
        {
            suggestedUsers = users;
            suggestIndex = 0;

            if (users == null || users.Count == 0)
            {
                MessageBox.Show("Không có user phù hợp!");
                return;
            }

            ShowUser(users[0]); // Hiển thị đúng UI chuẩn
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
            ShowUser(suggestedUsers[suggestIndex]);
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
            string myName = myUser.ten ?? "Someone";

            btn_tim.Enabled = false;

            try
            {
                bool isSuccess = await authHelper.SaveLikeAction(myUserId, targetUserId);
                if (!isSuccess)
                {
                    NextSuggestUser();
                    return;
                }

                bool isMatch = await authHelper.CheckIfUserLikedMe(myUserId, targetUserId);

                if (isMatch)
                {
                    await authHelper.CreateMatchRecord(myUserId, targetUserId);
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

            // 1. Cập nhật danh sách "người để quẹt" thành danh sách mới lọc được
            this.suggestedUsers = users;
            this.suggestIndex = 0; // Reset về người đầu tiên

            // 2. Hiển thị ngay người đầu tiên lên thẻ
            ShowUser(suggestedUsers[0]);

            MessageBox.Show($"Đã tìm thấy {users.Count} người phù hợp!", "Kết quả lọc");
        }

        // Nếu code cũ của bạn có gọi hàm này để chuyển UserControl, hãy giữ lại
        public void LoadUserControl(UserControl uc)
        {
            MainForm.LoadContent(uc);
        }
        // Các hàm sự kiện thừa có thể để trống
        private void btn_loc_Click(object sender, EventArgs e) { MainForm.LoadContent(new LocUser(MainForm)); }
        private void Flpanel_pictures_MouseWheel(object sender, MouseEventArgs e) { }
        private void panelPictures_Paint(object sender, PaintEventArgs e) { }
        private void btn_timVIP_Click(object sender, EventArgs e) { }
        private void panelQuet_Paint(object sender, PaintEventArgs e) { }
        private void panelThongTin_Paint(object sender, PaintEventArgs e) { }
        private void flpanel_pictures_Paint(object sender, PaintEventArgs e) { }
        private void panelPictures_Paint_1(object sender, PaintEventArgs e) { }
    }

}