using LOGIN.Main_UserControls.GhepDoi_UserControls;
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
using LOGIN;

namespace Main_Interface.User_Controls
{
    public partial class LocUser : UserControl
    {
        private Main MainForm;
        public LocUser()
        {
            InitializeComponent();
            btnTimKiem.Click += BtnTimKiem_Click;
        }

        private async void BtnTimKiem_Click(object sender, EventArgs e)
        {
            FilterModel filter = new FilterModel
            {
                GioiTinh = comboGioiTinh?.SelectedItem?.ToString(),
                DoTuoi = (int)num_dotuoi.Value,
                ChieuCaoMin = (int)num_chieucao.Value,
                NoiSong = textNoiSong.Text
            };

            MatchFilterAPI api = new MatchFilterAPI("login-bb104");

            try
            {
                List<USER> ans = await api.FilterUsers(filter);
                MainForm.gd.LoadFilteredUsers(ans);
                if (ans.Count > 0)
                {
                    MessageBox.Show(
                        $"Đã tìm thấy {ans.Count} người phù hợp!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy người phù hợp với tiêu chí!",
                        "Kết quả rỗng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lọc người dùng:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        public LocUser(Main m)
        {
            InitializeComponent();
            MainForm = m;
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.LoadContent(new GhepDoi(MainForm));
        }
        private void LocUser_Load(object sender, EventArgs e)
        {

        }
    }
}
