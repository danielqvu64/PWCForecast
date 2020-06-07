using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using PWC.BusinessObject;
using DVu.Library.PersistenceLayer;

namespace PWC.Forecast
{
    public partial class frmBrand : Form
    {
        private Brand.ParameteredCollection _brandCollection;

        public frmBrand()
        {
            InitializeComponent();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            _brandCollection = new Brand.ParameteredCollection();
            bindingSourceBrand.DataSource = _brandCollection;
        }

        private void txtBrandCode_GotFocus(object sender, System.EventArgs e)
        {
            txtBrandCode.SelectAll();
        }

        private void txtBrandDescription_GotFocus(object sender, System.EventArgs e)
        {
            txtBrandDescription.SelectAll();
        }

        private void dgvBrand_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvBrand.Columns[e.ColumnIndex].Name == "BrandCode")
                {
                    if (e.RowIndex < _brandCollection.Count)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (chkUseClipboardDataOnNewRow.Checked)
                    {
                        var values = Clipboard.GetText().Split('\t');
                        var newRow = dgvBrand.Rows[e.RowIndex];
                        if (values.Length == newRow.Cells.Count)
                        {
                            for (var sourceRowIndex = 0; sourceRowIndex < dgvBrand.Rows.Count; sourceRowIndex++)
                                if (dgvBrand.Rows[sourceRowIndex].Cells["BrandCode"].Value != null &&
                                    values[1].IndexOf(dgvBrand.Rows[sourceRowIndex].Cells["BrandCode"].Value.ToString(), StringComparison.Ordinal) > -1)
                                {
                                    var sourceRow = dgvBrand.Rows[sourceRowIndex];
                                    for (var cellIndex = 0; cellIndex < newRow.Cells.Count; cellIndex++)
                                        newRow.Cells[cellIndex].Value = sourceRow.Cells[cellIndex].Value;
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBrand_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvBrand.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBrand_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (e != null && e.Value != null)
                {
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
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBrand_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvBrand.IsCurrentCellDirty)
                    return;
                if (e.FormattedValue == null)
                {
                    dgvBrand.Rows[e.RowIndex].ErrorText = "Entry is required";
                    e.Cancel = true;
                }
                else
                {
                    if (dgvBrand.Columns[e.ColumnIndex].Name == "BrandCode")
                    {
                        var rx = new System.Text.RegularExpressions.Regex(@"^\d{2}$");
                        var formattedValue = e.FormattedValue.ToString();
                        if (!rx.IsMatch(formattedValue))
                        {
                            dgvBrand.Rows[e.RowIndex].ErrorText = "Please enter Brand Code in ##";
                            e.Cancel = true;
                        }
                        else
                        {
                            var checkBrandCollection = new Brand.ParameteredCollection(formattedValue, SqlString.Null);
                            checkBrandCollection.Load();
                            if (checkBrandCollection.Count > 0)
                            {
                                dgvBrand.Rows[e.RowIndex].ErrorText = "Brand already exists";
                                e.Cancel = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBrand_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception == null)
                return;
            var additionalData = new StringBuilder("Context: ");
            additionalData.Append(e.Context.ToString()).Append("\n");
            additionalData.Append("RowIndex: ").Append(e.RowIndex.ToString(CultureInfo.InvariantCulture)).Append("\n");
            additionalData.Append("ColumnIndex: ").Append(e.ColumnIndex.ToString(CultureInfo.InvariantCulture));
            PersistenceFacade.GetInstance().LogException(e.Exception, Environment.MachineName, additionalData.ToString());
            e.ThrowException = true;
        }

        private void dgvBrand_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvBrand.IsCurrentRowDirty)
                    return;

                if (dgvBrand.CurrentRow.Cells["BrandCode"].Value == null)
                    return;

                var brandCode = (SqlString) dgvBrand.CurrentRow.Cells["BrandCode"].Value;
                if (brandCode.IsNull)
                {
                    dgvBrand.Rows[e.RowIndex].ErrorText = "Brand Code is required";
                    e.Cancel = true;
                    return;
                }
                var rx = new System.Text.RegularExpressions.Regex(@"^\d{2}$");
                if (!rx.IsMatch(brandCode.Value))
                {
                    dgvBrand.Rows[e.RowIndex].ErrorText = "Please enter Brand Code in ##";
                    e.Cancel = true;
                    return;
                }
                Brand brand;
                // new record
                if (e.RowIndex >= _brandCollection.Count)
                {
                    var checkBrandCollection = new Brand.ParameteredCollection(brandCode, SqlString.Null);
                    checkBrandCollection.Load();
                    if (checkBrandCollection.Count > 0)
                    {
                        dgvBrand.Rows[e.RowIndex].ErrorText = "Brand already exists";
                        e.Cancel = true;
                    }
                    else
                    {
                        brand = _brandCollection.Create(new BrandKey(brandCode));
                        if (dgvBrand.CurrentRow.Cells["BrandDescription"].Value != null)
                            brand.BrandDescription =
                                (SqlString) (dgvBrand.CurrentRow.Cells["BrandDescription"].Value);
                        _brandCollection.Save(brand);
                        // when the initial collection is empty
                        // 1. brand in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                        // 2. the data moves above need to check for null
                        if (bindingSourceBrand.Count == 1)
                        {
                            bindingSourceBrand.DataSource = null;
                            bindingSourceBrand.DataSource = _brandCollection;
                        }
                        else
                            bindingSourceBrand.List[bindingSourceBrand.Count - 1] = brand;
                    }
                }
                    // existing record
                else
                {
                    //brand = _brandCollection[new BrandKey(brandCode)];
                    //brand.Save();
                    brand = (Brand) dgvBrand.CurrentRow.DataBoundItem;
                    _brandCollection.Save(brand);
                    _brandCollection[new BrandKey(brandCode)] = brand;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBrand_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string brandCode = e.Row.Cells["BrandCode"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm deletion for Brand Code: {0}.", brandCode), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                    _brandCollection.Delete(new BrandKey(brandCode));
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _brandCollection = new Brand.ParameteredCollection(txtBrandCode.Text == string.Empty ? SqlString.Null : txtBrandCode.Text,
                txtBrandDescription.Text == string.Empty ? SqlString.Null : txtBrandDescription.Text);
            _brandCollection.Load();
            bindingSourceBrand.DataSource = _brandCollection;
        }
    }
}
