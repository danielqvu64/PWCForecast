namespace PWC.Forecast
{
    partial class frmBrand
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
            this.txtBrandDescription = new System.Windows.Forms.TextBox();
            this.txtBrandCode = new System.Windows.Forms.TextBox();
            this.lblBrandCode = new System.Windows.Forms.Label();
            this.lblBrandDescription = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvBrand = new System.Windows.Forms.DataGridView();
            this.bindingSourceBrand = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseClipboardDataOnNewRow = new System.Windows.Forms.CheckBox();
            this.BrandCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBrandDescription
            // 
            this.txtBrandDescription.Location = new System.Drawing.Point(191, 13);
            this.txtBrandDescription.MaxLength = 100;
            this.txtBrandDescription.Name = "txtBrandDescription";
            this.txtBrandDescription.Size = new System.Drawing.Size(187, 20);
            this.txtBrandDescription.TabIndex = 4;
            this.txtBrandDescription.GotFocus += new System.EventHandler(this.txtBrandDescription_GotFocus);
            // 
            // txtBrandCode
            // 
            this.txtBrandCode.Location = new System.Drawing.Point(82, 14);
            this.txtBrandCode.MaxLength = 2;
            this.txtBrandCode.Name = "txtBrandCode";
            this.txtBrandCode.Size = new System.Drawing.Size(28, 20);
            this.txtBrandCode.TabIndex = 2;
            this.txtBrandCode.GotFocus += new System.EventHandler(this.txtBrandCode_GotFocus);
            // 
            // lblBrandCode
            // 
            this.lblBrandCode.AutoSize = true;
            this.lblBrandCode.Location = new System.Drawing.Point(16, 17);
            this.lblBrandCode.Name = "lblBrandCode";
            this.lblBrandCode.Size = new System.Drawing.Size(66, 13);
            this.lblBrandCode.TabIndex = 1;
            this.lblBrandCode.Text = "Brand Code:";
            // 
            // lblBrandDescription
            // 
            this.lblBrandDescription.AutoSize = true;
            this.lblBrandDescription.Location = new System.Drawing.Point(126, 16);
            this.lblBrandDescription.Name = "lblBrandDescription";
            this.lblBrandDescription.Size = new System.Drawing.Size(63, 13);
            this.lblBrandDescription.TabIndex = 3;
            this.lblBrandDescription.Text = "Description:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(390, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvBrand
            // 
            this.dgvBrand.AutoGenerateColumns = false;
            this.dgvBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrandCode,
            this.BrandDescription,
            this.objectKeyDataGridViewTextBoxColumn});
            this.dgvBrand.DataSource = this.bindingSourceBrand;
            this.dgvBrand.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvBrand.Location = new System.Drawing.Point(15, 64);
            this.dgvBrand.Name = "dgvBrand";
            this.dgvBrand.Size = new System.Drawing.Size(437, 302);
            this.dgvBrand.TabIndex = 8;
            this.dgvBrand.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBrand_UserDeletingRow);
            this.dgvBrand.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBrand_CellBeginEdit);
            this.dgvBrand.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBrand_RowValidating);
            this.dgvBrand.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvBrand_CellParsing);
            this.dgvBrand.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBrand_CellValidating);
            this.dgvBrand.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBrand_CellEndEdit);
            this.dgvBrand.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBrand_DataError);
            // 
            // bindingSourceBrand
            // 
            this.bindingSourceBrand.AllowNew = true;
            this.bindingSourceBrand.DataSource = typeof(PWC.BusinessObject.Brand.ParameteredCollection);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Maximum number of rows returned is 300.";
            // 
            // chkUseClipboardDataOnNewRow
            // 
            this.chkUseClipboardDataOnNewRow.AutoSize = true;
            this.chkUseClipboardDataOnNewRow.Location = new System.Drawing.Point(269, 40);
            this.chkUseClipboardDataOnNewRow.Name = "chkUseClipboardDataOnNewRow";
            this.chkUseClipboardDataOnNewRow.Size = new System.Drawing.Size(183, 17);
            this.chkUseClipboardDataOnNewRow.TabIndex = 7;
            this.chkUseClipboardDataOnNewRow.Text = "Use Clipboard Data on New Row";
            this.chkUseClipboardDataOnNewRow.UseVisualStyleBackColor = true;
            // 
            // BrandCode
            // 
            this.BrandCode.DataPropertyName = "BrandCode";
            this.BrandCode.HeaderText = "Brand Code";
            this.BrandCode.MaxInputLength = 2;
            this.BrandCode.Name = "BrandCode";
            this.BrandCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BrandCode.Width = 70;
            // 
            // BrandDescription
            // 
            this.BrandDescription.DataPropertyName = "BrandDescription";
            this.BrandDescription.HeaderText = "Description";
            this.BrandDescription.MaxInputLength = 100;
            this.BrandDescription.Name = "BrandDescription";
            this.BrandDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BrandDescription.Width = 220;
            // 
            // objectKeyDataGridViewTextBoxColumn
            // 
            this.objectKeyDataGridViewTextBoxColumn.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.Name = "objectKeyDataGridViewTextBoxColumn";
            this.objectKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmBrand
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 380);
            this.Controls.Add(this.chkUseClipboardDataOnNewRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBrand);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBrandDescription);
            this.Controls.Add(this.txtBrandCode);
            this.Controls.Add(this.lblBrandCode);
            this.Controls.Add(this.txtBrandDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBrand";
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.frmBrand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtBrandDescription;
        private System.Windows.Forms.TextBox txtBrandCode;
        private System.Windows.Forms.Label lblBrandCode;
        private System.Windows.Forms.Label lblBrandDescription;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBrand;
        private System.Windows.Forms.BindingSource bindingSourceBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUseClipboardDataOnNewRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn;
    }
}