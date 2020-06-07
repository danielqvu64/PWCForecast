using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    public class ProductGroupKey : AObjectKey
    {
        public SqlString ProductGroupCode;

        public ProductGroupKey() { }

        public ProductGroupKey(SqlString productGroupCode)
        {
            ProductGroupCode = productGroupCode;
        }

        public override string ToString()
        {
            return ProductGroupCode.ToString();
        }
    }

    /// <summary>
    /// Summary description for ProductGroup.
    /// </summary>
    [Serializable]
    public class ProductGroup : APersistenceObject, IRowVersion
    {
        private SqlString _productGroupCode;
        private SqlString _productGroupDescription;

        public ProductGroup() { }

        public ProductGroup(SqlString productGroupCode)
        {
            ProductGroupCode = productGroupCode;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ProductGroupKey); }
        }

        #region Mapped Members
        public SqlString ProductGroupCode
        {
            get { return _productGroupCode; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_productGroupCode.CompareTo(value) != 0)
                {
                    _productGroupCode = value;
                    FieldDataChange("ProductGroupCode", value);
                }
            }
        }

        public SqlString ProductGroupDescription
        {
            get { return _productGroupDescription; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_productGroupDescription.CompareTo(value) != 0)
                {
                    _productGroupDescription = value;
                    FieldDataChange("ProductGroupDescription", value);
                }
            }
        }

        public SqlBytes RowVersion { get; set; }
        #endregion

        [NotMapped]
        public string BrandCode
        {
            get { return _productGroupCode.IsNull ? string.Empty : _productGroupCode.ToString().Substring(0, 2); }
            set
            {
                if (_productGroupCode.IsNull)
                    _productGroupCode = value;
                else
                    _productGroupCode = string.Format("{0}{1}", value, _productGroupCode.ToString().Substring(2, 2));
            }
        }

        [NotMapped]
        public string ProductCategoryCode
        {
            get { return _productGroupCode.IsNull ? string.Empty : (_productGroupCode.ToString().Length == 4 ? _productGroupCode.ToString().Substring(2, 2) : string.Empty); }
            set
            {
                if (_productGroupCode.IsNull)
                    _productGroupCode = string.Format("  {0}", value);
                else
                    _productGroupCode = string.Format("{0}{1}", _productGroupCode.ToString().Substring(0, 2), value);
            }
        }

        public override bool Validate()
        {
            return (ObjectKey != null &&
                !_productGroupCode.IsNull &&
                !_productGroupDescription.IsNull);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<ProductGroupKey, ProductGroup>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString productGroupCode, SqlString brandCode, SqlString productCategoryCode, SqlString productGroupDescription)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"ProductGroupCode", productGroupCode},
                                               {"BrandCode", brandCode},
                                               {"ProductCategoryCode", productCategoryCode},
                                               {"ProductGroupDescription", productGroupDescription}
                                           };
            }
        }
    }
}
