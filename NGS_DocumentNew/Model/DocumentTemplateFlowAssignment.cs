using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class DocumentTemplateFlowAssignment
    {
        public String DocumentTemplateFlowAssignmentGUID { get; set; }
        public String DocumentTemplateFlowGUID { get; set; }
        public String DocumentTemplateGUID { get; set; }
        public int DocumentPosition { get; set; }

        public void FillData(string _DocumentTemplateFlowAssignmentGUID, string _DocumentTemplateFlowGUID, string _DocumentTemplateGUID, int _DocumentPosition)
        {
            DocumentTemplateFlowAssignmentGUID = _DocumentTemplateFlowAssignmentGUID;
            DocumentTemplateFlowGUID = _DocumentTemplateFlowGUID;
            DocumentTemplateGUID = _DocumentTemplateGUID;
            DocumentPosition = _DocumentPosition;
        }

        public void Save()
        {
            string sql = @"INSERT INTO DocumentTemplateFlowAssignment VALUES( @DocumentTemplateFlowAssignmentGUID, @DocumentTemplateFlowGUID, @DocumentTemplateGUID, @DocumentPosition)";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowAssignmentGUID", DocumentTemplateFlowAssignmentGUID));
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowGUID", DocumentTemplateFlowGUID));
            paramList.Add(new SQLiteParameter("@DocumentTemplateGUID", DocumentTemplateGUID));
            paramList.Add(new SQLiteParameter("@DocumentPosition", DocumentPosition));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            //GlobalVariables.Log("Użytkownik stowrzył szablon: " + DocumentName + "  id: " + DocumentTemplateGUID);

            connector = null;
        }
    }
}
