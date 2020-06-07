using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    public class ProductCategoryKey : AObjectKey
    {
        public SqlString ProductCategoryCode;

        public ProductCategoryKey() { }

        public ProductCategoryKey(SqlString productCategoryCode)
        {
            ProductCategoryCode = productCategoryCode;
        }

        public override string ToString()
        {
            return ProductCategoryCode.ToString();
        }
    }

    /// <summary>
    /// Summary description for ProductCategory.
    /// </summary>
    [Serializable]
    public class ProductCategory : APersistenceObject, IRowVersion
    {
        private SqlString _productCategoryCode;
        private SqlString _productCategoryDescription;

        public ProductCategory() { }

        public ProductCategory(SqlString productCategoryCode)
        {
            ProductCategoryCode = productCategoryCode;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ProductCategoryKey); }
        }

        #region Mapped Members
        public SqlString ProductCategoryCode
        {
            get { return _productCategoryCode; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_productCategoryCode.CompareTo(value) != 0)
                {
                    _productCategoryCode = value;
                    FieldDataChange("ProductCategoryCode", value);
                }
            }
        }

        public SqlString ProductCategoryDescription
        {
            get { return _productCategoryDescription; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_productCategoryDescription.CompareTo(value) != 0)
                {
                    _productCategoryDescription = value;
                    FieldDataChange("ProductCategoryDescription", value);
                }
            }
        }

        public SqlBytes RowVersion { get; set; }
        #endregion

        public override bool Validate()
        {
            return (ObjectKey != null &&
                !_productCategoryCode.IsNull &&
                !_productCategoryDescription.IsNull);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<ProductCategoryKey, ProductCategory>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString productCategoryCode, SqlString productCategoryDescription)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"ProductCategoryCode", productCategoryCode},
                                               {"ProductCategoryDescription", productCategoryDescription}
                                           };
            }
        }
    }
}
