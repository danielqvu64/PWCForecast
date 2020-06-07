namespace PWC.Forecast
{
    partial class frmProductCategory
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
            this.txtProductCategoryDescription = new System.Windows.Forms.TextBox();
            this.txtProductCategoryCode = new System.Windows.Forms.TextBox();
            this.lblProductCategoryCode = new System.Windows.Forms.Label();
            this.lblProductCategoryDescription = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvProductCategory = new System.Windows.Forms.DataGridView();
            this.bindingSourceProductCategory = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseClipboardDataOnNewRow = new System.Windows.Forms.CheckBox();
            this.ProductCategoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCategoryDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductCategoryDescription
            // 
            this.txtProductCategoryDescription.Location = new System.Drawing.Point(245, 14);
            this.txtProductCategoryDescription.MaxLength = 100;
            this.txtProductCategoryDescription.Name = "txtProductCategoryDescription";
            this.txtProductCategoryDescription.Size = new System.Drawing.Size(187, 20);
            this.txtProductCategoryDescription.TabIndex = 4;
            this.txtProductCategoryDescription.GotFocus += new System.EventHandler(this.txtProductCategoryDescription_GotFocus);
            // 
            // txtProductCategoryCode
            // 
            this.txtProductCategoryCode.Location = new System.Drawing.Point(139, 14);
            this.txtProductCategoryCode.MaxLength = 2;
            this.txtProductCategoryCode.Name = "txtProductCategoryCode";
            this.txtProductCategoryCode.Size = new System.Drawing.Size(28, 20);
            this.txtProductCategoryCode.TabIndex = 2;
            this.txtProductCategoryCode.GotFocus += new System.EventHandler(this.txtProductCategoryCode_GotFocus);
            // 
            // lblProductCategoryCode
            // 
            this.lblProductCategoryCode.AutoSize = true;
            this.lblProductCategoryCode.Location = new System.Drawing.Point(16, 17);
            this.lblProductCategoryCode.Name = "lblProductCategoryCode";
            this.lblProductCategoryCode.Size = new System.Drawing.Size(120, 13);
            this.lblProductCategoryCode.TabIndex = 1;
            this.lblProductCategoryCode.Text = "Product Category Code:";
            // 
            // lblProductCategoryDescription
            // 
            this.lblProductCategoryDescription.AutoSize = true;
            this.lblProductCategoryDescription.Location = new System.Drawing.Point(180, 17);
            this.lblProductCategoryDescription.Name = "lblProductCategoryDescription";
            this.lblProductCategoryDescription.Size = new System.Drawing.Size(63, 13);
            this.lblProductCategoryDescription.TabIndex = 3;
            this.lblProductCategoryDescription.Text = "Description:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(444, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvProductCategory
            // 
            this.dgvProductCategory.AutoGenerateColumns = false;
            this.dgvProductCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCategoryCode,
            this.ProductCategoryDescription,
            this.objectKeyDataGridViewTextBoxColumn});
            this.dgvProductCategory.DataSource = this.bindingSourceProductCategory;
            this.dgvProductCategory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductCategory.Location = new System.Drawing.Point(15, 64);
            this.dgvProductCategory.Name = "dgvProductCategory";
            this.dgvProductCategory.Size = new System.Drawing.Size(491, 302);
            this.dgvProductCategory.TabIndex = 8;
            this.dgvProductCategory.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProductCategory_UserDeletingRow);
            this.dgvProductCategory.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductCategory_CellBeginEdit);
            this.dgvProductCategory.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductCategory_RowValidating);
            this.dgvProductCategory.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvProductCategory_CellParsing);
            this.dgvProductCategory.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductCategory_CellValidating);
            this.dgvProductCategory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductCategory_CellEndEdit);
            this.dgvProductCategory.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductCategory_DataError);
            // 
            // bindingSourceProductCategory
            // 
            this.bindingSourceProductCategory.AllowNew = true;
            this.bindingSourceProductCategory.DataSource = typeof(PWC.BusinessObject.ProductCategory.ParameteredCollection);
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
            this.chkUseClipboardDataOnNewRow.Location = new System.Drawing.Point(323, 38);
            this.chkUseClipboardDataOnNewRow.Name = "chkUseClipboardDataOnNewRow";
            this.chkUseClipboardDataOnNewRow.Size = new System.Drawing.Size(183, 17);
            this.chkUseClipboardDataOnNewRow.TabIndex = 7;
            this.chkUseClipboardDataOnNewRow.Text = "Use Clipboard Data on New Row";
            this.chkUseClipboardDataOnNewRow.UseVisualStyleBackColor = true;
            // 
            // ProductCategoryCode
            // 
            this.ProductCategoryCode.DataPropertyName = "ProductCategoryCode";
            this.ProductCategoryCode.HeaderText = "Product Category Code";
            this.ProductCategoryCode.MaxInputLength = 2;
            this.ProductCategoryCode.Name = "ProductCategoryCode";
            this.ProductCategoryCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductCategoryCode.Width = 70;
            // 
            // ProductCategoryDescription
            // 
            this.ProductCategoryDescription.DataPropertyName = "ProductCategoryDescription";
            this.ProductCategoryDescription.HeaderText = "Description";
            this.ProductCategoryDescription.MaxInputLength = 100;
            this.ProductCategoryDescription.Name = "ProductCategoryDescription";
            this.ProductCategoryDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductCategoryDescription.Width = 220;
            // 
            // objectKeyDataGridViewTextBoxColumn
            // 
            this.objectKeyDataGridViewTextBoxColumn.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.Name = "objectKeyDataGridViewTextBoxColumn";
            this.objectKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmProductCategory
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 380);
            this.Controls.Add(this.chkUseClipboardDataOnNewRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProductCategory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblProductCategoryDescription);
            this.Controls.Add(this.txtProductCategoryCode);
            this.Controls.Add(this.lblProductCategoryCode);
            this.Controls.Add(this.txtProductCategoryDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductCategory";
            this.Text = "Product Category";
            this.Load += new System.EventHandler(this.frmProductCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtProductCategoryDescription;
        private System.Windows.Forms.TextBox txtProductCategoryCode;
        private System.Windows.Forms.Label lblProductCategoryCode;
        private System.Windows.Forms.Label lblProductCategoryDescription;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProductCategory;
        private System.Windows.Forms.BindingSource bindingSourceProductCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUseClipboardDataOnNewRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategoryDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn;
    }
}