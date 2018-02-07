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
    public partial class DocumentSearch : UserControl
    {

        List<Document> documentList = null;

        public DocumentSearch()
        {
            InitializeComponent();

            CreateColumns();
            dgvDocumentSearch.AllowUserToAddRows = false;
            dgvDocumentSearch.AllowUserToDeleteRows = false;
            dgvDocumentSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDocumentSearch.MultiSelect = false;

            dgvDocumentSearch.MouseClick += DgvDocumentSearch_MouseClick;
        }

        private void DgvDocumentSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dgvDocumentSearch.HitTest(e.X, e.Y).RowIndex;
                dgvDocumentSearch.Rows[currentMouseOverRow].Selected = true;
                ContextMenu m = new ContextMenu();
                MenuItem mi = new MenuItem("Edytuj dokument");
                mi.Name = dgvDocumentSearch[0, currentMouseOverRow].Value.ToString();
                mi.Click += Mi_Click;
                m.MenuItems.Add(mi);
                
                m.Show(dgvDocumentSearch, new Point(e.X, e.Y));
            }
        }

        private void Mi_Click(object sender, EventArgs e)
        {
            string documentGUID = ((MenuItem)sender).Name;
            Document doc = documentList.Where(t => t.DocumentGUID == documentGUID).First();

            ((MainWindow)this.Parent.Parent.Parent.Parent).EditDocument(doc);
        }

        private void CreateColumns()
        {
            DataGridViewColumn documentGUIDCol = new DataGridViewTextBoxColumn();
            documentGUIDCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            documentGUIDCol.HeaderText = "DocumentGUID";
            documentGUIDCol.Visible = false;
            documentGUIDCol.Name = "DocumentGUID";

            DataGridViewColumn documentNameCol = new DataGridViewTextBoxColumn();
            documentNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            documentNameCol.HeaderText = "Nazwa dokumentu";
            documentNameCol.Name = "DocumentName";

            DataGridViewColumn createdDateTimeCol = new DataGridViewTextBoxColumn();
            createdDateTimeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            createdDateTimeCol.HeaderText = "Data utworzenia";
            createdDateTimeCol.Name = "CreatedDateTime";

            DataGridViewColumn createdByCol = new DataGridViewTextBoxColumn();
            createdByCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            createdByCol.HeaderText = "Utworzona przez";
            createdByCol.Name = "CreatedBy";

            DataGridViewColumn lastModifiedDateTimeCol = new DataGridViewTextBoxColumn();
            lastModifiedDateTimeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lastModifiedDateTimeCol.HeaderText = "Data modyfikacji";
            lastModifiedDateTimeCol.Name = "LastModifiedDateTime";

            DataGridViewColumn lastModifiedBy = new DataGridViewTextBoxColumn();
            lastModifiedBy.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lastModifiedBy.HeaderText = "Zmodyfikowana przez";
            lastModifiedBy.Name = "LastModifiedBy";

            DataGridViewColumn printedDateTimeCol = new DataGridViewTextBoxColumn();
            printedDateTimeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            printedDateTimeCol.HeaderText = "Data wydruku";
            printedDateTimeCol.Name = "PrintedDateTimeCol";

            DataGridViewColumn typeOfDocument = new DataGridViewTextBoxColumn();
            typeOfDocument.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            typeOfDocument.HeaderText = "Typ dokumentu";
            typeOfDocument.Visible = false;
            typeOfDocument.Name = "DocumentType";

            dgvDocumentSearch.Columns.Add(documentGUIDCol);
            dgvDocumentSearch.Columns.Add(documentNameCol);
            dgvDocumentSearch.Columns.Add(createdDateTimeCol);
            dgvDocumentSearch.Columns.Add(createdByCol);
            dgvDocumentSearch.Columns.Add(lastModifiedDateTimeCol);
            dgvDocumentSearch.Columns.Add(lastModifiedBy);
            dgvDocumentSearch.Columns.Add(printedDateTimeCol);
            dgvDocumentSearch.Columns.Add(typeOfDocument);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ListNGSObject list = new ListNGSObject();
            documentList = list.GetDocumentListBySearchPhrase(tbDocumentSearch.Text);

            List<User> userList = list.GetListOfUsers();

            dgvDocumentSearch.Rows.Clear();

            foreach(Document d in documentList)
            {
                if (d is Document)
                {
                    dgvDocumentSearch.Rows.Add(((Document)d).DocumentGUID
                                            , d.DocumentName
                                            , d.CreatedDateTime
                                            , GetUserName(userList, d.CreatedBy)
                                            , ((Document)d).LastModifiedDateTime
                                            , GetUserName(userList, ((Document)d).LastModifiedBy)
                                            , ((Document)d).PrintedDateTime);
                }
            }
            
        }

        private String GetUserName(List<User> userList, String userGUID)
        {
            return userList.Where(t => t.UserGUID == userGUID).First().UserName;
        }

        private void DocumentSearch_Load(object sender, EventArgs e)
        {

        }

        public void OrderByLastCreateDate()
        {
            dgvDocumentSearch.Sort(dgvDocumentSearch.Columns[2], ListSortDirection.Descending);
        }

        private void tbDocumentSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) btnSearch.PerformClick();
        }
    }
}
