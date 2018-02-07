using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class DocumentTemplateFlowField
    {
        public String DocumentTemplateFlowGUID { get; set; }
        public String FieldName { get; set; }

        public void FillData( String _DocumentTemplateFlowGUID, String _FieldName)
        {
            DocumentTemplateFlowGUID = _DocumentTemplateFlowGUID;
            FieldName = _FieldName;
        }

    }
}
