using System;
using System.Windows.Forms;

namespace PWC.Forecast
{
    partial class frmPWCForecast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPWCForecast));
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.btnGotoItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGotoItem = new System.Windows.Forms.TextBox();
            this.lblPOSSalesEndDate = new System.Windows.Forms.Label();
            this.menuStripPWCForecast = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastFromEditedForecastFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posFromOracleFlatFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posFromACNeilsenFlatFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posFromACNeilsenXLSFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posFromACNeilsenXLSToCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualSalesFromFlatFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trendByCompanyProductGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trendByCompanyItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trendByCustomerProductGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trendByCustomerItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restorePOSPriorToImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreActualSalesPriorToImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bonusItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discontinuedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateCompanyForecastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualVsForecastComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageForecast = new System.Windows.Forms.TabPage();
            this.btnExportForecast = new System.Windows.Forms.Button();
            this.btnImportForecast = new System.Windows.Forms.Button();
            this.lblSavedForecast = new System.Windows.Forms.Label();
            this.cboSavedForecast = new System.Windows.Forms.ComboBox();
            this.bindingSourceSavedForecast = new System.Windows.Forms.BindingSource(this.components);
            this.lblForecastDescription = new System.Windows.Forms.Label();
            this.btnSaveForecast = new System.Windows.Forms.Button();
            this.btnGenerateForecast = new System.Windows.Forms.Button();
            this.dgvForecast = new System.Windows.Forms.DataGridView();
            this.ItemNumberForecast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForecastMethodForecast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyTypeDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceForecast = new System.Windows.Forms.BindingSource(this.components);
            this.forecastContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.forecastContextCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastContextPasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastContextEditCommentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastContextEditOverrideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastSalesRateContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.forecastSalesRateContextAddCommentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageParameter = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMovePLPercentageRightByYear = new System.Windows.Forms.Button();
            this.btnMovePLPercentageLeftByYear = new System.Windows.Forms.Button();
            this.lblMovePLPercentage = new System.Windows.Forms.Label();
            this.btnMovePLPercentageRightByMonth = new System.Windows.Forms.Button();
            this.btnMovePLPercentageLeftByMonth = new System.Windows.Forms.Button();
            this.dgvParameter = new System.Windows.Forms.DataGridView();
            this.ItemNumberParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCountExisting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCountNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialQtyPerNewStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectedSalesRateExisting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectedSalesRateNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PipelineStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PipelineEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OneTimeItemFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PlPctPY01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctPY12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctCY12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlPctNY12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyTypeDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceForecastParameter = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageTrend = new System.Windows.Forms.TabPage();
            this.rbtnTrendByCustomerProductGroup = new System.Windows.Forms.RadioButton();
            this.rbtnTrendByCompanyProductGroup = new System.Windows.Forms.RadioButton();
            this.rbtnTrendByCustomerItem = new System.Windows.Forms.RadioButton();
            this.rbtnTrendByCompanyItem = new System.Windows.Forms.RadioButton();
            this.dgvTrend = new System.Windows.Forms.DataGridView();
            this.ItemNumberTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ForecastMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorMonth12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceTrend = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageSalesRate = new System.Windows.Forms.TabPage();
            this.lblSavedSalesRate = new System.Windows.Forms.Label();
            this.cboSavedSalesRate = new System.Windows.Forms.ComboBox();
            this.bindingSourceSavedSalesRate = new System.Windows.Forms.BindingSource(this.components);
            this.btnSaveSalesRate = new System.Windows.Forms.Button();
            this.lblSalesRateDescription = new System.Windows.Forms.Label();
            this.dgvSalesRate = new System.Windows.Forms.DataGridView();
            this.ItemNumberSalesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrendFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSWeek1Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSWeek2Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSWeek3Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSWeek4Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCountExistingSalesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCountNewSalesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCountTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRatePrevious = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRateDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRateDifferencePercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceSalesRate = new System.Windows.Forms.BindingSource(this.components);
            this.btnApplySalesRate = new System.Windows.Forms.Button();
            this.btnGenerateSalesRate = new System.Windows.Forms.Button();
            this.tabPWCForecast = new System.Windows.Forms.TabControl();
            this.tabPageActualSales = new System.Windows.Forms.TabPage();
            this.dgvActualSales = new System.Windows.Forms.DataGridView();
            this.ItemNumberActualSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyTypeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageBonusAndDiscontinued = new System.Windows.Forms.TabPage();
            this.rbtnBonusAndDiscontinuedByCustomer = new System.Windows.Forms.RadioButton();
            this.rbtnBonusAndDiscontinuedByCompany = new System.Windows.Forms.RadioButton();
            this.dgvBonusAndDiscontinued = new System.Windows.Forms.DataGridView();
            this.ItemNumberBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscontinuedEffectiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY01Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY02Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY03Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY04Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY05Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY06Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY07Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY08Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY09Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY10Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY11Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY12Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY01Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY02Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY03Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY04Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY05Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY06Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY07Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY08Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY09Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY10Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY11Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CY12Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY01Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY02Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY03Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY04Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY05Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY06Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY07Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY08Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY09Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY10Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY11Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NY12Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyTypeDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectKeyDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceBonusAndDiscontinued = new System.Windows.Forms.BindingSource(this.components);
            this.dtpMonthEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblNumberOfPosWeeksOrSalesMonths = new System.Windows.Forms.Label();
            this.nudNumberOfPosWeeksOrSalesMonths = new System.Windows.Forms.NumericUpDown();
            this.rbtnSR = new System.Windows.Forms.RadioButton();
            this.rbtnRA = new System.Windows.Forms.RadioButton();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.chkShowPriorYear = new System.Windows.Forms.CheckBox();
            this.chkUseClipboardDataOnNewRow = new System.Windows.Forms.CheckBox();
            this.lblForecastFutureFrozenMonths = new System.Windows.Forms.Label();
            this.txtForecastFutureFrozenMonths = new System.Windows.Forms.TextBox();
            this.menuStripPWCForecast.SuspendLayout();
            this.tabPageForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForecast)).BeginInit();
            this.forecastContextMenuStrip.SuspendLayout();
            this.forecastSalesRateContextMenuStrip.SuspendLayout();
            this.tabPageParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForecastParameter)).BeginInit();
            this.tabPageTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTrend)).BeginInit();
            this.tabPageSalesRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedSalesRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSalesRate)).BeginInit();
            this.tabPWCForecast.SuspendLayout();
            this.tabPageActualSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActualSales)).BeginInit();
            this.tabPageBonusAndDiscontinued.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusAndDiscontinued)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBonusAndDiscontinued)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPosWeeksOrSalesMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(17, 36);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(102, 33);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(187, 20);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TabStop = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(310, 36);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(71, 33);
            this.txtCompanyCode.Mask = "000";
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.PromptChar = ' ';
            this.txtCompanyCode.Size = new System.Drawing.Size(25, 20);
            this.txtCompanyCode.TabIndex = 2;
            this.txtCompanyCode.GotFocus += new System.EventHandler(this.txtCompanyCode_GotFocus);
            this.txtCompanyCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyCode_Validating);
            // 
            // btnGotoItem
            // 
            this.btnGotoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoItem.Location = new System.Drawing.Point(938, 29);
            this.btnGotoItem.Name = "btnGotoItem";
            this.btnGotoItem.Size = new System.Drawing.Size(62, 23);
            this.btnGotoItem.TabIndex = 102;
            this.btnGotoItem.Text = "Go to";
            this.btnGotoItem.UseVisualStyleBackColor = true;
            this.btnGotoItem.Click += new System.EventHandler(this.btnGotoItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(822, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Item #:";
            // 
            // txtGotoItem
            // 
            this.txtGotoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGotoItem.Location = new System.Drawing.Point(863, 31);
            this.txtGotoItem.Name = "txtGotoItem";
            this.txtGotoItem.Size = new System.Drawing.Size(69, 20);
            this.txtGotoItem.TabIndex = 101;
            this.txtGotoItem.GotFocus += new System.EventHandler(this.txtGotoItem_GotFocus);
            this.txtGotoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUpperCase_KeyPress);
            this.txtGotoItem.Validating += new System.ComponentModel.CancelEventHandler(this.txtGotoItem_Validating);
            // 
            // lblPOSSalesEndDate
            // 
            this.lblPOSSalesEndDate.AutoSize = true;
            this.lblPOSSalesEndDate.Location = new System.Drawing.Point(308, 64);
            this.lblPOSSalesEndDate.Name = "lblPOSSalesEndDate";
            this.lblPOSSalesEndDate.Size = new System.Drawing.Size(100, 13);
            this.lblPOSSalesEndDate.TabIndex = 9;
            this.lblPOSSalesEndDate.Text = "POS Week Ending:";
            // 
            // menuStripPWCForecast
            // 
            this.menuStripPWCForecast.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.batchToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStripPWCForecast.Location = new System.Drawing.Point(0, 0);
            this.menuStripPWCForecast.Name = "menuStripPWCForecast";
            this.menuStripPWCForecast.Size = new System.Drawing.Size(1012, 24);
            this.menuStripPWCForecast.TabIndex = 103;
            this.menuStripPWCForecast.Text = "menuStrip1";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forecastFromEditedForecastFileToolStripMenuItem,
            this.posFromOracleFlatFileToolStripMenuItem,
            this.posFromACNeilsenFlatFileToolStripMenuItem,
            this.posFromACNeilsenXLSFileToolStripMenuItem,
            this.posFromACNeilsenXLSToCSVFileToolStripMenuItem,
            this.actualSalesFromFlatFileToolStripMenuItem,
            this.trendByCompanyProductGroupToolStripMenuItem,
            this.trendByCompanyItemToolStripMenuItem,
            this.trendByCustomerProductGroupToolStripMenuItem,
            this.trendByCustomerItemToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // forecastFromEditedForecastFileToolStripMenuItem
            // 
            this.forecastFromEditedForecastFileToolStripMenuItem.Name = "forecastFromEditedForecastFileToolStripMenuItem";
            this.forecastFromEditedForecastFileToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.forecastFromEditedForecastFileToolStripMenuItem.Text = "Forecast from edited forecast file";
            this.forecastFromEditedForecastFileToolStripMenuItem.Click += new System.EventHandler(this.forecastFromEditedForecastFileToolStripMenuItem_Click);
            // 
            // posFromOracleFlatFileToolStripMenuItem
            // 
            this.posFromOracleFlatFileToolStripMenuItem.Name = "posFromOracleFlatFileToolStripMenuItem";
            this.posFromOracleFlatFileToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.posFromOracleFlatFileToolStripMenuItem.Text = "POS from Oracle flat file";
            this.posFromOracleFlatFileToolStripMenuItem.Click += new System.EventHandler(this.posFromOracleFlatFileToolStripMenuItem_Click);
            // 
            // posFromACNeilsenFlatFileToolStripMenuItem
            // 
            this.posFromACNeilsenFlatFileToolStripMenuItem.Name = "posFromACNeilsenFlatFileToolStripMenuItem";
            this.posFromACNeilsenFlatFileToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.posFromACNeilsenFlatFileToolStripMenuItem.Text = "POS from AC Neilsen flat file";
            this.posFromACNeilsenFlatFileToolStripMenuItem.Click += new System.EventHandler(this.posFromACNeilsenFlatFileToolStripMenuItem_Click);
            // 
            // posFromACNeilsenXLSFileToolStripMenuItem
            // 
            this.posFromACNeilsenXLSFileToolStripMenuItem.Name = "posFromACNeilsenXLSFileToolStripMenuItem";
            this.posFromACNeilsenXLSFileToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.posFromACNeilsenXLSFileToolStripMenuItem.Text = "POS from AC Neilsen XLS file";
            this.posFromACNeilsenXLSFileToolStripMenuItem.Click += new System.EventHandler(this.posFromACNeilsenXLSFileToolStripMenuItem_Click);
            // 
            // posFromACNeilsenXLSToCSVFileToolStripMenuItem
            // 
            this.posFromACNeilsenXLSToCSVFileToolStripMenuItem.Name = "posFromACNeilsenXLSToCSVFileToolStripMenuItem";
            this.posFromACNeilsenXLSToCSVFileToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.posFromACNeilsenXLSToCSVFileToolStripMenuItem.Text = "POS from AC Neilsen CSV file";
            this.posFromACNeilsenXLSToCSVFileToolStripMenuItem.Click += new System.EventHandler(this.posFromACNeilsenXLSToCSVFileToolStripMenuItem_Click);
            // 
            // actualSalesFromFlatFileToolStripMenuItem
            // 
            this.actualSalesFromFlatFileToolStripMenuItem.Name = "actualSalesFromFlatFileToolStripMenuItem";
            this.actualSalesFromFlatFileToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.actualSalesFromFlatFileToolStripMenuItem.Text = "Actual Sales from flat file";
            this.actualSalesFromFlatFileToolStripMenuItem.Click += new System.EventHandler(this.actualSalesFromFlatFileToolStripMenuItem_Click);
            // 
            // trendByCompanyProductGroupToolStripMenuItem
            // 
            this.trendByCompanyProductGroupToolStripMenuItem.Name = "trendByCompanyProductGroupToolStripMenuItem";
            this.trendByCompanyProductGroupToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.trendByCompanyProductGroupToolStripMenuItem.Text = "Trend by Company Product Group";
            this.trendByCompanyProductGroupToolStripMenuItem.Click += new System.EventHandler(this.trendByCompanyProductGroupToolStripMenuItem_Click);
            // 
            // trendByCompanyItemToolStripMenuItem
            // 
            this.trendByCompanyItemToolStripMenuItem.Name = "trendByCompanyItemToolStripMenuItem";
            this.trendByCompanyItemToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.trendByCompanyItemToolStripMenuItem.Text = "Trend by Company Item";
            this.trendByCompanyItemToolStripMenuItem.Click += new System.EventHandler(this.trendByCompanyItemToolStripMenuItem_Click);
            // 
            // trendByCustomerProductGroupToolStripMenuItem
            // 
            this.trendByCustomerProductGroupToolStripMenuItem.Name = "trendByCustomerProductGroupToolStripMenuItem";
            this.trendByCustomerProductGroupToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.trendByCustomerProductGroupToolStripMenuItem.Text = "Trend by Customer Product Group";
            this.trendByCustomerProductGroupToolStripMenuItem.Click += new System.EventHandler(this.trendByCustomerProductGroupToolStripMenuItem_Click);
            // 
            // trendByCustomerItemToolStripMenuItem
            // 
            this.trendByCustomerItemToolStripMenuItem.Name = "trendByCustomerItemToolStripMenuItem";
            this.trendByCustomerItemToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.trendByCustomerItemToolStripMenuItem.Text = "Trend by Customer Item";
            this.trendByCustomerItemToolStripMenuItem.Click += new System.EventHandler(this.trendByCustomerItemToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restorePOSPriorToImportToolStripMenuItem,
            this.restoreActualSalesPriorToImportToolStripMenuItem,
            this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem,
            this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem,
            this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem,
            this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem});
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // restorePOSPriorToImportToolStripMenuItem
            // 
            this.restorePOSPriorToImportToolStripMenuItem.Name = "restorePOSPriorToImportToolStripMenuItem";
            this.restorePOSPriorToImportToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
            this.restorePOSPriorToImportToolStripMenuItem.Text = "POS prior to import";
            this.restorePOSPriorToImportToolStripMenuItem.Click += new System.EventHandler(this.restorePOSPriorToImportToolStripMenuItem_Click);
            // 
            // restoreActualSalesPriorToImportToolStripMenuItem
            // 
            this.restoreActualSalesPriorToImportToolStripMenuItem.Name = "restoreActualSalesPriorToImportToolStripMenuItem";
            this.restoreActualSalesPriorToImportToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
            this.restoreActualSalesPriorToImportToolStripMenuItem.Text = "Actual Sales prior to import";
            this.restoreActualSalesPriorToImportToolStripMenuItem.Click += new System.EventHandler(this.restoreActualSalesPriorToImportToolStripMenuItem_Click);
            // 
            // restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem
            // 
            this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem.Name = "restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem";
            this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
            this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem.Text = "Trend by Company Product Group prior to import";
            this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem.Click += new System.EventHandler(this.restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem_Click);
            // 
            // restoreTrendByCompanyItemPriorToImportToolStripMenuItem
            // 
            this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem.Name = "restoreTrendByCompanyItemPriorToImportToolStripMenuItem";
            this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
            this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem.Text = "Trend by Company Item prior to import";
            this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem.Click += new System.EventHandler(this.restoreTrendByCompanyItemPriorToImportToolStripMenuItem_Click);
            // 
            // restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem
            // 
            this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem.Name = "restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem";
            this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
            this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem.Text = "Trend by Customer Product Group prior to import";
            this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem.Click += new System.EventHandler(this.restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem_Click);
            // 
            // restoreTrendByCustomerItemPriorToImportToolStripMenuItem
            // 
            this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem.Name = "restoreTrendByCustomerItemPriorToImportToolStripMenuItem";
            this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
            this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem.Text = "Trend by Customer Item prior to import";
            this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem.Click += new System.EventHandler(this.restoreTrendByCustomerItemPriorToImportToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesRateToolStripMenuItem,
            this.forecastToolStripMenuItem,
            this.bonusItemsToolStripMenuItem,
            this.discontinuedItemsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // salesRateToolStripMenuItem
            // 
            this.salesRateToolStripMenuItem.Name = "salesRateToolStripMenuItem";
            this.salesRateToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.salesRateToolStripMenuItem.Text = "Sales Rate";
            this.salesRateToolStripMenuItem.Click += new System.EventHandler(this.salesRateToolStripMenuItem_Click);
            // 
            // forecastToolStripMenuItem
            // 
            this.forecastToolStripMenuItem.Name = "forecastToolStripMenuItem";
            this.forecastToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.forecastToolStripMenuItem.Text = "Forecast";
            this.forecastToolStripMenuItem.Click += new System.EventHandler(this.forecastToolStripMenuItem_Click);
            // 
            // bonusItemsToolStripMenuItem
            // 
            this.bonusItemsToolStripMenuItem.Name = "bonusItemsToolStripMenuItem";
            this.bonusItemsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.bonusItemsToolStripMenuItem.Text = "Bonus Items";
            this.bonusItemsToolStripMenuItem.Click += new System.EventHandler(this.bonusItemsToolStripMenuItem_Click);
            // 
            // discontinuedItemsToolStripMenuItem
            // 
            this.discontinuedItemsToolStripMenuItem.Name = "discontinuedItemsToolStripMenuItem";
            this.discontinuedItemsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.discontinuedItemsToolStripMenuItem.Text = "Discontinued Items";
            this.discontinuedItemsToolStripMenuItem.Click += new System.EventHandler(this.discontinuedItemsToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.brandToolStripMenuItem,
            this.productCategoryToolStripMenuItem,
            this.productGroupToolStripMenuItem,
            this.itemToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // brandToolStripMenuItem
            // 
            this.brandToolStripMenuItem.Name = "brandToolStripMenuItem";
            this.brandToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.brandToolStripMenuItem.Text = "Brand";
            this.brandToolStripMenuItem.Click += new System.EventHandler(this.brandToolStripMenuItem_Click);
            // 
            // productCategoryToolStripMenuItem
            // 
            this.productCategoryToolStripMenuItem.Name = "productCategoryToolStripMenuItem";
            this.productCategoryToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.productCategoryToolStripMenuItem.Text = "Product Category";
            this.productCategoryToolStripMenuItem.Click += new System.EventHandler(this.productCategoryToolStripMenuItem_Click);
            // 
            // productGroupToolStripMenuItem
            // 
            this.productGroupToolStripMenuItem.Name = "productGroupToolStripMenuItem";
            this.productGroupToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.productGroupToolStripMenuItem.Text = "Product Group";
            this.productGroupToolStripMenuItem.Click += new System.EventHandler(this.productGroupToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.itemToolStripMenuItem.Text = "Item";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // batchToolStripMenuItem
            // 
            this.batchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateCompanyForecastToolStripMenuItem});
            this.batchToolStripMenuItem.Name = "batchToolStripMenuItem";
            this.batchToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.batchToolStripMenuItem.Text = "Batch";
            // 
            // generateCompanyForecastToolStripMenuItem
            // 
            this.generateCompanyForecastToolStripMenuItem.Name = "generateCompanyForecastToolStripMenuItem";
            this.generateCompanyForecastToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.generateCompanyForecastToolStripMenuItem.Text = "Generate Company Forecast";
            this.generateCompanyForecastToolStripMenuItem.Click += new System.EventHandler(this.generateCompanyForecastToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualVsForecastComparisonToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // actualVsForecastComparisonToolStripMenuItem
            // 
            this.actualVsForecastComparisonToolStripMenuItem.Name = "actualVsForecastComparisonToolStripMenuItem";
            this.actualVsForecastComparisonToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.actualVsForecastComparisonToolStripMenuItem.Text = "Actual vs Forecast Comparison";
            this.actualVsForecastComparisonToolStripMenuItem.Click += new System.EventHandler(this.actualVsForecastComparisonToolStripMenuItem_Click);
            // 
            // tabPageForecast
            // 
            this.tabPageForecast.Controls.Add(this.btnExportForecast);
            this.tabPageForecast.Controls.Add(this.btnImportForecast);
            this.tabPageForecast.Controls.Add(this.lblSavedForecast);
            this.tabPageForecast.Controls.Add(this.cboSavedForecast);
            this.tabPageForecast.Controls.Add(this.lblForecastDescription);
            this.tabPageForecast.Controls.Add(this.btnSaveForecast);
            this.tabPageForecast.Controls.Add(this.btnGenerateForecast);
            this.tabPageForecast.Controls.Add(this.dgvForecast);
            this.tabPageForecast.Location = new System.Drawing.Point(4, 22);
            this.tabPageForecast.Name = "tabPageForecast";
            this.tabPageForecast.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForecast.Size = new System.Drawing.Size(977, 405);
            this.tabPageForecast.TabIndex = 2;
            this.tabPageForecast.Text = "Forecast";
            this.tabPageForecast.UseVisualStyleBackColor = true;
            // 
            // btnExportForecast
            // 
            this.btnExportForecast.Location = new System.Drawing.Point(221, 10);
            this.btnExportForecast.Name = "btnExportForecast";
            this.btnExportForecast.Size = new System.Drawing.Size(62, 23);
            this.btnExportForecast.TabIndex = 34;
            this.btnExportForecast.Text = "Export";
            this.btnExportForecast.UseVisualStyleBackColor = true;
            this.btnExportForecast.Click += new System.EventHandler(this.btnExportForecast_Click);
            // 
            // btnImportForecast
            // 
            this.btnImportForecast.Location = new System.Drawing.Point(153, 9);
            this.btnImportForecast.Name = "btnImportForecast";
            this.btnImportForecast.Size = new System.Drawing.Size(62, 23);
            this.btnImportForecast.TabIndex = 33;
            this.btnImportForecast.Text = "Import";
            this.btnImportForecast.UseVisualStyleBackColor = true;
            this.btnImportForecast.Click += new System.EventHandler(this.btnImportForecast_Click);
            // 
            // lblSavedForecast
            // 
            this.lblSavedForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSavedForecast.AutoSize = true;
            this.lblSavedForecast.Location = new System.Drawing.Point(768, 13);
            this.lblSavedForecast.Name = "lblSavedForecast";
            this.lblSavedForecast.Size = new System.Drawing.Size(90, 13);
            this.lblSavedForecast.TabIndex = 35;
            this.lblSavedForecast.Text = "Saved Forecasts:";
            // 
            // cboSavedForecast
            // 
            this.cboSavedForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedForecast.DataSource = this.bindingSourceSavedForecast;
            this.cboSavedForecast.DisplayMember = "Description";
            this.cboSavedForecast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavedForecast.FormattingEnabled = true;
            this.cboSavedForecast.Location = new System.Drawing.Point(860, 10);
            this.cboSavedForecast.Name = "cboSavedForecast";
            this.cboSavedForecast.Size = new System.Drawing.Size(107, 21);
            this.cboSavedForecast.TabIndex = 36;
            this.cboSavedForecast.ValueMember = "POSSalesEndDate";
            this.cboSavedForecast.SelectedIndexChanged += new System.EventHandler(this.cboSavedForecast_SelectedIndexChanged);
            // 
            // bindingSourceSavedForecast
            // 
            this.bindingSourceSavedForecast.AllowNew = false;
            // 
            // lblForecastDescription
            // 
            this.lblForecastDescription.AutoSize = true;
            this.lblForecastDescription.Location = new System.Drawing.Point(300, 13);
            this.lblForecastDescription.Name = "lblForecastDescription";
            this.lblForecastDescription.Size = new System.Drawing.Size(0, 13);
            this.lblForecastDescription.TabIndex = 32;
            // 
            // btnSaveForecast
            // 
            this.btnSaveForecast.Enabled = false;
            this.btnSaveForecast.Location = new System.Drawing.Point(76, 8);
            this.btnSaveForecast.Name = "btnSaveForecast";
            this.btnSaveForecast.Size = new System.Drawing.Size(62, 23);
            this.btnSaveForecast.TabIndex = 32;
            this.btnSaveForecast.Text = "Save";
            this.btnSaveForecast.UseVisualStyleBackColor = true;
            this.btnSaveForecast.Click += new System.EventHandler(this.btnSaveForecast_Click);
            // 
            // btnGenerateForecast
            // 
            this.btnGenerateForecast.Location = new System.Drawing.Point(8, 8);
            this.btnGenerateForecast.Name = "btnGenerateForecast";
            this.btnGenerateForecast.Size = new System.Drawing.Size(62, 23);
            this.btnGenerateForecast.TabIndex = 31;
            this.btnGenerateForecast.Text = "Generate";
            this.btnGenerateForecast.UseVisualStyleBackColor = true;
            this.btnGenerateForecast.Click += new System.EventHandler(this.btnGenerateForecast_Click);
            // 
            // dgvForecast
            // 
            this.dgvForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvForecast.AutoGenerateColumns = false;
            this.dgvForecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForecast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumberForecast,
            this.ForecastMethodForecast,
            this.PY01,
            this.PY02,
            this.PY03,
            this.PY04,
            this.PY05,
            this.PY06,
            this.PY07,
            this.PY08,
            this.PY09,
            this.PY10,
            this.PY11,
            this.PY12,
            this.CY01,
            this.CY02,
            this.CY03,
            this.CY04,
            this.CY05,
            this.CY06,
            this.CY07,
            this.CY08,
            this.CY09,
            this.CY10,
            this.CY11,
            this.CY12,
            this.NY01,
            this.NY02,
            this.NY03,
            this.NY04,
            this.NY05,
            this.NY06,
            this.NY07,
            this.NY08,
            this.NY09,
            this.NY10,
            this.NY11,
            this.NY12,
            this.objectKeyTypeDataGridViewTextBoxColumn5,
            this.objectKeyDataGridViewTextBoxColumn5,
            this.parentDataGridViewTextBoxColumn5});
            this.dgvForecast.DataSource = this.bindingSourceForecast;
            this.dgvForecast.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvForecast.Location = new System.Drawing.Point(3, 38);
            this.dgvForecast.Name = "dgvForecast";
            this.dgvForecast.Size = new System.Drawing.Size(968, 364);
            this.dgvForecast.TabIndex = 37;
            this.dgvForecast.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvForecast_CellBeginEdit);
            this.dgvForecast.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForecast_CellEndEdit);
            this.dgvForecast.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvForecast_CellFormatting);
            this.dgvForecast.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForecast_CellMouseEnter);
            this.dgvForecast.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvForecast_CellParsing);
            this.dgvForecast.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvForecast_CellValidating);
            this.dgvForecast.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForecast_CellValueChanged);
            this.dgvForecast.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvForecast_ColumnHeaderMouseClick);
            this.dgvForecast.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvForecast_DataError);
            this.dgvForecast.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvForecast_EditingControlShowing);
            this.dgvForecast.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvForecast_RowValidating);
            this.dgvForecast.SelectionChanged += new System.EventHandler(this.dgvForecast_SelectionChanged);
            this.dgvForecast.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvForecast_UserDeletingRow);
            // 
            // ItemNumberForecast
            // 
            this.ItemNumberForecast.DataPropertyName = "ItemNumber";
            this.ItemNumberForecast.Frozen = true;
            this.ItemNumberForecast.HeaderText = "Item #";
            this.ItemNumberForecast.MaxInputLength = 15;
            this.ItemNumberForecast.Name = "ItemNumberForecast";
            this.ItemNumberForecast.Width = 75;
            // 
            // ForecastMethodForecast
            // 
            this.ForecastMethodForecast.DataPropertyName = "ForecastMethod";
            this.ForecastMethodForecast.Frozen = true;
            this.ForecastMethodForecast.HeaderText = "Method";
            this.ForecastMethodForecast.MaxInputLength = 2;
            this.ForecastMethodForecast.Name = "ForecastMethodForecast";
            this.ForecastMethodForecast.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ForecastMethodForecast.Width = 50;
            // 
            // PY01
            // 
            this.PY01.DataPropertyName = "PY01";
            this.PY01.HeaderText = "PY01";
            this.PY01.MaxInputLength = 6;
            this.PY01.Name = "PY01";
            this.PY01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY01.Width = 45;
            // 
            // PY02
            // 
            this.PY02.DataPropertyName = "PY02";
            this.PY02.HeaderText = "PY02";
            this.PY02.MaxInputLength = 6;
            this.PY02.Name = "PY02";
            this.PY02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY02.Width = 45;
            // 
            // PY03
            // 
            this.PY03.DataPropertyName = "PY03";
            this.PY03.HeaderText = "PY03";
            this.PY03.MaxInputLength = 6;
            this.PY03.Name = "PY03";
            this.PY03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY03.Width = 45;
            // 
            // PY04
            // 
            this.PY04.DataPropertyName = "PY04";
            this.PY04.HeaderText = "PY04";
            this.PY04.MaxInputLength = 6;
            this.PY04.Name = "PY04";
            this.PY04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY04.Width = 45;
            // 
            // PY05
            // 
            this.PY05.DataPropertyName = "PY05";
            this.PY05.HeaderText = "PY05";
            this.PY05.MaxInputLength = 6;
            this.PY05.Name = "PY05";
            this.PY05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY05.Width = 45;
            // 
            // PY06
            // 
            this.PY06.DataPropertyName = "PY06";
            this.PY06.HeaderText = "PY06";
            this.PY06.MaxInputLength = 6;
            this.PY06.Name = "PY06";
            this.PY06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY06.Width = 45;
            // 
            // PY07
            // 
            this.PY07.DataPropertyName = "PY07";
            this.PY07.HeaderText = "PY07";
            this.PY07.MaxInputLength = 6;
            this.PY07.Name = "PY07";
            this.PY07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY07.Width = 45;
            // 
            // PY08
            // 
            this.PY08.DataPropertyName = "PY08";
            this.PY08.HeaderText = "PY08";
            this.PY08.MaxInputLength = 6;
            this.PY08.Name = "PY08";
            this.PY08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY08.Width = 45;
            // 
            // PY09
            // 
            this.PY09.DataPropertyName = "PY09";
            this.PY09.HeaderText = "PY09";
            this.PY09.MaxInputLength = 6;
            this.PY09.Name = "PY09";
            this.PY09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY09.Width = 45;
            // 
            // PY10
            // 
            this.PY10.DataPropertyName = "PY10";
            this.PY10.HeaderText = "PY10";
            this.PY10.MaxInputLength = 6;
            this.PY10.Name = "PY10";
            this.PY10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY10.Width = 45;
            // 
            // PY11
            // 
            this.PY11.DataPropertyName = "PY11";
            this.PY11.HeaderText = "PY11";
            this.PY11.MaxInputLength = 6;
            this.PY11.Name = "PY11";
            this.PY11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY11.Width = 45;
            // 
            // PY12
            // 
            this.PY12.DataPropertyName = "PY12";
            this.PY12.HeaderText = "PY12";
            this.PY12.MaxInputLength = 6;
            this.PY12.Name = "PY12";
            this.PY12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY12.Width = 45;
            // 
            // CY01
            // 
            this.CY01.DataPropertyName = "CY01";
            this.CY01.HeaderText = "CY01";
            this.CY01.MaxInputLength = 6;
            this.CY01.Name = "CY01";
            this.CY01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY01.Width = 45;
            // 
            // CY02
            // 
            this.CY02.DataPropertyName = "CY02";
            this.CY02.HeaderText = "CY02";
            this.CY02.MaxInputLength = 6;
            this.CY02.Name = "CY02";
            this.CY02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY02.Width = 45;
            // 
            // CY03
            // 
            this.CY03.DataPropertyName = "CY03";
            this.CY03.HeaderText = "CY03";
            this.CY03.MaxInputLength = 6;
            this.CY03.Name = "CY03";
            this.CY03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY03.Width = 45;
            // 
            // CY04
            // 
            this.CY04.DataPropertyName = "CY04";
            this.CY04.HeaderText = "CY04";
            this.CY04.MaxInputLength = 6;
            this.CY04.Name = "CY04";
            this.CY04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY04.Width = 45;
            // 
            // CY05
            // 
            this.CY05.DataPropertyName = "CY05";
            this.CY05.HeaderText = "CY05";
            this.CY05.MaxInputLength = 6;
            this.CY05.Name = "CY05";
            this.CY05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY05.Width = 45;
            // 
            // CY06
            // 
            this.CY06.DataPropertyName = "CY06";
            this.CY06.HeaderText = "CY06";
            this.CY06.MaxInputLength = 6;
            this.CY06.Name = "CY06";
            this.CY06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY06.Width = 45;
            // 
            // CY07
            // 
            this.CY07.DataPropertyName = "CY07";
            this.CY07.HeaderText = "CY07";
            this.CY07.MaxInputLength = 6;
            this.CY07.Name = "CY07";
            this.CY07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY07.Width = 45;
            // 
            // CY08
            // 
            this.CY08.DataPropertyName = "CY08";
            this.CY08.HeaderText = "CY08";
            this.CY08.MaxInputLength = 6;
            this.CY08.Name = "CY08";
            this.CY08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY08.Width = 45;
            // 
            // CY09
            // 
            this.CY09.DataPropertyName = "CY09";
            this.CY09.HeaderText = "CY09";
            this.CY09.MaxInputLength = 6;
            this.CY09.Name = "CY09";
            this.CY09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY09.Width = 45;
            // 
            // CY10
            // 
            this.CY10.DataPropertyName = "CY10";
            this.CY10.HeaderText = "CY10";
            this.CY10.MaxInputLength = 6;
            this.CY10.Name = "CY10";
            this.CY10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY10.Width = 45;
            // 
            // CY11
            // 
            this.CY11.DataPropertyName = "CY11";
            this.CY11.HeaderText = "CY11";
            this.CY11.MaxInputLength = 6;
            this.CY11.Name = "CY11";
            this.CY11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY11.Width = 45;
            // 
            // CY12
            // 
            this.CY12.DataPropertyName = "CY12";
            this.CY12.HeaderText = "CY12";
            this.CY12.MaxInputLength = 6;
            this.CY12.Name = "CY12";
            this.CY12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY12.Width = 45;
            // 
            // NY01
            // 
            this.NY01.DataPropertyName = "NY01";
            this.NY01.HeaderText = "NY01";
            this.NY01.MaxInputLength = 6;
            this.NY01.Name = "NY01";
            this.NY01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY01.Width = 45;
            // 
            // NY02
            // 
            this.NY02.DataPropertyName = "NY02";
            this.NY02.HeaderText = "NY02";
            this.NY02.MaxInputLength = 6;
            this.NY02.Name = "NY02";
            this.NY02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY02.Width = 45;
            // 
            // NY03
            // 
            this.NY03.DataPropertyName = "NY03";
            this.NY03.HeaderText = "NY03";
            this.NY03.MaxInputLength = 6;
            this.NY03.Name = "NY03";
            this.NY03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY03.Width = 45;
            // 
            // NY04
            // 
            this.NY04.DataPropertyName = "NY04";
            this.NY04.HeaderText = "NY04";
            this.NY04.MaxInputLength = 6;
            this.NY04.Name = "NY04";
            this.NY04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY04.Width = 45;
            // 
            // NY05
            // 
            this.NY05.DataPropertyName = "NY05";
            this.NY05.HeaderText = "NY05";
            this.NY05.MaxInputLength = 6;
            this.NY05.Name = "NY05";
            this.NY05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY05.Width = 45;
            // 
            // NY06
            // 
            this.NY06.DataPropertyName = "NY06";
            this.NY06.HeaderText = "NY06";
            this.NY06.MaxInputLength = 6;
            this.NY06.Name = "NY06";
            this.NY06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY06.Width = 45;
            // 
            // NY07
            // 
            this.NY07.DataPropertyName = "NY07";
            this.NY07.HeaderText = "NY07";
            this.NY07.MaxInputLength = 6;
            this.NY07.Name = "NY07";
            this.NY07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY07.Width = 45;
            // 
            // NY08
            // 
            this.NY08.DataPropertyName = "NY08";
            this.NY08.HeaderText = "NY08";
            this.NY08.MaxInputLength = 6;
            this.NY08.Name = "NY08";
            this.NY08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY08.Width = 45;
            // 
            // NY09
            // 
            this.NY09.DataPropertyName = "NY09";
            this.NY09.HeaderText = "NY09";
            this.NY09.MaxInputLength = 6;
            this.NY09.Name = "NY09";
            this.NY09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY09.Width = 45;
            // 
            // NY10
            // 
            this.NY10.DataPropertyName = "NY10";
            this.NY10.HeaderText = "NY10";
            this.NY10.MaxInputLength = 6;
            this.NY10.Name = "NY10";
            this.NY10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY10.Width = 45;
            // 
            // NY11
            // 
            this.NY11.DataPropertyName = "NY11";
            this.NY11.HeaderText = "NY11";
            this.NY11.MaxInputLength = 6;
            this.NY11.Name = "NY11";
            this.NY11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY11.Width = 45;
            // 
            // NY12
            // 
            this.NY12.DataPropertyName = "NY12";
            this.NY12.HeaderText = "NY12";
            this.NY12.MaxInputLength = 6;
            this.NY12.Name = "NY12";
            this.NY12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY12.Width = 45;
            // 
            // objectKeyTypeDataGridViewTextBoxColumn5
            // 
            this.objectKeyTypeDataGridViewTextBoxColumn5.DataPropertyName = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn5.HeaderText = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn5.Name = "objectKeyTypeDataGridViewTextBoxColumn5";
            this.objectKeyTypeDataGridViewTextBoxColumn5.ReadOnly = true;
            this.objectKeyTypeDataGridViewTextBoxColumn5.Visible = false;
            // 
            // objectKeyDataGridViewTextBoxColumn5
            // 
            this.objectKeyDataGridViewTextBoxColumn5.DataPropertyName = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn5.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn5.Name = "objectKeyDataGridViewTextBoxColumn5";
            this.objectKeyDataGridViewTextBoxColumn5.Visible = false;
            // 
            // parentDataGridViewTextBoxColumn5
            // 
            this.parentDataGridViewTextBoxColumn5.DataPropertyName = "Parent";
            this.parentDataGridViewTextBoxColumn5.HeaderText = "Parent";
            this.parentDataGridViewTextBoxColumn5.Name = "parentDataGridViewTextBoxColumn5";
            this.parentDataGridViewTextBoxColumn5.Visible = false;
            // 
            // bindingSourceForecast
            // 
            this.bindingSourceForecast.AllowNew = true;
            this.bindingSourceForecast.DataSource = typeof(PWC.BusinessObject.Forecast.WithCustomerParentParameteredCollection);
            // 
            // forecastContextMenuStrip
            // 
            this.forecastContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forecastContextCopyMenuItem,
            this.forecastContextPasteMenuItem,
            this.forecastContextEditCommentMenuItem,
            this.forecastContextEditOverrideMenuItem});
            this.forecastContextMenuStrip.Name = "forecastContextMenuStrip";
            this.forecastContextMenuStrip.Size = new System.Drawing.Size(207, 92);
            // 
            // forecastContextCopyMenuItem
            // 
            this.forecastContextCopyMenuItem.Name = "forecastContextCopyMenuItem";
            this.forecastContextCopyMenuItem.Size = new System.Drawing.Size(206, 22);
            this.forecastContextCopyMenuItem.Text = "Copy";
            this.forecastContextCopyMenuItem.Click += new System.EventHandler(this.forecastContextCopyMenuItemClick);
            // 
            // forecastContextPasteMenuItem
            // 
            this.forecastContextPasteMenuItem.Name = "forecastContextPasteMenuItem";
            this.forecastContextPasteMenuItem.Size = new System.Drawing.Size(206, 22);
            this.forecastContextPasteMenuItem.Text = "Paste";
            this.forecastContextPasteMenuItem.Click += new System.EventHandler(this.forecastContextPasteMenuItemClick);
            // 
            // forecastContextEditCommentMenuItem
            // 
            this.forecastContextEditCommentMenuItem.Name = "forecastContextEditCommentMenuItem";
            this.forecastContextEditCommentMenuItem.Size = new System.Drawing.Size(206, 22);
            this.forecastContextEditCommentMenuItem.Text = "Add/Remove Comments";
            this.forecastContextEditCommentMenuItem.Click += new System.EventHandler(this.forecastContextEditCommentMenuItemClick);
            // 
            // forecastContextEditOverrideMenuItem
            // 
            this.forecastContextEditOverrideMenuItem.Name = "forecastContextEditOverrideMenuItem";
            this.forecastContextEditOverrideMenuItem.Size = new System.Drawing.Size(206, 22);
            this.forecastContextEditOverrideMenuItem.Text = "Edit Manual Override";
            this.forecastContextEditOverrideMenuItem.Click += new System.EventHandler(this.forecastContextEditOverrideMenuItemClick);
            // 
            // forecastSalesRateContextMenuStrip
            // 
            this.forecastSalesRateContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forecastSalesRateContextAddCommentMenuItem});
            this.forecastSalesRateContextMenuStrip.Name = "forecastSalesRateContextMenuStrip";
            this.forecastSalesRateContextMenuStrip.Size = new System.Drawing.Size(255, 26);
            // 
            // forecastSalesRateContextAddCommentMenuItem
            // 
            this.forecastSalesRateContextAddCommentMenuItem.Name = "forecastSalesRateContextAddCommentMenuItem";
            this.forecastSalesRateContextAddCommentMenuItem.Size = new System.Drawing.Size(254, 22);
            this.forecastSalesRateContextAddCommentMenuItem.Text = "Add/Edit Comments and Override";
            this.forecastSalesRateContextAddCommentMenuItem.Click += new System.EventHandler(this.forecastSalesRateContextAddCommentMenuItemClick);
            // 
            // tabPageParameter
            // 
            this.tabPageParameter.Controls.Add(this.label2);
            this.tabPageParameter.Controls.Add(this.btnMovePLPercentageRightByYear);
            this.tabPageParameter.Controls.Add(this.btnMovePLPercentageLeftByYear);
            this.tabPageParameter.Controls.Add(this.lblMovePLPercentage);
            this.tabPageParameter.Controls.Add(this.btnMovePLPercentageRightByMonth);
            this.tabPageParameter.Controls.Add(this.btnMovePLPercentageLeftByMonth);
            this.tabPageParameter.Controls.Add(this.dgvParameter);
            this.tabPageParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameter.Name = "tabPageParameter";
            this.tabPageParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameter.Size = new System.Drawing.Size(977, 405);
            this.tabPageParameter.TabIndex = 0;
            this.tabPageParameter.Text = "Parameter";
            this.tabPageParameter.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "by Year";
            // 
            // btnMovePLPercentageRightByYear
            // 
            this.btnMovePLPercentageRightByYear.Location = new System.Drawing.Point(342, 7);
            this.btnMovePLPercentageRightByYear.Name = "btnMovePLPercentageRightByYear";
            this.btnMovePLPercentageRightByYear.Size = new System.Drawing.Size(34, 23);
            this.btnMovePLPercentageRightByYear.TabIndex = 29;
            this.btnMovePLPercentageRightByYear.Text = ">>";
            this.btnMovePLPercentageRightByYear.UseVisualStyleBackColor = true;
            this.btnMovePLPercentageRightByYear.Click += new System.EventHandler(this.btnMovePLPercentageRightByYear_Click);
            // 
            // btnMovePLPercentageLeftByYear
            // 
            this.btnMovePLPercentageLeftByYear.Location = new System.Drawing.Point(302, 7);
            this.btnMovePLPercentageLeftByYear.Name = "btnMovePLPercentageLeftByYear";
            this.btnMovePLPercentageLeftByYear.Size = new System.Drawing.Size(34, 23);
            this.btnMovePLPercentageLeftByYear.TabIndex = 28;
            this.btnMovePLPercentageLeftByYear.Text = "<<";
            this.btnMovePLPercentageLeftByYear.UseVisualStyleBackColor = true;
            this.btnMovePLPercentageLeftByYear.Click += new System.EventHandler(this.btnMovePLPercentageLeftByYear_Click);
            // 
            // lblMovePLPercentage
            // 
            this.lblMovePLPercentage.AutoSize = true;
            this.lblMovePLPercentage.Location = new System.Drawing.Point(6, 12);
            this.lblMovePLPercentage.Name = "lblMovePLPercentage";
            this.lblMovePLPercentage.Size = new System.Drawing.Size(160, 13);
            this.lblMovePLPercentage.TabIndex = 24;
            this.lblMovePLPercentage.Text = "Move PL Percentages by Month";
            // 
            // btnMovePLPercentageRightByMonth
            // 
            this.btnMovePLPercentageRightByMonth.Location = new System.Drawing.Point(208, 7);
            this.btnMovePLPercentageRightByMonth.Name = "btnMovePLPercentageRightByMonth";
            this.btnMovePLPercentageRightByMonth.Size = new System.Drawing.Size(34, 23);
            this.btnMovePLPercentageRightByMonth.TabIndex = 26;
            this.btnMovePLPercentageRightByMonth.Text = ">>";
            this.btnMovePLPercentageRightByMonth.UseVisualStyleBackColor = true;
            this.btnMovePLPercentageRightByMonth.Click += new System.EventHandler(this.btnMovePLPercentageRightByMonth_Click);
            // 
            // btnMovePLPercentageLeftByMonth
            // 
            this.btnMovePLPercentageLeftByMonth.Location = new System.Drawing.Point(168, 7);
            this.btnMovePLPercentageLeftByMonth.Name = "btnMovePLPercentageLeftByMonth";
            this.btnMovePLPercentageLeftByMonth.Size = new System.Drawing.Size(34, 23);
            this.btnMovePLPercentageLeftByMonth.TabIndex = 25;
            this.btnMovePLPercentageLeftByMonth.Text = "<<";
            this.btnMovePLPercentageLeftByMonth.UseVisualStyleBackColor = true;
            this.btnMovePLPercentageLeftByMonth.Click += new System.EventHandler(this.btnMovePLPercentageLeftByMonth_Click);
            // 
            // dgvParameter
            // 
            this.dgvParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParameter.AutoGenerateColumns = false;
            this.dgvParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumberParameter,
            this.StoreCountExisting,
            this.StoreCountNew,
            this.InitialQtyPerNewStore,
            this.ProjectedSalesRateExisting,
            this.ProjectedSalesRateNew,
            this.PipelineStart,
            this.PipelineEnd,
            this.OneTimeItemFlag,
            this.PlPctPY01,
            this.PlPctPY02,
            this.PlPctPY03,
            this.PlPctPY04,
            this.PlPctPY05,
            this.PlPctPY06,
            this.PlPctPY07,
            this.PlPctPY08,
            this.PlPctPY09,
            this.PlPctPY10,
            this.PlPctPY11,
            this.PlPctPY12,
            this.PlPctCY01,
            this.PlPctCY02,
            this.PlPctCY03,
            this.PlPctCY04,
            this.PlPctCY05,
            this.PlPctCY06,
            this.PlPctCY07,
            this.PlPctCY08,
            this.PlPctCY09,
            this.PlPctCY10,
            this.PlPctCY11,
            this.PlPctCY12,
            this.PlPctNY01,
            this.PlPctNY02,
            this.PlPctNY03,
            this.PlPctNY04,
            this.PlPctNY05,
            this.PlPctNY06,
            this.PlPctNY07,
            this.PlPctNY08,
            this.PlPctNY09,
            this.PlPctNY10,
            this.PlPctNY11,
            this.PlPctNY12,
            this.objectKeyTypeDataGridViewTextBoxColumn3,
            this.objectKeyDataGridViewTextBoxColumn3,
            this.parentDataGridViewTextBoxColumn3});
            this.dgvParameter.DataSource = this.bindingSourceForecastParameter;
            this.dgvParameter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvParameter.Location = new System.Drawing.Point(3, 35);
            this.dgvParameter.Name = "dgvParameter";
            this.dgvParameter.Size = new System.Drawing.Size(968, 367);
            this.dgvParameter.TabIndex = 30;
            this.dgvParameter.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvParameter_CellBeginEdit);
            this.dgvParameter.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameter_CellEndEdit);
            this.dgvParameter.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvParameter_CellFormatting);
            this.dgvParameter.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvParameter_CellParsing);
            this.dgvParameter.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvParameter_CellValidating);
            this.dgvParameter.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvParameter_ColumnHeaderMouseClick);
            this.dgvParameter.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvParameter_DataError);
            this.dgvParameter.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvParameter_EditingControlShowing);
            this.dgvParameter.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvParameter_RowValidating);
            this.dgvParameter.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvParameter_UserDeletingRow);
            // 
            // ItemNumberParameter
            // 
            this.ItemNumberParameter.DataPropertyName = "ItemNumber";
            this.ItemNumberParameter.Frozen = true;
            this.ItemNumberParameter.HeaderText = "Item #";
            this.ItemNumberParameter.MaxInputLength = 11;
            this.ItemNumberParameter.Name = "ItemNumberParameter";
            this.ItemNumberParameter.Width = 70;
            // 
            // StoreCountExisting
            // 
            this.StoreCountExisting.DataPropertyName = "StoreCountExisting";
            this.StoreCountExisting.Frozen = true;
            this.StoreCountExisting.HeaderText = "# Stores Existing";
            this.StoreCountExisting.MaxInputLength = 6;
            this.StoreCountExisting.Name = "StoreCountExisting";
            this.StoreCountExisting.Width = 70;
            // 
            // StoreCountNew
            // 
            this.StoreCountNew.DataPropertyName = "StoreCountNew";
            this.StoreCountNew.Frozen = true;
            this.StoreCountNew.HeaderText = "# Stores New";
            this.StoreCountNew.MaxInputLength = 6;
            this.StoreCountNew.Name = "StoreCountNew";
            this.StoreCountNew.Width = 70;
            // 
            // InitialQtyPerNewStore
            // 
            this.InitialQtyPerNewStore.DataPropertyName = "InitialQtyPerNewStore";
            this.InitialQtyPerNewStore.Frozen = true;
            this.InitialQtyPerNewStore.HeaderText = "Initial New Store Qty";
            this.InitialQtyPerNewStore.MaxInputLength = 8;
            this.InitialQtyPerNewStore.Name = "InitialQtyPerNewStore";
            this.InitialQtyPerNewStore.Width = 60;
            // 
            // ProjectedSalesRateExisting
            // 
            this.ProjectedSalesRateExisting.DataPropertyName = "ProjectedSalesRateExisting";
            this.ProjectedSalesRateExisting.Frozen = true;
            this.ProjectedSalesRateExisting.HeaderText = "Rate Existing";
            this.ProjectedSalesRateExisting.MaxInputLength = 6;
            this.ProjectedSalesRateExisting.Name = "ProjectedSalesRateExisting";
            this.ProjectedSalesRateExisting.Width = 70;
            // 
            // ProjectedSalesRateNew
            // 
            this.ProjectedSalesRateNew.DataPropertyName = "ProjectedSalesRateNew";
            this.ProjectedSalesRateNew.Frozen = true;
            this.ProjectedSalesRateNew.HeaderText = "Rate New";
            this.ProjectedSalesRateNew.MaxInputLength = 6;
            this.ProjectedSalesRateNew.Name = "ProjectedSalesRateNew";
            this.ProjectedSalesRateNew.Width = 60;
            // 
            // PipelineStart
            // 
            this.PipelineStart.DataPropertyName = "PipelineStart";
            this.PipelineStart.Frozen = true;
            this.PipelineStart.HeaderText = "Pipeline Start";
            this.PipelineStart.MaxInputLength = 4;
            this.PipelineStart.Name = "PipelineStart";
            this.PipelineStart.Width = 70;
            // 
            // PipelineEnd
            // 
            this.PipelineEnd.DataPropertyName = "PipelineEnd";
            this.PipelineEnd.Frozen = true;
            this.PipelineEnd.HeaderText = "Pipeline End";
            this.PipelineEnd.MaxInputLength = 4;
            this.PipelineEnd.Name = "PipelineEnd";
            this.PipelineEnd.Width = 70;
            // 
            // OneTimeItemFlag
            // 
            this.OneTimeItemFlag.DataPropertyName = "OneTimeItemFlag";
            this.OneTimeItemFlag.FalseValue = ((object)(resources.GetObject("OneTimeItemFlag.FalseValue")));
            this.OneTimeItemFlag.Frozen = true;
            this.OneTimeItemFlag.HeaderText = "One Time";
            this.OneTimeItemFlag.IndeterminateValue = ((object)(resources.GetObject("OneTimeItemFlag.IndeterminateValue")));
            this.OneTimeItemFlag.Name = "OneTimeItemFlag";
            this.OneTimeItemFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OneTimeItemFlag.TrueValue = ((object)(resources.GetObject("OneTimeItemFlag.TrueValue")));
            this.OneTimeItemFlag.Width = 40;
            // 
            // PlPctPY01
            // 
            this.PlPctPY01.DataPropertyName = "PlPctPY01";
            this.PlPctPY01.HeaderText = "PY01";
            this.PlPctPY01.MaxInputLength = 6;
            this.PlPctPY01.Name = "PlPctPY01";
            this.PlPctPY01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY01.Width = 45;
            // 
            // PlPctPY02
            // 
            this.PlPctPY02.DataPropertyName = "PlPctPY02";
            this.PlPctPY02.HeaderText = "PY02";
            this.PlPctPY02.MaxInputLength = 6;
            this.PlPctPY02.Name = "PlPctPY02";
            this.PlPctPY02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY02.Width = 45;
            // 
            // PlPctPY03
            // 
            this.PlPctPY03.DataPropertyName = "PlPctPY03";
            this.PlPctPY03.HeaderText = "PY03";
            this.PlPctPY03.MaxInputLength = 6;
            this.PlPctPY03.Name = "PlPctPY03";
            this.PlPctPY03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY03.Width = 45;
            // 
            // PlPctPY04
            // 
            this.PlPctPY04.DataPropertyName = "PlPctPY04";
            this.PlPctPY04.HeaderText = "PY04";
            this.PlPctPY04.MaxInputLength = 6;
            this.PlPctPY04.Name = "PlPctPY04";
            this.PlPctPY04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY04.Width = 45;
            // 
            // PlPctPY05
            // 
            this.PlPctPY05.DataPropertyName = "PlPctPY05";
            this.PlPctPY05.HeaderText = "PY05";
            this.PlPctPY05.MaxInputLength = 6;
            this.PlPctPY05.Name = "PlPctPY05";
            this.PlPctPY05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY05.Width = 45;
            // 
            // PlPctPY06
            // 
            this.PlPctPY06.DataPropertyName = "PlPctPY06";
            this.PlPctPY06.HeaderText = "PY06";
            this.PlPctPY06.MaxInputLength = 6;
            this.PlPctPY06.Name = "PlPctPY06";
            this.PlPctPY06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY06.Width = 45;
            // 
            // PlPctPY07
            // 
            this.PlPctPY07.DataPropertyName = "PlPctPY07";
            this.PlPctPY07.HeaderText = "PY07";
            this.PlPctPY07.MaxInputLength = 6;
            this.PlPctPY07.Name = "PlPctPY07";
            this.PlPctPY07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY07.Width = 45;
            // 
            // PlPctPY08
            // 
            this.PlPctPY08.DataPropertyName = "PlPctPY08";
            this.PlPctPY08.HeaderText = "PY08";
            this.PlPctPY08.MaxInputLength = 6;
            this.PlPctPY08.Name = "PlPctPY08";
            this.PlPctPY08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY08.Width = 45;
            // 
            // PlPctPY09
            // 
            this.PlPctPY09.DataPropertyName = "PlPctPY09";
            this.PlPctPY09.HeaderText = "PY09";
            this.PlPctPY09.MaxInputLength = 6;
            this.PlPctPY09.Name = "PlPctPY09";
            this.PlPctPY09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY09.Width = 45;
            // 
            // PlPctPY10
            // 
            this.PlPctPY10.DataPropertyName = "PlPctPY10";
            this.PlPctPY10.HeaderText = "PY10";
            this.PlPctPY10.MaxInputLength = 6;
            this.PlPctPY10.Name = "PlPctPY10";
            this.PlPctPY10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY10.Width = 45;
            // 
            // PlPctPY11
            // 
            this.PlPctPY11.DataPropertyName = "PlPctPY11";
            this.PlPctPY11.HeaderText = "PY11";
            this.PlPctPY11.MaxInputLength = 6;
            this.PlPctPY11.Name = "PlPctPY11";
            this.PlPctPY11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY11.Width = 45;
            // 
            // PlPctPY12
            // 
            this.PlPctPY12.DataPropertyName = "PlPctPY12";
            this.PlPctPY12.HeaderText = "PY12";
            this.PlPctPY12.MaxInputLength = 6;
            this.PlPctPY12.Name = "PlPctPY12";
            this.PlPctPY12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctPY12.Width = 45;
            // 
            // PlPctCY01
            // 
            this.PlPctCY01.DataPropertyName = "PlPctCY01";
            this.PlPctCY01.HeaderText = "CY01";
            this.PlPctCY01.MaxInputLength = 6;
            this.PlPctCY01.Name = "PlPctCY01";
            this.PlPctCY01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY01.Width = 45;
            // 
            // PlPctCY02
            // 
            this.PlPctCY02.DataPropertyName = "PlPctCY02";
            this.PlPctCY02.HeaderText = "CY02";
            this.PlPctCY02.MaxInputLength = 6;
            this.PlPctCY02.Name = "PlPctCY02";
            this.PlPctCY02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY02.Width = 45;
            // 
            // PlPctCY03
            // 
            this.PlPctCY03.DataPropertyName = "PlPctCY03";
            this.PlPctCY03.HeaderText = "CY03";
            this.PlPctCY03.MaxInputLength = 6;
            this.PlPctCY03.Name = "PlPctCY03";
            this.PlPctCY03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY03.Width = 45;
            // 
            // PlPctCY04
            // 
            this.PlPctCY04.DataPropertyName = "PlPctCY04";
            this.PlPctCY04.HeaderText = "CY04";
            this.PlPctCY04.MaxInputLength = 6;
            this.PlPctCY04.Name = "PlPctCY04";
            this.PlPctCY04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY04.Width = 45;
            // 
            // PlPctCY05
            // 
            this.PlPctCY05.DataPropertyName = "PlPctCY05";
            this.PlPctCY05.HeaderText = "CY05";
            this.PlPctCY05.MaxInputLength = 6;
            this.PlPctCY05.Name = "PlPctCY05";
            this.PlPctCY05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY05.Width = 45;
            // 
            // PlPctCY06
            // 
            this.PlPctCY06.DataPropertyName = "PlPctCY06";
            this.PlPctCY06.HeaderText = "CY06";
            this.PlPctCY06.MaxInputLength = 6;
            this.PlPctCY06.Name = "PlPctCY06";
            this.PlPctCY06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY06.Width = 45;
            // 
            // PlPctCY07
            // 
            this.PlPctCY07.DataPropertyName = "PlPctCY07";
            this.PlPctCY07.HeaderText = "CY07";
            this.PlPctCY07.MaxInputLength = 6;
            this.PlPctCY07.Name = "PlPctCY07";
            this.PlPctCY07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY07.Width = 45;
            // 
            // PlPctCY08
            // 
            this.PlPctCY08.DataPropertyName = "PlPctCY08";
            this.PlPctCY08.HeaderText = "CY08";
            this.PlPctCY08.MaxInputLength = 6;
            this.PlPctCY08.Name = "PlPctCY08";
            this.PlPctCY08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY08.Width = 45;
            // 
            // PlPctCY09
            // 
            this.PlPctCY09.DataPropertyName = "PlPctCY09";
            this.PlPctCY09.HeaderText = "CY09";
            this.PlPctCY09.MaxInputLength = 6;
            this.PlPctCY09.Name = "PlPctCY09";
            this.PlPctCY09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY09.Width = 45;
            // 
            // PlPctCY10
            // 
            this.PlPctCY10.DataPropertyName = "PlPctCY10";
            this.PlPctCY10.HeaderText = "CY10";
            this.PlPctCY10.MaxInputLength = 6;
            this.PlPctCY10.Name = "PlPctCY10";
            this.PlPctCY10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY10.Width = 45;
            // 
            // PlPctCY11
            // 
            this.PlPctCY11.DataPropertyName = "PlPctCY11";
            this.PlPctCY11.HeaderText = "CY11";
            this.PlPctCY11.MaxInputLength = 6;
            this.PlPctCY11.Name = "PlPctCY11";
            this.PlPctCY11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY11.Width = 45;
            // 
            // PlPctCY12
            // 
            this.PlPctCY12.DataPropertyName = "PlPctCY12";
            this.PlPctCY12.HeaderText = "CY12";
            this.PlPctCY12.MaxInputLength = 6;
            this.PlPctCY12.Name = "PlPctCY12";
            this.PlPctCY12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctCY12.Width = 45;
            // 
            // PlPctNY01
            // 
            this.PlPctNY01.DataPropertyName = "PlPctNY01";
            this.PlPctNY01.HeaderText = "NY01";
            this.PlPctNY01.MaxInputLength = 6;
            this.PlPctNY01.Name = "PlPctNY01";
            this.PlPctNY01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY01.Width = 45;
            // 
            // PlPctNY02
            // 
            this.PlPctNY02.DataPropertyName = "PlPctNY02";
            this.PlPctNY02.HeaderText = "NY02";
            this.PlPctNY02.MaxInputLength = 6;
            this.PlPctNY02.Name = "PlPctNY02";
            this.PlPctNY02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY02.Width = 45;
            // 
            // PlPctNY03
            // 
            this.PlPctNY03.DataPropertyName = "PlPctNY03";
            this.PlPctNY03.HeaderText = "NY03";
            this.PlPctNY03.MaxInputLength = 6;
            this.PlPctNY03.Name = "PlPctNY03";
            this.PlPctNY03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY03.Width = 45;
            // 
            // PlPctNY04
            // 
            this.PlPctNY04.DataPropertyName = "PlPctNY04";
            this.PlPctNY04.HeaderText = "NY04";
            this.PlPctNY04.MaxInputLength = 6;
            this.PlPctNY04.Name = "PlPctNY04";
            this.PlPctNY04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY04.Width = 45;
            // 
            // PlPctNY05
            // 
            this.PlPctNY05.DataPropertyName = "PlPctNY05";
            this.PlPctNY05.HeaderText = "NY05";
            this.PlPctNY05.MaxInputLength = 6;
            this.PlPctNY05.Name = "PlPctNY05";
            this.PlPctNY05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY05.Width = 45;
            // 
            // PlPctNY06
            // 
            this.PlPctNY06.DataPropertyName = "PlPctNY06";
            this.PlPctNY06.HeaderText = "NY06";
            this.PlPctNY06.MaxInputLength = 6;
            this.PlPctNY06.Name = "PlPctNY06";
            this.PlPctNY06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY06.Width = 45;
            // 
            // PlPctNY07
            // 
            this.PlPctNY07.DataPropertyName = "PlPctNY07";
            this.PlPctNY07.HeaderText = "NY07";
            this.PlPctNY07.MaxInputLength = 6;
            this.PlPctNY07.Name = "PlPctNY07";
            this.PlPctNY07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY07.Width = 45;
            // 
            // PlPctNY08
            // 
            this.PlPctNY08.DataPropertyName = "PlPctNY08";
            this.PlPctNY08.HeaderText = "NY08";
            this.PlPctNY08.MaxInputLength = 6;
            this.PlPctNY08.Name = "PlPctNY08";
            this.PlPctNY08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY08.Width = 45;
            // 
            // PlPctNY09
            // 
            this.PlPctNY09.DataPropertyName = "PlPctNY09";
            this.PlPctNY09.HeaderText = "NY09";
            this.PlPctNY09.MaxInputLength = 6;
            this.PlPctNY09.Name = "PlPctNY09";
            this.PlPctNY09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY09.Width = 45;
            // 
            // PlPctNY10
            // 
            this.PlPctNY10.DataPropertyName = "PlPctNY10";
            this.PlPctNY10.HeaderText = "NY10";
            this.PlPctNY10.MaxInputLength = 6;
            this.PlPctNY10.Name = "PlPctNY10";
            this.PlPctNY10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY10.Width = 45;
            // 
            // PlPctNY11
            // 
            this.PlPctNY11.DataPropertyName = "PlPctNY11";
            this.PlPctNY11.HeaderText = "NY11";
            this.PlPctNY11.MaxInputLength = 6;
            this.PlPctNY11.Name = "PlPctNY11";
            this.PlPctNY11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY11.Width = 45;
            // 
            // PlPctNY12
            // 
            this.PlPctNY12.DataPropertyName = "PlPctNY12";
            this.PlPctNY12.HeaderText = "NY12";
            this.PlPctNY12.MaxInputLength = 6;
            this.PlPctNY12.Name = "PlPctNY12";
            this.PlPctNY12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlPctNY12.Width = 45;
            // 
            // objectKeyTypeDataGridViewTextBoxColumn3
            // 
            this.objectKeyTypeDataGridViewTextBoxColumn3.DataPropertyName = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn3.HeaderText = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn3.Name = "objectKeyTypeDataGridViewTextBoxColumn3";
            this.objectKeyTypeDataGridViewTextBoxColumn3.ReadOnly = true;
            this.objectKeyTypeDataGridViewTextBoxColumn3.Visible = false;
            // 
            // objectKeyDataGridViewTextBoxColumn3
            // 
            this.objectKeyDataGridViewTextBoxColumn3.DataPropertyName = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn3.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn3.Name = "objectKeyDataGridViewTextBoxColumn3";
            this.objectKeyDataGridViewTextBoxColumn3.Visible = false;
            // 
            // parentDataGridViewTextBoxColumn3
            // 
            this.parentDataGridViewTextBoxColumn3.DataPropertyName = "Parent";
            this.parentDataGridViewTextBoxColumn3.HeaderText = "Parent";
            this.parentDataGridViewTextBoxColumn3.Name = "parentDataGridViewTextBoxColumn3";
            this.parentDataGridViewTextBoxColumn3.Visible = false;
            // 
            // bindingSourceForecastParameter
            // 
            this.bindingSourceForecastParameter.AllowNew = true;
            this.bindingSourceForecastParameter.DataSource = typeof(PWC.BusinessObject.ForecastParameter.WithCustomerParentCollection);
            // 
            // tabPageTrend
            // 
            this.tabPageTrend.Controls.Add(this.rbtnTrendByCustomerProductGroup);
            this.tabPageTrend.Controls.Add(this.rbtnTrendByCompanyProductGroup);
            this.tabPageTrend.Controls.Add(this.rbtnTrendByCustomerItem);
            this.tabPageTrend.Controls.Add(this.rbtnTrendByCompanyItem);
            this.tabPageTrend.Controls.Add(this.dgvTrend);
            this.tabPageTrend.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrend.Name = "tabPageTrend";
            this.tabPageTrend.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrend.Size = new System.Drawing.Size(977, 405);
            this.tabPageTrend.TabIndex = 1;
            this.tabPageTrend.Text = "Trend";
            this.tabPageTrend.UseVisualStyleBackColor = true;
            // 
            // rbtnTrendByCustomerProductGroup
            // 
            this.rbtnTrendByCustomerProductGroup.AutoSize = true;
            this.rbtnTrendByCustomerProductGroup.Location = new System.Drawing.Point(285, 6);
            this.rbtnTrendByCustomerProductGroup.Name = "rbtnTrendByCustomerProductGroup";
            this.rbtnTrendByCustomerProductGroup.Size = new System.Drawing.Size(155, 17);
            this.rbtnTrendByCustomerProductGroup.TabIndex = 22;
            this.rbtnTrendByCustomerProductGroup.Text = "by Customer Product Group";
            this.rbtnTrendByCustomerProductGroup.UseVisualStyleBackColor = true;
            this.rbtnTrendByCustomerProductGroup.CheckedChanged += new System.EventHandler(this.rbtnTrend_CheckedChanged);
            // 
            // rbtnTrendByCompanyProductGroup
            // 
            this.rbtnTrendByCompanyProductGroup.AutoSize = true;
            this.rbtnTrendByCompanyProductGroup.Checked = true;
            this.rbtnTrendByCompanyProductGroup.Location = new System.Drawing.Point(12, 6);
            this.rbtnTrendByCompanyProductGroup.Name = "rbtnTrendByCompanyProductGroup";
            this.rbtnTrendByCompanyProductGroup.Size = new System.Drawing.Size(155, 17);
            this.rbtnTrendByCompanyProductGroup.TabIndex = 20;
            this.rbtnTrendByCompanyProductGroup.TabStop = true;
            this.rbtnTrendByCompanyProductGroup.Text = "by Company Product Group";
            this.rbtnTrendByCompanyProductGroup.UseVisualStyleBackColor = true;
            this.rbtnTrendByCompanyProductGroup.CheckedChanged += new System.EventHandler(this.rbtnTrend_CheckedChanged);
            // 
            // rbtnTrendByCustomerItem
            // 
            this.rbtnTrendByCustomerItem.AutoSize = true;
            this.rbtnTrendByCustomerItem.Location = new System.Drawing.Point(446, 6);
            this.rbtnTrendByCustomerItem.Name = "rbtnTrendByCustomerItem";
            this.rbtnTrendByCustomerItem.Size = new System.Drawing.Size(106, 17);
            this.rbtnTrendByCustomerItem.TabIndex = 23;
            this.rbtnTrendByCustomerItem.Text = "by Customer Item";
            this.rbtnTrendByCustomerItem.UseVisualStyleBackColor = true;
            this.rbtnTrendByCustomerItem.CheckedChanged += new System.EventHandler(this.rbtnTrend_CheckedChanged);
            // 
            // rbtnTrendByCompanyItem
            // 
            this.rbtnTrendByCompanyItem.AutoSize = true;
            this.rbtnTrendByCompanyItem.Location = new System.Drawing.Point(173, 6);
            this.rbtnTrendByCompanyItem.Name = "rbtnTrendByCompanyItem";
            this.rbtnTrendByCompanyItem.Size = new System.Drawing.Size(106, 17);
            this.rbtnTrendByCompanyItem.TabIndex = 21;
            this.rbtnTrendByCompanyItem.Text = "by Company Item";
            this.rbtnTrendByCompanyItem.UseVisualStyleBackColor = true;
            this.rbtnTrendByCompanyItem.CheckedChanged += new System.EventHandler(this.rbtnTrend_CheckedChanged);
            // 
            // dgvTrend
            // 
            this.dgvTrend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrend.AutoGenerateColumns = false;
            this.dgvTrend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumberTrend,
            this.ProductGroup,
            this.ForecastMethod,
            this.FactorMonth01,
            this.FactorMonth02,
            this.FactorMonth03,
            this.FactorMonth04,
            this.FactorMonth05,
            this.FactorMonth06,
            this.FactorMonth07,
            this.FactorMonth08,
            this.FactorMonth09,
            this.FactorMonth10,
            this.FactorMonth11,
            this.FactorMonth12,
            this.objectKeyTypeDataGridViewTextBoxColumn1,
            this.objectKeyDataGridViewTextBoxColumn1,
            this.parentDataGridViewTextBoxColumn1});
            this.dgvTrend.DataSource = this.bindingSourceTrend;
            this.dgvTrend.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTrend.Location = new System.Drawing.Point(3, 29);
            this.dgvTrend.Name = "dgvTrend";
            this.dgvTrend.Size = new System.Drawing.Size(968, 373);
            this.dgvTrend.TabIndex = 24;
            this.dgvTrend.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTrend_CellBeginEdit);
            this.dgvTrend.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrend_CellEndEdit);
            this.dgvTrend.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvTrend_CellParsing);
            this.dgvTrend.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTrend_CellValidating);
            this.dgvTrend.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTrend_ColumnHeaderMouseClick);
            this.dgvTrend.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTrend_DataError);
            this.dgvTrend.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTrend_EditingControlShowing);
            this.dgvTrend.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTrend_RowValidating);
            this.dgvTrend.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTrend_UserDeletingRow);
            // 
            // ItemNumberTrend
            // 
            this.ItemNumberTrend.DataPropertyName = "ItemNumber";
            this.ItemNumberTrend.Frozen = true;
            this.ItemNumberTrend.HeaderText = "Item #";
            this.ItemNumberTrend.MaxInputLength = 11;
            this.ItemNumberTrend.Name = "ItemNumberTrend";
            this.ItemNumberTrend.Visible = false;
            this.ItemNumberTrend.Width = 70;
            // 
            // ProductGroup
            // 
            this.ProductGroup.DataPropertyName = "ProductGroupCodeBinding";
            this.ProductGroup.Frozen = true;
            this.ProductGroup.HeaderText = "Product Group";
            this.ProductGroup.Name = "ProductGroup";
            this.ProductGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductGroup.Width = 150;
            // 
            // ForecastMethod
            // 
            this.ForecastMethod.DataPropertyName = "ForecastMethod";
            this.ForecastMethod.Frozen = true;
            this.ForecastMethod.HeaderText = "Method";
            this.ForecastMethod.MaxInputLength = 2;
            this.ForecastMethod.Name = "ForecastMethod";
            this.ForecastMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ForecastMethod.Width = 70;
            // 
            // FactorMonth01
            // 
            this.FactorMonth01.DataPropertyName = "FactorMonth01";
            this.FactorMonth01.HeaderText = "Month 1";
            this.FactorMonth01.MaxInputLength = 6;
            this.FactorMonth01.Name = "FactorMonth01";
            this.FactorMonth01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth01.Width = 60;
            // 
            // FactorMonth02
            // 
            this.FactorMonth02.DataPropertyName = "FactorMonth02";
            this.FactorMonth02.HeaderText = "Month 2";
            this.FactorMonth02.MaxInputLength = 6;
            this.FactorMonth02.Name = "FactorMonth02";
            this.FactorMonth02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth02.Width = 60;
            // 
            // FactorMonth03
            // 
            this.FactorMonth03.DataPropertyName = "FactorMonth03";
            this.FactorMonth03.HeaderText = "Month 3";
            this.FactorMonth03.MaxInputLength = 6;
            this.FactorMonth03.Name = "FactorMonth03";
            this.FactorMonth03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth03.Width = 60;
            // 
            // FactorMonth04
            // 
            this.FactorMonth04.DataPropertyName = "FactorMonth04";
            this.FactorMonth04.HeaderText = "Month 4";
            this.FactorMonth04.MaxInputLength = 6;
            this.FactorMonth04.Name = "FactorMonth04";
            this.FactorMonth04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth04.Width = 60;
            // 
            // FactorMonth05
            // 
            this.FactorMonth05.DataPropertyName = "FactorMonth05";
            this.FactorMonth05.HeaderText = "Month 5";
            this.FactorMonth05.MaxInputLength = 6;
            this.FactorMonth05.Name = "FactorMonth05";
            this.FactorMonth05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth05.Width = 60;
            // 
            // FactorMonth06
            // 
            this.FactorMonth06.DataPropertyName = "FactorMonth06";
            this.FactorMonth06.HeaderText = "Month 6";
            this.FactorMonth06.MaxInputLength = 6;
            this.FactorMonth06.Name = "FactorMonth06";
            this.FactorMonth06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth06.Width = 60;
            // 
            // FactorMonth07
            // 
            this.FactorMonth07.DataPropertyName = "FactorMonth07";
            this.FactorMonth07.HeaderText = "Month 7";
            this.FactorMonth07.MaxInputLength = 6;
            this.FactorMonth07.Name = "FactorMonth07";
            this.FactorMonth07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth07.Width = 60;
            // 
            // FactorMonth08
            // 
            this.FactorMonth08.DataPropertyName = "FactorMonth08";
            this.FactorMonth08.HeaderText = "Month 8";
            this.FactorMonth08.MaxInputLength = 6;
            this.FactorMonth08.Name = "FactorMonth08";
            this.FactorMonth08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth08.Width = 60;
            // 
            // FactorMonth09
            // 
            this.FactorMonth09.DataPropertyName = "FactorMonth09";
            this.FactorMonth09.HeaderText = "Month 9";
            this.FactorMonth09.MaxInputLength = 6;
            this.FactorMonth09.Name = "FactorMonth09";
            this.FactorMonth09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth09.Width = 60;
            // 
            // FactorMonth10
            // 
            this.FactorMonth10.DataPropertyName = "FactorMonth10";
            this.FactorMonth10.HeaderText = "Month 10";
            this.FactorMonth10.MaxInputLength = 6;
            this.FactorMonth10.Name = "FactorMonth10";
            this.FactorMonth10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth10.Width = 60;
            // 
            // FactorMonth11
            // 
            this.FactorMonth11.DataPropertyName = "FactorMonth11";
            this.FactorMonth11.HeaderText = "Month 11";
            this.FactorMonth11.MaxInputLength = 6;
            this.FactorMonth11.Name = "FactorMonth11";
            this.FactorMonth11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth11.Width = 60;
            // 
            // FactorMonth12
            // 
            this.FactorMonth12.DataPropertyName = "FactorMonth12";
            this.FactorMonth12.HeaderText = "Month 12";
            this.FactorMonth12.MaxInputLength = 6;
            this.FactorMonth12.Name = "FactorMonth12";
            this.FactorMonth12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FactorMonth12.Width = 60;
            // 
            // objectKeyTypeDataGridViewTextBoxColumn1
            // 
            this.objectKeyTypeDataGridViewTextBoxColumn1.DataPropertyName = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn1.HeaderText = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn1.Name = "objectKeyTypeDataGridViewTextBoxColumn1";
            this.objectKeyTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.objectKeyTypeDataGridViewTextBoxColumn1.Visible = false;
            // 
            // objectKeyDataGridViewTextBoxColumn1
            // 
            this.objectKeyDataGridViewTextBoxColumn1.DataPropertyName = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn1.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn1.Name = "objectKeyDataGridViewTextBoxColumn1";
            this.objectKeyDataGridViewTextBoxColumn1.Visible = false;
            // 
            // parentDataGridViewTextBoxColumn1
            // 
            this.parentDataGridViewTextBoxColumn1.DataPropertyName = "Parent";
            this.parentDataGridViewTextBoxColumn1.HeaderText = "Parent";
            this.parentDataGridViewTextBoxColumn1.Name = "parentDataGridViewTextBoxColumn1";
            this.parentDataGridViewTextBoxColumn1.Visible = false;
            // 
            // bindingSourceTrend
            // 
            this.bindingSourceTrend.AllowNew = true;
            this.bindingSourceTrend.DataSource = typeof(PWC.BusinessObject.ForecastTrendByCompanyItem.WithCompanyParentCollection);
            // 
            // tabPageSalesRate
            // 
            this.tabPageSalesRate.Controls.Add(this.lblSavedSalesRate);
            this.tabPageSalesRate.Controls.Add(this.cboSavedSalesRate);
            this.tabPageSalesRate.Controls.Add(this.btnSaveSalesRate);
            this.tabPageSalesRate.Controls.Add(this.lblSalesRateDescription);
            this.tabPageSalesRate.Controls.Add(this.dgvSalesRate);
            this.tabPageSalesRate.Controls.Add(this.btnApplySalesRate);
            this.tabPageSalesRate.Controls.Add(this.btnGenerateSalesRate);
            this.tabPageSalesRate.Location = new System.Drawing.Point(4, 22);
            this.tabPageSalesRate.Name = "tabPageSalesRate";
            this.tabPageSalesRate.Size = new System.Drawing.Size(977, 405);
            this.tabPageSalesRate.TabIndex = 3;
            this.tabPageSalesRate.Text = "Sales Rate";
            this.tabPageSalesRate.UseVisualStyleBackColor = true;
            // 
            // lblSavedSalesRate
            // 
            this.lblSavedSalesRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSavedSalesRate.AutoSize = true;
            this.lblSavedSalesRate.Location = new System.Drawing.Point(776, 15);
            this.lblSavedSalesRate.Name = "lblSavedSalesRate";
            this.lblSavedSalesRate.Size = new System.Drawing.Size(101, 13);
            this.lblSavedSalesRate.TabIndex = 17;
            this.lblSavedSalesRate.Text = "Saved Sales Rates:";
            // 
            // cboSavedSalesRate
            // 
            this.cboSavedSalesRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedSalesRate.DataSource = this.bindingSourceSavedSalesRate;
            this.cboSavedSalesRate.DisplayMember = "POSSalesEndDate";
            this.cboSavedSalesRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavedSalesRate.FormattingEnabled = true;
            this.cboSavedSalesRate.Location = new System.Drawing.Point(880, 10);
            this.cboSavedSalesRate.Name = "cboSavedSalesRate";
            this.cboSavedSalesRate.Size = new System.Drawing.Size(85, 21);
            this.cboSavedSalesRate.TabIndex = 18;
            this.cboSavedSalesRate.ValueMember = "POSSalesEndDate";
            this.cboSavedSalesRate.SelectedIndexChanged += new System.EventHandler(this.cboSavedSalesRate_SelectedIndexChanged);
            // 
            // bindingSourceSavedSalesRate
            // 
            this.bindingSourceSavedSalesRate.AllowNew = false;
            // 
            // btnSaveSalesRate
            // 
            this.btnSaveSalesRate.Enabled = false;
            this.btnSaveSalesRate.Location = new System.Drawing.Point(147, 8);
            this.btnSaveSalesRate.Name = "btnSaveSalesRate";
            this.btnSaveSalesRate.Size = new System.Drawing.Size(62, 23);
            this.btnSaveSalesRate.TabIndex = 16;
            this.btnSaveSalesRate.Text = "Save";
            this.btnSaveSalesRate.UseVisualStyleBackColor = true;
            this.btnSaveSalesRate.Click += new System.EventHandler(this.btnSaveSalesRate_Click);
            // 
            // lblSalesRateDescription
            // 
            this.lblSalesRateDescription.AutoSize = true;
            this.lblSalesRateDescription.Location = new System.Drawing.Point(261, 13);
            this.lblSalesRateDescription.Name = "lblSalesRateDescription";
            this.lblSalesRateDescription.Size = new System.Drawing.Size(0, 13);
            this.lblSalesRateDescription.TabIndex = 16;
            // 
            // dgvSalesRate
            // 
            this.dgvSalesRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesRate.AutoGenerateColumns = false;
            this.dgvSalesRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumberSalesRate,
            this.TrendFactor,
            this.POSWeek1Quantity,
            this.POSWeek2Quantity,
            this.POSWeek3Quantity,
            this.POSWeek4Quantity,
            this.POSTotal,
            this.StoreCountExistingSalesRate,
            this.StoreCountNewSalesRate,
            this.StoreCountTotal,
            this.SalesRate,
            this.SalesRatePrevious,
            this.SalesRateDifference,
            this.SalesRateDifferencePercent,
            this.objectKeyTypeDataGridViewTextBoxColumn,
            this.objectKeyDataGridViewTextBoxColumn,
            this.parentDataGridViewTextBoxColumn});
            this.dgvSalesRate.DataSource = this.bindingSourceSalesRate;
            this.dgvSalesRate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSalesRate.Location = new System.Drawing.Point(3, 37);
            this.dgvSalesRate.Name = "dgvSalesRate";
            this.dgvSalesRate.Size = new System.Drawing.Size(971, 365);
            this.dgvSalesRate.TabIndex = 19;
            this.dgvSalesRate.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSalesRate_CellBeginEdit);
            this.dgvSalesRate.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesRate_CellEndEdit);
            this.dgvSalesRate.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSalesRate_CellFormatting);
            this.dgvSalesRate.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesRate_CellMouseEnter);
            this.dgvSalesRate.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvSalesRate_CellParsing);
            this.dgvSalesRate.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSalesRate_CellValidating);
            this.dgvSalesRate.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesRate_CellValueChanged);
            this.dgvSalesRate.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSalesRate_ColumnHeaderMouseClick);
            this.dgvSalesRate.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSalesRate_DataError);
            this.dgvSalesRate.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSalesRate_EditingControlShowing);
            this.dgvSalesRate.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSalesRate_RowValidating);
            this.dgvSalesRate.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSalesRate_UserDeletingRow);
            // 
            // ItemNumberSalesRate
            // 
            this.ItemNumberSalesRate.DataPropertyName = "ItemNumber";
            this.ItemNumberSalesRate.HeaderText = "Item #";
            this.ItemNumberSalesRate.MaxInputLength = 11;
            this.ItemNumberSalesRate.Name = "ItemNumberSalesRate";
            this.ItemNumberSalesRate.Width = 70;
            // 
            // TrendFactor
            // 
            this.TrendFactor.DataPropertyName = "TrendFactor";
            this.TrendFactor.HeaderText = "Trend";
            this.TrendFactor.MaxInputLength = 6;
            this.TrendFactor.Name = "TrendFactor";
            this.TrendFactor.ReadOnly = true;
            this.TrendFactor.Width = 60;
            // 
            // POSWeek1Quantity
            // 
            this.POSWeek1Quantity.DataPropertyName = "POSWeek1Quantity";
            this.POSWeek1Quantity.HeaderText = "POS Wk 1";
            this.POSWeek1Quantity.MaxInputLength = 5;
            this.POSWeek1Quantity.Name = "POSWeek1Quantity";
            this.POSWeek1Quantity.ReadOnly = true;
            this.POSWeek1Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POSWeek1Quantity.Width = 40;
            // 
            // POSWeek2Quantity
            // 
            this.POSWeek2Quantity.DataPropertyName = "POSWeek2Quantity";
            this.POSWeek2Quantity.HeaderText = "POS Wk 2";
            this.POSWeek2Quantity.MaxInputLength = 5;
            this.POSWeek2Quantity.Name = "POSWeek2Quantity";
            this.POSWeek2Quantity.ReadOnly = true;
            this.POSWeek2Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POSWeek2Quantity.Width = 40;
            // 
            // POSWeek3Quantity
            // 
            this.POSWeek3Quantity.DataPropertyName = "POSWeek3Quantity";
            this.POSWeek3Quantity.HeaderText = "POS Wk 3";
            this.POSWeek3Quantity.MaxInputLength = 5;
            this.POSWeek3Quantity.Name = "POSWeek3Quantity";
            this.POSWeek3Quantity.ReadOnly = true;
            this.POSWeek3Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POSWeek3Quantity.Width = 40;
            // 
            // POSWeek4Quantity
            // 
            this.POSWeek4Quantity.DataPropertyName = "POSWeek4Quantity";
            this.POSWeek4Quantity.HeaderText = "POS Wk 4";
            this.POSWeek4Quantity.MaxInputLength = 5;
            this.POSWeek4Quantity.Name = "POSWeek4Quantity";
            this.POSWeek4Quantity.ReadOnly = true;
            this.POSWeek4Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POSWeek4Quantity.Width = 40;
            // 
            // POSTotal
            // 
            this.POSTotal.DataPropertyName = "POSTotal";
            this.POSTotal.HeaderText = "POS Total";
            this.POSTotal.MaxInputLength = 7;
            this.POSTotal.Name = "POSTotal";
            this.POSTotal.ReadOnly = true;
            this.POSTotal.Width = 60;
            // 
            // StoreCountExistingSalesRate
            // 
            this.StoreCountExistingSalesRate.DataPropertyName = "StoreCountExisting";
            this.StoreCountExistingSalesRate.HeaderText = "# Store Existing";
            this.StoreCountExistingSalesRate.MaxInputLength = 5;
            this.StoreCountExistingSalesRate.Name = "StoreCountExistingSalesRate";
            this.StoreCountExistingSalesRate.ReadOnly = true;
            this.StoreCountExistingSalesRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StoreCountExistingSalesRate.Width = 50;
            // 
            // StoreCountNewSalesRate
            // 
            this.StoreCountNewSalesRate.DataPropertyName = "StoreCountNew";
            this.StoreCountNewSalesRate.HeaderText = "# Store New";
            this.StoreCountNewSalesRate.MaxInputLength = 5;
            this.StoreCountNewSalesRate.Name = "StoreCountNewSalesRate";
            this.StoreCountNewSalesRate.ReadOnly = true;
            this.StoreCountNewSalesRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StoreCountNewSalesRate.Width = 50;
            // 
            // StoreCountTotal
            // 
            this.StoreCountTotal.DataPropertyName = "StoreCountTotal";
            this.StoreCountTotal.HeaderText = "# Store Total";
            this.StoreCountTotal.MaxInputLength = 7;
            this.StoreCountTotal.Name = "StoreCountTotal";
            this.StoreCountTotal.ReadOnly = true;
            this.StoreCountTotal.Width = 60;
            // 
            // SalesRate
            // 
            this.SalesRate.DataPropertyName = "SalesRate";
            this.SalesRate.HeaderText = "Rate";
            this.SalesRate.MaxInputLength = 6;
            this.SalesRate.Name = "SalesRate";
            this.SalesRate.Width = 60;
            // 
            // SalesRatePrevious
            // 
            this.SalesRatePrevious.DataPropertyName = "SalesRatePrevious";
            this.SalesRatePrevious.HeaderText = "Compare";
            this.SalesRatePrevious.MaxInputLength = 6;
            this.SalesRatePrevious.Name = "SalesRatePrevious";
            this.SalesRatePrevious.ReadOnly = true;
            this.SalesRatePrevious.Width = 80;
            // 
            // SalesRateDifference
            // 
            this.SalesRateDifference.DataPropertyName = "SalesRateDifference";
            this.SalesRateDifference.HeaderText = "Difference";
            this.SalesRateDifference.MaxInputLength = 6;
            this.SalesRateDifference.Name = "SalesRateDifference";
            this.SalesRateDifference.ReadOnly = true;
            this.SalesRateDifference.Width = 90;
            // 
            // SalesRateDifferencePercent
            // 
            this.SalesRateDifferencePercent.DataPropertyName = "SalesRateDifferencePercent";
            this.SalesRateDifferencePercent.HeaderText = "% Difference";
            this.SalesRateDifferencePercent.MaxInputLength = 6;
            this.SalesRateDifferencePercent.Name = "SalesRateDifferencePercent";
            this.SalesRateDifferencePercent.ReadOnly = true;
            this.SalesRateDifferencePercent.Width = 90;
            // 
            // objectKeyTypeDataGridViewTextBoxColumn
            // 
            this.objectKeyTypeDataGridViewTextBoxColumn.DataPropertyName = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn.HeaderText = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn.Name = "objectKeyTypeDataGridViewTextBoxColumn";
            this.objectKeyTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.objectKeyTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // objectKeyDataGridViewTextBoxColumn
            // 
            this.objectKeyDataGridViewTextBoxColumn.DataPropertyName = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn.Name = "objectKeyDataGridViewTextBoxColumn";
            this.objectKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // parentDataGridViewTextBoxColumn
            // 
            this.parentDataGridViewTextBoxColumn.DataPropertyName = "Parent";
            this.parentDataGridViewTextBoxColumn.HeaderText = "Parent";
            this.parentDataGridViewTextBoxColumn.Name = "parentDataGridViewTextBoxColumn";
            this.parentDataGridViewTextBoxColumn.Visible = false;
            // 
            // bindingSourceSalesRate
            // 
            this.bindingSourceSalesRate.AllowNew = true;
            this.bindingSourceSalesRate.DataSource = typeof(PWC.BusinessObject.ForecastSalesRate.WithCustomerParentParameteredCollection);
            // 
            // btnApplySalesRate
            // 
            this.btnApplySalesRate.Location = new System.Drawing.Point(79, 8);
            this.btnApplySalesRate.Name = "btnApplySalesRate";
            this.btnApplySalesRate.Size = new System.Drawing.Size(62, 23);
            this.btnApplySalesRate.TabIndex = 15;
            this.btnApplySalesRate.Text = "Apply";
            this.btnApplySalesRate.UseVisualStyleBackColor = true;
            this.btnApplySalesRate.Click += new System.EventHandler(this.btnApplySalesRate_Click);
            // 
            // btnGenerateSalesRate
            // 
            this.btnGenerateSalesRate.Location = new System.Drawing.Point(11, 8);
            this.btnGenerateSalesRate.Name = "btnGenerateSalesRate";
            this.btnGenerateSalesRate.Size = new System.Drawing.Size(62, 23);
            this.btnGenerateSalesRate.TabIndex = 14;
            this.btnGenerateSalesRate.Text = "Generate";
            this.btnGenerateSalesRate.UseVisualStyleBackColor = true;
            this.btnGenerateSalesRate.Click += new System.EventHandler(this.btnGenerateSalesRate_Click);
            // 
            // tabPWCForecast
            // 
            this.tabPWCForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPWCForecast.Controls.Add(this.tabPageSalesRate);
            this.tabPWCForecast.Controls.Add(this.tabPageTrend);
            this.tabPWCForecast.Controls.Add(this.tabPageActualSales);
            this.tabPWCForecast.Controls.Add(this.tabPageParameter);
            this.tabPWCForecast.Controls.Add(this.tabPageBonusAndDiscontinued);
            this.tabPWCForecast.Controls.Add(this.tabPageForecast);
            this.tabPWCForecast.Location = new System.Drawing.Point(15, 85);
            this.tabPWCForecast.Name = "tabPWCForecast";
            this.tabPWCForecast.SelectedIndex = 0;
            this.tabPWCForecast.Size = new System.Drawing.Size(985, 431);
            this.tabPWCForecast.TabIndex = 13;
            this.tabPWCForecast.TabStop = false;
            this.tabPWCForecast.SelectedIndexChanged += new System.EventHandler(this.tabPWCForecast_SelectedIndexChanged);
            // 
            // tabPageActualSales
            // 
            this.tabPageActualSales.Controls.Add(this.dgvActualSales);
            this.tabPageActualSales.Location = new System.Drawing.Point(4, 22);
            this.tabPageActualSales.Name = "tabPageActualSales";
            this.tabPageActualSales.Size = new System.Drawing.Size(977, 405);
            this.tabPageActualSales.TabIndex = 5;
            this.tabPageActualSales.Text = "Actual Sales";
            this.tabPageActualSales.UseVisualStyleBackColor = true;
            // 
            // dgvActualSales
            // 
            this.dgvActualSales.AllowUserToAddRows = false;
            this.dgvActualSales.AllowUserToDeleteRows = false;
            this.dgvActualSales.AutoGenerateColumns = false;
            this.dgvActualSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActualSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumberActualSales,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.objectKeyTypeDataGridViewTextBoxColumn2,
            this.objectKeyDataGridViewTextBoxColumn2,
            this.parentDataGridViewTextBoxColumn2});
            this.dgvActualSales.DataSource = this.bindingSourceTrend;
            this.dgvActualSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActualSales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvActualSales.Location = new System.Drawing.Point(0, 0);
            this.dgvActualSales.Name = "dgvActualSales";
            this.dgvActualSales.ReadOnly = true;
            this.dgvActualSales.Size = new System.Drawing.Size(977, 405);
            this.dgvActualSales.TabIndex = 24;
            // 
            // ItemNumberActualSales
            // 
            this.ItemNumberActualSales.DataPropertyName = "ItemNumber";
            this.ItemNumberActualSales.Frozen = true;
            this.ItemNumberActualSales.HeaderText = "Item #";
            this.ItemNumberActualSales.MaxInputLength = 11;
            this.ItemNumberActualSales.Name = "ItemNumberActualSales";
            this.ItemNumberActualSales.ReadOnly = true;
            this.ItemNumberActualSales.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Month01";
            this.dataGridViewTextBoxColumn3.HeaderText = "Month 1";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Month02";
            this.dataGridViewTextBoxColumn4.HeaderText = "Month 2";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Month03";
            this.dataGridViewTextBoxColumn5.HeaderText = "Month 3";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Month04";
            this.dataGridViewTextBoxColumn6.HeaderText = "Month 4";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Month05";
            this.dataGridViewTextBoxColumn7.HeaderText = "Month 5";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Month06";
            this.dataGridViewTextBoxColumn8.HeaderText = "Month 6";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Month07";
            this.dataGridViewTextBoxColumn9.HeaderText = "Month 7";
            this.dataGridViewTextBoxColumn9.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Month08";
            this.dataGridViewTextBoxColumn10.HeaderText = "Month 8";
            this.dataGridViewTextBoxColumn10.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 60;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Month09";
            this.dataGridViewTextBoxColumn11.HeaderText = "Month 9";
            this.dataGridViewTextBoxColumn11.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Month10";
            this.dataGridViewTextBoxColumn12.HeaderText = "Month 10";
            this.dataGridViewTextBoxColumn12.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Month11";
            this.dataGridViewTextBoxColumn13.HeaderText = "Month 11";
            this.dataGridViewTextBoxColumn13.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Width = 60;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Month12";
            this.dataGridViewTextBoxColumn14.HeaderText = "Month 12";
            this.dataGridViewTextBoxColumn14.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn14.Width = 60;
            // 
            // objectKeyTypeDataGridViewTextBoxColumn2
            // 
            this.objectKeyTypeDataGridViewTextBoxColumn2.DataPropertyName = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn2.HeaderText = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn2.Name = "objectKeyTypeDataGridViewTextBoxColumn2";
            this.objectKeyTypeDataGridViewTextBoxColumn2.ReadOnly = true;
            this.objectKeyTypeDataGridViewTextBoxColumn2.Visible = false;
            // 
            // objectKeyDataGridViewTextBoxColumn2
            // 
            this.objectKeyDataGridViewTextBoxColumn2.DataPropertyName = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn2.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn2.Name = "objectKeyDataGridViewTextBoxColumn2";
            this.objectKeyDataGridViewTextBoxColumn2.ReadOnly = true;
            this.objectKeyDataGridViewTextBoxColumn2.Visible = false;
            // 
            // parentDataGridViewTextBoxColumn2
            // 
            this.parentDataGridViewTextBoxColumn2.DataPropertyName = "Parent";
            this.parentDataGridViewTextBoxColumn2.HeaderText = "Parent";
            this.parentDataGridViewTextBoxColumn2.Name = "parentDataGridViewTextBoxColumn2";
            this.parentDataGridViewTextBoxColumn2.ReadOnly = true;
            this.parentDataGridViewTextBoxColumn2.Visible = false;
            // 
            // tabPageBonusAndDiscontinued
            // 
            this.tabPageBonusAndDiscontinued.Controls.Add(this.rbtnBonusAndDiscontinuedByCustomer);
            this.tabPageBonusAndDiscontinued.Controls.Add(this.rbtnBonusAndDiscontinuedByCompany);
            this.tabPageBonusAndDiscontinued.Controls.Add(this.dgvBonusAndDiscontinued);
            this.tabPageBonusAndDiscontinued.Location = new System.Drawing.Point(4, 22);
            this.tabPageBonusAndDiscontinued.Name = "tabPageBonusAndDiscontinued";
            this.tabPageBonusAndDiscontinued.Size = new System.Drawing.Size(977, 405);
            this.tabPageBonusAndDiscontinued.TabIndex = 4;
            this.tabPageBonusAndDiscontinued.Text = "Bonus & Discontinued";
            this.tabPageBonusAndDiscontinued.UseVisualStyleBackColor = true;
            // 
            // rbtnBonusAndDiscontinuedByCustomer
            // 
            this.rbtnBonusAndDiscontinuedByCustomer.AutoSize = true;
            this.rbtnBonusAndDiscontinuedByCustomer.Location = new System.Drawing.Point(111, 6);
            this.rbtnBonusAndDiscontinuedByCustomer.Name = "rbtnBonusAndDiscontinuedByCustomer";
            this.rbtnBonusAndDiscontinuedByCustomer.Size = new System.Drawing.Size(83, 17);
            this.rbtnBonusAndDiscontinuedByCustomer.TabIndex = 29;
            this.rbtnBonusAndDiscontinuedByCustomer.TabStop = true;
            this.rbtnBonusAndDiscontinuedByCustomer.Text = "by Customer";
            this.rbtnBonusAndDiscontinuedByCustomer.UseVisualStyleBackColor = true;
            this.rbtnBonusAndDiscontinuedByCustomer.CheckedChanged += new System.EventHandler(this.rbtnBonusAndDiscontinuedByCustomer_CheckedChanged);
            // 
            // rbtnBonusAndDiscontinuedByCompany
            // 
            this.rbtnBonusAndDiscontinuedByCompany.AutoSize = true;
            this.rbtnBonusAndDiscontinuedByCompany.Checked = true;
            this.rbtnBonusAndDiscontinuedByCompany.Location = new System.Drawing.Point(10, 6);
            this.rbtnBonusAndDiscontinuedByCompany.Name = "rbtnBonusAndDiscontinuedByCompany";
            this.rbtnBonusAndDiscontinuedByCompany.Size = new System.Drawing.Size(83, 17);
            this.rbtnBonusAndDiscontinuedByCompany.TabIndex = 28;
            this.rbtnBonusAndDiscontinuedByCompany.TabStop = true;
            this.rbtnBonusAndDiscontinuedByCompany.Text = "by Company";
            this.rbtnBonusAndDiscontinuedByCompany.UseVisualStyleBackColor = true;
            this.rbtnBonusAndDiscontinuedByCompany.CheckedChanged += new System.EventHandler(this.rbtnBonusAndDiscontinuedByCompany_CheckedChanged);
            // 
            // dgvBonusAndDiscontinued
            // 
            this.dgvBonusAndDiscontinued.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBonusAndDiscontinued.AutoGenerateColumns = false;
            this.dgvBonusAndDiscontinued.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusAndDiscontinued.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNumberBonus,
            this.DiscontinuedEffectiveDate,
            this.PY01Bonus,
            this.PY02Bonus,
            this.PY03Bonus,
            this.PY04Bonus,
            this.PY05Bonus,
            this.PY06Bonus,
            this.PY07Bonus,
            this.PY08Bonus,
            this.PY09Bonus,
            this.PY10Bonus,
            this.PY11Bonus,
            this.PY12Bonus,
            this.CY01Bonus,
            this.CY02Bonus,
            this.CY03Bonus,
            this.CY04Bonus,
            this.CY05Bonus,
            this.CY06Bonus,
            this.CY07Bonus,
            this.CY08Bonus,
            this.CY09Bonus,
            this.CY10Bonus,
            this.CY11Bonus,
            this.CY12Bonus,
            this.NY01Bonus,
            this.NY02Bonus,
            this.NY03Bonus,
            this.NY04Bonus,
            this.NY05Bonus,
            this.NY06Bonus,
            this.NY07Bonus,
            this.NY08Bonus,
            this.NY09Bonus,
            this.NY10Bonus,
            this.NY11Bonus,
            this.NY12Bonus,
            this.objectKeyTypeDataGridViewTextBoxColumn4,
            this.objectKeyDataGridViewTextBoxColumn4,
            this.parentDataGridViewTextBoxColumn4});
            this.dgvBonusAndDiscontinued.DataSource = this.bindingSourceBonusAndDiscontinued;
            this.dgvBonusAndDiscontinued.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvBonusAndDiscontinued.Location = new System.Drawing.Point(3, 29);
            this.dgvBonusAndDiscontinued.Name = "dgvBonusAndDiscontinued";
            this.dgvBonusAndDiscontinued.Size = new System.Drawing.Size(971, 376);
            this.dgvBonusAndDiscontinued.TabIndex = 30;
            this.dgvBonusAndDiscontinued.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusAndDiscontinued_CellBeginEdit);
            this.dgvBonusAndDiscontinued.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBonusAndDiscontinued_CellEndEdit);
            this.dgvBonusAndDiscontinued.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBonusAndDiscontinued_CellFormatting);
            this.dgvBonusAndDiscontinued.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvBonusAndDiscontinued_CellParsing);
            this.dgvBonusAndDiscontinued.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBonusAndDiscontinued_CellValidating);
            this.dgvBonusAndDiscontinued.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBonusAndDiscontinued_ColumnHeaderMouseClick);
            this.dgvBonusAndDiscontinued.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBonusAndDiscontinued_DataError);
            this.dgvBonusAndDiscontinued.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBonusAndDiscontinued_EditingControlShowing);
            this.dgvBonusAndDiscontinued.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusAndDiscontinued_RowValidating);
            this.dgvBonusAndDiscontinued.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBonusAndDiscontinued_UserDeletingRow);
            // 
            // ItemNumberBonus
            // 
            this.ItemNumberBonus.DataPropertyName = "ItemNumber";
            this.ItemNumberBonus.Frozen = true;
            this.ItemNumberBonus.HeaderText = "Item #";
            this.ItemNumberBonus.MaxInputLength = 15;
            this.ItemNumberBonus.Name = "ItemNumberBonus";
            this.ItemNumberBonus.Width = 70;
            // 
            // DiscontinuedEffectiveDate
            // 
            this.DiscontinuedEffectiveDate.DataPropertyName = "DiscontinuedEffectiveDate";
            this.DiscontinuedEffectiveDate.Frozen = true;
            this.DiscontinuedEffectiveDate.HeaderText = "Discontinued";
            this.DiscontinuedEffectiveDate.MaxInputLength = 12;
            this.DiscontinuedEffectiveDate.Name = "DiscontinuedEffectiveDate";
            this.DiscontinuedEffectiveDate.Width = 75;
            // 
            // PY01Bonus
            // 
            this.PY01Bonus.DataPropertyName = "PY01";
            this.PY01Bonus.HeaderText = "PY01";
            this.PY01Bonus.MaxInputLength = 2;
            this.PY01Bonus.Name = "PY01Bonus";
            this.PY01Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY01Bonus.Width = 62;
            // 
            // PY02Bonus
            // 
            this.PY02Bonus.DataPropertyName = "PY02";
            this.PY02Bonus.HeaderText = "PY02";
            this.PY02Bonus.MaxInputLength = 2;
            this.PY02Bonus.Name = "PY02Bonus";
            this.PY02Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY02Bonus.Width = 62;
            // 
            // PY03Bonus
            // 
            this.PY03Bonus.DataPropertyName = "PY03";
            this.PY03Bonus.HeaderText = "PY03";
            this.PY03Bonus.MaxInputLength = 2;
            this.PY03Bonus.Name = "PY03Bonus";
            this.PY03Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY03Bonus.Width = 62;
            // 
            // PY04Bonus
            // 
            this.PY04Bonus.DataPropertyName = "PY04";
            this.PY04Bonus.HeaderText = "PY04";
            this.PY04Bonus.MaxInputLength = 2;
            this.PY04Bonus.Name = "PY04Bonus";
            this.PY04Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY04Bonus.Width = 62;
            // 
            // PY05Bonus
            // 
            this.PY05Bonus.DataPropertyName = "PY05";
            this.PY05Bonus.HeaderText = "PY05";
            this.PY05Bonus.MaxInputLength = 2;
            this.PY05Bonus.Name = "PY05Bonus";
            this.PY05Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY05Bonus.Width = 62;
            // 
            // PY06Bonus
            // 
            this.PY06Bonus.DataPropertyName = "PY06";
            this.PY06Bonus.HeaderText = "PY06";
            this.PY06Bonus.MaxInputLength = 2;
            this.PY06Bonus.Name = "PY06Bonus";
            this.PY06Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY06Bonus.Width = 62;
            // 
            // PY07Bonus
            // 
            this.PY07Bonus.DataPropertyName = "PY07";
            this.PY07Bonus.HeaderText = "PY07";
            this.PY07Bonus.MaxInputLength = 2;
            this.PY07Bonus.Name = "PY07Bonus";
            this.PY07Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY07Bonus.Width = 62;
            // 
            // PY08Bonus
            // 
            this.PY08Bonus.DataPropertyName = "PY08";
            this.PY08Bonus.HeaderText = "PY08";
            this.PY08Bonus.MaxInputLength = 2;
            this.PY08Bonus.Name = "PY08Bonus";
            this.PY08Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY08Bonus.Width = 62;
            // 
            // PY09Bonus
            // 
            this.PY09Bonus.DataPropertyName = "PY09";
            this.PY09Bonus.HeaderText = "PY09";
            this.PY09Bonus.MaxInputLength = 2;
            this.PY09Bonus.Name = "PY09Bonus";
            this.PY09Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY09Bonus.Width = 62;
            // 
            // PY10Bonus
            // 
            this.PY10Bonus.DataPropertyName = "PY10";
            this.PY10Bonus.HeaderText = "PY10";
            this.PY10Bonus.MaxInputLength = 2;
            this.PY10Bonus.Name = "PY10Bonus";
            this.PY10Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY10Bonus.Width = 62;
            // 
            // PY11Bonus
            // 
            this.PY11Bonus.DataPropertyName = "PY11";
            this.PY11Bonus.HeaderText = "PY11";
            this.PY11Bonus.MaxInputLength = 2;
            this.PY11Bonus.Name = "PY11Bonus";
            this.PY11Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY11Bonus.Width = 62;
            // 
            // PY12Bonus
            // 
            this.PY12Bonus.DataPropertyName = "PY12";
            this.PY12Bonus.HeaderText = "PY12";
            this.PY12Bonus.MaxInputLength = 2;
            this.PY12Bonus.Name = "PY12Bonus";
            this.PY12Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PY12Bonus.Width = 62;
            // 
            // CY01Bonus
            // 
            this.CY01Bonus.DataPropertyName = "CY01";
            this.CY01Bonus.HeaderText = "CY01";
            this.CY01Bonus.MaxInputLength = 2;
            this.CY01Bonus.Name = "CY01Bonus";
            this.CY01Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY01Bonus.Width = 62;
            // 
            // CY02Bonus
            // 
            this.CY02Bonus.DataPropertyName = "CY02";
            this.CY02Bonus.HeaderText = "CY02";
            this.CY02Bonus.MaxInputLength = 2;
            this.CY02Bonus.Name = "CY02Bonus";
            this.CY02Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY02Bonus.Width = 62;
            // 
            // CY03Bonus
            // 
            this.CY03Bonus.DataPropertyName = "CY03";
            this.CY03Bonus.HeaderText = "CY03";
            this.CY03Bonus.MaxInputLength = 2;
            this.CY03Bonus.Name = "CY03Bonus";
            this.CY03Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY03Bonus.Width = 62;
            // 
            // CY04Bonus
            // 
            this.CY04Bonus.DataPropertyName = "CY04";
            this.CY04Bonus.HeaderText = "CY04";
            this.CY04Bonus.MaxInputLength = 2;
            this.CY04Bonus.Name = "CY04Bonus";
            this.CY04Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY04Bonus.Width = 62;
            // 
            // CY05Bonus
            // 
            this.CY05Bonus.DataPropertyName = "CY05";
            this.CY05Bonus.HeaderText = "CY05";
            this.CY05Bonus.MaxInputLength = 2;
            this.CY05Bonus.Name = "CY05Bonus";
            this.CY05Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY05Bonus.Width = 62;
            // 
            // CY06Bonus
            // 
            this.CY06Bonus.DataPropertyName = "CY06";
            this.CY06Bonus.HeaderText = "CY06";
            this.CY06Bonus.MaxInputLength = 2;
            this.CY06Bonus.Name = "CY06Bonus";
            this.CY06Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY06Bonus.Width = 62;
            // 
            // CY07Bonus
            // 
            this.CY07Bonus.DataPropertyName = "CY07";
            this.CY07Bonus.HeaderText = "CY07";
            this.CY07Bonus.MaxInputLength = 2;
            this.CY07Bonus.Name = "CY07Bonus";
            this.CY07Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY07Bonus.Width = 62;
            // 
            // CY08Bonus
            // 
            this.CY08Bonus.DataPropertyName = "CY08";
            this.CY08Bonus.HeaderText = "CY08";
            this.CY08Bonus.MaxInputLength = 2;
            this.CY08Bonus.Name = "CY08Bonus";
            this.CY08Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY08Bonus.Width = 62;
            // 
            // CY09Bonus
            // 
            this.CY09Bonus.DataPropertyName = "CY09";
            this.CY09Bonus.HeaderText = "CY09";
            this.CY09Bonus.MaxInputLength = 2;
            this.CY09Bonus.Name = "CY09Bonus";
            this.CY09Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY09Bonus.Width = 62;
            // 
            // CY10Bonus
            // 
            this.CY10Bonus.DataPropertyName = "CY10";
            this.CY10Bonus.HeaderText = "CY10";
            this.CY10Bonus.MaxInputLength = 2;
            this.CY10Bonus.Name = "CY10Bonus";
            this.CY10Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY10Bonus.Width = 62;
            // 
            // CY11Bonus
            // 
            this.CY11Bonus.DataPropertyName = "CY11";
            this.CY11Bonus.HeaderText = "CY11";
            this.CY11Bonus.MaxInputLength = 2;
            this.CY11Bonus.Name = "CY11Bonus";
            this.CY11Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY11Bonus.Width = 62;
            // 
            // CY12Bonus
            // 
            this.CY12Bonus.DataPropertyName = "CY12";
            this.CY12Bonus.HeaderText = "CY12";
            this.CY12Bonus.MaxInputLength = 2;
            this.CY12Bonus.Name = "CY12Bonus";
            this.CY12Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CY12Bonus.Width = 62;
            // 
            // NY01Bonus
            // 
            this.NY01Bonus.DataPropertyName = "NY01";
            this.NY01Bonus.HeaderText = "NY01";
            this.NY01Bonus.MaxInputLength = 2;
            this.NY01Bonus.Name = "NY01Bonus";
            this.NY01Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY01Bonus.Width = 62;
            // 
            // NY02Bonus
            // 
            this.NY02Bonus.DataPropertyName = "NY02";
            this.NY02Bonus.HeaderText = "NY02";
            this.NY02Bonus.MaxInputLength = 2;
            this.NY02Bonus.Name = "NY02Bonus";
            this.NY02Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY02Bonus.Width = 62;
            // 
            // NY03Bonus
            // 
            this.NY03Bonus.DataPropertyName = "NY03";
            this.NY03Bonus.HeaderText = "NY03";
            this.NY03Bonus.MaxInputLength = 2;
            this.NY03Bonus.Name = "NY03Bonus";
            this.NY03Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY03Bonus.Width = 62;
            // 
            // NY04Bonus
            // 
            this.NY04Bonus.DataPropertyName = "NY04";
            this.NY04Bonus.HeaderText = "NY04";
            this.NY04Bonus.MaxInputLength = 2;
            this.NY04Bonus.Name = "NY04Bonus";
            this.NY04Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY04Bonus.Width = 62;
            // 
            // NY05Bonus
            // 
            this.NY05Bonus.DataPropertyName = "NY05";
            this.NY05Bonus.HeaderText = "NY05";
            this.NY05Bonus.MaxInputLength = 2;
            this.NY05Bonus.Name = "NY05Bonus";
            this.NY05Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY05Bonus.Width = 62;
            // 
            // NY06Bonus
            // 
            this.NY06Bonus.DataPropertyName = "NY06";
            this.NY06Bonus.HeaderText = "NY06";
            this.NY06Bonus.MaxInputLength = 2;
            this.NY06Bonus.Name = "NY06Bonus";
            this.NY06Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY06Bonus.Width = 62;
            // 
            // NY07Bonus
            // 
            this.NY07Bonus.DataPropertyName = "NY07";
            this.NY07Bonus.HeaderText = "NY07";
            this.NY07Bonus.MaxInputLength = 2;
            this.NY07Bonus.Name = "NY07Bonus";
            this.NY07Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY07Bonus.Width = 62;
            // 
            // NY08Bonus
            // 
            this.NY08Bonus.DataPropertyName = "NY08";
            this.NY08Bonus.HeaderText = "NY08";
            this.NY08Bonus.MaxInputLength = 2;
            this.NY08Bonus.Name = "NY08Bonus";
            this.NY08Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY08Bonus.Width = 62;
            // 
            // NY09Bonus
            // 
            this.NY09Bonus.DataPropertyName = "NY09";
            this.NY09Bonus.HeaderText = "NY09";
            this.NY09Bonus.MaxInputLength = 2;
            this.NY09Bonus.Name = "NY09Bonus";
            this.NY09Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY09Bonus.Width = 62;
            // 
            // NY10Bonus
            // 
            this.NY10Bonus.DataPropertyName = "NY10";
            this.NY10Bonus.HeaderText = "NY10";
            this.NY10Bonus.MaxInputLength = 2;
            this.NY10Bonus.Name = "NY10Bonus";
            this.NY10Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY10Bonus.Width = 62;
            // 
            // NY11Bonus
            // 
            this.NY11Bonus.DataPropertyName = "NY11";
            this.NY11Bonus.HeaderText = "NY11";
            this.NY11Bonus.MaxInputLength = 2;
            this.NY11Bonus.Name = "NY11Bonus";
            this.NY11Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY11Bonus.Width = 62;
            // 
            // NY12Bonus
            // 
            this.NY12Bonus.DataPropertyName = "NY12";
            this.NY12Bonus.HeaderText = "NY12";
            this.NY12Bonus.MaxInputLength = 2;
            this.NY12Bonus.Name = "NY12Bonus";
            this.NY12Bonus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NY12Bonus.Width = 62;
            // 
            // objectKeyTypeDataGridViewTextBoxColumn4
            // 
            this.objectKeyTypeDataGridViewTextBoxColumn4.DataPropertyName = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn4.HeaderText = "ObjectKeyType";
            this.objectKeyTypeDataGridViewTextBoxColumn4.Name = "objectKeyTypeDataGridViewTextBoxColumn4";
            this.objectKeyTypeDataGridViewTextBoxColumn4.ReadOnly = true;
            this.objectKeyTypeDataGridViewTextBoxColumn4.Visible = false;
            // 
            // objectKeyDataGridViewTextBoxColumn4
            // 
            this.objectKeyDataGridViewTextBoxColumn4.DataPropertyName = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn4.HeaderText = "ObjectKey";
            this.objectKeyDataGridViewTextBoxColumn4.Name = "objectKeyDataGridViewTextBoxColumn4";
            this.objectKeyDataGridViewTextBoxColumn4.Visible = false;
            // 
            // parentDataGridViewTextBoxColumn4
            // 
            this.parentDataGridViewTextBoxColumn4.DataPropertyName = "Parent";
            this.parentDataGridViewTextBoxColumn4.HeaderText = "Parent";
            this.parentDataGridViewTextBoxColumn4.Name = "parentDataGridViewTextBoxColumn4";
            this.parentDataGridViewTextBoxColumn4.Visible = false;
            // 
            // bindingSourceBonusAndDiscontinued
            // 
            this.bindingSourceBonusAndDiscontinued.AllowNew = true;
            this.bindingSourceBonusAndDiscontinued.DataSource = typeof(PWC.BusinessObject.BonusAndDiscontinuedByCompany.WithCompanyParentCollection);
            // 
            // dtpMonthEndDate
            // 
            this.dtpMonthEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMonthEndDate.Location = new System.Drawing.Point(408, 61);
            this.dtpMonthEndDate.Name = "dtpMonthEndDate";
            this.dtpMonthEndDate.Size = new System.Drawing.Size(86, 20);
            this.dtpMonthEndDate.TabIndex = 10;
            this.dtpMonthEndDate.GotFocus += new System.EventHandler(this.dtpMonthEndDate_GotFocus);
            this.dtpMonthEndDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpMonthEndDate_Validating);
            // 
            // lblNumberOfPosWeeksOrSalesMonths
            // 
            this.lblNumberOfPosWeeksOrSalesMonths.AutoSize = true;
            this.lblNumberOfPosWeeksOrSalesMonths.Location = new System.Drawing.Point(553, 64);
            this.lblNumberOfPosWeeksOrSalesMonths.Name = "lblNumberOfPosWeeksOrSalesMonths";
            this.lblNumberOfPosWeeksOrSalesMonths.Size = new System.Drawing.Size(42, 13);
            this.lblNumberOfPosWeeksOrSalesMonths.TabIndex = 11;
            this.lblNumberOfPosWeeksOrSalesMonths.Text = "# Wks:";
            // 
            // nudNumberOfPosWeeksOrSalesMonths
            // 
            this.nudNumberOfPosWeeksOrSalesMonths.Location = new System.Drawing.Point(601, 60);
            this.nudNumberOfPosWeeksOrSalesMonths.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudNumberOfPosWeeksOrSalesMonths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfPosWeeksOrSalesMonths.Name = "nudNumberOfPosWeeksOrSalesMonths";
            this.nudNumberOfPosWeeksOrSalesMonths.Size = new System.Drawing.Size(29, 20);
            this.nudNumberOfPosWeeksOrSalesMonths.TabIndex = 12;
            this.nudNumberOfPosWeeksOrSalesMonths.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudNumberOfPosWeeksOrSalesMonths.GotFocus += new System.EventHandler(this.nudNumberOfPosWeeksOrSalesMonths_GotFocus);
            this.nudNumberOfPosWeeksOrSalesMonths.Validating += new System.ComponentModel.CancelEventHandler(this.nudNumberOfPosWeeksOrSalesMonths_Validating);
            // 
            // rbtnSR
            // 
            this.rbtnSR.AutoSize = true;
            this.rbtnSR.Enabled = false;
            this.rbtnSR.Location = new System.Drawing.Point(18, 61);
            this.rbtnSR.Name = "rbtnSR";
            this.rbtnSR.Size = new System.Drawing.Size(40, 17);
            this.rbtnSR.TabIndex = 7;
            this.rbtnSR.Text = "SR";
            this.rbtnSR.UseVisualStyleBackColor = true;
            // 
            // rbtnRA
            // 
            this.rbtnRA.AutoSize = true;
            this.rbtnRA.Enabled = false;
            this.rbtnRA.Location = new System.Drawing.Point(64, 61);
            this.rbtnRA.Name = "rbtnRA";
            this.rbtnRA.Size = new System.Drawing.Size(40, 17);
            this.rbtnRA.TabIndex = 8;
            this.rbtnRA.Text = "RA";
            this.rbtnRA.UseVisualStyleBackColor = true;
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.ItemHeight = 13;
            this.cboCustomer.Location = new System.Drawing.Point(364, 33);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(267, 21);
            this.cboCustomer.TabIndex = 5;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // chkShowPriorYear
            // 
            this.chkShowPriorYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowPriorYear.AutoSize = true;
            this.chkShowPriorYear.Location = new System.Drawing.Point(899, 64);
            this.chkShowPriorYear.Name = "chkShowPriorYear";
            this.chkShowPriorYear.Size = new System.Drawing.Size(102, 17);
            this.chkShowPriorYear.TabIndex = 104;
            this.chkShowPriorYear.Text = "Show Prior Year";
            this.chkShowPriorYear.UseVisualStyleBackColor = true;
            this.chkShowPriorYear.CheckedChanged += new System.EventHandler(this.chkShowPriorYear_CheckedChanged);
            // 
            // chkUseClipboardDataOnNewRow
            // 
            this.chkUseClipboardDataOnNewRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseClipboardDataOnNewRow.AutoSize = true;
            this.chkUseClipboardDataOnNewRow.Location = new System.Drawing.Point(710, 64);
            this.chkUseClipboardDataOnNewRow.Name = "chkUseClipboardDataOnNewRow";
            this.chkUseClipboardDataOnNewRow.Size = new System.Drawing.Size(183, 17);
            this.chkUseClipboardDataOnNewRow.TabIndex = 103;
            this.chkUseClipboardDataOnNewRow.Text = "Use Clipboard Data on New Row";
            this.chkUseClipboardDataOnNewRow.UseVisualStyleBackColor = true;
            // 
            // lblForecastFutureFrozenMonths
            // 
            this.lblForecastFutureFrozenMonths.AutoSize = true;
            this.lblForecastFutureFrozenMonths.Location = new System.Drawing.Point(110, 63);
            this.lblForecastFutureFrozenMonths.Name = "lblForecastFutureFrozenMonths";
            this.lblForecastFutureFrozenMonths.Size = new System.Drawing.Size(157, 13);
            this.lblForecastFutureFrozenMonths.TabIndex = 105;
            this.lblForecastFutureFrozenMonths.Text = "Forecast Future Frozen Months:";
            // 
            // txtForecastFutureFrozenMonths
            // 
            this.txtForecastFutureFrozenMonths.Enabled = false;
            this.txtForecastFutureFrozenMonths.Location = new System.Drawing.Point(264, 59);
            this.txtForecastFutureFrozenMonths.Name = "txtForecastFutureFrozenMonths";
            this.txtForecastFutureFrozenMonths.Size = new System.Drawing.Size(25, 20);
            this.txtForecastFutureFrozenMonths.TabIndex = 106;
            this.txtForecastFutureFrozenMonths.TabStop = false;
            // 
            // frmPWCForecast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 528);
            this.Controls.Add(this.txtForecastFutureFrozenMonths);
            this.Controls.Add(this.lblForecastFutureFrozenMonths);
            this.Controls.Add(this.chkUseClipboardDataOnNewRow);
            this.Controls.Add(this.chkShowPriorYear);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.rbtnRA);
            this.Controls.Add(this.rbtnSR);
            this.Controls.Add(this.nudNumberOfPosWeeksOrSalesMonths);
            this.Controls.Add(this.lblNumberOfPosWeeksOrSalesMonths);
            this.Controls.Add(this.dtpMonthEndDate);
            this.Controls.Add(this.lblPOSSalesEndDate);
            this.Controls.Add(this.txtGotoItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGotoItem);
            this.Controls.Add(this.tabPWCForecast);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.menuStripPWCForecast);
            this.MainMenuStrip = this.menuStripPWCForecast;
            this.Name = "frmPWCForecast";
            this.Text = "PWC Forecast";
            this.Load += new System.EventHandler(this.frmPWCForecast_Load);
            this.menuStripPWCForecast.ResumeLayout(false);
            this.menuStripPWCForecast.PerformLayout();
            this.tabPageForecast.ResumeLayout(false);
            this.tabPageForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForecast)).EndInit();
            this.forecastContextMenuStrip.ResumeLayout(false);
            this.forecastSalesRateContextMenuStrip.ResumeLayout(false);
            this.tabPageParameter.ResumeLayout(false);
            this.tabPageParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForecastParameter)).EndInit();
            this.tabPageTrend.ResumeLayout(false);
            this.tabPageTrend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTrend)).EndInit();
            this.tabPageSalesRate.ResumeLayout(false);
            this.tabPageSalesRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSavedSalesRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSalesRate)).EndInit();
            this.tabPWCForecast.ResumeLayout(false);
            this.tabPageActualSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActualSales)).EndInit();
            this.tabPageBonusAndDiscontinued.ResumeLayout(false);
            this.tabPageBonusAndDiscontinued.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusAndDiscontinued)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBonusAndDiscontinued)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPosWeeksOrSalesMonths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.MaskedTextBox txtCompanyCode;
        private System.Windows.Forms.BindingSource bindingSourceForecastParameter;
        private System.Windows.Forms.BindingSource bindingSourceSalesRate;
        private System.Windows.Forms.BindingSource bindingSourceForecast;
        private System.Windows.Forms.BindingSource bindingSourceBonusAndDiscontinued;
        private System.Windows.Forms.Button btnGotoItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGotoItem;
        private System.Windows.Forms.Label lblPOSSalesEndDate;
        private System.Windows.Forms.MenuStrip menuStripPWCForecast;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastFromEditedForecastFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posFromOracleFlatFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posFromACNeilsenXLSFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posFromACNeilsenXLSToCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSourceTrend;
        private System.Windows.Forms.ToolStripMenuItem restorePOSPriorToImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageForecast;
        private System.Windows.Forms.Label lblForecastDescription;
        private System.Windows.Forms.Button btnSaveForecast;
        private System.Windows.Forms.Button btnGenerateForecast;
        private System.Windows.Forms.DataGridView dgvForecast;
        private System.Windows.Forms.TabPage tabPageParameter;
        private System.Windows.Forms.DataGridView dgvParameter;
        private System.Windows.Forms.TabPage tabPageTrend;
        private System.Windows.Forms.DataGridView dgvTrend;
        private System.Windows.Forms.TabPage tabPageSalesRate;
        private System.Windows.Forms.Button btnSaveSalesRate;
        private System.Windows.Forms.Label lblSalesRateDescription;
        private System.Windows.Forms.DataGridView dgvSalesRate;
        private System.Windows.Forms.Button btnApplySalesRate;
        private System.Windows.Forms.Button btnGenerateSalesRate;
        private System.Windows.Forms.TabControl tabPWCForecast;
        private System.Windows.Forms.Button btnMovePLPercentageRightByMonth;
        private System.Windows.Forms.Button btnMovePLPercentageLeftByMonth;
        private System.Windows.Forms.Label lblMovePLPercentage;
        private System.Windows.Forms.ToolStripMenuItem salesRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpMonthEndDate;
        private System.Windows.Forms.Label lblNumberOfPosWeeksOrSalesMonths;
        private System.Windows.Forms.NumericUpDown nudNumberOfPosWeeksOrSalesMonths;
        private System.Windows.Forms.TabPage tabPageBonusAndDiscontinued;
        private System.Windows.Forms.DataGridView dgvBonusAndDiscontinued;
        private System.Windows.Forms.RadioButton rbtnBonusAndDiscontinuedByCustomer;
        private System.Windows.Forms.RadioButton rbtnBonusAndDiscontinuedByCompany;
        private System.Windows.Forms.ToolStripMenuItem bonusItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discontinuedItemsToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbtnTrendByCustomerItem;
        private System.Windows.Forms.RadioButton rbtnTrendByCompanyItem;
        private System.Windows.Forms.RadioButton rbtnTrendByCompanyProductGroup;
        private System.Windows.Forms.RadioButton rbtnSR;
        private System.Windows.Forms.RadioButton rbtnRA;
        private System.Windows.Forms.ComboBox cboSavedSalesRate;
        private System.Windows.Forms.Label lblSavedSalesRate;
        private System.Windows.Forms.Label lblSavedForecast;
        private System.Windows.Forms.ComboBox cboSavedForecast;
        private System.Windows.Forms.BindingSource bindingSourceSavedSalesRate;
        private System.Windows.Forms.BindingSource bindingSourceSavedForecast;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.CheckBox chkShowPriorYear;
        private System.Windows.Forms.CheckBox chkUseClipboardDataOnNewRow;
        private System.Windows.Forms.ToolStripMenuItem actualSalesFromFlatFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreActualSalesPriorToImportToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMovePLPercentageRightByYear;
        private System.Windows.Forms.Button btnMovePLPercentageLeftByYear;
        private System.Windows.Forms.ToolStripMenuItem batchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateCompanyForecastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualVsForecastComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posFromACNeilsenFlatFileToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageActualSales;
        private System.Windows.Forms.DataGridView dgvActualSales;
        private System.Windows.Forms.Label lblForecastFutureFrozenMonths;
        private System.Windows.Forms.TextBox txtForecastFutureFrozenMonths;
        private System.Windows.Forms.RadioButton rbtnTrendByCustomerProductGroup;
        private System.Windows.Forms.ToolStripMenuItem trendByCompanyProductGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trendByCompanyItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trendByCustomerProductGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trendByCustomerItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreTrendByCompanyProductGroupPriorToImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreTrendByCompanyItemPriorToImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreTrendByCustomerProductGroupPriorToImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreTrendByCustomerItemPriorToImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip forecastContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip forecastSalesRateContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem forecastContextCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastContextPasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastContextEditCommentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastContextEditOverrideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastSalesRateContextAddCommentMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumberForecast;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForecastMethodForecast;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY01;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY02;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY03;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY04;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY05;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY06;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY07;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY08;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY09;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY10;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY11;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY12;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY01;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY02;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY03;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY04;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY05;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY06;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY07;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY08;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY09;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY10;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY11;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY12;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY01;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY02;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY03;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY04;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY05;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY06;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY07;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY08;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY09;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY10;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY11;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY12;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyTypeDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumberParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCountExisting;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCountNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialQtyPerNewStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectedSalesRateExisting;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectedSalesRateNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn PipelineStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn PipelineEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OneTimeItemFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY01;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY02;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY03;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY04;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY05;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY06;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY07;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY08;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY09;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY10;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY11;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctPY12;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY01;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY02;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY03;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY04;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY05;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY06;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY07;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY08;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY09;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY10;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY11;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctCY12;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY01;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY02;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY03;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY04;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY05;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY06;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY07;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY08;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY09;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY10;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY11;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlPctNY12;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyTypeDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumberTrend;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForecastMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth01;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth02;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth03;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth04;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth05;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth06;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth07;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth08;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth09;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth10;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth11;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorMonth12;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumberSalesRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrendFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSWeek1Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSWeek2Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSWeek3Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSWeek4Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCountExistingSalesRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCountNewSalesRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCountTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRatePrevious;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRateDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRateDifferencePercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumberActualSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyTypeDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumberBonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscontinuedEffectiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY01Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY02Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY03Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY04Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY05Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY06Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY07Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY08Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY09Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY10Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY11Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY12Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY01Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY02Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY03Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY04Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY05Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY06Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY07Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY08Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY09Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY10Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY11Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CY12Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY01Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY02Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY03Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY04Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY05Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY06Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY07Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY08Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY09Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY10Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY11Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NY12Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyTypeDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectKeyDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn4;
        private Button btnExportForecast;
        private Button btnImportForecast;
    }
}

