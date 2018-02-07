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
    public partial class TemplateImportView : UserControl
    {

        Dictionary<String, FieldBeforeAfter> listOfFields = new Dictionary<string, FieldBeforeAfter>();

        class FieldBeforeAfter
        {
            public String FieldName { get; set; }
            public String Before { get; set; }
            public String After { get; set; }
        }

        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

        public TemplateImportView()
        {
            InitializeComponent();

            LoadCategoryList();
        }

        private void LoadCategoryList()
        {
            cbCategory.Items.Clear();
            ListNGSObject list = new ListNGSObject();
            foreach (DocumentTemplateFlow flow in list.GetDocumentTemplateFlowList().Where(t => t.DocumentTemplateFlowType == "C"))
            {
                cbCategory.Items.Add(flow.DocumentTemplateFlowName);
            }
        }

        private void addToList( Dictionary<String, FieldBeforeAfter> list, string fieldName, string before, string after)
        {
            if( list.ContainsKey(fieldName))
            {
                if (before != null)
                    list[fieldName].Before = before;
                if (after != null)
                    list[fieldName].After = after;
            }
            else
            {
                FieldBeforeAfter fba = new FieldBeforeAfter();
                fba.FieldName = fieldName;
                if (before != null)
                    fba.Before = before;
                if (after != null)
                    fba.After = after;

                list.Add(fieldName, fba);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(cbCategory.Text))
            {
                MessageBox.Show("Musisz wybrać kategorię do której ma być przypisany szablon!", "Błąd - import szablonów", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(tbNazwaSzablonu.Text))
            {
                MessageBox.Show("Musisz podać nazwę szablonu!", "Błąd - import szablonów", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if( !String.IsNullOrEmpty(tbTemplatePath.Text) && !String.IsNullOrEmpty(cbCategory.Text) )
            {
                listOfFields = new Dictionary<string, FieldBeforeAfter>();
                System.IO.StreamReader stream = new System.IO.StreamReader(tbTemplatePath.Text, Encoding.GetEncoding("Windows-1250"));
                htmlDoc.Load(stream);

                string body = htmlDoc.DocumentNode.SelectNodes("//body")[0].InnerText.Replace(Environment.NewLine, " ").Replace("  ", " ");

                string before = "";
                string after = "";
                string fieldName = "";
                for( int i = 0; i < body.Length; i++)
                {
                    if( body[i] == '{' && i + 1 < body.Length && body[i+1] == '#' )
                    {

                        if (fieldName != "")
                            addToList(listOfFields, fieldName, null, after);

                        fieldName = "";
                        after = "";
                        for( int j = i + 2; j < body.Length; j++ )
                        {
                            if (body[j] == '#' && j + 1 < body.Length && body[j+1] == '}')
                            {
                                addToList(listOfFields, fieldName, before, null);
                                i = j + 1;
                                before = "";
                                break;
                            }
                            else 
                                fieldName += body[j];
                        }  

                    }
                    else
                    {
                        before += body[i];
                        if (fieldName != "")
                            after += body[i];
                    }
                }
                if (fieldName != "")
                    addToList(listOfFields, fieldName, null, after);

                //label3.Text = "Znaleziona " + listOfFields.Count + " pola w szablone.";
                stream.Close();

                if (cbValidEndDate.Checked == true) {
                    bool dateFiledExists = false;
                    foreach (FieldBeforeAfter fba in listOfFields.Values)
                    {
                        if(fba.FieldName == "DataWygasniecia" )
                        {
                            dateFiledExists = true;
                        }
                    }

                    if(!dateFiledExists)
                    {
                        MessageBox.Show("Pole {#DataWygasniecia#} nie występuje w szablonie. Proszę odznacz ważność dokumentu lub dodaj do szablonu wymagane pole.", "Import szablonu błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //IMPORT
                stream = new System.IO.StreamReader(tbTemplatePath.Text, Encoding.GetEncoding("Windows-1250"));
                string newBody = stream.ReadToEnd();
                foreach (FieldBeforeAfter fba in listOfFields.Values)
                {
                    newBody = newBody.Replace("{#" + fba.FieldName + "#}", "<ngs_input name='" + fba.FieldName + "' caption='" + fba.FieldName + "' style=\"background-color: #FFFF00;\">.......</ngs_input>");
                }

                newBody = newBody.Replace("<head>", "<head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\" />");

                DocumentTemplate dt = new DocumentTemplate();
                dt.DocumentHint = "";
                dt.DocumentName = tbNazwaSzablonu.Text;
                dt.DocumentTemplateGUID = GlobalVariables.GetNewGUID();
                dt.DocumentText = newBody;
                dt.DocumentType = "D";
                dt.DocumentEndDate = cbValidEndDate.Checked ? "Y" : "N";
                dt.Save();
                stream.Close();

                ListNGSObject list = new ListNGSObject();



                DocumentTemplateFlowAssignment dtfa = new DocumentTemplateFlowAssignment();
                dtfa.DocumentPosition = 1;
                dtfa.DocumentTemplateFlowAssignmentGUID = GlobalVariables.GetNewGUID();
                dtfa.DocumentTemplateGUID = dt.DocumentTemplateGUID;
                dtfa.DocumentTemplateFlowGUID = list.GetDocumentTemplateFlowList().Where(t => t.DocumentTemplateFlowType == "C" && t.DocumentTemplateFlowName == cbCategory.Text).First().DocumentTemplateFlowGUID;

                dtfa.Save();

                MessageBox.Show("Szablon został zaimportowany", "Informacja - szablon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //((MainWindow)(this.Parent.Parent)).LoadTreeDocuments();
            }
        }

        /*private void btnImportFile_Click(object sender, EventArgs e)
        {
            if (listOfFields.Count == 0)
            {

            }
            else
            {
                if (!String.IsNullOrEmpty(tbFileName.Text))
                {
                    System.IO.StreamReader stream = new System.IO.StreamReader(tbFileName.Text, Encoding.GetEncoding("Windows-1250"));

                    htmlDoc.Load(stream);

                    string body = htmlDoc.DocumentNode.SelectNodes("//body")[0].InnerText.Replace(Environment.NewLine, " ").Replace("  ", " ");

                    Document cd = new Document();
                    cd.CompanyGUID = GlobalVariables.CurrentCompany.CompanyGUID;
                    cd.CreatedBy = GlobalVariables.CurrentUser.UserGUID;
                    cd.CreatedDateTime = DateTime.Now;
                    cd.DocumentGUID = GlobalVariables.GetNewGUID();
                    cd.DocumentText = htmlDoc.DocumentNode.InnerHtml;
                    cd.DocumentName = tbFileName.Text.Split('\\')[tbFileName.Text.Split('\\').Length - 1];
                    cd.LastModifiedDateTime = DateTime.Now;
                    cd.LastModifiedBy = GlobalVariables.CurrentUser.UserGUID;
                    cd.PrintedDateTime = DateTime.Now;

                    foreach (FieldBeforeAfter fba in listOfFields.Values)
                    {
                        string value = body.Substring(
                            body.IndexOf(fba.Before) + fba.Before.Length,
                            body.IndexOf(fba.After) - (body.IndexOf(fba.Before) + fba.Before.Length)
                            );

                        DocumentField df = new DocumentField();
                        df.CompanyGUID = GlobalVariables.CurrentCompany.CompanyGUID;
                        df.DocumentGUID = cd.DocumentGUID;
                        df.FieldName = fba.FieldName;
                        df.FieldValue = value;

                        df.Save();
                    }

                    cd.Save();
                    MessageBox.Show("Dokument został zaimportowany", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }*/

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            
            if( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                tbTemplatePath.Text = openFileDialog.FileName;
            }
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
            }
        }*/
    }
}
