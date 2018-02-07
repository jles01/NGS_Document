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
    public partial class TemplateWindow : Form
    {
        public TemplateWindow()
        {
            InitializeComponent();

            this.Text = GlobalVariables.ApplicationName + " - Importuj Szablony";
            this.Icon = new Icon("Resources/logo_kula_bez_tla_brb_icon.ico");
            TemplateImportView tiv = new TemplateImportView();
            tiv.Dock = DockStyle.Fill;
            this.Controls.Add(tiv);
        }
    }
}
