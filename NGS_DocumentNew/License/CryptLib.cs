using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace NGS_DocumentNew.License
{
    public static class CryptLib
    {
        #region Settings

        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash = "SHA1";
        private static string _salt = "aselrias38490a32"; // Random
        private static string _vector = "8947az34awl34kjq"; // Random
        private static string pass = "NGSDocument1234$";
        #endregion

        public static string GetMacAddress()
        {
            var myInterfaceAddress = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .OrderByDescending(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                .Select(n => n.GetPhysicalAddress())
                .FirstOrDefault();

            return myInterfaceAddress.ToString();
        }

        public static string GenerateLicense(string dtFrom, string dtTo, string numCompanies, string numOfUsers, string mac)
        {
            string ret = GetEncryptMACAddress(mac) + GetLetter(numOfUsers) + "-" + GetLetterForDate(dtFrom) + "-" + GetLetterForDate(dtTo) + "-"
                    + GetLetter(numCompanies);

            string sumCtrl = GetControlSum(ret, GetEncryptMACAddress(mac));


            return ret + sumCtrl;
        }


        private static string GetControlSum(string input1, string input2)
        {
            int val = -7;
            foreach (char c in input1)
            {
                val += (int)c;
            }

            Console.WriteLine(val);
            int ret = 0;//(int)(val / 100) + (int)((val / 1000) / 100) + (int)((val / 1100 )/ 10) + (int)(val / 1110);

            foreach (char c in val.ToString())
            {
                ret += Int32.Parse(c.ToString());
            }

            Console.WriteLine(ret.ToString() + " " + input1 + " " + input2);
            Console.WriteLine(ret);

            return ret.ToString();
        }

        private static string GetEncryptMACAddress(string mac)
        {
            int val = 17;
            foreach (char c in mac)
            {
                int res = 1;
                if (Int32.TryParse(c.ToString(), out res))
                    val += res;
                else
                    val += 23;
            }
            if (val > 100)
                val = (int)val / 10;
            return val.ToString();
        }

        public static string GetLetterForDate(string date)
        {
            string ret = "";

            ret = GetLetter(date.Substring(0, 4));
            ret += GetLetter(date.Substring(5, 2));
            ret += GetLetter(date.Substring(8, 2));

            return ret;
        }

        public static string GetDateFromLetter(string date)
        {
            return GetValue(date);
        }

        private static string GetValue(string input)
        {
            string ret = "";

            foreach (Char c in input)
            {
                int x = ((int)c) - 17;
                ret += ((char)x).ToString();
            }


            return ret;
        }

        private static string GetLetter(string input)
        {
            string ret = "";

            foreach (Char c in input)
            {
                int x = ((int)c) + 17;
                //Console.WriteLine("Letter : " + c.ToString() + " " + x);
                ret += ((char)x).ToString();
            }


            return ret;
        }

        public static bool isKeyValid(string key)
        {
            if (key == null || key.Length < 12 || key.Split('-').Length < 4)
                return false;

            if (GetControlSum(key.Substring(0, key.Length - 2), key.Substring(0, 2)) ==
                key.Substring(key.Length - 2, 2)
                && key.Substring(0, 2) == GetEncryptMACAddress(GetMacAddress()))
                return true;

            return false;
        }

        public static string getNumOfCompanies(string key)
        {
            if (key.Split('-').Length == 4)
            {
                return GetValue(key.Split('-')[3].Substring(0, 2));
            }
            else
                return "";
        }

        public static string getNumOfUsers(string key)
        {
            if (key.Split('-').Length == 4)
            {
                return GetValue(key.Split('-')[0].Substring(2, 2));
            }
            else
                return "";
        }

        public static string getDateTo(string key)
        {
            if (key.Split('-').Length == 4)
            {
                return GetValue(key.Split('-')[2]).Substring(0, 4) + "-" + GetValue(key.Split('-')[2]).Substring(4, 2) + "-" + GetValue(key.Split('-')[2]).Substring(6, 2);
            }
            else
                return "";
        }

        public static string getDateFrom(string key)
        {
            if (key.Split('-').Length == 4)
            {
                return GetValue(key.Split('-')[1]).Substring(0, 4) + "-" + GetValue(key.Split('-')[1]).Substring(4, 2) + "-" + GetValue(key.Split('-')[1]).Substring(6, 2);
            }
            else
                return "";
        }



    }
}
