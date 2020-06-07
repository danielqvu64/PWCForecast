using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    public class ItemKey : AObjectKey
    {
        public SqlString ItemNumber;

        public ItemKey() { }

        public ItemKey(SqlString itemNumber)
        {
            ItemNumber = itemNumber;
        }

        public override string ToString()
        {
            return ItemNumber.ToString();
        }
    }

    /// <summary>
    /// Summary description for Item.
    /// </summary>
    [Serializable]
    public class Item : APersistenceObject, IRowVersion
    {
        private SqlString _itemNumber;
        private SqlString _itemDescription;
        private SqlString _productGroupCode;

        public Item() { }

        public Item(SqlString itemNumber)
        {
            ItemNumber = itemNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ItemKey); }
        }

        #region Mappped Members
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

        public SqlString ItemDescription
        {
            get { return _itemDescription; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_itemDescription.CompareTo(value) != 0)
                {
                    _itemDescription = value;
                    FieldDataChange("ItemDescription", value);
                }
            }
        }

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

        public SqlBytes RowVersion { get; set; }
        #endregion

        [NotMapped]
        public string ProductGroupCodeBinding
        {
            get { return _productGroupCode.IsNull ? string.Empty : _productGroupCode.Value; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_productGroupCode.CompareTo(value) != 0)
                {
                    _productGroupCode = value == string.Empty ? SqlString.Null : value;
                    FieldDataChange("ProductGroupCode", value);
                }
            }
        }

        public override bool Validate()
        {
            return (ObjectKey != null && !_itemNumber.IsNull);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<ItemKey, Item>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString itemNumber, SqlString itemDescription, SqlString productGroupCode, SqlString brandCode, SqlString productCategoryCode)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"ItemNumber", itemNumber},
                                               {"ItemDescription", itemDescription},
                                               {"ProductGroupCode", productGroupCode},
                                               {"BrandCode", brandCode},
                                               {"ProductCategoryCode", productCategoryCode}
                                           };
            }
        }
    }
}
