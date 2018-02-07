namespace NGS_DocumentNew.Views
{
    partial class DocumentSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbDocumentSearch = new System.Windows.Forms.TextBox();
            this.dgvDocumentSearch = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wyszukaj dokumentów:";
            // 
            // tbDocumentSearch
            // 
            this.tbDocumentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocumentSearch.Location = new System.Drawing.Point(129, 9);
            this.tbDocumentSearch.Name = "tbDocumentSearch";
            this.tbDocumentSearch.Size = new System.Drawing.Size(350, 20);
            this.tbDocumentSearch.TabIndex = 1;
            this.tbDocumentSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDocumentSearch_KeyDown);
            // 
            // dgvDocumentSearch
            // 
            this.dgvDocumentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentSearch.Location = new System.Drawing.Point(6, 45);
            this.dgvDocumentSearch.Name = "dgvDocumentSearch";
            this.dgvDocumentSearch.Size = new System.Drawing.Size(663, 187);
            this.dgvDocumentSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(485, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(184, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Wyszukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // DocumentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvDocumentSearch);
            this.Controls.Add(this.tbDocumentSearch);
            this.Controls.Add(this.label1);
            this.Name = "DocumentSearch";
            this.Size = new System.Drawing.Size(686, 252);
            this.Load += new System.EventHandler(this.DocumentSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDocumentSearch;
        private System.Windows.Forms.DataGridView dgvDocumentSearch;
        public System.Windows.Forms.Button btnSearch;
    }
}
