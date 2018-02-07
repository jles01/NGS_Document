namespace NGS_DocumentNew.Views
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drzewkoUżytkownikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importujSzablonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjścieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaFirmyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaFirmyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.użytkownicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przypisanieFirmyDoUżytkownikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazynToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licencjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualizacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.gbDocumentTree = new System.Windows.Forms.GroupBox();
            this.tVDocuments = new System.Windows.Forms.TreeView();
            this.gbSearchDocument = new System.Windows.Forms.GroupBox();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.documentSearch = new NGS_DocumentNew.Views.DocumentSearch();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbDocument = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.gbDocumentTree.SuspendLayout();
            this.gbSearchDocument.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.ustawieniaToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drzewkoUżytkownikaToolStripMenuItem,
            this.importujSzablonToolStripMenuItem,
            this.wyjścieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // drzewkoUżytkownikaToolStripMenuItem
            // 
            this.drzewkoUżytkownikaToolStripMenuItem.Name = "drzewkoUżytkownikaToolStripMenuItem";
            this.drzewkoUżytkownikaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.drzewkoUżytkownikaToolStripMenuItem.Text = "Drzewko użytkownika";
            this.drzewkoUżytkownikaToolStripMenuItem.Click += new System.EventHandler(this.drzewkoUżytkownikaToolStripMenuItem_Click);
            // 
            // importujSzablonToolStripMenuItem
            // 
            this.importujSzablonToolStripMenuItem.Name = "importujSzablonToolStripMenuItem";
            this.importujSzablonToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.importujSzablonToolStripMenuItem.Text = "Importuj Szablon";
            this.importujSzablonToolStripMenuItem.Click += new System.EventHandler(this.importujSzablonToolStripMenuItem_Click);
            // 
            // wyjścieToolStripMenuItem
            // 
            this.wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            this.wyjścieToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.wyjścieToolStripMenuItem.Text = "Wyjście";
            this.wyjścieToolStripMenuItem.Click += new System.EventHandler(this.wyjścieToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustawieniaFirmyToolStripMenuItem,
            this.zmianaFirmyToolStripMenuItem,
            this.użytkownicyToolStripMenuItem,
            this.firmyToolStripMenuItem,
            this.przypisanieFirmyDoUżytkownikaToolStripMenuItem,
            this.magazynToolStripMenuItem});
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // ustawieniaFirmyToolStripMenuItem
            // 
            this.ustawieniaFirmyToolStripMenuItem.Name = "ustawieniaFirmyToolStripMenuItem";
            this.ustawieniaFirmyToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ustawieniaFirmyToolStripMenuItem.Text = "Ustawienia firmy";
            this.ustawieniaFirmyToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaFirmyToolStripMenuItem_Click);
            // 
            // zmianaFirmyToolStripMenuItem
            // 
            this.zmianaFirmyToolStripMenuItem.Name = "zmianaFirmyToolStripMenuItem";
            this.zmianaFirmyToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.zmianaFirmyToolStripMenuItem.Text = "Zmiana firmy";
            // 
            // użytkownicyToolStripMenuItem
            // 
            this.użytkownicyToolStripMenuItem.Name = "użytkownicyToolStripMenuItem";
            this.użytkownicyToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.użytkownicyToolStripMenuItem.Text = "Użytkownicy";
            this.użytkownicyToolStripMenuItem.Click += new System.EventHandler(this.użytkownicyToolStripMenuItem_Click);
            // 
            // firmyToolStripMenuItem
            // 
            this.firmyToolStripMenuItem.Name = "firmyToolStripMenuItem";
            this.firmyToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.firmyToolStripMenuItem.Text = "Firmy";
            this.firmyToolStripMenuItem.Click += new System.EventHandler(this.firmyToolStripMenuItem_Click);
            // 
            // przypisanieFirmyDoUżytkownikaToolStripMenuItem
            // 
            this.przypisanieFirmyDoUżytkownikaToolStripMenuItem.Name = "przypisanieFirmyDoUżytkownikaToolStripMenuItem";
            this.przypisanieFirmyDoUżytkownikaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.przypisanieFirmyDoUżytkownikaToolStripMenuItem.Text = "Przypisanie firmy do użytkownika";
            this.przypisanieFirmyDoUżytkownikaToolStripMenuItem.Click += new System.EventHandler(this.przypisanieFirmyDoUżytkownikaToolStripMenuItem_Click);
            // 
            // magazynToolStripMenuItem
            // 
            this.magazynToolStripMenuItem.Name = "magazynToolStripMenuItem";
            this.magazynToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.magazynToolStripMenuItem.Text = "Nośniki DataCare";
            this.magazynToolStripMenuItem.Click += new System.EventHandler(this.magazynToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licencjaToolStripMenuItem,
            this.aktualizacjaToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            this.pomocToolStripMenuItem.Click += new System.EventHandler(this.pomocToolStripMenuItem_Click);
            // 
            // licencjaToolStripMenuItem
            // 
            this.licencjaToolStripMenuItem.Name = "licencjaToolStripMenuItem";
            this.licencjaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.licencjaToolStripMenuItem.Text = "Licencja";
            this.licencjaToolStripMenuItem.Click += new System.EventHandler(this.licencjaToolStripMenuItem_Click);
            // 
            // aktualizacjaToolStripMenuItem
            // 
            this.aktualizacjaToolStripMenuItem.Name = "aktualizacjaToolStripMenuItem";
            this.aktualizacjaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.aktualizacjaToolStripMenuItem.Text = "Aktualizacja";
            this.aktualizacjaToolStripMenuItem.Click += new System.EventHandler(this.aktualizacjaToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 329);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1092, 22);
            this.statusBar.TabIndex = 1;
            // 
            // gbDocumentTree
            // 
            this.gbDocumentTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDocumentTree.Controls.Add(this.tVDocuments);
            this.gbDocumentTree.Location = new System.Drawing.Point(12, 27);
            this.gbDocumentTree.Name = "gbDocumentTree";
            this.gbDocumentTree.Size = new System.Drawing.Size(438, 299);
            this.gbDocumentTree.TabIndex = 2;
            this.gbDocumentTree.TabStop = false;
            this.gbDocumentTree.Text = "Drzewko dokumentów";
            // 
            // tVDocuments
            // 
            this.tVDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVDocuments.Location = new System.Drawing.Point(3, 16);
            this.tVDocuments.Name = "tVDocuments";
            this.tVDocuments.Size = new System.Drawing.Size(432, 280);
            this.tVDocuments.TabIndex = 0;
            // 
            // gbSearchDocument
            // 
            this.gbSearchDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchDocument.Controls.Add(this.tbControl);
            this.gbSearchDocument.Location = new System.Drawing.Point(453, 27);
            this.gbSearchDocument.Name = "gbSearchDocument";
            this.gbSearchDocument.Size = new System.Drawing.Size(624, 299);
            this.gbSearchDocument.TabIndex = 3;
            this.gbSearchDocument.TabStop = false;
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tabPage1);
            this.tbControl.Controls.Add(this.tabPage2);
            this.tbControl.Controls.Add(this.tabPage3);
            this.tbControl.Controls.Add(this.tabPage4);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(3, 16);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(618, 280);
            this.tbControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.documentSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(610, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Wyszukiwarka dokumentów";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // documentSearch
            // 
            this.documentSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentSearch.Location = new System.Drawing.Point(3, 3);
            this.documentSearch.Name = "documentSearch";
            this.documentSearch.Size = new System.Drawing.Size(604, 248);
            this.documentSearch.TabIndex = 6;
            this.documentSearch.Load += new System.EventHandler(this.documentSearch_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(610, 254);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nośniki w DataCare";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(610, 254);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rejestr czynności";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(610, 254);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dziennik logów";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gbDocument
            // 
            this.gbDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDocument.Location = new System.Drawing.Point(456, 27);
            this.gbDocument.Name = "gbDocument";
            this.gbDocument.Size = new System.Drawing.Size(624, 299);
            this.gbDocument.TabIndex = 4;
            this.gbDocument.TabStop = false;
            this.gbDocument.Text = "Dokument";
            this.gbDocument.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 351);
            this.Controls.Add(this.gbSearchDocument);
            this.Controls.Add(this.gbDocument);
            this.Controls.Add(this.gbDocumentTree);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDocumentTree.ResumeLayout(false);
            this.gbSearchDocument.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjścieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaFirmyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaFirmyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem użytkownicyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firmyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przypisanieFirmyDoUżytkownikaToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbDocumentTree;
        private System.Windows.Forms.GroupBox gbSearchDocument;
        private System.Windows.Forms.TreeView tVDocuments;
        private System.Windows.Forms.GroupBox gbDocument;
        private DocumentView documentView;
        private System.Windows.Forms.ToolStripMenuItem licencjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktualizacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazynToolStripMenuItem;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DocumentSearch documentSearch;
        private DataCareSearch dataCareSearch1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem drzewkoUżytkownikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importujSzablonToolStripMenuItem;
    }
}