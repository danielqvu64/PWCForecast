using System;
using System.Data.SqlTypes;
using System.Text;
using System.Windows.Forms;
using PWC.BusinessObject;
using DVu.Library.PersistenceLayer;

namespace PWC.Forecast
{
    public partial class frmProductCategory : Form
    {
        private ProductCategory.ParameteredCollection _productCategoryCollection;

        public frmProductCategory()
        {
            InitializeComponent();
        }

        private void frmProductCategory_Load(object sender, EventArgs e)
        {
            _productCategoryCollection = new ProductCategory.ParameteredCollection();
            bindingSourceProductCategory.DataSource = _productCategoryCollection;
        }

        private void txtProductCategoryCode_GotFocus(object sender, System.EventArgs e)
        {
            txtProductCategoryCode.SelectAll();
        }

        private void txtProductCategoryDescription_GotFocus(object sender, System.EventArgs e)
        {
            txtProductCategoryDescription.SelectAll();
        }

        private void dgvProductCategory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvProductCategory.Columns[e.ColumnIndex].Name != "ProductCategoryCode")
                    return;
                if (e.RowIndex < _productCategoryCollection.Count)
                {
                    e.Cancel = true;
                    return;
                }
                if (!chkUseClipboardDataOnNewRow.Checked)
                    return;
                var values = Clipboard.GetText().Split('\t');
                var newRow = dgvProductCategory.Rows[e.RowIndex];
                if (values.Length != newRow.Cells.Count)
                    return;
                for (var sourceRowIndex = 0; sourceRowIndex < dgvProductCategory.Rows.Count; sourceRowIndex++)
                    if (dgvProductCategory.Rows[sourceRowIndex].Cells["ProductCategoryCode"].Value != null &&
                        values[1].IndexOf(dgvProductCategory.Rows[sourceRowIndex].Cells["ProductCategoryCode"].Value.ToString()) > -1)
                    {
                        var sourceRow = dgvProductCategory.Rows[sourceRowIndex];
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

        private void dgvProductCategory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvProductCategory.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductCategory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null || e.Value == null)
                return;
            try
            {
                // default parsing fails to convert string to sqlstring
                // assist it here.
                e.Value = new SqlString(e.Value.ToString());
                e.ParsingApplied = true;
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

        private void dgvProductCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvProductCategory.IsCurrentCellDirty)
                    return;
                if (e.FormattedValue == null)
                {
                    dgvProductCategory.Rows[e.RowIndex].ErrorText = "Entry is required";
                    e.Cancel = true;
                    return;
                }
                if (dgvProductCategory.Columns[e.ColumnIndex].Name != "ProductCategoryCode")
                    return;
                var rx = new System.Text.RegularExpressions.Regex(@"^\d{2}$");
                var formattedValue = e.FormattedValue.ToString();
                if (!rx.IsMatch(formattedValue))
                {
                    dgvProductCategory.Rows[e.RowIndex].ErrorText = "Please enter Product Category Code in ##";
                    e.Cancel = true;
                    return;
                }
                var checkProductCategoryCollection = new ProductCategory.ParameteredCollection(formattedValue, SqlString.Null);
                checkProductCategoryCollection.Load();
                if (checkProductCategoryCollection.Count > 0)
                {
                    dgvProductCategory.Rows[e.RowIndex].ErrorText = "Product Category already exists";
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductCategory_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dgvProductCategory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvProductCategory.IsCurrentRowDirty)
                    return;

                if (dgvProductCategory.CurrentRow.Cells["ProductCategoryCode"].Value != null)
                {
                    SqlString productCategoryCode = dgvProductCategory.CurrentRow.Cells["ProductCategoryCode"].Value.ToString();
                    if (productCategoryCode.IsNull)
                    {
                        dgvProductCategory.Rows[e.RowIndex].ErrorText = "Product Category Code is required";
                        e.Cancel = true;
                        return;
                    }
                    var rx = new System.Text.RegularExpressions.Regex(@"^\d{2}$");
                    if (!rx.IsMatch(productCategoryCode.Value))
                    {
                        dgvProductCategory.Rows[e.RowIndex].ErrorText = "Please enter Product Category Code in ##";
                        e.Cancel = true;
                        return;
                    }
                    ProductCategory productCategory = null;
                    // new record
                    if (e.RowIndex >= _productCategoryCollection.Count)
                    {
                        var checkProductCategoryCollection = new ProductCategory.ParameteredCollection(productCategoryCode, SqlString.Null);
                        checkProductCategoryCollection.Load();
                        if (checkProductCategoryCollection.Count > 0)
                        {
                            dgvProductCategory.Rows[e.RowIndex].ErrorText = "Product Category already exists";
                            e.Cancel = true;
                        }
                        else
                        {
                            productCategory = _productCategoryCollection.Create(new ProductCategoryKey(productCategoryCode));
                            if (dgvProductCategory.CurrentRow.Cells["ProductCategoryDescription"].Value != null)
                                productCategory.ProductCategoryDescription = (SqlString)(dgvProductCategory.CurrentRow.Cells["ProductCategoryDescription"].Value);
                            _productCategoryCollection.Save(productCategory);
                            // when the initial collection is empty
                            // 1. productCategory in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                            // 2. the data moves above need to check for null
                            if (bindingSourceProductCategory.Count == 1)
                            {
                                bindingSourceProductCategory.DataSource = null;
                                bindingSourceProductCategory.DataSource = _productCategoryCollection;
                            }
                            else
                                bindingSourceProductCategory.List[bindingSourceProductCategory.Count - 1] = productCategory;
                        }
                    }
                    // existing record
                    else
                    {
                        //productCategory = _productCategoryCollection[new ProductCategoryKey(productCategoryCode)];
                        //productCategory.Save();
                        productCategory = (ProductCategory)dgvProductCategory.CurrentRow.DataBoundItem;
                        _productCategoryCollection.Save(productCategory);
                        _productCategoryCollection[new ProductCategoryKey(productCategoryCode)] = productCategory;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvProductCategory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string productCategoryCode = e.Row.Cells["ProductCategoryCode"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm deletion for Product Category Code: {0}.", productCategoryCode), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                    _productCategoryCollection.Delete(new ProductCategoryKey(productCategoryCode));
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _productCategoryCollection = new ProductCategory.ParameteredCollection(txtProductCategoryCode.Text == string.Empty ? SqlString.Null : txtProductCategoryCode.Text,
                txtProductCategoryDescription.Text == string.Empty ? SqlString.Null : txtProductCategoryDescription.Text);
            _productCategoryCollection.Load();
            bindingSourceProductCategory.DataSource = _productCategoryCollection;
        }
    }
}
