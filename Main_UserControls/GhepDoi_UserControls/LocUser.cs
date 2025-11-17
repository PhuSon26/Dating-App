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
                GioiTinh = comboGioiTinh?.SelectedItem.ToString(),
                DoTuoi = int.Parse(comboBox1?.SelectedItem.ToString()),
                NoiSong = textNoiSong.Text,
                SoThich = textSoThich.Text,
                HocVan = comboHocVan?.SelectedItem.ToString(),
                CongViec = textCongViec.Text
            };
            MatchFilterAPI api = new MatchFilterAPI("login-bb104");
            List<USER> ans = await api.FilterUsers(filter);
            MainForm.gd.LoadFilteredUsers(ans);
        }
        public LocUser(Main m)
        {
            InitializeComponent();
            MainForm = m;
        }

        private void LocUser_Load(object sender, EventArgs e)
        {

        }
    }
}
