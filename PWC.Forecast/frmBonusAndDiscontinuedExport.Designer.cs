namespace PWC.Forecast
{
    partial class frmBonusAndDiscontinuedExport
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
            this.components = new System.ComponentModel.Container();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkAppendFile = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.bindingSourceSavedSalesRate = new System.Windows.Forms.BindingSource(this.components);
            this.chkByCustomer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedSalesRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.CausesValidation = false;
            this.btnBrowseFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowseFolder.Location = new System.Drawing.Point(312, 76);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseFolder.TabIndex = 9;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 104);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(413, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // chkAppendFile
            // 
            this.chkAppendFile.AutoSize = true;
            this.chkAppendFile.Location = new System.Drawing.Point(344, 80);
            this.chkAppendFile.Name = "chkAppendFile";
            this.chkAppendFile.Size = new System.Drawing.Size(82, 17);
            this.chkAppendFile.TabIndex = 10;
            this.chkAppendFile.Text = "Append File";
            this.chkAppendFile.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(153, 125);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(69, 78);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(235, 20);
            this.txtFilePath.TabIndex = 8;
            this.txtFilePath.GotFocus += new System.EventHandler(this.txtFilePath_GotFocus);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 81);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 7;
            this.lblFilePath.Text = "File Path:";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(69, 22);
            this.txtCompanyCode.Mask = "000";
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.PromptChar = ' ';
            this.txtCompanyCode.Size = new System.Drawing.Size(25, 20);
            this.txtCompanyCode.TabIndex = 2;
            this.txtCompanyCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyCode_Validating);
            this.txtCompanyCode.GotFocus += new System.EventHandler(this.txtCompanyCode_GotFocus);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(9, 54);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.Visible = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(100, 22);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(236, 20);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TabStop = false;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(11, 25);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(69, 51);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(267, 21);
            this.cboCustomer.TabIndex = 6;
            this.cboCustomer.Visible = false;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // chkByCustomer
            // 
            this.chkByCustomer.AutoSize = true;
            this.chkByCustomer.Location = new System.Drawing.Point(344, 25);
            this.chkByCustomer.Name = "chkByCustomer";
            this.chkByCustomer.Size = new System.Drawing.Size(85, 17);
            this.chkByCustomer.TabIndex = 4;
            this.chkByCustomer.Text = "By Customer";
            this.chkByCustomer.UseVisualStyleBackColor = true;
            this.chkByCustomer.CheckedChanged += new System.EventHandler(this.chkByCustomer_CheckedChanged);
            // 
            // frmBonusAndDiscontinuedExport
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(441, 168);
            this.Controls.Add(this.chkByCustomer);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkAppendFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBonusAndDiscontinuedExport";
            this.Text = "Bonus and Discontinued Export";
            this.Load += new System.EventHandler(this.frmBonusAndDiscontinuedExport_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBonusAndDiscontinuedExport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedSalesRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkAppendFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.MaskedTextBox txtCompanyCode;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.BindingSource bindingSourceSavedSalesRate;
        private System.Windows.Forms.CheckBox chkByCustomer;

    }
}