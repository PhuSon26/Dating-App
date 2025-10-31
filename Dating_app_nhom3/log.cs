using System;
using System.Drawing;
using System.Windows.Forms;
using Firebase.Auth;


namespace Dating_app_nhom3
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            quenmatkhau f1 = new quenmatkhau();
            f1.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dangky f2 = new dangky();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
