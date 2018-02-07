using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class Settings
    {
        public String CompanyGUID { get; set; }
        public Dictionary<String, String> SettingList { get; set; }

        public String GetSettingValue( String settingName )
        {
            if (SettingList.ContainsKey(settingName))
                return SettingList[settingName];
            else
                return null;
        }

        public String GetSettingValueOrDefault(String settingName, String defaultValue)
        {
            if (SettingList.ContainsKey(settingName))
                return SettingList[settingName];
            else
                return defaultValue;
        }

        public void SetSettingValue( String settingName, String settingValue)
        {
            
            if (SettingList.ContainsKey(settingName))
                SettingList[settingName] = settingValue;
            else
            {
                Console.WriteLine(settingName + " " + settingValue);
                SettingList.Add(settingName, settingValue);
            }
        }

        public void LoadSettings(String companyGUID)
        {
            string sql = @"SELECT SettingName, SettingValue FROM Settings WHERE CompanyGUID = @CompanyGUID";

            SettingList = new Dictionary<string, string>();
            CompanyGUID = companyGUID;
            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", companyGUID));

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            while(reader.Read())
            {
                SettingList.Add(reader.GetString(0), reader.GetString(1));
            }

            reader.Close();

            connector = null;
        }

        public void SaveSettings()
        {
            string sql = @"INSERT INTO Settings VALUES( @CompanyGUID, @SettingName, @SettingValue)";

            NGSConnector connector = new NGSConnector();

            foreach (KeyValuePair<String, String> keyPair in SettingList)
            {
                List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
                paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
                paramList.Add(new SQLiteParameter("@SettingName", keyPair.Key));
                paramList.Add(new SQLiteParameter("@SettingValue", keyPair.Value));

                connector.execSQL(sql, paramList);

            }
            connector = null;
        }

        public void DeleteSettings()
        {
            string sql = @"DELETE FROM Settings WHERE CompanyGUID = @CompanyGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

    }
}
