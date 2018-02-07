using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class Document
    {
        public String CompanyGUID { get; set; }
        public String DocumentGUID { get; set; }
        public String DocumentName { get; set; }
        public String DocumentText { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public String CreatedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public String LastModifiedBy { get; set; }
        public DateTime PrintedDateTime { get; set; }
        public DateTime? DocumentEndDateTime { get; set; }
        
        public void FillData(
            String companyGUID,
            String documentGUID,
            String documentName,
            String documentText,
            DateTime createdDateTime,
            String createdBy
            ,DateTime lastModifiedDateTime
            , String lastModifiedBy
            , DateTime printedDateTime
            , DateTime? documentEndDateTime
            )
        {
            CompanyGUID = companyGUID;
            DocumentGUID = documentGUID;
            DocumentName = documentName;
            DocumentText = documentText;
            CreatedDateTime = createdDateTime;
            CreatedBy = createdBy;
            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedBy = lastModifiedBy;
            PrintedDateTime = printedDateTime;
            DocumentEndDateTime = documentEndDateTime;
        }

        
        public void Save()
        {
            string sql = @"INSERT INTO Document VALUES( @CompanyGUID, @DocumentGUID, @DocumentName, @DocumentText, @CreatedDateTime, @CreatedBy, @LastModifiedDateTime, @LastModifiedBy, @PrintedDateTime, @DocumentEndDateTime)";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@DocumentGUID", DocumentGUID));
            paramList.Add(new SQLiteParameter("@DocumentName", DocumentName));
            paramList.Add(new SQLiteParameter("@DocumentText", DocumentText));
            paramList.Add(new SQLiteParameter("@CreatedDateTime", CreatedDateTime));
            paramList.Add(new SQLiteParameter("@CreatedBy", CreatedBy));
            paramList.Add(new SQLiteParameter("@LastModifiedDateTime", LastModifiedDateTime));
            paramList.Add(new SQLiteParameter("@LastModifiedBy", LastModifiedBy));
            paramList.Add(new SQLiteParameter("@PrintedDateTime", PrintedDateTime));
            paramList.Add(new SQLiteParameter("@DocumentEndDateTime", DocumentEndDateTime));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            GlobalVariables.Log("Użytkownik stowrzył nowy dokument: " + DocumentName + " document id: " + DocumentGUID);

            connector = null;
        }

        
        public void Update()
        {
            string sql = @"UPDATE Document 
            SET DocumentName = @DocumentName
                ,DocumentText = @DocumentText
                ,CreatedDateTime = @CreatedDateTime
                ,CreatedBy = @CreatedBy
                ,LastModifiedDateTime = @LastModifiedDateTime
                ,LastModifiedBy = @LastModifiedBy
                ,PrintedDateTime = @PrintedDateTime
                ,DocumentEndDateTime = @DocumentEndDateTime
            WHERE CompanyGUID = @CompanyGUID AND DocumentGUID = @DocumentGUID
            ";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@DocumentGUID", DocumentGUID));
            paramList.Add(new SQLiteParameter("@DocumentName", DocumentName));
            paramList.Add(new SQLiteParameter("@DocumentText", DocumentText));
            paramList.Add(new SQLiteParameter("@CreatedDateTime", CreatedDateTime));
            paramList.Add(new SQLiteParameter("@CreatedBy", CreatedBy));
            paramList.Add(new SQLiteParameter("@LastModifiedDateTime", LastModifiedDateTime));
            paramList.Add(new SQLiteParameter("@LastModifiedBy", LastModifiedBy));
            paramList.Add(new SQLiteParameter("@PrintedDateTime", PrintedDateTime));
            paramList.Add(new SQLiteParameter("@DocumentEndDateTime", DocumentEndDateTime));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            GlobalVariables.Log("Użytkownik zaktualizował dokument: " + DocumentName + " document id: " + DocumentGUID);

            connector = null;
        }

        
        public void Delete()
        {
            string sql = @"DELETE FROM Document WHERE CompanyGUID = @CompanyGUID AND DocumentGUID = @DocumentGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@DocumentGUID", DocumentGUID));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            GlobalVariables.Log("Użytkownik usunął document id: " + DocumentGUID);

            connector = null;
        }

        
        public String GetFieldValue( String fieldName)
        {
            string sql = @"SELECT FieldValue FROM DocumentField WHERE CompanyGUID = @CompanyGUID AND DocumentGUID = @DocumentGUID and FieldName = @FieldName";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));
            paramList.Add(new SQLiteParameter("@DocumentGUID", DocumentGUID));
            paramList.Add(new SQLiteParameter("@FieldName", fieldName));

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            string retVal = "";

            while (reader.Read())
            {
                retVal = reader.GetString(0);
            }

            connector = null;

            return retVal;
        }
    }
}
