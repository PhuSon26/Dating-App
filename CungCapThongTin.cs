using Main_Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LOGIN
{
    public partial class CungCapThongTin : Form
    {
        private readonly string _uid;
        private readonly string _email;
        private readonly FirebaseAuthHelper _auth;
        private Main MainForm;

        public CungCapThongTin(string uid, string email, FirebaseAuthHelper auth)
        {
            InitializeComponent();
            _uid = uid;
            _email = email;
            _auth = auth;

            // ví dụ: gán sẵn email lên label/textbox nếu muốn
            // txtEmail.Text = _email;
        }
        private async void btnHoanTat_Click(object sender, EventArgs e)
        {
            // 1. Map UI -> USER
            var user = new USER
            {
                Id = _uid,
                ten = txtTen.Text.Trim(),
                gioitinh = cbGioiTinh.SelectedItem?.ToString() ?? "",
                tuoi = (int)nudTuoi.Value,
                snhat = dtp_snhat.Text.Trim(),
                hocvan = txtHocVan.Text.Trim(),
                nghenghiep = txtNgheNghiep.Text.Trim(),
                thoiquen = txtThoiQuen.Text.Trim(),
                gthieu = txtGioiThieu.Text.Trim(),
                chieucao = (float)nudChieuCao.Value,
                vitri = txtViTri.Text.Trim(),
                AvatarUrl = "",                    // tạm thời chưa up avatar
                photos = new List<string>(),    // list rỗng
                isVip = false
            };

            // 2. Validate đơn giản
            if (string.IsNullOrWhiteSpace(user.ten))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                return;
            }

            try
            {
                // 3. Gọi API lưu Firestore
                await _auth.CreateOrUpdateUserInfoAsync(user);

                MessageBox.Show("Đã lưu thông tin vào Firestore!");

                // TODO: chuyển form
                this.Close();
                MainForm = new Main(_auth);
                MainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu Firestore: " + ex.Message);
            }
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm = new Main(_auth);
            MainForm.Show();
        }
        private void CungCapThongTin_Load(object sender, EventArgs e)
        {

        }
    }
}
