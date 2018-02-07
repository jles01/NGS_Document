using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class DocumentTemplateFlow
    {
        public String DocumentTemplateFlowGUID { get; set; }
        public String DocumentTemplateFlowName { get; set; }
        public String DocumentTemplateFlowType { get; set; }

        public void FillData(string _DocumentTemplateFlowGUID, string _DocumentTemplateFlowName, string _DocumentTemplateFlowType)
        {
            DocumentTemplateFlowGUID = _DocumentTemplateFlowGUID;
            DocumentTemplateFlowName = _DocumentTemplateFlowName;
            DocumentTemplateFlowType = _DocumentTemplateFlowType;
        }

        public void Save()
        {
            string sql = @"INSERT INTO DocumentTemplateFlow VALUES( @DocumentTemplateFlowGUID, @DocumentTemplateFlowName, @DocumentTemplateFlowType)";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowGUID", DocumentTemplateFlowGUID));
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowName", DocumentTemplateFlowName));
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowType", DocumentTemplateFlowType));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            GlobalVariables.Log("Użytkownik stowrzył kategorie: " + DocumentTemplateFlowName + "  id: " + DocumentTemplateFlowGUID);

            connector = null;
        }

        public void Delete()
        {
            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            NGSConnector connector = new NGSConnector();

            string sql = @"DELETE FROM DocumentTemplate WHERE DocumentTemplateGUID In (SELECT DocumentTemplateGUID FROM DocumentTemplateFlowAssignment WHERE DocumentTemplateFlowGUID= @DocumentTemplateFlowGUID)";
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowGUID", DocumentTemplateFlowGUID));
            connector.execSQL(sql, paramList);

            sql = @"DELETE FROM DocumentTemplateFlowAssignment WHERE DocumentTemplateFlowGUID = @DocumentTemplateFlowGUID";
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowGUID", DocumentTemplateFlowGUID));
            connector.execSQL(sql, paramList);

            sql = @"DELETE FROM DocumentTemplateFlow WHERE DocumentTemplateFlowGUID = @DocumentTemplateFlowGUID";
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowGUID", DocumentTemplateFlowGUID));
            connector.execSQL(sql, paramList);

            GlobalVariables.Log("Użytkownik usunął kategorie: " + DocumentTemplateFlowName + "  id: " + DocumentTemplateFlowGUID);

            connector = null;
        }
    }
}
