using System;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmForecastVarianceReport : Form
    {
        private Company _company;
        private CustomerKey _customerKey;

        public frmForecastVarianceReport(Company company, CustomerKey customerKey)
        {
            InitializeComponent();
            this._company = company;
            this._customerKey = customerKey;
        }

        private void frmForecastVarianceReport_Load(object sender, EventArgs e)
        {
            try
            {
                cboCustomerFrom.ValueMember = "Code";
                cboCustomerFrom.DisplayMember = "CodeDescription";
                cboBrandFrom.ValueMember = "Code";
                cboBrandFrom.DisplayMember = "CodeDescription";
                cboBrandFrom.DataSource = Utility.GetInstance().GetBrandDropDownCollection();
                cboProductCategoryFrom.ValueMember = "Code";
                cboProductCategoryFrom.DisplayMember = "CodeDescription";
                cboProductCategoryFrom.DataSource = Utility.GetInstance().GetProductCategoryDropDownCollection();
                cboCustomerTo.ValueMember = "Code";
                cboCustomerTo.DisplayMember = "CodeDescription";
                cboBrandTo.ValueMember = "Code";
                cboBrandTo.DisplayMember = "CodeDescription";
                cboBrandTo.DataSource = Utility.GetInstance().GetBrandDropDownCollection();
                cboProductCategoryTo.ValueMember = "Code";
                cboProductCategoryTo.DisplayMember = "CodeDescription";
                cboProductCategoryTo.DataSource = Utility.GetInstance().GetProductCategoryDropDownCollection();

                txtForecastYear.Text = DateTime.Today.Year.ToString("0000");
                txtFilePath.Text = ConfigurationManager.AppSettings["ReportForecastFilePath"];
                if (_company != null)
                {
                    txtCompanyCode.Text = _company.CompanyCode.ToString();
                    txtCompanyName.Text = _company.CompanyName.ToString();
                    CustomerKey saveCustomerKey = _customerKey;
                    cboCustomerFrom.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "CustomerNumber");
                    cboCustomerTo.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "CustomerNumber");
                    _customerKey = saveCustomerKey;
                    if (_customerKey != null)
                    {
                        for (int index = 1; index < cboCustomerFrom.Items.Count; index++)
                            if (((DropDownItem)cboCustomerFrom.Items[index]).Code == _customerKey.CustomerNumber)
                            {
                                cboCustomerFrom.SelectedIndex = index;
                                cboCustomerTo.SelectedIndex = index;
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                if (!chkPL.Checked && !chkSRRA.Checked)
                {
                    MessageBox.Show("Please select at least one Forecast Method check box.", "PWC Forecast");
                    chkSRRA.Focus();
                    return;
                }
                if (cboCustomerFrom.SelectedValue.ToString().CompareTo(cboCustomerTo.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Customer From must be less or equal Customer To.", "PWC Forecast");
                    cboCustomerFrom.Focus();
                    return;
                }
                if (cboBrandFrom.SelectedValue.ToString().CompareTo(cboBrandTo.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Brand From must be less or equal Brand To.", "PWC Forecast");
                    cboBrandFrom.Focus();
                    return;
                }
                if (cboProductCategoryFrom.SelectedValue.ToString().CompareTo(cboProductCategoryTo.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Product Category From must be less or equal Product Category To.", "PWC Forecast");
                    cboProductCategoryFrom.Focus();
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                progressBar1.Visible = true;
                StringBuilder forecastMethods = new StringBuilder();
                if (chkSRRA.Checked) forecastMethods.Append("|SR|RA");
                if (chkPL.Checked) forecastMethods.Append("|PL");
                _company.ReportForecast(txtFilePath.Text, 
                    chkAppendFile.Checked,
                    cboCustomerFrom.SelectedIndex == 0 ? SqlString.Null : cboCustomerFrom.SelectedValue.ToString(),
                    cboCustomerTo.SelectedIndex == 0 ? SqlString.Null : cboCustomerTo.SelectedValue.ToString(),
                    cboBrandFrom.SelectedIndex == 0 ? SqlString.Null : cboBrandFrom.SelectedValue.ToString(),
                    cboBrandTo.SelectedIndex == 0 ? SqlString.Null : cboBrandTo.SelectedValue.ToString(),
                    cboProductCategoryFrom.SelectedIndex == 0 ? SqlString.Null : cboProductCategoryFrom.SelectedValue.ToString(),
                    cboProductCategoryTo.SelectedIndex == 0 ? SqlString.Null : cboProductCategoryTo.SelectedValue.ToString(),
                    rbtnGroupByBrand.Checked ? ForecastReportGroupBy.Brand : ForecastReportGroupBy.Item,
                    forecastMethods.ToString(),
                    int.Parse(txtForecastYear.Text));
                if (txtFilePath.Text != ConfigurationManager.AppSettings["ReportForecastFilePath"])
                    Utility.GetInstance().SaveSetting("ReportForecastFilePath", txtFilePath.Text);
                progressBar1.Visible = false;
                this.Cursor = Cursors.Arrow;
                Close();
                Dispose();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
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
                            e.Cancel = true;
                            return;
                        }
                        _company = companyCollection[0];
                        txtCompanyName.Text = _company.CompanyName.ToString();
                        cboCustomerFrom.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "CustomerNumber");
                        cboCustomerTo.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "CustomerNumber");
                    }
                }
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
                Regex rx = new System.Text.RegularExpressions.Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)$?)(\\(\w[\w ].*))+(.csv|.CSV|.txt|.TXT|.prn|.PRN)$");
                if (!rx.IsMatch(txtFilePath.Text))
                {
                    MessageBox.Show("Please enter a valid text file path.", "PWC Forecast");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void txtForecastYear_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int forecastYear = int.Parse(txtForecastYear.Text);
                int maxYear = SqlDateTime.MaxValue.Value.Year;
                int minYear = SqlDateTime.MinValue.Value.Year;
                if (forecastYear > maxYear ||
                    forecastYear < minYear)
                {
                    MessageBox.Show(string.Format("Please enter year in range of {0} - {1}.", minYear, maxYear), "PWC Forecast");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        void txtCompanyCode_GotFocus(object sender, System.EventArgs e)
        {
            txtCompanyCode.SelectAll();
        }

        void txtFilePath_GotFocus(object sender, System.EventArgs e)
        {
            txtFilePath.SelectAll();
        }

        void txtForecastYear_GotFocus(object sender, System.EventArgs e)
        {
            txtForecastYear.SelectAll();
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = ".txt";
                saveFileDialog1.Filter = "Text Files (*.prn;*.txt;*.csv)|*.prn;*.txt;*.csv|All Files (*.*)|*.*";
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

        private void frmForecastVarianceReport_FormClosing(object sender, FormClosingEventArgs e)
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

    }
}
