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
    public partial class UsersView : Form
    {
        List<User> listOfUsers = null;

        public UsersView()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - użytkownicy";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            CreateColumns();
            LoadUsers();
        }

        private void CreateColumns()
        {
            DataGridViewColumn userGuidCol = new DataGridViewTextBoxColumn();
            userGuidCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userGuidCol.HeaderText = "UserGUID";
            userGuidCol.Visible = false;
            userGuidCol.Name = "UserGUID";

            DataGridViewColumn userNameGuidCol = new DataGridViewTextBoxColumn();
            userNameGuidCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userNameGuidCol.HeaderText = "Nazwa użytkownika";
            userNameGuidCol.Name = "UserName";
            //userNameGuidCol.ReadOnly = true;

            DataGridViewColumn userFirstNameCol = new DataGridViewTextBoxColumn();
            userFirstNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userFirstNameCol.HeaderText = "Imię";
            userFirstNameCol.Name = "FirstName";

            DataGridViewColumn userLastNameCol = new DataGridViewTextBoxColumn();
            userLastNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userLastNameCol.HeaderText = "Nazwisko";
            userLastNameCol.Name = "LastName";

            DataGridViewColumn userPasswordCol = new DataGridViewTextBoxColumn();
            userPasswordCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userPasswordCol.HeaderText = "Hasło";
            userPasswordCol.Name = "UserPassword";
            userPasswordCol.ReadOnly = true;

            dgvUsers.Columns.Add(userGuidCol);
            dgvUsers.Columns.Add(userNameGuidCol);
            dgvUsers.Columns.Add(userFirstNameCol);
            dgvUsers.Columns.Add(userLastNameCol);
            dgvUsers.Columns.Add(userPasswordCol);


            dgvUsers.CellClick += DgvUsers_CellClick;
            dgvUsers.CellEnter += DgvUsers_CellEnter;
            dgvUsers.CellEndEdit += DgvUsers_CellEndEdit;
            dgvUsers.RowsRemoved += DgvUsers_RowsRemoved;
            dgvUsers.RowsAdded += DgvUsers_RowsAdded;
            dgvUsers.CellValidating += DgvUsers_CellValidating;

            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.MultiSelect = false;

        }

        private void DgvUsers_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex == 1 && e.RowIndex >= listOfUsers.Count)
            {
                string userName = e.FormattedValue.ToString();

                foreach (User u in listOfUsers)
                {
                    if (u.UserName == userName)
                    {
                        dgvUsers.Rows[e.RowIndex].ErrorText = "Nazwa użytkownika musi byc unikalna";
                        e.Cancel = true;
                    }
                }
            }
        }

        private void DgvUsers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           /* int rowIndex = dgvUsers.Rows.Count - 1;
            if (dgvUsers[0, rowIndex] == null || dgvUsers[0, rowIndex].Value == null || String.IsNullOrEmpty(dgvUsers[0, rowIndex].Value.ToString()))
            {
                dgvUsers[0, rowIndex].Value = GlobalVariables.GetNewGUID();
            }*/
        }

        private void DgvUsers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void DgvUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void SaveUsers()
        {
            for(int i = 0; i < dgvUsers.Rows.Count - 1; i++)
            {
                if (dgvUsers[0, i].Value == null || String.IsNullOrEmpty(dgvUsers[0, i].Value.ToString()))
                {
                    if ( String.IsNullOrEmpty(dgvUsers[1, i].Value.ToString()))
                    {
                        return;
                    }
                    string newGUID = GlobalVariables.GetNewGUID();
                    User user = new User();
                    user.SaveUser(newGUID, dgvUsers[1, i].Value.ToString(), dgvUsers[2, i].Value.ToString(), dgvUsers[3, i].Value.ToString());
                }
                else {
                    foreach (User u in listOfUsers)
                        if (u.UserGUID == dgvUsers[0, i].Value.ToString())
                            u.UpdateUser(u.UserGUID, dgvUsers[2, i].Value.ToString(), dgvUsers[3, i].Value.ToString());
                }
            }

            LoadUsers();
        }

        private void DgvUsers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SetPassword(e.RowIndex);
            }
        }

        private void SetPassword(int rowIndex)
        {
            if (dgvUsers[0, rowIndex].Value != null)
            {
                string userGUID = dgvUsers[0, rowIndex].Value.ToString();
                //MessageBox.Show(userGUID);
                ChangePasswordView cpv = new ChangePasswordView();

                cpv.SetUserGUID(userGUID);

                cpv.ShowDialog();
            }
        }

        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                SetPassword(e.RowIndex);
            }
        }

        private void LoadUsers()
        {
            listOfUsers = new List<User>();
            dgvUsers.Rows.Clear();
            if (GlobalVariables.CurrentUser.UserName.Equals("Admin"))
            {
                ListNGSObject list = new ListNGSObject();
                listOfUsers = list.GetListOfUsers();
            }
            else
                listOfUsers.Add(GlobalVariables.CurrentUser);

            foreach (User u in listOfUsers)
                dgvUsers.Rows.Add(u.UserGUID, u.UserName, u.FirstName, u.LastName, "*****");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUsers();

            GlobalVariables.Log("Użytkownik dodał nowego użytkownika" );
        }
    }
}
