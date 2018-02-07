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
using MySql.Data.MySqlClient;

namespace NGS_DocumentNew.Views
{
    public partial class MagazynView : Form
    {

        String sql= @"SELECT
            m.nr_koperty,
            m.nr_plomby,
            m.data,
            m.godz_odb,
            m.data_kopii,
            m.nr_pro,
            m.przekazal,
            m.zwrocil,
            c.ClientName,
            c.NIP,
            c.AddressLine1,
            c.PostCode,
            c.City,
            k.FirstName,
            k.LastName,
            m.data_zw
        FROM  `tbl_magazyn` m
            INNER JOIN Client c
                ON c.ClientID = m.id_klienta
            INNER JOIN tbl_konwojenci k
                ON k.id = m.id_konwojenta
			INNER JOIN MagazynDostep md
				ON md.ClientID = m.id_klienta
		WHERE md.NumerLicencji = @NumerLicencji";

        String countSql = @"SELECT count(1) 
            FROM  `tbl_magazyn` m
            INNER JOIN Client c
                ON c.ClientID = m.id_klienta
            INNER JOIN tbl_konwojenci k
                ON k.id = m.id_konwojenta";

        public MagazynView()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - Magazyn";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            GetStatus();
        }

        private void GetStatus()
        {
            //GlobalVariables.LicenseKey;
            string connectionString = "Server=mn03.webd.pl;Port=3306;uid=ngsol_dataabi;pwd=}%-bv_^39?KiJMC}J?;database=ngsol_datacare;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                NGS_DocumentNew.Model.Magazyn magazyn = new Magazyn();

                magazyn.Delete();

                /*MySqlCommand cmd = new MySqlCommand(countSql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();*/

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@NumerLicencji", GlobalVariables.LicenseKey));

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Magazyn> listMagazyn = new List<Magazyn>();

                while (reader.Read())
                {
                    magazyn.FillData(
                        GlobalVariables.GetNewGUID(),
                        reader.IsDBNull(0) ? "" : reader.GetString(0),
                        reader.IsDBNull(1) ? "" : reader.GetString(1),
                        reader.IsDBNull(2) ? "" : reader.GetString(2),
                        reader.IsDBNull(3) ? "" : reader.GetString(3),
                        reader.IsDBNull(4) ? "" : reader.GetString(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        reader.IsDBNull(6) ? "" : reader.GetString(6),
                        reader.IsDBNull(7) ? "" : reader.GetString(7),
                        reader.IsDBNull(8) ? "" : reader.GetString(8),
                        reader.IsDBNull(9) ? "" : reader.GetString(9),
                        reader.IsDBNull(10) ? "" : reader.GetString(10),
                        reader.IsDBNull(11) ? "" : reader.GetString(11),
                        reader.IsDBNull(12) ? "" : reader.GetString(12),
                        reader.IsDBNull(13) ? "" : reader.GetString(13),
                        reader.IsDBNull(14) ? "" : reader.GetString(14),
                        reader.IsDBNull(15) ? "" : reader.GetString(15),
                        GlobalVariables.CurrentCompany.CompanyGUID
                        );

                    magazyn.Save();
                    //listMagazyn.Add(magazyn);
                }



                reader = null;
                reader.Close();
                GlobalVariables.Log("Użytkownik pobrał aktualne dane magazynowe.");
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Dane zostały przekopiowane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
