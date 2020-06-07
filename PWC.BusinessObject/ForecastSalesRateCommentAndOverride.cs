using System;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.BusinessObject;
using DVu.Library.PersistenceInterface;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastSalesRateCommentAndOverrideKey : ForecastSalesRateKey
    {
        public SqlDateTime CommentOverrideDateTime;

        public ForecastSalesRateCommentAndOverrideKey() { }

        public ForecastSalesRateCommentAndOverrideKey(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime posWeekEndDateEnd, SqlDateTime commentOverrideDateTime)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            POSSalesEndDate = posWeekEndDateEnd;
            CommentOverrideDateTime = commentOverrideDateTime;
        }

        public ForecastSalesRateCommentAndOverrideKey(ForecastSalesRateKey forecastSalesRateKey, SqlDateTime commentOverrideDateTime)
        {
            CompanyCode = forecastSalesRateKey.CompanyCode;
            CustomerNumber = forecastSalesRateKey.CustomerNumber;
            ItemNumber = forecastSalesRateKey.ItemNumber;
            POSSalesEndDate = forecastSalesRateKey.POSSalesEndDate;
            CommentOverrideDateTime = commentOverrideDateTime;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.Append("|").Append(CommentOverrideDateTime.IsNull ? CommentOverrideDateTime.ToString() : CommentOverrideDateTime.Value.ToString("G"));
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastSalesRateCommentAndOverride.
    /// </summary>
    [Serializable]
    public class ForecastSalesRateCommentAndOverride : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _itemNumber;
        private SqlDateTime _posSalesEndDate;
        private SqlDateTime _commentOverrideDateTime;
        private SqlString _comment;
        private SqlBoolean _isOverride;

        public ForecastSalesRateCommentAndOverride() { }

        public ForecastSalesRateCommentAndOverride(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime posSalesEndDate, SqlDateTime commentOverrideDateTime)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            POSSalesEndDate = posSalesEndDate;
            CommentOverrideDateTime = commentOverrideDateTime;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastSalesRateCommentAndOverrideKey); }
        }

        [NotMapped]
        public string CommentDisplay
        {
            get { return string.Format("{0}:{1}{2}{3}{4}", CommentOverrideDateTime, Environment.NewLine, Comment, Environment.NewLine, Environment.NewLine); }
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

        public SqlDateTime CommentOverrideDateTime
        {
            get { return _commentOverrideDateTime; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_commentOverrideDateTime.CompareTo(value) != 0)
                {
                    _commentOverrideDateTime = value;
                    FieldDataChange("CommentOverrideDateTime", value);
                }
            }
        }
        public SqlString Comment
        {
            get { return _comment; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_comment.CompareTo(value) != 0)
                {
                    _comment = value;
                    FieldDataChange("Comment", value);
                }
            }
        }

        public SqlBoolean IsOverride
        {
            get { return _isOverride.IsNull ? SqlBoolean.False : _isOverride; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_isOverride.CompareTo(value) != 0)
                {
                    _isOverride = value;
                    FieldDataChange("IsOverride", value);
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
                    !_posSalesEndDate.IsNull &&
                    !_commentOverrideDateTime.IsNull);
        }

        [Serializable]
        public class WithForecastSalesRateParentCollection : APersistenceObjectWithParentCollection<ForecastSalesRateCommentAndOverrideKey, ForecastSalesRateCommentAndOverride>
        {
            public WithForecastSalesRateParentCollection() { }

            public WithForecastSalesRateParentCollection(ForecastSalesRate parent)
            {
                Parent = parent;
            }
        }
    }
}
