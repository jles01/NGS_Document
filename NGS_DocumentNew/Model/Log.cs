using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using NGS_DocumentNew.Database;

namespace NGS_DocumentNew.Model
{
    public class Log
    {
        public String LogGUID { get; set; } 
        public DateTime LogDateTime { get; set; }
        public String LogType { get; set; }
        public String LogMessage { get; set; }
        public String UserGUID { get; set; }
        public String CompanyGUID { get; set; }
        public String UserName { get; set; }

        public void FillData(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                LogGUID = reader.GetString(0);
                LogDateTime = reader.GetDateTime(1);
                LogType = reader.GetString(2);
                LogMessage = reader.GetString(3);
                UserGUID = reader.GetString(4);
                CompanyGUID = reader.GetString(5);
                UserName = reader.GetString(6);
            }

            reader.Close();
        }

        public void FillData(String _LogGUID
                            , DateTime _LogDateTime
                            , String _LogType
                            , String _LogMessage
                            , String _UserGUID
                            , String _CompanyGUID
                            , String _UserName)
        {
            
            LogGUID = _LogGUID;
            LogDateTime = _LogDateTime;
            LogType = _LogType;
            LogMessage = _LogMessage;
            UserGUID = _UserGUID;
            CompanyGUID = _CompanyGUID;
            UserName = _UserName;
        }

        public void SaveLog(string userGUID, string companyGUID, string logMessage, string logType)
        {
            string sql = @"INSERT INTO LogTable( LogGUID, LogDateTime, LogType, LogMessage, UserGUID, CompanyGUID ) 
                           Values( @LogGUID, @LogDateTime, @LogType, @LogMessage, @UserGUID, @CompanyGUID )";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@LogGUID", GlobalVariables.GetNewGUID()));
            paramList.Add(new SQLiteParameter("@LogDateTime", DateTime.Now));
            paramList.Add(new SQLiteParameter("@LogType", logType));
            paramList.Add(new SQLiteParameter("@LogMessage", logMessage));
            paramList.Add(new SQLiteParameter("@UserGUID", userGUID));
            paramList.Add(new SQLiteParameter("@CompanyGUID", companyGUID));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);
        }

    }
}
