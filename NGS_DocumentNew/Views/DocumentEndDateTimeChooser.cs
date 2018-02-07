using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NGS_DocumentNew.Model;

namespace NGS_DocumentNew.Views
{
    public partial class DocumentEndDateTimeChooser : Form
    {
        public Document doc;

        public DocumentEndDateTimeChooser(Document document)
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - Wybierz datę wygaśnięcia dokuemntu";

            if (document.DocumentEndDateTime == null)
                dtpDocumentEndDateTime.Value = DateTime.Now;
            else
                dtpDocumentEndDateTime.Value = document.DocumentEndDateTime.Value;

            doc = document;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            doc.DocumentEndDateTime = dtpDocumentEndDateTime.Value;
            this.Close();
        }
    }
}
