using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using PWC.PersistenceInterface;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    /// <summary>
    /// Summary description for ABonusAndDiscontinued.
    /// </summary>
    [Serializable]
    public abstract class ABonusAndDiscontinued : APersistenceObject, IThreeYearMonthlyIntegerValue
    {
        private readonly SqlInt32[] _bonusNumOfDaysCollection = new SqlInt32[36];

        #region IThreeYearMonthlyIntegerValue Members
        [NotMapped]
        public SqlInt32[] BonusNumOfDaysCollection
        { get { return _bonusNumOfDaysCollection; } }
        
        public SqlInt32 PY01
        {
            get { return _bonusNumOfDaysCollection[0]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[0].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[0] = value;
                    FieldDataChange("PY01", value);
                }
            }
        }

        public SqlInt32 PY02
        {
            get { return _bonusNumOfDaysCollection[1]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[1].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[1] = value;
                    FieldDataChange("PY02", value);
                }
            }
        }

        public SqlInt32 PY03
        {
            get { return _bonusNumOfDaysCollection[2]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[2].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[2] = value;
                    FieldDataChange("PY03", value);
                }
            }
        }

        public SqlInt32 PY04
        {
            get { return _bonusNumOfDaysCollection[3]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[3].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[3] = value;
                    FieldDataChange("PY04", value);
                }
            }
        }

        public SqlInt32 PY05
        {
            get { return _bonusNumOfDaysCollection[4]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[4].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[4] = value;
                    FieldDataChange("PY05", value);
                }
            }
        }

        public SqlInt32 PY06
        {
            get { return _bonusNumOfDaysCollection[5]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[5].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[5] = value;
                    FieldDataChange("PY06", value);
                }
            }
        }

        public SqlInt32 PY07
        {
            get { return _bonusNumOfDaysCollection[6]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[6].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[6] = value;
                    FieldDataChange("PY07", value);
                }
            }
        }

        public SqlInt32 PY08
        {
            get { return _bonusNumOfDaysCollection[7]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[7].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[7] = value;
                    FieldDataChange("PY08", value);
                }
            }
        }

        public SqlInt32 PY09
        {
            get { return _bonusNumOfDaysCollection[8]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[8].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[8] = value;
                    FieldDataChange("PY09", value);
                }
            }
        }

        public SqlInt32 PY10
        {
            get { return _bonusNumOfDaysCollection[9]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[9].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[9] = value;
                    FieldDataChange("PY10", value);
                }
            }
        }

        public SqlInt32 PY11
        {
            get { return _bonusNumOfDaysCollection[10]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[10].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[10] = value;
                    FieldDataChange("PY11", value);
                }
            }
        }

        public SqlInt32 PY12
        {
            get { return _bonusNumOfDaysCollection[11]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[11].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[11] = value;
                    FieldDataChange("PY12", value);
                }
            }
        }

        public SqlInt32 CY01
        {
            get { return _bonusNumOfDaysCollection[12]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[12].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[12] = value;
                    FieldDataChange("CY01", value);
                }
            }
        }

        public SqlInt32 CY02
        {
            get { return _bonusNumOfDaysCollection[13]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[13].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[13] = value;
                    FieldDataChange("CY02", value);
                }
            }
        }

        public SqlInt32 CY03
        {
            get { return _bonusNumOfDaysCollection[14]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[14].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[14] = value;
                    FieldDataChange("CY03", value);
                }
            }
        }

        public SqlInt32 CY04
        {
            get { return _bonusNumOfDaysCollection[15]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[15].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[15] = value;
                    FieldDataChange("CY04", value);
                }
            }
        }

        public SqlInt32 CY05
        {
            get { return _bonusNumOfDaysCollection[16]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[16].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[16] = value;
                    FieldDataChange("CY05", value);
                }
            }
        }

        public SqlInt32 CY06
        {
            get { return _bonusNumOfDaysCollection[17]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[17].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[17] = value;
                    FieldDataChange("CY06", value);
                }
            }
        }

        public SqlInt32 CY07
        {
            get { return _bonusNumOfDaysCollection[18]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[18].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[18] = value;
                    FieldDataChange("CY07", value);
                }
            }
        }

        public SqlInt32 CY08
        {
            get { return _bonusNumOfDaysCollection[19]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[19].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[19] = value;
                    FieldDataChange("CY08", value);
                }
            }
        }

        public SqlInt32 CY09
        {
            get { return _bonusNumOfDaysCollection[20]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[20].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[20] = value;
                    FieldDataChange("CY09", value);
                }
            }
        }

        public SqlInt32 CY10
        {
            get { return _bonusNumOfDaysCollection[21]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[21].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[21] = value;
                    FieldDataChange("CY10", value);
                }
            }
        }

        public SqlInt32 CY11
        {
            get { return _bonusNumOfDaysCollection[22]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[22].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[22] = value;
                    FieldDataChange("CY11", value);
                }
            }
        }

        public SqlInt32 CY12
        {
            get { return _bonusNumOfDaysCollection[23]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[23].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[23] = value;
                    FieldDataChange("CY12", value);
                }
            }
        }

        public SqlInt32 NY01
        {
            get { return _bonusNumOfDaysCollection[24]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[24].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[24] = value;
                    FieldDataChange("NY01", value);
                }
            }
        }

        public SqlInt32 NY02
        {
            get { return _bonusNumOfDaysCollection[25]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[25].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[25] = value;
                    FieldDataChange("NY02", value);
                }
            }
        }

        public SqlInt32 NY03
        {
            get { return _bonusNumOfDaysCollection[26]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[26].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[26] = value;
                    FieldDataChange("NY03", value);
                }
            }
        }

        public SqlInt32 NY04
        {
            get { return _bonusNumOfDaysCollection[27]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[27].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[27] = value;
                    FieldDataChange("NY04", value);
                }
            }
        }

        public SqlInt32 NY05
        {
            get { return _bonusNumOfDaysCollection[28]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[28].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[28] = value;
                    FieldDataChange("NY05", value);
                }
            }
        }

        public SqlInt32 NY06
        {
            get { return _bonusNumOfDaysCollection[29]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[29].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[29] = value;
                    FieldDataChange("NY06", value);
                }
            }
        }

        public SqlInt32 NY07
        {
            get { return _bonusNumOfDaysCollection[30]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[30].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[30] = value;
                    FieldDataChange("NY07", value);
                }
            }
        }

        public SqlInt32 NY08
        {
            get { return _bonusNumOfDaysCollection[31]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[31].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[31] = value;
                    FieldDataChange("NY08", value);
                }
            }
        }

        public SqlInt32 NY09
        {
            get { return _bonusNumOfDaysCollection[32]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[32].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[32] = value;
                    FieldDataChange("NY09", value);
                }
            }
        }

        public SqlInt32 NY10
        {
            get { return _bonusNumOfDaysCollection[33]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[33].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[33] = value;
                    FieldDataChange("NY10", value);
                }
            }
        }

        public SqlInt32 NY11
        {
            get { return _bonusNumOfDaysCollection[34]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[34].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[34] = value;
                    FieldDataChange("NY11", value);
                }
            }
        }

        public SqlInt32 NY12
        {
            get { return _bonusNumOfDaysCollection[35]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_bonusNumOfDaysCollection[35].CompareTo(value) != 0)
                {
                    _bonusNumOfDaysCollection[35] = value;
                    FieldDataChange("NY12", value);
                }
            }
        }
        #endregion
    }

    [Serializable]
    public class BonusAndDiscontinuedByCompanyKey : CompanyKey
    {
        public SqlString ItemNumber;

        public BonusAndDiscontinuedByCompanyKey() { }

        public BonusAndDiscontinuedByCompanyKey(SqlString companyCode, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            ItemNumber = itemNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for BonusAndDiscontinuedByCompany.
    /// </summary>
    [Serializable]
    public class BonusAndDiscontinuedByCompany : ABonusAndDiscontinued, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _itemNumber;
        private SqlDateTime _discontinuedEffectiveDate;

        public BonusAndDiscontinuedByCompany() { }

        public BonusAndDiscontinuedByCompany(SqlString companyCode, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            ItemNumber = itemNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(BonusAndDiscontinuedByCompanyKey); }
        }

        #region IBonusAndDiscontinuedByCompany Members
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

        public SqlDateTime DiscontinuedEffectiveDate
        {
            get { return _discontinuedEffectiveDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_discontinuedEffectiveDate.CompareTo(value) != 0)
                {
                    _discontinuedEffectiveDate = value;
                    FieldDataChange("DiscontinuedEffectiveDate", value);
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
                !_itemNumber.IsNull);
        }

        [Serializable]
        public class WithCompanyParentCollection : APersistenceObjectWithParentCollection<BonusAndDiscontinuedByCompanyKey, BonusAndDiscontinuedByCompany>
        {
            public WithCompanyParentCollection() { }

            public WithCompanyParentCollection(Company company)
            {
                Parent = company;
            }

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<BonusAndDiscontinuedByCompany>
            {
                public int Compare(BonusAndDiscontinuedByCompany x, BonusAndDiscontinuedByCompany y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            //protected class comparer_CompanyCode : IComparer<BonusAndDiscontinuedByCompany>
            //{
            //    public int Compare(BonusAndDiscontinuedByCompany x, BonusAndDiscontinuedByCompany y)
            //    {
            //        return x.CompanyCode.CompareTo(y.CompanyCode);
            //    }
            //}

            protected class comparer_DiscontinuedEffectiveDate : IComparer<BonusAndDiscontinuedByCompany>
            {
                public int Compare(BonusAndDiscontinuedByCompany x, BonusAndDiscontinuedByCompany y)
                {
                    return x.DiscontinuedEffectiveDate.CompareTo(y.DiscontinuedEffectiveDate);
                }
            }
            #endregion
        }
    }

    [Serializable]
    public class BonusAndDiscontinuedByCustomerKey : CustomerKey
    {
        public SqlString ItemNumber;

        public BonusAndDiscontinuedByCustomerKey() { }

        public BonusAndDiscontinuedByCustomerKey(SqlString companyCode, SqlString customerNumber, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for BonusAndDiscontinuedByCustomer.
    /// </summary>
    [Serializable]
    public class BonusAndDiscontinuedByCustomer : ABonusAndDiscontinued, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _itemNumber;
        private SqlDateTime _discontinuedEffectiveDate;

        public BonusAndDiscontinuedByCustomer() { }

        public BonusAndDiscontinuedByCustomer(SqlString companyCode, SqlString customerNumber, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(BonusAndDiscontinuedByCustomerKey); }
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

        public SqlDateTime DiscontinuedEffectiveDate
        {
            get { return _discontinuedEffectiveDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_discontinuedEffectiveDate.CompareTo(value) != 0)
                {
                    _discontinuedEffectiveDate = value;
                    FieldDataChange("DiscontinuedEffectiveDate", value);
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
                !_itemNumber.IsNull);
        }

        [Serializable]
        public class WithCustomerParentCollection : APersistenceObjectWithParentCollection<BonusAndDiscontinuedByCustomerKey, BonusAndDiscontinuedByCustomer>
        {
            public WithCustomerParentCollection() { }

            public WithCustomerParentCollection(Customer customer)
            {
                Parent = customer;
            }

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<BonusAndDiscontinuedByCustomer>
            {
                public int Compare(BonusAndDiscontinuedByCustomer x, BonusAndDiscontinuedByCustomer y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            //protected class comparer_CustomerNumber : IComparer<BonusAndDiscontinuedByCustomer>
            //{
            //    public int Compare(BonusAndDiscontinuedByCustomer x, BonusAndDiscontinuedByCustomer y)
            //    {
            //        return x.CustomerNumber.CompareTo(y.CustomerNumber);
            //    }
            //}

            protected class comparer_DiscontinuedEffectiveDate : IComparer<BonusAndDiscontinuedByCustomer>
            {
                public int Compare(BonusAndDiscontinuedByCustomer x, BonusAndDiscontinuedByCustomer y)
                {
                    return x.DiscontinuedEffectiveDate.CompareTo(y.DiscontinuedEffectiveDate);
                }
            }
            #endregion
        }
    }
}
