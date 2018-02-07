using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGS_DocumentNew.Database;
using NGS_DocumentNew.License;
using NGS_DocumentNew.Model;

namespace NGS_DocumentNew.Views
{
    public partial class DrzewkoSzablonow : Form
    {
        public DrzewkoSzablonow()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            this.Text = GlobalVariables.ApplicationName + " - Kategorie";
            LoadDocumentList();

        }

        private void LoadDocumentList()
        {
            lbCategoryList.Items.Clear();
            ListNGSObject list = new ListNGSObject();
            foreach( DocumentTemplateFlow flow in list.GetDocumentTemplateFlowList().Where(t=>t.DocumentTemplateFlowType=="C"))
            {
                lbCategoryList.Items.Add(flow.DocumentTemplateFlowName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if( !String.IsNullOrEmpty(tbNewCategory.Text))
            {
                ListNGSObject list = new ListNGSObject();
                if (list.GetDocumentTemplateFlowList().Where(t => t.DocumentTemplateFlowType == "C" && t.DocumentTemplateFlowName == tbNewCategory.Text).Count() > 0)
                {
                    MessageBox.Show("Nie można dodac dwóch takich samych kategorii.", "NGSDocument - błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DocumentTemplateFlow dtf = new DocumentTemplateFlow();
                    dtf.DocumentTemplateFlowGUID = GlobalVariables.GetNewGUID();
                    dtf.DocumentTemplateFlowType = "C";
                    dtf.DocumentTemplateFlowName = tbNewCategory.Text;

                    dtf.Save();

                    MessageBox.Show("Kategoria została dodana.", "Infomracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbNewCategory.Text = "";
                    LoadDocumentList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if( lbCategoryList.SelectedIndex > -1 )
            {
                ListNGSObject list = new ListNGSObject();
                foreach (DocumentTemplateFlow flow in list.GetDocumentTemplateFlowList().Where(t => t.DocumentTemplateFlowType == "C" 
                    && t.DocumentTemplateFlowName == lbCategoryList.Items[lbCategoryList.SelectedIndex].ToString()))
                {
                    flow.Delete();
                    MessageBox.Show("Kategoria została usunięta", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDocumentList();
                }
            }
        }
    }
}
