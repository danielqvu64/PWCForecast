 using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastReportKey : CompanyKey
    {
        public SqlString GroupByCode;

        public ForecastReportKey() { }

        public ForecastReportKey(SqlString companyCode, SqlString groupByCode)
        {
            CompanyCode = companyCode;
            GroupByCode = groupByCode;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|").Append(GroupByCode.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastReport.
    /// </summary>
    [Serializable]
    public class ForecastReport : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _groupByCode;
        private SqlString _groupBy;
        private readonly SqlInt32[] _forecastReportQuantityCollection = new SqlInt32[12];

        public ForecastReport() { }

        public ForecastReport(SqlString companyCode, SqlString groupByCode)
        {
            CompanyCode = companyCode;
            GroupByCode = groupByCode;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastReportKey); }
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

        public SqlString GroupBy
        {
            get { return _groupBy; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_groupBy.CompareTo(value) != 0)
                {
                    _groupBy = value;
                    FieldDataChange("GroupBy", value);
                }
            }
        }

#if false
        public SqlInt32 PY01
        {
            get { return py01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py01.CompareTo(value) != 0)
                    AttributeChange();
                py01 = value;
            }
        }

        public SqlInt32 PY02
        {
            get { return py02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py02.CompareTo(value) != 0)
                    AttributeChange();
                py02 = value;
            }
        }

        public SqlInt32 PY03
        {
            get { return py03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py03.CompareTo(value) != 0)
                    AttributeChange();
                py03 = value;
            }
        }

        public SqlInt32 PY04
        {
            get { return py04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py04.CompareTo(value) != 0)
                    AttributeChange();
                py04 = value;
            }
        }

        public SqlInt32 PY05
        {
            get { return py05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py05.CompareTo(value) != 0)
                    AttributeChange();
                py05 = value;
            }
        }

        public SqlInt32 PY06
        {
            get { return py06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py06.CompareTo(value) != 0)
                    AttributeChange();
                py06 = value;
            }
        }

        public SqlInt32 PY07
        {
            get { return py07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py07.CompareTo(value) != 0)
                    AttributeChange();
                py07 = value;
            }
        }

        public SqlInt32 PY08
        {
            get { return py08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py08.CompareTo(value) != 0)
                    AttributeChange();
                py08 = value;
            }
        }

        public SqlInt32 PY09
        {
            get { return py09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py09.CompareTo(value) != 0)
                    AttributeChange();
                py09 = value;
            }
        }

        public SqlInt32 PY10
        {
            get { return py10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py10.CompareTo(value) != 0)
                    AttributeChange();
                py10 = value;
            }
        }

        public SqlInt32 PY11
        {
            get { return py11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py11.CompareTo(value) != 0)
                    AttributeChange();
                py11 = value;
            }
        }

        public SqlInt32 PY12
        {
            get { return py12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py12.CompareTo(value) != 0)
                    AttributeChange();
                py12 = value;
            }
        }

        public SqlInt32 CY01
        {
            get { return cy01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy01.CompareTo(value) != 0)
                    AttributeChange();
                cy01 = value;
            }
        }

        public SqlInt32 CY02
        {
            get { return cy02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy02.CompareTo(value) != 0)
                    AttributeChange();
                cy02 = value;
            }
        }

        public SqlInt32 CY03
        {
            get { return cy03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy03.CompareTo(value) != 0)
                    AttributeChange();
                cy03 = value;
            }
        }

        public SqlInt32 CY04
        {
            get { return cy04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy04.CompareTo(value) != 0)
                    AttributeChange();
                cy04 = value;
            }
        }

        public SqlInt32 CY05
        {
            get { return cy05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy05.CompareTo(value) != 0)
                    AttributeChange();
                cy05 = value;
            }
        }

        public SqlInt32 CY06
        {
            get { return cy06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy06.CompareTo(value) != 0)
                    AttributeChange();
                cy06 = value;
            }
        }

        public SqlInt32 CY07
        {
            get { return cy07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy07.CompareTo(value) != 0)
                    AttributeChange();
                cy07 = value;
            }
        }

        public SqlInt32 CY08
        {
            get { return cy08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy08.CompareTo(value) != 0)
                    AttributeChange();
                cy08 = value;
            }
        }

        public SqlInt32 CY09
        {
            get { return cy09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy09.CompareTo(value) != 0)
                    AttributeChange();
                cy09 = value;
            }
        }

        public SqlInt32 CY10
        {
            get { return cy10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy10.CompareTo(value) != 0)
                    AttributeChange();
                cy10 = value;
            }
        }

        public SqlInt32 CY11
        {
            get { return cy11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy11.CompareTo(value) != 0)
                    AttributeChange();
                cy11 = value;
            }
        }

        public SqlInt32 CY12
        {
            get { return cy12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy12.CompareTo(value) != 0)
                    AttributeChange();
                cy12 = value;
            }
        }

        public SqlInt32 NY01
        {
            get { return ny01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny01.CompareTo(value) != 0)
                    AttributeChange();
                ny01 = value;
            }
        }

        public SqlInt32 NY02
        {
            get { return ny02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny02.CompareTo(value) != 0)
                    AttributeChange();
                ny02 = value;
            }
        }

        public SqlInt32 NY03
        {
            get { return ny03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny03.CompareTo(value) != 0)
                    AttributeChange();
                ny03 = value;
            }
        }

        public SqlInt32 NY04
        {
            get { return ny04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny04.CompareTo(value) != 0)
                    AttributeChange();
                ny04 = value;
            }
        }

        public SqlInt32 NY05
        {
            get { return ny05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny05.CompareTo(value) != 0)
                    AttributeChange();
                ny05 = value;
            }
        }

        public SqlInt32 NY06
        {
            get { return ny06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny06.CompareTo(value) != 0)
                    AttributeChange();
                ny06 = value;
            }
        }

        public SqlInt32 NY07
        {
            get { return ny07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny07.CompareTo(value) != 0)
                    AttributeChange();
                ny07 = value;
            }
        }

        public SqlInt32 NY08
        {
            get { return ny08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny08.CompareTo(value) != 0)
                    AttributeChange();
                ny08 = value;
            }
        }

        public SqlInt32 NY09
        {
            get { return ny09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny09.CompareTo(value) != 0)
                    AttributeChange();
                ny09 = value;
            }
        }

        public SqlInt32 NY10
        {
            get { return ny10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny10.CompareTo(value) != 0)
                    AttributeChange();
                ny10 = value;
            }
        }

        public SqlInt32 NY11
        {
            get { return ny11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny11.CompareTo(value) != 0)
                    AttributeChange();
                ny11 = value;
            }
        }

        public SqlInt32 NY12
        {
            get { return ny12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny12.CompareTo(value) != 0)
                    AttributeChange();
                ny12 = value;
            }
        }
#endif
        internal SqlInt32[] ForcastReportQuantityCollection
        { get { return _forecastReportQuantityCollection; } }

        public SqlInt32 ForecastMonth01Quantity
        {
            get { return _forecastReportQuantityCollection[0]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[0].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[0] = value;
                    FieldDataChange("ForecastMonth01Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth02Quantity
        {
            get { return _forecastReportQuantityCollection[1]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[1].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[1] = value;
                    FieldDataChange("ForecastMonth02Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth03Quantity
        {
            get { return _forecastReportQuantityCollection[2]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[2].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[2] = value;
                    FieldDataChange("ForecastMonth03Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth04Quantity
        {
            get { return _forecastReportQuantityCollection[3]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[3].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[3] = value;
                    FieldDataChange("ForecastMonth04Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth05Quantity
        {
            get { return _forecastReportQuantityCollection[4]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[4].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[4] = value;
                    FieldDataChange("ForecastMonth05Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth06Quantity
        {
            get { return _forecastReportQuantityCollection[5]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[5].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[5] = value;
                    FieldDataChange("ForecastMonth06Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth07Quantity
        {
            get { return _forecastReportQuantityCollection[6]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[6].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[6] = value;
                    FieldDataChange("ForecastMonth07Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth08Quantity
        {
            get { return _forecastReportQuantityCollection[7]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[7].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[7] = value;
                    FieldDataChange("ForecastMonth08Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth09Quantity
        {
            get { return _forecastReportQuantityCollection[8]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[8].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[8] = value;
                    FieldDataChange("ForecastMonth09Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth10Quantity
        {
            get { return _forecastReportQuantityCollection[9]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[9].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[9] = value;
                    FieldDataChange("ForecastMonth10Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth11Quantity
        {
            get { return _forecastReportQuantityCollection[10]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[10].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[10] = value;
                    FieldDataChange("ForecastMonth11Quantity", value);
                }
            }
        }

        public SqlInt32 ForecastMonth12Quantity
        {
            get { return _forecastReportQuantityCollection[11]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastReportQuantityCollection[11].CompareTo(value) != 0)
                {
                    _forecastReportQuantityCollection[11] = value;
                    FieldDataChange("ForecastMonth12Quantity", value);
                }
            }
        }
        #endregion

        [NotMapped]
        public SqlInt32[] ForecastReportQuantityCollection
        { get { return _forecastReportQuantityCollection; } }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<ForecastReportKey, ForecastReport>
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
