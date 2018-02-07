namespace NGS_DocumentNew.Views
{
    partial class DziennikLogowView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.tbNowyLog = new System.Windows.Forms.TextBox();
            this.btnAddLog = new System.Windows.Forms.Button();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLogType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Wiadomość: ";
            // 
            // tbNowyLog
            // 
            this.tbNowyLog.Location = new System.Drawing.Point(91, 39);
            this.tbNowyLog.Name = "tbNowyLog";
            this.tbNowyLog.Size = new System.Drawing.Size(491, 20);
            this.tbNowyLog.TabIndex = 16;
            this.tbNowyLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNowyLog_KeyDown);
            // 
            // btnAddLog
            // 
            this.btnAddLog.Location = new System.Drawing.Point(604, 36);
            this.btnAddLog.Name = "btnAddLog";
            this.btnAddLog.Size = new System.Drawing.Size(155, 23);
            this.btnAddLog.TabIndex = 15;
            this.btnAddLog.Text = "Dodaj log";
            this.btnAddLog.UseVisualStyleBackColor = true;
            this.btnAddLog.Click += new System.EventHandler(this.btnAddLog_Click);
            // 
            // dgvSearch
            // 
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(14, 85);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.Size = new System.Drawing.Size(745, 165);
            this.dgvSearch.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Typ logów:";
            // 
            // cbLogType
            // 
            this.cbLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogType.FormattingEnabled = true;
            this.cbLogType.Items.AddRange(new object[] {
            "WSZYSTKIE",
            "SYSTEMOWE",
            "UŻYTKOWNIKA"});
            this.cbLogType.Location = new System.Drawing.Point(461, 9);
            this.cbLogType.Name = "cbLogType";
            this.cbLogType.Size = new System.Drawing.Size(121, 21);
            this.cbLogType.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(604, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(155, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Wyszukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Szukaj tesktu:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(91, 7);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(271, 20);
            this.tbSearch.TabIndex = 9;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // DziennikLogowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNowyLog);
            this.Controls.Add(this.btnAddLog);
            this.Controls.Add(this.dgvSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLogType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Name = "DziennikLogowView";
            this.Size = new System.Drawing.Size(782, 269);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNowyLog;
        private System.Windows.Forms.Button btnAddLog;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLogType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
    }
}
