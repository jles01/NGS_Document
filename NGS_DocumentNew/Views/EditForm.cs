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
    public partial class EditForm : Form
    {
        private string txt = "";
        private bool tab = true;

        public EditForm()
        {
            InitializeComponent();

            this.textBox1.KeyDown += TextBox1_KeyDown;

            this.textBox1.SelectAll();
        }

        public EditForm(string _intxt, string _caption)
        {
            InitializeComponent();

            this.textBox1.KeyDown += TextBox1_KeyDown;
            this.textBox1.PreviewKeyDown += TextBox1_PreviewKeyDown;
            this.txt = _intxt;
            textBox1.Text = txt;

            this.lblTxt.Text = _caption;
            this.textBox1.SelectAll();
        }

        private void TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                e.IsInputKey = true;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt = textBox1.Text;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txt = textBox1.Text;
                tab = true;
                this.Close();
            }
        }

        private void EditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Tab)
            {

            }
        }

        public string GetValue()
        {
            return txt;
        }

        public bool GetTab()
        {
            return tab;
        }

        private void btnWstaw_Click_1(object sender, EventArgs e)
        {
            txt = textBox1.Text;
            tab = true;
            this.Close();
        }
    }
}
