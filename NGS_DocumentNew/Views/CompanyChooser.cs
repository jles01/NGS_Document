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
    public partial class CompanyChooser : Form
    {
        private List<Model.Company> companyList = null;

        public CompanyChooser()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - wybór firmy";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            LoadCompany();
        }

        private void LoadCompany()
        {
            cbCompany.Items.Clear();

            companyList = GlobalVariables.CurrentUser.GetUserCompany();

            if( companyList.Count == 0 )
            {
                GlobalVariables.ShowMessage("Użytkownik nie ma wybranej firmy. Musisz ją przypisać.", "Wybór firmy", 1);
                AssignCompanyUser acu = new AssignCompanyUser();
                acu.ShowDialog();
                LoadCompany();
            }
            else
            {
                foreach (Model.Company c in companyList)
                    cbCompany.Items.Add(c.CompanyName);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbCompany.Text))
                GlobalVariables.ShowMessage("Musisz wybrać firmę!", "Wybór firmy", 1);
            else
            {
                foreach (Model.Company c in companyList)
                    if (c.CompanyName.Equals(cbCompany.Text))
                    {
                        GlobalVariables.CurrentCompany = c;

                        Settings settings = new Settings();
                        settings.LoadSettings(c.CompanyGUID);

                        GlobalVariables.CurrentCompanySettings = settings;

                        GlobalVariables.Log("Użytkownik " + GlobalVariables.CurrentUser.UserName + " zalogował się do firmy " + c.CompanyName);
                    }

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Visible = false;
            }
        }

        private void cbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                btnChoose.PerformClick();
            }
        }
    }
}
