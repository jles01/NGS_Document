using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGS_DocumentNew.Model
{
    public static class GlobalVariables
    {
        public static User CurrentUser { get; set; }
        public static Company CurrentCompany { get; set; }
        public static Settings CurrentCompanySettings { get; set; }
        public static String LicenseKey { get; set; }

        public static String Version = "0.0.1";
        public static String ApplicationName = "IOD DataCare v." + Version;

        public static string GetCurrentPath()
        {
            return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetDatabaseName()
        {
            return "NGS_Document.sqlite";
        }

        public static string GetDatabasePath()
        {
            return GetDatabasePath(GlobalVariables.GetDatabaseName());
        }

        public static string GetDatabasePath(string databaseName)
        {
            System.IO.Directory.CreateDirectory(GlobalVariables.GetCurrentPath() + "\\Database");

            return GlobalVariables.GetCurrentPath() + "\\Database\\" + databaseName;
        }

        public static string GetConnectionString()
        {
            return GetConnectionString(GlobalVariables.GetDatabaseName());
        }

        public static void ShowMessage(string msgTxt, string captionMsg, int msgLvl )
        {
            if (msgLvl == 1) //WARNING
            {
                MessageBox.Show(msgTxt, ApplicationName + " - " + captionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (msgLvl == 3) //ERROR
            {
                MessageBox.Show(msgTxt, ApplicationName + " - " + captionMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetConnectionString(string databaseName)
        {
            string str = "Data Source={0};Version=3;";

            return str.Replace("{0}", GetDatabasePath(databaseName));
        }

        public static string GetNewGUID()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }

        public static void Log( string message )
        {
            Log(message, "System");
        }

        public static void Log( string message, string logtype )
        {
            Model.Log l = new Model.Log();
            if(CurrentCompany != null )
                l.SaveLog(GlobalVariables.CurrentUser.UserGUID, CurrentCompany.CompanyGUID, message, logtype);
            else
                l.SaveLog(GlobalVariables.CurrentUser.UserGUID, "", message, logtype);
        }

        public static string GetMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToUpper();
            }
        }
    }
}
