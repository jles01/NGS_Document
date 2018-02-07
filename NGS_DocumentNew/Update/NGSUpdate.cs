using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace NGS_DocumentNew.Update
{
    public static class NGSUpdate
    {
        private static string serverHost = "ftp://ftp.ngsol.webd.pl:21/";
        private static string serverUser = "aktualizacje@datacare.com.pl";
        private static string serverPass = "^Rmw#dxtsu,a";
        public static int CurrentProcessId = -1;
        public static string versionOnTheserver = Model.GlobalVariables.Version;

        public static bool isUpdateAvaliable()
        {
            bool ret = false;
            try
            {
                String ftpserver = serverHost + "/VERSION.TXT";
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpserver));

                reqFTP.Credentials = new NetworkCredential(serverUser, serverPass);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                Stream responseStream = response.GetResponseStream();

                StreamReader sr = new StreamReader(responseStream);
                string version = sr.ReadToEnd();
                sr.Close();
                
                if (version != null && version != Model.GlobalVariables.Version)
                {
                    versionOnTheserver = version;
                    ret = true;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }

        public static bool DownloadNewVersion()
        {
            bool ret = false;
            try
            {
                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                String ftpserver = serverHost + "/Update.zip";
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpserver));

                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

                reqFTP.Credentials = new NetworkCredential(serverUser, serverPass);

                Stream reader = reqFTP.GetResponse().GetResponseStream();
                FileStream fileStream = new FileStream(Model.GlobalVariables.GetCurrentPath() + @"\update.zip", FileMode.Create);

                while (true)
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                        break;

                    fileStream.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();

                ret = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }

        public static void Update()
        {
            UnZipFile();
        }

        private static void UnZipFile()
        {
            //System.IO.Compression.ZipFile.ExtractToDirectory(NGS_DocumentNew.Model.GlobalVariables.GetCurrentPath() + @"\update.zip", NGS_DocumentNew.Model.GlobalVariables.GetCurrentPath());
            /*Process process = new Process();

            process.StartInfo.FileName = NGS_DocumentNew.Model.GlobalVariables.GetCurrentPath() + @"\NGSUpdate.exe";
            process.StartInfo.Arguments = CurrentProcessId.ToString();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Sta*/
            string path = NGS_DocumentNew.Model.GlobalVariables.GetCurrentPath();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = @"cmd";
            psi.Arguments = "/C start \"" + path  + "\" NGSUpdate.exe " + CurrentProcessId.ToString() + "";

            Console.WriteLine("/C start \"" + path + "\" " + CurrentProcessId.ToString());
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process.Start(psi);
        }

        public static void UpdateDB()
        {
            NGS_DocumentNew.Model.GlobalSettings gs = new NGS_DocumentNew.Model.GlobalSettings();
            gs.LoadSettings();
            string path = NGS_DocumentNew.Model.GlobalVariables.GetCurrentPath() + "\\SQL\\";

            NGS_DocumentNew.Database.NGSConnector connector = new NGS_DocumentNew.Database.NGSConnector();


            Console.WriteLine(gs.GetSettingValueOrDefault("DatabaseVersion", ""));
            if ( gs.GetSettingValueOrDefault("DatabaseVersion", "") != NGS_DocumentNew.Model.GlobalVariables.Version)
            {
                if( System.IO.Directory.Exists(path) )
                {
                    foreach( string file in System.IO.Directory.GetFiles(path) )
                    {
                        string sql = System.IO.File.ReadAllText(file);

                        connector.execSQL(sql);
                    }
                }
            }


            connector = null;
        }
    }
}
