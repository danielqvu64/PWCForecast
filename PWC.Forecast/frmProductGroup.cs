using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PWC.BusinessObject;
using DVu.Library.PersistenceLayer;

namespace PWC.Forecast
{
    public partial class frmProductGroup : Form
    {
        private ProductGroup.ParameteredCollection _productGroupCollection;
        private readonly List<DropDownItem> _brandDropDownCollection = Utility.GetInstance().GetBrandDropDownCollection();
        private readonly List<DropDownItem> _productCategoryDropDownCollection = Utility.GetInstance().GetProductCategoryDropDownCollection();
        private readonly List<DropDownItem> _brandDropDownCollection2 = Utility.GetInstance().GetBrandDropDownCollection();
        private readonly List<DropDownItem> _productCategoryDropDownCollection2 = Utility.GetInstance().GetProductCategoryDropDownCollection();
        public delegate void ProductGroupCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event ProductGroupCollectionInvalidatedDelegate ProductGroupCollectionInvalidated;

        public frmProductGroup()
        {
            InitializeComponent();
        }

        private void frmProductGroup_Load(object sender, EventArgs e)
        {
            _productGroupCollection = new ProductGroup.ParameteredCollection();
            bindingSourceProductGroup.DataSource = _productGroupCollection;
            cboBrand.ValueMember = "Code";
            cboBrand.DisplayMember = "CodeDescription";
            cboBrand.DataSource = _brandDropDownCollection2;
            cboProductCategory.ValueMember = "Code";
            cboProductCategory.DisplayMember = "CodeDescription";
            cboProductCategory.DataSource = _productCategoryDropDownCollection2;
            ((DataGridViewComboBoxColumn)dgvProductGroup.Columns["Brand"]).DataSource = _brandDropDownCollection;
            ((DataGridViewComboBoxColumn)dgvProductGroup.Columns["Brand"]).DisplayMember = "CodeDescription";
            ((DataGridViewComboBoxColumn)dgvProductGroup.Columns["Brand"]).ValueMember = "Code";
            ((DataGridViewComboBoxColumn)dgvProductGroup.Columns["ProductCategory"]).DataSource = _productCategoryDropDownCollection;
            ((DataGridViewComboBoxColumn)dgvProductGroup.Columns["ProductCategory"]).DisplayMember = "CodeDescription";
            ((DataGridViewComboBoxColumn)dgvProductGroup.Columns["ProductCategory"]).ValueMember = "Code";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _productGroupCollection = new ProductGroup.ParameteredCollection(SqlString.Null,
                cboBrand.SelectedIndex < 1 ? SqlString.Null : cboBrand.SelectedValue.ToString(),
                cboProductCategory.SelectedIndex < 1 ? SqlString.Null : cboProductCategory.SelectedValue.ToString(),
                txtProductGroupDescription.Text == string.Empty ? SqlString.Null : txtProductGroupDescription.Text);
            _productGroupCollection.Load();
            bindingSourceProductGroup.DataSource = _productGroupCollection;
        }

        private void dgvProductGroup_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvProductGroup.Columns[e.ColumnIndex].Name != "Brand" &&
                    dgvProductGroup.Columns[e.ColumnIndex].Name != "ProductCategory")
                    return;
                if (e.RowIndex < _productGroupCollection.Count)
                {
                    e.Cancel = true;
                    return;
                }
                if (!chkUseClipboardDataOnNewRow.Checked)
                    return;
                var values = Clipboard.GetText().Split('\t');
                var newRow = dgvProductGroup.Rows[e.RowIndex];
                if (values.Length != newRow.Cells.Count)
                    return;
                for (var sourceRowIndex = 0; sourceRowIndex < dgvProductGroup.Rows.Count; sourceRowIndex++)
                    if (dgvProductGroup.Rows[sourceRowIndex].Cells["ProductGroupCode"].Value != null &&
                        values[3].IndexOf(dgvProductGroup.Rows[sourceRowIndex].Cells["ProductGroupCode"].Value.ToString()) > -1)
                    {
                        var sourceRow = dgvProductGroup.Rows[sourceRowIndex];
                        for (var cellIndex = 0; cellIndex < newRow.Cells.Count; cellIndex++)
                            newRow.Cells[cellIndex].Value = sourceRow.Cells[cellIndex].Value;
                        break;
                    }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductGroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvProductGroup.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductGroup_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null || e.Value == null)
                return;
            try
            {
                // default parsing fails to convert string to sqlstring
                // assist it here.
                if (dgvProductGroup.Columns[e.ColumnIndex].Name == "ProductGroupDescription")
                {
                    e.Value = new SqlString(e.Value.ToString());
                    e.ParsingApplied = true;
                }
            }
            catch (FormatException)
            {
                // Set to false in case another CellParsing handler
                // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                e.ParsingApplied = false;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductGroup_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvProductGroup.IsCurrentCellDirty)
                    return;
                if (e.FormattedValue == null)
                {
                    dgvProductGroup.Rows[e.RowIndex].ErrorText = "Entry is required";
                    e.Cancel = true;
                }
                else
                {
                    if (dgvProductGroup.Columns[e.ColumnIndex].Name == "Brand" &&
                        dgvProductGroup.Rows[e.RowIndex].Cells["ProductCategory"].Value != null)
                    {
                        var formattedValue = e.FormattedValue.ToString();
                        var productCategoryCode = dgvProductGroup.Rows[e.RowIndex].Cells["ProductCategory"].Value.ToString();
                        if (formattedValue != "<< select >>" && productCategoryCode != string.Empty)
                            dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value = (SqlString)string.Format("{0}{1}", formattedValue.Substring(0, 2), productCategoryCode);
                    }
                    else if (dgvProductGroup.Columns[e.ColumnIndex].Name == "ProductCategory" &&
                        dgvProductGroup.Rows[e.RowIndex].Cells["Brand"].Value != null)
                    {
                        var formattedValue = e.FormattedValue.ToString();
                        var brandCode = dgvProductGroup.Rows[e.RowIndex].Cells["Brand"].Value.ToString();

                        if (formattedValue != "<< select >>" && brandCode != string.Empty)
                            dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value = (SqlString)string.Format("{0}{1}", brandCode, formattedValue.Substring(0, 2));
                    }
                    if ((dgvProductGroup.Columns[e.ColumnIndex].Name == "Brand" ||
                        dgvProductGroup.Columns[e.ColumnIndex].Name == "ProductCategory") &&
                        dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value != null &&
                        dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value.ToString() != "Null")
                    {
                        var checkProductGroupCollection = new ProductGroup.ParameteredCollection((SqlString)dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value, SqlString.Null, SqlString.Null, SqlString.Null);
                        checkProductGroupCollection.Load();
                        if (checkProductGroupCollection.Count > 0)
                        {
                            dgvProductGroup.Rows[e.RowIndex].ErrorText = "Product Group already exists";
                            e.Cancel = true;
                        }
                        if (dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value != null)
                        {
                            var brandCode = dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value.ToString().Substring(0, 2);
                            var productCategoryCode = dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupCode"].Value.ToString().Substring(2, 2);
                            dgvProductGroup.Rows[e.RowIndex].Cells["ProductGroupDescription"].Value = (SqlString)string.Format("{0} - {1}",
                                GetDescription(_brandDropDownCollection, brandCode),
                                GetDescription(_productCategoryDropDownCollection, productCategoryCode));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private static string GetDescription(IEnumerable<DropDownItem> collection, string code)
        {
            var description = string.Empty;
            foreach (var item in collection.Where(item => item.Code == code))
            {
                description = item.Description;
                break;
            }
            return description;
        }

        private void dgvProductGroup_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvProductGroup.IsCurrentRowDirty)
                    return;

                if (dgvProductGroup.CurrentRow.Cells["ProductGroupCode"].Value != null)
                {
                    SqlString productGroupCode = dgvProductGroup.CurrentRow.Cells["ProductGroupCode"].Value.ToString();
                    if (productGroupCode.IsNull)
                    {
                        dgvProductGroup.Rows[e.RowIndex].ErrorText = "Please select Brand and Product Category";
                        e.Cancel = true;
                        return;
                    }
                    ProductGroup productGroup = null;
                    // new record
                    if (e.RowIndex >= _productGroupCollection.Count)
                    {
                        var checkProductGroupCollection = new ProductGroup.ParameteredCollection(productGroupCode, SqlString.Null, SqlString.Null, SqlString.Null);
                        checkProductGroupCollection.Load();
                        if (checkProductGroupCollection.Count > 0)
                        {
                            dgvProductGroup.Rows[e.RowIndex].ErrorText = "Product Group Code already exists";
                            e.Cancel = true;
                        }
                        else
                        {
                            productGroup = _productGroupCollection.Create(new ProductGroupKey(productGroupCode));
                            if (dgvProductGroup.CurrentRow.Cells["ProductGroupDescription"].Value != null)
                                productGroup.ProductGroupDescription = (SqlString)dgvProductGroup.CurrentRow.Cells["ProductGroupDescription"].Value;
                            _productGroupCollection.Save(productGroup);
                            // when the initial collection is empty
                            // 1. brand in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                            // 2. the data moves above need to check for null
                            if (bindingSourceProductGroup.Count == 1)
                            {
                                bindingSourceProductGroup.DataSource = null;
                                bindingSourceProductGroup.DataSource = _productGroupCollection;
                            }
                            else
                                bindingSourceProductGroup.List[bindingSourceProductGroup.Count - 1] = productGroup;
                        }
                    }
                    // existing record
                    else
                    {
                        //productGroup = _productGroupCollection[new ProductGroupKey(productGroupCode)];
                        //productGroup.Save();
                        productGroup = (ProductGroup)dgvProductGroup.CurrentRow.DataBoundItem;
                        _productGroupCollection.Save(productGroup);
                        _productGroupCollection[new ProductGroupKey(productGroupCode)] = productGroup;
                    }
                    if (ProductGroupCollectionInvalidated != null)
                        ProductGroupCollectionInvalidated(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductGroup_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var productGroupCode = e.Row.Cells["ProductGroupCode"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm deletion for Product Group Code: {0}.", productGroupCode), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                {
                    _productGroupCollection.Delete(new ProductGroupKey(productGroupCode));
                    if (ProductGroupCollectionInvalidated != null)
                        ProductGroupCollectionInvalidated(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductGroup_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                var additionalData = new StringBuilder("Context: ");
                additionalData.Append(e.Context.ToString()).Append("\n");
                additionalData.Append("RowIndex: ").Append(e.RowIndex.ToString()).Append("\n");
                additionalData.Append("ColumnIndex: ").Append(e.ColumnIndex.ToString());
                PersistenceFacade.GetInstance().LogException(e.Exception, Environment.MachineName, additionalData.ToString());
                e.ThrowException = true;
            }
        }
    }
}
