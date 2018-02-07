using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGS_DocumentNew.Model;

namespace NGS_DocumentNew.Views
{
    public partial class DocumentView : UserControl
    {
        List<DocumentTemplate> documentTemplateList = null;
        List<DocumentTemplateFlow> documentTemplateFlowList = null;
        List<DocumentTemplateFlowAssignment> documentTemplateFlowAssignmentList = null;
        Dictionary<string, string> documentFields = new Dictionary<string, string>();
        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
        String CurrentDocumentGUID { get; set; }
        String CurrentDocumentTemplateGUID { get; set; }
        DocumentTemplateFlow CurrentDocumentTemplateFlow { get; set; }
        Document CurrentDocument { get; set; }
        Dictionary<String, String> fieldValueList = new Dictionary<string, string>();
        int DocumentPosition { get; set; }
        bool DocumentSaved = false;

        public DocumentView()
        {
            InitializeComponent();

            webBrowser.IsWebBrowserContextMenuEnabled = false;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;

            if( !License.NGSLicense.isLicenseValid() )
            {
                btnPrint.Enabled = false;
                btnNext.Enabled = false;
            }

        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser.Document.Body.MouseDown += Body_MouseDown; ;
            this.webBrowser.Document.Body.KeyDown += Body_KeyDown; ;
        }

        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            
        }

        private void Body_MouseDown(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                HtmlElement element = this.webBrowser.Document.GetElementFromPoint(e.ClientMousePosition);
                if (FieldInDocumentFields(element.TagName, element.GetAttribute("name")))
                {
                    ShowEditField(element, e.ClientMousePosition);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;
            CurrentDocument = null;
        }

        public void LoadDocument(List<DocumentTemplate> _documentTemplateList, 
            List<DocumentTemplateFlow> _documentTemplateFlowList, 
            List<DocumentTemplateFlowAssignment> _documentTemplateFlowAssignmentList, 
            string documentGUID
            )
        {
            try
            {
                CurrentDocumentTemplateGUID = documentGUID;
                CurrentDocumentGUID = GlobalVariables.GetNewGUID();
                documentTemplateList = _documentTemplateList;
                documentTemplateFlowList = _documentTemplateFlowList;
                documentTemplateFlowAssignmentList = _documentTemplateFlowAssignmentList;

                DocumentTemplate dt = documentTemplateList.Where(t => t.DocumentTemplateGUID == documentGUID).First();

                if (dt.DocumentType == "L")
                    webBrowser.Navigate(dt.DocumentText);
                else if( dt.DocumentType == "N" )
                {
                    htmlDoc.LoadHtml(dt.DocumentText);
                    LoadDictionaryWithInputFields();
                    LoadDocumentDefaultFieldValues();

                    webBrowser.DocumentText = htmlDoc.DocumentNode.OuterHtml.Replace("<head>", "<head><style>body { height:297mm; width:210mm; margin-left:auto; margin-right:auto; }</style>");

                }
                else
                {
                    htmlDoc.LoadHtml(dt.DocumentText);
                    LoadDictionaryWithInputFields();
                    LoadDocumentDefaultFieldValues();

                    webBrowser.DocumentText = htmlDoc.DocumentNode.OuterHtml.Replace("<head>", "<head><style>body { height:297mm; width:210mm; margin-left:auto; margin-right:auto; }</style>");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadDocument(List<DocumentTemplate> _documentTemplateList, 
            List<DocumentTemplateFlow> _documentTemplateFlowList, 
            List<DocumentTemplateFlowAssignment> _documentTemplateFlowAssignmentList,
            DocumentTemplateFlow dfv,
            String documentGUID, 
            int documentPosition,
            Dictionary<string, string> _fieldValueList)
        {
            fieldValueList = _fieldValueList;
            DocumentPosition = documentPosition;
            CurrentDocumentTemplateFlow = dfv;
            CurrentDocumentTemplateGUID = documentGUID;
            CurrentDocumentGUID = GlobalVariables.GetNewGUID();
            documentTemplateList = _documentTemplateList;
            documentTemplateFlowList = _documentTemplateFlowList;
            documentTemplateFlowAssignmentList = _documentTemplateFlowAssignmentList;

            htmlDoc.LoadHtml(documentTemplateList.Where(t => t.DocumentTemplateGUID == documentGUID).First().DocumentText);
            LoadDictionaryWithInputFields();
            LoadDocumentDefaultFieldValues();

            webBrowser.DocumentText = htmlDoc.DocumentNode.OuterHtml.Replace("<head>", "<head><style>body { height:297mm; width:210mm; margin-left:auto; margin-right:auto; }</style>");

            btnNext.Visible = true;
        }

        public void LoadDocument(List<DocumentTemplate> _documentTemplateList,
            List<DocumentTemplateFlow> _documentTemplateFlowList,
            List<DocumentTemplateFlowAssignment> _documentTemplateFlowAssignmentList,
            Document doc
            )
        {
            try
            {
                CurrentDocumentGUID = doc.DocumentGUID;
                CurrentDocument = doc;
                documentTemplateList = _documentTemplateList;
                documentTemplateFlowList = _documentTemplateFlowList;
                documentTemplateFlowAssignmentList = _documentTemplateFlowAssignmentList;

                htmlDoc.LoadHtml(doc.DocumentText.Replace("<head>", "<head><style>body { height:297mm; width:210mm; margin-left:auto; margin-right:auto; }</style>"));
                LoadDictionaryWithInputFields();
                LoadDocumentDefaultFieldValues();

                webBrowser.DocumentText = htmlDoc.DocumentNode.OuterHtml;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void LoadDictionaryWithInputFields()
        {
            documentFields.Clear();
            if(htmlDoc.DocumentNode.SelectNodes("//ngs_input") != null && htmlDoc.DocumentNode.SelectNodes("//ngs_input").Count > 0)
                foreach (HtmlAgilityPack.HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//ngs_input"))
                {
                    documentFields.Add(node.GetAttributeValue("name", ""), node.InnerText);
                }
        }

        private void LoadDocumentDefaultFieldValues()
        {
            if(htmlDoc.DocumentNode.SelectNodes("//ngs_input") != null && htmlDoc.DocumentNode.SelectNodes("//ngs_input").Count > 0 )
            foreach (HtmlAgilityPack.HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//ngs_input"))
            {
                if (FieldInDocumentFields(node.Name, node.GetAttributeValue("name", "")))
                {
                    string str = "";

                    if (CurrentDocument != null)
                    {
                        str = CurrentDocument.GetFieldValue(node.GetAttributeValue("name", ""));
                    }
                    else
                        str = GetFieldValueFromFieldValueList(node.GetAttributeValue("name", ""));

                    if (!String.IsNullOrEmpty(str))
                    {
                        node.InnerHtml = str;
                    }
                    else
                    {
                        str = GlobalVariables.CurrentCompanySettings.GetSettingValueOrDefault(node.GetAttributeValue("name", ""), "");
                        if (!String.IsNullOrEmpty(str))
                            node.InnerHtml = str;
                    }
                }
            }
        }

        private String GetFieldValueFromFieldValueList( String fieldName )
        {
            if (fieldValueList.ContainsKey(fieldName))
                return fieldValueList[fieldName];
            else
                return "";
        }

        private bool FieldInDocumentFields(string tagName, string fieldName)
        {
            if (tagName.ToLower().Trim() == "ngs_input")
                return documentFields.ContainsKey(fieldName);
            else
                return false;
        }

        private void ShowEditField(HtmlElement element, Point p)
        {
            EditForm ef = new EditForm(element.InnerText, element.GetAttribute("caption"));
            
            ef.ShowDialog();
            ChangeInnerTextInElement(element, ef.GetValue());

            if (ef.GetTab())
            {
                //IncrementTab();
            }
        }

        private void ChangeInnerTextInElement(HtmlElement element, string txt)
        {
            if (String.IsNullOrEmpty(txt))
                element.InnerText = "   ";
            else
                element.InnerText = txt;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == (Keys.Control | Keys.C)) || (keyData == (Keys.Control | Keys.V)) || keyData == Keys.ControlKey
                || (keyData == (Keys.ControlKey | Keys.C)) || (keyData == (Keys.ControlKey | Keys.V) || keyData == Keys.Control)
                )
            {
                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.webBrowser.ShowPrintDialog();

            SaveDocument();
        }

        private void UpdateDocumentFieldsList()
        {
            for (int i = 0; i < this.webBrowser.Document.GetElementsByTagName("ngs_input").Count; i++)
            {
                HtmlElement element = this.webBrowser.Document.GetElementsByTagName("ngs_input")[i];

                if (documentFields.ContainsKey(element.GetAttribute("name")))
                {
                    Console.WriteLine(element.GetAttribute("name") + " " + element.InnerText);
                    documentFields[element.GetAttribute("name")] = element.InnerText;
                }
            }
        }

        private void SaveDocument()
        {
            UpdateDocumentFieldsList();
            foreach (KeyValuePair<String,String> keyPair in documentFields)
            {
                DocumentField df = new DocumentField();
                df.FillData(GlobalVariables.CurrentCompany.CompanyGUID, CurrentDocumentGUID, keyPair.Key, keyPair.Value);
                df.Delete();
                df.Save();
            }

            if (CurrentDocument == null)
            {

                DocumentTemplate dt = documentTemplateList.Where(t => t.DocumentTemplateGUID == CurrentDocumentTemplateGUID).First();
                CurrentDocument = new Document();

                /*if (dt.DocumentEndDate == "Y")
                {
                    DocumentEndDateTimeChooser dedt = new DocumentEndDateTimeChooser(CurrentDocument);
                    dedt.ShowDialog();
                }*/
                if(fieldValueList.ContainsKey("DataWygasniecia"))
                {
                    foreach( KeyValuePair<String, String> keyVal in fieldValueList)
                    {
                        if(keyVal.Key == "DataWygasniecia" && keyVal.Value != null )
                        {
                            try
                            {
                                CurrentDocument.DocumentEndDateTime = DateTime.Parse(keyVal.Value);
                            }
                            catch { }
                        }  

                    }
                    //CurrentDocument.DocumentEndDateTime = if(fieldValueList.TryGetValue("DataWygasniecia")
                }

                CurrentDocument.FillData(GlobalVariables.CurrentCompany.CompanyGUID
                        , CurrentDocumentGUID
                        , dt.DocumentName
                        , dt.DocumentText
                        , DateTime.Now
                        , GlobalVariables.CurrentUser.UserGUID
                        , DateTime.Now
                        , GlobalVariables.CurrentUser.UserGUID
                        , DateTime.Now
                        , CurrentDocument.DocumentEndDateTime);

                CurrentDocument.Save();
            }
            else
            {
                if (CurrentDocument is Document)
                {
                    DocumentTemplate dt = documentTemplateList.Where(t => t.DocumentTemplateGUID == CurrentDocumentTemplateGUID).First();
                    if (dt.DocumentEndDate == "Y")
                    {
                        DocumentEndDateTimeChooser dedt = new DocumentEndDateTimeChooser(CurrentDocument);
                        dedt.ShowDialog();
                    }

                    ((Document)CurrentDocument).LastModifiedBy = GlobalVariables.CurrentUser.UserGUID;
                    ((Document)CurrentDocument).LastModifiedDateTime = DateTime.Now;

                    CurrentDocument.Update();
                }
            }
            DocumentSaved = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (documentTemplateFlowAssignmentList.Where(t => t.DocumentPosition > DocumentPosition && t.DocumentTemplateFlowGUID == CurrentDocumentTemplateFlow.DocumentTemplateFlowGUID).Count() > 0)
            {
                if( !DocumentSaved)
                {
                    DialogResult dr = MessageBox.Show("Dokument nie jest zapisany. Czy chciałbyś zapisać dokument ?", "Dokument - zapis", MessageBoxButtons.YesNo);
                    if( dr == DialogResult.Yes)
                        SaveDocument();
 
                }
                
                int nextDocumentPosition = documentTemplateFlowAssignmentList.Where(t => t.DocumentPosition > DocumentPosition && t.DocumentTemplateFlowGUID == CurrentDocumentTemplateFlow.DocumentTemplateFlowGUID).OrderBy(t => t.DocumentPosition).First().DocumentPosition;
                CurrentDocument = null;
                ((MainWindow)this.Parent.Parent).DocumentFlow(CurrentDocumentTemplateFlow.DocumentTemplateFlowGUID, fieldValueList, nextDocumentPosition);
            }
            else
            {
                btnClose.PerformClick();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadDocument(documentTemplateList, documentTemplateFlowList, documentTemplateFlowAssignmentList, CurrentDocumentTemplateGUID);
        }
    }
}
