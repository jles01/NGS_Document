using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class DocumentTemplate
    {
        public String DocumentTemplateGUID { get; set; }
        public String DocumentName { get; set; }
        public String DocumentText { get; set; }
        public String DocumentHint { get; set; }
        public String DocumentType { get; set; }
        public String DocumentEndDate { get; set; }

        public void FillData(string _DocumentTemplateGUID, string _DocumentName, string _DocumentText, string _DocumentHint, string _DocumentType, string _DocumentEndDate)
        {
            DocumentTemplateGUID = _DocumentTemplateGUID;
            DocumentName = _DocumentName;
            DocumentText = _DocumentText;
            DocumentHint = _DocumentHint;
            DocumentType = _DocumentType;
            DocumentEndDate = _DocumentEndDate;
        }

        public void Save()
        {
            string sql = @"INSERT INTO DocumentTemplate VALUES( @DocumentTemplateGUID, @DocumentName, @DocumentText, @DocumentHint, @DocumentType, @DocumentEndDate)";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@DocumentTemplateGUID", DocumentTemplateGUID));
            paramList.Add(new SQLiteParameter("@DocumentName", DocumentName));
            paramList.Add(new SQLiteParameter("@DocumentText", DocumentText));
            paramList.Add(new SQLiteParameter("@DocumentHint", DocumentHint));
            paramList.Add(new SQLiteParameter("@DocumentType", DocumentType));
            paramList.Add(new SQLiteParameter("@DocumentEndDate", DocumentEndDate));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            GlobalVariables.Log("Użytkownik stowrzył szablon: " + DocumentName + "  id: " + DocumentTemplateGUID);

            connector = null;
        }

        
    }
}
