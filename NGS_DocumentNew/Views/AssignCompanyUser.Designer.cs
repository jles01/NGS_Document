namespace NGS_DocumentNew.Views
{
    partial class AssignCompanyUser
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
            this.lbComapny = new System.Windows.Forms.ListBox();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAssignCompany = new System.Windows.Forms.GroupBox();
            this.lbAssignCompany = new System.Windows.Forms.ListBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnNewCompany = new System.Windows.Forms.Button();
            this.btnAssignAll = new System.Windows.Forms.Button();
            this.btnUnAssign = new System.Windows.Forms.Button();
            this.btnUnassignAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbComapny.SuspendLayout();
            this.gbAssignCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbComapny
            // 
            this.gbComapny.Controls.Add(this.lbComapny);
            this.gbComapny.Location = new System.Drawing.Point(12, 51);
            this.gbComapny.Name = "gbComapny";
            this.gbComapny.Size = new System.Drawing.Size(237, 188);
            this.gbComapny.TabIndex = 0;
            this.gbComapny.TabStop = false;
            this.gbComapny.Text = "Firmy:";
            // 
            // lbComapny
            // 
            this.lbComapny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbComapny.FormattingEnabled = true;
            this.lbComapny.Location = new System.Drawing.Point(3, 16);
            this.lbComapny.Name = "lbComapny";
            this.lbComapny.Size = new System.Drawing.Size(231, 169);
            this.lbComapny.TabIndex = 0;
            // 
            // cbUsers
            // 
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(91, 12);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(472, 21);
            this.cbUsers.TabIndex = 1;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Użytkownik: ";
            // 
            // gbAssignCompany
            // 
            this.gbAssignCompany.Controls.Add(this.lbAssignCompany);
            this.gbAssignCompany.Location = new System.Drawing.Point(305, 51);
            this.gbAssignCompany.Name = "gbAssignCompany";
            this.gbAssignCompany.Size = new System.Drawing.Size(258, 188);
            this.gbAssignCompany.TabIndex = 1;
            this.gbAssignCompany.TabStop = false;
            this.gbAssignCompany.Text = "Przypisane firmy:";
            // 
            // lbAssignCompany
            // 
            this.lbAssignCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAssignCompany.FormattingEnabled = true;
            this.lbAssignCompany.Location = new System.Drawing.Point(3, 16);
            this.lbAssignCompany.Name = "lbAssignCompany";
            this.lbAssignCompany.Size = new System.Drawing.Size(252, 169);
            this.lbAssignCompany.TabIndex = 0;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(255, 81);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(44, 23);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "->";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnNewCompany
            // 
            this.btnNewCompany.Location = new System.Drawing.Point(12, 251);
            this.btnNewCompany.Name = "btnNewCompany";
            this.btnNewCompany.Size = new System.Drawing.Size(551, 23);
            this.btnNewCompany.TabIndex = 0;
            this.btnNewCompany.Text = "Nowa firma";
            this.btnNewCompany.UseVisualStyleBackColor = true;
            this.btnNewCompany.Click += new System.EventHandler(this.btnNewCompany_Click);
            // 
            // btnAssignAll
            // 
            this.btnAssignAll.Location = new System.Drawing.Point(255, 110);
            this.btnAssignAll.Name = "btnAssignAll";
            this.btnAssignAll.Size = new System.Drawing.Size(44, 23);
            this.btnAssignAll.TabIndex = 4;
            this.btnAssignAll.Text = "->>";
            this.btnAssignAll.UseVisualStyleBackColor = true;
            this.btnAssignAll.Click += new System.EventHandler(this.btnAssignAll_Click);
            // 
            // btnUnAssign
            // 
            this.btnUnAssign.Location = new System.Drawing.Point(255, 139);
            this.btnUnAssign.Name = "btnUnAssign";
            this.btnUnAssign.Size = new System.Drawing.Size(44, 23);
            this.btnUnAssign.TabIndex = 5;
            this.btnUnAssign.Text = "<-";
            this.btnUnAssign.UseVisualStyleBackColor = true;
            this.btnUnAssign.Click += new System.EventHandler(this.btnUnAssign_Click);
            // 
            // btnUnassignAll
            // 
            this.btnUnassignAll.Location = new System.Drawing.Point(255, 168);
            this.btnUnassignAll.Name = "btnUnassignAll";
            this.btnUnassignAll.Size = new System.Drawing.Size(44, 23);
            this.btnUnassignAll.TabIndex = 6;
            this.btnUnassignAll.Text = "<<-";
            this.btnUnassignAll.UseVisualStyleBackColor = true;
            this.btnUnassignAll.Click += new System.EventHandler(this.btnUnassignAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 280);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(551, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AssignCompanyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUnassignAll);
            this.Controls.Add(this.btnUnAssign);
            this.Controls.Add(this.btnAssignAll);
            this.Controls.Add(this.btnNewCompany);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.gbAssignCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.gbComapny);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignCompanyUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignCompanyUser";
            this.gbComapny.ResumeLayout(false);
            this.gbAssignCompany.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbComapny;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAssignCompany;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnNewCompany;
        private System.Windows.Forms.Button btnAssignAll;
        private System.Windows.Forms.Button btnUnAssign;
        private System.Windows.Forms.Button btnUnassignAll;
        private System.Windows.Forms.ListBox lbComapny;
        private System.Windows.Forms.ListBox lbAssignCompany;
        private System.Windows.Forms.Button btnClose;
    }
}