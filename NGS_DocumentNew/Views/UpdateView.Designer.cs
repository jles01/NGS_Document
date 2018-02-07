namespace NGS_DocumentNew.Views
{
    partial class UpdateView
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentVersion = new System.Windows.Forms.TextBox();
            this.tbAvaliableVersion = new System.Windows.Forms.TextBox();
            this.btnCheckUpdate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Obecna wersja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dostępna wersja:";
            // 
            // tbCurrentVersion
            // 
            this.tbCurrentVersion.Location = new System.Drawing.Point(130, 6);
            this.tbCurrentVersion.Name = "tbCurrentVersion";
            this.tbCurrentVersion.ReadOnly = true;
            this.tbCurrentVersion.Size = new System.Drawing.Size(186, 20);
            this.tbCurrentVersion.TabIndex = 2;
            // 
            // tbAvaliableVersion
            // 
            this.tbAvaliableVersion.Location = new System.Drawing.Point(130, 35);
            this.tbAvaliableVersion.Name = "tbAvaliableVersion";
            this.tbAvaliableVersion.ReadOnly = true;
            this.tbAvaliableVersion.Size = new System.Drawing.Size(186, 20);
            this.tbAvaliableVersion.TabIndex = 3;
            // 
            // btnCheckUpdate
            // 
            this.btnCheckUpdate.Location = new System.Drawing.Point(15, 73);
            this.btnCheckUpdate.Name = "btnCheckUpdate";
            this.btnCheckUpdate.Size = new System.Drawing.Size(301, 23);
            this.btnCheckUpdate.TabIndex = 4;
            this.btnCheckUpdate.Text = "Sprawdź aktualizacje";
            this.btnCheckUpdate.UseVisualStyleBackColor = true;
            this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(15, 102);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(301, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Aktualizuj";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(15, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(301, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 163);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCheckUpdate);
            this.Controls.Add(this.tbAvaliableVersion);
            this.Controls.Add(this.tbCurrentVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateView";
            this.Text = "UpdateView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentVersion;
        private System.Windows.Forms.TextBox tbAvaliableVersion;
        private System.Windows.Forms.Button btnCheckUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
    }
}