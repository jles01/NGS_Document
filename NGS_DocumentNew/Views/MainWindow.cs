using NGS_DocumentNew.Database;
using NGS_DocumentNew.License;
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
    public partial class MainWindow : Form
    {
        DziennikLogowView dziennikLogow = null;
        List<DocumentTemplate> documentTemplateList = null;
        List<DocumentTemplateFlow> documentTemplateFlowList = null;
        List<DocumentTemplateFlowAssignment> documentTemplateFlowAssignmentList = null;

        public MainWindow()
        {
            InitializeComponent();

            this.FormClosed += MainWindow_FormClosed;

            this.Text = GlobalVariables.ApplicationName + " - Okno Główne";

            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
        }

        private void LoadTabControlView()
        {
            RDOView rdoView = new RDOView();
            rdoView.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(rdoView);
        }

        private void LoadLicenseKey()
        {
            GlobalSettings gs = new GlobalSettings();

            gs.LoadSettings();
            GlobalVariables.LicenseKey = gs.GetSettingValueOrDefault("LicenseKey", "");
            
        }

        private void LoadTreeDocuments( TreeNode root, List<DocumentTemplateFlow> documentTemplateFlowList)
        {
            foreach (DocumentTemplateFlow documentTemplateFlow in documentTemplateFlowList)
            {
                TreeNode tnDocumentTemplateFlow = new TreeNode(documentTemplateFlow.DocumentTemplateFlowName);
                tnDocumentTemplateFlow.Name = documentTemplateFlow.DocumentTemplateFlowGUID;

                if (documentTemplateFlow.DocumentTemplateFlowType == "S" 
                    ) //Standard approach
                {
                    ContextMenu cm = new ContextMenu();
                    MenuItem mi = new MenuItem("Nowa seria dokumentów");
                    mi.Name = documentTemplateFlow.DocumentTemplateFlowGUID;
                    cm.MenuItems.Add(mi);
                    mi.Click += Mi_Click;
                    tnDocumentTemplateFlow.ContextMenu = cm;
                }
                foreach (DocumentTemplateFlowAssignment dtfa
                    in documentTemplateFlowAssignmentList.Where(t => t.DocumentTemplateFlowGUID == documentTemplateFlow.DocumentTemplateFlowGUID).OrderBy(t => t.DocumentPosition))
                {
                    TreeNode tnDT = new TreeNode(documentTemplateList.Where(t => t.DocumentTemplateGUID == dtfa.DocumentTemplateGUID).First().DocumentName);

                    DocumentTemplate dt = documentTemplateList.Where(t => t.DocumentTemplateGUID == dtfa.DocumentTemplateGUID).First();
                    tnDT.Name = dt.DocumentTemplateGUID;

                    if (!String.IsNullOrEmpty(dt.DocumentHint))
                    {
                        tnDT.ToolTipText = dt.DocumentHint;
                    }

                    ContextMenu cmm = new ContextMenu();
                    MenuItem mii = dt.DocumentType == "L" || dt.DocumentType == "N" ? new MenuItem("Otwórz link") : new MenuItem("Nowy dokument");
                    mii.Name = tnDT.Name;
                    mii.Click += Mii_Click;
                    cmm.MenuItems.Add(mii);
                    tnDT.ContextMenu = cmm;

                    tnDocumentTemplateFlow.Nodes.Add(tnDT);
                }

                root.Nodes.Add(tnDocumentTemplateFlow);
            }
        }

        public void LoadTreeDocuments()
        {
            tVDocuments.Nodes.Clear();

            ListNGSObject list = new ListNGSObject();
            documentTemplateList = list.GetDocumentTemplateList();
            documentTemplateFlowAssignmentList = list.GetDocumentTemplateFlowAssignmentList();
            documentTemplateFlowList = list.GetDocumentTemplateFlowList();

            TreeNode root = new TreeNode("Dokumenty");

            LoadTreeDocuments(root, documentTemplateFlowList.Where(t => t.DocumentTemplateFlowType == "S" || t.DocumentTemplateFlowType == "L").ToList<DocumentTemplateFlow>());

            tVDocuments.ShowNodeToolTips = true;
            tVDocuments.Nodes.Add(root);

            TreeNode rejestrZbiorow = new TreeNode("Rejestr czynności");
            rejestrZbiorow.ContextMenu = GetMenuToRejestrZbiorow();
            tVDocuments.Nodes.Add(rejestrZbiorow);

            TreeNode dziennikLogow = new TreeNode("Dziennik logów");
            dziennikLogow.ContextMenu = GetMenuToDziennikLogow();
            tVDocuments.Nodes.Add(dziennikLogow);

            TreeNode nosnikiDataCare = new TreeNode("Nośniki w DataCare");
            nosnikiDataCare.ContextMenu = GetNosnikiDataCare();
            tVDocuments.Nodes.Add(nosnikiDataCare);

            TreeNode mojeDokumenty = new TreeNode("Moje dokumenty");

            LoadTreeDocuments(mojeDokumenty, documentTemplateFlowList.Where(t => t.DocumentTemplateFlowType == "C").ToList<DocumentTemplateFlow>());

            tVDocuments.Nodes.Add(mojeDokumenty);


            tVDocuments.CollapseAll();
        }

        private ContextMenu GetMenuToDziennikLogow()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi = new MenuItem("Otwórz");
            mi.Click += OpenDziennikLogow;
            cm.MenuItems.Add(mi);

            return cm;
        }

        private ContextMenu GetMenuToRejestrZbiorow()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi = new MenuItem("Otwórz");
            mi.Click += OpenRejestrZbiorow;
            cm.MenuItems.Add(mi);

            return cm;
        }

        private ContextMenu GetNosnikiDataCare()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi = new MenuItem("Otwórz");
            mi.Click += OpenNosnikiDataCare;
            cm.MenuItems.Add(mi);

            return cm;
        }

        private void OpenNosnikiDataCare(object sender, EventArgs e)
        {
            tbControl.SelectedIndex = 1;
            
        }

        private void OpenRejestrZbiorow(object sender, EventArgs e)
        {
            tbControl.SelectedIndex = 2;
        }

        private void OpenDziennikLogow(object sender, EventArgs e)
        {
            tbControl.SelectedIndex = 3;
        }

        private void Mii_Click(object sender, EventArgs e)
        {
            NewDocument(((MenuItem)sender).Name);
        }

        private void CreateDocumentView()
        {
            documentView = new DocumentView();
            documentView.Dock = DockStyle.Fill;
            gbDocument.Controls.Add(documentView);
        }

        private void NewDocument(string documentGUID)
        {
            try
            {
                gbDocument.Visible = true;
                gbSearchDocument.SendToBack();

                if (documentView == null)
                {
                    CreateDocumentView();
                }

                documentView.LoadDocument(documentTemplateList, documentTemplateFlowList, documentTemplateFlowAssignmentList, documentGUID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewDocumentFlow(string documentFlowGUID, int documentPosition = 1)
        {
            DocumentTemplateFlow dtf = documentTemplateFlowList.Where(t => t.DocumentTemplateFlowGUID == documentFlowGUID).First();

            if (dtf != null)
            {
                DefaultFieldValue dfv = new DefaultFieldValue();
                dfv.LoadFields(dtf);
                if( !dfv.IsDisposed )
                dfv.ShowDialog();

                DocumentFlow(documentFlowGUID, dfv.GetFieldValueList(), documentPosition);
            }
        }

        public void DocumentFlow(string documentFlowGUID, Dictionary<String, String> fieldValueList, int documentPosition = 1)
        {
            if (documentView == null)
            {
                CreateDocumentView();
            }

            gbDocument.Visible = true;
            gbSearchDocument.SendToBack();

            DocumentTemplateFlow dtf = documentTemplateFlowList.Where(t => t.DocumentTemplateFlowGUID == documentFlowGUID).First();

            String documentGUID = documentTemplateFlowAssignmentList.Where(t => t.DocumentTemplateFlowGUID == documentFlowGUID && t.DocumentPosition == documentPosition).First().DocumentTemplateGUID;

            documentView.LoadDocument(documentTemplateList, documentTemplateFlowList, documentTemplateFlowAssignmentList, dtf, documentGUID, documentPosition, fieldValueList);
        }

        private void Mi_Click(object sender, EventArgs e)
        {
            NewDocumentFlow(((MenuItem)sender).Name);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SetStatusBarInfo()
        {
            statusBar.Items.Clear();
            ToolStripLabel lbl = new ToolStripLabel();
            lbl.Text = NGSLicense.statusBarInfo();

            if (NGSLicense.isLicenseValid())
                lbl.ForeColor = Color.Green;
            else
                lbl.ForeColor = Color.Red;
            
            statusBar.Items.Add(lbl);
            statusBar.Items.Add("Jesteś zalogowany jako: " + GlobalVariables.CurrentUser.UserName + ", firma: " + GlobalVariables.CurrentCompany.CompanyName);
        }

        private void firmyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyView cv = new CompanyView();
            cv.ShowDialog();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void przypisanieFirmyDoUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignCompanyUser acu = new AssignCompanyUser();
            acu.ShowDialog();
        }

        private void ustawieniaFirmyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsView sv = new SettingsView();
            sv.ShowDialog();
        }

        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersView uv = new UsersView();
            uv.ShowDialog();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InstallTableScript.InsertTemplates();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gbDocument.Visible = false;
        }

        public void EditDocument(Document doc)
        {
            try
            {
                gbDocument.Visible = true;
                gbSearchDocument.SendToBack();

                if (documentView == null)
                {
                    CreateDocumentView();
                }

                documentView.LoadDocument(documentTemplateList, documentTemplateFlowList, documentTemplateFlowAssignmentList, doc);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void licencjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseView lv = new LicenseView();
            lv.ShowDialog();

            SetStatusBarInfo();
        }

        private void aktualizacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateView uv = new UpdateView();
            uv.ShowDialog();
        }

        private void magazynToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagazynView mv = new MagazynView();
            mv.ShowDialog();
        }

        private void documentSearch_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            dziennikLogow = new DziennikLogowView();
            dziennikLogow.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(dziennikLogow);

            dataCareSearch1 = new DataCareSearch();
            dataCareSearch1.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(dataCareSearch1);


            LoadLicenseKey();
            SetStatusBarInfo();
            LoadTreeDocuments();
            LoadTabControlView();
            LoadSearchDocument();
        }

        private void LoadSearchDocument()
        {
            documentSearch.btnSearch.PerformClick();
            documentSearch.OrderByLastCreateDate();
        }

        private void dziennikLogówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DziennikLogow dl = new DziennikLogow();
            dl.ShowDialog();
        }

        private void zaimportujSzablonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drzewoUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drzewkoUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrzewkoSzablonow ds = new DrzewkoSzablonow();
            ds.ShowDialog();
            LoadTreeDocuments();
        }

        private void importujSzablonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateWindow tw = new TemplateWindow();
            tw.ShowDialog();
            LoadTreeDocuments();
        }
    }
}
