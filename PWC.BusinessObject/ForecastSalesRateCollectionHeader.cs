using System;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.BusinessObject;
using DVu.Library.PersistenceInterface;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastSalesRateCollectionKey : CustomerKey
    {
        public SqlDateTime POSSalesEndDate;

        public ForecastSalesRateCollectionKey() { }

        public ForecastSalesRateCollectionKey(SqlString companyCode, SqlString customerNumber, SqlDateTime posWeekEndDateEnd)
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
    public class ForecastSalesRateCollectionHeader : APersistenceObject, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _posSalesEndDate;
        private SqlInt16 _posNumberOfWeeks;

        public ForecastSalesRateCollectionHeader() { }

        public ForecastSalesRateCollectionHeader(SqlString companyCode, SqlString customerNumber, SqlDateTime posSalesEndDate, SqlInt16 posNumberOfWeeks)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posSalesEndDate;
            POSNumberOfWeeks = posNumberOfWeeks;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastSalesRateCollectionKey); }
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

        public SqlInt16 POSNumberOfWeeks
        {
            get { return _posNumberOfWeeks; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_posNumberOfWeeks.CompareTo(value) != 0)
                {
                    _posNumberOfWeeks = value;
                    FieldDataChange("POSNumberOfWeeks", value);
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
