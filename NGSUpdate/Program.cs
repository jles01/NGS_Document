using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.IO.Compression;

namespace NGSUpdate
{
    class Program
    {
        public static string GetCurrentPath()
        {
            return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);
            int processId = Int32.Parse(args[0]);
            //Process p = Process.GetProcessById(Int32.Parse(args[0]));
            Process[] processlist = Process.GetProcesses();

            processlist.First(pr => pr.Id == processId).Kill();

            /*string updateFolder = GetCurrentPath() + @"\SQL";
            if ( System.IO.Directory.Exists(updateFolder) )
                System.IO.Directory.Delete(updateFolder,true);
            System.IO.Compression.ZipFile.ExtractToDirectory(GetCurrentPath() + @"\update.zip", GetCurrentPath(),);
            */

            ZipArchive archive = ZipFile.OpenRead(GetCurrentPath() + @"\update.zip");
            ZipArchiveExtensions.ExtractToDirectory(archive, GetCurrentPath(),true);


                string path = GetCurrentPath();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = @"cmd";
            psi.Arguments = "/C start \"" + path + "\" NGS_DocumentNew.exe ";

            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
