namespace PWC.Forecast
{
    partial class frmForecastVarianceReport
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
            this.txtCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProductCategoryFrom = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cboBrandFrom = new System.Windows.Forms.ComboBox();
            this.chkSRRA = new System.Windows.Forms.CheckBox();
            this.chkPL = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBrandTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboProductCategoryTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnGroupByBrand = new System.Windows.Forms.RadioButton();
            this.rbtnGroupByItem = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtForecastYear = new System.Windows.Forms.MaskedTextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkAppendFile = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cboCustomerFrom = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomerTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(66, 12);
            this.txtCompanyCode.Mask = "000";
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.PromptChar = ' ';
            this.txtCompanyCode.Size = new System.Drawing.Size(25, 20);
            this.txtCompanyCode.TabIndex = 2;
            this.txtCompanyCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyCode_Validating);
            this.txtCompanyCode.GotFocus += new System.EventHandler(this.txtCompanyCode_GotFocus);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(97, 12);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(267, 20);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TabStop = false;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(8, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Product Category:";
            // 
            // cboProductCategoryFrom
            // 
            this.cboProductCategoryFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductCategoryFrom.FormattingEnabled = true;
            this.cboProductCategoryFrom.ItemHeight = 13;
            this.cboProductCategoryFrom.Location = new System.Drawing.Point(96, 92);
            this.cboProductCategoryFrom.Name = "cboProductCategoryFrom";
            this.cboProductCategoryFrom.Size = new System.Drawing.Size(120, 21);
            this.cboProductCategoryFrom.TabIndex = 16;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(6, 68);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 11;
            this.lblBrand.Text = "Brand:";
            // 
            // cboBrandFrom
            // 
            this.cboBrandFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrandFrom.FormattingEnabled = true;
            this.cboBrandFrom.ItemHeight = 13;
            this.cboBrandFrom.Location = new System.Drawing.Point(96, 65);
            this.cboBrandFrom.Name = "cboBrandFrom";
            this.cboBrandFrom.Size = new System.Drawing.Size(120, 21);
            this.cboBrandFrom.TabIndex = 12;
            // 
            // chkSRRA
            // 
            this.chkSRRA.AutoSize = true;
            this.chkSRRA.Checked = true;
            this.chkSRRA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSRRA.Location = new System.Drawing.Point(484, 15);
            this.chkSRRA.Name = "chkSRRA";
            this.chkSRRA.Size = new System.Drawing.Size(61, 17);
            this.chkSRRA.TabIndex = 5;
            this.chkSRRA.Text = "SR/RA";
            this.chkSRRA.UseVisualStyleBackColor = true;
            // 
            // chkPL
            // 
            this.chkPL.AutoSize = true;
            this.chkPL.Location = new System.Drawing.Point(551, 15);
            this.chkPL.Name = "chkPL";
            this.chkPL.Size = new System.Drawing.Size(39, 17);
            this.chkPL.TabIndex = 6;
            this.chkPL.Text = "PL";
            this.chkPL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Forecast Method:";
            // 
            // cboBrandTo
            // 
            this.cboBrandTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrandTo.FormattingEnabled = true;
            this.cboBrandTo.ItemHeight = 13;
            this.cboBrandTo.Location = new System.Drawing.Point(393, 65);
            this.cboBrandTo.Name = "cboBrandTo";
            this.cboBrandTo.Size = new System.Drawing.Size(120, 21);
            this.cboBrandTo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "to";
            // 
            // cboProductCategoryTo
            // 
            this.cboProductCategoryTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductCategoryTo.FormattingEnabled = true;
            this.cboProductCategoryTo.ItemHeight = 13;
            this.cboProductCategoryTo.Location = new System.Drawing.Point(393, 92);
            this.cboProductCategoryTo.Name = "cboProductCategoryTo";
            this.cboProductCategoryTo.Size = new System.Drawing.Size(120, 21);
            this.cboProductCategoryTo.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Group by:";
            // 
            // rbtnGroupByBrand
            // 
            this.rbtnGroupByBrand.AutoSize = true;
            this.rbtnGroupByBrand.Location = new System.Drawing.Point(96, 120);
            this.rbtnGroupByBrand.Name = "rbtnGroupByBrand";
            this.rbtnGroupByBrand.Size = new System.Drawing.Size(53, 17);
            this.rbtnGroupByBrand.TabIndex = 20;
            this.rbtnGroupByBrand.TabStop = true;
            this.rbtnGroupByBrand.Text = "Brand";
            this.rbtnGroupByBrand.UseVisualStyleBackColor = true;
            // 
            // rbtnGroupByItem
            // 
            this.rbtnGroupByItem.AutoSize = true;
            this.rbtnGroupByItem.Checked = true;
            this.rbtnGroupByItem.Location = new System.Drawing.Point(155, 120);
            this.rbtnGroupByItem.Name = "rbtnGroupByItem";
            this.rbtnGroupByItem.Size = new System.Drawing.Size(45, 17);
            this.rbtnGroupByItem.TabIndex = 21;
            this.rbtnGroupByItem.TabStop = true;
            this.rbtnGroupByItem.Text = "Item";
            this.rbtnGroupByItem.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Forecast Year:";
            // 
            // txtForecastYear
            // 
            this.txtForecastYear.Location = new System.Drawing.Point(393, 122);
            this.txtForecastYear.Mask = "0000";
            this.txtForecastYear.Name = "txtForecastYear";
            this.txtForecastYear.PromptChar = ' ';
            this.txtForecastYear.Size = new System.Drawing.Size(36, 20);
            this.txtForecastYear.TabIndex = 23;
            this.txtForecastYear.Validating += new System.ComponentModel.CancelEventHandler(this.txtForecastYear_Validating);
            this.txtForecastYear.GotFocus += new System.EventHandler(this.txtForecastYear_GotFocus);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.CausesValidation = false;
            this.btnBrowseFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowseFolder.Location = new System.Drawing.Point(535, 146);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseFolder.TabIndex = 26;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 174);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(650, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Visible = false;
            // 
            // chkAppendFile
            // 
            this.chkAppendFile.AutoSize = true;
            this.chkAppendFile.Location = new System.Drawing.Point(578, 151);
            this.chkAppendFile.Name = "chkAppendFile";
            this.chkAppendFile.Size = new System.Drawing.Size(82, 17);
            this.chkAppendFile.TabIndex = 27;
            this.chkAppendFile.Text = "Append File";
            this.chkAppendFile.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(325, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(257, 195);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(62, 23);
            this.btnReport.TabIndex = 29;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(66, 147);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(463, 20);
            this.txtFilePath.TabIndex = 25;
            this.txtFilePath.GotFocus += new System.EventHandler(this.txtFilePath_GotFocus);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(7, 150);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 24;
            this.lblFilePath.Text = "File Path:";
            // 
            // cboCustomerFrom
            // 
            this.cboCustomerFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerFrom.FormattingEnabled = true;
            this.cboCustomerFrom.ItemHeight = 13;
            this.cboCustomerFrom.Location = new System.Drawing.Point(97, 38);
            this.cboCustomerFrom.Name = "cboCustomerFrom";
            this.cboCustomerFrom.Size = new System.Drawing.Size(267, 21);
            this.cboCustomerFrom.TabIndex = 8;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 41);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 7;
            this.lblCustomer.Text = "Customer:";
            // 
            // cboCustomerTo
            // 
            this.cboCustomerTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerTo.FormattingEnabled = true;
            this.cboCustomerTo.ItemHeight = 13;
            this.cboCustomerTo.Location = new System.Drawing.Point(393, 38);
            this.cboCustomerTo.Name = "cboCustomerTo";
            this.cboCustomerTo.Size = new System.Drawing.Size(267, 21);
            this.cboCustomerTo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "to";
            // 
            // frmForecastVarianceReport
            // 
            this.AcceptButton = this.btnReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(672, 230);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCustomerTo);
            this.Controls.Add(this.cboCustomerFrom);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkAppendFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.cboProductCategoryFrom);
            this.Controls.Add(this.txtForecastYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbtnGroupByItem);
            this.Controls.Add(this.rbtnGroupByBrand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboProductCategoryTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBrandTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPL);
            this.Controls.Add(this.chkSRRA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cboBrandFrom);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForecastVarianceReport";
            this.Text = "Actual vs Forecast Report";
            this.Load += new System.EventHandler(this.frmForecastVarianceReport_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmForecastVarianceReport_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MaskedTextBox txtCompanyCode;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProductCategoryFrom;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboBrandFrom;
        private System.Windows.Forms.CheckBox chkSRRA;
        private System.Windows.Forms.CheckBox chkPL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBrandTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboProductCategoryTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtnGroupByBrand;
        private System.Windows.Forms.RadioButton rbtnGroupByItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtForecastYear;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkAppendFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox cboCustomerFrom;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomerTo;
        private System.Windows.Forms.Label label7;
    }
}