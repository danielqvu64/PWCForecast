using System;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmSalesRateExport : Form
    {
        private Company _company;
        private CustomerKey _customerKey;

        public frmSalesRateExport(Company company, CustomerKey customerKey)
        {
            InitializeComponent();
            this._company = company;
            this._customerKey = customerKey;
        }

        private void frmForecastExport_Load(object sender, EventArgs e)
        {
            try
            {
                cboCustomer.ValueMember = "Code";
                cboCustomer.DisplayMember = "CodeDescription";
                txtFilePath.Text = ConfigurationManager.AppSettings["ExportSalesRateFilePath"];
                if (_company != null)
                {
                    txtCompanyCode.Text = _company.CompanyCode.ToString();
                    txtCompanyName.Text = _company.CompanyName.ToString();
                    CustomerKey saveCustomerKey = _customerKey;
                    cboCustomer.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "default");
                    _customerKey = saveCustomerKey;
                    if (_customerKey != null)
                    {
                        for (int index = 1; index < cboCustomer.Items.Count; index++)
                            if (((DropDownItem)cboCustomer.Items[index]).Code == _customerKey.CustomerNumber)
                            {
                                cboCustomer.SelectedIndex = index;
                                break;
                            }
                        bindingSourceSavedSalesRate.DataSource = PWC.PersistenceLayer.Utility.GetInstance().GetSavedSalesRateDateCollection(_customerKey.CompanyCode.Value, _customerKey.CustomerNumber.Value, 12);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void txtCompanyCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCompanyCode.Text.Length == 3)
                {
                    if ((_company != null && _company.CompanyCode != txtCompanyCode.Text) ||
                        _company == null)
                    {
                        Company.ParameteredCollection companyCollection = new Company.ParameteredCollection(txtCompanyCode.Text);
                        companyCollection.Load();
                        if (companyCollection.Count == 0)
                        {
                            MessageBox.Show("Invalid Company Code.", "PWC Forecast");
                            _company = null;
                            e.Cancel = true;
                            return;
                        }
                        _company = companyCollection[0];
                        txtCompanyName.Text = _company.CompanyName.ToString();
                        cboCustomer.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "default");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ForecastSalesRate.WithCustomerParentParameteredCollection salesRateCollection = null;
            try
            {
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                if (_customerKey == null)
                {
                    MessageBox.Show("Please select a Customer.", "PWC Forecast");
                    cboCustomer.Focus();
                    return;
                }
                if (cboSavedSalesRate.SelectedIndex < 1)
                {
                    MessageBox.Show("Please select a Saved Sales Rate.", "PWC Forecast");
                    cboSavedSalesRate.Focus();
                    return;
                }
                if (!Directory.Exists(Path.GetDirectoryName(txtFilePath.Text)))
                {
                    MessageBox.Show("Export file folder does not exist. Please create the folder and try again.", "PWC Forecast");
                    txtFilePath.Focus();
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                progressBar1.Visible = true;
                Customer customer = _company.CustomerCollection[_customerKey];
                // save the current sales rate collection before execute export
                salesRateCollection = customer.ForecastSalesRateCollection;
                // execute export
                customer.ExportSalesRate(DateTime.Parse(cboSavedSalesRate.SelectedValue.ToString()), txtFilePath.Text, chkAppendFile.Checked);
                // restore the current sales rate collection after execute export
                customer.ForecastSalesRateCollection = salesRateCollection;
                if (txtFilePath.Text != ConfigurationManager.AppSettings["ExportSalesRateFilePath"])
                    Utility.GetInstance().SaveSetting("ExportSalesRateFilePath", txtFilePath.Text);
                progressBar1.Visible = false;
                this.Cursor = Cursors.Arrow;
                Close();
                Dispose();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
            finally
            {
                // restore the current forecast collection after execute export
                if (salesRateCollection != null && _customerKey != null)
                    _company.CustomerCollection[_customerKey].ForecastSalesRateCollection = salesRateCollection;
                progressBar1.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
                Dispose();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void txtFilePath_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Regex rx = new System.Text.RegularExpressions.Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)$?)(\\(\w[\w ].*))+(.csv|.CSV)$");
                if (!rx.IsMatch(txtFilePath.Text))
                {
                    MessageBox.Show("Please enter a valid .csv file path.", "PWC Forecast");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void txtFilePath_GotFocus(object sender, System.EventArgs e)
        {
            txtFilePath.SelectAll();
        }

        private void txtCompanyCode_GotFocus(object sender, System.EventArgs e)
        {
            txtCompanyCode.SelectAll();
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = ".csv";
                saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                FileInfo fileInfo = new FileInfo(txtFilePath.Text);
                saveFileDialog1.InitialDirectory = fileInfo.DirectoryName;
                saveFileDialog1.FileName = fileInfo.Name;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    txtFilePath.Text = saveFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void frmSalesRateForecastExport_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.None)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCustomer.SelectedIndex < 0)
                    return;
                string customerNumber = ((DropDownItem)cboCustomer.SelectedItem).Code;
                if (customerNumber == string.Empty)
                {
                    _customerKey = null;
                    return;
                }
                _customerKey = new CustomerKey(txtCompanyCode.Text, customerNumber);
                bindingSourceSavedSalesRate.DataSource = PWC.PersistenceLayer.Utility.GetInstance().GetSavedSalesRateDateCollection(txtCompanyCode.Text, customerNumber, 12);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
    }
}
