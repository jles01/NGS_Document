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
    public partial class CompanyView : Form
    {
        public CompanyView()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - firmy";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            CreateColumnsForDGV();
            LoadCompany();
        }

        private void CreateColumnsForDGV()
        {
            DataGridViewColumn companyGuidCol = new DataGridViewTextBoxColumn();
            companyGuidCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            companyGuidCol.HeaderText = "CompanyGUID";
            companyGuidCol.Visible = false;
            companyGuidCol.Name = "CompanyGUID";

            DataGridViewColumn companyNameCol = new DataGridViewTextBoxColumn();
            companyNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            companyNameCol.HeaderText = "Nazwa firmy";
            companyNameCol.Name = "CompanyName";

            dgvComapny.CellEndEdit += DgvComapny_CellEndEdit;

            dgvComapny.Columns.Add(companyGuidCol);
            dgvComapny.Columns.Add(companyNameCol);
        }

        private void DgvComapny_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveCompany(e.RowIndex);
        }

        private void SaveCompany(int rowIndex)
        {
            ListNGSObject list = new ListNGSObject();

            bool save = true;
            List<Company> companyList = list.GetListOfCompany();
            foreach (Company c in companyList)
            {
                if(dgvComapny[1, rowIndex].Value != null && c.CompanyName == dgvComapny[1, rowIndex].Value.ToString() 
                    && (dgvComapny[0, rowIndex].Value == null || c.CompanyGUID != dgvComapny[0, rowIndex].Value.ToString()))
                {
                    GlobalVariables.ShowMessage("Podana nazwa firmy \"" + dgvComapny[1, rowIndex].Value.ToString() + "\"  już istnieje.", "Duplikat nazwy firmy.", 3);
                    save = false;
                }
            }

            if(save && dgvComapny[1, rowIndex].Value != null && (dgvComapny[0, rowIndex].Value == null || String.IsNullOrEmpty(dgvComapny[0, rowIndex].Value.ToString())))
            {
                if( NGSLicense.getNumberOfCompaniesRegistered() < rowIndex )
                {
                    GlobalVariables.ShowMessage("Twoja licencja nie pozwala mieć, więcej firm!", "Licencja - błąd", 3);
                    return;
                }

                Company c = new Company();
                c.CompanyGUID = GlobalVariables.GetNewGUID();
                c.CompanyName = dgvComapny[1, rowIndex].Value.ToString();
                dgvComapny[0, rowIndex].Value = c.CompanyGUID;

                c.Save();
            }
            else if( save && dgvComapny[1, rowIndex].Value != null 
                && dgvComapny[0, rowIndex].Value != null && !String.IsNullOrEmpty(dgvComapny[0, rowIndex].Value.ToString()))
            {
                foreach (Company c in companyList)
                {
                    if( c.CompanyGUID == dgvComapny[0, rowIndex].Value.ToString())
                    {
                        c.CompanyName = dgvComapny[1, rowIndex].Value.ToString();
                        c.Update();
                        break;
                    }
                }
            }
        }

        private void LoadCompany()
        {
            dgvComapny.Rows.Clear();
            ListNGSObject listNGSObject = new ListNGSObject();
            List<Company> companyList = listNGSObject.GetListOfCompany();

            foreach(Company c in companyList)
            {
                dgvComapny.Rows.Add(c.CompanyGUID, c.CompanyName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvComapny_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
