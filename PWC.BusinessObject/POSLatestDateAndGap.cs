using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class POSLatestDateAndGapKey : CustomerKey
    {
        public POSLatestDateAndGapKey() { }

        public POSLatestDateAndGapKey(SqlString companyCode, SqlString customerNumber) : base(companyCode, customerNumber) {}
    }

    /// <summary>
    /// Summary description for POSLatestDateAndGap.
    /// </summary>
    [Serializable]
    public class POSLatestDateAndGap : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _latestWeekEndDate;
        private SqlInt16 _numOfWeeks;
        private SqlBoolean _gapFlag;

        public POSLatestDateAndGap() { }

        public POSLatestDateAndGap(SqlString companyCode, SqlString customerNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(POSLatestDateAndGapKey); }
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

        public SqlDateTime LatestWeekEndDate
        {
            get { return _latestWeekEndDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_latestWeekEndDate.CompareTo(value) != 0)
                {
                    _latestWeekEndDate = value;
                    FieldDataChange("LatestWeekEndDate", value);
                }
            }
        }

        public SqlInt16 NumOfWeeks
        {
            get { return _numOfWeeks; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_numOfWeeks.CompareTo(value) != 0)
                {
                    _numOfWeeks = value;
                    FieldDataChange("NumOfWeeks", value);
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
        public class ParameteredCollection : APersistenceObjectCollection<POSLatestDateAndGapKey, POSLatestDateAndGap>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString companyCode, SqlString customerNumber, SqlDateTime weekEndDate, SqlInt16 numOfWeeks)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", companyCode},
                                               {"CustomerNumber", customerNumber},
                                               {"WeekEndDate", weekEndDate},
                                               {"NumOfWeeks", numOfWeeks}
                                           };
            }
        }
    }
}
