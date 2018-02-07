using NGS_DocumentNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGS_DocumentNew.Views
{
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();

            LoadSettings();
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            this.Text = GlobalVariables.ApplicationName + " - ustawienia firmy " + GlobalVariables.CurrentCompany.CompanyName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            GlobalVariables.CurrentCompanySettings.SetSettingValue("NazwaAdministratoraDanych", tbAdministratorName.Text);
            GlobalVariables.CurrentCompanySettings.DeleteSettings();
            GlobalVariables.CurrentCompanySettings.SaveSettings();

            GlobalVariables.Log("Użytkownik zmienił ustawienia.");
        }

        private void LoadSettings()
        {
            tbAdministratorName.Text = GlobalVariables.CurrentCompanySettings.GetSettingValueOrDefault("NazwaAdministratoraDanych", "");
        }
    }
}
