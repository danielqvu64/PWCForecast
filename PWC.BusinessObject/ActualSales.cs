using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ActualSalesKey : CustomerKey
    {
        public SqlString ItemNumber;
        public SqlDateTime Month;

        public ActualSalesKey() { }

        public ActualSalesKey(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime month)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            Month = month;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString()).Append("|");
            sb.Append(Month.IsNull ? Month.ToString() : Month.Value.ToString("MM/dd/yyyy"));
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for ActualSales.
    /// </summary>
    [Serializable]
    public class ActualSales : APersistenceObject
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _itemNumber;
        private SqlDateTime _month;
        private SqlInt32 _quantity;

        public ActualSales() { }

        public ActualSales(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime month)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
            Month = month;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ActualSalesKey); }
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

        public SqlDateTime Month
        {
            get { return _month; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_month.CompareTo(value) != 0)
                {
                    _month = value;
                    FieldDataChange("Month", value);
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
                !_month.IsNull);
        }

        [Serializable]
        public class WithCustomerParentParameteredCollection : APersistenceObjectWithParentCollection<ActualSalesKey, ActualSales>
        {
            public WithCustomerParentParameteredCollection() { }

            public WithCustomerParentParameteredCollection(Customer parent, SqlDateTime beginDate, SqlDateTime endDate)
            {
                Parent = parent;
                ParameterCollection = new HybridDictionary {{"BeginDate", beginDate}, {"EndDate", endDate}};
            }
        }

        //[Serializable]
        //public class WithCustomerParentParameteredCommandTextCollection : APersistenceObjectWithParentCollection<ActualSalesKey, ActualSales>
        //{
        //    private Customer parent;
        //    private string commandText;
        //    private SqlDateTime beginDate;
        //    private SqlDateTime endDate;
        //    private HybridDictionary parameters = new HybridDictionary();

        //    public WithCustomerParentParameteredCommandTextCollection(Customer parent, string commandText, SqlDateTime beginDate, SqlDateTime endDate)
        //    {
        //        this.parent = parent;
        //        this.commandText = commandText;
        //        this.beginDate = beginDate;
        //        this.endDate = endDate;
        //    }

        //    public Customer Parent
        //    { get { return parent; } }

        //    public string CommandText
        //    { get { return commandText; } }

        //    public SqlDateTime BeginDate
        //    { get { return beginDate; } }

        //    public SqlDateTime EndDate
        //    { get { return endDate; } }

        //    private void GetParameters()
        //    {
        //        parameters.Add("company_code", parent.CompanyCode);
        //        parameters.Add("customer_number", parent.CustomerName);
        //        parameters.Add("begin_date", beginDate.Value.ToString("MM/dd/yy"));
        //        parameters.Add("end_date", endDate.Value.ToString("MM/dd/yy"));
        //    }

        //    protected override object[] PersistenceLayerObjectCollection
        //    {
        //        get
        //        {
        //            GetParameters();
        //            return ((IActualSalesCollection)PersistenceFacade.GetInstance().Get(this.GetType(), commandText, parameters)).ActualSalesCollection;
        //        }
        //    }
        //}
    }
}
