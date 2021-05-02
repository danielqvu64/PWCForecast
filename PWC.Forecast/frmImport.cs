using System;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    public enum ImportFileType
    { ForecastFromEdited, POSFlatOracle, POSFlatACNeilsen, POSXLSACNeilsen, POSXLSToCSVACNeilsen, ActualSalesFlat, TrendByCompanyProductGroupFlat, TrendByCompanyItemFlat, TrendByCustomerProductGroupFlat, TrendByCustomerItemFlat }

    public partial class frmImport : Form
    {
        private ImportFileType _importFileType = ImportFileType.POSFlatOracle;
        private string _connectionString = ConfigurationManager.ConnectionStrings["PWCConnectionString"].ToString();
        private Company _company;
        private CustomerKey _customerKey;
        public delegate void TrendByCustomerProductGroupCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event TrendByCustomerProductGroupCollectionInvalidatedDelegate TrendByCustomerProductGroupCollectionInvalidated;
        public delegate void TrendByCustomerItemCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event TrendByCustomerItemCollectionInvalidatedDelegate TrendByCustomerItemCollectionInvalidated;
        public delegate void TrendByCompanyProductGroupCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event TrendByCompanyProductGroupCollectionInvalidatedDelegate TrendByCompanyProductGroupCollectionInvalidated;
        public delegate void TrendByCompanyItemCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event TrendByCompanyItemCollectionInvalidatedDelegate TrendByCompanyItemCollectionInvalidated;

        public frmImport(ImportFileType importFileType)
        {
            InitializeComponent();
            this._importFileType = importFileType;
        }

        public frmImport(ImportFileType importFileType, Company company, CustomerKey customerKey)
        {
            InitializeComponent();
            this._importFileType = importFileType;
            this._company = company;
            this._customerKey = customerKey;
        }

        private void frmPosImport_Load(object sender, EventArgs e)
        {
            try
            {
                lblCompany.Visible = _importFileType == ImportFileType.POSFlatACNeilsen;
                txtCompanyCode.Visible = _importFileType == ImportFileType.POSFlatACNeilsen;
                txtCompanyName.Visible = _importFileType == ImportFileType.POSFlatACNeilsen;
                lblCustomer.Visible = _importFileType == ImportFileType.POSFlatACNeilsen;
                cboCustomer.Visible = _importFileType == ImportFileType.POSFlatACNeilsen;

                switch (_importFileType)
                {
                    case ImportFileType.ForecastFromEdited:
                        this.Text = "Forecast import from edited forecast file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["ForecastEditedFilePath"];
                        break;
                    case ImportFileType.POSFlatOracle:
                        this.Text = "POS import from Oracle flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["POSFlatOracleFilePath"];
                        break;
                    case ImportFileType.POSFlatACNeilsen:
                        this.Text = "POS import from AC Neilsen flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["POSFlatOracleFilePath"];
                        cboCustomer.ValueMember = "Code";
                        cboCustomer.DisplayMember = "CodeDescription";
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
                            }
                        }
                        break;
                    case ImportFileType.POSXLSACNeilsen:
                        this.Text = "POS import from AC Neilsen XLS file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["POSXLSACNeilsenFilePath"];
                        break;
                    case ImportFileType.POSXLSToCSVACNeilsen:
                        this.Text = "POS import from AC Neilsen XLS to CSV file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["POSXLSToCSVACNeilsenFilePath"];
                        break;
                    case ImportFileType.ActualSalesFlat:
                        this.Text = "Actual Sales import from flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["ActualSalesFlatFilePath"];
                        break;
                    case ImportFileType.TrendByCompanyProductGroupFlat:
                        this.Text = "Trend by Company Product Group import from flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["TrendByCompanyProductGroupFlatFilePath"];
                        break;
                    case ImportFileType.TrendByCompanyItemFlat:
                        this.Text = "Trend by Company Item import from flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["TrendByCompanyItemFlatFilePath"];
                        break;
                    case ImportFileType.TrendByCustomerProductGroupFlat:
                        this.Text = "Trend by Customer Product Group import from flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["TrendByCustomerProductGroupFlatFilePath"];
                        break;
                    case ImportFileType.TrendByCustomerItemFlat:
                        this.Text = "Trend by Customer Item import from flat file";
                        txtFilePath.Text = ConfigurationManager.AppSettings["TrendByCustomerItemFlatFilePath"];
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_importFileType == ImportFileType.POSFlatACNeilsen)
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
                }

                this.Cursor = Cursors.WaitCursor;
                string messageString = string.Empty;
                bool importError = false;
                string dtsPackagePath = string.Empty;
                // Notes: PWC is still using SQLNCLI, to test replace SQLNCLI with SQLNCLI10
                //        The model xls file is C:\PWC\Import Data\New\Forecasting Reports 061408b.xls

                ///FILE "C:\PWC\Import Data\POS Data Import Package.dtsx" /CONNECTION DestinationConnectionOLEDB;"\"Data Source=(local);User ID=sa;Password=Xtra8422;Initial Catalog=PWCForecast;Provider=SQLNCLI;Auto Translate=false;\"" /CONNECTION SourceConnectionFlatFile;"C:\PWC\Import Data\posdt.txt"  /MAXCONCURRENT " -1 " /CHECKPOINTING OFF  /REPORTING EWCDI 
                ///FILE "C:\PWC\Import Data\POS Data Import XLS Package.dtsx" /CONNECTION DestinationConnectionOLEDB;"Data Source=(local);User ID=sa;Password=Xtra8422;Initial Catalog=PWCForecast;Provider=SQLNCLI;Auto Translate=false;" /CONNECTION SourceConnectionExcel;"Provider=Microsoft.Jet.OLEDB.4.0;""Data Source=C:\PWC\Import Data\Forecasting Reports 122907b.xls"";""Extended Properties=Excel 8.0;HDR=NO"""  /MAXCONCURRENT " -1 " /CHECKPOINTING OFF  /REPORTING EWCDI
                switch (_importFileType)
                {
                    case ImportFileType.ForecastFromEdited:
                        importError = ImportForecast(ref messageString);
                        break;
                    case ImportFileType.POSFlatOracle:
                        dtsPackagePath = ConfigurationManager.AppSettings["POSFlatFileOracleDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdatePOSFromBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.POSFlatACNeilsen:
                        dtsPackagePath = ConfigurationManager.AppSettings["POSFlatFileACNeilsenDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "dbo.utlUpdatePOSFromACNeilsenBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.POSXLSACNeilsen:
                        dtsPackagePath = ConfigurationManager.AppSettings["POSXlsFileACNeilsenDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionExcel;\"Provider=Microsoft.Jet.OLEDB.4.0;\"\"Data Source={2}\"\";\"\"Extended Properties=Excel 8.0;HDR=NO\"\"\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdatePOSFromXlsBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.POSXLSToCSVACNeilsen:
                        dtsPackagePath = ConfigurationManager.AppSettings["POSXlsToCsvFileACNeilsenDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdatePOSFromXlsToCsvBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.ActualSalesFlat:
                        dtsPackagePath = ConfigurationManager.AppSettings["ActualSalesFlatDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdateActualSalesFromBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.TrendByCompanyProductGroupFlat:
                        dtsPackagePath = ConfigurationManager.AppSettings["TrendByCompanyProductGroupFlatDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdateTrendByCompanyProductGroupFromBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.TrendByCompanyItemFlat:
                        dtsPackagePath = ConfigurationManager.AppSettings["TrendByCompanyItemFlatDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdateTrendByCompanyItemFromBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.TrendByCustomerProductGroupFlat:
                        dtsPackagePath = ConfigurationManager.AppSettings["TrendByCustomerProductGroupFlatDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdateTrendByCustomerProductGroupFromBcp"
                            , ref messageString);
                        break;
                    case ImportFileType.TrendByCustomerItemFlat:
                        dtsPackagePath = ConfigurationManager.AppSettings["TrendByCustomerItemFlatDTSPackagePath"];
                        importError = Import(dtsPackagePath
                            , string.Format("/FILE \"{0}\" /CONNECTION DestinationConnectionOLEDB;\"{1}Provider=SQLNCLI;Auto Translate=false;\" /CONNECTION SourceConnectionFlatFile;\"{2}\"  /MAXCONCURRENT \" -1 \" /CHECKPOINTING OFF  /REPORTING EWCDI", dtsPackagePath, _connectionString, txtFilePath.Text)
                            , "utlUpdateTrendByCustomerItemFromBcp"
                            , ref messageString);
                        break;
                }
                this.Cursor = Cursors.Arrow;

                if (messageString != string.Empty)
                {
                    MessageBox.Show(messageString, "PWC Forecast");
                    if (importError)
                        return;
                }
                switch (_importFileType)
                {
                    case ImportFileType.ForecastFromEdited:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["ForecastEditedFilePath"])
                            Utility.GetInstance().SaveSetting("ForecastEditedFilePath", txtFilePath.Text);
                        break;
                    case ImportFileType.POSFlatOracle:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["POSFlatOracleFilePath"])
                            Utility.GetInstance().SaveSetting("POSFlatOracleFilePath", txtFilePath.Text);
                        break;
                    case ImportFileType.POSFlatACNeilsen:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["POSFlatACNeilsenFilePath"])
                            Utility.GetInstance().SaveSetting("POSFlatOracleFilePath", txtFilePath.Text);
                        break;
                    case ImportFileType.POSXLSACNeilsen:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["POSXLSACNeilsenFilePath"])
                            Utility.GetInstance().SaveSetting("POSXLSACNeilsenFilePath", txtFilePath.Text);
                        break;
                    case ImportFileType.POSXLSToCSVACNeilsen:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["POSXLSToCSVACNeilsenFilePath"])
                            Utility.GetInstance().SaveSetting("POSXLSToCSVACNeilsenFilePath", txtFilePath.Text);
                        break;
                    case ImportFileType.ActualSalesFlat:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["ActualSalesFlatFilePath"])
                            Utility.GetInstance().SaveSetting("ActualSalesFlatFilePath", txtFilePath.Text);
                        break;
                    case ImportFileType.TrendByCompanyProductGroupFlat:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["TrendByCompanyProductGroupFlatFilePath"])
                            Utility.GetInstance().SaveSetting("TrendByCompanyProductGroupFlatFilePath", txtFilePath.Text);
                        if (TrendByCompanyProductGroupCollectionInvalidated != null)
                            TrendByCompanyProductGroupCollectionInvalidated(this, new EventArgs());
                        break;
                    case ImportFileType.TrendByCompanyItemFlat:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["TrendByCompanyItemFlatFilePath"])
                            Utility.GetInstance().SaveSetting("TrendByCompanyItemFlatFilePath", txtFilePath.Text);
                        if (TrendByCompanyItemCollectionInvalidated != null)
                            TrendByCompanyItemCollectionInvalidated(this, new EventArgs());
                        break;
                    case ImportFileType.TrendByCustomerProductGroupFlat:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["TrendByCustomerProductGroupFlatFilePath"])
                            Utility.GetInstance().SaveSetting("TrendByCustomerProductGroupFlatFilePath", txtFilePath.Text);
                        if (TrendByCustomerProductGroupCollectionInvalidated != null)
                            TrendByCustomerProductGroupCollectionInvalidated(this, new EventArgs());
                        break;
                    case ImportFileType.TrendByCustomerItemFlat:
                        if (txtFilePath.Text != ConfigurationManager.AppSettings["TrendByCustomerItemFlatFilePath"])
                            Utility.GetInstance().SaveSetting("TrendByCustomerItemFlatFilePath", txtFilePath.Text);
                        if (TrendByCustomerItemCollectionInvalidated != null)
                            TrendByCustomerItemCollectionInvalidated(this, new EventArgs());
                        break;
                }
                Close();
                Dispose();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
                this.Cursor = Cursors.Arrow;
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

        private bool ImportForecast(ref string messageString)
        {
            Company company = null;
            Customer customer = null;
            
            // populate forecast comment from txt file
            if (!File.Exists(txtFilePath.Text))
            {
                messageString = "Forecast file does not exist.";
                return true;
            }

            var forecastCommentFileName = Customer.GetForecastCommentTxtFileName(txtFilePath.Text);
            if (!File.Exists(forecastCommentFileName))
            {
                messageString = "Forecast Comment file does not exist.";
                return true;
            }

            var forecastCommentCollection = new List<ForecastCommentAndOverride>();
            var lineCount = 0;

            // populate forecast commnent from txt file
            using (var sr = new StreamReader(forecastCommentFileName))
            {
                sr.ReadLine();
                lineCount++;
                while (sr.Peek() >= 0)
                {
                    var columns = sr.ReadLine().Split('\t');
                    lineCount++;
                    if (columns.Length != 8)
                    {
                        messageString = string.Format("The number of columns in the forecast comment txt file must be 8. The error is on line {0}.", lineCount);
                        return true;
                    }
                    var companyCode = columns[0].Replace("!", "");
                    var customerNumber = columns[1];
                    forecastCommentCollection.Add(new ForecastCommentAndOverride
                    {
                        CompanyCode = companyCode,
                        CustomerNumber = customerNumber,
                        POSSalesEndDate = Convert.ToDateTime(columns[2]),
                        ItemNumber = columns[3],
                        ForecastMethod = columns[4],
                        ForecastValueKey = columns[5],
                        CommentOverrideDateTime = Convert.ToDateTime(columns[6]),
                        Comment = columns[7].Replace("{crlf}", Environment.NewLine)
                    });
                }
            }

            // populate forecast from txt file
            using (var sr = new StreamReader(txtFilePath.Text))
            {
                sr.ReadLine();
                lineCount = 1;
                while (sr.Peek() >= 0)
                {
                    var columns = sr.ReadLine().Split('\t');
                    lineCount++;
                    if (columns.Length != 41)
                    {
                        messageString = string.Format("The number of columns in the forecast txt file must be 41. The error is on line {0}.", lineCount);
                        return true;
                    }
                    var companyCode = columns[0].Replace("!", "");
                    var customerNumber = columns[1];

                    if (customer != null && (customer.CompanyCode != companyCode || customer.CustomerNumber != customerNumber))
                    {
                        if (customer.ForecastCollection != null && customer.ForecastCollection.Count > 0)
                        {
                            customer.ForecastCollection.SetHeader = new ForecastCollectionHeader(customer.ForecastCollection[0].CompanyCode,
                                                                                                 customer.ForecastCollection[0].CustomerNumber,
                                                                                                 customer.ForecastCollection[0].POSSalesEndDate);
                            ((IPersistenceObject)customer.ForecastCollection.SetHeader).Load();

                            SaveForecast(customer);

                            lblProgress.Text = string.Format("Reading Forecast for Company: {0}, Customer: {1} ...", companyCode, customerNumber);
                            Application.DoEvents();
                        }
                    }
                    var posSalesEndDate = Convert.ToDateTime(columns[2]);

                    if (company == null || company.CompanyCode != companyCode)
                    {
                        var companyCollection = new Company.ParameteredCollection(companyCode);
                        companyCollection.Load();
                        if (companyCollection.Count == 0)
                        {
                            messageString = string.Format("Invalid Company Code at line {0} in forecast txt file.", lineCount);
                            return true;
                        }
                        company = companyCollection[0];
                    }

                    if (customer == null || customer.CompanyCode != companyCode || customer.CustomerNumber != customerNumber)
                    {
                        var customerKey = new CustomerKey(companyCode, customerNumber);
                        customer = company.CustomerCollection[customerKey];
                        if (customer == null)
                        {
                            messageString = string.Format("Invalid Customer Number at line {0} in forecast txt file.", lineCount);
                            return true;
                        }
                        customer.POSSalesEndDate = posSalesEndDate;
                        customer.ForecastAction = ForecastAction.Generate;
                        customer.ForecastCollection = new PWC.BusinessObject.Forecast.WithCustomerParentParameteredCollection { Parent = customer };
                    }

                    var savedForecastDates = PersistenceLayer.Utility.GetInstance().GetSavedForecastDateCollection(companyCode, customerNumber, 1);
                    if (savedForecastDates.Count == 1)
                        continue;
                    var latestPosSalesEndDate = DateTime.Parse(savedForecastDates[1].POSSalesEndDate);

                    var calendar = Calendar.GetInstance();
                    if (latestPosSalesEndDate > posSalesEndDate &&
                        String.CompareOrdinal(calendar.GetYYMM(posSalesEndDate), calendar.GetYYMM(DateTime.Today)) < 0)
                    {
                        messageString = string.Format("Past forecast cannot be overwritten at line {0}.", lineCount);
                        return true;
                    }

                    var forecastKey = new ForecastKey(companyCode, customerNumber, posSalesEndDate, columns[3], columns[4]);
                    var forecast = customer.ForecastCollection.Create(forecastKey);
                    for (var i = 5; i < 41; i++)
                    {
                        if (!string.IsNullOrEmpty(columns[i]))
                        {
                            var quantity = Math.Round(Convert.ToDecimal(columns[i]), 0);
                            forecast.ForecastQuantityCollection[i - 5] = Convert.ToInt32(quantity);
                        }
                        else
                            forecast.ForecastQuantityCollection[i - 5] = SqlInt32.Null;
                    }
                    var comments = forecastCommentCollection.Where(
                        c => (c.CompanyCode == forecast.CompanyCode && c.CustomerNumber == forecast.CustomerNumber &&
                              c.POSSalesEndDate == forecast.POSSalesEndDate && c.ItemNumber == forecast.ItemNumber &&
                              c.ForecastMethod == forecast.ForecastMethod).Value).ToArray();
                    if (comments.Length > 0)
                    {
                        forecast.HasComment = true;
                        forecast.ForecastCommentAndOverrideCollection = new ForecastCommentAndOverride.WithForecastParentCollection(forecast);
                        foreach (var comment in comments)
                        {
                            var forecastComment = forecast.ForecastCommentAndOverrideCollection.Create(new ForecastCommentAndOverrideKey
                            {
                                CompanyCode = forecast.CompanyCode,
                                CustomerNumber = forecast.CustomerNumber,
                                POSSalesEndDate = forecast.POSSalesEndDate,
                                ItemNumber = forecast.ItemNumber,
                                ForecastMethod = forecast.ForecastMethod,
                                ForecastValueKey = comment.ForecastValueKey,
                                CommentOverrideDateTime = comment.CommentOverrideDateTime,
                            });
                            forecastComment.Comment = comment.Comment;
                            forecast.ForecastCommentAndOverrideCollection.Add(forecastComment);
                        }
                    }

                    forecast.CreatedDate = DateTime.Today;
                    customer.ForecastCollection.Add(forecast);
                }
            }

            if (customer.ForecastCollection != null && customer.ForecastCollection.Count > 0)
            {
                customer.ForecastCollection.SetHeader = new ForecastCollectionHeader(customer.ForecastCollection[0].CompanyCode,
                                                                                     customer.ForecastCollection[0].CustomerNumber,
                                                                                     customer.ForecastCollection[0].POSSalesEndDate);
                ((IPersistenceObject)customer.ForecastCollection.SetHeader).Load();

                SaveForecast(customer);
            }

            return false;
        }

        private void SaveForecast(Customer customer)
        {
            lblProgress.Text = string.Format("Saving Forecast for Company: {0}, Customer: {1} ...", customer.CompanyCode, customer.CustomerNumber);
            Application.DoEvents();

            using (var transaction = new Transaction())
            {
                // save a copy of the genenerated collection
                var generatedCollection = customer.ForecastCollection;

                // delete the existing collections
                customer.ForecastAction = ForecastAction.Get; // do a get for delete
                customer.ForecastCollection.SetHeader = generatedCollection.SetHeader; // restore the version before the get

                foreach (var forecast in customer.ForecastCollection.Where(forecast => (bool)(forecast.HasComment || forecast.HasOverride)))
                {
                    transaction.Enlist(forecast.ForecastCommentAndOverrideCollection);
                    forecast.ForecastCommentAndOverrideCollection.Delete();
                }

                transaction.Enlist(customer.ForecastCollection);
                customer.ForecastCollection.Delete();

                // insert the generated collection to DB
                generatedCollection.MarkNew();
                transaction.Enlist(generatedCollection);
                generatedCollection.Save();

                // insert the generated comment and override collection to DB
                foreach (var generatedForecast in generatedCollection.Where(forecast => (bool)(forecast.HasComment || forecast.HasOverride)))
                {
                    generatedForecast.ForecastCommentAndOverrideCollection.MarkNew();
                    transaction.Enlist(generatedForecast.ForecastCommentAndOverrideCollection);
                    generatedForecast.ForecastCommentAndOverrideCollection.Save();
                }

                transaction.Commit();
            }
        }

        private bool Import(string dtsPackagePath, string dtsArguments, string posUpdateSPName, ref string messageString)
        {
            this.Cursor = Cursors.WaitCursor;
            bool importError = false;
            string DTExecPath = ConfigurationManager.AppSettings["DTExecPath"];
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = DTExecPath;
            process.StartInfo.Arguments = dtsArguments;
            process.StartInfo.WorkingDirectory = DTExecPath.ToLower().Replace("dtexec.exe", string.Empty);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.ErrorDialog = true;
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ConfigurationManager.AppSettings["DTSErrorFilePath"], true))
            //{
            //    sw.Write("DTS Error on: ");
            //    sw.WriteLine(CommentOverrideDateTime.Now);
            //    sw.WriteLine(string.Format("process.StartInfo.FileName: {0}", process.StartInfo.FileName));
            //    sw.WriteLine(string.Format("process.StartInfo.Arguments: {0}", process.StartInfo.Arguments));
            //    sw.WriteLine(string.Format("process.StartInfo.WorkingDirectory: {0}", process.StartInfo.WorkingDirectory));
            //}
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit(300000); // wait for 5 mins
            importError = process.ExitCode != 0;
            if (importError)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ConfigurationManager.AppSettings["DTSErrorFilePath"], true))
                {
                    sw.Write("DTS Error on: ");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(output);
                }
                messageString = string.Format("Error occured while loading the {0} file to temporary SQL table.", _importFileType.ToString());
            }
            else
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand();
                command.CommandText = posUpdateSPName;
                command.CommandType = CommandType.StoredProcedure;
                if (_customerKey != null)
                {
                    command.Parameters.AddWithValue("@company_code", _customerKey.CompanyCode);
                    command.Parameters.AddWithValue("@customer_number", _customerKey.CustomerNumber);
                }
                command.CommandTimeout = 0;
                command.Connection = connection;
                connection.Open();
                string POSorActualSales = _importFileType == ImportFileType.ActualSalesFlat ? "Actual Sales" : "POS";
                System.Text.StringBuilder sb = new StringBuilder(string.Empty);
                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        importError = (int)(dr["errorNumber"]) != 0;
                        if (importError)
                        {
                            sb.Append(string.Format("Error occured while updating {0} from temporary {1} table.", POSorActualSales, POSorActualSales));
                            sb.Append("\nData has been rolled back to previous good state.");
                            sb.Append("\nError Number: ").Append(dr["errorNumber"].ToString());
                            sb.Append("\nError Message: ").Append(dr["errorMessage"].ToString());
                            sb.Append("\nError Severity: ").Append(dr["errorSeverity"].ToString());
                            sb.Append("\nError State: ").Append(dr["errorState"].ToString());
                            sb.Append("\nLine Number: ").Append(dr["errorLine"].ToString());
                            sb.Append("\nProcedure Name: ").Append(dr["errorProcedure"].ToString());
                        }
                        else
                        {
                            sb.Append(string.Format("{0} import from {1} file succeeded.", POSorActualSales, _importFileType.ToString()));
                            sb.Append("\nRows backed up: ").Append(dr["rowBackedUp"].ToString());
                            sb.Append("\nDuplicate rows deleted: ").Append(dr["duplicateRowDeleted"].ToString());
                            sb.Append("\nRows inserted: ").Append(dr["rowInserted"].ToString());
                        }
                    }
                }
                messageString = sb.ToString();
            }
            this.Cursor = Cursors.Arrow;
            return importError;
        }

        private void txtFilePath_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Regex rx;
                if (_importFileType == ImportFileType.POSXLSACNeilsen)
                    rx = new System.Text.RegularExpressions.Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)$?)(\\(\w[\w ].*))+(.xls|.XLS)$");
                else
                    rx = new System.Text.RegularExpressions.Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)$?)(\\(\w[\w ].*))+(.csv|.CSV|.txt|.TXT|.prn|.PRN)$");
                if (!rx.IsMatch(txtFilePath.Text))
                {
                    MessageBox.Show(string.Format("Please enter a valid {0} file path.", _importFileType == ImportFileType.POSXLSACNeilsen ? "Excel" : "text"), "PWC Forecast");
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
            try
            {
                txtFilePath.SelectAll();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_importFileType == ImportFileType.POSXLSACNeilsen)
                {
                    openFileDialog1.DefaultExt = ".xls";
                    openFileDialog1.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*";
                }
                else
                {
                    openFileDialog1.DefaultExt = ".txt";
                    openFileDialog1.Filter = "Text Files (*.prn;*.txt;*.csv)|*.prn;*.txt;*.csv|All Files (*.*)|*.*";
                }

                FileInfo fileInfo = new FileInfo(txtFilePath.Text);
                openFileDialog1.InitialDirectory = fileInfo.DirectoryName;
                openFileDialog1.FileName = fileInfo.Name;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                    txtFilePath.Text = openFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void frmPosImport_FormClosing(object sender, FormClosingEventArgs e)
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

        void txtCompanyCode_GotFocus(object sender, System.EventArgs e)
        {
            txtCompanyCode.SelectAll();
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
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
    }
}
