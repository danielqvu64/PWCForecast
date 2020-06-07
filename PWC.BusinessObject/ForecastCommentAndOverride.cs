using System;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.BusinessObject;
using DVu.Library.PersistenceInterface;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastCommentAndOverrideKey : ForecastKey
    {
        public SqlString ForecastValueKey;
        public SqlDateTime CommentOverrideDateTime;

        public ForecastCommentAndOverrideKey() { }

        public ForecastCommentAndOverrideKey(SqlString companyCode, SqlString customerNumber, SqlDateTime posWeekEndDateEnd, SqlString itemNumber, SqlString forecastMethod, SqlString forecastValueKey, SqlDateTime commentOverrideDateTime)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posWeekEndDateEnd;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
            ForecastValueKey = forecastValueKey;
            CommentOverrideDateTime = commentOverrideDateTime;
        }

        public ForecastCommentAndOverrideKey(ForecastKey forecastKey, SqlString forecastValueKey, SqlDateTime commentOverrideDateTime)
        {
            CompanyCode = forecastKey.CompanyCode;
            CustomerNumber = forecastKey.CustomerNumber;
            POSSalesEndDate = forecastKey.POSSalesEndDate;
            ItemNumber = forecastKey.ItemNumber;
            ForecastMethod = forecastKey.ForecastMethod;
            ForecastValueKey = forecastValueKey;
            CommentOverrideDateTime = commentOverrideDateTime;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.Append("|").Append(ForecastValueKey.ToString());
            sb.Append("|").Append(CommentOverrideDateTime.IsNull ? CommentOverrideDateTime.ToString() : CommentOverrideDateTime.Value.ToString("G"));
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastCommentAndOverride.
    /// </summary>
    [Serializable]
    public class ForecastCommentAndOverride : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _posSalesEndDate;
        private SqlString _itemNumber;
        private SqlString _forecastMethod;
        private SqlString _forecastValueKey;
        private SqlDateTime _commentOverrideDateTime;
        private SqlString _comment;
        private SqlBoolean _manualFlag;

        public ForecastCommentAndOverride() { }

        public ForecastCommentAndOverride(SqlString companyCode, SqlString customerNumber, SqlDateTime posSalesEndDate, SqlString itemNumber, SqlString forecastMethod, SqlString forecastValueKey, SqlDateTime commentOverrideDateTime)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posSalesEndDate;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
            ForecastValueKey = forecastValueKey;
            CommentOverrideDateTime = commentOverrideDateTime;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastCommentAndOverrideKey); }
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

        public SqlString ForecastMethod
        {
            get { return _forecastMethod; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastMethod.CompareTo(value) != 0)
                {
                    _forecastMethod = value;
                    FieldDataChange("ForecastMethod", value);
                }
            }
        }

        public SqlString ForecastValueKey
        {
            get { return _forecastValueKey; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastValueKey.CompareTo(value) != 0)
                {
                    _forecastValueKey = value;
                    FieldDataChange("ForecastValueKey", value);
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
            get { return _manualFlag.IsNull ? SqlBoolean.False : _manualFlag; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_manualFlag.CompareTo(value) != 0)
                {
                    _manualFlag = value;
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
                    !_posSalesEndDate.IsNull &&
                    !_itemNumber.IsNull &&
                    !_forecastMethod.IsNull &&
                    !_forecastValueKey.IsNull &&
                    !_commentOverrideDateTime.IsNull);
        }

        [Serializable]
        public class WithForecastParentCollection : APersistenceObjectWithParentCollection<ForecastCommentAndOverrideKey, ForecastCommentAndOverride>
        {
            public WithForecastParentCollection() { }

            public WithForecastParentCollection(Forecast parent)
            {
                Parent = parent;
            }
        }
    }
}
