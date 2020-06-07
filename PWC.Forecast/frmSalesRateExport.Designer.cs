namespace PWC.Forecast
{
    partial class frmSalesRateExport
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
            this.txtCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.chkAppendFile = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblSavedSalesRate = new System.Windows.Forms.Label();
            this.cboSavedSalesRate = new System.Windows.Forms.ComboBox();
            this.bindingSourceSavedSalesRate = new System.Windows.Forms.BindingSource(this.components);
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedSalesRate)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(69, 24);
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
            this.lblCustomer.Location = new System.Drawing.Point(250, 27);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(100, 24);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(143, 20);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TabStop = false;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(11, 27);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company:";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(299, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(231, 124);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(69, 76);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(307, 20);
            this.txtFilePath.TabIndex = 9;
            this.txtFilePath.GotFocus += new System.EventHandler(this.txtFilePath_GotFocus);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 79);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 8;
            this.lblFilePath.Text = "File Path:";
            // 
            // chkAppendFile
            // 
            this.chkAppendFile.AutoSize = true;
            this.chkAppendFile.Location = new System.Drawing.Point(425, 79);
            this.chkAppendFile.Name = "chkAppendFile";
            this.chkAppendFile.Size = new System.Drawing.Size(82, 17);
            this.chkAppendFile.TabIndex = 11;
            this.chkAppendFile.Text = "Append File";
            this.chkAppendFile.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 103);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(565, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.CausesValidation = false;
            this.btnBrowseFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowseFolder.Location = new System.Drawing.Point(382, 74);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseFolder.TabIndex = 10;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lblSavedSalesRate
            // 
            this.lblSavedSalesRate.AutoSize = true;
            this.lblSavedSalesRate.Location = new System.Drawing.Point(10, 55);
            this.lblSavedSalesRate.Name = "lblSavedSalesRate";
            this.lblSavedSalesRate.Size = new System.Drawing.Size(96, 13);
            this.lblSavedSalesRate.TabIndex = 6;
            this.lblSavedSalesRate.Text = "Saved Sales Rate:";
            // 
            // cboSavedSalesRate
            // 
            this.cboSavedSalesRate.DataSource = this.bindingSourceSavedSalesRate;
            this.cboSavedSalesRate.DisplayMember = "POSSalesEndDate";
            this.cboSavedSalesRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavedSalesRate.FormattingEnabled = true;
            this.cboSavedSalesRate.Location = new System.Drawing.Point(112, 50);
            this.cboSavedSalesRate.Name = "cboSavedSalesRate";
            this.cboSavedSalesRate.Size = new System.Drawing.Size(85, 21);
            this.cboSavedSalesRate.TabIndex = 7;
            this.cboSavedSalesRate.ValueMember = "POSSalesEndDate";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(310, 23);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(267, 21);
            this.cboCustomer.TabIndex = 5;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // frmSalesRateExport
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(590, 165);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblSavedSalesRate);
            this.Controls.Add(this.cboSavedSalesRate);
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
            this.Name = "frmSalesRateExport";
            this.Text = "Export Sales Rate";
            this.Load += new System.EventHandler(this.frmForecastExport_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesRateForecastExport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedSalesRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MaskedTextBox txtCompanyCode;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.CheckBox chkAppendFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblSavedSalesRate;
        private System.Windows.Forms.ComboBox cboSavedSalesRate;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.BindingSource bindingSourceSavedSalesRate;
    }
}