using Google.Cloud.Firestore;
using LOGIN;
using LOGIN.Main_UserControls.GhepDoi_UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private readonly HttpClient _client = new HttpClient();

        private List<System.Drawing.Image> images = new List<System.Drawing.Image>();
        private Main MainForm;
        private LocUser loc;
        private MatchFilterAPI filterAPI;
        private FirebaseAuthHelper authHelper;
        private List<USER> suggestedUsers = new List<USER>();
        public FirestoreDb db;

        private int suggestIndex = 0;
        private LOGIN.Match match;
        string myUserId = Session.LocalId;
        private USER myUser;
        public GhepDoi()
        {
            InitializeComponent();
            authHelper = new FirebaseAuthHelper("login-bb104");
        }
        public GhepDoi(Main m)
        {
            InitializeComponent();
            match = new LOGIN.Match("login-bb104", myUserId);
            MainForm = m;
            authHelper = new FirebaseAuthHelper("login-bb104");
            loc = new LocUser(MainForm);
            filterAPI = new MatchFilterAPI("login-bb104");
            db = FirestoreDb.Create("login-bb104");
        }

        private void ShowUser(USER u)
        {
            flpanel_pictures.Controls.Clear();

            if (u == null) return;

            // --- XỬ LÝ ẢNH (QUAN TRỌNG) ---
            flpanel_pictures.Controls.Clear(); // Xóa ảnh cũ đi

            // Kiểm tra xem list photos có dữ liệu không
            if (u.photos != null && u.photos.Count > 0)
            {
                // Nếu có list ảnh -> Duyệt vòng lặp để hiện hết lên
                foreach (string photoUrl in u.photos)
                {
                    AddImageToPanel(photoUrl);
                }
            }
            avatar.Image = authHelper.Base64ToImage(u.AvatarUrl);

            tb_name.Text = u.ten ?? "No Name";
            tb_tuoi.Text = u.tuoi.ToString();
            tb_snhat.Text = u.snhat;
            tb_hocvan.Text = u.hocvan ?? "---";
            tb_nghe.Text = u.nghenghiep ?? "---";


            tb_chieucao.Text = u.chieucao > 0 ? $"{u.chieucao}m" : "---";

            tb_thoiquen.Text = u.thoiquen ?? "Chưa cập nhật";
            tb_vitri.Text = u.vitri ?? "---";
            tb_gioithieu.Text = u.gthieu ?? "Người dùng này chưa viết gì về mình.";
        }
        private async void AddImageToPanel(string url)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(300, 350);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Margin = new Padding(10);

            try
            {
                if (url.StartsWith("http"))
                {
                    // Ảnh URL từ Firebase Storage
                    pb.Image = await LoadImageFromUrl(url);
                }
                else
                {
                    // Ảnh Base64
                    pb.Image = authHelper.Base64ToImage(url);
                }
            }
            catch
            {
                pb.BackColor = Color.LightGray; // fallback
            }

            flpanel_pictures.Controls.Add(pb);
        }
        private async Task<Image> LoadImageFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }
        private async Task LoadFilteredUsers(FilterModel filter)
        {
            suggestedUsers = await filterAPI.FilterUsers(filter);

            suggestIndex = 0;

            if (suggestedUsers.Count > 0)
                ShowUser(suggestedUsers[0]);
            else
                MessageBox.Show("Không tìm thấy người phù hợp!");
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
                var allUsers = await db.Collection("Users").GetSnapshotAsync();
                int totalUsers = allUsers.Count;

                suggestedUsers = await authHelper.GetRandomSuggest(userId, totalUsers);

                if (suggestedUsers == null || suggestedUsers.Count == 0)
                {
                    MessageBox.Show("Không có user nào phù hợp để gợi ý.");
                    return;
                }

                suggestIndex = 0; // reset index
                ShowUser(suggestedUsers[suggestIndex]); // hiển thị user đầu tiên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải gợi ý: " + ex.Message);
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
            if (suggestIndex >= suggestedUsers.Count)
                suggestIndex = 0;

            ShowUser(suggestedUsers[suggestIndex]);
        }

        private void btn_kothich_Click(object sender, EventArgs e)
        {
            NextSuggestUser();
        }
        private async void btn_tim_Click(object sender, EventArgs e)
        {

            if (suggestedUsers == null || suggestedUsers.Count == 0) return;

            USER currentUserOnCard = suggestedUsers[suggestIndex];
            string targetUserId = currentUserOnCard.Id;


            btn_tim.Enabled = false;

            try
            {

                bool isMatch = await match.LikeUser(targetUserId);


                if (isMatch)
                {
                    MatchForm match = new MatchForm(myUser, currentUserOnCard, authHelper);
                    match.ShowDialog();
                    //MessageBox.Show($"Chúc mừng! Bạn và {currentUserOnCard.ten} đã tương hợp!", "It's a Match!");

                }
                else
                {
                    MessageBox.Show("Đã thả tim thành công!");
                }


                NextSuggestUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                // Mở lại nút bấm
                btn_tim.Enabled = true;
            }
        }
        private void Flpanel_pictures_MouseWheel(object sender, MouseEventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;

            if (panel == null) return;

            // Invert e.Delta nếu muốn cuộn theo hướng mong muốn
            int scrollAmount = panel.HorizontalScroll.Value - e.Delta;

            // Giới hạn trong min/max
            if (scrollAmount < panel.HorizontalScroll.Minimum)
                scrollAmount = panel.HorizontalScroll.Minimum;
            if (scrollAmount > panel.HorizontalScroll.Maximum)
                scrollAmount = panel.HorizontalScroll.Maximum;

            panel.HorizontalScroll.Value = scrollAmount;
            panel.PerformLayout();
        }

        private void panelPictures_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_timVIP_Click(object sender, EventArgs e)
        {

        }

        private void panelQuet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelThongTin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}