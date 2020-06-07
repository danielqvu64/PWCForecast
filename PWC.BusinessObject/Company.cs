using System;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    public enum ExportType
    { Bonus, Discontinued }

    public enum ForecastExportType
    { ToOracle, PipelineCrosstab }

    public enum ForecastReportGroupBy
    { Brand, Item }

    public class CompanyKey : AObjectKey
    {
        public SqlString CompanyCode;

        public CompanyKey() { }

        public CompanyKey(SqlString companyCode)
        {
            CompanyCode = companyCode;
        }

        public override string ToString()
        {
            return CompanyCode.ToString();
        }
    }

    /// <summary>
    /// Summary description for Company.
    /// </summary>
    [Serializable]
    public class Company : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _companyName;
        private Customer.WithCompanyParentCollection _customerCollection;
        private ForecastTrendByCompanyItem.WithCompanyParentCollection _forecastTrendByItemCollection;
        private ForecastTrendByCompanyProductGroup.WithCompanyParentCollection _forecastTrendByProductGroupCollection;
        private BonusAndDiscontinuedByCompany.WithCompanyParentCollection _bonusAndDiscontinuedCollection;

        public Company() { }

        public Company(SqlString companyCode)
        {
            CompanyCode = companyCode;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(CompanyKey); }
        }

        #region Collection Members
        [NotMapped]
        public Customer.WithCompanyParentCollection CustomerCollection
        {
            get
            {
                if (_customerCollection == null)
                {
                    _customerCollection = new Customer.WithCompanyParentCollection(this);
                    _customerCollection.Load();
                }
                return _customerCollection;
            }
            set { _customerCollection = value; }
        }

        [NotMapped]
        public ForecastTrendByCompanyItem.WithCompanyParentCollection ForecastTrendByItemCollection
        {
            get
            {
                if (_forecastTrendByItemCollection == null)
                {
                    _forecastTrendByItemCollection = new ForecastTrendByCompanyItem.WithCompanyParentCollection(this);
                    _forecastTrendByItemCollection.Load();
                }
                return _forecastTrendByItemCollection;
            }
            set { _forecastTrendByItemCollection = value; }
        }

        [NotMapped]
        public ForecastTrendByCompanyProductGroup.WithCompanyParentCollection ForecastTrendByProductGroupCollection
        {
            get
            {
                if (_forecastTrendByProductGroupCollection == null)
                {
                    _forecastTrendByProductGroupCollection = new ForecastTrendByCompanyProductGroup.WithCompanyParentCollection(this);
                    _forecastTrendByProductGroupCollection.Load();
                }
                return _forecastTrendByProductGroupCollection;
            }
            set { _forecastTrendByProductGroupCollection = value; }
        }

        [NotMapped]
        public BonusAndDiscontinuedByCompany.WithCompanyParentCollection BonusAndDiscontinuedCollection
        {
            get
            {
                if (_bonusAndDiscontinuedCollection == null)
                {
                    _bonusAndDiscontinuedCollection = new BonusAndDiscontinuedByCompany.WithCompanyParentCollection(this);
                    _bonusAndDiscontinuedCollection.Load();
                }
                return _bonusAndDiscontinuedCollection;
            }
            set { _bonusAndDiscontinuedCollection = value; }
        }
        #endregion

        #region Mapped Members
        public SqlString CompanyCode
        {
            get { return _companyCode; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_companyCode.CompareTo(value) != 0)
                {
                    _companyCode = value;
                    FieldDataChange("CompanyCode", value);
                }
            }
        }

        public SqlString CompanyName
        {
            get { return _companyName; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_companyName.CompareTo(value) != 0)
                {
                    _companyName = value;
                    FieldDataChange("CompanyName", value);
                }
            }
        }
        #endregion

        public override bool Validate()
        {
            return (ObjectKey != null && !_companyName.IsNull);
        }

        public void GenerateAndSaveForecast()
        {
            foreach (var customer in CustomerCollection)
            {
                if (customer.ForecastMethod == "RA")
                {
                    var actualSalesDateAndGapCollection = new ActualSalesLatestDateAndGap.ParameteredCollection(customer.CompanyCode, customer.CustomerNumber, SqlDateTime.Null, (SqlByte)customer.RollingAvageNumberOfMonths);
                    actualSalesDateAndGapCollection.Load();
                    if (actualSalesDateAndGapCollection.Count > 0)
                    {
                        customer.POSSalesEndDate = actualSalesDateAndGapCollection[0].LatestActualSalesEndDate;
                        customer.GenerateAndSaveForecast();
                    }
                }
                else if (customer.ForecastMethod == "SR")
                {
                    var posDateAndGapCollection = new POSLatestDateAndGap.ParameteredCollection(customer.CompanyCode, customer.CustomerNumber, SqlDateTime.Null, (SqlByte)customer.POSNumberOfWeeks);
                    posDateAndGapCollection.Load();
                    if (posDateAndGapCollection.Count > 0)
                    {
                        customer.POSSalesEndDate = posDateAndGapCollection[0].LatestWeekEndDate;
                        customer.GenerateAndSaveForecast();
                    }
                }
            }
        }

        private void WriteForecastVarianceCrossTab(StreamWriter sw, ForecastReport forecastReport, ActualSalesReport.ParameteredCollection actualSalesReportCollection, int forecastYear, ref int[] forecastReportGrandTotal, ref int[] actualSalesReportGrandTotal, ref int[] varianceReportGrandTotal)
        {
            if (forecastReport.GroupBy == ForecastReportGroupBy.Brand.ToString())
            {
                var brand = new Brand(forecastReport.GroupByCode);
                brand.Load();
                sw.WriteLine("{0} - {1}", forecastReport.GroupByCode, brand.BrandDescription);
            }
            else
                sw.WriteLine(forecastReport.GroupByCode);

            var varianceReportCollection = new int[12];
            var forecastReportTotal = 0;
            var actualSalesReportTotal = 0;
            var varianceReportTotal = 0;
            sw.Write("Actual");
            for (var i = 0; i < 12; i++)
            {
                int actualSalesReportQuantity;
                var actualSalesReport = actualSalesReportCollection[new ActualSalesReportKey(_companyCode, forecastReport.GroupByCode, new SqlDateTime(forecastYear, i + 1, 1))];
                if (actualSalesReport != null && actualSalesReport.Quantity > SqlInt32.Zero)
                    actualSalesReportQuantity = actualSalesReport.Quantity.Value;
                else
                    actualSalesReportQuantity = 0;

                varianceReportCollection[i] = forecastReport.ForcastReportQuantityCollection[i].Value - actualSalesReportQuantity;
                forecastReportTotal += forecastReport.ForcastReportQuantityCollection[i].IsNull ? 0 : forecastReport.ForcastReportQuantityCollection[i].Value;
                actualSalesReportTotal += actualSalesReportQuantity;
                varianceReportTotal += varianceReportCollection[i];
                forecastReportGrandTotal[i] += forecastReport.ForcastReportQuantityCollection[i].IsNull ? 0 : forecastReport.ForcastReportQuantityCollection[i].Value;
                actualSalesReportGrandTotal[i] += actualSalesReportQuantity;
                varianceReportGrandTotal[i] += varianceReportCollection[i];
                sw.Write(",{0}", actualSalesReportQuantity);
            }
            forecastReportGrandTotal[12] += forecastReportTotal;
            actualSalesReportGrandTotal[12] += actualSalesReportTotal;
            varianceReportGrandTotal[12] += varianceReportTotal;

            sw.WriteLine(",{0}", actualSalesReportTotal);

            sw.Write("SLSFR,{0},{1},{2},{3},{4},{5},", forecastReport.ForecastMonth01Quantity, forecastReport.ForecastMonth02Quantity, forecastReport.ForecastMonth03Quantity, forecastReport.ForecastMonth04Quantity, forecastReport.ForecastMonth05Quantity, forecastReport.ForecastMonth06Quantity);
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", forecastReport.ForecastMonth07Quantity, forecastReport.ForecastMonth08Quantity, forecastReport.ForecastMonth09Quantity, forecastReport.ForecastMonth10Quantity, forecastReport.ForecastMonth11Quantity, forecastReport.ForecastMonth12Quantity, forecastReportTotal);

            sw.Write("Variance");
            for (var i = 0; i < 12; i++)
                sw.Write(",{0}", varianceReportCollection[i]);
            sw.WriteLine(",{0}", varianceReportTotal);
            sw.WriteLine();
        }

        public void ExportForecast(DateTime posSalesEndDate, string filePath, bool appendFile, ForecastExportType forecastExportType, bool subtractCurrentMonthSales)
        {
            using (var sw = new StreamWriter(filePath, appendFile))
            {
                foreach (var customer in CustomerCollection)
                {
                    customer.POSSalesEndDate = posSalesEndDate;
                    customer.ForecastAction = ForecastAction.Get;
                    customer.ForecastCollection = null;
                    if (customer.ForecastCollection != null)
                    {
                        if (customer.ForecastCollection.Count == 0)
                            continue;
                        if (forecastExportType == ForecastExportType.PipelineCrosstab &&
                            !customer.ForecastCollection.ContainForecastMethod("PL"))
                            continue;
                    }
                    customer.ExportForecast(forecastExportType, sw, subtractCurrentMonthSales);
                }
            }
        }

        public void ExportForecast(string filePath, bool appendFile, ForecastExportType forecastExportType, bool subtractCurrentMonthSales)
        {
            using (var sw = new StreamWriter(filePath, appendFile))
            {
                foreach (var customer in CustomerCollection)
                {
                    var savedForecastDates = PersistenceLayer.Utility.GetInstance().GetSavedForecastDateCollection(_companyCode, customer.CustomerNumber, 1);
                    if (savedForecastDates.Count == 1)
                        continue;
                    var posSalesEndDate = DateTime.Parse(savedForecastDates[1].POSSalesEndDate);
                    customer.POSSalesEndDate = posSalesEndDate;
                    customer.ForecastAction = ForecastAction.Get;
                    customer.ForecastCollection = null;
                    if (customer.ForecastCollection != null)
                    {
                        if (customer.ForecastCollection.Count == 0)
                            continue;
                        if (forecastExportType == ForecastExportType.PipelineCrosstab &&
                            !customer.ForecastCollection.ContainForecastMethod("PL"))
                            continue;
                    }
                    customer.ExportForecast(forecastExportType, sw, subtractCurrentMonthSales);
                }
            }
        }

        public void ReportForecast(string filePath, bool appendFile, SqlString customerNumberFrom, SqlString customerNumberTo, SqlString brandCodeFrom, SqlString brandCodeTo, SqlString productCategoryCodeFrom, SqlString productCategoryCodeTo, ForecastReportGroupBy groupBy, string forecastMethods, int forecastYear)
        {
            var forecastReportCollection = new ForecastReport.ParameteredCollection(_companyCode, customerNumberFrom, customerNumberTo, brandCodeFrom, brandCodeTo, productCategoryCodeFrom, productCategoryCodeTo, groupBy, forecastMethods, forecastYear);
            forecastReportCollection.Load();
            var actualSalesReportCollection = new ActualSalesReport.ParameteredCollection(_companyCode, customerNumberFrom, customerNumberTo, brandCodeFrom, brandCodeTo, productCategoryCodeFrom, productCategoryCodeTo, groupBy, forecastMethods, forecastYear);
            actualSalesReportCollection.Load();
            using (var sw = new StreamWriter(filePath, appendFile))
            {
                sw.WriteLine(",,,,Actual vs Forecast Comparison Report,,,,,,,Report Date: {0:MM/dd/yyyy}", DateTime.Today);
                sw.WriteLine();
                sw.WriteLine("Company Code: {0}", _companyCode);
                sw.WriteLine("Customer Number from: {0} to: {1}", customerNumberFrom, customerNumberTo);
                sw.WriteLine("Brand Code from: {0} to: {1}", brandCodeFrom, brandCodeTo);
                sw.WriteLine("Product Category Code from: {0} to: {1}", productCategoryCodeFrom, productCategoryCodeTo);
                sw.WriteLine("Forecast Methods: {0}", forecastMethods);
                sw.WriteLine("Forecast Year: {0}", forecastYear);
                sw.WriteLine("Group by: {0}", groupBy);
                sw.WriteLine();
                var header = new StringBuilder();
                if (groupBy == ForecastReportGroupBy.Brand)
                    header.Append("Brand");
                else
                    header.Append("Item#");
                header.Append(",").Append("Jan ").Append(forecastYear.ToString());
                header.Append(",").Append("Feb ").Append(forecastYear.ToString());
                header.Append(",").Append("Mar ").Append(forecastYear.ToString());
                header.Append(",").Append("Apr ").Append(forecastYear.ToString());
                header.Append(",").Append("May ").Append(forecastYear.ToString());
                header.Append(",").Append("Jun ").Append(forecastYear.ToString());
                header.Append(",").Append("Jul ").Append(forecastYear.ToString());
                header.Append(",").Append("Aug ").Append(forecastYear.ToString());
                header.Append(",").Append("Sep ").Append(forecastYear.ToString());
                header.Append(",").Append("Oct ").Append(forecastYear.ToString());
                header.Append(",").Append("Nov ").Append(forecastYear.ToString());
                header.Append(",").Append("Dec ").Append(forecastYear.ToString());
                header.Append(",Total ").Append(forecastYear.ToString());
                sw.WriteLine(header.ToString());
                sw.WriteLine();
                var forecastReportGrandTotal = new int[13];
                var actualSalesReportGrandTotal = new int[13];
                var varianceReportGrandTotal = new int[13];
                foreach (var forecastReport in forecastReportCollection)
                    WriteForecastVarianceCrossTab(sw, forecastReport, actualSalesReportCollection, forecastYear, ref forecastReportGrandTotal, ref actualSalesReportGrandTotal, ref varianceReportGrandTotal);
                sw.WriteLine();
                sw.WriteLine("Report Total:");
                sw.Write("Actual");
                for (var i = 0; i < 13; i++)
                    sw.Write(",{0}", actualSalesReportGrandTotal[i]);
                sw.WriteLine();
                sw.Write("SLSFR");
                for (var i = 0; i < 13; i++)
                    sw.Write(",{0}", forecastReportGrandTotal[i]);
                sw.WriteLine();
                sw.Write("Variance");
                for (var i = 0; i < 13; i++)
                    sw.Write(",{0}", varianceReportGrandTotal[i]);
                sw.WriteLine();
            }
        }

        public string BuildBonusMonthExportHeader()
        {
            var calendar = Calendar.GetInstance();
            var sb = new StringBuilder(string.Empty);
            for (var columnIndex = 0; columnIndex < 36; columnIndex++)
            {
                int year, month = (columnIndex + 1) % 12;
                if (month == 0) month = 12;
                if (columnIndex < 12)
                    year = DateTime.Today.Year - 1;
                else if (columnIndex < 24)
                    year = DateTime.Today.Year;
                else
                    year = DateTime.Today.Year + 1;
                sb.Append(",");
                sb.Append(calendar.GetPWCForecastMonth(new DateTime(year, month, 1)));
                sb.Append(" (").Append(DateTime.DaysInMonth(year, month == 0 ? 12 : month).ToString()).Append(")");
            }
            return sb.ToString();
        }

        public void ExportBonusAndDiscontinued(ExportType exportType, string filePath, bool appendFile)
        {
            using (var sw = new StreamWriter(filePath, appendFile))
            {
                if (BonusAndDiscontinuedCollection.Count <= 0) return;
                var firstBonusAndDiscontinuedByCompany = BonusAndDiscontinuedCollection[0];
                sw.WriteLine("Company: {0}", firstBonusAndDiscontinuedByCompany.CompanyCode);
                sw.Write("Item No");
                if (exportType == ExportType.Bonus)
                    sw.Write(BuildBonusMonthExportHeader());
                else
                    sw.Write(",Discontinued");
                sw.WriteLine();
                foreach (var bonusAndDiscontinuedByCompany in BonusAndDiscontinuedCollection)
                {
                    if (exportType == ExportType.Discontinued &&
                        bonusAndDiscontinuedByCompany.DiscontinuedEffectiveDate.IsNull)
                        continue;
                    if (exportType == ExportType.Bonus)
                    {
                        var hasBonusValue = false;
                        for (var i = 0; i < bonusAndDiscontinuedByCompany.BonusNumOfDaysCollection.Length; i++)
                            if (!bonusAndDiscontinuedByCompany.BonusNumOfDaysCollection[i].IsNull)
                            {
                                hasBonusValue = true;
                                break;
                            }
                        if (!hasBonusValue)
                            continue;
                    }
                    sw.Write(bonusAndDiscontinuedByCompany.ItemNumber);
                    if (exportType == ExportType.Discontinued)
                        sw.WriteLine(",{0:MM-dd-yyyy}",
                                     bonusAndDiscontinuedByCompany.DiscontinuedEffectiveDate.Value);
                    else
                    {
                        for (var i = 0; i < bonusAndDiscontinuedByCompany.BonusNumOfDaysCollection.Length; i++)
                            sw.Write(",{0}", bonusAndDiscontinuedByCompany.BonusNumOfDaysCollection[i]);
                        sw.WriteLine();
                    }
                }
            }
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<CompanyKey, Company>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString companyCode)
            {
                ParameterCollection = new HybridDictionary { {"CompanyCode", companyCode} };
            }
        }
    }
}
