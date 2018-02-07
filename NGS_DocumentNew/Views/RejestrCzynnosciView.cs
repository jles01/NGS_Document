using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGS_DocumentNew.Model;

namespace NGS_DocumentNew.Views
{
    public partial class RejestrCzynnosciView : Form
    {
        RejestrCzynnosci rc = null;


        public RejestrCzynnosciView()
        {
            this.Text = GlobalVariables.ApplicationName + " - Wprowadź rejestr czynności";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            InitializeComponent();
            
            rc = new RejestrCzynnosci();
            SetToolTips();
        }

        public RejestrCzynnosciView(RejestrCzynnosci _rc)
        {
            this.Text = GlobalVariables.ApplicationName + " - Edytuj rejestr czynności";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            InitializeComponent();
            rc = _rc;

            LoadRejestr();
            SetToolTips();
        }

        private void SetToolTips()
        {
            tbNazwaAdministratoraDanych.Enter += ToolTipTextBox_Enter;
        }

        private void ToolTipTextBox_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show( NGS_DocumentNew.Model.RejestrCzynnosciToolTip.tbNazwaAdministratoraDanych, TB, 0, 0, VisibleTime);
        }

        private void LoadRejestr()
        {
            tbNazwaAdministratoraDanych.Text = rc.NazwaAdministratoraDanych;
            tbWspolAdministratorzy.Text = rc.WspolAdministratorzy;
            tbInsepktorDanychOsobowych.Text = rc.InsepktorDanychOsobowych;
            tbNazwaZbioruDanych.Text = rc.NazwaZbioruDanych;
            cbRodzajCzynnosci.Text = rc.RodzajCzynnosci;
            tbTytulCzynnosci.Text = rc.TytulCzynnosci;
            tbCelPrzetwarzania.Text = rc.CelPrzetwarzania;
            tbOpisKategoriiOsob.Text = rc.OpisKategoriiOsob;
            tbKategorieOdbiorcow.Text = rc.KategorieOdbiorcow;
            tbKategorieDanychOsobowych.Text = rc.KategorieDanychOsobowych;
            tbInformarcjeOPrzekazaniuDoPanstwaTrzeciego.Text = rc.InformarcjeOPrzekazaniuDoPanstwaTrzeciego;
            tbPlanowanyTerminUsuniecia.Text = rc.PlanowanyTerminUsuniecia;
            tbOpisTechniczny.Text = rc.OpisTechniczny;
            tbUwagi.Text = rc.Uwagi;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            rc.LastModifiedBy = GlobalVariables.CurrentUser.UserGUID;
            rc.LastModifiedDateTime = DateTime.Now;

            if (rc.RejestrCzynnosciGUID == null)
            {
                rc.RejestrCzynnosciGUID = GlobalVariables.GetNewGUID();
                rc.CreatedBy = GlobalVariables.CurrentUser.UserGUID;
                rc.CreatedDateTime = DateTime.Now;
            }
            else
            {
                rc.TypRejestruCzynnosci = "HISTORIA";

                rc.Update();

                rc.RejestrCzynnosciGUID = GlobalVariables.GetNewGUID();
                rc.CreatedBy = GlobalVariables.CurrentUser.UserGUID;
                rc.CreatedDateTime = DateTime.Now;
            }
            rc.TypRejestruCzynnosci = "AKTYWNA";

            rc.NazwaAdministratoraDanych = tbNazwaAdministratoraDanych.Text;
            rc.WspolAdministratorzy = tbWspolAdministratorzy.Text;
            rc.InsepktorDanychOsobowych = tbInsepktorDanychOsobowych.Text;
            rc.NazwaZbioruDanych = tbNazwaZbioruDanych.Text;
            rc.RodzajCzynnosci = cbRodzajCzynnosci.Text;
            rc.TytulCzynnosci = tbTytulCzynnosci.Text;
            rc.CelPrzetwarzania = tbCelPrzetwarzania.Text;
            rc.OpisKategoriiOsob = tbOpisKategoriiOsob.Text;
            rc.KategorieOdbiorcow = tbKategorieOdbiorcow.Text;
            rc.KategorieDanychOsobowych = tbKategorieDanychOsobowych.Text;
            rc.InformarcjeOPrzekazaniuDoPanstwaTrzeciego = tbInformarcjeOPrzekazaniuDoPanstwaTrzeciego.Text;
            rc.PlanowanyTerminUsuniecia = tbPlanowanyTerminUsuniecia.Text;
            rc.OpisTechniczny = tbOpisTechniczny.Text;
            rc.Uwagi = tbUwagi.Text;
            rc.CompanyGUID = GlobalVariables.CurrentCompany.CompanyGUID;
            
            rc.Save();

            MessageBox.Show("Rejestr został zapisany", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
