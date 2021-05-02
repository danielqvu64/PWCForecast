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
            this.bindingSourceSavedForecast = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnToOracle = new System.Windows.Forms.RadioButton();
            this.rbtnForEdit = new System.Windows.Forms.RadioButton();
            this.chkSubtractCurrentMonthSales = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedForecast)).BeginInit();
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
            this.txtCompanyCode.GotFocus += new System.EventHandler(this.txtCompanyCode_GotFocus);
            this.txtCompanyCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyCode_Validating);
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
            this.btnCancel.Location = new System.Drawing.Point(250, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(182, 109);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(69, 61);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(268, 20);
            this.txtFilePath.TabIndex = 10;
            this.txtFilePath.GotFocus += new System.EventHandler(this.txtFilePath_GotFocus);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 64);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 9;
            this.lblFilePath.Text = "File Path:";
            // 
            // chkAppendFile
            // 
            this.chkAppendFile.AutoSize = true;
            this.chkAppendFile.Location = new System.Drawing.Point(397, 64);
            this.chkAppendFile.Name = "chkAppendFile";
            this.chkAppendFile.Size = new System.Drawing.Size(82, 17);
            this.chkAppendFile.TabIndex = 12;
            this.chkAppendFile.Text = "Append File";
            this.chkAppendFile.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 88);
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
            this.btnBrowseFolder.Location = new System.Drawing.Point(343, 61);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseFolder.TabIndex = 11;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // bindingSourceSavedForecast
            // 
            this.bindingSourceSavedForecast.AllowNew = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnToOracle);
            this.groupBox2.Controls.Add(this.rbtnForEdit);
            this.groupBox2.Location = new System.Drawing.Point(279, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 42);
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
            this.rbtnToOracle.CheckedChanged += new System.EventHandler(this.rbtnToOracle_CheckedChanged);
            // 
            // rbtnForEdit
            // 
            this.rbtnForEdit.AutoSize = true;
            this.rbtnForEdit.Location = new System.Drawing.Point(93, 19);
            this.rbtnForEdit.Name = "rbtnForEdit";
            this.rbtnForEdit.Size = new System.Drawing.Size(61, 17);
            this.rbtnForEdit.TabIndex = 2;
            this.rbtnForEdit.Text = "For Edit";
            this.rbtnForEdit.UseVisualStyleBackColor = true;
            // 
            // chkSubtractCurrentMonthSales
            // 
            this.chkSubtractCurrentMonthSales.AutoSize = true;
            this.chkSubtractCurrentMonthSales.Location = new System.Drawing.Point(12, 38);
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
            this.ClientSize = new System.Drawing.Size(494, 141);
            this.Controls.Add(this.chkSubtractCurrentMonthSales);
            this.Controls.Add(this.groupBox2);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmForecastExport_FormClosing);
            this.Load += new System.EventHandler(this.frmForecastExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedForecast)).EndInit();
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
        private System.Windows.Forms.BindingSource bindingSourceSavedForecast;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnToOracle;
        private System.Windows.Forms.CheckBox chkSubtractCurrentMonthSales;
        private System.Windows.Forms.RadioButton rbtnForEdit;
    }
}