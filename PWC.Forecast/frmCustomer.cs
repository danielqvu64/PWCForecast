using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using PWC.BusinessObject;
using DVu.Library.PersistenceLayer;

namespace PWC.Forecast
{
    public partial class frmCustomer : Form
    {
        private Company _company;
        private readonly string _passedInCompanyCode = string.Empty;
        public delegate void CustomerCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event CustomerCollectionInvalidatedDelegate CustomerCollectionInvalidated;

        internal frmCustomer() { }

        public frmCustomer(Company company)
        {
            InitializeComponent();
            _company = company;
            if (company != null)
                _passedInCompanyCode = company.CompanyCode.Value;
        }

        private void frmPWCCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCustomer.DefaultCellStyle.NullValue = "Null";
                dgvCustomer.DefaultCellStyle.DataSourceNullValue = Convert.DBNull;
                if (_company != null)
                {
                    txtCompanyCode.Text = _company.CompanyCode.ToString();
                    txtCompanyName.Text = _company.CompanyName.ToString();
                }
                BindCustomer();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void BindCustomer()
        {
            bindingSourceCustomer.DataSource = _company != null ? _company.CustomerCollection : new Customer.WithCompanyParentCollection();
        }

        private void txtCompanyCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCompanyCode.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a Company Code.", "PWC Forecast");
                    e.Cancel = true;
                    return;
                }
                if ((_company != null && _company.CompanyCode != txtCompanyCode.Text) || _company == null)
                {
                    var companyCollection = new Company.ParameteredCollection(txtCompanyCode.Text);
                    companyCollection.Load();
                    if (companyCollection.Count == 0)
                    {
                        MessageBox.Show("Invalid Company Code.", "PWC Forecast");
                        e.Cancel = true;
                        return;
                    }
                    _company = companyCollection[0];
                    txtCompanyName.Text = _company.CompanyName.ToString();
                    BindCustomer();
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvCustomer_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "CustomerNumber")
                {
                    if (e.RowIndex < _company.CustomerCollection.Count)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (chkUseClipboardDataOnNewRow.Checked)
                    {
                        var values = Clipboard.GetText().Split('\t');
                        var newRow = dgvCustomer.Rows[e.RowIndex];
                        if (values.Length == newRow.Cells.Count)
                        {
                            for (var sourceRowIndex = 0; sourceRowIndex < dgvCustomer.Rows.Count; sourceRowIndex++)
                                if (dgvCustomer.Rows[sourceRowIndex].Cells["CustomerNumber"].Value != null &&
                                    values[1].IndexOf(dgvCustomer.Rows[sourceRowIndex].Cells["CustomerNumber"].Value.ToString(), StringComparison.Ordinal) > -1)
                                {
                                    var sourceRow = dgvCustomer.Rows[sourceRowIndex];
                                    for (int cellIndex = 0; cellIndex < newRow.Cells.Count; cellIndex++)
                                        newRow.Cells[cellIndex].Value = sourceRow.Cells[cellIndex].Value;
                                    break;
                                }
                        }
                    }
                }
                else if (dgvCustomer.Columns[e.ColumnIndex].Name == "InflateFactor" &&
                    dgvCustomer.Rows[e.RowIndex].Cells["ForecastMethod"].Value.ToString() != "SR")
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvCustomer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvCustomer.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0)
                    return;
                if (dgvCustomer.Columns[e.ColumnIndex].Name != "InflateFactor" || e.Value == null)
                    return;
                var decValue = (SqlDecimal)e.Value;
                e.Value = decValue.IsNull ? "Null" : decValue.Value.ToString("0.00");
                e.FormattingApplied = true;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void dgvCustomer_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (e != null && e.Value != null)
                {
                    try
                    {
                        var columnName = dgvCustomer.Columns[e.ColumnIndex].Name;
                        switch (columnName)
                        {
                            case "ForecastMethod":
                            case "CustomerName":
                            case "CustomerNumber":
                                // default parsing fails to convert string to sqlstring
                                // assist it here.
                                e.Value = new SqlString(e.Value.ToString());
                                e.ParsingApplied = true;
                                break;
                            case "InflateFactor":
                                if (e.Value.ToString() == "Null")
                                {
                                    e.Value = SqlDecimal.Null;
                                    e.ParsingApplied = true;
                                }
                                break;
                            case "ForecastFutureFrozenMonths":
                                if (e.Value.ToString() == "Null")
                                {
                                    e.Value = SqlInt16.Null;
                                    e.ParsingApplied = true;
                                }
                                break;
                        }
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

        private void dgvCustomer_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvCustomer.IsCurrentCellDirty)
                    return;
                if (e.FormattedValue == null)
                {
                    dgvCustomer.Rows[e.RowIndex].ErrorText = "Entry is required";
                    e.Cancel = true;
                    return;
                }
                var formattedValue = e.FormattedValue.ToString();
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "CustomerNumber")
                {
                    //System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(@"^\d{4}$");
                    //if (!rx.IsMatch(formattedValue))
                    //{
                    //    dgvCustomer.Rows[e.RowIndex].ErrorText = "Please enter Customer Number in ####";
                    //    e.Cancel = true;
                    //}
                    if (formattedValue.Length < 4 || formattedValue.Length > 10)
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Please enter 4 to 10 characters Customer Number";
                        e.Cancel = true;
                        return;
                    }
                    if (_company.CustomerCollection.ContainsKey(new CustomerKey(_company.CompanyCode, formattedValue)))
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Customer already exists for the Company";
                        e.Cancel = true;
                        return;
                    }
                    // set default values for ForecastFutureFrozenMonths and ForecastMethod
                    dgvCustomer.Rows[e.RowIndex].Cells["ForecastMethod"].Value = new SqlString("SR");
                    dgvCustomer.Rows[e.RowIndex].Cells["ForecastFutureFrozenMonths"].Value = SqlInt16.Zero;
                    //after setting default values, CustomerNumber looses its state, so set its current value
                    dgvCustomer.Rows[e.RowIndex].Cells["CustomerNumber"].Value = new SqlString(formattedValue);
                }
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "ForecastMethod")
                {
                    if (formattedValue.Length != 2 || "SR|RA".IndexOf(formattedValue, StringComparison.Ordinal) < 0)
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Please enter Forecast Method as SR or RA";
                        e.Cancel = true;
                        return;
                    }
                    if (formattedValue != "SR")
                    {
                        dgvCustomer.Rows[e.RowIndex].Cells["InflateFactor"].Value = SqlDecimal.Null;
                        //after setting InflateFactor value, ForecastMethod looses its state, so set its current value
                        dgvCustomer.Rows[e.RowIndex].Cells["ForecastMethod"].Value = new SqlString(formattedValue);
                    }
                }
                System.Text.RegularExpressions.Regex rx;
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "InflateFactor" &&
                    formattedValue != "Null")
                {
                    rx = new System.Text.RegularExpressions.Regex(@"^[+-]?\d{0,2}(\.\d{1,2})?$");
                    if (formattedValue == string.Empty || !rx.IsMatch(formattedValue))
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Please enter Inflate Percentage in (+/-)##.##";
                        e.Cancel = true;
                    }
                }
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "ForecastFutureFrozenMonths")
                {
                    if (formattedValue != "Null")
                    {
                        rx = new System.Text.RegularExpressions.Regex(@"^[+-]?[0-6]$");
                        if (formattedValue == string.Empty || !rx.IsMatch(formattedValue))
                        {
                            dgvCustomer.Rows[e.RowIndex].ErrorText = "Please enter Future Forecast Months in range -6 to 6";
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Null value is not allowed for Future Forecast Months";
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                var additionalData = new StringBuilder("Context: ");
                additionalData.Append(e.Context.ToString()).Append("\n");
                additionalData.Append("RowIndex: ").Append(e.RowIndex.ToString(CultureInfo.InvariantCulture)).Append("\n");
                additionalData.Append("ColumnIndex: ").Append(e.ColumnIndex.ToString(CultureInfo.InvariantCulture));
                PersistenceFacade.GetInstance().LogException(e.Exception, Environment.MachineName, additionalData.ToString());
                e.ThrowException = true;
            }
        }

        private void dgvCustomer_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvCustomer.IsCurrentRowDirty)
                    return;

                if (dgvCustomer.CurrentRow.Cells["CustomerNumber"].Value != null)
                {
                    SqlString customerNumber = dgvCustomer.CurrentRow.Cells["CustomerNumber"].Value.ToString();
                    if (customerNumber.IsNull)
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Customer Number is required";
                        e.Cancel = true;
                        return;
                    }
                    if (customerNumber.Value.Length < 4 || customerNumber.Value.Length > 10)
                    {
                        dgvCustomer.Rows[e.RowIndex].ErrorText = "Please enter 4 to 10 characters Customer Number";
                        e.Cancel = true;
                        return;
                    }
                    var customerKey = new CustomerKey(_company.CompanyCode, customerNumber);
                    Customer customer;
                    // new record
                    if (e.RowIndex >= _company.CustomerCollection.Count)
                    {
                        var checkCustomerCollection = new Customer.ParameteredCollection(_company.CompanyCode, customerNumber);
                        checkCustomerCollection.Load();
                        if (checkCustomerCollection.Count > 0)
                        {
                            dgvCustomer.Rows[e.RowIndex].ErrorText = "Customer already exists for the Company";
                            e.Cancel = true;
                        }
                        else
                        {
                            customer = _company.CustomerCollection.Create(customerKey);
                            customer.CustomerName = dgvCustomer.CurrentRow.Cells["CustomerName"].Value.ToString();
                            customer.ForecastMethod = dgvCustomer.CurrentRow.Cells["ForecastMethod"].Value.ToString();
                            customer.InflateFactor = (SqlDecimal)(dgvCustomer.CurrentRow.Cells["InflateFactor"].Value);
                            customer.ForecastFutureFrozenMonths = (SqlInt16)(dgvCustomer.CurrentRow.Cells["ForecastFutureFrozenMonths"].Value);
                            _company.CustomerCollection.Save(customer);
                            // when the initial collection is empty
                            // 1. item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                            // 2. the data moves above need to check for null
                            if (bindingSourceCustomer.Count == 1)
                            {
                                bindingSourceCustomer.DataSource = null;
                                bindingSourceCustomer.DataSource = _company.CustomerCollection;
                            }
                            else
                                bindingSourceCustomer.List[bindingSourceCustomer.Count - 1] = customer;
                        }
                    }
                    // existing record
                    else
                    {
                        //customer = _company.CustomerCollection[customerKey];
                        //customer.Save();
                        customer = (Customer)dgvCustomer.CurrentRow.DataBoundItem;
                        _company.CustomerCollection.Save(customer);
                        _company.CustomerCollection[customerKey] = customer;
                    }
                    if (CustomerCollectionInvalidated != null && _company.CompanyCode == _passedInCompanyCode)
                        CustomerCollectionInvalidated(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvCustomer_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var customerNumber = e.Row.Cells["CustomerNumber"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm deletion for Customer Number: {0}.", customerNumber), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                {
                    _company.CustomerCollection.Delete(new CustomerKey(_company.CompanyCode, customerNumber));
                    if (CustomerCollectionInvalidated != null && _company.CompanyCode == _passedInCompanyCode)
                        CustomerCollectionInvalidated(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvCustomer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                var tb = e.Control as TextBox;
                if (tb == null)
                    return;
                var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                tb.KeyPress -= keyPressEventHandler;
                if (dgvCustomer.Columns[dgvCustomer.CurrentCell.ColumnIndex].Name == "ForecastMethod")
                    tb.KeyPress += keyPressEventHandler;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void txtUpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char C = e.KeyChar;
            //if (Char.IsLetter(C) == true)
            //{
            //    e.Handled = true;
            //    System.Media.SystemSounds.Beep.Play();
            //}

            // upper case pipeline entry
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        
        private void txtCompanyCode_GotFocus(object sender, System.EventArgs e)
        {
            txtCompanyCode.SelectAll();
        }
    }
}