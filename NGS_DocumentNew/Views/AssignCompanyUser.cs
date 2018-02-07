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
    public partial class AssignCompanyUser : Form
    {
        List<Model.Company> companyList = null;
        List<User> userList = null;
        List<Model.Company> companyAssignForUser = null;

        public AssignCompanyUser()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - przyporządkowanie użytkownika do firmy";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            LoadCompany();
            LoadUsers();
        }

        private void LoadUsers()
        {
            cbUsers.Items.Clear();
            
            if (GlobalVariables.CurrentUser.UserName.Equals("Admin"))
            {
                ListNGSObject listNGSObject = new ListNGSObject();
                userList = listNGSObject.GetListOfUsers();
            }
            else
            {
                userList = new List<User>();
                userList.Add(GlobalVariables.CurrentUser);
            }

            foreach(User u in userList)
            {
                cbUsers.Items.Add(u.UserName);
            }

            for(int i = 0; i < cbUsers.Items.Count; i++)
            {
                if (cbUsers.Items[i].ToString() == GlobalVariables.CurrentUser.UserName)
                    cbUsers.SelectedIndex = i;
            }
        }

        private void LoadCompany()
        {
            ListNGSObject listNGSObject = new ListNGSObject();
            companyList = listNGSObject.GetListOfCompany();

            foreach( Model.Company c in companyList)
            {
                lbComapny.Items.Add(c.CompanyName);
            }
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssignCompanyForUser();
        }

        private void LoadAssignCompanyForUser()
        {
            lbAssignCompany.Items.Clear();
            foreach (User u in userList)
            {
                if(u.UserName.Equals(cbUsers.Text))
                {
                    companyAssignForUser = u.GetUserCompany();

                    foreach (Company c in companyAssignForUser)
                        lbAssignCompany.Items.Add(c.CompanyName);
                }
            }

            RemoveAlreadyAssignCompany();
        }

        private void RemoveAlreadyAssignCompany()
        {
            foreach (Company c in companyAssignForUser)
                lbComapny.Items.Remove(c.CompanyName);
        }

        private void btnNewCompany_Click(object sender, EventArgs e)
        {
            CreateNewCompany();
        }

        private void CreateNewCompany()
        {
            CompanyView cv = new CompanyView();
            cv.ShowDialog();

            LoadCompany();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lbComapny.SelectedIndex > -1)
                AssignCompanyToUser(lbComapny.SelectedItem.ToString());
        }

        private void AssignCompanyToUser(string companyName)
        {
            User selectedUser = null;
            foreach (User u in userList)
            {
                if (u.UserName.Equals(cbUsers.Text))
                    selectedUser = u;
            }

            foreach (Company c in companyList)
                if (c.CompanyName.Equals(companyName))
                {
                    selectedUser.AssignCompany(c.CompanyGUID);
                }

            lbAssignCompany.Items.Add(companyName);
            lbComapny.Items.Remove(companyName);
        }

        private void btnAssignAll_Click(object sender, EventArgs e)
        {
            foreach (String item in lbComapny.Items)
                AssignCompanyToUser(item);
        }

        private void btnUnAssign_Click(object sender, EventArgs e)
        {
            if (lbAssignCompany.SelectedIndex > -1)
                RemoveAssignCompanyToUser(lbAssignCompany.SelectedItem.ToString());
        }

        private void RemoveAssignCompanyToUser(string companyName)
        {
            User selectedUser = null;
            foreach (User u in userList)
            {
                if (u.UserName.Equals(cbUsers.Text))
                    selectedUser = u;
            }

            foreach (Company c in companyList)
                if (c.CompanyName.Equals(companyName))
                {
                    selectedUser.RemoveAssignCompany(c.CompanyGUID);
                }

            lbComapny.Items.Add(companyName);
            lbAssignCompany.Items.Remove(companyName);
        }

        private void btnUnassignAll_Click(object sender, EventArgs e)
        {
            foreach (String item in lbComapny.Items)
                RemoveAssignCompanyToUser(item);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
