using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastParameterKey : CustomerKey
    {
        public SqlString ItemNumber;

        public ForecastParameterKey() { }

        public ForecastParameterKey(SqlString companyCode, SqlString customerNumber, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append("|").Append(ItemNumber.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastParameter.
    /// </summary>
    [Serializable]
    public class ForecastParameter : APersistenceObject, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _itemNumber;
        private SqlInt32 _storeCountExisting;
        private SqlInt32 _storeCountNew;
        private SqlDecimal _initialQtyPerNewStore;
        private SqlString _pipelineStart;
        private SqlString _pipelineEnd;
        private SqlDecimal _projectedSalesRateExisting;
        private SqlDecimal _projectedSalesRateNew;
        private SqlBoolean _oneTimeItemFlag;

        private readonly SqlDecimal[] _plPctCollection = new SqlDecimal[36];

        public ForecastParameter() { }

        public ForecastParameter(SqlString companyCode, SqlString customerNumber, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            ItemNumber = itemNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastParameterKey); }
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

        public SqlInt32 StoreCountExisting
        {
            get { return _storeCountExisting; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_storeCountExisting.CompareTo(value) != 0)
                {
                    _storeCountExisting = value;
                    FieldDataChange("StoreCountExisting", value);
                }
            }
        }

        public SqlInt32 StoreCountNew
        {
            get { return _storeCountNew; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_storeCountNew.CompareTo(value) != 0)
                {
                    _storeCountNew = value;
                    FieldDataChange("StoreCountNew", value);
                }
            }
        }

        public SqlDecimal InitialQtyPerNewStore
        {
            get { return _initialQtyPerNewStore; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_initialQtyPerNewStore.CompareTo(value) != 0)
                {
                    _initialQtyPerNewStore = value;
                    FieldDataChange("InitialQtyPerNewStore", value);
                }
            }
        }

        public SqlString PipelineStart
        {
            get { return _pipelineStart; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_pipelineStart.CompareTo(value) != 0)
                {
                    _pipelineStart = value;
                    FieldDataChange("PipelineStart", value);
                }
            }
        }

        public SqlString PipelineEnd
        {
            get { return _pipelineEnd; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_pipelineEnd.CompareTo(value) != 0)
                {
                    _pipelineEnd = value;
                    FieldDataChange("PipelineEnd", value);
                }
            }
        }

        public SqlDecimal ProjectedSalesRateExisting
        {
            get { return _projectedSalesRateExisting; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_projectedSalesRateExisting.CompareTo(value) != 0)
                {
                    _projectedSalesRateExisting = value;
                    FieldDataChange("ProjectedSalesRateExisting", value);
                }
            }
        }

        public SqlDecimal ProjectedSalesRateNew
        {
            get { return _projectedSalesRateNew; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_projectedSalesRateNew.CompareTo(value) != 0)
                {
                    _projectedSalesRateNew = value;
                    FieldDataChange("ProjectedSalesRateNew", value);
                }
            }
        }

        public SqlBoolean OneTimeItemFlag
        {
            get { return _oneTimeItemFlag.IsNull ? SqlBoolean.False : _oneTimeItemFlag; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_oneTimeItemFlag.CompareTo(value) != 0)
                {
                    _oneTimeItemFlag = value;
                    FieldDataChange("OneTimeItemFlag", value);
                }
            }
        }

        [NotMapped]
        public SqlDecimal[] PlPctCollection
        { get { return _plPctCollection; } }

        public SqlDecimal PlPctPY01
        {
            get { return _plPctCollection[0]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[0].CompareTo(value) != 0)
                {
                    _plPctCollection[0] = value;
                    FieldDataChange("PlPctPY01", value);
                }
            }
        }

        public SqlDecimal PlPctPY02
        {
            get { return _plPctCollection[1]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[1].CompareTo(value) != 0)
                {
                    _plPctCollection[1] = value;
                    FieldDataChange("PlPctPY02", value);
                }
            }
        }

        public SqlDecimal PlPctPY03
        {
            get { return _plPctCollection[2]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[2].CompareTo(value) != 0)
                {
                    _plPctCollection[2] = value;
                    FieldDataChange("PlPctPY03", value);
                }
            }
        }

        public SqlDecimal PlPctPY04
        {
            get { return _plPctCollection[3]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[3].CompareTo(value) != 0)
                {
                    _plPctCollection[3] = value;
                    FieldDataChange("PlPctPY04", value);
                }
            }
        }

        public SqlDecimal PlPctPY05
        {
            get { return _plPctCollection[4]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[4].CompareTo(value) != 0)
                {
                    _plPctCollection[4] = value;
                    FieldDataChange("PlPctPY05", value);
                }
            }
        }

        public SqlDecimal PlPctPY06
        {
            get { return _plPctCollection[5]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[5].CompareTo(value) != 0)
                {
                    _plPctCollection[5] = value;
                    FieldDataChange("PlPctPY06", value);
                }
            }
        }

        public SqlDecimal PlPctPY07
        {
            get { return _plPctCollection[6]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[6].CompareTo(value) != 0)
                {
                    _plPctCollection[6] = value;
                    FieldDataChange("PlPctPY07", value);
                }
            }
        }

        public SqlDecimal PlPctPY08
        {
            get { return _plPctCollection[7]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[7].CompareTo(value) != 0)
                {
                    _plPctCollection[7] = value;
                    FieldDataChange("PlPctPY08", value);
                }
            }
        }

        public SqlDecimal PlPctPY09
        {
            get { return _plPctCollection[8]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[8].CompareTo(value) != 0)
                {
                    _plPctCollection[8] = value;
                    FieldDataChange("PlPctPY09", value);
                }
            }
        }

        public SqlDecimal PlPctPY10
        {
            get { return _plPctCollection[9]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[9].CompareTo(value) != 0)
                {
                    _plPctCollection[9] = value;
                    FieldDataChange("PlPctPY10", value);
                }
            }
        }

        public SqlDecimal PlPctPY11
        {
            get { return _plPctCollection[10]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[10].CompareTo(value) != 0)
                {
                    _plPctCollection[10] = value;
                    FieldDataChange("PlPctPY11", value);
                }
            }
        }

        public SqlDecimal PlPctPY12
        {
            get { return _plPctCollection[11]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[11].CompareTo(value) != 0)
                {
                    _plPctCollection[11] = value;
                    FieldDataChange("PlPctPY12", value);
                }
            }
        }

        public SqlDecimal PlPctCY01
        {
            get { return _plPctCollection[12]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[12].CompareTo(value) != 0)
                {
                    _plPctCollection[12] = value;
                    FieldDataChange("PlPctCY01", value);
                }
            }
        }

        public SqlDecimal PlPctCY02
        {
            get { return _plPctCollection[13]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[13].CompareTo(value) != 0)
                {
                    _plPctCollection[13] = value;
                    FieldDataChange("PlPctCY02", value);
                }
            }
        }

        public SqlDecimal PlPctCY03
        {
            get { return _plPctCollection[14]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[14].CompareTo(value) != 0)
                {
                    _plPctCollection[14] = value;
                    FieldDataChange("PlPctCY03", value);
                }
            }
        }

        public SqlDecimal PlPctCY04
        {
            get { return _plPctCollection[15]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[15].CompareTo(value) != 0)
                {
                    _plPctCollection[15] = value;
                    FieldDataChange("PlPctCY04", value);
                }
            }
        }

        public SqlDecimal PlPctCY05
        {
            get { return _plPctCollection[16]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[16].CompareTo(value) != 0)
                {
                    _plPctCollection[16] = value;
                    FieldDataChange("PlPctCY05", value);
                }
            }
        }

        public SqlDecimal PlPctCY06
        {
            get { return _plPctCollection[17]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[17].CompareTo(value) != 0)
                {
                    _plPctCollection[17] = value;
                    FieldDataChange("PlPctCY06", value);
                }
            }
        }

        public SqlDecimal PlPctCY07
        {
            get { return _plPctCollection[18]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[18].CompareTo(value) != 0)
                {
                    _plPctCollection[18] = value;
                    FieldDataChange("PlPctCY07", value);
                }
            }
        }

        public SqlDecimal PlPctCY08
        {
            get { return _plPctCollection[19]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[19].CompareTo(value) != 0)
                {
                    _plPctCollection[19] = value;
                    FieldDataChange("PlPctCY08", value);
                }
            }
        }

        public SqlDecimal PlPctCY09
        {
            get { return _plPctCollection[20]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[20].CompareTo(value) != 0)
                {
                    _plPctCollection[20] = value;
                    FieldDataChange("PlPctCY09", value);
                }
            }
        }

        public SqlDecimal PlPctCY10
        {
            get { return _plPctCollection[21]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[21].CompareTo(value) != 0)
                {
                    _plPctCollection[21] = value;
                    FieldDataChange("PlPctCY10", value);
                }
            }
        }

        public SqlDecimal PlPctCY11
        {
            get { return _plPctCollection[22]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[22].CompareTo(value) != 0)
                {
                    _plPctCollection[22] = value;
                    FieldDataChange("PlPctCY11", value);
                }
            }
        }

        public SqlDecimal PlPctCY12
        {
            get { return _plPctCollection[23]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[23].CompareTo(value) != 0)
                {
                    _plPctCollection[23] = value;
                    FieldDataChange("PlPctCY12", value);
                }
            }
        }

        public SqlDecimal PlPctNY01
        {
            get { return _plPctCollection[24]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[24].CompareTo(value) != 0)
                {
                    _plPctCollection[24] = value;
                    FieldDataChange("PlPctNY01", value);
                }
            }
        }

        public SqlDecimal PlPctNY02
        {
            get { return _plPctCollection[25]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[25].CompareTo(value) != 0)
                {
                    _plPctCollection[25] = value;
                    FieldDataChange("PlPctNY02", value);
                }
            }
        }

        public SqlDecimal PlPctNY03
        {
            get { return _plPctCollection[26]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[26].CompareTo(value) != 0)
                {
                    _plPctCollection[26] = value;
                    FieldDataChange("PlPctNY03", value);
                }
            }
        }

        public SqlDecimal PlPctNY04
        {
            get { return _plPctCollection[27]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[27].CompareTo(value) != 0)
                {
                    _plPctCollection[27] = value;
                    FieldDataChange("PlPctNY04", value);
                }
            }
        }

        public SqlDecimal PlPctNY05
        {
            get { return _plPctCollection[28]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[28].CompareTo(value) != 0)
                {
                    _plPctCollection[28] = value;
                    FieldDataChange("PlPctNY05", value);
                }
            }
        }

        public SqlDecimal PlPctNY06
        {
            get { return _plPctCollection[29]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[29].CompareTo(value) != 0)
                {
                    _plPctCollection[29] = value;
                    FieldDataChange("PlPctNY06", value);
                }
            }
        }

        public SqlDecimal PlPctNY07
        {
            get { return _plPctCollection[30]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[30].CompareTo(value) != 0)
                {
                    _plPctCollection[30] = value;
                    FieldDataChange("PlPctNY07", value);
                }
            }
        }

        public SqlDecimal PlPctNY08
        {
            get { return _plPctCollection[31]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[31].CompareTo(value) != 0)
                {
                    _plPctCollection[31] = value;
                    FieldDataChange("PlPctNY08", value);
                }
            }
        }

        public SqlDecimal PlPctNY09
        {
            get { return _plPctCollection[32]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[32].CompareTo(value) != 0)
                {
                    _plPctCollection[32] = value;
                    FieldDataChange("PlPctNY09", value);
                }
            }
        }

        public SqlDecimal PlPctNY10
        {
            get { return _plPctCollection[33]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[33].CompareTo(value) != 0)
                {
                    _plPctCollection[33] = value;
                    FieldDataChange("PlPctNY10", value);
                }
            }
        }

        public SqlDecimal PlPctNY11
        {
            get { return _plPctCollection[34]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[34].CompareTo(value) != 0)
                {
                    _plPctCollection[34] = value;
                    FieldDataChange("PlPctNY11", value);
                }
            }
        }

        public SqlDecimal PlPctNY12
        {
            get { return _plPctCollection[35]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_plPctCollection[35].CompareTo(value) != 0)
                {
                    _plPctCollection[35] = value;
                    FieldDataChange("PlPctNY12", value);
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
        public class WithCustomerParentCollection : APersistenceObjectWithParentCollection<ForecastParameterKey, ForecastParameter>
        {
            public WithCustomerParentCollection() { }

            public WithCustomerParentCollection(Customer parent)
            {
                Parent = parent;
            }

            //public bool IsPipelineForecastPeriodOverlap(SqlString pipelineStart, SqlString pipelineEnd)
            //{
            //    string plStartYYMM = Calendar.GetYYMM(pipelineStart.ToString());
            //    string plEndYYMM = Calendar.GetYYMM(pipelineEnd.ToString());
            //    string forecastStartYYMM = Calendar.GetYYMM(parent.ForecastWeekEndDateStart.Value.AddDays(-6));
            //    string forecastEndYYMM = Calendar.GetYYMM(parent.ForecastWeekEndDateEnd.Value);
            //    return ((plStartYYMM.CompareTo(forecastStartYYMM) >= 0 &&
            //        plStartYYMM.CompareTo(forecastEndYYMM) <= 0) ||
            //        (plEndYYMM.CompareTo(forecastStartYYMM) >= 0 &&
            //        plEndYYMM.CompareTo(forecastEndYYMM) <= 0) ||
            //        (forecastStartYYMM.CompareTo(plStartYYMM) >= 0 &&
            //        forecastStartYYMM.CompareTo(plEndYYMM) <= 0) ||
            //        (forecastEndYYMM.CompareTo(plStartYYMM) >= 0 &&
            //        forecastEndYYMM.CompareTo(plEndYYMM) <= 0));
            //}

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            protected class comparer_StoreCountExisting : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.StoreCountExisting.CompareTo(y.StoreCountExisting);
                }
            }

            protected class comparer_StoreCountNew : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.StoreCountNew.CompareTo(y.StoreCountNew);
                }
            }

            protected class comparer_InitialQtyPerNewStore : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.InitialQtyPerNewStore.CompareTo(y.InitialQtyPerNewStore);
                }
            }

            protected class comparer_PipelineStart : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.PipelineStart.CompareTo(y.PipelineStart);
                }
            }

            protected class comparer_PipelineEnd : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.PipelineEnd.CompareTo(y.PipelineEnd);
                }
            }

            protected class comparer_ProjectedSalesRateExisting : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.ProjectedSalesRateExisting.CompareTo(y.ProjectedSalesRateExisting);
                }
            }

            protected class comparer_ProjectedSalesRateNew : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.ProjectedSalesRateNew.CompareTo(y.ProjectedSalesRateNew);
                }
            }

            protected class comparer_OneTimeItemFlag : IComparer<ForecastParameter>
            {
                public int Compare(ForecastParameter x, ForecastParameter y)
                {
                    return x.OneTimeItemFlag.CompareTo(y.OneTimeItemFlag);
                }
            }
            #endregion
        }
    }
}
