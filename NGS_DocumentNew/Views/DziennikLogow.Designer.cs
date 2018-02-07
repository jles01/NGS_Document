namespace NGS_DocumentNew.Views
{
    partial class DziennikLogow
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbLogType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.btnAddLog = new System.Windows.Forms.Button();
            this.tbNowyLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(92, 9);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(271, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Szukaj tesktu:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(605, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(155, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Wyszukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbLogType
            // 
            this.cbLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogType.FormattingEnabled = true;
            this.cbLogType.Items.AddRange(new object[] {
            "WSZYSTKIE",
            "SYSTEMOWE",
            "UŻYTKOWNIKA"});
            this.cbLogType.Location = new System.Drawing.Point(462, 11);
            this.cbLogType.Name = "cbLogType";
            this.cbLogType.Size = new System.Drawing.Size(121, 21);
            this.cbLogType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Typ logów:";
            // 
            // dgvSearch
            // 
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(15, 87);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.Size = new System.Drawing.Size(745, 160);
            this.dgvSearch.TabIndex = 5;
            // 
            // btnAddLog
            // 
            this.btnAddLog.Location = new System.Drawing.Point(605, 38);
            this.btnAddLog.Name = "btnAddLog";
            this.btnAddLog.Size = new System.Drawing.Size(155, 23);
            this.btnAddLog.TabIndex = 6;
            this.btnAddLog.Text = "Dodaj log";
            this.btnAddLog.UseVisualStyleBackColor = true;
            this.btnAddLog.Click += new System.EventHandler(this.btnAddLog_Click);
            // 
            // tbNowyLog
            // 
            this.tbNowyLog.Location = new System.Drawing.Point(92, 41);
            this.tbNowyLog.Name = "tbNowyLog";
            this.tbNowyLog.Size = new System.Drawing.Size(491, 20);
            this.tbNowyLog.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wiadomość: ";
            // 
            // DziennikLogow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 259);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNowyLog);
            this.Controls.Add(this.btnAddLog);
            this.Controls.Add(this.dgvSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLogType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Name = "DziennikLogow";
            this.Text = "DziennikLogow";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbLogType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Button btnAddLog;
        private System.Windows.Forms.TextBox tbNowyLog;
        private System.Windows.Forms.Label label3;
    }
}