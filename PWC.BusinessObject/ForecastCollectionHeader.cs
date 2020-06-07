using System;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.BusinessObject;
using DVu.Library.PersistenceInterface;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastCollectionKey : CustomerKey
    {
        public SqlDateTime POSSalesEndDate;

        public ForecastCollectionKey() { }

        public ForecastCollectionKey(SqlString companyCode, SqlString customerNumber, SqlDateTime posWeekEndDateEnd)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posWeekEndDateEnd;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|");
            sb.Append(POSSalesEndDate.IsNull ? POSSalesEndDate.ToString() : POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
            return sb.ToString();
        }
    }

    [Serializable]
    public class ForecastCollectionHeader : APersistenceObject, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _posSalesEndDate;

        public ForecastCollectionHeader() { }

        public ForecastCollectionHeader(SqlString companyCode, SqlString customerNumber, SqlDateTime posSalesEndDate)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posSalesEndDate;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastCollectionKey); }
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

        public SqlDateTime POSSalesEndDate
        {
            get { return _posSalesEndDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_posSalesEndDate.CompareTo(value) != 0)
                {
                    _posSalesEndDate = value;
                    FieldDataChange("POSSalesEndDate", value);
                }
            }
        }

        public SqlBytes RowVersion { get; set; }
        #endregion

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull &&
                !_posSalesEndDate.IsNull);
        }
    }
}
