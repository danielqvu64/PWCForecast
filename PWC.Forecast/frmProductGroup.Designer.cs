namespace PWC.Forecast
{
    partial class frmProductGroup
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
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProductCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtProductGroupDescription = new System.Windows.Forms.TextBox();
            this.dgvProductGroup = new System.Windows.Forms.DataGridView();
            this.bindingSourceProductGroup = new System.Windows.Forms.BindingSource(this.components);
            this.chkUseClipboardDataOnNewRow = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Brand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProductCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProductGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductGroupDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.ItemHeight = 13;
            this.cboBrand.Location = new System.Drawing.Point(106, 12);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(120, 21);
            this.cboBrand.TabIndex = 2;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(14, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "Brand:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Product Category:";
            // 
            // cboProductCategory
            // 
            this.cboProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductCategory.FormattingEnabled = true;
            this.cboProductCategory.ItemHeight = 13;
            this.cboProductCategory.Location = new System.Drawing.Point(106, 40);
            this.cboProductCategory.Name = "cboProductCategory";
            this.cboProductCategory.Size = new System.Drawing.Size(120, 21);
            this.cboProductCategory.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Group Description:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(530, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtProductGroupDescription
            // 
            this.txtProductGroupDescription.Location = new System.Drawing.Point(405, 12);
            this.txtProductGroupDescription.MaxLength = 100;
            this.txtProductGroupDescription.Name = "txtProductGroupDescription";
            this.txtProductGroupDescription.Size = new System.Drawing.Size(187, 20);
            this.txtProductGroupDescription.TabIndex = 4;
            // 
            // dgvProductGroup
            // 
            this.dgvProductGroup.AutoGenerateColumns = false;
            this.dgvProductGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Brand,
            this.ProductCategory,
            this.ProductGroupCode,
            this.ProductGroupDescription,
            this.objectKeyDataGridViewTextBoxColumn});
            this.dgvProductGroup.DataSource = this.bindingSourceProductGroup;
            this.dgvProductGroup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductGroup.Location = new System.Drawing.Point(15, 90);
            this.dgvProductGroup.Name = "dgvProductGroup";
            this.dgvProductGroup.Size = new System.Drawing.Size(577, 331);
            this.dgvProductGroup.TabIndex = 8;
            this.dgvProductGroup.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProductGroup_UserDeletingRow);
            this.dgvProductGroup.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductGroup_CellBeginEdit);
            this.dgvProductGroup.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductGroup_RowValidating);
            this.dgvProductGroup.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvProductGroup_CellParsing);
            this.dgvProductGroup.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductGroup_CellValidating);
            this.dgvProductGroup.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductGroup_CellEndEdit);
            this.dgvProductGroup.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductGroup_DataError);
            // 
            // bindingSourceProductGroup
            // 
            this.bindingSourceProductGroup.AllowNew = true;
            this.bindingSourceProductGroup.DataSource = typeof(PWC.BusinessObject.ProductGroup.ParameteredCollection);
            // 
            // chkUseClipboardDataOnNewRow
            // 
            this.chkUseClipboardDataOnNewRow.AutoSize = true;
            this.chkUseClipboardDataOnNewRow.Location = new System.Drawing.Point(409, 67);
            this.chkUseClipboardDataOnNewRow.Name = "chkUseClipboardDataOnNewRow";
            this.chkUseClipboardDataOnNewRow.Size = new System.Drawing.Size(183, 17);
            this.chkUseClipboardDataOnNewRow.TabIndex = 10;
            this.chkUseClipboardDataOnNewRow.Text = "Use Clipboard Data on New Row";
            this.chkUseClipboardDataOnNewRow.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Maximum number of rows returned is 300.";
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "BrandCode";
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.Width = 120;
            // 
            // ProductCategory
            // 
            this.ProductCategory.DataPropertyName = "ProductCategoryCode";
            this.ProductCategory.HeaderText = "Product Category";
            this.ProductCategory.Name = "ProductCategory";
            this.ProductCategory.Width = 120;
            // 
            // ProductGroupCode
            // 
            this.ProductGroupCode.DataPropertyName = "ProductGroupCode";
            this.ProductGroupCode.HeaderText = "Product Group Code";
            this.ProductGroupCode.MaxInputLength = 4;
            this.ProductGroupCode.Name = "ProductGroupCode";
            this.ProductGroupCode.ReadOnly = true;
            this.ProductGroupCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductGroupCode.Width = 70;
            // 
            // ProductGroupDescription
            // 
            this.ProductGroupDescription.DataPropertyName = "ProductGroupDescription";
            this.ProductGroupDescription.HeaderText = "Description";
            this.ProductGroupDescription.MaxInputLength = 100;
            this.ProductGroupDescription.Name = "ProductGroupDescription";
            this.ProductGroupDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductGroupDescription.Width = 200;
            // 
            // objectKeyDataGridViewTextBoxColumn
            // 
            this.objectKeyDataGridViewTextBoxColumn.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.Name = "objectKeyDataGridViewTextBoxColumn";
            this.objectKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmProductGroup
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 436);
            this.Controls.Add(this.chkUseClipboardDataOnNewRow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvProductGroup);
            this.Controls.Add(this.txtProductGroupDescription);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProductCategory);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cboBrand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductGroup";
            this.Text = "Product Group";
            this.Load += new System.EventHandler(this.frmProductGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProductCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtProductGroupDescription;
        private System.Windows.Forms.DataGridView dgvProductGroup;
        private System.Windows.Forms.BindingSource bindingSourceProductGroup;
        private System.Windows.Forms.CheckBox chkUseClipboardDataOnNewRow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Brand;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGroupDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn;
    }
}