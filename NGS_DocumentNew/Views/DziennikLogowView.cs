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
    public partial class DziennikLogowView : UserControl
    {
        public DziennikLogowView()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - dziennik logów";

            cbLogType.Text = "WSZYSTKIE";
            cbLogType.SelectedText = "WSZYSTKIE";

            dgvSearch.ReadOnly = true;
            CreateColumns();
        }

        private void CreateColumns()
        {
            DataGridViewColumn logGUIDLog = new DataGridViewTextBoxColumn();
            logGUIDLog.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            logGUIDLog.HeaderText = "LogGUID";
            logGUIDLog.Visible = false;
            logGUIDLog.Name = "LogGUID";

            DataGridViewColumn logDateTime = new DataGridViewTextBoxColumn();
            logDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            logDateTime.HeaderText = "Data logu";
            logDateTime.Name = "LogType";

            DataGridViewColumn logType = new DataGridViewTextBoxColumn();
            logType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            logType.HeaderText = "Typ";
            logType.Name = "logType";

            DataGridViewColumn logMessage = new DataGridViewTextBoxColumn();
            logMessage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            logMessage.HeaderText = "Wiadomość";
            logMessage.Name = "logMessage";

            DataGridViewColumn userName = new DataGridViewTextBoxColumn();
            userName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userName.HeaderText = "Użytkownik";
            userName.Name = "userName";


            dgvSearch.Columns.Add(logGUIDLog);
            dgvSearch.Columns.Add(logDateTime);
            dgvSearch.Columns.Add(logType);
            dgvSearch.Columns.Add(logMessage);
            dgvSearch.Columns.Add(userName);

        }

        private void btnAddLog_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbNowyLog.Text))
            {
                GlobalVariables.Log(tbNowyLog.Text, "User");

                MessageBox.Show("Log został dodany!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNowyLog.Text = "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearch.Rows.Clear();

            ListNGSLog list = new ListNGSLog();
            list.LoadList(tbSearch.Text, cbLogType.Text);

            foreach (Log l in list.logList)
            {
                dgvSearch.Rows.Add(
                    l.LogGUID
                    , l.LogDateTime
                    , l.LogType
                    , l.LogMessage
                    , l.UserName
                    );
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch.PerformClick();
        }

        private void tbNowyLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAddLog.PerformClick();
        }
    }
}
