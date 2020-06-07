using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    public class BrandKey : AObjectKey
    {
        public SqlString BrandCode;

        public BrandKey() { }

        public BrandKey(SqlString brandCode)
        {
            BrandCode = brandCode;
        }

        public override string ToString()
        {
            return BrandCode.ToString();
        }
    }
    
    /// <summary>
    /// Summary description for Brand.
    /// </summary>
    [Serializable]
    public class Brand : APersistenceObject, IRowVersion
    {
        private SqlString _brandCode;
        private SqlString _brandDescription;

        public Brand() { }

        public Brand(SqlString brandCode)
        {
            BrandCode = brandCode;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(BrandKey); }
        }

        #region Mapped Members
        public SqlString BrandCode
        {
            get { return _brandCode; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_brandCode.CompareTo(value) != 0)
                {
                    _brandCode = value;
                    FieldDataChange("BrandCode", value);
                }
            }
        }

        public SqlString BrandDescription
        {
            get { return _brandDescription; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_brandDescription.CompareTo(value) != 0)
                {
                    _brandDescription = value;
                    FieldDataChange("BrandDescription", value);
                }
            }
        }

        public SqlBytes RowVersion { get; set; }
        #endregion

        public override bool Validate()
        {
            return (ObjectKey != null && !_brandDescription.IsNull);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<BrandKey, Brand>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString brandCode, SqlString brandDescription)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"BrandCode", brandCode},
                                               {"BrandDescription", brandDescription}
                                           };
            }
        }
    }
}
