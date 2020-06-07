using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ActualSalesLatestDateAndGapKey : CustomerKey
    {
        public ActualSalesLatestDateAndGapKey() { }

        public ActualSalesLatestDateAndGapKey(SqlString companyCode, SqlString customerNumber) : base(companyCode, customerNumber) { }
    }

    /// <summary>
    /// Summary description for ActualSalesLatestDateAndGap.
    /// </summary>
    [Serializable]
    public class ActualSalesLatestDateAndGap : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _latestActualSalesEndDate;
        private SqlByte _rollingAverageNumberOfMonths;
        private SqlBoolean _gapFlag;

        public ActualSalesLatestDateAndGap() { }

        public ActualSalesLatestDateAndGap(SqlString companyCode, SqlString customerNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ActualSalesLatestDateAndGapKey); }
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

        public SqlString CustomerNumber
        {
            get { return _customerNumber; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_customerNumber.CompareTo(value) != 0)
                {
                    _customerNumber = value;
                    FieldDataChange("CustomerNumber", value);
                }
            }
        }

        public SqlDateTime LatestActualSalesEndDate
        {
            get { return _latestActualSalesEndDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_latestActualSalesEndDate.CompareTo(value) != 0)
                {
                    _latestActualSalesEndDate = value;
                    FieldDataChange("LatestActualSalesEndDate", value);
                }
            }
        }

        public SqlByte RollingAverageNumberOfMonths
        {
            get { return _rollingAverageNumberOfMonths; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_rollingAverageNumberOfMonths.CompareTo(value) != 0)
                {
                    _rollingAverageNumberOfMonths = value;
                    FieldDataChange("RollingAverageNumberOfMonths", value);
                }
            }
        }
        
        public SqlBoolean GapFlag
        {
            get { return _gapFlag; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_gapFlag.CompareTo(value) != 0)
                {
                    _gapFlag = value;
                    FieldDataChange("GapFlag", value);
                }
            }
        }
        #endregion

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<ActualSalesLatestDateAndGapKey, ActualSalesLatestDateAndGap>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString companyCode, SqlString customerNumber, SqlDateTime actualSalesEndDate, SqlByte rollingAverageNumberOfMonths)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                                {"CompanyCode", companyCode},
                                                {"CustomerNumber", customerNumber},
                                                {"ActualSalesEndDate", actualSalesEndDate},
                                                {"RollingAverageNumberOfMonths", rollingAverageNumberOfMonths}
                                           };
            }
        }
    }
}
