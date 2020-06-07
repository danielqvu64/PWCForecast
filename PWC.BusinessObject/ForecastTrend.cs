using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;
using PWC.PersistenceInterface;

namespace PWC.BusinessObject
{
    /// <summary>
    /// Summary description for AForecastTrendFactor.
    /// </summary>
    [Serializable]
    public abstract class AForecastTrend : APersistenceObject, IForecastTrendValue
    {
        private SqlDecimal _factorMonth01;
        private SqlDecimal _factorMonth02;
        private SqlDecimal _factorMonth03;
        private SqlDecimal _factorMonth04;
        private SqlDecimal _factorMonth05;
        private SqlDecimal _factorMonth06;
        private SqlDecimal _factorMonth07;
        private SqlDecimal _factorMonth08;
        private SqlDecimal _factorMonth09;
        private SqlDecimal _factorMonth10;
        private SqlDecimal _factorMonth11;
        private SqlDecimal _factorMonth12;

        #region Mapped Members
        public SqlDecimal FactorMonth01
        {
            get { return _factorMonth01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth01.CompareTo(value) != 0)
                {
                    _factorMonth01 = value;
                    FieldDataChange("FactorMonth01", value);
                }
            }
        }

        public SqlDecimal FactorMonth02
        {
            get { return _factorMonth02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth02.CompareTo(value) != 0)
                {
                    _factorMonth02 = value;
                    FieldDataChange("FactorMonth02", value);
                }
            }
        }

        public SqlDecimal FactorMonth03
        {
            get { return _factorMonth03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth03.CompareTo(value) != 0)
                {
                    _factorMonth03 = value;
                    FieldDataChange("FactorMonth03", value);
                }
            }
        }

        public SqlDecimal FactorMonth04
        {
            get { return _factorMonth04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth04.CompareTo(value) != 0)
                {
                    _factorMonth04 = value;
                    FieldDataChange("FactorMonth04", value);
                }
            }
        }

        public SqlDecimal FactorMonth05
        {
            get { return _factorMonth05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth05.CompareTo(value) != 0)
                {
                    _factorMonth05 = value;
                    FieldDataChange("FactorMonth05", value);
                }
            }
        }

        public SqlDecimal FactorMonth06
        {
            get { return _factorMonth06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth06.CompareTo(value) != 0)
                {
                    _factorMonth06 = value;
                    FieldDataChange("FactorMonth06", value);
                }
            }
        }

        public SqlDecimal FactorMonth07
        {
            get { return _factorMonth07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth07.CompareTo(value) != 0)
                {
                    _factorMonth07 = value;
                    FieldDataChange("FactorMonth07", value);
                }
            }
        }

        public SqlDecimal FactorMonth08
        {
            get { return _factorMonth08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth08.CompareTo(value) != 0)
                {
                    _factorMonth08 = value;
                    FieldDataChange("FactorMonth08", value);
                }
            }
        }

        public SqlDecimal FactorMonth09
        {
            get { return _factorMonth09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth09.CompareTo(value) != 0)
                {
                    _factorMonth09 = value;
                    FieldDataChange("FactorMonth09", value);
                }
            }
        }

        public SqlDecimal FactorMonth10
        {
            get { return _factorMonth10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth10.CompareTo(value) != 0)
                {
                    _factorMonth10 = value;
                    FieldDataChange("FactorMonth10", value);
                }
            }
        }

        public SqlDecimal FactorMonth11
        {
            get { return _factorMonth11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth11.CompareTo(value) != 0)
                {
                    _factorMonth11 = value;
                    FieldDataChange("FactorMonth11", value);
                }
            }
        }

        public SqlDecimal FactorMonth12
        {
            get { return _factorMonth12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_factorMonth12.CompareTo(value) != 0)
                {
                    _factorMonth12 = value;
                    FieldDataChange("FactorMonth12", value);
                }
            }
        }
        #endregion
    }

    [Serializable]
    public class ForecastTrendByCompanyItemKey : CompanyKey
    {
        public SqlString ItemNumber;
        public SqlString ForecastMethod;

        public ForecastTrendByCompanyItemKey() { }

        public ForecastTrendByCompanyItemKey(SqlString companyCode, SqlString itemNumber, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString()).Append("|").Append(ForecastMethod.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastTrendByCompanyItem.
    /// </summary>
    [Serializable]
    public class ForecastTrendByCompanyItem : AForecastTrend, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _itemNumber;
        private SqlString _forecastMethod;

        public ForecastTrendByCompanyItem() { }

        public ForecastTrendByCompanyItem(SqlString companyCode, SqlString itemNumber, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastTrendByCompanyItemKey); }
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

        public SqlBytes RowVersion { get; set; }
        #endregion

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_itemNumber.IsNull &&
                !_forecastMethod.IsNull);
        }

        [Serializable]
        public class WithCompanyParentCollection : APersistenceObjectWithParentCollection<ForecastTrendByCompanyItemKey, ForecastTrendByCompanyItem>
        {
            public WithCompanyParentCollection() { }

            public WithCompanyParentCollection(Company parent)
            {
                Parent = parent;
            }

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<ForecastTrendByCompanyItem>
            {
                public int Compare(ForecastTrendByCompanyItem x, ForecastTrendByCompanyItem y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            protected class comparer_ForecastMethod : IComparer<ForecastTrendByCompanyItem>
            {
                public int Compare(ForecastTrendByCompanyItem x, ForecastTrendByCompanyItem y)
                {
                    return x.ForecastMethod.CompareTo(y.ForecastMethod);
                }
            }
            #endregion
        }
    }

    [Serializable]
    public class ForecastTrendByCompanyProductGroupKey : CompanyKey
    {
        public SqlString ProductGroupCode;
        public SqlString ForecastMethod;

        public ForecastTrendByCompanyProductGroupKey() { }

        public ForecastTrendByCompanyProductGroupKey(SqlString companyCode, SqlString productGroupCode, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            ProductGroupCode = productGroupCode;
            ForecastMethod = forecastMethod;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append("|").Append(ProductGroupCode.ToString()).Append("|").Append(ForecastMethod.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastTrendByCompanyProductGroup.
    /// </summary>
    [Serializable]
    public class ForecastTrendByCompanyProductGroup : AForecastTrend, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _productGroupCode;
        private SqlString _forecastMethod;

        public ForecastTrendByCompanyProductGroup() { }

        public ForecastTrendByCompanyProductGroup(SqlString companyCode, SqlString productGroupCode, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            ProductGroupCode = productGroupCode;
            ForecastMethod = forecastMethod;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastTrendByCompanyProductGroupKey); }
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

        public SqlBytes RowVersion { get; set; }
        #endregion

        [NotMapped]
        public string ProductGroupCodeBinding
        {
            get
            {
                return _productGroupCode.IsNull ? string.Empty : _productGroupCode.Value;
            }
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
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_productGroupCode.IsNull &&
                !_forecastMethod.IsNull);
        }

        [Serializable]
        public class WithCompanyParentCollection : APersistenceObjectWithParentCollection<ForecastTrendByCompanyProductGroupKey, ForecastTrendByCompanyProductGroup>
        {
            public WithCompanyParentCollection() { }

            public WithCompanyParentCollection(Company company)
            {
                Parent = company;
            }

            #region Comparer Classes
            protected class comparer_ProductGroupCodeBinding : IComparer<ForecastTrendByCompanyProductGroup>
            {
                public int Compare(ForecastTrendByCompanyProductGroup x, ForecastTrendByCompanyProductGroup y)
                {
                    return x.ProductGroupCodeBinding.CompareTo(y.ProductGroupCodeBinding);
                }
            }

            protected class comparer_ForecastMethod : IComparer<ForecastTrendByCompanyProductGroup>
            {
                public int Compare(ForecastTrendByCompanyProductGroup x, ForecastTrendByCompanyProductGroup y)
                {
                    return x.ForecastMethod.CompareTo(y.ForecastMethod);
                }
            }
            #endregion
        }
    }

    [Serializable]
    public class ForecastTrendProductGroupItemKey : AObjectKey
    {
        public SqlString ItemNumber;
        public SqlString ForecastMethod;

        public ForecastTrendProductGroupItemKey() { }

        public ForecastTrendProductGroupItemKey(SqlString itemNumber, SqlString forecastMethod)
        {
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        public override string ToString()
        {
            return new StringBuilder(ItemNumber.ToString()).Append("|").Append(ForecastMethod.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastTrendProductGroupItem.
    /// </summary>
    [Serializable]
    public class ForecastTrendProductGroupItem : AForecastTrend
    {
        private SqlString _itemNumber;
        private SqlString _forecastMethod;

        public ForecastTrendProductGroupItem() { }

        public ForecastTrendProductGroupItem(SqlString itemNumber, SqlString forecastMethod)
        {
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastTrendProductGroupItemKey); }
        }

        #region Mapped Members
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
        #endregion

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_itemNumber.IsNull &&
                !_forecastMethod.IsNull);
        }

        [Serializable]
        public class ByCustomerParameteredCollection : APersistenceObjectCollection<ForecastTrendProductGroupItemKey, ForecastTrendProductGroupItem>
        {
            public ByCustomerParameteredCollection() { }

            public ByCustomerParameteredCollection(Customer customer)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", customer.CompanyCode},
                                               {"CustomerNumber", customer.CustomerNumber}
                                           };
            }
        }

        [Serializable]
        public class ByCompanyParameteredCollection : APersistenceObjectCollection<ForecastTrendProductGroupItemKey, ForecastTrendProductGroupItem>
        {
            public ByCompanyParameteredCollection() { }

            public ByCompanyParameteredCollection(Customer customer)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", customer.CompanyCode},
                                               {"CustomerNumber", customer.CustomerNumber}
                                           };
            }
        }
    }

    [Serializable]
    public class ForecastTrendByCustomerItemKey : CustomerKey
    {
        public SqlString ItemNumber;
        public SqlString ForecastMethod;

        public ForecastTrendByCustomerItemKey() { }

        public ForecastTrendByCustomerItemKey(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString()).Append("|").Append(ForecastMethod.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastTrendByCustomerItem.
    /// </summary>
    [Serializable]
    public class ForecastTrendByCustomerItem : AForecastTrend, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _itemNumber;
        private SqlString _forecastMethod;

        public ForecastTrendByCustomerItem() { }

        public ForecastTrendByCustomerItem(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastTrendByCustomerItemKey); }
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

        public SqlBytes RowVersion { get; set; }
        #endregion

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull &&
                !_itemNumber.IsNull &&
                !_forecastMethod.IsNull);
        }

        [Serializable]
        public class WithCustomerParentCollection : APersistenceObjectWithParentCollection<ForecastTrendByCustomerItemKey, ForecastTrendByCustomerItem>
        {
            public WithCustomerParentCollection() { }

            public WithCustomerParentCollection(Customer parent)
            {
                Parent = parent;
            }

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<ForecastTrendByCustomerItem>
            {
                public int Compare(ForecastTrendByCustomerItem x, ForecastTrendByCustomerItem y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            protected class comparer_ForecastMethod : IComparer<ForecastTrendByCustomerItem>
            {
                public int Compare(ForecastTrendByCustomerItem x, ForecastTrendByCustomerItem y)
                {
                    return x.ForecastMethod.CompareTo(y.ForecastMethod);
                }
            }
            #endregion
        }
    }

    [Serializable]
    public class ForecastTrendByCustomerProductGroupKey : CustomerKey
    {
        public SqlString ProductGroupCode;
        public SqlString ForecastMethod;

        public ForecastTrendByCustomerProductGroupKey() { }

        public ForecastTrendByCustomerProductGroupKey(SqlString companyCode, SqlString customerNumber, SqlString productGroupCode, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ProductGroupCode = productGroupCode;
            ForecastMethod = forecastMethod;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append("|").Append(ProductGroupCode.ToString()).Append("|").Append(ForecastMethod.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastTrendByCustomerProductGroup.
    /// </summary>
    [Serializable]
    public class ForecastTrendByCustomerProductGroup : AForecastTrend, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _productGroupCode;
        private SqlString _forecastMethod;

        public ForecastTrendByCustomerProductGroup() { }

        public ForecastTrendByCustomerProductGroup(SqlString companyCode, SqlString customerNumber, SqlString productGroupCode, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ProductGroupCode = productGroupCode;
            ForecastMethod = forecastMethod;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastTrendByCustomerProductGroupKey); }
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

        public SqlBytes RowVersion { get; set; }
        #endregion

        [NotMapped]
        public string ProductGroupCodeBinding
        {
            get
            {
                return _productGroupCode.IsNull ? string.Empty : _productGroupCode.Value;
            }
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
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull &&
                !_productGroupCode.IsNull &&
                !_forecastMethod.IsNull);
        }

        [Serializable]
        public class WithCustomerParentCollection : APersistenceObjectWithParentCollection<ForecastTrendByCustomerProductGroupKey, ForecastTrendByCustomerProductGroup>
        {
            public WithCustomerParentCollection() { }

            public WithCustomerParentCollection(Customer parent)
            {
                Parent = parent;
            }

            #region Comparer Classes
            protected class comparer_ProductGroupCodeBinding : IComparer<ForecastTrendByCustomerProductGroup>
            {
                public int Compare(ForecastTrendByCustomerProductGroup x, ForecastTrendByCustomerProductGroup y)
                {
                    return x.ProductGroupCodeBinding.CompareTo(y.ProductGroupCodeBinding);
                }
            }

            protected class comparer_ForecastMethod : IComparer<ForecastTrendByCustomerProductGroup>
            {
                public int Compare(ForecastTrendByCustomerProductGroup x, ForecastTrendByCustomerProductGroup y)
                {
                    return x.ForecastMethod.CompareTo(y.ForecastMethod);
                }
            }
            #endregion
        }
    }
}
