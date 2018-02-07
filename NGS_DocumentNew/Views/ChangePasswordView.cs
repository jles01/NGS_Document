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
    public partial class ChangePasswordView : Form
    {

        private String UserGUID { get; set; }

        public ChangePasswordView()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - zmiana hasła";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if( String.IsNullOrEmpty(tbNewPassword.Text) ||
                String.IsNullOrEmpty(tbNewPassword2.Text ) ) {
                GlobalVariables.ShowMessage("Wszytskie pola muszą być uzupełnione.", "Brak uzupełnionych pól", 3);

                return;
            }

            if( tbNewPassword2.Text != tbNewPassword.Text )
            {
                GlobalVariables.ShowMessage("Pole \"nowe hasło\" różni się od pola \"powtórz hasło\".", "Błąd podczas zapisu hasła", 3);

                return;
            }


            User u = new User();
            u.SavePassword(UserGUID, tbNewPassword.Text);
            u = null;

            GlobalVariables.Log("Użytkownik zmienił hasło");

            this.Close();
        }

        private void ChangePasswordView_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetUserGUID(string userGUID)
        {
            UserGUID = userGUID;
        }
    }
}
