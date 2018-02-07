using NGS_DocumentNew.License;
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
using System.Net.NetworkInformation;

namespace NGS_DocumentNew.Views
{
    public partial class LicenseView : Form
    {
        
        public LicenseView()
        {
            InitializeComponent();
            this.Text = GlobalVariables.ApplicationName + " - Licencja";

            LoadLicenseStatus();

            tbMACAdres.Text = GetMacAddress();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalSettings gs = new GlobalSettings();
            gs.LoadSettings();
            gs.SetSettingValue("LicenseKey", tbLicenseKey.Text);
            gs.DeleteSettings();
            gs.SaveSettings();

            GlobalVariables.Log("Użytkownik zmienił kod licencyjny.");

            LoadLicenseStatus();
        }

        private void LoadLicenseStatus()
        {
            GlobalSettings gs = new GlobalSettings();

            gs.LoadSettings();
            tbLicenseKey.Text = gs.GetSettingValueOrDefault("LicenseKey", "");

            if(tbLicenseKey.Text.Trim() == "")
            {
                lblLicenseInfo.Text = "";
                return;
            }

            if (CryptLib.isKeyValid(tbLicenseKey.Text))
            {
                try
                {
                    string key = gs.GetSettingValueOrDefault("LicenseKey", "");
                    lblLicenseInfo.Text = "Aktualne dane licencyjne.\n";
                    lblLicenseInfo.Text += "\nWażna od: " + CryptLib.getDateFrom(key);
                    lblLicenseInfo.Text += "\nWażna do: " + CryptLib.getDateTo(key);
                    lblLicenseInfo.Text += "\nLiczba użytkowników: " + CryptLib.getNumOfUsers(key);
                    lblLicenseInfo.Text += "\nLiczba firm: " + CryptLib.getNumOfCompanies(key);
                }
                catch
                {
                    GlobalVariables.ShowMessage("Błąd w numerze licencji.", "Licencja - błąd", 3);
                }
            }
            else
            {
                lblLicenseInfo.Text = "Błędna licencja";
                GlobalVariables.ShowMessage("Błąd w numerze licencji.", "Licencja - błąd", 3);
            }
        }

        public static string GetMacAddress()
        {
            var myInterfaceAddress = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .OrderByDescending(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                .Select(n => n.GetPhysicalAddress())
                .FirstOrDefault();

            return myInterfaceAddress.ToString();
        }
    }
}
