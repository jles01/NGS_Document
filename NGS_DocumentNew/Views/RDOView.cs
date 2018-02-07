using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGS_DocumentNew.Views
{
    public partial class RDOView : UserControl
    {
        private List<NGS_DocumentNew.Model.RejestrCzynnosci> rejestrCzynnosciList = new List<NGS_DocumentNew.Model.RejestrCzynnosci>();

        public RDOView()
        {
            InitializeComponent();

            InitResultSet();

            dgvResult.MouseClick += DgvResult_MouseClick;
            dgvResult.ReadOnly = true;

            cbTypRejestru.Text = "AKTYWNA";
        }

        private void DgvResult_MouseClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Right )
            {
                int currentMouseOverRow = dgvResult.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    String guid = dgvResult[0, currentMouseOverRow].Value.ToString();
                    NGS_DocumentNew.Model.RejestrCzynnosci rc = rejestrCzynnosciList.Where(t => t.RejestrCzynnosciGUID == guid).First();

                    ContextMenu m = new ContextMenu();

                    if (NGS_DocumentNew.License.NGSLicense.isLicenseValid())
                    {

                        if (rc.TypRejestruCzynnosci == "AKTYWNA")
                        {
                            MenuItem mie = new MenuItem("Edytuj");
                            mie.Click += Mie_Click;
                            mie.Tag = currentMouseOverRow.ToString();
                            m.MenuItems.Add(mie);

                            MenuItem mm = new MenuItem("Dezaktywuj");
                            mm.Click += Dez_Click;
                            mm.Tag = currentMouseOverRow.ToString();
                            m.MenuItems.Add(mm);
                        }
                        else if (rc.TypRejestruCzynnosci == "NIEAKTYWNA")
                        {
                            MenuItem mie = new MenuItem("Aktywuj");
                            mie.Click += Akt_Click;
                            mie.Tag = currentMouseOverRow.ToString();
                            m.MenuItems.Add(mie);
                        }

                    }
                    m.Show(dgvResult, new Point(e.X, e.Y));
                }
            }
        }

        private void Akt_Click(object sender, EventArgs e)
        {
            MenuItem mie = (MenuItem)sender;
            String guid = dgvResult[0, Int32.Parse(mie.Tag.ToString())].Value.ToString();
            NGS_DocumentNew.Model.RejestrCzynnosci rc = rejestrCzynnosciList.Where(t => t.RejestrCzynnosciGUID == guid).First();

            rc.TypRejestruCzynnosci = "AKTYWNA";
            rc.LastModifiedBy = NGS_DocumentNew.Model.GlobalVariables.CurrentUser.UserGUID;
            rc.LastModifiedDateTime = DateTime.Now;

            rc.Update();
            Search();
        }

        private void Dez_Click(object sender, EventArgs e)
        {
            MenuItem mie = (MenuItem)sender;
            String guid = dgvResult[0, Int32.Parse(mie.Tag.ToString())].Value.ToString();
            NGS_DocumentNew.Model.RejestrCzynnosci rc = rejestrCzynnosciList.Where(t => t.RejestrCzynnosciGUID == guid).First();

            rc.TypRejestruCzynnosci = "NIEAKTYWNA";
            rc.LastModifiedBy = NGS_DocumentNew.Model.GlobalVariables.CurrentUser.UserGUID;
            rc.LastModifiedDateTime = DateTime.Now;

            rc.Update();
            Search();
        }

        private void Mie_Click(object sender, EventArgs e)
        {
            MenuItem mie = (MenuItem)sender;
            String guid = dgvResult[0, Int32.Parse(mie.Tag.ToString())].Value.ToString();
            NGS_DocumentNew.Model.RejestrCzynnosci rc = rejestrCzynnosciList.Where(t => t.RejestrCzynnosciGUID == guid).First();

            if (rc.TypRejestruCzynnosci != "AKTYWNA")
            {
                MessageBox.Show("Tylko aktywny rejstr można edytować !", "Błąd edycji rejestru", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RejestrCzynnosciView rcv = new RejestrCzynnosciView(rc);
                rcv.ShowDialog();
            }
        }

        private void InitResultSet()
        {
            DataGridViewColumn RejestrCzynnosciGUID = new DataGridViewTextBoxColumn();
            RejestrCzynnosciGUID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RejestrCzynnosciGUID.Visible = false;
            RejestrCzynnosciGUID.HeaderText = "GUID";
            RejestrCzynnosciGUID.Name = "GUID";

            DataGridViewColumn DataUtworzeniaRejestru = new DataGridViewTextBoxColumn();
            DataUtworzeniaRejestru.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataUtworzeniaRejestru.Visible = true;
            DataUtworzeniaRejestru.HeaderText = "Data utworzenia rejestru";
            DataUtworzeniaRejestru.Name = "Data utworzenia rejestru";

            DataGridViewColumn NazwaAdministratoraDanych = new DataGridViewTextBoxColumn();
            NazwaAdministratoraDanych.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NazwaAdministratoraDanych.HeaderText = @"Nazwa administratora danych lub podmiotu przetwarzającego / przedstawiciela administratora lub podmiotu przetwarzającego";
            NazwaAdministratoraDanych.Name = @"Nazwa administratora danych lub podmiotu przetwarzającego / przedstawiciela administratora lub podmiotu przetwarzającego";

            DataGridViewColumn WspolAdministratorzy = new DataGridViewTextBoxColumn();
            WspolAdministratorzy.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            WspolAdministratorzy.HeaderText = "Współadministratorzy";
            WspolAdministratorzy.Name = "Współadministratorzy";

            DataGridViewColumn InsepktorDanychOsobowych = new DataGridViewTextBoxColumn();
            InsepktorDanychOsobowych.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InsepktorDanychOsobowych.HeaderText = "Inspektor ochrony danych osobowych";
            InsepktorDanychOsobowych.Name = "Inspektor ochrony danych osobowych";

            DataGridViewColumn NazwaZbioruDanych = new DataGridViewTextBoxColumn();
            NazwaZbioruDanych.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NazwaZbioruDanych.HeaderText = "Nazwa zbioru danych";
            NazwaZbioruDanych.Name = "Nazwa zbioru danych";

            DataGridViewColumn RodzajCzynnosci = new DataGridViewTextBoxColumn();
            RodzajCzynnosci.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RodzajCzynnosci.HeaderText = "Rodzaj czynności";
            RodzajCzynnosci.Name = "Rodzaj czynności";

            DataGridViewColumn TytulCzynnosci = new DataGridViewTextBoxColumn();
            TytulCzynnosci.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TytulCzynnosci.HeaderText = "Tytuł czynności";
            TytulCzynnosci.Name = "Tytuł czynności";

            DataGridViewColumn CelPrzetwarzania = new DataGridViewTextBoxColumn();
            CelPrzetwarzania.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CelPrzetwarzania.HeaderText = "Cel przetwarzania";
            CelPrzetwarzania.Name = "Cel przetwarzania";

            DataGridViewColumn OpisKategoriiOsob = new DataGridViewTextBoxColumn();
            OpisKategoriiOsob.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OpisKategoriiOsob.HeaderText = "Opis kategorii osób";
            OpisKategoriiOsob.Name = "Opis kategorii osób";

            DataGridViewColumn KategorieOdbiorcow = new DataGridViewTextBoxColumn();
            KategorieOdbiorcow.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            KategorieOdbiorcow.HeaderText = "Kategorie odbiorców";
            KategorieOdbiorcow.Name = "Kategorie odbiorców";

            DataGridViewColumn KategorieDanychOsobowych = new DataGridViewTextBoxColumn();
            KategorieDanychOsobowych.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            KategorieDanychOsobowych.HeaderText = "Kategorie danych osobowych";
            KategorieDanychOsobowych.Name = "Kategorie danych osobowych";

            DataGridViewColumn InformarcjeOPrzekazaniuDoPanstwaTrzeciego = new DataGridViewTextBoxColumn();
            InformarcjeOPrzekazaniuDoPanstwaTrzeciego.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InformarcjeOPrzekazaniuDoPanstwaTrzeciego.HeaderText = "Informacje o przekazaniu do państwa trzeciego lub organizacji międzynarodowej";
            InformarcjeOPrzekazaniuDoPanstwaTrzeciego.Name = "Informacje o przekazaniu do państwa trzeciego lub organizacji międzynarodowej";

            DataGridViewColumn PlanowanyTerminUsuniecia = new DataGridViewTextBoxColumn();
            PlanowanyTerminUsuniecia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PlanowanyTerminUsuniecia.HeaderText = "Planowany termin usunięcia danych osobowych";
            PlanowanyTerminUsuniecia.Name = "Planowany termin usunięcia danych osobowych";

            DataGridViewColumn OpisTechniczny = new DataGridViewTextBoxColumn();
            OpisTechniczny.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OpisTechniczny.HeaderText = "Opis technicznych i organizacyjnych środków bezpieczeństwa";
            OpisTechniczny.Name = "Opis technicznych i organizacyjnych środków bezpieczeństwa";

            DataGridViewColumn Uwagi = new DataGridViewTextBoxColumn();
            Uwagi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Uwagi.HeaderText = "Uwagi";
            Uwagi.Name = "Uwagi";

            DataGridViewColumn TypRejestruCzynnosci = new DataGridViewTextBoxColumn();
            TypRejestruCzynnosci.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TypRejestruCzynnosci.HeaderText = "Typ rejestru";
            TypRejestruCzynnosci.Name = "TypRejestru";

            dgvResult.Columns.Add(RejestrCzynnosciGUID);
            dgvResult.Columns.Add(DataUtworzeniaRejestru);
            dgvResult.Columns.Add(NazwaAdministratoraDanych);
            dgvResult.Columns.Add(WspolAdministratorzy);
            dgvResult.Columns.Add(InsepktorDanychOsobowych);
            dgvResult.Columns.Add(NazwaZbioruDanych);
            dgvResult.Columns.Add(RodzajCzynnosci);
            dgvResult.Columns.Add(TytulCzynnosci);
            dgvResult.Columns.Add(CelPrzetwarzania);
            dgvResult.Columns.Add(OpisKategoriiOsob);
            dgvResult.Columns.Add(KategorieOdbiorcow);
            dgvResult.Columns.Add(KategorieDanychOsobowych);
            dgvResult.Columns.Add(InformarcjeOPrzekazaniuDoPanstwaTrzeciego);
            dgvResult.Columns.Add(PlanowanyTerminUsuniecia);
            dgvResult.Columns.Add(OpisTechniczny);
            dgvResult.Columns.Add(Uwagi);
            dgvResult.Columns.Add(TypRejestruCzynnosci);
        }

        private void Search()
        {
            dgvResult.Rows.Clear();

            NGS_DocumentNew.Model.ListNGSObject list = new NGS_DocumentNew.Model.ListNGSObject();

            rejestrCzynnosciList = list.GetRejestrCzynnosciList(tbSearch.Text);

            foreach (NGS_DocumentNew.Model.RejestrCzynnosci rc in rejestrCzynnosciList)
                if( ( cbTypRejestru.Text == "AKTYWNA" && rc.TypRejestruCzynnosci == "AKTYWNA") ||
                    ( cbTypRejestru.Text == "NIEAKTYWNA" && rc.TypRejestruCzynnosci == "NIEAKTYWNA" ) 
                    || cbTypRejestru.Text == "HISTORIA" || cbTypRejestru.Text == "WSZYSTKIE")
                dgvResult.Rows.Add(
                            rc.RejestrCzynnosciGUID,
                            rc.CreatedDateTime,
                            rc.NazwaAdministratoraDanych,
                            rc.WspolAdministratorzy,
                            rc.InsepktorDanychOsobowych,
                            rc.NazwaZbioruDanych,
                            rc.RodzajCzynnosci,
                            rc.TytulCzynnosci,
                            rc.CelPrzetwarzania,
                            rc.OpisKategoriiOsob,
                            rc.KategorieOdbiorcow,
                            rc.KategorieDanychOsobowych,
                            rc.InformarcjeOPrzekazaniuDoPanstwaTrzeciego,
                            rc.PlanowanyTerminUsuniecia,
                            rc.OpisTechniczny,
                            rc.Uwagi,
                            rc.TypRejestruCzynnosci);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NGS_DocumentNew.License.NGSLicense.isLicenseValid())
            {
                RejestrCzynnosciView rcv = new RejestrCzynnosciView();
                rcv.ShowDialog();

                Search();
            }
        }

        private void dgvResult_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if(e.RowIndex >=0 && dgvResult.Rows.Count >0 && dgvResult.Rows[e.RowIndex].Cells[15].Value != null &&
                dgvResult.Rows[e.RowIndex].Cells[15].Value.ToString() == "AKTYWNA")
            {
                dgvResult.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
        }
    }
}
