using NGS_DocumentNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.License
{
    public static class NGSLicense
    {
        public static GlobalSettings gs;

        private static void LoadGlobalSettings()
        {
            gs = new GlobalSettings();
            gs.LoadSettings();
        }

        public static bool isLicenseValid()
        {
            LoadGlobalSettings();
            String licenseKey = gs.GetSettingValueOrDefault("LicenseKey", "");
            bool ret = false;
            if (CryptLib.isKeyValid(licenseKey))
            {
                DateTime dateTo = Convert.ToDateTime(CryptLib.getDateTo(licenseKey));

                int compare = DateTime.Compare(DateTime.Now, dateTo);

                if (compare <= 0)
                    ret = true;
                //Console.WriteLine(compare);
                
            }
            
            return ret;
        }

        public static int getNumberOfCompaniesRegistered()
        {
            LoadGlobalSettings();
            return Int32.Parse(CryptLib.getNumOfCompanies(gs.GetSettingValueOrDefault("LicenseKey", "")));
        }

        public static int getNumberOfUsers()
        {
            LoadGlobalSettings();
            return Int32.Parse(CryptLib.getNumOfUsers(gs.GetSettingValueOrDefault("LicenseKey", "")));
        }

        public static string getEndDateOfLicense()
        {
            LoadGlobalSettings();
            return CryptLib.getDateTo(gs.GetSettingValueOrDefault("LicenseKey", ""));
        }

        public static string getStartDateOfLicense()
        {
            LoadGlobalSettings();
            return CryptLib.getDateFrom(gs.GetSettingValueOrDefault("LicenseKey", ""));
        }

        public static string statusBarInfo()
        {
            LoadGlobalSettings();
            if (isLicenseValid())
                return "Licencja jest ważna do : " + CryptLib.getDateTo(gs.GetSettingValueOrDefault("LicenseKey", ""));
            else
                return "Licencja jest nieważna.";
        }
    }
}
