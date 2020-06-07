using System;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DVu.Library.PersistenceLayer;
using DVu.Library.BusinessObject;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    struct DropDownItem
    {
        private readonly string _code;
        private readonly string _description;

        public DropDownItem(string code, string description)
        {
            _code = code;
            _description = description;
        }

        public string Code
        { get { return _code; } }

        public string Description
        { get { return _description; } }

        public string CodeDescription
        {
            get
            {
                return _code == string.Empty ? "<< select >>" : new System.Text.StringBuilder(Code).Append(" - ").Append(Description).ToString();
            }
        }
    }

    class ActualSalesCrossTabLine
    {
        private SqlInt32 _month01 = SqlInt32.Null;
        private SqlInt32 _month02 = SqlInt32.Null;
        private SqlInt32 _month03 = SqlInt32.Null;
        private SqlInt32 _month04 = SqlInt32.Null;
        private SqlInt32 _month05 = SqlInt32.Null;
        private SqlInt32 _month06 = SqlInt32.Null;
        private SqlInt32 _month07 = SqlInt32.Null;
        private SqlInt32 _month08 = SqlInt32.Null;
        private SqlInt32 _month09 = SqlInt32.Null;
        private SqlInt32 _month10 = SqlInt32.Null;
        private SqlInt32 _month11 = SqlInt32.Null;
        private SqlInt32 _month12 = SqlInt32.Null;

        public SqlString ItemNumber { get; set; }
        public SqlInt32 Month01 { get { return _month01; } set { _month01 = value; } }
        public SqlInt32 Month02 { get { return _month02; } set { _month02 = value; } }
        public SqlInt32 Month03 { get { return _month03; } set { _month03 = value; } }
        public SqlInt32 Month04 { get { return _month04; } set { _month04 = value; } }
        public SqlInt32 Month05 { get { return _month05; } set { _month05 = value; } }
        public SqlInt32 Month06 { get { return _month06; } set { _month06 = value; } }
        public SqlInt32 Month07 { get { return _month07; } set { _month07 = value; } }
        public SqlInt32 Month08 { get { return _month08; } set { _month08 = value; } }
        public SqlInt32 Month09 { get { return _month09; } set { _month09 = value; } }
        public SqlInt32 Month10 { get { return _month10; } set { _month10 = value; } }
        public SqlInt32 Month11 { get { return _month11; } set { _month11 = value; } }
        public SqlInt32 Month12 { get { return _month12; } set { _month12 = value; } }
    }

    sealed class Utility
    {
        private static volatile Utility _instance;
        private static readonly object SyncRoot = new object();

        private Utility() { }

        public static Utility GetInstance()
        {
            if (_instance == null)
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Utility();
                }
            return _instance;
        }

        public void HandleException(Form form, Exception ex, EventArgs e)
        {
            string additionalData = null;
            var errorPhrase = "Unexpected error occured.";
            var isConcurrencyConflict = false;
            if (ex is SqlException)
            {
                isConcurrencyConflict = ex.Message == "Timestamp mismatched";

                additionalData = string.Format("Class: {0}, LineNumber: {1}, Number: {2}, Procedure: {3}, State: {4}", ((SqlException)ex).Class, ((SqlException)ex).LineNumber, ((SqlException)ex).Number, ((SqlException)ex).Procedure, ((SqlException)ex).State);
                errorPhrase = "SQL operation error occured.";
            }
            if (isConcurrencyConflict)
                MessageBox.Show("Your changes cannot be saved since your original data has been changed by another user.\n\n1. Please review the refreshed data\n2. Apply your changes\n3. Save again.", "PWC Forecast", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PersistenceFacade.GetInstance().LogException(ex, Environment.MachineName, additionalData);
                MessageBox.Show(
                    string.Format(
                        "{0}\nThe error has been logged into database.\nPlease notify System Administrator.\n\n{1}",
                        errorPhrase, ex.Message), "PWC Forecast", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            form.Cursor = Cursors.Arrow;

            //if (e is DataGridViewCellCancelEventArgs)
            //    ((DataGridViewCellCancelEventArgs)e).Cancel = true;
            //else if (e is DataGridViewRowCancelEventArgs)
            //    ((DataGridViewRowCancelEventArgs)e).Cancel = true;
            //else if (e is DataGridViewCellValidatingEventArgs)
            //    ((DataGridViewCellValidatingEventArgs)e).Cancel = true;
            
            // all of the types above are derived from CancelEventArgs, so no need to check individually
            if (e is CancelEventArgs)
                ((CancelEventArgs)e).Cancel = true;
            else if (e is DataGridViewCellParsingEventArgs)
                ((DataGridViewCellParsingEventArgs)e).ParsingApplied = false;
            else if (e is DataGridViewCellFormattingEventArgs)
                ((DataGridViewCellFormattingEventArgs)e).FormattingApplied = false;
        }

        public void SaveSetting(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public List<DropDownItem> GetCustomerDropDownCollection(Company company, string sortField)
        {
            var list = new List<DropDownItem>(company.CustomerCollection.Count + 1);
            if (sortField != "default") company.CustomerCollection.Sort(sortField, SortDirection.Ascending);
            list.Add(new DropDownItem(string.Empty, string.Empty));
            list.AddRange(company.CustomerCollection.Select(customer => new DropDownItem(customer.CustomerNumber.Value, customer.CustomerName.IsNull ? string.Empty : customer.CustomerName.Value)));
            return list;
        }

        public List<DropDownItem> GetBrandDropDownCollection()
        {
            var brandCollection = new Brand.ParameteredCollection(SqlString.Null, SqlString.Null);
            brandCollection.Load();
            var list = new List<DropDownItem>(brandCollection.Count + 1) {new DropDownItem(string.Empty, string.Empty)};
            list.AddRange(brandCollection.Select(brand => new DropDownItem(brand.BrandCode.Value, brand.BrandDescription.IsNull ? string.Empty : brand.BrandDescription.Value)));
            return list;
        }

        public List<DropDownItem> GetProductCategoryDropDownCollection()
        {
            var productCategoryCollection = new ProductCategory.ParameteredCollection(SqlString.Null, SqlString.Null);
            productCategoryCollection.Load();
            var list = new List<DropDownItem>(productCategoryCollection.Count + 1)
                           {new DropDownItem(string.Empty, string.Empty)};
            list.AddRange(productCategoryCollection.Select(productCategory => new DropDownItem(productCategory.ProductCategoryCode.Value, productCategory.ProductCategoryDescription.IsNull ? string.Empty : productCategory.ProductCategoryDescription.Value)));
            return list;
        }

        public List<DropDownItem> GetProductGroupDropDownCollection()
        {
            var productGroupCollection = new ProductGroup.ParameteredCollection(SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
            productGroupCollection.Load();
            var list = new List<DropDownItem>(productGroupCollection.Count + 1)
                           {new DropDownItem(string.Empty, string.Empty)};
            list.AddRange(productGroupCollection.Select(productGroup => new DropDownItem(productGroup.ProductGroupCode.Value, productGroup.ProductGroupDescription.IsNull ? string.Empty : productGroup.ProductGroupDescription.Value)));
            return list;
        }

        public List<ActualSalesCrossTabLine> GetActualSalesCrossTabCollection(Customer customer)
        {
            var actualSalesCrossTabCollection = new List<ActualSalesCrossTabLine>();
            var actualSalesCollection = new ActualSales.WithCustomerParentParameteredCollection(customer, new SqlDateTime(DateTime.Today.AddMonths(-11).Year, DateTime.Today.AddMonths(-11).Month, 1), new SqlDateTime(DateTime.Today));
            actualSalesCollection.Load();
            if (actualSalesCollection.Count > 0)
            {
                SqlString previousItemNumber = string.Empty;
                ActualSalesCrossTabLine actualSalesCrossTabLine = null;
                foreach (var actualSales in actualSalesCollection)
                {
                    if (previousItemNumber != actualSales.ItemNumber)
                    {
                        actualSalesCrossTabLine = new ActualSalesCrossTabLine();
                        actualSalesCrossTabCollection.Add(actualSalesCrossTabLine);
                        actualSalesCrossTabLine.ItemNumber = actualSales.ItemNumber;
                        previousItemNumber = actualSales.ItemNumber;
                    }
                    if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-11).Month)
                        actualSalesCrossTabLine.Month01 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-10).Month)
                        actualSalesCrossTabLine.Month02 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-9).Month)
                        actualSalesCrossTabLine.Month03 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-8).Month)
                        actualSalesCrossTabLine.Month04 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-7).Month)
                        actualSalesCrossTabLine.Month05 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-6).Month)
                        actualSalesCrossTabLine.Month06 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-5).Month)
                        actualSalesCrossTabLine.Month07 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-4).Month)
                        actualSalesCrossTabLine.Month08 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-3).Month)
                        actualSalesCrossTabLine.Month09 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-2).Month)
                        actualSalesCrossTabLine.Month10 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.AddMonths(-1).Month)
                        actualSalesCrossTabLine.Month11 = actualSales.Quantity;
                    else if (actualSales.Month.Value.Month == DateTime.Today.Month)
                        actualSalesCrossTabLine.Month12 = actualSales.Quantity;
                }
            }
            return actualSalesCrossTabCollection;
        }
    }
}
