namespace PWC.Forecast
{
    partial class frmCustomer
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.bindingSourceCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.chkUseClipboardDataOnNewRow = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForecastMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InflateFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForecastFutureFrozenMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(73, 12);
            this.txtCompanyCode.Mask = "000";
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.PromptChar = ' ';
            this.txtCompanyCode.Size = new System.Drawing.Size(25, 20);
            this.txtCompanyCode.TabIndex = 1;
            this.txtCompanyCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyCode_Validating);
            this.txtCompanyCode.GotFocus += new System.EventHandler(this.txtCompanyCode_GotFocus);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(104, 12);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(427, 20);
            this.txtCompanyName.TabIndex = 2;
            this.txtCompanyName.TabStop = false;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(15, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company:";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomer.AutoGenerateColumns = false;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerNumber,
            this.CustomerName,
            this.ForecastMethod,
            this.InflateFactor,
            this.ForecastFutureFrozenMonths,
            this.objectKeyDataGridViewTextBoxColumn});
            this.dgvCustomer.DataSource = this.bindingSourceCustomer;
            this.dgvCustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCustomer.Location = new System.Drawing.Point(16, 58);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.Size = new System.Drawing.Size(515, 264);
            this.dgvCustomer.TabIndex = 3;
            this.dgvCustomer.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCustomer_UserDeletingRow);
            this.dgvCustomer.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCustomer_CellBeginEdit);
            this.dgvCustomer.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCustomer_RowValidating);
            this.dgvCustomer.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvCustomer_CellParsing);
            this.dgvCustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCustomer_CellFormatting);
            this.dgvCustomer.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCustomer_CellValidating);
            this.dgvCustomer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellEndEdit);
            this.dgvCustomer.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCustomer_EditingControlShowing);
            this.dgvCustomer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCustomer_DataError);
            // 
            // bindingSourceCustomer
            // 
            this.bindingSourceCustomer.AllowNew = true;
            this.bindingSourceCustomer.DataSource = typeof(PWC.BusinessObject.Customer.WithCompanyParentCollection);
            // 
            // chkUseClipboardDataOnNewRow
            // 
            this.chkUseClipboardDataOnNewRow.AutoSize = true;
            this.chkUseClipboardDataOnNewRow.Location = new System.Drawing.Point(348, 38);
            this.chkUseClipboardDataOnNewRow.Name = "chkUseClipboardDataOnNewRow";
            this.chkUseClipboardDataOnNewRow.Size = new System.Drawing.Size(183, 17);
            this.chkUseClipboardDataOnNewRow.TabIndex = 3;
            this.chkUseClipboardDataOnNewRow.Text = "Use Clipboard Data on New Row";
            this.chkUseClipboardDataOnNewRow.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Parent";
            this.dataGridViewTextBoxColumn1.HeaderText = "Parent";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.DataPropertyName = "CustomerNumber";
            this.CustomerNumber.HeaderText = "Customer No.";
            this.CustomerNumber.MaxInputLength = 10;
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerNumber.Width = 100;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.MaxInputLength = 100;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerName.Width = 195;
            // 
            // ForecastMethod
            // 
            this.ForecastMethod.DataPropertyName = "ForecastMethod";
            this.ForecastMethod.HeaderText = "Forecast Method";
            this.ForecastMethod.MaxInputLength = 2;
            this.ForecastMethod.Name = "ForecastMethod";
            this.ForecastMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ForecastMethod.Width = 50;
            // 
            // InflateFactor
            // 
            this.InflateFactor.DataPropertyName = "InflateFactor";
            this.InflateFactor.HeaderText = "Forecast Inflate %";
            this.InflateFactor.MaxInputLength = 6;
            this.InflateFactor.Name = "InflateFactor";
            this.InflateFactor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InflateFactor.Width = 55;
            // 
            // ForecastFutureFrozenMonths
            // 
            this.ForecastFutureFrozenMonths.DataPropertyName = "ForecastFutureFrozenMonths";
            this.ForecastFutureFrozenMonths.HeaderText = "Forecast Future Frozen Months";
            this.ForecastFutureFrozenMonths.MaxInputLength = 2;
            this.ForecastFutureFrozenMonths.Name = "ForecastFutureFrozenMonths";
            this.ForecastFutureFrozenMonths.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ForecastFutureFrozenMonths.Width = 50;
            // 
            // objectKeyDataGridViewTextBoxColumn
            // 
            this.objectKeyDataGridViewTextBoxColumn.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.Name = "objectKeyDataGridViewTextBoxColumn";
            this.objectKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 339);
            this.Controls.Add(this.chkUseClipboardDataOnNewRow);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.frmPWCCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MaskedTextBox txtCompanyCode;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.BindingSource bindingSourceCustomer;
        private System.Windows.Forms.CheckBox chkUseClipboardDataOnNewRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForecastMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn InflateFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForecastFutureFrozenMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn;
    }
}