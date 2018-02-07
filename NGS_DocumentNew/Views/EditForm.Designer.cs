namespace NGS_DocumentNew.Views
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTxt = new System.Windows.Forms.Label();
            this.btnWstaw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lblTxt
            // 
            this.lblTxt.AutoSize = true;
            this.lblTxt.Location = new System.Drawing.Point(12, 15);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(35, 13);
            this.lblTxt.TabIndex = 1;
            this.lblTxt.Text = "label1";
            // 
            // btnWstaw
            // 
            this.btnWstaw.Location = new System.Drawing.Point(456, 10);
            this.btnWstaw.Name = "btnWstaw";
            this.btnWstaw.Size = new System.Drawing.Size(91, 23);
            this.btnWstaw.TabIndex = 2;
            this.btnWstaw.Text = "Wstaw";
            this.btnWstaw.UseVisualStyleBackColor = true;
            this.btnWstaw.Click += new System.EventHandler(this.btnWstaw_Click_1);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 43);
            this.ControlBox = false;
            this.Controls.Add(this.btnWstaw);
            this.Controls.Add(this.lblTxt);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTxt;
        private System.Windows.Forms.Button btnWstaw;
    }
}