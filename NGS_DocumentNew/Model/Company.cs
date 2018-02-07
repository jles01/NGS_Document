using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class Company : NGSObject
    {
        public String CompanyGUID { get; set; }
        public String CompanyName { get; set; }

        public void FillData( String _CompanyGUID, String _CompanyName )
        {
            CompanyGUID = _CompanyGUID;
            CompanyName = _CompanyName;
        }

        public void Save()
        {
            string sql = @"INSERT INTO Company VALUES( @CompanyGUID, @CompanyName )";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@CompanyName", CompanyName));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

        public void Update()
        {
            string sql = @"UPDATE Company SET CompanyName = @CompanyName WHERE CompanyGUID = @CompanyGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@CompanyName", CompanyName));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

    }
}
