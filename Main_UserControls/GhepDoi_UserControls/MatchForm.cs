using LOGIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Interface.User_Controls
{
    public partial class MatchForm : Form
    {
        private FirebaseAuthHelper auth;
        private USER u1;
        private USER u2;
        public MatchForm()
        {
            InitializeComponent();
        }
        public MatchForm(USER u1, USER u2, FirebaseAuthHelper auth)
        {
            InitializeComponent();
            this.u1 = u1;
            this.u2 = u2;
            this.auth = auth;
        }

        private void Match_Load(object sender, EventArgs e)
        {
            lb_user1.Text = string.IsNullOrWhiteSpace(u1.ten) ? "Anonymous" : u1.ten;
            lb_user2.Text = string.IsNullOrWhiteSpace(u2.ten) ? "Anonymous" : u2.ten;
            pb_avatarUser1.Image = auth.Base64ToImage(u1.AvatarUrl);
            pb_avatarUser2.Image = auth.Base64ToImage(u2.AvatarUrl);
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}