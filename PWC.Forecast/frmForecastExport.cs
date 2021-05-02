using System;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PWC.BusinessObject;
using System.Text;

namespace PWC.Forecast
{
    public partial class frmForecastExport : Form
    {
        private Company _company;
        private Company.ParameteredCollection _companyCollection;

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
                if (txtCompanyCode.Text.Length != 3 && txtCompanyCode.Text.Length != 0)
                {
                    MessageBox.Show("An empty or 3 digit Company Code is expected.", "PWC Forecast");
                    e.Cancel = true;
                    return;
                }
                txtCompanyName.Text = string.Empty;
                _companyCollection = new Company.ParameteredCollection(txtCompanyCode.Text);
                _companyCollection.Load();
                if (txtCompanyCode.Text.Length == 3)
                {
                    if ((_company != null && _company.CompanyCode != txtCompanyCode.Text) ||
                        _company == null)
                    {
                        if (_companyCollection.Count == 0)
                        {
                            MessageBox.Show("Invalid Company Code.", "PWC Forecast");
                            e.Cancel = true;
                            return;
                        }
                        _company = _companyCollection[0];
                    }
                    txtCompanyName.Text = _company.CompanyName.ToString();
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
                if (!Directory.Exists(Path.GetDirectoryName(txtFilePath.Text)))
                {
                    MessageBox.Show("Export file folder does not exist. Please create the folder and try again.", "PWC Forecast");
                    txtFilePath.Focus();
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                progressBar1.Visible = true;

                ForecastExportType forecastExportType;
                if (rbtnToOracle.Checked)
                    forecastExportType = ForecastExportType.ToOracle;
                else
                    forecastExportType = ForecastExportType.ForEdit;

                var swForecast = new StreamWriter(txtFilePath.Text, chkAppendFile.Checked);
                StreamWriter swForecastComment = null;
                if (forecastExportType == ForecastExportType.ForEdit)
                {
                    swForecastComment = new StreamWriter(Customer.GetForecastCommentTxtFileName(txtFilePath.Text), chkAppendFile.Checked);
                    Customer.WriteForecastToTxtHeaders(swForecast, swForecastComment);
                }

                if (_companyCollection != null && _companyCollection.Count > 1)
                {
                    for (var i = 0; i < _companyCollection.Count; i++)
                    {
                        var company = _companyCollection[i];
                        company.ExportForecast(forecastExportType, swForecast, swForecastComment, chkSubtractCurrentMonthSales.Checked);
                    }
                }
                else if (_company != null)
                    _company.ExportForecast(forecastExportType, swForecast, swForecastComment, chkSubtractCurrentMonthSales.Checked);

                if (swForecastComment != null)
                {
                    swForecastComment.Close();
                    swForecastComment.Dispose();
                }
                swForecast.Close();
                swForecast.Dispose();

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

        private void frmForecastExport_FormClosing(object sender, FormClosingEventArgs e)
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

        private void rbtnToOracle_CheckedChanged(object sender, EventArgs e)
        {
            chkSubtractCurrentMonthSales.Visible = rbtnToOracle.Checked;
            chkAppendFile.Visible = rbtnToOracle.Checked;
            if (rbtnForEdit.Checked)
            {
                chkSubtractCurrentMonthSales.Checked = false;
                chkAppendFile.Checked = false;
            }
        }
    }
}
