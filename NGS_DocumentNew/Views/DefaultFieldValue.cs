using NGS_DocumentNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGS_DocumentNew.Views
{
    public partial class DefaultFieldValue : Form
    {
        List<String> fieldList = null;
        Dictionary<String, String> fieldValueList = new Dictionary<string, string>();

        public DefaultFieldValue()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - domyślne pola";

            CreateColumns();

            dgvDefaultFields.AllowUserToDeleteRows = false;
            dgvDefaultFields.AllowUserToAddRows = false;
        }

        private void CreateColumns()
        {
            DataGridViewColumn fieldNameCol = new DataGridViewTextBoxColumn();
            fieldNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fieldNameCol.HeaderText = "Nazwa pola";
            fieldNameCol.ReadOnly = true;
            fieldNameCol.Name = "FieldName";

            DataGridViewColumn fieldValueCol = new DataGridViewTextBoxColumn();
            fieldValueCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fieldValueCol.HeaderText = "Wartość pola";
            fieldValueCol.Name = "FieldValue";

            dgvDefaultFields.Columns.Add(fieldNameCol);
            dgvDefaultFields.Columns.Add(fieldValueCol);
        }

        public void LoadFields(DocumentTemplateFlow dtf)
        {
            ListNGSObject list = new ListNGSObject();
            fieldList = list.GetDocumentTemplateFlowFieldList(dtf.DocumentTemplateFlowGUID);

            if (fieldList.Count == 0)
                this.Close();
            else
            {
                foreach (String field in fieldList)
                    dgvDefaultFields.Rows.Add(field, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fieldValueList.Clear();
            foreach (DataGridViewRow r in dgvDefaultFields.Rows)
            {
                fieldValueList.Add(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString());
            }

            this.Close();
        }

        public Dictionary<String, String> GetFieldValueList()
        {
            return fieldValueList;
        }
    }
}
