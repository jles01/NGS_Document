namespace NGS_DocumentNew.Views
{
    partial class LicenseView
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbLicenseKey = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLicenseInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbMACAdres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klucz licencyjny:";
            // 
            // tbLicenseKey
            // 
            this.tbLicenseKey.Location = new System.Drawing.Point(131, 32);
            this.tbLicenseKey.Name = "tbLicenseKey";
            this.tbLicenseKey.Size = new System.Drawing.Size(298, 20);
            this.tbLicenseKey.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(452, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Zapisz klucz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLicenseInfo
            // 
            this.lblLicenseInfo.AutoSize = true;
            this.lblLicenseInfo.Location = new System.Drawing.Point(12, 65);
            this.lblLicenseInfo.Name = "lblLicenseInfo";
            this.lblLicenseInfo.Size = new System.Drawing.Size(35, 13);
            this.lblLicenseInfo.TabIndex = 3;
            this.lblLicenseInfo.Text = "label2";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(15, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(536, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbMACAdres
            // 
            this.tbMACAdres.Location = new System.Drawing.Point(131, 6);
            this.tbMACAdres.Name = "tbMACAdres";
            this.tbMACAdres.ReadOnly = true;
            this.tbMACAdres.Size = new System.Drawing.Size(298, 20);
            this.tbMACAdres.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adres MAC:";
            // 
            // LicenseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 198);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMACAdres);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblLicenseInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbLicenseKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLicenseKey;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbMACAdres;
        private System.Windows.Forms.Label label2;
    }
}