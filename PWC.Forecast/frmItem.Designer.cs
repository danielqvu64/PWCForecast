namespace PWC.Forecast
{
    partial class frmItem
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
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.bindingSourceItem = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseClipboardDataOnNewRow = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProductGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProductCategory = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.ItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Location = new System.Drawing.Point(324, 12);
            this.txtItemDescription.MaxLength = 100;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(187, 20);
            this.txtItemDescription.TabIndex = 4;
            this.txtItemDescription.GotFocus += new System.EventHandler(this.txtItemDescription_GotFocus);
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Location = new System.Drawing.Point(95, 12);
            this.txtItemNumber.MaxLength = 11;
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.Size = new System.Drawing.Size(69, 20);
            this.txtItemNumber.TabIndex = 2;
            this.txtItemNumber.GotFocus += new System.EventHandler(this.txtItemNumber_GotFocus);
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(16, 17);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(40, 13);
            this.lblItemNumber.TabIndex = 1;
            this.lblItemNumber.Text = "Item #:";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Location = new System.Drawing.Point(259, 15);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(63, 13);
            this.lblItemDescription.TabIndex = 3;
            this.lblItemDescription.Text = "Description:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(449, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvItem
            // 
            this.dgvItem.AutoGenerateColumns = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumber,
            this.ItemDescription,
            this.ProductGroup,
            this.objectKeyDataGridViewTextBoxColumn});
            this.dgvItem.DataSource = this.bindingSourceItem;
            this.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvItem.Location = new System.Drawing.Point(15, 117);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Size = new System.Drawing.Size(512, 302);
            this.dgvItem.TabIndex = 14;
            this.dgvItem.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvItem_UserDeletingRow);
            this.dgvItem.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItem_CellBeginEdit);
            this.dgvItem.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItem_RowValidating);
            this.dgvItem.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvItem_CellParsing);
            this.dgvItem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvItem_CellValidating);
            this.dgvItem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellEndEdit);
            this.dgvItem.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItem_EditingControlShowing);
            this.dgvItem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItem_DataError);
            // 
            // bindingSourceItem
            // 
            this.bindingSourceItem.AllowNew = true;
            this.bindingSourceItem.DataSource = typeof(PWC.BusinessObject.Item.ParameteredCollection);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Maximum number of rows returned is 300.";
            // 
            // chkUseClipboardDataOnNewRow
            // 
            this.chkUseClipboardDataOnNewRow.AutoSize = true;
            this.chkUseClipboardDataOnNewRow.Location = new System.Drawing.Point(344, 94);
            this.chkUseClipboardDataOnNewRow.Name = "chkUseClipboardDataOnNewRow";
            this.chkUseClipboardDataOnNewRow.Size = new System.Drawing.Size(183, 17);
            this.chkUseClipboardDataOnNewRow.TabIndex = 13;
            this.chkUseClipboardDataOnNewRow.Text = "Use Clipboard Data on New Row";
            this.chkUseClipboardDataOnNewRow.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Group:";
            // 
            // cboProductGroup
            // 
            this.cboProductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductGroup.FormattingEnabled = true;
            this.cboProductGroup.ItemHeight = 13;
            this.cboProductGroup.Location = new System.Drawing.Point(95, 65);
            this.cboProductGroup.Name = "cboProductGroup";
            this.cboProductGroup.Size = new System.Drawing.Size(227, 21);
            this.cboProductGroup.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Product Category:";
            // 
            // cboProductCategory
            // 
            this.cboProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductCategory.FormattingEnabled = true;
            this.cboProductCategory.ItemHeight = 13;
            this.cboProductCategory.Location = new System.Drawing.Point(324, 37);
            this.cboProductCategory.Name = "cboProductCategory";
            this.cboProductCategory.Size = new System.Drawing.Size(120, 21);
            this.cboProductCategory.TabIndex = 8;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(16, 43);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 5;
            this.lblBrand.Text = "Brand:";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.ItemHeight = 13;
            this.cboBrand.Location = new System.Drawing.Point(95, 38);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(120, 21);
            this.cboBrand.TabIndex = 6;
            // 
            // ItemNumber
            // 
            this.ItemNumber.DataPropertyName = "ItemNumber";
            this.ItemNumber.HeaderText = "Item #";
            this.ItemNumber.MaxInputLength = 11;
            this.ItemNumber.Name = "ItemNumber";
            this.ItemNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemNumber.Width = 70;
            // 
            // ItemDescription
            // 
            this.ItemDescription.DataPropertyName = "ItemDescription";
            this.ItemDescription.HeaderText = "Description";
            this.ItemDescription.MaxInputLength = 100;
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemDescription.Width = 220;
            // 
            // ProductGroup
            // 
            this.ProductGroup.DataPropertyName = "ProductGroupCodeBinding";
            this.ProductGroup.HeaderText = "Product Group";
            this.ProductGroup.Name = "ProductGroup";
            this.ProductGroup.Width = 150;
            // 
            // objectKeyDataGridViewTextBoxColumn
            // 
            this.objectKeyDataGridViewTextBoxColumn.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.Name = "objectKeyDataGridViewTextBoxColumn";
            this.objectKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmItem
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 436);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboProductCategory);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProductGroup);
            this.Controls.Add(this.chkUseClipboardDataOnNewRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblItemDescription);
            this.Controls.Add(this.txtItemNumber);
            this.Controls.Add(this.lblItemNumber);
            this.Controls.Add(this.txtItemDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItem";
            this.Text = "Item";
            this.Load += new System.EventHandler(this.frmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.BindingSource bindingSourceItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUseClipboardDataOnNewRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProductGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProductCategory;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn;
    }
}