using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class DocumentField
    {
        public String CompanyGUID { get; set; }
        public String DocumentGUID { get; set; }
        public String FieldName { get; set; }
        public String FieldValue { get; set; }

        public void Delete()
        {
            string sql = @"DELETE FROM DocumentField WHERE CompanyGUID = @CompanyGUID AND DocumentGUID = @DocumentGUID AND FieldName = @FieldName ";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@DocumentGUID", DocumentGUID));
            paramList.Add(new SQLiteParameter("@FieldName", FieldName));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

        public void Save()
        {
            string sql = @"INSERT INTO DocumentField VALUES( @CompanyGUID, @DocumentGUID, @FieldName, @FieldValue)";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@DocumentGUID", DocumentGUID));
            paramList.Add(new SQLiteParameter("@FieldName", FieldName));
            paramList.Add(new SQLiteParameter("@FieldValue", FieldValue));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

        public void FillData( String companyGUID, String documentGUID, String fieldName, String fieldValue)
        {
            CompanyGUID = companyGUID;
            DocumentGUID = documentGUID;
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}
