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
    public partial class DataCareSearch : UserControl
    {
        List<Magazyn> listMagazyn = null;

        public DataCareSearch()
        {
            InitializeComponent();

            CreateColumns();
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.MultiSelect = false;

            dgvSearch.MouseClick += DgvDocumentSearch_MouseClick;
            btnSearch.PerformClick();
        }

        private void DgvDocumentSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                /*int currentMouseOverRow = dgvSearch.HitTest(e.X, e.Y).RowIndex;
                dgvSearch.Rows[currentMouseOverRow].Selected = true;
                ContextMenu m = new ContextMenu();
                MenuItem mi = new MenuItem("Edytuj dokument");
                mi.Name = dgvSearch[0, currentMouseOverRow].Value.ToString();
                mi.Click += Mi_Click;
                m.MenuItems.Add(mi);

                m.Show(dgvSearch, new Point(e.X, e.Y));*/
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listMagazyn = new List<Magazyn>();
            Magazyn mag = new Magazyn();
            listMagazyn = mag.GetSearchMagazyn(tbSearch.Text.Trim());

            dgvSearch.Rows.Clear();

            foreach (Magazyn m in listMagazyn)
            {
                dgvSearch.Rows.Add(m.KopertaGUID
                    , m.DataOdbioru
                    , m.DataZwrotu
                    , m.NrKoperty
                    , m.NrPlomby
                    , m.DataKopii
                    , m.KopertaNrPro
                    , m.Przekazal
                    , m.Zwrocil
                    , m.NazwaKlienta
                    , m.NIP
                    , m.KodPocztowy
                    , m.Miasto
                    , m.KonwojentImie + " " + m.KonwojentNazwisko);
            }

        }

        private void CreateColumns()
        {
            DataGridViewColumn KopertaGUID = new DataGridViewTextBoxColumn();
            KopertaGUID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            KopertaGUID.HeaderText = "KopertaGUID";
            KopertaGUID.Visible = false;
            KopertaGUID.Name = "KopertaGUID";

            DataGridViewColumn NrKoperty = new DataGridViewTextBoxColumn();
            NrKoperty.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NrKoperty.HeaderText = "Numer Koperty";
            NrKoperty.Name = "NrKoperty";

            DataGridViewColumn NrPlomby = new DataGridViewTextBoxColumn();
            NrPlomby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NrPlomby.HeaderText = "Numer Plomby";
            NrPlomby.Name = "NrPlomby";

            DataGridViewColumn DataOdbioru = new DataGridViewTextBoxColumn();
            DataOdbioru.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataOdbioru.HeaderText = "Data Odbioru";
            DataOdbioru.Name = "DataOdbioru";

            DataGridViewColumn DataZwrotu = new DataGridViewTextBoxColumn();
            DataZwrotu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataZwrotu.HeaderText = "Data Zwrotu";
            DataZwrotu.Name = "DataZwrotu";

            DataGridViewColumn GodzinaOdbioru = new DataGridViewTextBoxColumn();
            GodzinaOdbioru.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GodzinaOdbioru.HeaderText = "Godzina Odbioru";
            GodzinaOdbioru.Name = "GodzinaOdbioru";

            DataGridViewColumn DataKopii = new DataGridViewTextBoxColumn();
            DataKopii.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataKopii.HeaderText = "Data Kopii";
            DataKopii.Name = "DataKopii";

            DataGridViewColumn KopertaNrProCol = new DataGridViewTextBoxColumn();
            KopertaNrProCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            KopertaNrProCol.HeaderText = "Nr Pro";
            KopertaNrProCol.Name = "KopertaNrPro";

            DataGridViewColumn Przekazal = new DataGridViewTextBoxColumn();
            Przekazal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Przekazal.HeaderText = "Przekazał";
            Przekazal.Name = "Przekazal";

            DataGridViewColumn Zwrocil = new DataGridViewTextBoxColumn();
            Zwrocil.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Zwrocil.HeaderText = "Zwrocił";
            Zwrocil.Name = "Zwrocil";

            DataGridViewColumn NazwaKlienta = new DataGridViewTextBoxColumn();
            NazwaKlienta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NazwaKlienta.HeaderText = "Nazwa Klienta";
            NazwaKlienta.Name = "NazwaKlienta";

            DataGridViewColumn NIP = new DataGridViewTextBoxColumn();
            NIP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NIP.HeaderText = "NIP";
            NIP.Name = "NIP";

            DataGridViewColumn AdresKlienta = new DataGridViewTextBoxColumn();
            AdresKlienta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AdresKlienta.HeaderText = "Adres Klienta";
            AdresKlienta.Name = "AdresKlienta";

            DataGridViewColumn KodPocztowy = new DataGridViewTextBoxColumn();
            KodPocztowy.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            KodPocztowy.HeaderText = "Kod Pocztowy";
            KodPocztowy.Name = "KodPocztowy";

            DataGridViewColumn Miasto = new DataGridViewTextBoxColumn();
            Miasto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Miasto.HeaderText = "Miasto";
            Miasto.Name = "Miasto";

            DataGridViewColumn Konwojent = new DataGridViewTextBoxColumn();
            Konwojent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Konwojent.HeaderText = "Konwojent";
            Konwojent.Name = "Konwojent";

            dgvSearch.Columns.Add(KopertaGUID);
            dgvSearch.Columns.Add(DataOdbioru);
            dgvSearch.Columns.Add(DataZwrotu);
            dgvSearch.Columns.Add(NrKoperty);
            dgvSearch.Columns.Add(NrPlomby);
            dgvSearch.Columns.Add(DataKopii);
            dgvSearch.Columns.Add(KopertaNrProCol);
            dgvSearch.Columns.Add(Przekazal);
            dgvSearch.Columns.Add(Zwrocil);
            dgvSearch.Columns.Add(NazwaKlienta);
            dgvSearch.Columns.Add(NIP);
            dgvSearch.Columns.Add(KodPocztowy);
            dgvSearch.Columns.Add(Miasto);
            dgvSearch.Columns.Add(Konwojent);

        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch.PerformClick();
        }
    }
}
