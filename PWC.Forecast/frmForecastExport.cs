using System;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmForecastExport : Form
    {
        private Company _company;

        public frmForecastExport(Company company)
        {
            InitializeComponent();
            this._company = company;
        }

        private void frmForecastExport_Load(object sender, EventArgs e)
        {
            try
            {
                txtFilePath.Text = ConfigurationManager.AppSettings["ExportForecastFilePath"];
                if (_company != null)
                {
                    txtCompanyCode.Text = _company.CompanyCode.ToString();
                    txtCompanyName.Text = _company.CompanyName.ToString();
                    bindingSourceSavedForecast.DataSource = PWC.PersistenceLayer.Utility.GetInstance().GetSavedForecastDateCollection(_company.CompanyCode, SqlString.Null, 12);
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
                            e.Cancel = true;
                            return;
                        }
                        _company = companyCollection[0];
                        txtCompanyName.Text = _company.CompanyName.ToString();
                        bindingSourceSavedForecast.DataSource = PWC.PersistenceLayer.Utility.GetInstance().GetSavedForecastDateCollection(_company.CompanyCode, SqlString.Null, 12);
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
                if (rbtnByDate.Checked && cboSavedForecast.SelectedIndex < 1)
                {
                    MessageBox.Show("Please select a Saved Forecast.", "PWC Forecast");
                    cboSavedForecast.Focus();
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
                ForecastExportType forecastReportType;
                if (rbtnPLCrossTab.Checked)
                    forecastReportType = ForecastExportType.PipelineCrosstab;
                else
                    forecastReportType = ForecastExportType.ToOracle;
                if (rbtnByDate.Checked)
                    _company.ExportForecast(DateTime.Parse(((PWC.PersistenceLayer.Utility.ForecastDateMethod)cboSavedForecast.SelectedItem).POSSalesEndDate), txtFilePath.Text, chkAppendFile.Checked, forecastReportType, chkSubtractCurrentMonthSales.Checked);
                else
                    _company.ExportForecast(txtFilePath.Text, chkAppendFile.Checked, forecastReportType, chkSubtractCurrentMonthSales.Checked);
                if (txtFilePath.Text != ConfigurationManager.AppSettings["ExportForecastFilePath"])
                    Utility.GetInstance().SaveSetting("ExportForecastFilePath", txtFilePath.Text);
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

        private void rbtnByDate_CheckedChanged(object sender, EventArgs e)
        {
            lblSavedForecast.Visible = rbtnByDate.Checked;
            cboSavedForecast.Visible = rbtnByDate.Checked;
        }

        private void rbtnPLCrossTab_CheckedChanged(object sender, EventArgs e)
        {
            chkSubtractCurrentMonthSales.Visible = !rbtnPLCrossTab.Checked;
        }
    }
}
