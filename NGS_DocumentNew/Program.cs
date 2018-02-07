using NGS_DocumentNew.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGS_DocumentNew
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*if( Update.NGSUpdate.isUpdateAvaliable() )
            {
                MessageBox.Show("Jest nowa wersja programu");
            }*/
            /*
               string x = NGS_DocumentNew.License.CryptLib.GetLetterForDate("2017-03-15");
               string y = NGS_DocumentNew.License.CryptLib.GenerateLicense("2017-03-15", "2017-06-30", "10", "03");
               Console.WriteLine(y);

               Console.WriteLine(NGS_DocumentNew.License.CryptLib.isKeyValid(y));
               */

            try
            {
                Update.NGSUpdate.UpdateDB();
                //Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Id);
                Update.NGSUpdate.CurrentProcessId = System.Diagnostics.Process.GetCurrentProcess().Id;
            }catch(Exception ex)
            {
                MessageBox.Show("Bład podczas updatu: sciezka bazy : " + NGS_DocumentNew.Model.GlobalVariables.GetDatabasePath() + " " + ex.Message + "\n" + ex.StackTrace);
            }
            try
            {
                    Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new OpenView());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sciezka aplikacji : " + NGS_DocumentNew.Model.GlobalVariables.GetDatabasePath() + " Blad podczas uruchamiania aplikacji: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
