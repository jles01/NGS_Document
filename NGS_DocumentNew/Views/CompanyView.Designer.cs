namespace NGS_DocumentNew.Views
{
    partial class CompanyView
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
            this.gbComapny = new System.Windows.Forms.GroupBox();
            this.dgvComapny = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbComapny.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComapny)).BeginInit();
            this.SuspendLayout();
            // 
            // gbComapny
            // 
            this.gbComapny.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComapny.Controls.Add(this.dgvComapny);
            this.gbComapny.Location = new System.Drawing.Point(12, 12);
            this.gbComapny.Name = "gbComapny";
            this.gbComapny.Size = new System.Drawing.Size(434, 155);
            this.gbComapny.TabIndex = 0;
            this.gbComapny.TabStop = false;
            this.gbComapny.Text = "Firmy:";
            // 
            // dgvComapny
            // 
            this.dgvComapny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComapny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComapny.Location = new System.Drawing.Point(3, 16);
            this.dgvComapny.Name = "dgvComapny";
            this.dgvComapny.Size = new System.Drawing.Size(428, 136);
            this.dgvComapny.TabIndex = 0;
            this.dgvComapny.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComapny_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(15, 173);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(431, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CompanyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 204);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbComapny);
            this.HelpButton = true;
            this.Name = "CompanyView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.gbComapny.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComapny)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbComapny;
        private System.Windows.Forms.DataGridView dgvComapny;
        private System.Windows.Forms.Button btnClose;
    }
}