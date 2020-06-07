namespace PWC.Forecast
{
    partial class frmForecastExport
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
            this.lblSavedForecast = new System.Windows.Forms.Label();
            this.cboSavedForecast = new System.Windows.Forms.ComboBox();
            this.bindingSourceSavedForecast = new System.Windows.Forms.BindingSource(this.components);
            this.rbtnAllLatestCustomerForecasts = new System.Windows.Forms.RadioButton();
            this.rbtnByDate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnToOracle = new System.Windows.Forms.RadioButton();
            this.rbtnPLCrossTab = new System.Windows.Forms.RadioButton();
            this.chkSubtractCurrentMonthSales = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedForecast)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(69, 12);
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
            this.txtCompanyName.Location = new System.Drawing.Point(100, 12);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(165, 20);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TabStop = false;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(11, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company:";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(250, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(182, 173);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(69, 125);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(268, 20);
            this.txtFilePath.TabIndex = 10;
            this.txtFilePath.GotFocus += new System.EventHandler(this.txtFilePath_GotFocus);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 128);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 9;
            this.lblFilePath.Text = "File Path:";
            // 
            // chkAppendFile
            // 
            this.chkAppendFile.AutoSize = true;
            this.chkAppendFile.Location = new System.Drawing.Point(397, 128);
            this.chkAppendFile.Name = "chkAppendFile";
            this.chkAppendFile.Size = new System.Drawing.Size(82, 17);
            this.chkAppendFile.TabIndex = 12;
            this.chkAppendFile.Text = "Append File";
            this.chkAppendFile.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 152);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(466, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.CausesValidation = false;
            this.btnBrowseFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowseFolder.Location = new System.Drawing.Point(343, 125);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseFolder.TabIndex = 11;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lblSavedForecast
            // 
            this.lblSavedForecast.AutoSize = true;
            this.lblSavedForecast.Location = new System.Drawing.Point(279, 63);
            this.lblSavedForecast.Name = "lblSavedForecast";
            this.lblSavedForecast.Size = new System.Drawing.Size(90, 13);
            this.lblSavedForecast.TabIndex = 6;
            this.lblSavedForecast.Text = "Saved Forecasts:";
            this.lblSavedForecast.Visible = false;
            // 
            // cboSavedForecast
            // 
            this.cboSavedForecast.DataSource = this.bindingSourceSavedForecast;
            this.cboSavedForecast.DisplayMember = "Description";
            this.cboSavedForecast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavedForecast.FormattingEnabled = true;
            this.cboSavedForecast.Location = new System.Drawing.Point(372, 58);
            this.cboSavedForecast.Name = "cboSavedForecast";
            this.cboSavedForecast.Size = new System.Drawing.Size(107, 21);
            this.cboSavedForecast.TabIndex = 7;
            this.cboSavedForecast.ValueMember = "POSSalesEndDate";
            this.cboSavedForecast.Visible = false;
            // 
            // bindingSourceSavedForecast
            // 
            this.bindingSourceSavedForecast.AllowNew = false;
            // 
            // rbtnAllLatestCustomerForecasts
            // 
            this.rbtnAllLatestCustomerForecasts.AutoSize = true;
            this.rbtnAllLatestCustomerForecasts.Checked = true;
            this.rbtnAllLatestCustomerForecasts.Location = new System.Drawing.Point(12, 19);
            this.rbtnAllLatestCustomerForecasts.Name = "rbtnAllLatestCustomerForecasts";
            this.rbtnAllLatestCustomerForecasts.Size = new System.Drawing.Size(164, 17);
            this.rbtnAllLatestCustomerForecasts.TabIndex = 1;
            this.rbtnAllLatestCustomerForecasts.TabStop = true;
            this.rbtnAllLatestCustomerForecasts.Text = "All Latest Customer Forecasts";
            this.rbtnAllLatestCustomerForecasts.UseVisualStyleBackColor = true;
            // 
            // rbtnByDate
            // 
            this.rbtnByDate.AutoSize = true;
            this.rbtnByDate.Location = new System.Drawing.Point(183, 19);
            this.rbtnByDate.Name = "rbtnByDate";
            this.rbtnByDate.Size = new System.Drawing.Size(63, 17);
            this.rbtnByDate.TabIndex = 2;
            this.rbtnByDate.TabStop = true;
            this.rbtnByDate.Text = "By Date";
            this.rbtnByDate.UseVisualStyleBackColor = true;
            this.rbtnByDate.CheckedChanged += new System.EventHandler(this.rbtnByDate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnByDate);
            this.groupBox1.Controls.Add(this.rbtnAllLatestCustomerForecasts);
            this.groupBox1.Location = new System.Drawing.Point(14, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 44);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forecast Selection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnToOracle);
            this.groupBox2.Controls.Add(this.rbtnPLCrossTab);
            this.groupBox2.Location = new System.Drawing.Point(279, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 42);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export Type Selection";
            // 
            // rbtnToOracle
            // 
            this.rbtnToOracle.AutoSize = true;
            this.rbtnToOracle.Checked = true;
            this.rbtnToOracle.Location = new System.Drawing.Point(10, 19);
            this.rbtnToOracle.Name = "rbtnToOracle";
            this.rbtnToOracle.Size = new System.Drawing.Size(72, 17);
            this.rbtnToOracle.TabIndex = 1;
            this.rbtnToOracle.TabStop = true;
            this.rbtnToOracle.Text = "To Oracle";
            this.rbtnToOracle.UseVisualStyleBackColor = true;
            // 
            // rbtnPLCrossTab
            // 
            this.rbtnPLCrossTab.AutoSize = true;
            this.rbtnPLCrossTab.Location = new System.Drawing.Point(93, 19);
            this.rbtnPLCrossTab.Name = "rbtnPLCrossTab";
            this.rbtnPLCrossTab.Size = new System.Drawing.Size(82, 17);
            this.rbtnPLCrossTab.TabIndex = 2;
            this.rbtnPLCrossTab.Text = "PL Crosstab";
            this.rbtnPLCrossTab.UseVisualStyleBackColor = true;
            this.rbtnPLCrossTab.CheckedChanged += new System.EventHandler(this.rbtnPLCrossTab_CheckedChanged);
            // 
            // chkSubtractCurrentMonthSales
            // 
            this.chkSubtractCurrentMonthSales.AutoSize = true;
            this.chkSubtractCurrentMonthSales.Location = new System.Drawing.Point(14, 97);
            this.chkSubtractCurrentMonthSales.Name = "chkSubtractCurrentMonthSales";
            this.chkSubtractCurrentMonthSales.Size = new System.Drawing.Size(165, 17);
            this.chkSubtractCurrentMonthSales.TabIndex = 8;
            this.chkSubtractCurrentMonthSales.Text = "Subtract Current Month Sales";
            this.chkSubtractCurrentMonthSales.UseVisualStyleBackColor = true;
            // 
            // frmForecastExport
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 206);
            this.Controls.Add(this.chkSubtractCurrentMonthSales);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSavedForecast);
            this.Controls.Add(this.cboSavedForecast);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkAppendFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForecastExport";
            this.Text = "Export Forecast";
            this.Load += new System.EventHandler(this.frmForecastExport_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesRateForecastExport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedForecast)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MaskedTextBox txtCompanyCode;
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
        private System.Windows.Forms.Label lblSavedForecast;
        private System.Windows.Forms.ComboBox cboSavedForecast;
        private System.Windows.Forms.BindingSource bindingSourceSavedForecast;
        private System.Windows.Forms.RadioButton rbtnAllLatestCustomerForecasts;
        private System.Windows.Forms.RadioButton rbtnByDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnPLCrossTab;
        private System.Windows.Forms.RadioButton rbtnToOracle;
        private System.Windows.Forms.CheckBox chkSubtractCurrentMonthSales;
    }
}