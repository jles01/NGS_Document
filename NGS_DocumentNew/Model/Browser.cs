using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace NGS_DocumentNew.Model
{
    public static class Browser
    {
        static string BrowserKeyPath = @"\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
        //32bit OS
        //\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION
        //32bit app on 64bit OS
        //\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION
        public static void RemoveBrowserKey()
        {
            RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(BrowserKeyPath.Substring(1), true);
            key.DeleteValue(Process.GetCurrentProcess().ProcessName + ".exe", false);
        }
        public static void CreateBrowserKey(bool IgnoreIDocDirective = false)
        {
            string basekey = Microsoft.Win32.Registry.CurrentUser.ToString();
            Int32 value = 11000;
            //Value reference: http://msdn.microsoft.com/en-us/library/ee330730%28v=VS.85%29.aspx
            //IDOC Reference:  http://msdn.microsoft.com/en-us/library/ms535242%28v=vs.85%29.aspx
            WebBrowser browser = new WebBrowser();
            switch (browser.Version.Major)
            {
                case 8:
                    if (IgnoreIDocDirective)
                    {
                        value = 8888;
                    }
                    else
                    {
                        value = 8000;
                    }
                    break;
                case 9:
                    if (IgnoreIDocDirective)
                    {
                        value = 9999;
                    }
                    else
                    {
                        value = 9000;
                    }
                    break;
                case 10:
                    if (IgnoreIDocDirective)
                    {
                        value = 10001;
                    }
                    else
                    {
                        value = 10000;
                    }
                    break;
                case 11:
                    if (IgnoreIDocDirective)
                    {
                        value = 11001;
                    }
                    else
                    {
                        value = 11000;
                    }
                    break;
                default:
                    break;
            }
            Microsoft.Win32.Registry.SetValue(Microsoft.Win32.Registry.CurrentUser.ToString() + BrowserKeyPath, Process.GetCurrentProcess().ProcessName + ".exe", value, Microsoft.Win32.RegistryValueKind.DWord);
        }
    }
}
