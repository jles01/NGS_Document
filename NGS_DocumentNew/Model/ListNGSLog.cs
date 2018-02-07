using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGS_DocumentNew.Database;
using System.Data.SQLite;
namespace NGS_DocumentNew.Model
{
    public class ListNGSLog
    {
        public List<Log> logList = null;

        public ListNGSLog()
        {
            logList = new List<Log>();
        }

        public void LoadList( string text, string logType )
        {
            logList.Clear();
            string sql = "";
            if (logType == "WSZYSTKIE")
                sql = "SELECT l.LogGUID, l.LogDateTime, l.LogType, l.LogMessage, l.UserGUID, l.CompanyGUID, u.UserName FROM LogTable l INNER JOIN User u ON u.UserGUID = l.UserGUID WHERE l.LogMessage like '%" + text + "%'";
            else if( logType == "UŻYTKOWNIKA")
                sql = "SELECT l.LogGUID, l.LogDateTime, l.LogType, l.LogMessage, l.UserGUID, l.CompanyGUID, u.UserName FROM LogTable l INNER JOIN User u ON u.UserGUID = l.UserGUID WHERE l.LogMessage like '%" + text + "%' and lower(logType) = '" + "user" + "'";
            else if( logType == "SYSTEMOWE")
                sql = "SELECT l.LogGUID, l.LogDateTime, l.LogType, l.LogMessage, l.UserGUID, l.CompanyGUID, u.UserName FROM LogTable l INNER JOIN User u ON u.UserGUID = l.UserGUID WHERE l.LogMessage like '%" + text + "%' and lower(logType) = '" + "system" +"'";

            NGSConnector connector = new NGSConnector();

            SQLiteDataReader reader = connector.execSQLWithResult(sql);

            while(reader.Read())
            {
                Log l = new Log();
                l.FillData( reader.GetString(0)
                ,reader.GetDateTime(1)
                ,reader.GetString(2)
                ,reader.GetString(3)
                ,reader.GetString(4)
                ,reader.GetString(5)
                ,reader.GetString(6));

                logList.Add(l);
            }

            reader.Close();
            connector = null;

        }

    }
}
