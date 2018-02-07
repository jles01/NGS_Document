using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGS_DocumentNew.Model;
using System.Diagnostics;

namespace NGS_DocumentNew.Views
{
    public partial class UpdateView : Form
    {
        public UpdateView()
        {
            InitializeComponent();
            this.Text = GlobalVariables.ApplicationName + " - Aktualizacja";

            LoadStatus();
        }

        private void LoadStatus()
        {
            tbCurrentVersion.Text = GlobalVariables.Version;
            tbAvaliableVersion.Text = NGS_DocumentNew.Update.NGSUpdate.versionOnTheserver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            if( NGS_DocumentNew.Update.NGSUpdate.isUpdateAvaliable() )
            {
                btnUpdate.Enabled = true;
                MessageBox.Show("Nowa wersja aplikacji jest dostępna.");
                LoadStatus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if( NGS_DocumentNew.Update.NGSUpdate.DownloadNewVersion() )
            {
                NGS_DocumentNew.Update.NGSUpdate.Update();
            }
        }
    }
}
