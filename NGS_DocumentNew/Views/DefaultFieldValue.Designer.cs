namespace NGS_DocumentNew.Views
{
    partial class DefaultFieldValue
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartDocumentFlow = new System.Windows.Forms.Button();
            this.dgvDefaultFields = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefaultFields)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDefaultFields);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domyślne pola:";
            // 
            // btnStartDocumentFlow
            // 
            this.btnStartDocumentFlow.Location = new System.Drawing.Point(12, 200);
            this.btnStartDocumentFlow.Name = "btnStartDocumentFlow";
            this.btnStartDocumentFlow.Size = new System.Drawing.Size(486, 23);
            this.btnStartDocumentFlow.TabIndex = 1;
            this.btnStartDocumentFlow.Text = "Rozpocznij przepływ dokumentów";
            this.btnStartDocumentFlow.UseVisualStyleBackColor = true;
            this.btnStartDocumentFlow.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDefaultFields
            // 
            this.dgvDefaultFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefaultFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefaultFields.Location = new System.Drawing.Point(3, 16);
            this.dgvDefaultFields.Name = "dgvDefaultFields";
            this.dgvDefaultFields.Size = new System.Drawing.Size(480, 163);
            this.dgvDefaultFields.TabIndex = 0;
            // 
            // DefaultFieldValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 232);
            this.ControlBox = false;
            this.Controls.Add(this.btnStartDocumentFlow);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefaultFieldValue";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DefaultFieldValue";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefaultFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartDocumentFlow;
        private System.Windows.Forms.DataGridView dgvDefaultFields;
    }
}