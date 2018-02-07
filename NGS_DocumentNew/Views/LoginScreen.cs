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
    public partial class LoginScreen : Form
    {
        private bool FirstLogIn;

        public LoginScreen(bool firstLogIn)
        {
            InitializeForm(firstLogIn);
        }

        public LoginScreen()
        {
            InitializeForm(true);
        }

        private void InitializeForm(bool firstLogin)
        {
            InitializeComponent();

            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            FirstLogIn = firstLogin;
            this.Text = GlobalVariables.ApplicationName + " - Ekran logowania";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if( CheckFields() )
                LoginUser();
        }

        private bool CheckFields()
        {
            bool ret = true;

            if( String.IsNullOrEmpty(tbUserName.Text) )
            {
                GlobalVariables.ShowMessage("Musisz podać nazwę użytkownika !", "Ekran logowania", 1);
                ret = false;
            }
            else if (String.IsNullOrEmpty(tbPassword.Text))
            {
                GlobalVariables.ShowMessage("Musisz podać hasło !", "Ekran logowania", 1);
                ret = false;
            }

            return ret;
        }

        private void LoginUser()
        {
            User user = new User();
            if (user.LoginUser(tbUserName.Text, tbPassword.Text))
            {
                GlobalVariables.CurrentUser = user;

                GlobalVariables.Log("Użytkownik " + user.UserName + " zalogował się.");

                this.Visible = false;
                CompanyChooser cc = new CompanyChooser();
                cc.Show();

                
            }
            else
            {
                GlobalVariables.ShowMessage("Nie prawidłowa nazwa użytkownika lub hasło !", "Ekran logowania", 3);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if( FirstLogIn )
            {
                Application.Exit();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter )
                if (CheckFields())
                    LoginUser();
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (CheckFields())
                    LoginUser();
        }
    }
}
