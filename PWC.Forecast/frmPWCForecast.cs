using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlTypes;
using DVu.Library.PersistenceLayer;
using DVu.Library.BusinessObject;
using PWC.PersistenceInterface;
using PWC.BusinessObject;
using Calendar = PWC.BusinessObject.Calendar;

namespace PWC.Forecast
{
    public partial class frmPWCForecast : Form
    {
        private Company _company;
        private CustomerKey _customerKey;
        private DataGridViewColumn _dgvSalesRateSortedColumn;
        private System.Windows.Forms.SortOrder _dgvSalesRateSortOrder = System.Windows.Forms.SortOrder.Descending;
        private DataGridViewColumn _dgvTrendSortedColumn;
        private System.Windows.Forms.SortOrder _dgvTrendSortOrder = System.Windows.Forms.SortOrder.Descending;
        private DataGridViewColumn _dgvParameterSortedColumn;
        private System.Windows.Forms.SortOrder _dgvParameterSortOrder = System.Windows.Forms.SortOrder.Descending;
        private DataGridViewColumn _dgvForecastSortedColumn;
        private System.Windows.Forms.SortOrder _dgvForecastSortOrder = System.Windows.Forms.SortOrder.Descending;
        private DataGridViewColumn _dgvBonusAndDiscontinuedSortedColumn;
        private System.Windows.Forms.SortOrder _dgvBonusAndDiscontinuedSortOrder = System.Windows.Forms.SortOrder.Descending;
        private List<DropDownItem> _productGroupCollection;
        private bool _dgvBonusAndDiscontinuedRowDirty = false;
        private bool _dgvForecastRowDirty = false;
        private bool _dgvParameterRowDirty = false;
        private bool _dgvSalesRateRowDirty = false;
        private bool _dgvTrendRowDirty = false;
        private DataGridViewCellEventArgs _mouseLocation;

        public frmPWCForecast()
        {
            InitializeComponent();
        }

        #region frmPWCForecast Event Handlers
        private void frmPWCForecast_Load(object sender, EventArgs e)
        {
            try
            {
                var util = PersistenceLayer.Utility.GetInstance();
                Text = string.Format("{0} - {1}", Text, util.GetDefaultSqlServerName().ToLower().IndexOf("dev", StringComparison.Ordinal) > -1 ? "Test" : "Production");

                cboCustomer.ValueMember = "Code";
                cboCustomer.DisplayMember = "CodeDescription";

                _productGroupCollection = Utility.GetInstance().GetProductGroupDropDownCollection();
                ((DataGridViewComboBoxColumn)dgvTrend.Columns["ProductGroup"]).DataSource = _productGroupCollection;
                ((DataGridViewComboBoxColumn)dgvTrend.Columns["ProductGroup"]).DisplayMember = "CodeDescription";
                ((DataGridViewComboBoxColumn)dgvTrend.Columns["ProductGroup"]).ValueMember = "Code";

                // initialize data set to empty collection so the grid can be click on the first time.
                bindingSourceForecast.DataSource = new BusinessObject.Forecast.WithCustomerParentParameteredCollection();
                bindingSourceForecastParameter.DataSource = new ForecastParameter.WithCustomerParentCollection();
                bindingSourceSalesRate.DataSource = new ForecastSalesRate.WithCustomerParentParameteredCollection();
                bindingSourceTrend.DataSource = new ForecastTrendByCompanyItem.WithCompanyParentCollection();
                bindingSourceBonusAndDiscontinued.DataSource = new BonusAndDiscontinuedByCompany.WithCompanyParentCollection();

                //dgvParameter.FirstDisplayedScrollingColumnIndex = dgvParameter.Columns["PlPctCY01"].Index;
                //dgvBonusAndDiscontinued.FirstDisplayedScrollingColumnIndex = dgvBonusAndDiscontinued.Columns["CY01Bonus"].Index;
                //dgvForecast.FirstDisplayedScrollingColumnIndex = dgvForecast.Columns["CY01"].Index;
                chkShowPriorYear_CheckedChanged(this, null);
                
                dgvSalesRate.DefaultCellStyle.NullValue = "Null";
                dgvSalesRate.DefaultCellStyle.DataSourceNullValue = Convert.DBNull;
                dgvParameter.DefaultCellStyle.NullValue = "Null";
                dgvParameter.DefaultCellStyle.DataSourceNullValue = Convert.DBNull;
                dgvForecast.DefaultCellStyle.NullValue = "Null";
                dgvForecast.DefaultCellStyle.DataSourceNullValue = Convert.DBNull;
                dgvBonusAndDiscontinued.DefaultCellStyle.NullValue = "Null";
                dgvBonusAndDiscontinued.DefaultCellStyle.DataSourceNullValue = Convert.DBNull;
                // this does not work, have to do cell format event
                //dgvBonusAndDiscontinued.Columns["DiscontinuedEffectiveDate"].DefaultCellStyle.Format = "MM/dd/yyyy";

                for (var i = 1; i <= 12; i++)
                    dgvActualSales.Columns[i].HeaderText = DateTime.Today.AddMonths(-12 + i).ToString("MMM yy");

                // need to do this for dgvBonusAndDiscontinued because the default datatype generated for empty collection is string for textbox
                // it is causing data casting problem
                DiscontinuedEffectiveDate.ValueType = typeof(SqlDateTime);
                PY01Bonus.ValueType = typeof(SqlInt32);
                PY02Bonus.ValueType = typeof(SqlInt32);
                PY03Bonus.ValueType = typeof(SqlInt32);
                PY04Bonus.ValueType = typeof(SqlInt32);
                PY05Bonus.ValueType = typeof(SqlInt32);
                PY06Bonus.ValueType = typeof(SqlInt32);
                PY07Bonus.ValueType = typeof(SqlInt32);
                PY08Bonus.ValueType = typeof(SqlInt32);
                PY09Bonus.ValueType = typeof(SqlInt32);
                PY10Bonus.ValueType = typeof(SqlInt32);
                PY11Bonus.ValueType = typeof(SqlInt32);
                PY12Bonus.ValueType = typeof(SqlInt32);
                CY01Bonus.ValueType = typeof(SqlInt32);
                CY02Bonus.ValueType = typeof(SqlInt32);
                CY03Bonus.ValueType = typeof(SqlInt32);
                CY04Bonus.ValueType = typeof(SqlInt32);
                CY05Bonus.ValueType = typeof(SqlInt32);
                CY06Bonus.ValueType = typeof(SqlInt32);
                CY07Bonus.ValueType = typeof(SqlInt32);
                CY08Bonus.ValueType = typeof(SqlInt32);
                CY09Bonus.ValueType = typeof(SqlInt32);
                CY10Bonus.ValueType = typeof(SqlInt32);
                CY11Bonus.ValueType = typeof(SqlInt32);
                CY12Bonus.ValueType = typeof(SqlInt32);
                NY01Bonus.ValueType = typeof(SqlInt32);
                NY02Bonus.ValueType = typeof(SqlInt32);
                NY03Bonus.ValueType = typeof(SqlInt32);
                NY04Bonus.ValueType = typeof(SqlInt32);
                NY05Bonus.ValueType = typeof(SqlInt32);
                NY06Bonus.ValueType = typeof(SqlInt32);
                NY07Bonus.ValueType = typeof(SqlInt32);
                NY08Bonus.ValueType = typeof(SqlInt32);
                NY09Bonus.ValueType = typeof(SqlInt32);
                NY10Bonus.ValueType = typeof(SqlInt32);
                NY11Bonus.ValueType = typeof(SqlInt32);
                NY12Bonus.ValueType = typeof(SqlInt32);

                // do the same for parameter
                StoreCountExisting.ValueType = typeof(SqlInt32);
                StoreCountNew.ValueType = typeof(SqlInt32);
                InitialQtyPerNewStore.ValueType = typeof(SqlDecimal);
                ProjectedSalesRateExisting.ValueType = typeof(SqlDecimal);
                ProjectedSalesRateNew.ValueType = typeof(SqlDecimal);
                PlPctPY01.ValueType = typeof(SqlDecimal);
                PlPctPY02.ValueType = typeof(SqlDecimal);
                PlPctPY03.ValueType = typeof(SqlDecimal);
                PlPctPY04.ValueType = typeof(SqlDecimal);
                PlPctPY05.ValueType = typeof(SqlDecimal);
                PlPctPY06.ValueType = typeof(SqlDecimal);
                PlPctPY07.ValueType = typeof(SqlDecimal);
                PlPctPY08.ValueType = typeof(SqlDecimal);
                PlPctPY09.ValueType = typeof(SqlDecimal);
                PlPctPY10.ValueType = typeof(SqlDecimal);
                PlPctPY11.ValueType = typeof(SqlDecimal);
                PlPctPY12.ValueType = typeof(SqlDecimal);
                PlPctCY01.ValueType = typeof(SqlDecimal);
                PlPctCY02.ValueType = typeof(SqlDecimal);
                PlPctCY03.ValueType = typeof(SqlDecimal);
                PlPctCY04.ValueType = typeof(SqlDecimal);
                PlPctCY05.ValueType = typeof(SqlDecimal);
                PlPctCY06.ValueType = typeof(SqlDecimal);
                PlPctCY07.ValueType = typeof(SqlDecimal);
                PlPctCY08.ValueType = typeof(SqlDecimal);
                PlPctCY09.ValueType = typeof(SqlDecimal);
                PlPctCY10.ValueType = typeof(SqlDecimal);
                PlPctCY11.ValueType = typeof(SqlDecimal);
                PlPctCY12.ValueType = typeof(SqlDecimal);
                PlPctNY01.ValueType = typeof(SqlDecimal);
                PlPctNY02.ValueType = typeof(SqlDecimal);
                PlPctNY03.ValueType = typeof(SqlDecimal);
                PlPctNY04.ValueType = typeof(SqlDecimal);
                PlPctNY05.ValueType = typeof(SqlDecimal);
                PlPctNY06.ValueType = typeof(SqlDecimal);
                PlPctNY07.ValueType = typeof(SqlDecimal);
                PlPctNY08.ValueType = typeof(SqlDecimal);
                PlPctNY09.ValueType = typeof(SqlDecimal);
                PlPctNY10.ValueType = typeof(SqlDecimal);
                PlPctNY11.ValueType = typeof(SqlDecimal);
                PlPctNY12.ValueType = typeof(SqlDecimal);

                dtpMonthEndDate.Value = DateTime.Today.AddDays(DayOfWeek.Sunday - DateTime.Today.DayOfWeek);

                var startIndex = 0;
                for (var columnIndex = 0; columnIndex < dgvBonusAndDiscontinued.Columns.Count; columnIndex++)
                    if (dgvBonusAndDiscontinued.Columns[columnIndex].HeaderText.IndexOf("PY01", StringComparison.Ordinal) > -1)
                    {
                        startIndex = columnIndex;
                        break;
                    }
                for (var columnIndex = startIndex; columnIndex < startIndex + 36; columnIndex++)
                {
                    int year, month = (columnIndex - startIndex + 1) % 12;
                    if (columnIndex - startIndex < 12)
                        year = DateTime.Today.Year - 1;
                    else if (columnIndex - startIndex < 24)
                        year = DateTime.Today.Year;
                    else
                        year = DateTime.Today.Year + 1;
                    var sb = new StringBuilder(dgvBonusAndDiscontinued.Columns[columnIndex].HeaderText);
                    sb.Append(" (").Append(DateTime.DaysInMonth(year, month == 0 ? 12 : month).ToString()).Append(")");
                    dgvBonusAndDiscontinued.Columns[columnIndex].HeaderText = sb.ToString();
                }

                // setup context menu for Forecast and Sales Rate
                foreach (var column in dgvForecast.Columns.Cast<DataGridViewColumn>().Where(column => Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$")))
                    column.ContextMenuStrip = forecastContextMenuStrip;
                
                dgvSalesRate.Columns["SalesRate"].ContextMenuStrip = forecastSalesRateContextMenuStrip;

                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void frmPWCForecast_ForecastCollectionInvalidated(object sender, EventArgs e)
        {
            bindingSourceForecast.DataSource = null;
        }

        private void frmPWCForecast_ForecastSalesRateCollectionInvalidated(object sender, EventArgs e)
        {
            bindingSourceSalesRate.DataSource = null;
        }

        private void frmPWCForecast_ForecastActionChanged(Customer sender, EventArgs e)
        {
            btnSaveForecast.Enabled = sender.ForecastAction == ForecastAction.Generate;
        }

        private void frmPWCForecast_ForecastSalesRateActionChanged(Customer sender, EventArgs e)
        {
            btnSaveSalesRate.Enabled = sender.ForecastSalesRateAction == ForecastSalesRateAction.Generate;
        }

        private void frmPWCForecast_ProductGroupCollectionInvalidated(object sender, EventArgs e)
        {
            _productGroupCollection = Utility.GetInstance().GetProductGroupDropDownCollection();
            ((DataGridViewComboBoxColumn)dgvTrend.Columns["ProductGroup"]).DataSource = _productGroupCollection;
        }
        
        private void frmPWCForecast_CustomerCollectionInvalidated(object sender, EventArgs e)
        {
            if (_company != null)
            {
                if (_customerKey != null && _company.CustomerCollection.ContainsKey(_customerKey))
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    if (customer.ForecastAction == ForecastAction.Generate)
                        customer.ForecastCollection = null;
                    if (customer.ForecastSalesRateAction == ForecastSalesRateAction.Generate)
                        customer.ForecastSalesRateCollection = null;
                }
                cboCustomer.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "CustomerName");
            }
            cboCustomer.SelectedIndex = 0;
        }
        #endregion

        #region Menus Event Handlers
        private void forecastFromEditedForecastFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.ForecastFromEdited);
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void posFromOracleFlatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.POSFlatOracle);
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void posFromACNeilsenFlatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.POSFlatACNeilsen);
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void posFromACNeilsenXLSFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.POSXLSACNeilsen);
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void posFromACNeilsenXLSToCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.POSXLSToCSVACNeilsen);
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void restorePOSPriorToImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestorePriorToImport("utlRestorePOSPriorToImport", "POS");
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void actualSalesFromFlatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.ActualSalesFlat);
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void restoreActualSalesPriorToImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestorePriorToImport("utlRestoreActualSalesPriorToImport", "Actual Sales");
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void trendByCompanyProductGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.TrendByCompanyProductGroupFlat);
                var trendByCompanyProductGroupCollectionInvalidatedDelegate = new frmImport.TrendByCompanyProductGroupCollectionInvalidatedDelegate(frmImport_TrendByCompanyProductGroupCollectionInvalidated);
                frmImport.TrendByCompanyProductGroupCollectionInvalidated -= trendByCompanyProductGroupCollectionInvalidatedDelegate;
                frmImport.TrendByCompanyProductGroupCollectionInvalidated += trendByCompanyProductGroupCollectionInvalidatedDelegate;
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void trendByCompanyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.TrendByCompanyItemFlat);
                var trendByCompanyItemCollectionInvalidatedDelegate = new frmImport.TrendByCompanyItemCollectionInvalidatedDelegate(frmImport_TrendByCompanyItemCollectionInvalidated);
                frmImport.TrendByCompanyItemCollectionInvalidated -= trendByCompanyItemCollectionInvalidatedDelegate;
                frmImport.TrendByCompanyItemCollectionInvalidated += trendByCompanyItemCollectionInvalidatedDelegate;
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void trendByCustomerProductGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.TrendByCustomerProductGroupFlat);
                var trendByCustomerProductGroupCollectionInvalidatedDelegate = new frmImport.TrendByCustomerProductGroupCollectionInvalidatedDelegate(frmImport_TrendByCustomerProductGroupCollectionInvalidated);
                frmImport.TrendByCustomerProductGroupCollectionInvalidated -= trendByCustomerProductGroupCollectionInvalidatedDelegate;
                frmImport.TrendByCustomerProductGroupCollectionInvalidated += trendByCustomerProductGroupCollectionInvalidatedDelegate;
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void trendByCustomerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmImport = new frmImport(ImportFileType.TrendByCustomerItemFlat);
                var trendByCustomerItemCollectionInvalidatedDelegate = new frmImport.TrendByCustomerItemCollectionInvalidatedDelegate(frmImport_TrendByCustomerItemCollectionInvalidated);
                frmImport.TrendByCustomerItemCollectionInvalidated -= trendByCustomerItemCollectionInvalidatedDelegate;
                frmImport.TrendByCustomerItemCollectionInvalidated += trendByCustomerItemCollectionInvalidatedDelegate;
                frmImport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        void frmImport_TrendByCompanyProductGroupCollectionInvalidated(object sender, EventArgs e)
        {
            if (_company != null)
            {
                _company.ForecastTrendByProductGroupCollection = null;
                if (tabPWCForecast.SelectedTab != null && tabPWCForecast.SelectedTab.Name == "tabPageTrend" && rbtnTrendByCompanyProductGroup.Checked)
                {
                    bindingSourceTrend.DataSource = null;
                    LoadTab(tabPWCForecast.SelectedTab.Name);
                }
            }
        }

        void frmImport_TrendByCompanyItemCollectionInvalidated(object sender, EventArgs e)
        {
            if (_company != null)
            {
                _company.ForecastTrendByItemCollection = null;
                if (tabPWCForecast.SelectedTab != null && tabPWCForecast.SelectedTab.Name == "tabPageTrend" && rbtnTrendByCompanyItem.Checked)
                {
                    bindingSourceTrend.DataSource = null;
                    LoadTab(tabPWCForecast.SelectedTab.Name);
                }
            }
        }

        void frmImport_TrendByCustomerProductGroupCollectionInvalidated(object sender, EventArgs e)
        {
            if (_company != null)
            {
                foreach (var customer in _company.CustomerCollection)
                    customer.ForecastTrendByProductGroupCollection = null;

                if (tabPWCForecast.SelectedTab != null && tabPWCForecast.SelectedTab.Name == "tabPageTrend" && rbtnTrendByCustomerProductGroup.Checked)
                {
                    bindingSourceTrend.DataSource = null;
                    LoadTab(tabPWCForecast.SelectedTab.Name);
                }
            }
        }
        
        void frmImport_TrendByCustomerItemCollectionInvalidated(object sender, EventArgs e)
        {
            if (_company != null)
            {
                foreach (var customer in _company.CustomerCollection)
                    customer.ForecastTrendByItemCollection = null;

                if (tabPWCForecast.SelectedTab != null && tabPWCForecast.SelectedTab.Name == "tabPageTrend" && rbtnTrendByCustomerItem.Checked)
                {
                    bindingSourceTrend.DataSource = null;
                    LoadTab(tabPWCForecast.SelectedTab.Name);
                }
            }
        }

        private void restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestorePriorToImport("utlRestoreTrendByCompanyProductGroupPriorToImport", "Trend by Company Product Group");
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void restoreTrendByCompanyItemPriorToImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestorePriorToImport("utlRestoreTrendByCompanyItemPriorToImport", "Trend by Company Item");
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestorePriorToImport("utlRestoreTrendByCustomerProductGroupPriorToImport", "Trend by Customer Product Group");
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void restoreTrendByCustomerItemPriorToImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestorePriorToImport("utlRestoreTrendByCustomerItemPriorToImport", "Trend by Customer Item");
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void RestorePriorToImport(string storedProcedureName, string tableName)
        {
            if (!Validate())
                return;
            var connectionString = ConfigurationManager.ConnectionStrings["PWCConnectionString"].ToString();
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand
                              {
                                  CommandText = storedProcedureName,
                                  CommandType = CommandType.StoredProcedure,
                                  CommandTimeout = 0,
                                  Connection = connection
                              };
            connection.Open();
            var sb = new StringBuilder(string.Empty);
            using (var dr = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                if (dr.Read())
                {
                    var importError = (int)(dr["errorNumber"]) != 0;
                    if (importError)
                    {
                        sb.Append("Error occured while restoring ").Append(tableName).Append(" prior to import.");
                        sb.Append("\nRestore did not take place.");
                        sb.Append("\nError Number: ").Append(dr["errorNumber"].ToString());
                        sb.Append("\nError Message: ").Append(dr["errorMessage"].ToString());
                        sb.Append("\nError Severity: ").Append(dr["errorSeverity"].ToString());
                        sb.Append("\nError State: ").Append(dr["errorState"].ToString());
                        sb.Append("\nLine Number: ").Append(dr["errorLine"].ToString());
                        sb.Append("\nProcedure Name: ").Append(dr["errorProcedure"].ToString());
                    }
                    else
                    {
                        sb.Append("Restore ").Append(tableName).Append(" prior to import succeeded.");
                        sb.Append("\nRows restored: ").Append(dr["rowRestored"].ToString());
                    }
                }
            }
            MessageBox.Show(sb.ToString(), "PWC Forecast");
        }

        private void salesRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmExport = new frmSalesRateExport(_company, _customerKey);
                frmExport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void forecastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmExport = new frmForecastExport(_company);
                frmExport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmCustomer = new frmCustomer(_company);
                var customerCollectionInvalidatedDelegate = new frmCustomer.CustomerCollectionInvalidatedDelegate(frmPWCForecast_CustomerCollectionInvalidated);
                frmCustomer.CustomerCollectionInvalidated -= customerCollectionInvalidatedDelegate;
                frmCustomer.CustomerCollectionInvalidated += customerCollectionInvalidatedDelegate;
                frmCustomer.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmItem = new frmItem();
                frmItem.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmBrand = new frmBrand();
                frmBrand.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void productCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmProductCategory = new frmProductCategory();
                frmProductCategory.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void productGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmProductGroup = new frmProductGroup();
                var productGroupCollectionInvalidatedDelegate = new frmProductGroup.ProductGroupCollectionInvalidatedDelegate(frmPWCForecast_ProductGroupCollectionInvalidated);
                frmProductGroup.ProductGroupCollectionInvalidated -= productGroupCollectionInvalidatedDelegate;
                frmProductGroup.ProductGroupCollectionInvalidated += productGroupCollectionInvalidatedDelegate;
                frmProductGroup.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void bonusItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmExport = new frmBonusAndDiscontinuedExport(_company, _customerKey, ExportType.Bonus);
                frmExport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void discontinuedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmExport = new frmBonusAndDiscontinuedExport(_company, _customerKey, ExportType.Discontinued);
                frmExport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void generateCompanyForecastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                if (_company == null)
                {
                    MessageBox.Show("Please ennter a Company Code.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                _company.GenerateAndSaveForecast();
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void actualVsForecastComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                var frmForecastVarianceReport = new frmForecastVarianceReport(_company, _customerKey);
                frmForecastVarianceReport.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region Textboxes Event Handlers
        private void txtCompanyCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCompanyCode.Text.Length == 0)
                {
                    _company = null;
                    txtCompanyName.Text = string.Empty;
                }
                else if (txtCompanyCode.Text.Length != 3)
                {
                    MessageBox.Show("Please enter a 3 character Company Code.", "PWC Forecast");
                    e.Cancel = true;
                }
                else if ((_company != null && _company.CompanyCode != txtCompanyCode.Text) ||
                    _company == null)
                {
                    _customerKey = null;
                    bindingSourceForecast.DataSource = null;
                    bindingSourceForecastParameter.DataSource = null;
                    bindingSourceSalesRate.DataSource = null;
                    bindingSourceTrend.DataSource = null;
                    bindingSourceBonusAndDiscontinued.DataSource = null;

                    if (txtCompanyCode.Text.Length == 0)
                        return;

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
                    cboCustomer.DataSource = Utility.GetInstance().GetCustomerDropDownCollection(_company, "default");
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private DateTime GetLatestPOSSalesEndDate(Customer customer)
        {
            var latestPOSSalesEndDate = customer.POSSalesEndDate.Value;
            var savedForecastCollection = (List<PWC.PersistenceLayer.Utility.ForecastDateMethod>)bindingSourceSavedForecast.DataSource;
            if (savedForecastCollection.Count > 1)
                latestPOSSalesEndDate = DateTime.Parse(savedForecastCollection[1].POSSalesEndDate);
            return latestPOSSalesEndDate;
        }

        private void GetDefaultPOSSalesEndDate()
        {
            if (rbtnSR.Checked)
            {
                var posDateAndGapCollection = new POSLatestDateAndGap.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, SqlDateTime.Null, (byte)nudNumberOfPosWeeksOrSalesMonths.Value);
                posDateAndGapCollection.Load();
                if (posDateAndGapCollection.Count > 0)
                {
                    var posLatestDateAndGap = posDateAndGapCollection[0];
                    dtpMonthEndDate.Value = posLatestDateAndGap.LatestWeekEndDate.Value;
                    if (posLatestDateAndGap.GapFlag)
                        MessageBox.Show("There's gap in the POS period selected or no POS data.", "PWC Forecast");
                }
                else
                    MessageBox.Show("There's gap in the POS period selected or no POS data.", "PWC Forecast");
            }
            else
            {
                var actualSalesDateAndGapCollection = new ActualSalesLatestDateAndGap.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, SqlDateTime.Null, (byte)nudNumberOfPosWeeksOrSalesMonths.Value);
                actualSalesDateAndGapCollection.Load();
                if (actualSalesDateAndGapCollection.Count > 0)
                {
                    var actualSalesDateAndGap = actualSalesDateAndGapCollection[0];
                    dtpMonthEndDate.Value = actualSalesDateAndGap.LatestActualSalesEndDate.Value;
                    if (actualSalesDateAndGap.GapFlag)
                        MessageBox.Show("There's gap in the Actual Sales period selected or no Actual Sales data.", "PWC Forecast");
                }
                else
                    MessageBox.Show("There's gap in the Actual Sales period selected or no Actual Sales data.", "PWC Forecast");
            }
        }

        private void ValidatePOSSalesEndDate()
        {
            var customer = _company.CustomerCollection[_customerKey];
            if (rbtnSR.Checked)
            {
                var posDateAndGapCollection = new POSLatestDateAndGap.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, dtpMonthEndDate.Value, (byte)nudNumberOfPosWeeksOrSalesMonths.Value);
                posDateAndGapCollection.Load();
                if (posDateAndGapCollection.Count > 0 && posDateAndGapCollection[0].GapFlag)
                    MessageBox.Show("There's gap in the POS period selected or no POS data.", "PWC Forecast");
                customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
            }
            else
            {
                var actualSalesDateAndGapCollection = new ActualSalesLatestDateAndGap.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, dtpMonthEndDate.Value, (byte)nudNumberOfPosWeeksOrSalesMonths.Value);
                actualSalesDateAndGapCollection.Load();
                if (actualSalesDateAndGapCollection.Count > 0 && actualSalesDateAndGapCollection[0].GapFlag)
                    MessageBox.Show("There's gap in the Actual Sales period selected or no Actual Sales data.", "PWC Forecast");
                customer.RollingAvageNumberOfMonths = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
            }
            customer.POSSalesEndDate = dtpMonthEndDate.Value;
        }

        private void txtCompanyCode_GotFocus(object sender, EventArgs e)
        {
            try
            {
                txtCompanyCode.SelectAll();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void txtGotoItem_GotFocus(object sender, System.EventArgs e)
        {
            try
            {
                txtGotoItem.SelectAll();
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

            // upper case
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtPipeLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char C = e.KeyChar;
            //if (Char.IsLetter(C) == true)
            //{
            //    e.Handled = true;
            //    System.Media.SystemSounds.Beep.Play();
            //}

            // upper case and add 'y' to pipeline entry
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if ((e.KeyChar == 'P' || e.KeyChar == 'C' || e.KeyChar == 'N') &&
                (dgvParameter.CurrentCell.Value.ToString().Length == 4 ||
                dgvParameter.CurrentCell.Value.ToString().Length == 0))
            {
                dgvParameter.CurrentCell.Value = (SqlString)string.Format("{0}Y", e.KeyChar);
                //dgvParameter.CurrentCell.Selected = false;
                //e.Handled = true;
            }
        }

        private void txtGotoItem_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGotoItem.Text))
                    return;
                if (!Regex.IsMatch(txtGotoItem.Text, @"^\d{2}-\d{5}-[A-Z0-9]{2}$"))
                {
                    MessageBox.Show("Please enter Item Number in ##-#####-AA", "PWC Forecast");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region dtpMonthEndDate, nudNumberOfPosWeeksOrSalesMonths Event Handlers
        private void dtpMonthEndDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (rbtnSR.Checked && dtpMonthEndDate.Value.DayOfWeek != DayOfWeek.Sunday)
                {
                    MessageBox.Show("Please select a week ending Sunday.", "PWC Forecast");
                    e.Cancel = true;
                    return;
                }
                if (txtCompanyCode.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a Company Code.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                if (cboCustomer.SelectedIndex < 1)
                {
                    MessageBox.Show("Please select a Customer Number.", "PWC Forecast");
                    cboCustomer.Focus();
                    return;
                }
                ValidatePOSSalesEndDate();

                // force current tab to refresh
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dtpMonthEndDate_GotFocus(object sender, System.EventArgs e)
        {
            try
            {
                dtpMonthEndDate.Select();
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void nudNumberOfPosWeeksOrSalesMonths_GotFocus(object sender, System.EventArgs e)
        {
            try
            {
                nudNumberOfPosWeeksOrSalesMonths.Select(0, 100);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void nudNumberOfPosWeeksOrSalesMonths_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCompanyCode.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a Company Code.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                if (cboCustomer.SelectedIndex < 1)
                {
                    MessageBox.Show("Please select a Customer Number.", "PWC Forecast");
                    cboCustomer.Focus();
                    return;
                }
                ValidatePOSSalesEndDate();

                // force current tab to refresh
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region Buttons Event Handlers
        private void btnGenerateSalesRate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    //System.Xml.Linq.XElement customerXml = customer.ToXml();
                    //customerXml.Save("customer.xml");
                    if ((customer.ForecastSalesRateAction == ForecastSalesRateAction.Get &&
                        customer.ForecastSalesRateCollection.Count > 0) ||
                        PersistenceLayer.Utility.GetInstance().DoesForecastSalesRateExist(_customerKey.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate))
                    {
                        if (MessageBox.Show("A saved Sales Rate for the period exists.\nDo you want to regenerate new Sales Rate?", "PWC Forecast", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    Cursor = Cursors.WaitCursor;
                    customer.ForecastSalesRateCollection = null;
                    customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                    customer.POSSalesEndDate = dtpMonthEndDate.Value;
                    customer.ForecastSalesRateAction = ForecastSalesRateAction.Generate;
                    bindingSourceSalesRate.DataSource = customer.ForecastSalesRateCollection;
                    lblSalesRateDescription.Text = string.Format("Company: {0} - Customer: {1} - Generated Sales Rate (POS ends {2} for {3} weeks)", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), customer.POSNumberOfWeeks);
                    if (customer.ForecastSalesRateCollection != null && customer.ForecastSalesRateCollection.Count > 0)
                        dgvSalesRate.Focus();
                    Cursor = Cursors.Arrow;
                }
                else
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnApplySalesRate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    if (customer.ForecastSalesRateCollection.Count <= 0)
                        MessageBox.Show("The Sales Rate collection is empty.", "PWC Forecast");
                    else
                    {
                        Cursor = Cursors.WaitCursor;
                        customer.ForecastSalesRateCollection.UpdateParameterCollection();
                        // force a refresh for updated sales rates to show
                        customer.ForecastParameterCollection = null;
                        Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnSaveSalesRate_Click(object sender, EventArgs e)
        {
            Customer customer;
            try
            {
                if (_company == null || _customerKey == null)
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                customer = _company.CustomerCollection[_customerKey];
                if (customer.ForecastSalesRateCollection.Count <= 0)
                {
                    MessageBox.Show("The Sales Rate collection is empty.", "PWC Forecast");
                    return;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                using (var transaction = new Transaction())
                {
                    switch (customer.ForecastSalesRateAction)
                    {
                        case ForecastSalesRateAction.Get:
                            transaction.Enlist(customer.ForecastSalesRateCollection);
                            customer.ForecastSalesRateCollection.Save();

                            transaction.Commit();
                            break;
                        case ForecastSalesRateAction.Generate:
                            // save a copy of the genenerated collection
                            var generatedCollection = customer.ForecastSalesRateCollection;

                            // delete the existing collection
                            customer.ForecastSalesRateAction = ForecastSalesRateAction.Get; // do a get for delete
                            customer.ForecastSalesRateCollection.SetHeader = generatedCollection.SetHeader; // restore the version before the get

                            foreach (var salesRate in customer.ForecastSalesRateCollection.Where(salesRate => (bool)(salesRate.HasComment || salesRate.HasOverride)))
                            {
                                transaction.Enlist(salesRate.ForecastSalesRateCommentAndOverrideCollection);
                                salesRate.ForecastSalesRateCommentAndOverrideCollection.Delete();
                            }

                            transaction.Enlist(customer.ForecastSalesRateCollection);
                            customer.ForecastSalesRateCollection.Delete();

                            // insert the generated collection to DB
                            generatedCollection.MarkNew();
                            transaction.Enlist(generatedCollection);
                            generatedCollection.Save();

                            foreach (var generatedSalesRate in generatedCollection.Where(generatedSalesRate => (bool) (generatedSalesRate.HasComment || generatedSalesRate.HasOverride)))
                            {
                                generatedSalesRate.ForecastSalesRateCommentAndOverrideCollection.MarkNew();
                                transaction.Enlist(generatedSalesRate.ForecastSalesRateCommentAndOverrideCollection);
                                generatedSalesRate.ForecastSalesRateCommentAndOverrideCollection.Save();
                            }

                            transaction.Commit();
                            break;
                    }
                }
                lblSalesRateDescription.Text = string.Format("Company: {0} - Customer: {1} - Existing Sales Rate (POS ends {2} for {3} weeks)", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), customer.POSNumberOfWeeks);
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
            finally
            {
                // refresh the object and screen
                customer.ForecastSalesRateCollection = null;
                bindingSourceSalesRate.DataSource = null;
                bindingSourceSalesRate.DataSource = customer.ForecastSalesRateCollection;

                // refresh saved forecast dropdown
                bindingSourceSavedSalesRate.DataSource = PersistenceLayer.Utility.GetInstance().GetSavedSalesRateDateCollection(_customerKey.CompanyCode.Value, _customerKey.CustomerNumber.Value, 12);

                // sync the grid with business object collection
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
        }

        private void btnGenerateForecast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];

                    //System.IO.StreamWriter sw = new System.IO.StreamWriter("customer.xml", false);
                    //sw.Write(customer.ToXml());
                    //sw.Close();

                    var calendar = Calendar.GetInstance();
                    if (GetLatestPOSSalesEndDate(customer) > customer.POSSalesEndDate.Value && 
                        String.CompareOrdinal(calendar.GetYYMM(customer.POSSalesEndDate.Value), calendar.GetYYMM(DateTime.Today)) < 0)
                    {
                        MessageBox.Show("Past Forecast cannot be overwritten.", "PWC Forecast", MessageBoxButtons.OK);
                        return;
                    }
                    if ((customer.ForecastAction == ForecastAction.Get && customer.ForecastCollection.Count > 0) ||
                        PersistenceLayer.Utility.GetInstance().DoesForecastExist(_customerKey.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate))
                    {
                        if (MessageBox.Show("A saved Forecast for the period exists.\nDo you want to regenerate new Forecast?", "PWC Forecast", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    Cursor = Cursors.WaitCursor;
                    customer.ForecastCollection = null;
                    if (customer.ForecastMethod == "SR")
                        customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                    else
                        customer.RollingAvageNumberOfMonths = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                    customer.POSSalesEndDate = dtpMonthEndDate.Value;
                    customer.ForecastAction = ForecastAction.Generate;
                    bindingSourceForecast.DataSource = customer.ForecastCollection;
                    lblForecastDescription.Text = string.Format("Company: {0}, Customer: {1} - Generated Forecast: (POS/Actual Sale ends {2})", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
                    if (customer.ForecastCollection != null && customer.ForecastCollection.Count > 0)
                        dgvForecast.Focus();
                    Cursor = Cursors.Arrow;
                }
                else
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnSaveForecast_Click(object sender, EventArgs e)
        {
            Customer customer = null;
            try
            {
                if (_company == null || _customerKey == null)
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                customer = _company.CustomerCollection[_customerKey];
                if (customer.ForecastCollection.Count <= 0)
                {
                    MessageBox.Show("The Forecast collection is empty.", "PWC Forecast");
                    return;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
                return;
            }
                
            try
            {
                Cursor = Cursors.WaitCursor;
                using (var transaction = new Transaction())
                {
                    switch (customer.ForecastAction)
                    {
                        case ForecastAction.Get:
                            transaction.Enlist(customer.ForecastCollection);
                            customer.ForecastCollection.Save();

                            transaction.Commit();
                            break;
                        case ForecastAction.Generate:
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
                            foreach (var generatedForecast in generatedCollection.Where(forecast => (bool) (forecast.HasComment || forecast.HasOverride)))
                            {
                                generatedForecast.ForecastCommentAndOverrideCollection.MarkNew();
                                transaction.Enlist(generatedForecast.ForecastCommentAndOverrideCollection);
                                generatedForecast.ForecastCommentAndOverrideCollection.Save();
                            }

                            transaction.Commit();
                            break;
                    }
                }
                lblForecastDescription.Text = string.Format("Company: {0} - Customer: {1} - Existing Forecast (POS/Actual Sale ends {2})", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
            finally
            {
                // refresh the object and screen
                customer.ForecastCollection = null;
                bindingSourceForecast.DataSource = null;
                bindingSourceForecast.DataSource = customer.ForecastCollection;

                // refresh saved forecast dropdown
                bindingSourceSavedForecast.DataSource = PWC.PersistenceLayer.Utility.GetInstance().GetSavedForecastDateCollection(_customerKey.CompanyCode.Value, _customerKey.CustomerNumber.Value, 12);

                // sync the grid with business object collection
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
        }

        private void btnImportForecast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_company == null || _customerKey == null)
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }

                var osd = new OpenFileDialog { DefaultExt = ".txt", Filter = "Text Files (*.prn;*.txt;*.csv)|*.prn;*.txt;*.csv|All Files (*.*)|*.*" };
                if (osd.ShowDialog() != DialogResult.OK)
                    return;

                var customer = _company.CustomerCollection[_customerKey];
                    
                string line;
                using (var sr = new StreamReader(osd.FileName))
                {
                    sr.ReadLine();
                    line = sr.ReadLine();
                }

                if (line == null)
                {
                    MessageBox.Show("Error reading the txt file.", "PWC Forecast", MessageBoxButtons.OK);
                    return;
                }

                var columns = line.Split('\t');
                if (columns.Length != 41)
                {
                    MessageBox.Show("The number of columns in the csv file must be 41. The error is on line 2.", "PWC Forecast", MessageBoxButtons.OK);
                    return;
                }

                if (columns[0] != _customerKey.CompanyCode && columns[1] != _customerKey.CustomerNumber)
                {
                    MessageBox.Show("Forecast to be imported has different Company and Customer Codes.", "PWC Forecast", MessageBoxButtons.OK);
                    return;
                }

                var posSalesEndDate = Convert.ToDateTime(columns[2]);

                var calendar = Calendar.GetInstance();
                if (GetLatestPOSSalesEndDate(customer) > posSalesEndDate &&
                    String.CompareOrdinal(calendar.GetYYMM(posSalesEndDate), calendar.GetYYMM(DateTime.Today)) < 0)
                {
                    MessageBox.Show("Past Forecast cannot be overwritten.", "PWC Forecast", MessageBoxButtons.OK);
                    return;
                }

                if ((customer.ForecastAction == ForecastAction.Get && customer.ForecastCollection.Count > 0) ||
                    PersistenceLayer.Utility.GetInstance().DoesForecastExist(_customerKey.CompanyCode, _customerKey.CustomerNumber, posSalesEndDate))
                {
                    if (MessageBox.Show("A saved Forecast for the period exists.\nDo you want to import new Forecast?", "PWC Forecast", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }

                customer.POSSalesEndDate = posSalesEndDate;
                dtpMonthEndDate.Value = posSalesEndDate;

                Cursor = Cursors.WaitCursor;
                customer.ForecastAction = ForecastAction.Generate;
                customer.PopulateForecastFromTxt(osd.FileName);
                bindingSourceForecast.DataSource = customer.ForecastCollection;
                lblForecastDescription.Text = string.Format("Company: {0}, Customer: {1} - Imported Forecast: (POS/Actual Sale ends {2})", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
                if (customer.ForecastCollection != null && customer.ForecastCollection.Count > 0)
                    dgvForecast.Focus();
                Cursor = Cursors.Arrow;
            }
            catch (FormatException formatException)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(formatException.Message);
            }
            catch (DataException dataException)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(dataException.Message);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnExportForecast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_company == null || _customerKey == null)
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                    return;
                }
                
                if (dgvForecast.RowCount == 1)
                {
                    MessageBox.Show("There's no Forecast data to export.", "PWC Forecast");
                    return;
                }

                var sfd = new SaveFileDialog { DefaultExt = ".txt", Filter = "Text Files (*.prn;*.txt;*.csv)|*.prn;*.txt;*.csv|All Files (*.*)|*.*" };
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                Cursor = Cursors.WaitCursor;
                var customer = _company.CustomerCollection[_customerKey];

                using (var swForecast = new StreamWriter(sfd.FileName, false))
                {
                    using (var swForecastComment = new StreamWriter(Customer.GetForecastCommentTxtFileName(sfd.FileName), false))
                    {
                        Customer.WriteForecastToTxtHeaders(swForecast, swForecastComment);
                        customer.WriteForecastToText(swForecast, swForecastComment);
                    }
                }

                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void btnGotoItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPWCForecast.SelectedTab != null && !string.IsNullOrEmpty(txtGotoItem.Text))
                {
                    switch (tabPWCForecast.SelectedTab.Name)
                    {
                        case "tabPageSalesRate":
                            GotoItem(dgvSalesRate, "ItemNumberSalesRate");
                            break;
                        case "tabPageTrend":
                            GotoItem(dgvTrend, "ItemNumberTrend");
                            break;
                        case "tabPageActualSales":
                            GotoItem(dgvActualSales, "ItemNumberActualSales");
                            break;
                        case "tabPageParameter":
                            GotoItem(dgvParameter, "ItemNumberParameter");
                            break;
                        case "tabPageBonusAndDiscontinued":
                            GotoItem(dgvBonusAndDiscontinued, "ItemNumberBonus");
                            break;
                        case "tabPageForecast":
                            GotoItem(dgvForecast, "ItemNumberForecast");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void GotoItem(DataGridView dgv, string itemColumnName)
        {
            var found = false;
            for (var rowIndex = dgv.CurrentRow.Index + 1; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                var row = dgv.Rows[rowIndex];
                if (row.Cells[itemColumnName].Value != null &&
                    row.Cells[itemColumnName].Value.ToString() == txtGotoItem.Text)
                {
                    dgv.CurrentCell.Selected = false;
                    foreach (DataGridViewRow r in dgv.SelectedRows)
                        r.Selected = false;
                    dgv.CurrentCell = row.Cells[itemColumnName];
                    row.Selected = true;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
                {
                    var row = dgv.Rows[rowIndex];
                    if (row.Cells[itemColumnName].Value != null &&
                        row.Cells[itemColumnName].Value.ToString() == txtGotoItem.Text)
                    {
                        dgv.CurrentCell.Selected = false;
                        foreach (DataGridViewRow r in dgv.SelectedRows)
                            r.Selected = false;
                        dgv.CurrentCell = row.Cells[itemColumnName];
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void btnMovePLPercentageLeftByMonth_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var startIndex = dgvParameter.Columns["PlPctPY01"].Index;
                var endIndex = dgvParameter.Columns["PlPctNY12"].Index;
                foreach (DataGridViewRow row in dgvParameter.Rows)
                {
                    if (row.Index >= dgvParameter.Rows.Count - 1)
                        break;
                    if (((SqlDecimal)row.Cells["PlPctPY01"].Value).IsNull ||
                        (SqlDecimal)row.Cells["PlPctPY01"].Value == 0)
                    {
                        for (int index = startIndex; index < endIndex; index++)
                            row.Cells[index].Value = row.Cells[index + 1].Value;
                        row.Cells[endIndex].Value = SqlDecimal.Null;
                        if (row.Cells["PipelineStart"].Value.ToString() != "Null")
                            row.Cells["PipelineStart"].Value = (SqlString)Calendar.GetInstance().GetPriorMonthPWCForecastMonth(row.Cells["PipelineStart"].Value.ToString());
                        if (row.Cells["PipelineEnd"].Value.ToString() != "Null")
                            row.Cells["PipelineEnd"].Value = (SqlString)Calendar.GetInstance().GetPriorMonthPWCForecastMonth(row.Cells["PipelineEnd"].Value.ToString());
                        ((ForecastParameter)row.DataBoundItem).Save();
                    }
                }
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnMovePLPercentageRightByMonth_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int startIndex = dgvParameter.Columns["PlPctPY01"].Index;
                int endIndex = dgvParameter.Columns["PlPctNY12"].Index;
                foreach (DataGridViewRow row in dgvParameter.Rows)
                {
                    if (row.Index >= dgvParameter.Rows.Count - 1)
                        break;
                    if (((SqlDecimal)row.Cells["PlPctNY12"].Value).IsNull ||
                        (SqlDecimal)row.Cells["PlPctNY12"].Value == 0)
                    {
                        for (int index = endIndex; index > startIndex; index--)
                            row.Cells[index].Value = row.Cells[index - 1].Value;
                        row.Cells[startIndex].Value = SqlDecimal.Null;
                        if (row.Cells["PipelineStart"].Value.ToString() != "Null")
                            row.Cells["PipelineStart"].Value = (SqlString)Calendar.GetInstance().GetNexMonthPWCForecastMonth(row.Cells["PipelineStart"].Value.ToString());
                        if (row.Cells["PipelineEnd"].Value.ToString() != "Null")
                            row.Cells["PipelineEnd"].Value = (SqlString)Calendar.GetInstance().GetNexMonthPWCForecastMonth(row.Cells["PipelineEnd"].Value.ToString());
                        ((ForecastParameter)row.DataBoundItem).Save();
                    }
                }
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnMovePLPercentageLeftByYear_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var startIndex = dgvParameter.Columns["PlPctPY01"].Index;
                var endIndex = dgvParameter.Columns["PlPctNY12"].Index;
                foreach (DataGridViewRow row in dgvParameter.Rows)
                {
                    if (row.Index >= dgvParameter.Rows.Count - 1)
                        break;
                    var hasData = false;
                    for (var index = startIndex; index < startIndex + 12; index++)
                        if (row.Cells[index].Value.ToString() != "Null" &&
                            (SqlDecimal)row.Cells[index].Value > 0)
                        {
                            hasData = true;
                            break;
                        }
                    if (hasData)
                        continue;
                    for (var index = startIndex; index < endIndex - 12; index = index + 12)
                        for (var subIndex = index + 12; subIndex < index + 24; subIndex++)
                            row.Cells[subIndex - 12].Value = row.Cells[subIndex].Value;
                    for (var index = endIndex - 12; index < endIndex; index++)
                        row.Cells[index].Value = SqlDecimal.Null;
                    if (row.Cells["PipelineStart"].Value.ToString() != "Null")
                        row.Cells["PipelineStart"].Value = (SqlString)Calendar.GetInstance().GetPriorYearPWCForecastMonth(row.Cells["PipelineStart"].Value.ToString());
                    if (row.Cells["PipelineEnd"].Value.ToString() != "Null")
                        row.Cells["PipelineEnd"].Value = (SqlString)Calendar.GetInstance().GetPriorYearPWCForecastMonth(row.Cells["PipelineEnd"].Value.ToString());
                    ((ForecastParameter)row.DataBoundItem).Save();
                }
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void btnMovePLPercentageRightByYear_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var startIndex = dgvParameter.Columns["PlPctPY01"].Index;
                var endIndex = dgvParameter.Columns["PlPctNY12"].Index;
                foreach (DataGridViewRow row in dgvParameter.Rows)
                {
                    if (row.Index >= dgvParameter.Rows.Count - 1)
                        break;
                    var hasData = false;
                    for (var index = endIndex; index > endIndex - 12; index--)
                        if (row.Cells[index].Value.ToString() != "Null" &&
                            (SqlDecimal)row.Cells[index].Value > 0)
                        {
                            hasData = true;
                            break;
                        }
                    if (hasData)
                        continue;
                    for (var index = endIndex; index > startIndex + 12; index = index - 12)
                        for (var subIndex = index - 12; subIndex > index - 24; subIndex--)
                            row.Cells[subIndex + 12].Value = row.Cells[subIndex].Value;
                    for (var index = startIndex; index < startIndex + 12; index++)
                        row.Cells[index].Value = SqlDecimal.Null;
                    if (row.Cells["PipelineStart"].Value.ToString() != "Null")
                        row.Cells["PipelineStart"].Value = (SqlString)Calendar.GetInstance().GetNexYearPWCForecastMonth(row.Cells["PipelineStart"].Value.ToString());
                    if (row.Cells["PipelineEnd"].Value.ToString() != "Null")
                        row.Cells["PipelineEnd"].Value = (SqlString)Calendar.GetInstance().GetNexYearPWCForecastMonth(row.Cells["PipelineEnd"].Value.ToString());
                    ((ForecastParameter)row.DataBoundItem).Save();

                }
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void rbtnBonusAndDiscontinuedByCompany_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                bindingSourceBonusAndDiscontinued.DataSource = null;
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void rbtnBonusAndDiscontinuedByCustomer_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                bindingSourceBonusAndDiscontinued.DataSource = null;
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void rbtnTrend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bindingSourceTrend.DataSource = null;
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void chkShowPriorYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int startColumnIndex = dgvParameter.Columns["PlPctPY01"].Index;
                for (var columnIndex = startColumnIndex; columnIndex < startColumnIndex + 12; columnIndex++)
                    dgvParameter.Columns[columnIndex].Visible = chkShowPriorYear.Checked;
                startColumnIndex = dgvBonusAndDiscontinued.Columns["PY01Bonus"].Index;
                for (var columnIndex = startColumnIndex; columnIndex < startColumnIndex + 12; columnIndex++)
                    dgvBonusAndDiscontinued.Columns[columnIndex].Visible = chkShowPriorYear.Checked;
                startColumnIndex = dgvForecast.Columns["PY01"].Index;
                for (var columnIndex = startColumnIndex; columnIndex < startColumnIndex + 12; columnIndex++)
                    dgvForecast.Columns[columnIndex].Visible = chkShowPriorYear.Checked;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region tabPWCForecast Event Handlers
        private void tabPWCForecast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void LoadTab(string tabName)
        {
            Cursor = Cursors.WaitCursor;
            switch (tabName)
            {
                case "tabPageSalesRate":
                    if (_company != null && _customerKey != null)
                    {
                        var customer = _company.CustomerCollection[_customerKey];
                        var matched = false; int i;
                        for (i = 1; i < cboSavedSalesRate.Items.Count; i++)
                            if (((string)cboSavedSalesRate.Items[i]).IndexOf(customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), StringComparison.Ordinal) > -1)
                            {
                                matched = true;
                                break;
                            }
                        if (matched)
                            cboSavedSalesRate.SelectedIndex = i;
                        else
                        {
                            cboSavedSalesRate.SelectedIndex = 0;
                            lblSalesRateDescription.Text = string.Empty;
                            customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                            customer.POSSalesEndDate = dtpMonthEndDate.Value;
                            bindingSourceSalesRate.DataSource = customer.ForecastSalesRateCollection;
                            if (customer.ForecastSalesRateAction == ForecastSalesRateAction.Get)
                                lblSalesRateDescription.Text = string.Format("Company: {0} - Customer: {1} - Existing Sales Rate (POS ends {2} for {3} weeks)", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), customer.POSNumberOfWeeks);
                            else if (customer.ForecastSalesRateAction == ForecastSalesRateAction.Generate)
                                lblSalesRateDescription.Text = string.Format("Company: {0} - Customer: {1} - Generated Sales Rate (POS ends {2} for {3} weeks)", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), customer.POSNumberOfWeeks);
                        }

                        btnSaveSalesRate.Enabled = customer.ForecastSalesRateAction == ForecastSalesRateAction.Generate;

                        if (customer.ForecastSalesRateCollection.Count > 0)
                            dgvSalesRate.Focus();
                    }
                    break;
                case "tabPageTrend":
                    dgvTrend.Columns["ProductGroup"].Visible = rbtnTrendByCompanyProductGroup.Checked || rbtnTrendByCustomerProductGroup.Checked;
                    dgvTrend.Columns["ItemNumberTrend"].Visible = rbtnTrendByCompanyItem.Checked || rbtnTrendByCustomerItem.Checked;
                    if (rbtnTrendByCompanyItem.Checked)
                    {
                        if (_company != null)
                            bindingSourceTrend.DataSource = _company.ForecastTrendByItemCollection;
                    }
                    else if (rbtnTrendByCustomerItem.Checked)
                    {
                        if (_company != null && _customerKey != null)
                            bindingSourceTrend.DataSource = _company.CustomerCollection[_customerKey].ForecastTrendByItemCollection;
                    }
                    else if (rbtnTrendByCompanyProductGroup.Checked)
                    {
                        if (_company != null)
                            bindingSourceTrend.DataSource = _company.ForecastTrendByProductGroupCollection;
                    }
                    else if (rbtnTrendByCustomerProductGroup.Checked)
                    {
                        if (_company != null && _customerKey != null)
                            bindingSourceTrend.DataSource = _company.CustomerCollection[_customerKey].ForecastTrendByProductGroupCollection;
                    }
                    if (bindingSourceTrend.Count > 0)
                        dgvTrend.Focus();
                    break;
                case "tabPageParameter":
                    if (_company != null && _customerKey != null)
                    {
                        var customer = _company.CustomerCollection[_customerKey];
                        bindingSourceForecastParameter.DataSource = customer.ForecastParameterCollection;
                        if (customer.ForecastParameterCollection.Count > 0)
                            dgvParameter.Focus();
                    }
                    break;
                case "tabPageBonusAndDiscontinued":
                    if (rbtnBonusAndDiscontinuedByCustomer.Checked)
                    {
                        if (_company != null && _customerKey != null)
                        {
                            var customer = _company.CustomerCollection[_customerKey];
                            bindingSourceBonusAndDiscontinued.DataSource = customer.BonusAndDiscontinuedCollection;
                        }
                    }
                    else if (_company != null)
                        bindingSourceBonusAndDiscontinued.DataSource = _company.BonusAndDiscontinuedCollection;
                    if (bindingSourceBonusAndDiscontinued.Count > 0)
                        dgvParameter.Focus();
                    break;
                case "tabPageForecast":
                    if (_company != null && _customerKey != null)
                    {
                        var customer = _company.CustomerCollection[_customerKey];
                        var matched = false; int i;
                        for (i = 1; i < cboSavedForecast.Items.Count; i++)
                            if (((PersistenceLayer.Utility.ForecastDateMethod)cboSavedForecast.Items[i]).POSSalesEndDate.IndexOf(customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), StringComparison.Ordinal) > -1)
                            {
                                matched = true;
                                break;
                            }
                        if (matched)
                            cboSavedForecast.SelectedIndex = i;
                        else
                        {
                            cboSavedForecast.SelectedIndex = 0;
                            lblForecastDescription.Text = string.Empty;
                            if (customer.ForecastMethod == "SR")
                                customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                            else
                                customer.RollingAvageNumberOfMonths = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                            customer.POSSalesEndDate = dtpMonthEndDate.Value;
                            bindingSourceForecast.DataSource = customer.ForecastCollection;
                            if (customer.ForecastAction == ForecastAction.Get)
                                lblForecastDescription.Text = string.Format("Company: {0}, Customer: {1} - Existing Forecast (POS/Actual Sale ends {2})", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
                            else if (customer.ForecastAction == ForecastAction.Generate)
                                lblForecastDescription.Text = string.Format("Company: {0}, Customer: {1} - Generated Forecast (POS/Actual Sale ends {2})", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"));

                        }

                        btnSaveForecast.Enabled = customer.ForecastAction == ForecastAction.Generate;

                        if (customer.ForecastCollection.Count > 0)
                            dgvForecast.Focus();
                    }
                    break;
            }
            Cursor = Cursors.Arrow;
        }
        #endregion

        #region dgvParameter Event Handlers
        private void dgvParameter_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (_company == null || _customerKey == null)
                    return;
                var column = dgvParameter.Columns[e.ColumnIndex];
                if (column.Name == "ItemNumberParameter")
                {
                    if (e.RowIndex < _company.CustomerCollection[_customerKey].ForecastParameterCollection.Count)
                        e.Cancel = true;
                    else if (chkUseClipboardDataOnNewRow.Checked)
                        CopyClipboardToNewRow(dgvParameter, "ItemNumberParameter", e.RowIndex, true);
                    else
                    {
                        var row = dgvParameter.Rows[e.RowIndex];
                        // default sales rates to 0
                        row.Cells["ProjectedSalesRateExisting"].Value = SqlDecimal.ConvertToPrecScale(0, 5, 2);
                        row.Cells["ProjectedSalesRateNew"].Value = SqlDecimal.ConvertToPrecScale(0, 5, 2);
                        // default pl start end to CY01
                        row.Cells["PipelineStart"].Value = new SqlString("CY01");
                        row.Cells["PipelineEnd"].Value = new SqlString("CY01");
                        row.Cells["PlPctCY01"].Value = SqlDecimal.ConvertToPrecScale(100, 5, 2);
                    }
                }
                else if (Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$")) // CY##, NY##, PY##
                {
                    if (!((SqlString)dgvParameter.Rows[e.RowIndex].Cells["PipelineStart"].Value).IsNull &&
                        !((SqlString)dgvParameter.Rows[e.RowIndex].Cells["PipelineEnd"].Value).IsNull)
                    {
                        var plStart = dgvParameter.Rows[e.RowIndex].Cells["PipelineStart"].Value.ToString();
                        var plEnd = dgvParameter.Rows[e.RowIndex].Cells["PipelineEnd"].Value.ToString();
                        var calendar = Calendar.GetInstance();
                        if (String.CompareOrdinal(calendar.GetYYMM(column.HeaderText), calendar.GetYYMM(plStart)) < 0 ||
                            String.CompareOrdinal(calendar.GetYYMM(column.HeaderText), calendar.GetYYMM(plEnd)) > 0)
                            //calendar.GetYYMM(column.HeaderText).CompareTo(calendar.GetYYMM(CommentOverrideDateTime.Today)) < 0)
                            //calendar.GetYYMM(column.HeaderText).CompareTo(calendar.GetYYMM(CommentOverrideDateTime.Today.AddMonths(12))) > 0)
                            e.Cancel = true;
                    }
                    else
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvParameter.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0)
                    return;
                if (Regex.IsMatch(dgvParameter.Columns[e.ColumnIndex].HeaderText, @"^[PCN]Y[01]\d$")) // PY##, CY##, NY## columns
                {
                    if (e.Value != null)
                    {
                        var decValue = (SqlDecimal)e.Value;
                        e.Value = decValue.IsNull ? "Null" : decValue.Value.ToString("0.00");
                        if (!decValue.IsNull && decValue.Value != decimal.Zero)
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        e.FormattingApplied = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                var column = dgvParameter.Columns[e.ColumnIndex];
                if (e == null || e.Value == null)
                    return;
                try
                {
                    // default parsing fails to convert string to sqlstring
                    // assist it here.
                    if (column.Name == "PipelineStart" ||
                        column.Name == "PipelineEnd" ||
                        column.Name == "ItemNumberParameter")
                    {
                        e.Value = new SqlString(e.Value.ToString());
                        e.ParsingApplied = true;
                    }
                    else if (Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$")) // PY##, CY##, NY## columns
                    {
                        if (e.Value.ToString() == "Null")
                        {
                            e.Value = SqlDecimal.Null;
                            e.ParsingApplied = true;
                        }
                    }
                }
                catch (FormatException)
                {
                    // Set to false in case another CellParsing handler
                    // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                    e.ParsingApplied = false;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvParameter.IsCurrentCellDirty)
                    return;
                _dgvParameterRowDirty = true;
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    dgvParameter.CancelEdit();
                    txtCompanyCode.Focus();
                    return;
                }
                if (_customerKey == null)
                {
                    MessageBox.Show("Please enter Customer Number.", "PWC Forecast");
                    dgvParameter.CancelEdit();
                    cboCustomer.Focus();
                    return;
                }
                var column = dgvParameter.Columns[e.ColumnIndex];
                var row = dgvParameter.Rows[e.RowIndex];
                if (e.FormattedValue == null)
                {
                    row.ErrorText = "Entry is required";
                    e.Cancel = true;
                    return;
                }
                var formattedValue = e.FormattedValue.ToString();
                switch (column.Name)
                {
                    case "ItemNumberParameter":
                        if ("803|805".IndexOf(_company.CompanyCode.Value, StringComparison.Ordinal) > -1 && !Regex.IsMatch(formattedValue, @"^\d{2}-\d{5}-[A-Z0-9]{2}$"))
                        {
                            row.ErrorText = "Please enter Item Number in ##-#####-AA";
                            e.Cancel = true;
                        }
                        else if ("803|805".IndexOf(_company.CompanyCode.Value, StringComparison.Ordinal) < 0 &&  !Regex.IsMatch(formattedValue, @"^\d{2}-\d{5}-[A-Z0-9]\d$"))
                        {
                            row.ErrorText = "Please enter Item Number in ##-#####-A#";
                            e.Cancel = true;
                        }
                        else
                        {
                            var itemCollection = new Item.ParameteredCollection(formattedValue, SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
                            itemCollection.Load();
                            if (itemCollection.Count == 0)
                            {
                                row.ErrorText = "Item does not exist in Item Master";
                                e.Cancel = true;
                            }
                            else if (_company.CustomerCollection[_customerKey].ForecastParameterCollection.ContainsKey(new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, formattedValue)))
                            {
                                row.ErrorText = "Item already exists in Parameters";
                                e.Cancel = true;
                            }
                            else
                            {
                                // the object may not exists for new record
                                // only update the screen
                                row.Cells["ItemNumberParameter"].Value = (SqlString)formattedValue;
                            }
                        }
                        break;
                    case "StoreCountNew":
                    case "StoreCountExisting":
                        if (!Regex.IsMatch(formattedValue, @"^\-?\d{1,6}$"))
                        {
                            row.ErrorText = "Please enter a numeric value";
                            e.Cancel = true;
                        }
                        break;
                    case "InitialQtyPerNewStore":
                        if (formattedValue == string.Empty || !Regex.IsMatch(formattedValue, @"^\d{0,5}(\.\d{1,2})?$"))
                        {
                            row.ErrorText = "Please enter Initial Qty Per New Store in #####.##";
                            e.Cancel = true;
                        }
                        break;
                    case "ProjectedSalesRateNew":
                    case "ProjectedSalesRateExisting":
                        if (formattedValue == string.Empty || !Regex.IsMatch(formattedValue, @"^\d{0,3}(\.\d{1,2})?$"))
                        {
                            row.ErrorText = "Please enter Sales Rate in ###.##";
                            e.Cancel = true;
                        }
                        else if (decimal.Parse(formattedValue) > 100)
                        {
                            row.ErrorText = "Sales Rate cannot be greater 100";
                            e.Cancel = true;
                        }
                        break;
                    case "PipelineEnd":
                    case "PipelineStart":
                        if (!Regex.IsMatch(formattedValue, @"^[PCN]Y[01]\d$"))
                        {
                            row.ErrorText = "Please enter month in PY##, CY##, NY##";
                            e.Cancel = true;
                        }
                        else if (int.Parse(formattedValue.Substring(2)) > 12)
                        {
                            row.ErrorText = "Please enter month from 01 to 12";
                            e.Cancel = true;
                        }
                        else if (column.Name == "PipelineStart")
                        {
                            var startIndex = row.Cells["PlPctPY01"].ColumnIndex;
                            var endIndex = row.Cells["PlPctNY12"].ColumnIndex;
                            for (var index = startIndex; index <= endIndex; index++)
                                row.Cells[index].Value = row.Cells[index].OwningColumn.HeaderText == formattedValue ? SqlDecimal.ConvertToPrecScale(100, 5, 2) : SqlDecimal.Null;
                            row.Cells["PipelineStart"].Value = (SqlString)formattedValue;
                        }
                        break;
                    default:
                        if (Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$") &&
                            formattedValue != "Null") // PL##, CY##, NY##
                        {
                            if (formattedValue == string.Empty || !Regex.IsMatch(formattedValue, @"^\d{0,3}(\.\d{1,2})?$"))
                            {
                                row.ErrorText = "Please enter Trend Factor Override in ###.##";
                                e.Cancel = true;
                            }
                            else if (decimal.Parse(formattedValue) > 100)
                            {
                                row.ErrorText = "Trend Factor Override cannot be greater 100";
                                e.Cancel = true;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;

                var newColumn = dgvParameter.Columns[e.ColumnIndex];
                if (newColumn == null || newColumn.SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;

                var oldColumn = _dgvParameterSortedColumn;

                // If oldColumn is null, then the DataGridView is not currently sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && _dgvParameterSortOrder == System.Windows.Forms.SortOrder.Ascending)
                        _dgvParameterSortOrder = System.Windows.Forms.SortOrder.Descending;
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        _dgvParameterSortOrder = System.Windows.Forms.SortOrder.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                    _dgvParameterSortOrder = System.Windows.Forms.SortOrder.Ascending;

                if (_company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.ForecastParameterCollection.Sort(dgvParameter.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvParameterSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceForecastParameter.DataSource = null;
                    bindingSourceForecastParameter.DataSource = customer.ForecastParameterCollection;
                    _dgvParameterSortedColumn = newColumn;
                    newColumn.HeaderCell.SortGlyphDirection = _dgvParameterSortOrder;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dgvParameter_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = e.Control as TextBox;
            if (tb == null)
                return;
            try
            {
                var column = dgvParameter.Columns[dgvParameter.CurrentCell.ColumnIndex];
                if ((column.Name == "ItemNumberParameter" ||
                     column.Name == "PipelineStart" ||
                     column.Name == "PipelineEnd"))
                {
                    var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                    tb.KeyPress -= keyPressEventHandler;
                    tb.KeyPress += keyPressEventHandler;
                }
                var keyEventHandler = new KeyEventHandler(dgvParameter_tb_KeyUp);
                tb.KeyUp -= keyEventHandler;
                tb.KeyUp += keyEventHandler;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_tb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (_dgvParameterRowDirty && e.KeyCode == Keys.Escape && _company != null && _customerKey != null)
                {
                    var itemNumber = (SqlString)dgvParameter.CurrentRow.Cells["ItemNumberParameter"].Value;
                    var param = new ForecastParameter(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber);
                    param.Load();
                    _company.CustomerCollection[_customerKey].ForecastParameterCollection[new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber)] = param;
                    dgvParameter.CurrentRow.Cells["StoreCountExisting"].Value = param.StoreCountExisting;
                    dgvParameter.CurrentRow.Cells["StoreCountNew"].Value = param.StoreCountNew;
                    dgvParameter.CurrentRow.Cells["InitialQtyPerNewStore"].Value = param.InitialQtyPerNewStore;
                    dgvParameter.CurrentRow.Cells["ProjectedSalesRateExisting"].Value = param.ProjectedSalesRateExisting;
                    dgvParameter.CurrentRow.Cells["ProjectedSalesRateNew"].Value = param.ProjectedSalesRateNew;
                    dgvParameter.CurrentRow.Cells["PipelineStart"].Value = param.PipelineStart;
                    dgvParameter.CurrentRow.Cells["PipelineEnd"].Value = param.PipelineEnd;
                    dgvParameter.CurrentRow.Cells["OneTimeItemFlag"].Value = param.OneTimeItemFlag;
                    dgvParameter.CurrentRow.Cells["PlPctPY01"].Value = param.PlPctPY01;
                    dgvParameter.CurrentRow.Cells["PlPctPY02"].Value = param.PlPctPY02;
                    dgvParameter.CurrentRow.Cells["PlPctPY03"].Value = param.PlPctPY03;
                    dgvParameter.CurrentRow.Cells["PlPctPY04"].Value = param.PlPctPY04;
                    dgvParameter.CurrentRow.Cells["PlPctPY05"].Value = param.PlPctPY05;
                    dgvParameter.CurrentRow.Cells["PlPctPY06"].Value = param.PlPctPY06;
                    dgvParameter.CurrentRow.Cells["PlPctPY07"].Value = param.PlPctPY07;
                    dgvParameter.CurrentRow.Cells["PlPctPY08"].Value = param.PlPctPY08;
                    dgvParameter.CurrentRow.Cells["PlPctPY09"].Value = param.PlPctPY09;
                    dgvParameter.CurrentRow.Cells["PlPctPY10"].Value = param.PlPctPY10;
                    dgvParameter.CurrentRow.Cells["PlPctPY11"].Value = param.PlPctPY11;
                    dgvParameter.CurrentRow.Cells["PlPctPY12"].Value = param.PlPctPY12;
                    _dgvParameterRowDirty = false;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvParameter.IsCurrentRowDirty)
                    return;

                var row = dgvParameter.Rows[e.RowIndex];
                if (row.Cells["ItemNumberParameter"].Value == null ||
                    row.Cells["StoreCountExisting"].Value == null ||
                    row.Cells["StoreCountNew"].Value == null ||
                    row.Cells["InitialQtyPerNewStore"].Value == null ||
                    row.Cells["ProjectedSalesRateExisting"].Value == null ||
                    row.Cells["ProjectedSalesRateNew"].Value == null ||
                    row.Cells["PipelineStart"].Value == null ||
                    row.Cells["PipelineEnd"].Value == null)
                {
                    row.ErrorText = "Please enter data for all cells from Item# through Pipeline End";
                    e.Cancel = true;
                    return;
                }

                if (row.Cells["ItemNumberParameter"].Value.ToString() == "Null" ||
                    row.Cells["StoreCountExisting"].Value.ToString() == "Null" ||
                    row.Cells["StoreCountNew"].Value.ToString() == "Null" ||
                    row.Cells["InitialQtyPerNewStore"].Value.ToString() == "Null" ||
                    row.Cells["ProjectedSalesRateExisting"].Value.ToString() == "Null" ||
                    row.Cells["ProjectedSalesRateNew"].Value.ToString() == "Null" ||
                    row.Cells["PipelineStart"].Value.ToString() == "Null" ||
                    row.Cells["PipelineEnd"].Value.ToString() == "Null")
                {
                    row.ErrorText = "Please enter data for all cells from Item# through Pipeline End";
                    e.Cancel = true;
                    return;
                }

                SqlString itemNumber = row.Cells["ItemNumberParameter"].Value.ToString();
                if (row.Cells["PipelineStart"].Value.ToString() != "Null" &&
                    row.Cells["PipelineEnd"].Value.ToString() != "Null")
                {
                    var calendar = Calendar.GetInstance();
                    var plStartYYMM = calendar.GetYYMM(row.Cells["PipelineStart"].Value.ToString());
                    var plEndYYMM = calendar.GetYYMM(row.Cells["PipelineEnd"].Value.ToString());
                    if (String.CompareOrdinal(plStartYYMM, plEndYYMM) > 0)
                    {
                        row.ErrorText = "Pipeline Start cannot be later than Pipeline End";
                        e.Cancel = true;
                        return;
                    }
                    SqlDecimal percentTotal = 0;
                    foreach (DataGridViewColumn column in dgvParameter.Columns)
                    {
                        if (column.HeaderText.IndexOf("PY", StringComparison.Ordinal) > -1 || column.HeaderText.IndexOf("CY", StringComparison.Ordinal) > -1 || column.HeaderText.IndexOf("NY", StringComparison.Ordinal) > -1)
                        {
                            var columnHeaderYYMM = calendar.GetYYMM(column.HeaderText);
                            if (columnHeaderYYMM.CompareTo(plStartYYMM) >= 0 &&
                                columnHeaderYYMM.CompareTo(plEndYYMM) <= 0)
                                percentTotal += ((SqlDecimal)(row.Cells[column.Index].Value)).IsNull ? 0 : (SqlDecimal)(row.Cells[column.Index].Value);
                            if (columnHeaderYYMM.CompareTo(plEndYYMM) > 0)
                                break;
                        }
                    }
                    if (percentTotal != 100)
                    {
                        row.ErrorText = "Total Trend Factor Overrides is not 100%";
                        e.Cancel = true;
                        return;
                    }
                }
                var parameterKey = new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber);
                ForecastParameter param;
                var customer = _company.CustomerCollection[_customerKey];
                // new record
                if (e.RowIndex >= customer.ForecastParameterCollection.Count)
                {
                    if (customer.ForecastParameterCollection.ContainsKey(parameterKey))
                    {
                        row.ErrorText = "Item already exists for the Customer";
                        e.Cancel = true;
                        return;
                    }
                    param = customer.ForecastParameterCollection.Create(parameterKey);
                    param.StoreCountExisting = (SqlInt32)(row.Cells["StoreCountExisting"].Value);
                    param.StoreCountNew = (SqlInt32)(row.Cells["StoreCountNew"].Value);
                    param.InitialQtyPerNewStore = (SqlDecimal)(row.Cells["InitialQtyPerNewStore"].Value);
                    param.ProjectedSalesRateExisting = (SqlDecimal)(row.Cells["ProjectedSalesRateExisting"].Value);
                    param.ProjectedSalesRateNew = (SqlDecimal)(row.Cells["ProjectedSalesRateNew"].Value);
                    param.PipelineStart = row.Cells["PipelineStart"].Value.ToString();
                    param.PipelineEnd = row.Cells["PipelineEnd"].Value.ToString();
                    if (row.Cells["OneTimeItemFlag"].Value != null)
                        param.OneTimeItemFlag = (SqlBoolean)(row.Cells["OneTimeItemFlag"].Value);
                    if (row.Cells["PlPctPY01"].Value != null)
                        param.PlPctPY01 = (SqlDecimal)(row.Cells["PlPctPY01"].Value);
                    if (row.Cells["PlPctPY02"].Value != null)
                        param.PlPctPY02 = (SqlDecimal)(row.Cells["PlPctPY02"].Value);
                    if (row.Cells["PlPctPY03"].Value != null)
                        param.PlPctPY03 = (SqlDecimal)(row.Cells["PlPctPY03"].Value);
                    if (row.Cells["PlPctPY04"].Value != null)
                        param.PlPctPY04 = (SqlDecimal)(row.Cells["PlPctPY04"].Value);
                    if (row.Cells["PlPctPY05"].Value != null)
                        param.PlPctPY05 = (SqlDecimal)(row.Cells["PlPctPY05"].Value);
                    if (row.Cells["PlPctPY06"].Value != null)
                        param.PlPctPY06 = (SqlDecimal)(row.Cells["PlPctPY06"].Value);
                    if (row.Cells["PlPctPY07"].Value != null)
                        param.PlPctPY07 = (SqlDecimal)(row.Cells["PlPctPY07"].Value);
                    if (row.Cells["PlPctPY08"].Value != null)
                        param.PlPctPY08 = (SqlDecimal)(row.Cells["PlPctPY08"].Value);
                    if (row.Cells["PlPctPY09"].Value != null)
                        param.PlPctPY09 = (SqlDecimal)(row.Cells["PlPctPY09"].Value);
                    if (row.Cells["PlPctPY10"].Value != null)
                        param.PlPctPY10 = (SqlDecimal)(row.Cells["PlPctPY10"].Value);
                    if (row.Cells["PlPctPY11"].Value != null)
                        param.PlPctPY11 = (SqlDecimal)(row.Cells["PlPctPY11"].Value);
                    if (row.Cells["PlPctPY12"].Value != null)
                        param.PlPctPY12 = (SqlDecimal)(row.Cells["PlPctPY12"].Value);
                    if (row.Cells["PlPctCY01"].Value != null)
                        param.PlPctCY01 = (SqlDecimal)(row.Cells["PlPctCY01"].Value);
                    if (row.Cells["PlPctCY02"].Value != null)
                        param.PlPctCY02 = (SqlDecimal)(row.Cells["PlPctCY02"].Value);
                    if (row.Cells["PlPctCY03"].Value != null)
                        param.PlPctCY03 = (SqlDecimal)(row.Cells["PlPctCY03"].Value);
                    if (row.Cells["PlPctCY04"].Value != null)
                        param.PlPctCY04 = (SqlDecimal)(row.Cells["PlPctCY04"].Value);
                    if (row.Cells["PlPctCY05"].Value != null)
                        param.PlPctCY05 = (SqlDecimal)(row.Cells["PlPctCY05"].Value);
                    if (row.Cells["PlPctCY06"].Value != null)
                        param.PlPctCY06 = (SqlDecimal)(row.Cells["PlPctCY06"].Value);
                    if (row.Cells["PlPctCY07"].Value != null)
                        param.PlPctCY07 = (SqlDecimal)(row.Cells["PlPctCY07"].Value);
                    if (row.Cells["PlPctCY08"].Value != null)
                        param.PlPctCY08 = (SqlDecimal)(row.Cells["PlPctCY08"].Value);
                    if (row.Cells["PlPctCY09"].Value != null)
                        param.PlPctCY09 = (SqlDecimal)(row.Cells["PlPctCY09"].Value);
                    if (row.Cells["PlPctCY10"].Value != null)
                        param.PlPctCY10 = (SqlDecimal)(row.Cells["PlPctCY10"].Value);
                    if (row.Cells["PlPctCY11"].Value != null)
                        param.PlPctCY11 = (SqlDecimal)(row.Cells["PlPctCY11"].Value);
                    if (row.Cells["PlPctCY12"].Value != null)
                        param.PlPctCY12 = (SqlDecimal)(row.Cells["PlPctCY12"].Value);
                    if (row.Cells["PlPctNY01"].Value != null)
                        param.PlPctNY01 = (SqlDecimal)(row.Cells["PlPctNY01"].Value);
                    if (row.Cells["PlPctNY02"].Value != null)
                        param.PlPctNY02 = (SqlDecimal)(row.Cells["PlPctNY02"].Value);
                    if (row.Cells["PlPctNY03"].Value != null)
                        param.PlPctNY03 = (SqlDecimal)(row.Cells["PlPctNY03"].Value);
                    if (row.Cells["PlPctNY04"].Value != null)
                        param.PlPctNY04 = (SqlDecimal)(row.Cells["PlPctNY04"].Value);
                    if (row.Cells["PlPctNY05"].Value != null)
                        param.PlPctNY05 = (SqlDecimal)(row.Cells["PlPctNY05"].Value);
                    if (row.Cells["PlPctNY06"].Value != null)
                        param.PlPctNY06 = (SqlDecimal)(row.Cells["PlPctNY06"].Value);
                    if (row.Cells["PlPctNY07"].Value != null)
                        param.PlPctNY07 = (SqlDecimal)(row.Cells["PlPctNY07"].Value);
                    if (row.Cells["PlPctNY08"].Value != null)
                        param.PlPctNY08 = (SqlDecimal)(row.Cells["PlPctNY08"].Value);
                    if (row.Cells["PlPctNY09"].Value != null)
                        param.PlPctNY09 = (SqlDecimal)(row.Cells["PlPctNY09"].Value);
                    if (row.Cells["PlPctNY10"].Value != null)
                        param.PlPctNY10 = (SqlDecimal)(row.Cells["PlPctNY10"].Value);
                    if (row.Cells["PlPctNY11"].Value != null)
                        param.PlPctNY11 = (SqlDecimal)(row.Cells["PlPctNY11"].Value);
                    if (row.Cells["PlPctNY12"].Value != null)
                        param.PlPctNY12 = (SqlDecimal)(row.Cells["PlPctNY12"].Value);
                    customer.ForecastParameterCollection.Save(param);
                    // when the initial collection is empty
                    // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                    // 2. the data moves above need to check for null
                    if (bindingSourceForecastParameter.Count == 1)
                    {
                        bindingSourceForecastParameter.DataSource = null;
                        bindingSourceForecastParameter.DataSource = customer.ForecastParameterCollection;
                    }
                    else
                        bindingSourceForecastParameter.List[bindingSourceForecastParameter.Count - 1] = param;
                }
                // existing record
                else
                {
                    //param = customer.ForecastParameterCollection[parameterKey];
                    //param.Save();
                    param = (ForecastParameter)dgvParameter.CurrentRow.DataBoundItem;
                    customer.ForecastParameterCollection.Save(param);
                    customer.ForecastParameterCollection[parameterKey] = param;
                }
                _dgvParameterRowDirty = false;
                // invalidate dependent trend, sales rate business objects
                _company.ForecastTrendByItemCollection = null;
                customer.ForecastSalesRateCollection = null;
                //row.ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvParameter_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var itemNumber = e.Row.Cells["ItemNumberParameter"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm Forecast Parameter deletion for Item: {0}.", itemNumber), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.ForecastParameterCollection.Delete(new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber));
                    // invalidate dependent trend, sales rate business objects
                    _company.ForecastTrendByItemCollection = null;
                    customer.ForecastSalesRateCollection = null;
                    if (customer.ForecastAction == ForecastAction.Generate)
                        customer.ForecastCollection = null;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region dgvBonusAndDiscontinued Event Handlers
        private void CopyClipboardToNewRow(DataGridView dgv, string itemNumberColumnName, int newRowIndex, bool hasPYColumns)
        {
            string[] values = Clipboard.GetText().Split('\t');
            var newRow = dgv.Rows[newRowIndex];

            bool dataMatched;
            if (hasPYColumns)
                dataMatched = values.Length == (chkShowPriorYear.Checked ? newRow.Cells.Count : newRow.Cells.Count - 12);
            else
                dataMatched = values.Length == newRow.Cells.Count - ("ItemNumberTrend|ProductGroup".IndexOf(itemNumberColumnName) > -1 ? 1 : 0);

            if (dataMatched)
                for (var sourceRowIndex = 0; sourceRowIndex < dgv.Rows.Count; sourceRowIndex++)
                    if (dgv.Rows[sourceRowIndex].Cells[itemNumberColumnName].Value != null &&
                        values[1].IndexOf(dgv.Rows[sourceRowIndex].Cells[itemNumberColumnName].Value.ToString()) > -1)
                    {
                        var sourceRow = dgv.Rows[sourceRowIndex];
                        for (var cellIndex = 0; cellIndex < newRow.Cells.Count; cellIndex++)
                            newRow.Cells[cellIndex].Value = sourceRow.Cells[cellIndex].Value;
                        break;
                    }
        }

        private void CopyClipboardToNewRow(DataGridView dgv, string itemNumberColumnName, string forecastMethodColumnName, int newRowIndex, bool hasPYColumns)
        {
            var values = Clipboard.GetText().Split('\t');
            var newRow = dgv.Rows[newRowIndex];

            bool dataMatched;
            if (hasPYColumns)
                dataMatched = values.Length == (chkShowPriorYear.Checked ? newRow.Cells.Count : newRow.Cells.Count - 12);
            else
                dataMatched = values.Length == newRow.Cells.Count - ("ItemNumberTrend|ProductGroup".IndexOf(itemNumberColumnName) > -1 ? 1 : 0);

            if (dataMatched)
                for (var sourceRowIndex = 0; sourceRowIndex < dgv.Rows.Count; sourceRowIndex++)
                    if (dgv.Rows[sourceRowIndex].Cells[itemNumberColumnName].Value != null &&
                        values[1].IndexOf(dgv.Rows[sourceRowIndex].Cells[itemNumberColumnName].Value.ToString(), StringComparison.Ordinal) > -1 &&
                        values[2].IndexOf(dgv.Rows[sourceRowIndex].Cells[forecastMethodColumnName].Value.ToString(), StringComparison.Ordinal) > -1)
                    {
                        var sourceRow = dgv.Rows[sourceRowIndex];
                        for (var cellIndex = 0; cellIndex < newRow.Cells.Count; cellIndex++)
                            newRow.Cells[cellIndex].Value = sourceRow.Cells[cellIndex].Value;
                        break;
                    }
        }

        private void dgvBonusAndDiscontinued_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvBonusAndDiscontinued.Columns[e.ColumnIndex].Name != "ItemNumberBonus")
                    return;
                
                if (rbtnBonusAndDiscontinuedByCompany.Checked)
                {
                    if (_company == null)
                        return;
                    if (e.RowIndex < _company.BonusAndDiscontinuedCollection.Count)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    if (_company == null || _customerKey == null)
                        return;
                    if (e.RowIndex < _company.CustomerCollection[_customerKey].BonusAndDiscontinuedCollection.Count)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (chkUseClipboardDataOnNewRow.Checked)
                    CopyClipboardToNewRow(dgvBonusAndDiscontinued, "ItemNumberBonus", e.RowIndex, true);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvBonusAndDiscontinued.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0)
                    return;
                if (dgvBonusAndDiscontinued.Columns[e.ColumnIndex].Name != "DiscontinuedEffectiveDate")
                    return;
                if (e.Value == null)
                    return;
                var dateValue = (SqlDateTime) e.Value;
                e.Value = dateValue.IsNull ? "Null" : dateValue.Value.ToString("MM/dd/yyyy");
                e.FormattingApplied = true;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null || e.Value == null)
                return;
            try
            {
                // default parsing fails to convert string to sqlstring
                // assist it here.
                var column = dgvBonusAndDiscontinued.Columns[e.ColumnIndex];
                switch (column.Name)
                {
                    case "ItemNumberBonus":
                        e.Value = new SqlString(e.Value.ToString());
                        e.ParsingApplied = true;
                        break;
                    case "DiscontinuedEffectiveDate":
                        if (e.Value.ToString() == "Null")
                        {
                            e.Value = SqlDateTime.Null;
                            e.ParsingApplied = true;
                        }
                        break;
                    default:
                        if (Regex.IsMatch(column.Name, @"^[PCN]Y[01]\d")) // PY##, CY##, NY## columns
                        {
                            if (e.Value.ToString() == "Null")
                            {
                                e.Value = SqlInt32.Null;
                                e.ParsingApplied = true;
                            }
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
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvBonusAndDiscontinued.IsCurrentCellDirty)
                    return;
                _dgvBonusAndDiscontinuedRowDirty = true;
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    dgvBonusAndDiscontinued.CancelEdit();
                    txtCompanyCode.Focus();
                    return;
                }
                if (rbtnBonusAndDiscontinuedByCustomer.Checked && _customerKey == null)
                {
                    MessageBox.Show("Please select a Customer Number.", "PWC Forecast");
                    dgvBonusAndDiscontinued.CancelEdit();
                    cboCustomer.Focus();
                    return;
                }
                var row = dgvBonusAndDiscontinued.Rows[e.RowIndex];
                if (e.FormattedValue == null)
                {
                    row.ErrorText = "Entry is required";
                    e.Cancel = true;
                }
                else
                {
                    var formattedValue = e.FormattedValue.ToString();
                    var rx = new Regex(@"^[PCN]Y[01]\d");
                    var column = dgvBonusAndDiscontinued.Columns[e.ColumnIndex];
                    if (column.Name == "ItemNumberBonus")
                    {
                        if (!Regex.IsMatch(formattedValue, @"^\d{2}-\d{5}-[A-Z0-9]{2}$"))
                        {
                            row.ErrorText = "Please enter Item Number in ##-#####-AA";
                            e.Cancel = true;
                        }
                        else
                        {
                            var itemCollection = new Item.ParameteredCollection(formattedValue, SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
                            itemCollection.Load();
                            if (itemCollection.Count == 0)
                            {
                                row.ErrorText = "Item does not exist in Item Master";
                                e.Cancel = true;
                            }
                            else
                            {
                                if (rbtnBonusAndDiscontinuedByCompany.Checked)
                                {
                                    if (_company.BonusAndDiscontinuedCollection.ContainsKey(new BonusAndDiscontinuedByCompanyKey(_company.CompanyCode, formattedValue)))
                                    {
                                        row.ErrorText = "Item already exists in Bonus and Discontinued";
                                        e.Cancel = true;
                                    }
                                }
                                else if (_company.CustomerCollection[_customerKey].BonusAndDiscontinuedCollection.ContainsKey(new BonusAndDiscontinuedByCustomerKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, formattedValue)))
                                {
                                    row.ErrorText = "Item already exists in Bonus and Discontinued";
                                    e.Cancel = true;
                                }
                            }
                        }
                    }
                    else if (column.Name == "DiscontinuedEffectiveDate" &&
                        formattedValue != "Null")
                    {
                        if (formattedValue == string.Empty || !Regex.IsMatch(formattedValue, @"^\d{1,2}/\d{1,2}/\d{2,4}$"))
                        {
                            row.ErrorText = "Please enter Discontinued Effective Date in ##/##/####";
                            e.Cancel = true;
                        }
                        DateTime discontinuedEffectiveDate;
                        if (!DateTime.TryParse(formattedValue, out discontinuedEffectiveDate))
                        {
                            row.ErrorText = "Invalid Discontinued Effective Date";
                            e.Cancel = true;
                        }
                    }
                    else if (rx.IsMatch(column.Name) &&
                        formattedValue != "Null") // PL##, CY##, NY##
                    {
                        var daysOfMonth = int.Parse(rx.Replace(column.HeaderText, string.Empty).Replace("(", string.Empty).Replace(")", string.Empty));
                        if (formattedValue == string.Empty || !Regex.IsMatch(formattedValue, @"^\d{0,2}$"))
                        {
                            row.ErrorText = "Please enter Number of Days in ##";
                            e.Cancel = true;
                        }
                        else if (int.Parse(formattedValue) > daysOfMonth)
                        {
                            row.ErrorText = string.Format("Number of Days cannot be greater {0}", daysOfMonth);
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;

                var newColumn = dgvBonusAndDiscontinued.Columns[e.ColumnIndex];
                if (newColumn == null || newColumn.SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;

                var oldColumn = _dgvBonusAndDiscontinuedSortedColumn;

                // If oldColumn is null, then the DataGridView is not currently sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && _dgvBonusAndDiscontinuedSortOrder == System.Windows.Forms.SortOrder.Ascending)
                        _dgvBonusAndDiscontinuedSortOrder = System.Windows.Forms.SortOrder.Descending;
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        _dgvBonusAndDiscontinuedSortOrder = System.Windows.Forms.SortOrder.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                    _dgvBonusAndDiscontinuedSortOrder = System.Windows.Forms.SortOrder.Ascending;

                if (rbtnBonusAndDiscontinuedByCustomer.Checked && _company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.BonusAndDiscontinuedCollection.Sort(dgvBonusAndDiscontinued.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvBonusAndDiscontinuedSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceBonusAndDiscontinued.DataSource = null;
                    bindingSourceBonusAndDiscontinued.DataSource = customer.BonusAndDiscontinuedCollection;
                    _dgvBonusAndDiscontinuedSortedColumn = newColumn;
                    newColumn.HeaderCell.SortGlyphDirection = _dgvBonusAndDiscontinuedSortOrder;
                }
                else if (rbtnBonusAndDiscontinuedByCompany.Checked && _company != null)
                {
                    _company.BonusAndDiscontinuedCollection.Sort(dgvBonusAndDiscontinued.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvBonusAndDiscontinuedSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceBonusAndDiscontinued.DataSource = null;
                    bindingSourceBonusAndDiscontinued.DataSource = _company.BonusAndDiscontinuedCollection;
                    _dgvBonusAndDiscontinuedSortedColumn = newColumn;
                    newColumn.HeaderCell.SortGlyphDirection = _dgvBonusAndDiscontinuedSortOrder;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                var additionalData = new StringBuilder("Context: ");
                additionalData.Append(e.Context.ToString()).Append("\n");
                additionalData.Append("RowIndex: ").Append(e.RowIndex.ToString()).Append("\n");
                additionalData.Append("ColumnIndex: ").Append(e.ColumnIndex.ToString());
                PersistenceFacade.GetInstance().LogException(e.Exception, Environment.MachineName, additionalData.ToString());
                e.ThrowException = true;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                var tb = e.Control as TextBox;
                if (tb == null)
                    return;
                if (dgvBonusAndDiscontinued.Columns[dgvBonusAndDiscontinued.CurrentCell.ColumnIndex].Name == "ItemNumberBonus")
                {
                    var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                    tb.KeyPress -= keyPressEventHandler;
                    tb.KeyPress += keyPressEventHandler;
                }
                var keyEventHandler = new KeyEventHandler(dgvBonusAndDiscontinued_tb_KeyUp);
                tb.KeyUp -= keyEventHandler;
                tb.KeyUp += keyEventHandler;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_tb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (_dgvBonusAndDiscontinuedRowDirty && e.KeyCode == Keys.Escape)
                {
                    ABonusAndDiscontinued bAndD = null;
                    var itemNumber = (SqlString)dgvBonusAndDiscontinued.CurrentRow.Cells["ItemNumberBonus"].Value;
                    if (rbtnBonusAndDiscontinuedByCompany.Checked && _company != null)
                    {
                        bAndD = new BonusAndDiscontinuedByCompany(_company.CompanyCode, itemNumber);
                        bAndD.Load();
                        _company.BonusAndDiscontinuedCollection[new BonusAndDiscontinuedByCompanyKey(_company.CompanyCode, itemNumber)] = (BonusAndDiscontinuedByCompany)bAndD;
                        dgvBonusAndDiscontinued.CurrentRow.Cells["DiscontinuedEffectiveDate"].Value = ((BonusAndDiscontinuedByCompany)bAndD).DiscontinuedEffectiveDate;
                    }
                    else if (rbtnBonusAndDiscontinuedByCustomer.Checked && _company != null && _customerKey != null)
                    {
                        bAndD = new BonusAndDiscontinuedByCustomer(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber);
                        bAndD.Load();
                        _company.CustomerCollection[_customerKey].BonusAndDiscontinuedCollection[new BonusAndDiscontinuedByCustomerKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber)] = (BonusAndDiscontinuedByCustomer)bAndD;
                        dgvBonusAndDiscontinued.CurrentRow.Cells["DiscontinuedEffectiveDate"].Value = ((BonusAndDiscontinuedByCustomer)bAndD).DiscontinuedEffectiveDate;
                    }
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY01Bonus"].Value = bAndD.PY01;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY02Bonus"].Value = bAndD.PY02;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY03Bonus"].Value = bAndD.PY03;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY04Bonus"].Value = bAndD.PY04;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY05Bonus"].Value = bAndD.PY05;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY06Bonus"].Value = bAndD.PY06;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY07Bonus"].Value = bAndD.PY07;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY08Bonus"].Value = bAndD.PY08;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY09Bonus"].Value = bAndD.PY09;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY10Bonus"].Value = bAndD.PY10;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY11Bonus"].Value = bAndD.PY11;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["PY12Bonus"].Value = bAndD.PY12;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY01Bonus"].Value = bAndD.CY01;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY02Bonus"].Value = bAndD.CY02;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY03Bonus"].Value = bAndD.CY03;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY04Bonus"].Value = bAndD.CY04;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY05Bonus"].Value = bAndD.CY05;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY06Bonus"].Value = bAndD.CY06;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY07Bonus"].Value = bAndD.CY07;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY08Bonus"].Value = bAndD.CY08;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY09Bonus"].Value = bAndD.CY09;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY10Bonus"].Value = bAndD.CY10;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY11Bonus"].Value = bAndD.CY11;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["CY12Bonus"].Value = bAndD.CY12;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY01Bonus"].Value = bAndD.NY01;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY02Bonus"].Value = bAndD.NY02;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY03Bonus"].Value = bAndD.NY03;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY04Bonus"].Value = bAndD.NY04;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY05Bonus"].Value = bAndD.NY05;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY06Bonus"].Value = bAndD.NY06;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY07Bonus"].Value = bAndD.NY07;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY08Bonus"].Value = bAndD.NY08;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY09Bonus"].Value = bAndD.NY09;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY10Bonus"].Value = bAndD.NY10;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY11Bonus"].Value = bAndD.NY11;
                    dgvBonusAndDiscontinued.CurrentRow.Cells["NY12Bonus"].Value = bAndD.NY12;
                    _dgvBonusAndDiscontinuedRowDirty = false;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvBonusAndDiscontinued_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvBonusAndDiscontinued.IsCurrentRowDirty)
                    return;

                var row = dgvBonusAndDiscontinued.Rows[e.RowIndex];
                if (row.Cells["ItemNumberBonus"].Value != null)
                {
                    SqlString itemNumber = row.Cells["ItemNumberBonus"].Value.ToString();
                    if (itemNumber.IsNull)
                    {
                        row.ErrorText = "Item# is required";
                        e.Cancel = true;
                        return;
                    }
                    var hasEntry = false;
                    for (var columnIndex = row.Cells["DiscontinuedEffectiveDate"].ColumnIndex; columnIndex <= row.Cells["NY12Bonus"].ColumnIndex; columnIndex++)
                    {
                        if (row.Cells[columnIndex].Value != null && row.Cells[columnIndex].Value.ToString() != "Null")
                        {
                            hasEntry = true;
                            break;
                        }
                    }
                    if (!hasEntry)
                    {
                        row.ErrorText = "Please enter Discontinued Effective Date or Bonus value(s)";
                        e.Cancel = true;
                        return;
                    }
                    if (rbtnBonusAndDiscontinuedByCustomer.Checked && _customerKey != null)
                    {
                        var customer = _company.CustomerCollection[_customerKey];
                        var bonusAndDiscontinuedByCustomerKey = new BonusAndDiscontinuedByCustomerKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber);
                        BonusAndDiscontinuedByCustomer bonusAndDiscontinuedByCustomer;
                        // new record
                        if (e.RowIndex >= customer.BonusAndDiscontinuedCollection.Count)
                        {
                            if (customer.BonusAndDiscontinuedCollection.ContainsKey(bonusAndDiscontinuedByCustomerKey))
                            {
                                row.ErrorText = "Item already exists for the Customer";
                                e.Cancel = true;
                                return;
                            }
                            if (customer.ForecastParameterCollection.ContainsKey(new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber)))
                            {
                                for (var columnIndex = row.Cells["PY01Bonus"].ColumnIndex; columnIndex <= row.Cells["NY12Bonus"].ColumnIndex; columnIndex++)
                                {
                                    if (row.Cells[columnIndex].Value != null && row.Cells[columnIndex].Value.ToString() != "Null")
                                    {
                                        row.ErrorText = "Bonus Item cannot be one of the Forecast Parameter Items";
                                        e.Cancel = true;
                                        return;
                                    }
                                }
                            }
                            bonusAndDiscontinuedByCustomer = customer.BonusAndDiscontinuedCollection.Create(bonusAndDiscontinuedByCustomerKey);
                            if (row.Cells["DiscontinuedEffectiveDate"].Value != null)
                                bonusAndDiscontinuedByCustomer.DiscontinuedEffectiveDate = (SqlDateTime)(row.Cells["DiscontinuedEffectiveDate"].Value);
                            AssignBonusValues(row, bonusAndDiscontinuedByCustomer);
                            customer.BonusAndDiscontinuedCollection.Save(bonusAndDiscontinuedByCustomer);
                            // when the initial collection is empty
                            // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                            // 2. the data moves above need to check for null
                            if (bindingSourceBonusAndDiscontinued.Count == 1)
                            {
                                bindingSourceBonusAndDiscontinued.DataSource = null;
                                bindingSourceBonusAndDiscontinued.DataSource = customer.BonusAndDiscontinuedCollection;
                            }
                            else
                                bindingSourceBonusAndDiscontinued.List[bindingSourceBonusAndDiscontinued.Count - 1] = bonusAndDiscontinuedByCustomer;
                        }
                        // existing record
                        else
                        {
                            //bonusAndDiscontinuedByCustomer = customer.BonusAndDiscontinuedCollection[bonusAndDiscontinuedByCustomerKey];
                            //bonusAndDiscontinuedByCustomer.Save();
                            bonusAndDiscontinuedByCustomer = (BonusAndDiscontinuedByCustomer)dgvBonusAndDiscontinued.CurrentRow.DataBoundItem;
                            customer.BonusAndDiscontinuedCollection.Save(bonusAndDiscontinuedByCustomer);
                            customer.BonusAndDiscontinuedCollection[bonusAndDiscontinuedByCustomerKey] = bonusAndDiscontinuedByCustomer;
                        }
                        _dgvBonusAndDiscontinuedRowDirty = false;
                        // invalidate dependent forecast business objects
                        if (customer.ForecastAction == ForecastAction.Generate)
                            customer.ForecastCollection = null;
                    }
                    else
                    {
                        var bonusAndDiscontinuedByCompanyKey = new BonusAndDiscontinuedByCompanyKey(txtCompanyCode.Text, itemNumber);
                        BonusAndDiscontinuedByCompany bonusAndDiscontinuedByCompany;
                        // new record
                        if (e.RowIndex >= _company.BonusAndDiscontinuedCollection.Count)
                        {
                            if (_company.BonusAndDiscontinuedCollection.ContainsKey(bonusAndDiscontinuedByCompanyKey))
                            {
                                row.ErrorText = "Item already exists for the Company";
                                e.Cancel = true;
                                return;
                            }
                            bonusAndDiscontinuedByCompany = _company.BonusAndDiscontinuedCollection.Create(bonusAndDiscontinuedByCompanyKey);
                            if (row.Cells["DiscontinuedEffectiveDate"].Value != null)
                                bonusAndDiscontinuedByCompany.DiscontinuedEffectiveDate = (SqlDateTime)(row.Cells["DiscontinuedEffectiveDate"].Value);
                            AssignBonusValues(row, bonusAndDiscontinuedByCompany);
                            _company.BonusAndDiscontinuedCollection.Save(bonusAndDiscontinuedByCompany);
                            // when the initial collection is empty
                            // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                            // 2. the data moves above need to check for null
                            if (bindingSourceBonusAndDiscontinued.Count == 1)
                            {
                                bindingSourceBonusAndDiscontinued.DataSource = null;
                                bindingSourceBonusAndDiscontinued.DataSource = _company.BonusAndDiscontinuedCollection;
                            }
                            else
                                bindingSourceBonusAndDiscontinued.List[bindingSourceBonusAndDiscontinued.Count - 1] = bonusAndDiscontinuedByCompany;
                        }
                        // existing record
                        else
                        {
                            //bonusAndDiscontinuedByCompany = _company.BonusAndDiscontinuedCollection[bonusAndDiscontinuedByCompanyKey];
                            //bonusAndDiscontinuedByCompany.Save();
                            bonusAndDiscontinuedByCompany = (BonusAndDiscontinuedByCompany)dgvBonusAndDiscontinued.CurrentRow.DataBoundItem;
                            _company.BonusAndDiscontinuedCollection.Save(bonusAndDiscontinuedByCompany);
                            _company.BonusAndDiscontinuedCollection[bonusAndDiscontinuedByCompanyKey] = bonusAndDiscontinuedByCompany;
                        }
                        // invalidate dependent forecast business objects
                        if (_customerKey != null)
                        {
                            var customer = _company.CustomerCollection[_customerKey];
                            if (customer.ForecastAction == ForecastAction.Generate)
                                customer.ForecastCollection = null;
                        }
                    }
                    row.ErrorText = String.Empty;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private static void AssignBonusValues(DataGridViewRow row, IThreeYearMonthlyIntegerValue iTYMIV)
        {
            if (row.Cells["PY01Bonus"].Value != null)
                iTYMIV.PY01 = (SqlInt32)row.Cells["PY01Bonus"].Value;
            if (row.Cells["PY02Bonus"].Value != null)
                iTYMIV.PY02 = (SqlInt32)row.Cells["PY02Bonus"].Value;
            if (row.Cells["PY03Bonus"].Value != null)
                iTYMIV.PY03 = (SqlInt32)row.Cells["PY03Bonus"].Value;
            if (row.Cells["PY04Bonus"].Value != null)
                iTYMIV.PY04 = (SqlInt32)row.Cells["PY04Bonus"].Value;
            if (row.Cells["PY05Bonus"].Value != null)
                iTYMIV.PY05 = (SqlInt32)row.Cells["PY05Bonus"].Value;
            if (row.Cells["PY06Bonus"].Value != null)
                iTYMIV.PY06 = (SqlInt32)row.Cells["PY06Bonus"].Value;
            if (row.Cells["PY07Bonus"].Value != null)
                iTYMIV.PY07 = (SqlInt32)row.Cells["PY07Bonus"].Value;
            if (row.Cells["PY08Bonus"].Value != null)
                iTYMIV.PY08 = (SqlInt32)row.Cells["PY08Bonus"].Value;
            if (row.Cells["PY09Bonus"].Value != null)
                iTYMIV.PY09 = (SqlInt32)row.Cells["PY09Bonus"].Value;
            if (row.Cells["PY10Bonus"].Value != null)
                iTYMIV.PY10 = (SqlInt32)row.Cells["PY10Bonus"].Value;
            if (row.Cells["PY11Bonus"].Value != null)
                iTYMIV.PY11 = (SqlInt32)row.Cells["PY11Bonus"].Value;
            if (row.Cells["PY12Bonus"].Value != null)
                iTYMIV.PY12 = (SqlInt32)row.Cells["PY12Bonus"].Value;
            if (row.Cells["CY01Bonus"].Value != null)
                iTYMIV.CY01 = (SqlInt32)row.Cells["CY01Bonus"].Value;
            if (row.Cells["CY02Bonus"].Value != null)
                iTYMIV.CY02 = (SqlInt32)row.Cells["CY02Bonus"].Value;
            if (row.Cells["CY03Bonus"].Value != null)
                iTYMIV.CY03 = (SqlInt32)row.Cells["CY03Bonus"].Value;
            if (row.Cells["CY04Bonus"].Value != null)
                iTYMIV.CY04 = (SqlInt32)row.Cells["CY04Bonus"].Value;
            if (row.Cells["CY05Bonus"].Value != null)
                iTYMIV.CY05 = (SqlInt32)row.Cells["CY05Bonus"].Value;
            if (row.Cells["CY06Bonus"].Value != null)
                iTYMIV.CY06 = (SqlInt32)row.Cells["CY06Bonus"].Value;
            if (row.Cells["CY07Bonus"].Value != null)
                iTYMIV.CY07 = (SqlInt32)row.Cells["CY07Bonus"].Value;
            if (row.Cells["CY08Bonus"].Value != null)
                iTYMIV.CY08 = (SqlInt32)row.Cells["CY08Bonus"].Value;
            if (row.Cells["CY09Bonus"].Value != null)
                iTYMIV.CY09 = (SqlInt32)row.Cells["CY09Bonus"].Value;
            if (row.Cells["CY10Bonus"].Value != null)
                iTYMIV.CY10 = (SqlInt32)row.Cells["CY10Bonus"].Value;
            if (row.Cells["CY11Bonus"].Value != null)
                iTYMIV.CY11 = (SqlInt32)row.Cells["CY11Bonus"].Value;
            if (row.Cells["CY12Bonus"].Value != null)
                iTYMIV.CY12 = (SqlInt32)row.Cells["CY12Bonus"].Value;
            if (row.Cells["NY01Bonus"].Value != null)
                iTYMIV.NY01 = (SqlInt32)row.Cells["NY01Bonus"].Value;
            if (row.Cells["NY02Bonus"].Value != null)
                iTYMIV.NY02 = (SqlInt32)row.Cells["NY02Bonus"].Value;
            if (row.Cells["NY03Bonus"].Value != null)
                iTYMIV.NY03 = (SqlInt32)row.Cells["NY03Bonus"].Value;
            if (row.Cells["NY04Bonus"].Value != null)
                iTYMIV.NY04 = (SqlInt32)row.Cells["NY04Bonus"].Value;
            if (row.Cells["NY05Bonus"].Value != null)
                iTYMIV.NY05 = (SqlInt32)row.Cells["NY05Bonus"].Value;
            if (row.Cells["NY06Bonus"].Value != null)
                iTYMIV.NY06 = (SqlInt32)row.Cells["NY06Bonus"].Value;
            if (row.Cells["NY07Bonus"].Value != null)
                iTYMIV.NY07 = (SqlInt32)row.Cells["NY07Bonus"].Value;
            if (row.Cells["NY08Bonus"].Value != null)
                iTYMIV.NY08 = (SqlInt32)row.Cells["NY08Bonus"].Value;
            if (row.Cells["NY09Bonus"].Value != null)
                iTYMIV.NY09 = (SqlInt32)row.Cells["NY09Bonus"].Value;
            if (row.Cells["NY10Bonus"].Value != null)
                iTYMIV.NY10 = (SqlInt32)row.Cells["NY10Bonus"].Value;
            if (row.Cells["NY11Bonus"].Value != null)
                iTYMIV.NY11 = (SqlInt32)row.Cells["NY11Bonus"].Value;
            if (row.Cells["NY12Bonus"].Value != null)
                iTYMIV.NY12 = (SqlInt32)row.Cells["NY12Bonus"].Value;
        }

        private void dgvBonusAndDiscontinued_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var itemNumber = e.Row.Cells["ItemNumberBonus"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm Bonus & Discontinued deletion for Item: {0}.", itemNumber), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                {
                    if (rbtnBonusAndDiscontinuedByCustomer.Checked)
                    {
                        var customer = _company.CustomerCollection[_customerKey];
                        customer.BonusAndDiscontinuedCollection.Delete(new BonusAndDiscontinuedByCustomerKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber));
                        // invalidate dependent forecast business objects
                        if (customer.ForecastAction == ForecastAction.Generate)
                            customer.ForecastCollection = null;
                    }
                    else
                    {
                        _company.BonusAndDiscontinuedCollection.Delete(new BonusAndDiscontinuedByCompanyKey(txtCompanyCode.Text, itemNumber));
                        // invalidate dependent forecast business objects
                        if (_customerKey != null)
                        {
                            var customer = _company.CustomerCollection[_customerKey];
                            if (customer.ForecastAction == ForecastAction.Generate)
                                customer.ForecastCollection = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region dgvSalesRate Event Handlers
        private void dgvSalesRate_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (_company == null || _customerKey == null)
                    return;
                if (dgvSalesRate.Columns[e.ColumnIndex].Name != "ItemNumberSalesRate")
                    return;
                if (e.RowIndex < _company.CustomerCollection[_customerKey].ForecastSalesRateCollection.Count)
                    e.Cancel = true;
                else if (chkUseClipboardDataOnNewRow.Checked)
                    CopyClipboardToNewRow(dgvSalesRate, "ItemNumberSalesRate", e.RowIndex, false);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvSalesRate.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _mouseLocation = e;
        }

        private static Color GetSalesRateCellBackColor(ForecastSalesRate salesRate)
        {
            var color = SystemColors.Window;
            if (!salesRate.HasComment && !salesRate.HasOverride)
                return color;

            var commentAndOverrides = salesRate.ForecastSalesRateCommentAndOverrideCollection
                .OrderByDescending(commentAndOverride => commentAndOverride.CommentOverrideDateTime);
            var manualOverride = commentAndOverrides.FirstOrDefault(commentAndOverride => commentAndOverride.Comment.IsNull);
            var isOverride = (bool)(manualOverride != null && manualOverride.IsOverride);
            var hasComment = commentAndOverrides.Any(commentAndOverride => !commentAndOverride.Comment.IsNull);
            if (isOverride && hasComment)
                color = Color.Orange;
            else if (isOverride)
                color = Color.Tomato;
            else if (hasComment)
                color = Color.Yellow;
            return color;
        }
        
        private void dgvSalesRate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || _customerKey == null)
                    return;

                var salesRateCollection = _company.CustomerCollection[_customerKey].ForecastSalesRateCollection;
                if (e.RowIndex >= salesRateCollection.Count)
                    return;

                var columnName = dgvSalesRate.Columns[e.ColumnIndex].Name;
                switch (columnName)
                {
                    case "SalesRateDifference":
                    case "SalesRate":
                        if (e.Value != null)
                        {
                            var decValue = (SqlDecimal)e.Value;
                            e.Value = decValue.IsNull ? "Null" : decValue.Value.ToString("0.00");
                            e.FormattingApplied = true;
                        }

                        if (columnName == "SalesRateDifference")
                            return;

                        e.CellStyle.BackColor = GetSalesRateCellBackColor(salesRateCollection[e.RowIndex]);

                        break;
                    case "SalesRateDifferencePercent":
                        if (e.Value != null)
                        {
                            var decValue = (SqlDecimal)e.Value;
                            if (((SqlInt32)dgvSalesRate.Rows[e.RowIndex].Cells["POSTotal"].Value > 0 &&
                                 (SqlInt32)dgvSalesRate.Rows[e.RowIndex].Cells["StoreCountTotal"].Value == 0) ||
                                (decValue < -50 || decValue > 50))
                                e.CellStyle.BackColor = Color.Red;
                            else if (salesRateCollection[e.RowIndex].HasOverride)
                                e.CellStyle.BackColor = Color.Yellow;

                            e.Value = decValue.IsNull ? "Null" : decValue.Value.ToString("0.00");
                            e.FormattingApplied = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (e != null && e.Value != null)
                {
                    try
                    {
                        // default parsing fails to convert string to sqlstring
                        // assist it here.
                        switch (dgvSalesRate.Columns[e.ColumnIndex].Name)
                        {
                            case "ItemNumberSalesRate":
                                e.Value = new SqlString(e.Value.ToString());
                                e.ParsingApplied = true;
                                break;
                            case "SalesRate":
                                if (e.Value.ToString() == "Null")
                                {
                                    e.Value = SqlDecimal.Null;
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

        private void dgvSalesRate_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvSalesRate.IsCurrentCellDirty)
                    return;
                _dgvSalesRateRowDirty = true;
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    dgvSalesRate.CancelEdit();
                    txtCompanyCode.Focus();
                    return;
                }
                if (_customerKey == null)
                {
                    MessageBox.Show("Please enter Customer Number.", "PWC Forecast");
                    dgvSalesRate.CancelEdit();
                    cboCustomer.Focus();
                    return;
                }
                var row = dgvSalesRate.Rows[e.RowIndex];
                var column = dgvSalesRate.Columns[e.ColumnIndex];
                if (e.FormattedValue == null)
                {
                    row.ErrorText = "Entry is required";
                    e.Cancel = true;
                    return;
                }
                var formattedValue = e.FormattedValue.ToString();
                if (column.Name == "ItemNumberSalesRate")
                {
                    if (!Regex.IsMatch(formattedValue, @"^\d{2}-\d{5}-[A-F0-9]{2}$"))
                    {
                        row.ErrorText = "Please enter Item Number in ##-#####-AA";
                        e.Cancel = true;
                        return;
                    }
                    var customer = _company.CustomerCollection[_customerKey];
                    var paramKey = new ForecastParameterKey(_company.CompanyCode, _customerKey.CustomerNumber, formattedValue);
                    var param = customer.ForecastParameterCollection[paramKey];
                    if (param == null)
                    {
                        row.ErrorText = "Item does not exist in Forecast Parameter";
                        e.Cancel = true;
                        return;
                    }
                    var salesRateKey = new ForecastSalesRateKey(_company.CompanyCode, customer.CustomerNumber, customer.POSSalesEndDate, formattedValue);
                    if (customer.ForecastSalesRateCollection.ContainsKey(salesRateKey))
                    {
                        row.ErrorText = "Item already exists in Forecast Sales Rate";
                        e.Cancel = true;
                        return;
                    }
                    Cursor = Cursors.WaitCursor;

                    // the object may not exists for new record
                    // only update the screen
                    row.Cells["ItemNumberSalesRate"].Value = param.ItemNumber;

                    // get trend factor
                    var trend = _company.ForecastTrendByItemCollection[new ForecastTrendByCompanyItemKey(_company.CompanyCode, formattedValue, "SR")];
                    if (trend != null)
                    {
                        switch (customer.POSSalesEndDate.Value.Month)
                        {
                            case 1: row.Cells["TrendFactor"].Value = trend.FactorMonth01; break;
                            case 2: row.Cells["TrendFactor"].Value = trend.FactorMonth02; break;
                            case 3: row.Cells["TrendFactor"].Value = trend.FactorMonth03; break;
                            case 4: row.Cells["TrendFactor"].Value = trend.FactorMonth04; break;
                            case 5: row.Cells["TrendFactor"].Value = trend.FactorMonth05; break;
                            case 6: row.Cells["TrendFactor"].Value = trend.FactorMonth06; break;
                            case 7: row.Cells["TrendFactor"].Value = trend.FactorMonth07; break;
                            case 8: row.Cells["TrendFactor"].Value = trend.FactorMonth08; break;
                            case 9: row.Cells["TrendFactor"].Value = trend.FactorMonth09; break;
                            case 10: row.Cells["TrendFactor"].Value = trend.FactorMonth10; break;
                            case 11: row.Cells["TrendFactor"].Value = trend.FactorMonth11; break;
                            case 12: row.Cells["TrendFactor"].Value = trend.FactorMonth12; break;
                        }
                    }

                    // get pos quantity
                    POS.ParameteredCollection posCollection;
                    if (customer.POSNumberOfWeeks >= 1)
                    {
                        posCollection = new POS.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, param.ItemNumber, customer.POSSalesEndDate);
                        posCollection.Load();
                        if (posCollection.Count > 0)
                            row.Cells["POSWeek4Quantity"].Value = posCollection[0].Quantity;
                    }
                    if (customer.POSNumberOfWeeks >= 2)
                    {
                        posCollection = new POS.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, param.ItemNumber, customer.POSSalesEndDate.Value.AddDays(-7));
                        posCollection.Load();
                        if (posCollection.Count > 0)
                            row.Cells["POSWeek3Quantity"].Value = posCollection[0].Quantity;
                    }
                    if (customer.POSNumberOfWeeks >= 3)
                    {
                        posCollection = new POS.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, param.ItemNumber, customer.POSSalesEndDate.Value.AddDays(-14));
                        posCollection.Load();
                        if (posCollection.Count > 0)
                            row.Cells["POSWeek2Quantity"].Value = posCollection[0].Quantity;
                    }
                    if (customer.POSNumberOfWeeks == 4)
                    {
                        posCollection = new POS.ParameteredCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, param.ItemNumber, customer.POSSalesEndDate.Value.AddDays(-21));
                        posCollection.Load();
                        if (posCollection.Count > 0)
                            row.Cells["POSWeek1Quantity"].Value = posCollection[0].Quantity;
                    }

                    row.Cells["StoreCountExistingSalesRate"].Value = param.StoreCountExisting;
                    row.Cells["StoreCountNewSalesRate"].Value = param.StoreCountNew;
                    row.Cells["StoreCountTotal"].Value = param.StoreCountExisting + param.StoreCountNew;
                    //row.Cells["SalesRate"].Value = null; // force a recalc

                    // get Previous Sales Rate
                    var previousSalesRateCollection = new ForecastSalesRate.PreviousSalesRateCollection(_customerKey.CompanyCode, _customerKey.CustomerNumber, param.ItemNumber, customer.POSSalesEndDate);
                    previousSalesRateCollection.Load();
                    if (previousSalesRateCollection.Count > 0)
                        row.Cells["SalesRatePrevious"].Value = previousSalesRateCollection[0].SalesRate;

                    Cursor = Cursors.Arrow;
                }
                else if (column.Name == "SalesRate" && formattedValue != "Null")
                {
                    if (formattedValue == string.Empty || !Regex.IsMatch(formattedValue, @"^\d{0,3}(\.\d{1,2})?$"))
                    {
                        row.ErrorText = "Please enter Sales Rate in ###.##";
                        e.Cancel = true;
                        return;
                    }
                    if (decimal.Parse(formattedValue) > 100)
                    {
                        row.ErrorText = "Sales Rate cannot be greater 100";
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || _customerKey == null)
                    return;

                var columnName = dgvSalesRate.Columns[e.ColumnIndex].Name;
                if (columnName != "SalesRate")
                    return;

                var customer = _company.CustomerCollection[_customerKey];
                if (e.RowIndex >= customer.ForecastSalesRateCollection.Count)
                    SalesRateValidateAndSave(new DataGridViewCellCancelEventArgs(e.ColumnIndex, e.RowIndex));

                var row = dgvSalesRate.Rows[e.RowIndex];
                var salesRate = (ForecastSalesRate) row.DataBoundItem;
                customer.UpdateSalesRateOverride(salesRate, true, e.RowIndex >= customer.ForecastSalesRateCollection.Count);
                row.Cells[e.ColumnIndex].Style.BackColor = GetSalesRateCellBackColor(salesRate);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;

                var newColumn = dgvSalesRate.Columns[e.ColumnIndex];
                if (newColumn == null || newColumn.SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;

                var oldColumn = _dgvSalesRateSortedColumn;

                // If oldColumn is null, then the DataGridView is not currently sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && _dgvSalesRateSortOrder == System.Windows.Forms.SortOrder.Ascending)
                        _dgvSalesRateSortOrder = System.Windows.Forms.SortOrder.Descending;
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        _dgvSalesRateSortOrder = System.Windows.Forms.SortOrder.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                    _dgvSalesRateSortOrder = System.Windows.Forms.SortOrder.Ascending;

                if (_company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.ForecastSalesRateCollection.Sort(dgvSalesRate.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvSalesRateSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceSalesRate.DataSource = null;
                    bindingSourceSalesRate.DataSource = customer.ForecastSalesRateCollection;
                    _dgvSalesRateSortedColumn = newColumn;
                    newColumn.HeaderCell.SortGlyphDirection = _dgvSalesRateSortOrder;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dgvSalesRate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = e.Control as TextBox;
            if (tb == null)
                return;

            try
            {
                if (dgvSalesRate.Columns[dgvSalesRate.CurrentCell.ColumnIndex].Name == "ItemNumberSalesRate")
                {
                    var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                    tb.KeyPress -= keyPressEventHandler;
                    tb.KeyPress += keyPressEventHandler;
                }
                var keyEventHandler = new KeyEventHandler(dgvSalesRate_tb_KeyUp);
                tb.KeyUp -= keyEventHandler;
                tb.KeyUp += keyEventHandler;
                tb.ContextMenuStrip = forecastSalesRateContextMenuStrip;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_tb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (_dgvSalesRateRowDirty && e.KeyCode == Keys.Escape && _company != null && _customerKey != null)
                {
                    var posSalesEndDate = _company.CustomerCollection[_customerKey].POSSalesEndDate;
                    var itemNumber = (SqlString)dgvSalesRate.CurrentRow.Cells["ItemNumberSalesRate"].Value;
                    var salesRate = new ForecastSalesRate(_customerKey.CompanyCode, _customerKey.CustomerNumber, posSalesEndDate, itemNumber);
                    salesRate.Load();
                    _company.CustomerCollection[_customerKey].ForecastSalesRateCollection[new ForecastSalesRateKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, posSalesEndDate, itemNumber)] = salesRate;
                    dgvSalesRate.CurrentRow.Cells["SalesRate"].Value = salesRate.SalesRate;
                    _dgvSalesRateRowDirty = false;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void SalesRateValidateAndSave(DataGridViewCellCancelEventArgs e)
        {
            if (!dgvSalesRate.IsCurrentRowDirty)
                return;

            var row = dgvSalesRate.Rows[e.RowIndex];
            if (row.Cells["ItemNumberSalesRate"].Value == null)
                return;

            var itemNumber = (SqlString)(row.Cells["ItemNumberSalesRate"].Value);
            if (itemNumber.IsNull)
            {
                row.ErrorText = "Item# is required";
                e.Cancel = true;
                return;
            }
            //var rate = SqlDecimal.Null;
            //if (row.Cells["SalesRate"].Value != null)
            //{
            //    rate = (SqlDecimal)(row.Cells["SalesRate"].Value);
            //    if (rate.IsNull)
            //    {
            //        row.ErrorText = "Sales Rate is required";
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            var salesRateKey = new ForecastSalesRateKey(_customerKey.CompanyCode, _customerKey.CustomerNumber,
                                                        dtpMonthEndDate.Value, itemNumber);
            ForecastSalesRate salesRate;
            var customer = _company.CustomerCollection[_customerKey];
            // new record
            if (e.RowIndex >= customer.ForecastSalesRateCollection.Count)
            {
                if (customer.ForecastSalesRateCollection.ContainsKey(salesRateKey))
                {
                    row.ErrorText = "Sales Rate for Item already exists for the Customer";
                    e.Cancel = true;
                    return;
                }
                if (!customer.ForecastParameterCollection.ContainsKey(new ForecastParameterKey(_company.CompanyCode, _customerKey.CustomerNumber, itemNumber)))
                {
                    row.ErrorText = "Item does not exist in Forecast Parameter";
                    e.Cancel = true;
                    return;
                }
                salesRate = customer.ForecastSalesRateCollection.Create((salesRateKey));
                ((ForecastSalesRateCollectionHeader)customer.ForecastSalesRateCollection.SetHeader).
                    POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                if (row.Cells["TrendFactor"].Value != null)
                    salesRate.TrendFactor = (SqlDecimal)(row.Cells["TrendFactor"].Value);
                if (row.Cells["POSWeek1Quantity"].Value != null)
                    salesRate.POSWeek1Quantity = (SqlInt32)(row.Cells["POSWeek1Quantity"].Value);
                if (row.Cells["POSWeek2Quantity"].Value != null)
                    salesRate.POSWeek2Quantity = (SqlInt32)(row.Cells["POSWeek2Quantity"].Value);
                if (row.Cells["POSWeek3Quantity"].Value != null)
                    salesRate.POSWeek3Quantity = (SqlInt32)(row.Cells["POSWeek3Quantity"].Value);
                if (row.Cells["POSWeek4Quantity"].Value != null)
                    salesRate.POSWeek4Quantity = (SqlInt32)(row.Cells["POSWeek4Quantity"].Value);
                if (row.Cells["StoreCountExistingSalesRate"].Value != null)
                    salesRate.StoreCountExisting = (SqlInt32)(row.Cells["StoreCountExistingSalesRate"].Value);
                if (row.Cells["StoreCountNewSalesRate"].Value != null)
                    salesRate.StoreCountNew = (SqlInt32)(row.Cells["StoreCountNewSalesRate"].Value);
                if (row.Cells["SalesRate"].Value != null)
                    salesRate.SalesRate = (SqlDecimal)(row.Cells["SalesRate"].Value);
                if (row.Cells["SalesRatePrevious"].Value != null)
                    salesRate.SalesRatePrevious = (SqlDecimal)(row.Cells["SalesRatePrevious"].Value);
                // only save row when working on existing records not generated records
                if (customer.ForecastSalesRateAction == ForecastSalesRateAction.Get)
                {
                    using (var transaction = new Transaction())
                    {
                        transaction.Enlist(customer.ForecastSalesRateCollection);
                        customer.ForecastSalesRateCollection.Save(salesRate);
                        transaction.Enlist(salesRate.ForecastSalesRateCommentAndOverrideCollection);
                        salesRate.ForecastSalesRateCommentAndOverrideCollection.Save();
                        transaction.Commit();
                    }
                }
                else
                    customer.ForecastSalesRateCollection.Add(salesRate);
                // when the initial collection is empty
                // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                // 2. the data moves above need to check for null
                if (bindingSourceSalesRate.Count == 1)
                {
                    bindingSourceSalesRate.DataSource = null;
                    bindingSourceSalesRate.DataSource = customer.ForecastSalesRateCollection;
                }
                else
                    bindingSourceSalesRate.List[bindingSourceSalesRate.Count - 1] = salesRate;
            }
            // existing record
            else
            {
                // only save row when working on existing records not generated records
                if (customer.ForecastSalesRateAction == ForecastSalesRateAction.Get)
                {
                    using (var transaction = new Transaction())
                    {
                        salesRate = (ForecastSalesRate)dgvSalesRate.CurrentRow.DataBoundItem;
                        transaction.Enlist(customer.ForecastSalesRateCollection);
                        customer.ForecastSalesRateCollection.Save(salesRate);
                        transaction.Enlist(salesRate.ForecastSalesRateCommentAndOverrideCollection);
                        salesRate.ForecastSalesRateCommentAndOverrideCollection.Save();
                        transaction.Commit();
                    }
                    customer.ForecastSalesRateCollection[salesRateKey] = salesRate;
                }
            }
            _dgvSalesRateRowDirty = false;            
        }

        private void dgvSalesRate_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                SalesRateValidateAndSave(e);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvSalesRate_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var itemNumber = e.Row.Cells["ItemNumberSalesRate"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm Sales Factor deletion for Item: {0}.", itemNumber), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                var salesRateKey = new ForecastSalesRateKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, dtpMonthEndDate.Value, itemNumber);
                var customer = _company.CustomerCollection[_customerKey];
                // only delete row when working on existing records not generated records
                if (customer.ForecastSalesRateAction == ForecastSalesRateAction.Get)
                {
                    using (var transaction = new Transaction())
                    {
                        var salesRate = customer.ForecastSalesRateCollection[salesRateKey];
                        if (salesRate.HasOverride || salesRate.HasComment)
                        {
                            transaction.Enlist(salesRate.ForecastSalesRateCommentAndOverrideCollection);
                            salesRate.ForecastSalesRateCommentAndOverrideCollection.Delete();
                        }
                        transaction.Enlist(customer.ForecastSalesRateCollection);
                        customer.ForecastSalesRateCollection.Delete(salesRateKey);
                        transaction.Commit();
                    }
                }
                else
                    customer.ForecastSalesRateCollection.Remove(salesRateKey);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region dgvTrend Event Handlers
        private void dgvTrend_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!rbtnTrendByCompanyProductGroup.Checked && !rbtnTrendByCustomerProductGroup.Checked &&
                    !rbtnTrendByCompanyItem.Checked && !rbtnTrendByCustomerItem.Checked)
                    return;

                if (_company == null)
                    return;
                if (rbtnTrendByCustomerItem.Checked || rbtnTrendByCustomerProductGroup.Checked)
                    if (_customerKey == null)
                        return;
                
                int collectionCount = 0;
                if (rbtnTrendByCompanyItem.Checked)
                    collectionCount = _company.ForecastTrendByItemCollection.Count;
                else if (rbtnTrendByCompanyProductGroup.Checked)
                    collectionCount = _company.ForecastTrendByProductGroupCollection.Count;
                else if (rbtnTrendByCustomerItem.Checked)
                    collectionCount = _company.CustomerCollection[_customerKey].ForecastTrendByItemCollection.Count;
                else if (rbtnTrendByCustomerProductGroup.Checked)
                    collectionCount = _company.CustomerCollection[_customerKey].ForecastTrendByProductGroupCollection.Count;

                if (rbtnTrendByCompanyProductGroup.Checked || rbtnTrendByCustomerProductGroup.Checked)
                {
                    if (dgvTrend.Columns[e.ColumnIndex].Name == "ProductGroup" ||
                        dgvTrend.Columns[e.ColumnIndex].Name == "ForecastMethod")
                    {
                        if (e.RowIndex < collectionCount)
                            e.Cancel = true;
                        else if (chkUseClipboardDataOnNewRow.Checked)
                            CopyClipboardToNewRow(dgvTrend, "ProductGroup", "ForecastMethod", e.RowIndex, false);
                    }
                }
                else
                {
                    if (dgvTrend.Columns[e.ColumnIndex].Name == "ItemNumberTrend" ||
                        dgvTrend.Columns[e.ColumnIndex].Name == "ForecastMethod")
                    {
                        if (e.RowIndex < collectionCount)
                            e.Cancel = true;
                        else if (chkUseClipboardDataOnNewRow.Checked)
                            CopyClipboardToNewRow(dgvTrend, "ItemNumberTrend", e.RowIndex, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvTrend.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (dgvTrend.Columns[e.ColumnIndex].Name == "ItemNumberTrend" ||
                    dgvTrend.Columns[e.ColumnIndex].Name == "ForecastMethod")
                {
                    if (e.Value != null)
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
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvTrend.IsCurrentCellDirty)
                    return;
                _dgvTrendRowDirty = true;
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    dgvTrend.CancelEdit();
                    txtCompanyCode.Focus();
                    return;
                }
                if ((rbtnTrendByCompanyItem.Checked || rbtnTrendByCustomerItem.Checked) && _customerKey == null)
                {
                    MessageBox.Show("Please select Customer Number.", "PWC Forecast");
                    dgvTrend.CancelEdit();
                    cboCustomer.Focus();
                    return;
                }
                var row = dgvTrend.Rows[e.RowIndex];
                if (e.FormattedValue == null)
                {
                    row.ErrorText = "Entry is required";
                    e.Cancel = true;
                    return;
                }
                Customer customer = null;
                if (rbtnTrendByCustomerItem.Checked || rbtnTrendByCustomerProductGroup.Checked)
                    customer = _company.CustomerCollection[_customerKey];
                var formattedValue = e.FormattedValue.ToString();
                var columnName = dgvTrend.Columns[e.ColumnIndex].Name;
                if (columnName == "ItemNumberTrend")
                {
                    if (!Regex.IsMatch(formattedValue, @"^\d{2}-\d{5}-[A-Z0-9]\d$"))
                    {
                        row.ErrorText = "Please enter Item Number in ##-#####-A#";
                        e.Cancel = true;
                    }
                    //if (!customer.ForecastParameterCollection.ContainsKey(
                    //    new ForecastParameterKey(customerKey.CompanyCode, customerKey.CustomerNumber, formattedValue)))
                    //{
                    //    row.ErrorText = "Item does not exist in Forecast Parameter";
                    //    e.Cancel = true;
                    //}
                }
                else if (columnName == "ForecastMethod")
                {
                    if (formattedValue.Length != 2 || "SR|PL".IndexOf(formattedValue, StringComparison.Ordinal) < 0)
                    {
                        row.ErrorText = "Please enter Forecast Method as SR or PL";
                        e.Cancel = true;
                        return;
                    }
                    if (row.Cells["ItemNumberTrend"].Value != null)
                    {
                        var itemNumber = (SqlString)row.Cells["ItemNumberTrend"].Value;
                        if (rbtnTrendByCompanyItem.Checked && e.RowIndex >= _company.ForecastTrendByItemCollection.Count) // new record
                        {
                            var trendKey = new ForecastTrendByCompanyItemKey(_customerKey.CompanyCode, itemNumber, formattedValue);
                            if (_company.ForecastTrendByItemCollection.ContainsKey(trendKey))
                            {
                                row.ErrorText = "Trend Factor for Item already exists for the Company";
                                e.Cancel = true;
                                return;
                            }
                        }
                        if (rbtnTrendByCustomerItem.Checked && e.RowIndex >= customer.ForecastTrendByItemCollection.Count) // new record
                        {
                            var trendKey = new ForecastTrendByCustomerItemKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber, formattedValue);
                            if (customer.ForecastTrendByItemCollection.ContainsKey(trendKey))
                            {
                                row.ErrorText = "Trend Factor for Item already exists for the Customer";
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    if (row.Cells["ProductGroup"].Value != null)
                    {
                        if (rbtnTrendByCompanyProductGroup.Checked && _company.ForecastTrendByItemCollection.Count > 0) // new record
                        {
                            var trendKey = new ForecastTrendByCompanyProductGroupKey(_company.CompanyCode, (string)row.Cells["ProductGroup"].Value, formattedValue);
                            if (_company.ForecastTrendByProductGroupCollection.ContainsKey(trendKey))
                            {
                                row.ErrorText = "Trend Factor for Product Group already exists for the Company";
                                e.Cancel = true;
                                return;
                            }
                        }
                        if (rbtnTrendByCustomerProductGroup.Checked && customer.ForecastTrendByItemCollection.Count > 0) // new record
                        {
                            var trendKey = new ForecastTrendByCustomerProductGroupKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, (string)row.Cells["ProductGroup"].Value, formattedValue);
                            if (customer.ForecastTrendByProductGroupCollection.ContainsKey(trendKey))
                            {
                                row.ErrorText = "Trend Factor for Product Group already exists for the Customer";
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    // the object may not exists for new record
                    // only update the screen
                    row.Cells["ForecastMethod"].Value = (SqlString)formattedValue;
                    
                    // default all 12 month to 100.00
                    var startColumnIndex = row.Cells["FactorMonth01"].ColumnIndex;
                    var endColumnIndex = row.Cells["FactorMonth12"].ColumnIndex;
                    for (var colIndex = startColumnIndex; colIndex <= endColumnIndex; colIndex++)
                        row.Cells[colIndex].Value = SqlDecimal.ConvertToPrecScale(100, 5, 2);
                }
                else if (columnName == "FactorMonth01" ||
                    columnName == "FactorMonth02" ||
                    columnName == "FactorMonth03" ||
                    columnName == "FactorMonth04" ||
                    columnName == "FactorMonth05" ||
                    columnName == "FactorMonth06" ||
                    columnName == "FactorMonth07" ||
                    columnName == "FactorMonth08" ||
                    columnName == "FactorMonth09" ||
                    columnName == "FactorMonth10" ||
                    columnName == "FactorMonth11" ||
                    columnName == "FactorMonth12")
                {
                    if (formattedValue == string.Empty || formattedValue == "Null" || !Regex.IsMatch(formattedValue, @"^\d{0,3}(\.\d{1,2})?$"))
                    {
                        row.ErrorText = "Please enter Trend Factor in ###.##";
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;

                var newColumn = dgvTrend.Columns[e.ColumnIndex];
                if (newColumn == null || newColumn.SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;

                var oldColumn = _dgvTrendSortedColumn;

                // If oldColumn is null, then the DataGridView is not currently sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && _dgvTrendSortOrder == System.Windows.Forms.SortOrder.Ascending)
                        _dgvTrendSortOrder = System.Windows.Forms.SortOrder.Descending;
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        _dgvTrendSortOrder = System.Windows.Forms.SortOrder.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                    _dgvTrendSortOrder = System.Windows.Forms.SortOrder.Ascending;

                if (rbtnTrendByCompanyItem.Checked && _company != null)
                {
                    _company.ForecastTrendByItemCollection.Sort(dgvTrend.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvTrendSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceTrend.DataSource = null;
                    bindingSourceTrend.DataSource = _company.ForecastTrendByItemCollection;
                }
                else if (rbtnTrendByCustomerItem.Checked && _company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.ForecastTrendByItemCollection.Sort(dgvTrend.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvTrendSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceTrend.DataSource = null;
                    bindingSourceTrend.DataSource = customer.ForecastTrendByItemCollection;
                }
                else if (rbtnTrendByCompanyProductGroup.Checked && _company != null)
                {
                    _company.ForecastTrendByProductGroupCollection.Sort(dgvTrend.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvTrendSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceTrend.DataSource = null;
                    bindingSourceTrend.DataSource = _company.ForecastTrendByProductGroupCollection;
                }
                else if (rbtnTrendByCustomerProductGroup.Checked && _company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.ForecastTrendByProductGroupCollection.Sort(dgvTrend.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvTrendSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceTrend.DataSource = null;
                    bindingSourceTrend.DataSource = customer.ForecastTrendByProductGroupCollection;
                }
                _dgvTrendSortedColumn = newColumn;
                newColumn.HeaderCell.SortGlyphDirection = _dgvTrendSortOrder;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dgvTrend_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if ((dgvTrend.Columns[dgvTrend.CurrentCell.ColumnIndex].Name == "ItemNumberTrend" ||
                    dgvTrend.Columns[dgvTrend.CurrentCell.ColumnIndex].Name == "ForecastMethod") &&
                    e.Control is TextBox)
                {
                    var tb = e.Control as TextBox;
                    var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                    tb.KeyPress -= keyPressEventHandler;
                    tb.KeyPress += keyPressEventHandler;
                }
                if (e.Control is TextBox)
                {
                    var tb = e.Control as TextBox;
                    var keyEventHandler = new KeyEventHandler(dgvTrend_tb_KeyUp);
                    tb.KeyUp -= keyEventHandler;
                    tb.KeyUp += keyEventHandler;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_tb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (_dgvTrendRowDirty && e.KeyCode == Keys.Escape)
                {
                    IForecastTrendValue trend = null;
                    var forecastMethod = (SqlString)dgvTrend.CurrentRow.Cells["ForecastMethod"].Value;
                    if (rbtnTrendByCompanyItem.Checked && _company != null)
                    {
                        var itemNumber = (SqlString)dgvTrend.CurrentRow.Cells["ItemNumberTrend"].Value;
                        trend = new ForecastTrendByCompanyItem(_company.CompanyCode, itemNumber, forecastMethod);
                        ((ForecastTrendByCompanyItem)trend).Load();
                        _company.ForecastTrendByItemCollection[new ForecastTrendByCompanyItemKey(_company.CompanyCode, itemNumber, forecastMethod)] = (ForecastTrendByCompanyItem)trend;
                    }
                    else if (rbtnTrendByCustomerItem.Checked && _company != null && _customerKey != null)
                    {
                        var itemNumber = (SqlString)dgvTrend.CurrentRow.Cells["ItemNumberTrend"].Value;
                        trend = new ForecastTrendByCustomerItem(_customerKey.CompanyCode, _customerKey.CustomerNumber, (SqlString)dgvTrend.CurrentRow.Cells["ItemNumberTrend"].Value, (SqlString)dgvTrend.CurrentRow.Cells["ForecastMethod"].Value);
                        ((ForecastTrendByCustomerItem)trend).Load();
                        _company.CustomerCollection[_customerKey].ForecastTrendByItemCollection[new ForecastTrendByCustomerItemKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber, forecastMethod)] = (ForecastTrendByCustomerItem)trend;
                    }
                    else if (rbtnTrendByCompanyProductGroup.Checked && _company != null)
                    {
                        var productGroupCode = (SqlString)dgvTrend.CurrentRow.Cells["ProductGroup"].Value;
                        trend = new ForecastTrendByCompanyProductGroup(_company.CompanyCode, productGroupCode, (SqlString)dgvTrend.CurrentRow.Cells["ForecastMethod"].Value);
                        ((ForecastTrendByCompanyProductGroup)trend).Load();
                        _company.ForecastTrendByProductGroupCollection[new ForecastTrendByCompanyProductGroupKey(_company.CompanyCode, productGroupCode, forecastMethod)] = (ForecastTrendByCompanyProductGroup)trend;
                    }
                    else if (rbtnTrendByCustomerProductGroup.Checked && _company != null && _customerKey != null)
                    {
                        var productGroupCode = (SqlString)dgvTrend.CurrentRow.Cells["ProductGroup"].Value;
                        trend = new ForecastTrendByCustomerProductGroup(_customerKey.CompanyCode, _customerKey.CustomerNumber, productGroupCode, (SqlString)dgvTrend.CurrentRow.Cells["ForecastMethod"].Value);
                        ((ForecastTrendByCustomerProductGroup)trend).Load();
                        _company.CustomerCollection[_customerKey].ForecastTrendByProductGroupCollection[new ForecastTrendByCustomerProductGroupKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, productGroupCode, forecastMethod)] = (ForecastTrendByCustomerProductGroup)trend;
                    }
                    dgvTrend.CurrentRow.Cells["FactorMonth01"].Value = trend.FactorMonth01;
                    dgvTrend.CurrentRow.Cells["FactorMonth02"].Value = trend.FactorMonth02;
                    dgvTrend.CurrentRow.Cells["FactorMonth03"].Value = trend.FactorMonth03;
                    dgvTrend.CurrentRow.Cells["FactorMonth04"].Value = trend.FactorMonth04;
                    dgvTrend.CurrentRow.Cells["FactorMonth05"].Value = trend.FactorMonth05;
                    dgvTrend.CurrentRow.Cells["FactorMonth06"].Value = trend.FactorMonth06;
                    dgvTrend.CurrentRow.Cells["FactorMonth07"].Value = trend.FactorMonth07;
                    dgvTrend.CurrentRow.Cells["FactorMonth08"].Value = trend.FactorMonth08;
                    dgvTrend.CurrentRow.Cells["FactorMonth09"].Value = trend.FactorMonth09;
                    dgvTrend.CurrentRow.Cells["FactorMonth10"].Value = trend.FactorMonth10;
                    dgvTrend.CurrentRow.Cells["FactorMonth11"].Value = trend.FactorMonth11;
                    dgvTrend.CurrentRow.Cells["FactorMonth12"].Value = trend.FactorMonth12;
                    _dgvTrendRowDirty = false;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private static void SetTrendFactorValues(IForecastTrendValue trend, DataGridViewRow row)
        {
            if (row.Cells["FactorMonth01"].Value != null)
                trend.FactorMonth01 = (SqlDecimal)(row.Cells["FactorMonth01"].Value);
            if (row.Cells["FactorMonth02"].Value != null)
                trend.FactorMonth02 = (SqlDecimal)(row.Cells["FactorMonth02"].Value);
            if (row.Cells["FactorMonth03"].Value != null)
                trend.FactorMonth03 = (SqlDecimal)(row.Cells["FactorMonth03"].Value);
            if (row.Cells["FactorMonth04"].Value != null)
                trend.FactorMonth04 = (SqlDecimal)(row.Cells["FactorMonth04"].Value);
            if (row.Cells["FactorMonth05"].Value != null)
                trend.FactorMonth05 = (SqlDecimal)(row.Cells["FactorMonth05"].Value);
            if (row.Cells["FactorMonth06"].Value != null)
                trend.FactorMonth06 = (SqlDecimal)(row.Cells["FactorMonth06"].Value);
            if (row.Cells["FactorMonth07"].Value != null)
                trend.FactorMonth07 = (SqlDecimal)(row.Cells["FactorMonth07"].Value);
            if (row.Cells["FactorMonth08"].Value != null)
                trend.FactorMonth08 = (SqlDecimal)(row.Cells["FactorMonth08"].Value);
            if (row.Cells["FactorMonth09"].Value != null)
                trend.FactorMonth09 = (SqlDecimal)(row.Cells["FactorMonth09"].Value);
            if (row.Cells["FactorMonth10"].Value != null)
                trend.FactorMonth10 = (SqlDecimal)(row.Cells["FactorMonth10"].Value);
            if (row.Cells["FactorMonth11"].Value != null)
                trend.FactorMonth11 = (SqlDecimal)(row.Cells["FactorMonth11"].Value);
            if (row.Cells["FactorMonth12"].Value != null)
                trend.FactorMonth12 = (SqlDecimal)(row.Cells["FactorMonth12"].Value);
        }

        private void dgvTrend_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvTrend.IsCurrentRowDirty)
                    return;

                var row = dgvTrend.Rows[e.RowIndex];
                SqlString itemNumber = null, forecastMethod = null;
                Customer customer = null;
                if (rbtnTrendByCustomerItem.Checked || rbtnTrendByCustomerProductGroup.Checked)
                    customer = _company.CustomerCollection[_customerKey];
                if ((rbtnTrendByCustomerItem.Checked || rbtnTrendByCompanyItem.Checked) && row.Cells["ItemNumberTrend"].Value != null)
                {
                    //customer = company.CustomerCollection[customerKey];
                    itemNumber = (SqlString)(row.Cells["ItemNumberTrend"].Value);
                    if (itemNumber.IsNull)
                    {
                        row.ErrorText = "Item# is required";
                        e.Cancel = true;
                        return;
                    }
                    //if (!customer.ForecastParameterCollection.ContainsKey(new ForecastParameterKey(customerKey.CompanyCode, customerKey.CustomerNumber, itemNumber)))
                    //{
                    //    row.ErrorText = "Item does not exist in Forecast Parameter";
                    //    e.Cancel = true;
                    //    return;
                    //}
                }
                if ((rbtnTrendByCompanyProductGroup.Checked || rbtnTrendByCustomerProductGroup.Checked) && (row.Cells["ProductGroup"].Value == null || row.Cells["ProductGroup"].Value.ToString() == string.Empty))
                {
                    row.ErrorText = "Product Group is required";
                    e.Cancel = true;
                    return;
                }
                if (row.Cells["ForecastMethod"].Value != null)
                {
                    forecastMethod = (SqlString)row.Cells["ForecastMethod"].Value;
                    if (forecastMethod.IsNull)
                    {
                        row.ErrorText = "Forecast Method is required";
                        e.Cancel = true;
                        return;
                    }
                }
                var startColumnIndex = row.Cells["FactorMonth01"].ColumnIndex;
                var endColumnIndex = row.Cells["FactorMonth12"].ColumnIndex;
                for (var i = startColumnIndex; i <= endColumnIndex; i++)
                    if (row.Cells[i].Value == null || ((SqlDecimal)row.Cells[i].Value).IsNull)
                    {
                        row.ErrorText = "Please enter all 12 Trend Factors";
                        e.Cancel = true;
                        return;
                    }
                if (rbtnTrendByCompanyItem.Checked)
                {
                    var trendKey = new ForecastTrendByCompanyItemKey(_customerKey.CompanyCode, itemNumber, forecastMethod);
                    ForecastTrendByCompanyItem trend;
                    // new record
                    if (e.RowIndex >= _company.ForecastTrendByItemCollection.Count)
                    {
                        if (_company.ForecastTrendByItemCollection.ContainsKey(trendKey))
                        {
                            row.ErrorText = "Trend Factor for Item already exists for the Company";
                            e.Cancel = true;
                            return;
                        }
                        trend = _company.ForecastTrendByItemCollection.Create((trendKey));
                        SetTrendFactorValues(trend, row);
                        _company.ForecastTrendByItemCollection.Save(trend);
                        // when the initial collection is empty
                        // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                        // 2. the data moves above need to check for null
                        if (bindingSourceTrend.Count == 1)
                        {
                            bindingSourceTrend.DataSource = null;
                            bindingSourceTrend.DataSource = _company.ForecastTrendByItemCollection;
                        }
                        else
                            bindingSourceTrend.List[bindingSourceTrend.Count - 1] = trend;
                    }
                    // existing record
                    else
                    {
                        //trend = _company.ForecastTrendByItemCollection[trendKey];
                        //trend.Save();
                        trend = (ForecastTrendByCompanyItem)dgvTrend.CurrentRow.DataBoundItem;
                        _company.ForecastTrendByItemCollection.Save(trend);
                        _company.ForecastTrendByItemCollection[trendKey] = trend;
                    }
                }
                else if (rbtnTrendByCustomerItem.Checked)
                {
                    var trendKey = new ForecastTrendByCustomerItemKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber, forecastMethod);
                    ForecastTrendByCustomerItem trend;
                    // new record
                    if (e.RowIndex >= customer.ForecastTrendByItemCollection.Count)
                    {
                        if (customer.ForecastTrendByItemCollection.ContainsKey(trendKey))
                        {
                            row.ErrorText = "Trend Factor for Item already exists for the Customer";
                            e.Cancel = true;
                            return;
                        }
                        trend = customer.ForecastTrendByItemCollection.Create(trendKey);
                        SetTrendFactorValues(trend, row);
                        customer.ForecastTrendByItemCollection.Save(trend);
                        // when the initial collection is empty
                        // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                        // 2. the data moves above need to check for null
                        if (bindingSourceTrend.Count == 1)
                        {
                            bindingSourceTrend.DataSource = null;
                            bindingSourceTrend.DataSource = customer.ForecastTrendByItemCollection;
                        }
                        else
                            bindingSourceTrend.List[bindingSourceTrend.Count - 1] = trend;
                    }
                    // existing record
                    else
                    {
                        //trend = customer.ForecastTrendByItemCollection[trendKey];
                        //trend.Save();
                        trend = (ForecastTrendByCustomerItem)dgvTrend.CurrentRow.DataBoundItem;
                        customer.ForecastTrendByItemCollection.Save(trend);
                        customer.ForecastTrendByItemCollection[trendKey] = trend;
                    }
                }
                else if (rbtnTrendByCompanyProductGroup.Checked)
                {
                    var trendKey = new ForecastTrendByCompanyProductGroupKey(_company.CompanyCode, (string)row.Cells["ProductGroup"].Value, forecastMethod);
                    ForecastTrendByCompanyProductGroup trend;
                    // new record
                    if (e.RowIndex >= _company.ForecastTrendByProductGroupCollection.Count)
                    {
                        if (_company.ForecastTrendByProductGroupCollection.ContainsKey(trendKey))
                        {
                            row.ErrorText = "Trend Factor for Product Group already exists for the Company";
                            e.Cancel = true;
                            return;
                        }
                        trend = _company.ForecastTrendByProductGroupCollection.Create((trendKey));
                        SetTrendFactorValues(trend, row);
                        _company.ForecastTrendByProductGroupCollection.Save(trend);
                        // when the initial collection is empty
                        // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                        // 2. the data moves above need to check for null
                        if (bindingSourceTrend.Count == 1)
                        {
                            bindingSourceTrend.DataSource = null;
                            bindingSourceTrend.DataSource = _company.ForecastTrendByProductGroupCollection;
                        }
                        else
                            bindingSourceTrend.List[bindingSourceTrend.Count - 1] = trend;
                    }
                    // existing record
                    else
                    {
                        //trend = _company.ForecastTrendByProductGroupCollection[trendKey];
                        //trend.Save();
                        trend = (ForecastTrendByCompanyProductGroup)dgvTrend.CurrentRow.DataBoundItem;
                        _company.ForecastTrendByProductGroupCollection.Save(trend);
                        _company.ForecastTrendByProductGroupCollection[trendKey] = trend;
                    }
                    _dgvTrendRowDirty = false;
                    //invalidate the related collection
                    if (customer != null)
                        customer.ForecastTrendByCompanyProductGroupItemCollection = null;
                }
                else if (rbtnTrendByCustomerProductGroup.Checked)
                {
                    var trendKey = new ForecastTrendByCustomerProductGroupKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, (string)row.Cells["ProductGroup"].Value, forecastMethod);
                    ForecastTrendByCustomerProductGroup trend;
                    // new record
                    if (e.RowIndex >= customer.ForecastTrendByProductGroupCollection.Count)
                    {
                        if (customer.ForecastTrendByProductGroupCollection.ContainsKey(trendKey))
                        {
                            row.ErrorText = "Trend Factor for Product Group already exists for the Customer";
                            e.Cancel = true;
                            return;
                        }
                        trend = customer.ForecastTrendByProductGroupCollection.Create((trendKey));
                        SetTrendFactorValues(trend, row);
                        customer.ForecastTrendByProductGroupCollection.Save(trend);
                        // when the initial collection is empty
                        // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                        // 2. the data moves above need to check for null
                        if (bindingSourceTrend.Count == 1)
                        {
                            bindingSourceTrend.DataSource = null;
                            bindingSourceTrend.DataSource = customer.ForecastTrendByProductGroupCollection;
                        }
                        else
                            bindingSourceTrend.List[bindingSourceTrend.Count - 1] = trend;
                    }
                    // existing record
                    else
                    {
                        //trend = customer.ForecastTrendByProductGroupCollection[trendKey];
                        //trend.Save();
                        trend = (ForecastTrendByCustomerProductGroup)dgvTrend.CurrentRow.DataBoundItem;
                        customer.ForecastTrendByProductGroupCollection.Save(trend);
                        customer.ForecastTrendByProductGroupCollection[trendKey] = trend;
                    }
                    _dgvTrendRowDirty = false;
                    //invalidate the related collection
                    if (customer != null)
                        customer.ForecastTrendByCustomerProductGroupItemCollection = null;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvTrend_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                Customer customer = null;
                if (_customerKey != null)
                    customer = _company.CustomerCollection[_customerKey];

                var forecastMethod = e.Row.Cells["ForecastMethod"].Value.ToString();
                if (rbtnTrendByCompanyProductGroup.Checked || rbtnTrendByCustomerProductGroup.Checked)
                {
                    var productGroupCode = (string)e.Row.Cells["ProductGroup"].Value;
                    if (MessageBox.Show(string.Format("Please confirm Trend Factor deletion for Product Group: {0}, Forecast Method: {1}.", productGroupCode, forecastMethod), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (rbtnTrendByCompanyProductGroup.Checked)
                    {
                        var trendKey = new ForecastTrendByCompanyProductGroupKey(_company.CompanyCode, productGroupCode, forecastMethod);
                        _company.ForecastTrendByProductGroupCollection.Delete(trendKey);
                        //invalidate the related collection
                        if (_customerKey != null)
                            customer.ForecastTrendByCompanyProductGroupItemCollection = null;
                    }
                    else if (rbtnTrendByCustomerProductGroup.Checked && _customerKey != null)
                    {
                        var trenKey = new ForecastTrendByCustomerProductGroupKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, productGroupCode, forecastMethod);
                        customer.ForecastTrendByProductGroupCollection.Delete(trenKey);
                        //invalidate the related collection
                        if (_customerKey != null)
                            customer.ForecastTrendByCustomerProductGroupItemCollection = null;
                    }
                }
                else
                {
                    var itemNumber = e.Row.Cells["ItemNumberTrend"].Value.ToString();
                    if (MessageBox.Show(string.Format("Please confirm Trend Factor deletion for Item: {0}, Forecast Method: {1}.", itemNumber, forecastMethod), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (rbtnTrendByCompanyItem.Checked)
                    {
                        var trendKey = new ForecastTrendByCompanyItemKey(_customerKey.CompanyCode, itemNumber, forecastMethod);
                        _company.ForecastTrendByItemCollection.Delete(trendKey);
                    }
                    else if (rbtnTrendByCustomerItem.Checked)
                    {
                        var trendKey = new ForecastTrendByCustomerItemKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber, forecastMethod);
                        _company.CustomerCollection[_customerKey].ForecastTrendByItemCollection.Delete(trendKey);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region dgvForecast Event Handlers
        private void dgvForecast_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (_company == null || _customerKey == null)
                    return;
                var column = dgvForecast.Columns[e.ColumnIndex];
                var customer = _company.CustomerCollection[_customerKey];
                if (column.Name == "ItemNumberForecast" ||
                    column.Name == "ForecastMethodForecast")
                {
                    if (e.RowIndex < customer.ForecastCollection.Count)
                        e.Cancel = true;
                    else if (chkUseClipboardDataOnNewRow.Checked)
                        CopyClipboardToNewRow(dgvForecast, "ItemNumberForecast", "ForecastMethodForecast", e.RowIndex, true);
                }
                else
                {
                    var calendar = Calendar.GetInstance();
                    var latestPOSSalesEndDate = GetLatestPOSSalesEndDate(customer);

                    if (Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$")) // CY##, NY##, PY##
                    {
                        var forecastMethod = string.Empty;
                        if (dgvForecast.Rows[e.RowIndex].Cells["ForecastMethodForecast"].Value != null)
                            forecastMethod = dgvForecast.Rows[e.RowIndex].Cells["ForecastMethodForecast"].Value.ToString();
                        if (forecastMethod.Length != 2)
                            e.Cancel = true;
                        if (latestPOSSalesEndDate > customer.POSSalesEndDate.Value &&
                            String.CompareOrdinal(calendar.GetYYMM(customer.POSSalesEndDate.Value), calendar.GetYYMM(DateTime.Today)) < 0)
                            e.Cancel = true;
                        else if ("SR|RA".IndexOf(forecastMethod, StringComparison.Ordinal) > -1 &&
                            String.CompareOrdinal(calendar.GetYYMM(column.HeaderText), calendar.GetYYMM(customer.POSSalesEndDate.Value.AddMonths(customer.ForecastFutureFrozenMonths.Value))) <= 0)
                            e.Cancel = true;
                        //else if ("SR|RA".IndexOf(forecastMethod) > -1 &&
                        //    calendar.GetYYMM(column.HeaderText).CompareTo(calendar.GetYYMM(CommentOverrideDateTime.Today.AddMonths(customer.ForecastFutureFrozenMonths.Value))) <= 0)
                        //    e.Cancel = true;
                        else if (forecastMethod == "PL" &&
                            String.CompareOrdinal(calendar.GetYYMM(column.HeaderText), calendar.GetYYMM(DateTime.Today)) < 0)
                            e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvForecast.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _mouseLocation = e;
        }

        private static Color GetForecastCellBackColor(BusinessObject.Forecast forecast, string columnName)
        {
            var color = SystemColors.Window;
            if (!forecast.HasComment && !forecast.HasOverride)
                return color;

            var commentAndOverrides = forecast.ForecastCommentAndOverrideCollection
                .Where(commentAndOverride => (bool)(commentAndOverride.ForecastValueKey == columnName))
                .OrderByDescending(commentAndOverride => commentAndOverride.CommentOverrideDateTime);
            var manualOverride = commentAndOverrides.FirstOrDefault(commentAndOverride => commentAndOverride.Comment.IsNull);
            var isManualOverride = (bool)(manualOverride != null && manualOverride.IsOverride);
            var hasComment = commentAndOverrides.Any(commentAndOverride => !commentAndOverride.Comment.IsNull);
            if (isManualOverride && hasComment)
                color = Color.Orange;
            else if (isManualOverride)
                color = Color.Tomato;
            else if (hasComment)
                color = Color.Yellow;
            return color;
        }

        private void dgvForecast_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || _customerKey == null)
                return;
            var forecastCollection = _company.CustomerCollection[_customerKey].ForecastCollection;
            if (e.RowIndex >= forecastCollection.Count)
                return;
            try
            {
                var column = dgvForecast.Columns[e.ColumnIndex];
                if (Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$")) // CY##, NY##, PY##
                    e.CellStyle.BackColor = GetForecastCellBackColor(forecastCollection[e.RowIndex], column.HeaderText);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e == null || e.Value == null)
                return;
            try
            {
                // default parsing fails to convert string to sqlstring
                // assist it here.
                var column = dgvForecast.Columns[e.ColumnIndex];
                if (column.Name == "ItemNumberForecast" ||
                    column.Name == "ForecastMethodForecast")
                {
                    //if (e.Value.ToString() == "Null")
                    //{
                    //    e.Value = SqlString.Null;
                    //    e.ParsingApplied = true;
                    //}
                    e.Value = new SqlString(e.Value.ToString());
                    e.ParsingApplied = true;
                }
                else
                {
                    if (Regex.IsMatch(column.HeaderText, @"^[PCN]Y[01]\d$")) // CY##, NY##, PY##
                    {
                        if (e.Value.ToString() == "Null")
                        {
                            e.Value = SqlInt32.Null;
                            e.ParsingApplied = true;
                        }
                    }
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

        private void dgvForecast_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvForecast.IsCurrentCellDirty)
                    return;

                _dgvForecastRowDirty = true;
                if (_company == null)
                {
                    MessageBox.Show("Please enter Company Code.", "PWC Forecast");
                    dgvForecast.CancelEdit();
                    txtCompanyCode.Focus();
                    return;
                }
                if (_customerKey == null)
                {
                    MessageBox.Show("Please select Customer Number.", "PWC Forecast");
                    dgvForecast.CancelEdit();
                    cboCustomer.Focus();
                    return;
                }
                var row = dgvForecast.Rows[e.RowIndex];
                if (e.FormattedValue == null)
                {
                    row.ErrorText = "Entry is required";
                    e.Cancel = true;
                    return;
                }
                var customer = _company.CustomerCollection[_customerKey];
                var formattedValue = e.FormattedValue.ToString();
                var columnName = dgvForecast.Columns[e.ColumnIndex].Name;
                if (columnName == "ItemNumberForecast")
                {
                    if (!Regex.IsMatch(formattedValue, @"^\d{2}-\d{5}-[A-Z0-9]{2}$"))
                    {
                        row.ErrorText = "Please enter Item Number in ##-#####-A#";
                        e.Cancel = true;
                        return;
                    }
#if TEMPFORECASTITEM
                    var itemCollection = new Item.ParameteredCollection(formattedValue, SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
                    itemCollection.Load();
                    if (itemCollection.Count == 0)
                    {
                        row.ErrorText = "Item does not exist in Item Master";
                        e.Cancel = true;
                    }
#else
                    if (!customer.ForecastParameterCollection.ContainsKey(new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, formattedValue)) &&
                        !customer.BonusAndDiscontinuedCollection.ContainsKey(new BonusAndDiscontinuedByCustomerKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, formattedValue)) &&
                        !_company.BonusAndDiscontinuedCollection.ContainsKey(new BonusAndDiscontinuedByCompanyKey(_customerKey.CompanyCode, formattedValue)))
                    {
                        row.ErrorText = "Item does not exist in Forecast Parameter";
                        e.Cancel = true;
                        return;
                    }
#endif
                }
                else if (columnName == "ForecastMethodForecast")
                {
                    if (formattedValue.Length != 2 || "SR|PL|RA".IndexOf(formattedValue) < 0)
                    {
                        row.ErrorText = "Please enter Format Method as SR, RA or PL";
                        e.Cancel = true;
                        return;
                    }
                    if (row.Cells["ItemNumberForecast"].Value != null)
                    {
                        var itemNumber = (SqlString)row.Cells["ItemNumberForecast"].Value;
                        if (e.RowIndex >= customer.ForecastCollection.Count) // new record
                        {
                            var forecastKey = new ForecastKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, dtpMonthEndDate.Value, itemNumber, formattedValue);
                            if (customer.ForecastCollection.ContainsKey(forecastKey))
                            {
                                row.ErrorText = "Forecast for Item already exists for the Customer";
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    // the object may not exists for new record
                    // only update the screen
                    row.Cells["ForecastMethodForecast"].Value = (SqlString)formattedValue;
                }
                else if (formattedValue != "Null") // forecast value columns
                {
                    if (!Regex.IsMatch(formattedValue, @"^\-?\d{1,6}$"))
                    {
                        dgvForecast.Rows[e.RowIndex].ErrorText = "Please enter a numeric value";
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || _customerKey == null)
                    return;

                var columnName = dgvForecast.Columns[e.ColumnIndex].Name;
                if ("ItemNumberForecast|ForecastMethodForecast".IndexOf(columnName, StringComparison.Ordinal) > -1)
                    return;

                var customer = _company.CustomerCollection[_customerKey];
                if (e.RowIndex >= customer.ForecastCollection.Count)
                    ForecastValidateAndSave(new DataGridViewCellCancelEventArgs(e.ColumnIndex, e.RowIndex));

                var row = dgvForecast.Rows[e.RowIndex];
                var forecast = (BusinessObject.Forecast) row.DataBoundItem;
                customer.UpdateForecastOverride(forecast, columnName, true, e.RowIndex >= customer.ForecastCollection.Count);
                row.Cells[e.ColumnIndex].Style.BackColor = GetForecastCellBackColor(forecast, columnName);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;
                
                var newColumn = dgvForecast.Columns[e.ColumnIndex];
                if (newColumn == null || newColumn.SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;

                var oldColumn = _dgvForecastSortedColumn;

                // If oldColumn is null, then the DataGridView is not currently sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && _dgvForecastSortOrder == System.Windows.Forms.SortOrder.Ascending)
                        _dgvForecastSortOrder = System.Windows.Forms.SortOrder.Descending;
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        _dgvForecastSortOrder = System.Windows.Forms.SortOrder.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                    _dgvForecastSortOrder = System.Windows.Forms.SortOrder.Ascending;

                if (_company != null && _customerKey != null)
                {
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.ForecastCollection.Sort(dgvForecast.Columns[e.ColumnIndex].DataPropertyName,
                        _dgvForecastSortOrder == System.Windows.Forms.SortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                    bindingSourceForecast.DataSource = null;
                    bindingSourceForecast.DataSource = customer.ForecastCollection;
                    _dgvForecastSortedColumn = newColumn;
                    newColumn.HeaderCell.SortGlyphDirection = _dgvForecastSortOrder;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = e.Control as TextBox;
            if (tb == null)
                return;

            try
            {
                if (dgvForecast.Columns[dgvForecast.CurrentCell.ColumnIndex].Name == "ForecastMethodForecast" ||
                    dgvForecast.Columns[dgvForecast.CurrentCell.ColumnIndex].Name == "ItemNumberForecast")
                {
                    var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                    tb.KeyPress -= keyPressEventHandler;
                    tb.KeyPress += keyPressEventHandler;
                } 
                var keyEventHandler = new KeyEventHandler(dgvForecast_tb_KeyUp);
                tb.KeyUp -= keyEventHandler;
                tb.KeyUp += keyEventHandler;
                tb.ContextMenuStrip = forecastContextMenuStrip;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvForecast_tb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (_dgvForecastRowDirty && e.KeyCode == Keys.Escape && _company != null && _customerKey != null)
                {
                    var posSalesEndDate = _company.CustomerCollection[_customerKey].POSSalesEndDate;
                    var itemNumber = (SqlString)dgvForecast.CurrentRow.Cells["ItemNumberForecast"].Value;
                    var forecastMethod = (SqlString)dgvForecast.CurrentRow.Cells["ForecastMethodForecast"].Value;
                    var forecast = new BusinessObject.Forecast(_customerKey.CompanyCode, _customerKey.CustomerNumber, posSalesEndDate, itemNumber, forecastMethod);
                    _company.CustomerCollection[_customerKey].ForecastCollection[new ForecastKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, posSalesEndDate, itemNumber, forecastMethod)] = forecast;
                    dgvForecast.CurrentRow.Cells["PY01"].Value = forecast.PY01;
                    dgvForecast.CurrentRow.Cells["PY02"].Value = forecast.PY02;
                    dgvForecast.CurrentRow.Cells["PY03"].Value = forecast.PY03;
                    dgvForecast.CurrentRow.Cells["PY04"].Value = forecast.PY04;
                    dgvForecast.CurrentRow.Cells["PY05"].Value = forecast.PY05;
                    dgvForecast.CurrentRow.Cells["PY06"].Value = forecast.PY06;
                    dgvForecast.CurrentRow.Cells["PY07"].Value = forecast.PY07;
                    dgvForecast.CurrentRow.Cells["PY08"].Value = forecast.PY08;
                    dgvForecast.CurrentRow.Cells["PY09"].Value = forecast.PY09;
                    dgvForecast.CurrentRow.Cells["PY10"].Value = forecast.PY10;
                    dgvForecast.CurrentRow.Cells["PY11"].Value = forecast.PY11;
                    dgvForecast.CurrentRow.Cells["PY12"].Value = forecast.PY12;
                    dgvForecast.CurrentRow.Cells["CY01"].Value = forecast.CY01;
                    dgvForecast.CurrentRow.Cells["CY02"].Value = forecast.CY02;
                    dgvForecast.CurrentRow.Cells["CY03"].Value = forecast.CY03;
                    dgvForecast.CurrentRow.Cells["CY04"].Value = forecast.CY04;
                    dgvForecast.CurrentRow.Cells["CY05"].Value = forecast.CY05;
                    dgvForecast.CurrentRow.Cells["CY06"].Value = forecast.CY06;
                    dgvForecast.CurrentRow.Cells["CY07"].Value = forecast.CY07;
                    dgvForecast.CurrentRow.Cells["CY08"].Value = forecast.CY08;
                    dgvForecast.CurrentRow.Cells["CY09"].Value = forecast.CY09;
                    dgvForecast.CurrentRow.Cells["CY10"].Value = forecast.CY10;
                    dgvForecast.CurrentRow.Cells["CY11"].Value = forecast.CY11;
                    dgvForecast.CurrentRow.Cells["CY12"].Value = forecast.CY12;
                    dgvForecast.CurrentRow.Cells["NY01"].Value = forecast.NY01;
                    dgvForecast.CurrentRow.Cells["NY02"].Value = forecast.NY02;
                    dgvForecast.CurrentRow.Cells["NY03"].Value = forecast.NY03;
                    dgvForecast.CurrentRow.Cells["NY04"].Value = forecast.NY04;
                    dgvForecast.CurrentRow.Cells["NY05"].Value = forecast.NY05;
                    dgvForecast.CurrentRow.Cells["NY06"].Value = forecast.NY06;
                    dgvForecast.CurrentRow.Cells["NY07"].Value = forecast.NY07;
                    dgvForecast.CurrentRow.Cells["NY08"].Value = forecast.NY08;
                    dgvForecast.CurrentRow.Cells["NY09"].Value = forecast.NY09;
                    dgvForecast.CurrentRow.Cells["NY10"].Value = forecast.NY10;
                    dgvForecast.CurrentRow.Cells["NY11"].Value = forecast.NY11;
                    dgvForecast.CurrentRow.Cells["NY12"].Value = forecast.NY12;
                    _dgvForecastRowDirty = false;
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        
        private void dgvForecast_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void ForecastValidateAndSave(DataGridViewCellCancelEventArgs e)
        {
            if (!dgvForecast.IsCurrentRowDirty)
                return;

            var row = dgvForecast.Rows[e.RowIndex];
            var customer = _company.CustomerCollection[_customerKey];
            SqlString itemNumber = null, forecastMethod = null;
            if (row.Cells["ItemNumberForecast"].Value != null)
            {
                itemNumber = (SqlString)(row.Cells["ItemNumberForecast"].Value);
                if (itemNumber.IsNull)
                {
                    row.ErrorText = "Item# is required";
                    e.Cancel = true;
                    return;
                }
#if TEMPFORECASTITEM
                var itemCollection = new Item.ParameteredCollection(itemNumber, SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
                itemCollection.Load();
                if (itemCollection.Count == 0)
                {
                    row.ErrorText = "Item does not exist in Item Master";
                    e.Cancel = true;
                }
#else
                if (!customer.ForecastParameterCollection.ContainsKey(new ForecastParameterKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber)) &&
                    !customer.BonusAndDiscontinuedCollection.ContainsKey(new BonusAndDiscontinuedByCustomerKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, itemNumber)) &
                    !_company.BonusAndDiscontinuedCollection.ContainsKey(new BonusAndDiscontinuedByCompanyKey(_customerKey.CompanyCode, itemNumber)))
                {
                    row.ErrorText = "Item does not exist in Forecast Parameter";
                    e.Cancel = true;
                    return;
                }
#endif
            }
            if (row.Cells["ForecastMethodForecast"].Value != null)
            {
                forecastMethod = (SqlString)row.Cells["ForecastMethodForecast"].Value;
                if (forecastMethod.IsNull)
                {
                    row.ErrorText = "Forecast Method is required";
                    e.Cancel = true;
                    return;
                }
            }
            var forecastKey = new ForecastKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, dtpMonthEndDate.Value, itemNumber, forecastMethod);
            BusinessObject.Forecast forecast;
            // new record
            if (e.RowIndex >= customer.ForecastCollection.Count)
            {
                if (customer.ForecastCollection.ContainsKey(forecastKey))
                {
                    row.ErrorText = "Forecast for Item already exists for the Customer";
                    e.Cancel = true;
                    return;
                }
                forecast = customer.ForecastCollection.Create(forecastKey);
                forecast.CreatedDate = DateTime.Today;
                var PY01ForecastIndex = dgvForecast.Columns["PY01"].Index;
                for (var columnIndex = 0; columnIndex < forecast.ForecastQuantityCollection.Length; columnIndex++)
                    if (row.Cells[PY01ForecastIndex + columnIndex].Value != null)
                        forecast.ForecastQuantityCollection[columnIndex] = (SqlInt32)(row.Cells[PY01ForecastIndex + columnIndex].Value);
                // only save row when working on existing records not generated records
                if (customer.ForecastAction == ForecastAction.Get)
                {
                    using (var transaction = new Transaction())
                    {
                        transaction.Enlist(customer.ForecastCollection);
                        customer.ForecastCollection.Save(forecast);
                        transaction.Enlist(forecast.ForecastCommentAndOverrideCollection);
                        forecast.ForecastCommentAndOverrideCollection.Save();
                        transaction.Commit();
                    }
                }
                else
                    customer.ForecastCollection.Add(forecast);
                // when the initial collection is empty
                // 1. first item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                // 2. the data moves above need to check for null
                if (bindingSourceForecast.Count == 1)
                {
                    bindingSourceForecast.DataSource = null;
                    bindingSourceForecast.DataSource = customer.ForecastCollection;
                }
                else
                    bindingSourceForecast.List[bindingSourceForecast.Count - 1] = forecast;
            }
            // existing record
            else
            {
                // only save row when working on existing records not generated records
                if (customer.ForecastAction == ForecastAction.Get)
                {
                    using (var transaction = new Transaction())
                    {
                        forecast = (BusinessObject.Forecast)dgvForecast.CurrentRow.DataBoundItem;
                        transaction.Enlist(customer.ForecastCollection);
                        customer.ForecastCollection.Save(forecast);
                        transaction.Enlist(forecast.ForecastCommentAndOverrideCollection);
                        forecast.ForecastCommentAndOverrideCollection.Save();
                        transaction.Commit();
                    }
                    customer.ForecastCollection[forecastKey] = forecast;
                }
            }
            _dgvForecastRowDirty = false;            
        }

        private void dgvForecast_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                ForecastValidateAndSave(e);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        void dgvForecast_SelectionChanged(object sender, EventArgs e)
        {
            forecastContextMenuStrip.Items["forecastContextEditCommentMenuItem"].Enabled = dgvForecast.SelectedCells.Count == 1;

            forecastContextMenuStrip.Items["forecastContextEditOverrideMenuItem"].Enabled = true;
            foreach (DataGridViewCell selectedCell in dgvForecast.SelectedCells)
            {
                if ("Item #|Method".IndexOf(dgvForecast.Columns[selectedCell.ColumnIndex].HeaderText, StringComparison.Ordinal) > -1)
                {
                    forecastContextMenuStrip.Items["forecastContextEditOverrideMenuItem"].Enabled = false;
                    return;
                }
            }
        }

        private void dgvForecast_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var itemNumber = e.Row.Cells["ItemNumberForecast"].Value.ToString();
                var forecastMethod = e.Row.Cells["ForecastMethodForecast"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm Forecast deletion for Item: {0}, Forecast Method: {1}.", itemNumber, forecastMethod), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                var forecastKey = new ForecastKey(_customerKey.CompanyCode, _customerKey.CustomerNumber, dtpMonthEndDate.Value, itemNumber, forecastMethod);
                var customer = _company.CustomerCollection[_customerKey];
                if (customer.ForecastAction == ForecastAction.Get)
                    using (var transaction = new Transaction())
                    {
                        var forecast = customer.ForecastCollection[forecastKey];
                        if (forecast.HasOverride || forecast.HasComment)
                        {
                            transaction.Enlist(forecast.ForecastCommentAndOverrideCollection);
                            forecast.ForecastCommentAndOverrideCollection.Delete();
                        }
                        transaction.Enlist(customer.ForecastCollection);
                        customer.ForecastCollection.Delete(forecastKey);
                        transaction.Commit();
                    }
                else
                    customer.ForecastCollection.Remove(forecastKey);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region Combo Boxes Event Handlers
        private void cboSavedSalesRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSavedSalesRate.SelectedIndex < 0)
                    return;
                if (_company != null && _customerKey != null)
                {
                    Cursor = Cursors.WaitCursor;
                    var customer = _company.CustomerCollection[_customerKey];
                    customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                    if (cboSavedSalesRate.SelectedIndex == 0)
                        GetDefaultPOSSalesEndDate();
                    else
                        dtpMonthEndDate.Value = DateTime.Parse(cboSavedSalesRate.SelectedValue.ToString());
                    customer.POSSalesEndDate = dtpMonthEndDate.Value;
                    customer.ForecastSalesRateAction = ForecastSalesRateAction.Get;
                    customer.ForecastSalesRateCollection = null;
                    bindingSourceSalesRate.DataSource = customer.ForecastSalesRateCollection;
                    lblSalesRateDescription.Text = string.Format("Company: {0} - Customer: {1} - Existing Sales Rate (POS ends {2} for {3} weeks)", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"), customer.POSNumberOfWeeks);
                    if (customer.ForecastSalesRateCollection.Count > 0)
                        dgvSalesRate.Focus();
                    Cursor = Cursors.Arrow;
                }
                else
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void cboSavedForecast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSavedForecast.SelectedIndex < 0)
                    return;
                if (_company != null && _customerKey != null)
                {
                    Cursor = Cursors.WaitCursor;
                    var customer = _company.CustomerCollection[_customerKey];
                    //customer.POSNumberOfWeeks = (SqlInt16)nudNumberOfPosWeeksOrSalesMonths.Value;
                    if (cboSavedForecast.SelectedIndex == 0)
                        GetDefaultPOSSalesEndDate();
                    else
                        dtpMonthEndDate.Value = DateTime.Parse(((PWC.PersistenceLayer.Utility.ForecastDateMethod)cboSavedForecast.SelectedItem).POSSalesEndDate);
                    customer.POSSalesEndDate = dtpMonthEndDate.Value;
                    customer.ForecastAction = ForecastAction.Get;
                    customer.ForecastCollection = null;
                    bindingSourceForecast.DataSource = customer.ForecastCollection;
                    lblForecastDescription.Text = string.Format("Company: {0}, Customer: {1} - Existing Forecast (POS/Actual Sale ends {2})", _company.CompanyCode, _customerKey.CustomerNumber, customer.POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
                    if (customer.ForecastCollection.Count > 0)
                        dgvForecast.Focus();
                    Cursor = Cursors.Arrow;
                }
                else
                {
                    MessageBox.Show("Please enter Company Code and Customer Number.", "PWC Forecast");
                    txtCompanyCode.Focus();
                }
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
                var customerNumber = ((DropDownItem)cboCustomer.SelectedItem).Code;
                if ((_customerKey == null || _customerKey.CustomerNumber == customerNumber) && _customerKey != null)
                    return;
                bindingSourceForecast.DataSource = null;
                bindingSourceForecastParameter.DataSource = null;
                bindingSourceSalesRate.DataSource = null;
                bindingSourceTrend.DataSource = null;
                bindingSourceBonusAndDiscontinued.DataSource = null;
                bindingSourceSavedSalesRate.DataSource = null;
                bindingSourceSavedForecast.DataSource = null;
                dgvActualSales.DataSource = null;

                if (customerNumber == string.Empty)
                {
                    _customerKey = null;
                    return;
                }

                _customerKey = new CustomerKey(txtCompanyCode.Text, customerNumber);
                var customer = _company.CustomerCollection[_customerKey];
                if (customer.ForecastMethod == "SR")
                {
                    if (!tabPWCForecast.TabPages.Contains(tabPageSalesRate))
                        tabPWCForecast.TabPages.Insert(0, tabPageSalesRate);
                    rbtnSR.Checked = true;
                    lblPOSSalesEndDate.Text = "POS Week Ending:";
                    lblNumberOfPosWeeksOrSalesMonths.Text = "# Wks:";
                    nudNumberOfPosWeeksOrSalesMonths.Maximum = 4;
                    nudNumberOfPosWeeksOrSalesMonths.Value = 4;
                    customer.POSNumberOfWeeks = (SqlInt16) nudNumberOfPosWeeksOrSalesMonths.Value;
                }
                else
                {
                    if (tabPWCForecast.TabPages.Contains(tabPageSalesRate))
                        tabPWCForecast.TabPages.Remove(tabPageSalesRate);
                    rbtnRA.Checked = true;
                    lblPOSSalesEndDate.Text = "Actual Sales End:";
                    lblNumberOfPosWeeksOrSalesMonths.Text = "# Mths:";
                    nudNumberOfPosWeeksOrSalesMonths.Maximum = 9;
                    nudNumberOfPosWeeksOrSalesMonths.Value = 3;
                    customer.RollingAvageNumberOfMonths = (SqlInt16) nudNumberOfPosWeeksOrSalesMonths.Value;
                }

                GetDefaultPOSSalesEndDate();

                customer.POSSalesEndDate = dtpMonthEndDate.Value;
                txtForecastFutureFrozenMonths.Text = customer.ForecastFutureFrozenMonths.ToString();

                bindingSourceSavedSalesRate.DataSource =
                    PersistenceLayer.Utility.GetInstance().GetSavedSalesRateDateCollection(
                        _customerKey.CompanyCode.Value, _customerKey.CustomerNumber.Value, 12);
                bindingSourceSavedForecast.DataSource =
                    PersistenceLayer.Utility.GetInstance().GetSavedForecastDateCollection(
                        _customerKey.CompanyCode.Value, _customerKey.CustomerNumber.Value, 12);
                dgvActualSales.DataSource = Utility.GetInstance().GetActualSalesCrossTabCollection(customer);

                var forecastCollectionInvalidatedDelegate =
                    new Customer.ForecastCollectionInvalidatedDelegate(frmPWCForecast_ForecastCollectionInvalidated);
                customer.ForecastCollectionInvalidated -= forecastCollectionInvalidatedDelegate;
                customer.ForecastCollectionInvalidated += forecastCollectionInvalidatedDelegate;
                var forecastSalesRateCollectionInvalidatedDelegate =
                    new Customer.ForecastSalesRateCollectionInvalidatedDelegate(
                        frmPWCForecast_ForecastSalesRateCollectionInvalidated);
                customer.ForecastSalesRateCollectionInvalidated -= forecastSalesRateCollectionInvalidatedDelegate;
                customer.ForecastSalesRateCollectionInvalidated += forecastSalesRateCollectionInvalidatedDelegate;
                // bug in .net 3.5 sp1
                // event name for some reason cause System.ArgumentException on System.ComponentModel.ReflectEventDescriptor.RemoveEventHandler
                // put 'x' at end of the event name fixes the problem
                var forecastActionChangedDelegate =
                    new Customer.ForecastActionChangedDelegate(frmPWCForecast_ForecastActionChanged);
                customer.ForecastActionChangedx -= forecastActionChangedDelegate;
                customer.ForecastActionChangedx += forecastActionChangedDelegate;
                var forecastSalesRateActionChangedDelegate =
                    new Customer.ForecastSalesRateActionChangedDelegate(
                        frmPWCForecast_ForecastSalesRateActionChanged);
                customer.ForecastSalesRateActionChangedx -= forecastSalesRateActionChangedDelegate;
                customer.ForecastSalesRateActionChangedx += forecastSalesRateActionChangedDelegate;
                // force current tab to refresh
                if (tabPWCForecast.SelectedTab != null)
                    LoadTab(tabPWCForecast.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region Forecast Sales Rate Context Menu Event Handlers
        private void forecastSalesRateContextAddCommentMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;

                var row = dgvSalesRate.Rows[_mouseLocation.RowIndex];
                var customer = _company.CustomerCollection[_customerKey];
                var forecastSalesRate = (ForecastSalesRate)row.DataBoundItem;
                var frmSalesRateCommentAndOverride = new frmSalesRateCommentAndOverride(customer, forecastSalesRate, _mouseLocation.RowIndex >= customer.ForecastSalesRateCollection.Count);
                frmSalesRateCommentAndOverride.ShowDialog(this);
                row.Cells[_mouseLocation.ColumnIndex].Style.BackColor = GetSalesRateCellBackColor(forecastSalesRate);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion

        #region Forecast Context Menu Event Handlers
        private void forecastContextEditCommentMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                
                var row = dgvForecast.Rows[_mouseLocation.RowIndex];
                var columnName = dgvForecast.Columns[_mouseLocation.ColumnIndex].HeaderText;
                var customer = _company.CustomerCollection[_customerKey];
                var forecast = (BusinessObject.Forecast) row.DataBoundItem;
                var frmForecastCommentAndOverride = new frmForecastComment(customer, forecast, columnName);
                frmForecastCommentAndOverride.ShowDialog(this);
                row.Cells[_mouseLocation.ColumnIndex].Style.BackColor = GetForecastCellBackColor(forecast, columnName);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void forecastContextEditOverrideMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;

                var frmForecastManualOverride = new frmForecastManualOverride(dgvForecast.SelectedCells, dgvForecast,
                                                                              _company.CustomerCollection[_customerKey]);
                if (frmForecastManualOverride.ShowDialog(this) == DialogResult.Cancel)
                    return;
                foreach (DataGridViewCell selectedCell in dgvForecast.SelectedCells)
                {
                    var forecast = (BusinessObject.Forecast) dgvForecast.Rows[selectedCell.RowIndex].DataBoundItem;
                    var columnName = dgvForecast.Columns[selectedCell.ColumnIndex].HeaderText;
                    selectedCell.Style.BackColor = GetForecastCellBackColor(forecast, columnName);
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void forecastContextPasteMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var lines = Clipboard.GetText().Split('\n');
                if (lines.Length == 0)
                    return;

                var selectedRowIndex = dgvForecast.SelectedCells[0].RowIndex;
                for (var i = 0; i < dgvForecast.SelectedCells.Count; i++)
                    if (selectedRowIndex != dgvForecast.SelectedCells[i].RowIndex)
                    {
                        MessageBox.Show("Only single row selection is supported for range pasting.", "PWC Forecast");
                        return;
                    }

                var rowIndex = dgvForecast.SelectedCells[0].RowIndex;
                var columnIndex = dgvForecast.SelectedCells[0].ColumnIndex;
                var selectedCellsCount = dgvForecast.SelectedCells.Count;

                // sometimes the selected column indexes are offset by length - 1
                if (dgvForecast.SelectedCells.Count > 1 &&
                    dgvForecast.SelectedCells[0].ColumnIndex >
                    dgvForecast.SelectedCells[1].ColumnIndex)
                    columnIndex -= dgvForecast.SelectedCells.Count - 1;

                var line = lines[0];
                if (line.Length > 0)
                {
                    var clipboardTexts = line.Split('\t');
                    for (var i = 0; i < clipboardTexts.GetLength(0) && i < selectedCellsCount; ++i)
                    {
                        if (columnIndex + i >= dgvForecast.ColumnCount)
                            break;
                        var cell = dgvForecast[columnIndex + i, rowIndex];
                        if (cell.ReadOnly)
                            continue;
                        if (cell.Value.ToString() == clipboardTexts[i])
                            continue;
                        //TypeConverter tc =  TypeDescriptor.GetConverter(cell.ValueType);                       
                        //cell.Value = tc.ConvertFromString(cellTexts[i]);
                        dgvForecast.CurrentCell = cell;
                        if (dgvForecast.BeginEdit(false))
                            cell.Value = new SqlInt32(Convert.ToInt32(clipboardTexts[i].Replace(",", "")));
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void forecastContextCopyMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var dataObject = dgvForecast.GetClipboardContent();
                Clipboard.SetDataObject(dataObject);
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }
        #endregion
    }
}