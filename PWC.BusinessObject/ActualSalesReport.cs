using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ActualSalesReportKey : CompanyKey
    {
        public SqlString GroupByCode;
        public SqlDateTime Month;

        public ActualSalesReportKey() { }

        public ActualSalesReportKey(SqlString companyCode, SqlString groupByCode, SqlDateTime month)
        {
            CompanyCode = companyCode;
            GroupByCode = groupByCode;
            Month = month;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|").Append(GroupByCode.ToString()).Append("|");
            sb.Append(Month.IsNull ? Month.ToString() : Month.Value.ToString("MM/dd/yyyy"));
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for ActualSalesReport.
    /// </summary>
    [Serializable]
    public class ActualSalesReport : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _groupByCode;
        private SqlDateTime _month;
        private SqlInt32 _quantity;

        public ActualSalesReport() { }

        public ActualSalesReport(SqlString companyCode, SqlString groupByCode, SqlDateTime month)
        {
            CompanyCode = companyCode;
            GroupByCode = groupByCode;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ActualSalesReportKey); }
        }

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

        public SqlString GroupByCode
        {
            get { return _groupByCode; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_groupByCode.CompareTo(value) != 0)
                {
                    _groupByCode = value;
                    FieldDataChange("GroupByCode", value);
                }
            }
        }

        public SqlDateTime Month
        {
            get { return _month; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_month.CompareTo(value) != 0)
                {
                    _month = value;
                    FieldDataChange("Month", value);
                }
            }
        }

        public SqlInt32 Quantity
        {
            get { return _quantity; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_quantity.CompareTo(value) != 0)
                {
                    _quantity = value;
                    FieldDataChange("Quantity", value);
                }
            }
        }
        #endregion

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<ActualSalesReportKey, ActualSalesReport>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString companyCode, SqlString customerNumberFrom, SqlString customerNumberTo, SqlString brandCodeFrom, SqlString brandCodeTo, SqlString productCategoryCodeFrom, SqlString productCategoryCodeTo, ForecastReportGroupBy groupBy, string forecastMethods, int forecastYear)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", companyCode},
                                               {"CustomerNumberFrom", customerNumberFrom},
                                               {"CustomerNumberTo", customerNumberTo},
                                               {"BrandCodeFrom", brandCodeFrom},
                                               {"BrandCodeTo", brandCodeTo},
                                               {"ProductCategoryCodeFrom", productCategoryCodeFrom},
                                               {"ProductCategoryCodeTo", productCategoryCodeTo},
                                               {"GroupBy", groupBy.ToString()},
                                               {"ForecastMethods", forecastMethods},
                                               {"ForecastYear", forecastYear}
                                           };
            }
        }
    }
}
