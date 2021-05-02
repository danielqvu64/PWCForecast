using System;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmBonusAndDiscontinuedExport : Form
    {
        private Company _company;
        private CustomerKey _customerKey;
        private ExportType _exportType;
        
        public frmBonusAndDiscontinuedExport(Company company, CustomerKey customerKey, ExportType exportType)
        {
            InitializeComponent();
            this._company = company;
            this._customerKey = customerKey;
            this._exportType = exportType;
        }

        private void frmBonusAndDiscontinuedExport_Load(object sender, EventArgs e)
        {
            try
            {
                cboCustomer.ValueMember = "Code";
                cboCustomer.DisplayMember = "CodeDescription";
                if (_exportType == ExportType.Bonus)
                {
                    this.Text = "Export Bonus Items";
                    txtFilePath.Text = ConfigurationManager.AppSettings["ExportBonusFilePath"];
                }
                else
                {
                    this.Text = "Export Discontinued Items";
                    txtFilePath.Text = ConfigurationManager.AppSettings["ExportDiscontinuedFilePath"];
                }
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
            try
            {
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                if (chkByCustomer.Checked && _customerKey == null)
                {
                    MessageBox.Show("Please select a Customer.", "PWC Forecast");
                    cboCustomer.Focus();
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
                if (chkByCustomer.Checked)
                    _company.CustomerCollection[_customerKey].ExportBonusAndDiscontinued(_exportType, txtFilePath.Text, chkAppendFile.Checked);
                else
                    _company.ExportBonusAndDiscontinued(_exportType, txtFilePath.Text, chkAppendFile.Checked);
                if (_exportType == ExportType.Bonus && txtFilePath.Text != ConfigurationManager.AppSettings["ExportBonusFilePath"])
                    Utility.GetInstance().SaveSetting("ExportBonusFilePath", txtFilePath.Text);
                else if (_exportType == ExportType.Discontinued && txtFilePath.Text != ConfigurationManager.AppSettings["ExportDiscontinuedFilePath"])
                    Utility.GetInstance().SaveSetting("ExportDiscontinuedFilePath", txtFilePath.Text);
                progressBar1.Visible = false;
                this.Cursor = Cursors.Arrow;
                Close();
                Dispose();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
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

        private void frmBonusAndDiscontinuedExport_FormClosing(object sender, FormClosingEventArgs e)
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
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void chkByCustomer_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomer.Visible = chkByCustomer.Checked;
            cboCustomer.Visible = chkByCustomer.Checked;
        }
    }
}
