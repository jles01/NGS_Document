using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NGS_DocumentNew.Views
{
    public partial class OpenView : Form
    {
        public OpenView()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void OpenView_Shown(object sender, EventArgs e)
        {
            int x = 0;
            while (x < 30)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                x++;
            }

            try
            {
                NGS_DocumentNew.Model.Browser.CreateBrowserKey();
            }
            catch {}

            LoginScreen ls = new LoginScreen();
            ls.Show();

            this.Visible = false;
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
