using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class POSKey : CustomerKey
    {
        public SqlString ItemNumber;
        public SqlDateTime WeekEndDate;

        public POSKey() { }

        public POSKey(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime weekEndDate)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            WeekEndDate = weekEndDate;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString()).Append("|");
            sb.Append(WeekEndDate.IsNull ? WeekEndDate.ToString() : WeekEndDate.Value.ToString("MM/dd/yyyy"));
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for POS.
    /// </summary>
    [Serializable]
    public class POS : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _itemNumber;
        private SqlDateTime _weekEndDate;
        private SqlInt32 _quantity;

        public POS() { }

        public POS(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime weekEndDate)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            WeekEndDate = weekEndDate;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(POSKey); }
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

        public SqlString ItemNumber
        {
            get { return _itemNumber; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_itemNumber.CompareTo(value) != 0)
                {
                    _itemNumber = value;
                    FieldDataChange("ItemNumber", value);
                }
            }
        }

        public SqlDateTime WeekEndDate
        {
            get { return _weekEndDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_weekEndDate.CompareTo(value) != 0)
                {
                    _weekEndDate = value;
                    FieldDataChange("WeekEndDate", value);
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

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull &&
                !_itemNumber.IsNull &&
                !_weekEndDate.IsNull);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<POSKey, POS>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime weekEndDate)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", companyCode},
                                               {"CustomerNumber", customerNumber},
                                               {"ItemNumber", itemNumber},
                                               {"WeekEndDate", weekEndDate}
                                           };
            }
        }
    }
}
