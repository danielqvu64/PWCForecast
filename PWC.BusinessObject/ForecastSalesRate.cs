using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using DVu.Library.BusinessObject;
using DVu.Library.PersistenceInterface;

namespace PWC.BusinessObject
{
    [Serializable]
    public class ForecastSalesRateKey : CustomerKey
    {
        public SqlDateTime POSSalesEndDate;
        public SqlString ItemNumber;

        public ForecastSalesRateKey() { }

        public ForecastSalesRateKey(SqlString companyCode, SqlString customerNumber, SqlDateTime posWeekEndDateEnd, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posWeekEndDateEnd;
            ItemNumber = itemNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.Append("|").Append(POSSalesEndDate.IsNull ? POSSalesEndDate.ToString() : POSSalesEndDate.Value.ToString("G"));
            sb.Append("|").Append(ItemNumber.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for ForecastSalesRate.
    /// </summary>
    [Serializable]
    public class ForecastSalesRate : APersistenceObject, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _posSalesEndDate;
        private SqlString _itemNumber;
        private SqlDecimal _trendFactor;
        private SqlInt32 _posWeek1Quantity;
        private SqlInt32 _posWeek2Quantity;
        private SqlInt32 _posWeek3Quantity;
        private SqlInt32 _posWeek4Quantity;
        private SqlInt32 _storeCountExisting;
        private SqlInt32 _storeCountNew;
        private SqlDecimal _salesRate;
        private SqlDecimal _salesRatePrevious;
        private ForecastSalesRateCommentAndOverride.WithForecastSalesRateParentCollection _forecastSalesRateCommentAndOverrideCollection;
        private SqlBoolean _hasOverride;
        private SqlBoolean _hasComment;

        public ForecastSalesRate() { }

        public ForecastSalesRate(SqlString companyCode, SqlString customerNumber, SqlDateTime posSalesEndDate, SqlString itemNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posSalesEndDate;
            ItemNumber = itemNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastSalesRateKey); }
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

        public SqlDecimal TrendFactor
        {
            get { return _trendFactor; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_trendFactor.CompareTo(value) != 0)
                {
                    _trendFactor = value;
                    FieldDataChange("TrendFactor", value);
                }
            }
        }

        public SqlInt32 POSWeek1Quantity
        {
            get { return _posWeek1Quantity; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_posWeek1Quantity.CompareTo(value) != 0)
                {
                    _posWeek1Quantity = value;
                    FieldDataChange("POSWeek1Quantity", value);
                }
            }
        }

        public SqlInt32 POSWeek2Quantity
        {
            get { return _posWeek2Quantity; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_posWeek2Quantity.CompareTo(value) != 0)
                {
                    _posWeek2Quantity = value;
                    FieldDataChange("POSWeek2Quantity", value);
                }
            }
        }

        public SqlInt32 POSWeek3Quantity
        {
            get { return _posWeek3Quantity; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_posWeek3Quantity.CompareTo(value) != 0)
                {
                    _posWeek3Quantity = value;
                    FieldDataChange("POSWeek3Quantity", value);
                }
            }
        }

        public SqlInt32 POSWeek4Quantity
        {
            get { return _posWeek4Quantity; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_posWeek4Quantity.CompareTo(value) != 0)
                {
                    _posWeek4Quantity = value;
                    FieldDataChange("POSWeek4Quantity", value);
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
        
        public SqlDecimal SalesRate
        {
            get
            {
                if (_salesRate.IsNull && !_hasOverride)
                    _salesRate = SalesRateCalculated;
                return _salesRate;
            }
            set
            {
                // use CompareTo for proper null value comparision
                if (_salesRate.CompareTo(value) != 0)
                {
                    _salesRate = value;
                    FieldDataChange("SalesRate", value);
                }
            }
        }

        public SqlDecimal SalesRatePrevious
        {
            get { return _salesRatePrevious; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_salesRatePrevious.CompareTo(value) != 0)
                {
                    _salesRatePrevious = value;
                    FieldDataChange("SalesRatePrevious", value);
                }
            }
        }

        public SqlBoolean HasOverride
        {
            get { return _hasOverride; }
            set { _hasOverride = value; }
        }

        public SqlBoolean HasComment
        {
            get { return _hasComment; }
            set { _hasComment = value; }
        }

        public SqlBytes RowVersion { get; set; }
        #endregion

        public bool GetOverride()
        {
            if (!HasOverride)
                return false;

            var manualOverride = ForecastSalesRateCommentAndOverrideCollection.OrderByDescending(commentAndOverride => commentAndOverride.CommentOverrideDateTime).FirstOrDefault(commentAndOverride => (bool)(commentAndOverride.Comment.IsNull));
            return (bool)(manualOverride != null && manualOverride.IsOverride);
        }

        public List<ForecastSalesRateCommentAndOverride> GetComments()
        {
            return ForecastSalesRateCommentAndOverrideCollection.Where(commentAndOverride => !commentAndOverride.Comment.IsNull).OrderByDescending(commentAndOverride => commentAndOverride.CommentOverrideDateTime).ToList();
        }

        [NotMapped]
        public ForecastSalesRateCommentAndOverride.WithForecastSalesRateParentCollection ForecastSalesRateCommentAndOverrideCollection
        {
            get
            {
                if (_forecastSalesRateCommentAndOverrideCollection == null)
                {
                    _forecastSalesRateCommentAndOverrideCollection = new ForecastSalesRateCommentAndOverride.WithForecastSalesRateParentCollection(this);
                    _forecastSalesRateCommentAndOverrideCollection.Load();
                }
                return _forecastSalesRateCommentAndOverrideCollection;
            }
            set { _forecastSalesRateCommentAndOverrideCollection = value; }
        }

        [NotMapped]
        public SqlInt32 POSTotal
        {
            get
            {
                return (_posWeek1Quantity.IsNull ? 0 : _posWeek1Quantity) +
                    (_posWeek2Quantity.IsNull ? 0 : _posWeek2Quantity) +
                    (_posWeek3Quantity.IsNull ? 0 : _posWeek3Quantity) +
                    (_posWeek4Quantity.IsNull ? 0 : _posWeek4Quantity);
            }
        }

        [NotMapped]
        public SqlInt32 StoreCountTotal
        {
            get
            {
                return (_storeCountExisting.IsNull ? 0 : _storeCountExisting) +
                    (_storeCountNew.IsNull ? 0 : _storeCountNew);
            }
        }

        [NotMapped]
        public SqlDecimal SalesRateDifference
        {
            get { return _salesRate - _salesRatePrevious; }
        }

        [NotMapped]
        public SqlDecimal SalesRateDifferencePercent
        {
            get { return _salesRatePrevious.IsNull || _salesRatePrevious == 0 ? SqlDecimal.Null : (_salesRate - _salesRatePrevious) / _salesRatePrevious * 100; }
        }

        [NotMapped]
        public SqlDecimal SalesRateCalculated
        {
            get
            {
                if (ContainingCollection == null)
                    return SqlDecimal.Null;
                var posNumberOfWeeks = ((ForecastSalesRateCollectionHeader)((WithCustomerParentParameteredCollection)ContainingCollection).SetHeader).POSNumberOfWeeks;
                return StoreCountTotal == 0 ? SqlDecimal.Null : SqlDecimal.Round(POSTotal.ToSqlDecimal() / posNumberOfWeeks / StoreCountTotal / (_trendFactor / 100), 2);
            }
        }

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull &&
                !_posSalesEndDate.IsNull &&
                !_itemNumber.IsNull);
        }

        [Serializable]
        public class WithCustomerParentParameteredCollection : APersistenceObjectWithParentCollection<ForecastSalesRateKey, ForecastSalesRate>, ISetVersion
        {
            public WithCustomerParentParameteredCollection() { }

            public WithCustomerParentParameteredCollection(Customer parent, SqlInt16 posNumberOfWeeks, SqlDateTime posWeekEndDateEnd, ForecastSalesRateAction forecastSalesRateAction, SqlBoolean isGettingPreviousOverride)
            {
                Parent = parent;
                ParameterCollection = new HybridDictionary
                                           {
                                               {"POSNumberOfWeeks", posNumberOfWeeks},
                                               {"POSSalesEndDate", posWeekEndDateEnd},
                                               {"ForecastSalesRateAction", forecastSalesRateAction.ToString()},
                                               {"IsGettingPreviousOverride", isGettingPreviousOverride}
                                           };
                SetHeader = new ForecastSalesRateCollectionHeader(parent.CompanyCode, parent.CustomerNumber, posWeekEndDateEnd, posNumberOfWeeks);
            }

            public IRowVersion SetHeader { get; set; }

            public void UpdateParameterCollection()
            {
                using (var transaction = new Transaction())
                {
                    foreach (var param in ((Customer)Parent).ForecastParameterCollection)
                    {
                        var rateKey = new ForecastSalesRateKey(param.CompanyCode, param.CustomerNumber, ((Customer)Parent).POSSalesEndDate, param.ItemNumber);
                        if (!ContainsKey(rateKey) || this[rateKey]._salesRate.IsNull)
                            continue;
                        param.ProjectedSalesRateExisting = this[rateKey]._salesRate;
                        transaction.Enlist(param);
                        param.Save();
                    }
                    transaction.Commit();
                }
            }

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            protected class comparer_TrendFactor : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.TrendFactor.CompareTo(y.TrendFactor);
                }
            }

            protected class comparer_SalesRate : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.SalesRate.CompareTo(y.SalesRate);
                }
            }

            protected class comparer_POSTotal : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.POSTotal.CompareTo(y.POSTotal);
                }
            }

            protected class comparer_StoreCountTotal : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.StoreCountTotal.CompareTo(y.StoreCountTotal);
                }
            }

            protected class comparer_SalesRatePrevious : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.SalesRatePrevious.CompareTo(y.SalesRatePrevious);
                }
            }

            protected class comparer_SalesRateDifference : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.SalesRateDifference.CompareTo(y.SalesRateDifference);
                }
            }

            protected class comparer_SalesRateDifferencePercent : IComparer<ForecastSalesRate>
            {
                public int Compare(ForecastSalesRate x, ForecastSalesRate y)
                {
                    return x.SalesRateDifferencePercent.CompareTo(y.SalesRateDifferencePercent);
                }
            }
            #endregion
        }
        
        [Serializable]
        public class PreviousSalesRateCollection : APersistenceObjectCollection<ForecastSalesRateKey, ForecastSalesRate>
        {
            public PreviousSalesRateCollection() { }

            public PreviousSalesRateCollection(SqlString companyCode, SqlString customerNumber, SqlString itemNumber, SqlDateTime weekEndDateEnd)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", companyCode},
                                               {"CustomerNumber", customerNumber},
                                               {"ItemNumber", itemNumber},
                                               {"POSSalesEndDate", weekEndDateEnd}
                                           };
            }
        }
    }
}
