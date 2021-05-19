using System;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;
using PWC.PersistenceInterface;

namespace PWC.BusinessObject
{
    public enum ForecastSalesRateAction
    { Get, Generate }

    public enum ForecastAction
    { Get, Generate }

    [Serializable]
    public class CustomerKey : CompanyKey
    {
        public SqlString CustomerNumber;

        public CustomerKey() { }

        public CustomerKey(SqlString companyCode, SqlString customerNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append("|").Append(CustomerNumber.ToString()).ToString();
        }
    }

    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    [Serializable]
    public class Customer : APersistenceObject, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlString _customerName;
        private SqlBoolean _distinctForecastNameFlag;
        private SqlString _forecastMethod;
        private SqlDecimal _inflateFactor;
        private SqlInt16 _forecastFutureFrozenMonths;

        private SqlDateTime _posSalesEndDate;
        private SqlInt16 _posNumberOfWeeks = 4;
        private SqlInt16 _rollingAvageNumberOfMonths = 3;
        private ForecastSalesRateAction _forecastSalesRateAction = ForecastSalesRateAction.Get;
        private ForecastAction _forecastAction = ForecastAction.Get;
        private ForecastSalesRate.WithCustomerParentParameteredCollection _forecastSalesRateCollection;
        private ForecastSalesRate.WithCustomerParentParameteredCollection _forecastSalesRateOverrideCollection;
        private ForecastParameter.WithCustomerParentCollection _forecastParameterCollection;
        private Forecast.WithCustomerParentParameteredCollection _forecastCollection;
        private Forecast.WithCustomerParentPreviousCollection _forecastPreviousCollection;
        private BonusAndDiscontinuedByCustomer.WithCustomerParentCollection _bonusAndDiscontinuedCollection;
        private ForecastTrendByCustomerItem.WithCustomerParentCollection _forecastTrendByItemCollection;
        private ForecastTrendByCustomerProductGroup.WithCustomerParentCollection _forecastTrendByProductGroupCollection;
        private ForecastTrendProductGroupItem.ByCustomerParameteredCollection _forecastTrendByCustomerProductGroupItemCollection;
        private ForecastTrendProductGroupItem.ByCompanyParameteredCollection _forecastTrendByCompanyProductGroupItemCollection;
        private ActualSales.WithCustomerParentParameteredCollection _actualSalesCollection;

        public delegate void ForecastSalesRateCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event ForecastSalesRateCollectionInvalidatedDelegate ForecastSalesRateCollectionInvalidated;

        public delegate void ForecastCollectionInvalidatedDelegate(object sender, EventArgs e);
        public event ForecastCollectionInvalidatedDelegate ForecastCollectionInvalidated;

        // bug in .net 3.5 sp1
        // event name for some reason cause System.ArgumentException on System.ComponentModel.ReflectEventDescriptor.RemoveEventHandler
        // put 'x' at end of the event name fixes the problem
        public delegate void ForecastSalesRateActionChangedDelegate(Customer sender, EventArgs e);
        public event ForecastSalesRateActionChangedDelegate ForecastSalesRateActionChangedx;

        // bug in .net 3.5 sp1
        // event name for some reason cause System.ArgumentException on System.ComponentModel.ReflectEventDescriptor.RemoveEventHandler
        // put 'x' at end of the event name fixes the problem
        public delegate void ForecastActionChangedDelegate(Customer sender, EventArgs e);
        public event ForecastActionChangedDelegate ForecastActionChangedx;

        public Customer() { }

        public Customer(SqlString companyCode, SqlString customerNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(CustomerKey); }
        }

    #region Collection Members
        [NotMapped]
        public ForecastSalesRate.WithCustomerParentParameteredCollection ForecastSalesRateOverrideCollection
        {
            get
            {
                if (_forecastSalesRateOverrideCollection == null)
                {
                    _forecastSalesRateOverrideCollection = new ForecastSalesRate.WithCustomerParentParameteredCollection(this, _posNumberOfWeeks, _posSalesEndDate, ForecastSalesRateAction.Get, SqlBoolean.True);
                    _forecastSalesRateOverrideCollection.Load();
                }
                return _forecastSalesRateOverrideCollection;
            }
        }

        [NotMapped]
        public ForecastSalesRate.WithCustomerParentParameteredCollection ForecastSalesRateCollection
        {
            get
            {
                if (_forecastSalesRateCollection == null)
                {
                    _forecastSalesRateCollection = new ForecastSalesRate.WithCustomerParentParameteredCollection(this, _posNumberOfWeeks, _posSalesEndDate, _forecastSalesRateAction, SqlBoolean.False);
                    _forecastSalesRateCollection.Load();
                    //_posNumberOfWeeks = ((ForecastSalesRateCollectionHeader)_forecastSalesRateCollection.SetHeader).POSNumberOfWeeks;
                    if (_forecastSalesRateAction == ForecastSalesRateAction.Generate) //restore manual sales rate
                    {
                        foreach (var a in ForecastSalesRateOverrideCollection)
                        {
                            var salesRateOverride = a;
                            foreach (var b in _forecastSalesRateCollection.Where(b => (bool) (salesRateOverride.ItemNumber == b.ItemNumber)))
                            {
                                b.SalesRate = a.SalesRate;
                                b.HasComment = a.HasComment;
                                b.HasOverride = a.HasOverride;
                                foreach (var manualCommentAndOverride in a.ForecastSalesRateCommentAndOverrideCollection)
                                {
                                    var commentAndOverride = b.ForecastSalesRateCommentAndOverrideCollection.Create(
                                        new ForecastSalesRateCommentAndOverrideKey((ForecastSalesRateKey) b.ObjectKey, manualCommentAndOverride.CommentOverrideDateTime));
                                    commentAndOverride.Comment = manualCommentAndOverride.Comment;
                                    commentAndOverride.IsOverride = manualCommentAndOverride.IsOverride;
                                    b.ForecastSalesRateCommentAndOverrideCollection.Add(commentAndOverride);
                                }
                            }
                        }
                        _forecastSalesRateOverrideCollection = null;
                    }
                }
                return _forecastSalesRateCollection;
            }
            set { _forecastSalesRateCollection = value; }
        }

        [NotMapped]
        public ForecastParameter.WithCustomerParentCollection ForecastParameterCollection
        {
            get
            {
                if (_forecastParameterCollection == null)
                {
                    _forecastParameterCollection = new ForecastParameter.WithCustomerParentCollection(this);
                    _forecastParameterCollection.Load();
                }
                return _forecastParameterCollection;
            }
            set { _forecastParameterCollection = value; }
        }

        [NotMapped]
        public BonusAndDiscontinuedByCustomer.WithCustomerParentCollection BonusAndDiscontinuedCollection
        {
            get
            {
                if (_bonusAndDiscontinuedCollection == null)
                {
                    _bonusAndDiscontinuedCollection = new BonusAndDiscontinuedByCustomer.WithCustomerParentCollection(this);
                    _bonusAndDiscontinuedCollection.Load();
                }
                return _bonusAndDiscontinuedCollection;
            }
            set { _bonusAndDiscontinuedCollection = value; }
        }

        [NotMapped]
        public ForecastTrendByCustomerItem.WithCustomerParentCollection ForecastTrendByItemCollection
        {
            get
            {
                if (_forecastTrendByItemCollection == null)
                {
                    _forecastTrendByItemCollection = new ForecastTrendByCustomerItem.WithCustomerParentCollection(this);
                    _forecastTrendByItemCollection.Load();
                }
                return _forecastTrendByItemCollection;
            }
            set { _forecastTrendByItemCollection = value; }
        }

        [NotMapped]
        public ForecastTrendByCustomerProductGroup.WithCustomerParentCollection ForecastTrendByProductGroupCollection
        {
            get
            {
                if (_forecastTrendByProductGroupCollection == null)
                {
                    _forecastTrendByProductGroupCollection = new ForecastTrendByCustomerProductGroup.WithCustomerParentCollection(this);
                    _forecastTrendByProductGroupCollection.Load();
                }
                return _forecastTrendByProductGroupCollection;
            }
            set { _forecastTrendByProductGroupCollection = value; }
        }

        [NotMapped]
        public Forecast.WithCustomerParentParameteredCollection ForecastCollection
        {
            get
            {
                if (_forecastCollection == null)
                {
                    switch (_forecastAction)
                    {
                        case ForecastAction.Generate:
                            GenerateForecast();
                            break;
                        case ForecastAction.Get:
                            _forecastCollection = new Forecast.WithCustomerParentParameteredCollection(this, _posSalesEndDate, _forecastAction);
                            _forecastCollection.Load();
                            break;
                    }
                }
                return _forecastCollection;
            }
            set { _forecastCollection = value; }
        }

        [NotMapped]
        public Forecast.WithCustomerParentPreviousCollection ForecastPreviousCollection
        {
            get
            {
                if (_forecastPreviousCollection == null)
                {
                    _forecastPreviousCollection = new Forecast.WithCustomerParentPreviousCollection(this, _posSalesEndDate);
                    _forecastPreviousCollection.Load();
                }
                return _forecastPreviousCollection;
            }
            set { _forecastPreviousCollection = value; }
        }

        [NotMapped]
        public ForecastTrendProductGroupItem.ByCompanyParameteredCollection ForecastTrendByCompanyProductGroupItemCollection
        {
            get
            {
                if (_forecastTrendByCompanyProductGroupItemCollection == null)
                {
                    _forecastTrendByCompanyProductGroupItemCollection = new ForecastTrendProductGroupItem.ByCompanyParameteredCollection(this);
                    _forecastTrendByCompanyProductGroupItemCollection.Load();
                }
                return _forecastTrendByCompanyProductGroupItemCollection;
            }
            set { _forecastTrendByCompanyProductGroupItemCollection = value; }
        }

        [NotMapped]
        public ForecastTrendProductGroupItem.ByCustomerParameteredCollection ForecastTrendByCustomerProductGroupItemCollection
        {
            get
            {
                if (_forecastTrendByCustomerProductGroupItemCollection == null)
                {
                    _forecastTrendByCustomerProductGroupItemCollection = new ForecastTrendProductGroupItem.ByCustomerParameteredCollection(this);
                    _forecastTrendByCustomerProductGroupItemCollection.Load();
                }
                return _forecastTrendByCustomerProductGroupItemCollection;
            }
            set { _forecastTrendByCustomerProductGroupItemCollection = value; }
        }

        [NotMapped]
        public ActualSales.WithCustomerParentParameteredCollection ActualSalesCollection
        {
            get
            {
                if (_actualSalesCollection == null)
                {
                    //CommentOverrideDateTime endDate;
                    //if (_forecastMethod == "RA")
                    //{
                    //    endDate = new CommentOverrideDateTime(_posSalesEndDate.Value.Year, _posSalesEndDate.Value.Month, 1);
                    //    _actualSalesCollection = new ActualSales.WithCustomerParentParameteredCollection(this, endDate.AddMonths(-(int)_rollingAvageNumberOfMonths + (int)(_forecastFutureFrozenMonths >= 0 ? 0 : _forecastFutureFrozenMonths)), endDate);
                    //}
                    //else if (_forecastMethod == "SR")
                    //{
                    //    endDate = new CommentOverrideDateTime(CommentOverrideDateTime.Today.Year, CommentOverrideDateTime.Today.Month, 1);
                    //    _actualSalesCollection = new ActualSales.WithCustomerParentParameteredCollection(this, endDate, endDate);
                    //}
                    //_actualSalesCollection.Load();

                    DateTime beginDateSR;
                    var endDateRA = new DateTime(_posSalesEndDate.Value.Year, _posSalesEndDate.Value.Month, 1);
                    var beginDateRA = endDateRA.AddMonths(-(int)_rollingAvageNumberOfMonths + (int)(_forecastFutureFrozenMonths >= 0 ? 0 : _forecastFutureFrozenMonths));
                    var endDateSR = beginDateSR = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    if (_forecastMethod == "SR")
                        _actualSalesCollection = new ActualSales.WithCustomerParentParameteredCollection(this, beginDateSR, endDateSR);
                    else if (_forecastMethod == "RA")
                        // for RA, take the union of the 2 collections
                        // an RA can be switched to SR when SalesRateExisting is not 0
                        _actualSalesCollection = new ActualSales.WithCustomerParentParameteredCollection(this, 
                            beginDateRA < beginDateSR ? beginDateRA : beginDateSR, 
                            endDateRA > endDateSR ? endDateRA : endDateSR);
                    if (_actualSalesCollection == null) return _actualSalesCollection;
                    _actualSalesCollection.Load();
                }
                return _actualSalesCollection;
            }
            set { _actualSalesCollection = value; }
        }
        #endregion

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

        public SqlString CustomerName
        {
            get { return _customerName; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_customerName.CompareTo(value) != 0)
                {
                    _customerName = value;
                    FieldDataChange("CustomerName", value);
                }
            }
        }

        public SqlBoolean DistinctForecastNameFlag
        {
            get { return _distinctForecastNameFlag; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_distinctForecastNameFlag.CompareTo(value) != 0)
                {
                    _distinctForecastNameFlag = value;
                    FieldDataChange("DistinctForecastNameFlag", value);
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
                    _actualSalesCollection = null;
                    FieldDataChange("ForecastMethod", value);
                }
                _forecastMethod = value;
            }
        }

        public SqlDecimal InflateFactor
        {
            get { return _inflateFactor; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_inflateFactor.CompareTo(value) != 0)
                {
                    _inflateFactor = value;
                    FieldDataChange("InflateFactor", value);
                }
            }
        }

        public SqlInt16 ForecastFutureFrozenMonths
        {
            get { return _forecastFutureFrozenMonths; }
            set {
                // use CompareTo for proper null value comparision
                if (_forecastFutureFrozenMonths.CompareTo(value) != 0)
                {
                    _forecastFutureFrozenMonths = value;
                    FieldDataChange("ForecastFutureFrozenMonths", value);
                }
            }
        }

        public SqlBytes RowVersion { get; set; }
        #endregion

        [NotMapped]
        public SqlInt16 RollingAvageNumberOfMonths
        {
            get { return _rollingAvageNumberOfMonths; }
            set {
                if (_rollingAvageNumberOfMonths.CompareTo(value) != 0)
                {
                    if (_forecastAction == ForecastAction.Generate)
                    {
                        _forecastCollection = null;
                        if (ForecastCollectionInvalidated != null)
                            ForecastCollectionInvalidated(this, new EventArgs());
                    }
                }
                _rollingAvageNumberOfMonths = value; }
        }

        [NotMapped]
        public SqlInt16 POSNumberOfWeeks
        {
            get { return _posNumberOfWeeks; }
            set {
                if (_posNumberOfWeeks.CompareTo(value) != 0)
                {
                    if (_forecastSalesRateAction == ForecastSalesRateAction.Generate)
                    {
                        _forecastSalesRateCollection = null;
                        if (ForecastSalesRateCollectionInvalidated != null)
                            ForecastSalesRateCollectionInvalidated(this, new EventArgs());
                    }
                }
                _posNumberOfWeeks = value;
            }
        }

        [NotMapped]
        public SqlDateTime POSSalesEndDate
        {
            get { return _posSalesEndDate; }
            set {
                if (_posSalesEndDate.CompareTo(value) != 0)
                {
                    //if (_forecastAction == ForecastAction.Generate)
                    //{
                        _forecastCollection = null;
                        if (ForecastCollectionInvalidated != null)
                            ForecastCollectionInvalidated(this, new EventArgs());
                        _actualSalesCollection = null;
                    //}
                    //if (_forecastSalesRateAction == ForecastSalesRateAction.Generate)
                    //{
                        _forecastSalesRateCollection = null;
                        if (ForecastSalesRateCollectionInvalidated != null)
                            ForecastSalesRateCollectionInvalidated(this, new EventArgs());
                    //}
                }
                _posSalesEndDate = value;
            }
        }

        [NotMapped]
        public ForecastAction ForecastAction
        {
            get { return _forecastAction; }
            set
            {
                var valueChanged = _forecastAction != value;
                if (valueChanged)
                {
                    _forecastCollection = null;
                    if (ForecastCollectionInvalidated != null)
                        ForecastCollectionInvalidated(this, new EventArgs());
                }
                _forecastAction = value;
                if (valueChanged && ForecastActionChangedx != null)
                    ForecastActionChangedx(this, new EventArgs());
            }
        }

        [NotMapped]
        public ForecastSalesRateAction ForecastSalesRateAction
        {
            get { return _forecastSalesRateAction; }
            set
            {
                var valueChanged = _forecastSalesRateAction != value;
                if (valueChanged)
                {
                    _forecastSalesRateCollection = null;
                    if (ForecastSalesRateCollectionInvalidated != null)
                        ForecastSalesRateCollectionInvalidated(this, new EventArgs());
                }
                _forecastSalesRateAction = value;
                if (valueChanged && ForecastSalesRateActionChangedx != null)
                    ForecastSalesRateActionChangedx(this, new EventArgs());
            }
        }

        public override bool Validate()
        {
            return (ObjectKey != null && !_customerName.IsNull);
        }

        private static void WriteForecastPLCrossTab(StreamWriter sw, Forecast forecast)
        {
            sw.Write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},", forecast.ItemNumber, forecast.ForecastMethod, forecast.PY01, forecast.PY02, forecast.PY03, forecast.PY04, forecast.PY05, forecast.PY06, forecast.PY07, forecast.PY08, forecast.PY09, forecast.PY10, forecast.PY11, forecast.PY12);
            sw.Write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},", forecast.CY01, forecast.CY02, forecast.CY03, forecast.CY04, forecast.CY05, forecast.CY06, forecast.CY07, forecast.CY08, forecast.CY09, forecast.CY10, forecast.CY11, forecast.CY12);
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", forecast.NY01, forecast.NY02, forecast.NY03, forecast.NY04, forecast.NY05, forecast.NY06, forecast.NY07, forecast.NY08, forecast.NY09, forecast.NY10, forecast.NY11, forecast.NY12);
        }

        private void WriteForecast(StreamWriter sw, Forecast forecast, SqlInt32 currentMonthActualSales)
        {
            var calendar = Calendar.GetInstance();

            var companyCode = CompanyCode == "002" || CompanyCode == "301" ? "001" : CompanyCode == "805" ? "803" : CompanyCode.Value;

            var forecastMethod = CompanyCode == "805" && CustomerNumber ==  "ZZZZ" ? "D" + forecast.ForecastMethod : forecast.ForecastMethod;

            var customerNumber = _distinctForecastNameFlag ? CustomerNumber.Value : "ZZZZ";
            customerNumber = customerNumber.Replace("-D", "").Replace("-E", "");

            var forecastNamePreffix = CompanyCode == "001" || CompanyCode == "805" || (CompanyCode == "803" && CustomerNumber.Value.IndexOf("-D", StringComparison.Ordinal) > -1) ? "DOM" : "EXP";

            if (CompanyCode == "301" && customerNumber == "ZZZZ") forecastNamePreffix = "CAN";

            if (CompanyCode == "001")
            {
                if (customerNumber == "91055") customerNumber = "TOPC";
                else if (customerNumber == "1854") customerNumber = "AMAZ";
            }
            else if (CompanyCode == "002")
            {
                if (customerNumber == "15285") customerNumber = "SINX";
                else if (customerNumber == "90946") customerNumber = "SIGN";
                else if (customerNumber == "90077") customerNumber = "ARCM";
                else if (customerNumber == "90281") customerNumber = "DROG";
                else if (customerNumber == "1641") customerNumber = "REPL";
                else if (customerNumber == "90947") customerNumber = "SIMC";
            }

            if (!forecast.PY01.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY01", forecast.CreatedDate.Value), forecast.PY01);
            if (!forecast.PY02.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY02", forecast.CreatedDate.Value), forecast.PY02);
            if (!forecast.PY03.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY03", forecast.CreatedDate.Value), forecast.PY03);
            if (!forecast.PY04.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY04", forecast.CreatedDate.Value), forecast.PY04);
            if (!forecast.PY05.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY05", forecast.CreatedDate.Value), forecast.PY05);
            if (!forecast.PY06.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY06", forecast.CreatedDate.Value), forecast.PY06);
            if (!forecast.PY07.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY07", forecast.CreatedDate.Value), forecast.PY07);
            if (!forecast.PY08.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY08", forecast.CreatedDate.Value), forecast.PY08);
            if (!forecast.PY09.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY09", forecast.CreatedDate.Value), forecast.PY09);
            if (!forecast.PY10.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY10", forecast.CreatedDate.Value), forecast.PY10);
            if (!forecast.PY11.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY11", forecast.CreatedDate.Value), forecast.PY11);
            if (!forecast.PY12.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("PY12", forecast.CreatedDate.Value), forecast.PY12);
            if (!forecast.CY01.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY01", forecast.CreatedDate.Value), forecast.CY01 - (DateTime.Today.Month == 1 ? currentMonthActualSales : 0));
            if (!forecast.CY02.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY02", forecast.CreatedDate.Value), forecast.CY02 - (DateTime.Today.Month == 2 ? currentMonthActualSales : 0));
            if (!forecast.CY03.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY03", forecast.CreatedDate.Value), forecast.CY03 - (DateTime.Today.Month == 3 ? currentMonthActualSales : 0));
            if (!forecast.CY04.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY04", forecast.CreatedDate.Value), forecast.CY04 - (DateTime.Today.Month == 4 ? currentMonthActualSales : 0));
            if (!forecast.CY05.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY05", forecast.CreatedDate.Value), forecast.CY05 - (DateTime.Today.Month == 5 ? currentMonthActualSales : 0));
            if (!forecast.CY06.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY06", forecast.CreatedDate.Value), forecast.CY06 - (DateTime.Today.Month == 6 ? currentMonthActualSales : 0));
            if (!forecast.CY07.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY07", forecast.CreatedDate.Value), forecast.CY07 - (DateTime.Today.Month == 7 ? currentMonthActualSales : 0));
            if (!forecast.CY08.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY08", forecast.CreatedDate.Value), forecast.CY08 - (DateTime.Today.Month == 8 ? currentMonthActualSales : 0));
            if (!forecast.CY09.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY09", forecast.CreatedDate.Value), forecast.CY09 - (DateTime.Today.Month == 9 ? currentMonthActualSales : 0));
            if (!forecast.CY10.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY10", forecast.CreatedDate.Value), forecast.CY10 - (DateTime.Today.Month == 10 ? currentMonthActualSales : 0));
            if (!forecast.CY11.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY11", forecast.CreatedDate.Value), forecast.CY11 - (DateTime.Today.Month == 11 ? currentMonthActualSales : 0));
            if (!forecast.CY12.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("CY12", forecast.CreatedDate.Value), forecast.CY12 - (DateTime.Today.Month == 12 ? currentMonthActualSales : 0));
            if (!forecast.NY01.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY01", forecast.CreatedDate.Value), forecast.NY01);
            if (!forecast.NY02.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY02", forecast.CreatedDate.Value), forecast.NY02);
            if (!forecast.NY03.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY03", forecast.CreatedDate.Value), forecast.NY03);
            if (!forecast.NY04.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY04", forecast.CreatedDate.Value), forecast.NY04);
            if (!forecast.NY05.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY05", forecast.CreatedDate.Value), forecast.NY05);
            if (!forecast.NY06.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY06", forecast.CreatedDate.Value), forecast.NY06);
            if (!forecast.NY07.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY07", forecast.CreatedDate.Value), forecast.NY07);
            if (!forecast.NY08.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY08", forecast.CreatedDate.Value), forecast.NY08);
            if (!forecast.NY09.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY09", forecast.CreatedDate.Value), forecast.NY09);
            if (!forecast.NY10.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY10", forecast.CreatedDate.Value), forecast.NY10);
            if (!forecast.NY11.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY11", forecast.CreatedDate.Value), forecast.NY11);
            if (!forecast.NY12.IsNull) sw.WriteLine("{0},{1}{2}{3},{4},{5},{6}", companyCode, forecastNamePreffix, customerNumber, forecastMethod, forecast.ItemNumber, calendar.GetMMdash01dashYY("NY12", forecast.CreatedDate.Value), forecast.NY12);
        }

        internal void ExportForecastToText(StreamWriter swForecast, StreamWriter swForecastComment)
        {
            WriteForecastToText(swForecast, swForecastComment);
            _forecastCollection = null; //release the memory for GC
        }

        internal void ExportForecastToOracle(StreamWriter swForecast, StreamWriter swForecastComment, bool subtractCurrentMonthSales)
        {
            foreach (var forecast in ForecastCollection)
            {
                var actualSalesQuantity = SqlInt32.Zero;
                if (subtractCurrentMonthSales)
                {
                    var actualSales = ActualSalesCollection[new ActualSalesKey(forecast.CompanyCode, forecast.CustomerNumber, forecast.ItemNumber, new SqlDateTime(DateTime.Today.Year, DateTime.Today.Month, 1))];
                    if (actualSales != null && actualSales.Quantity > SqlInt32.Zero)
                        actualSalesQuantity = actualSales.Quantity;
                }
                WriteForecast(swForecast, forecast, actualSalesQuantity);
            }
            _forecastCollection = null; //release the memory for GC
        }

        public void ExportSalesRate(DateTime posWeekEndDateEnd, string filePath, bool appendFile)
        {
            using (var sw = new StreamWriter(filePath, appendFile))
            {
                _forecastSalesRateCollection = null;
                _posSalesEndDate = posWeekEndDateEnd;
                ForecastSalesRateAction = ForecastSalesRateAction.Get;
                if (ForecastSalesRateCollection.Count > 0)
                {
                    var firstForecastSalesRate = ForecastSalesRateCollection[0];
                    sw.WriteLine("Company: {0} - Customer: {1} - POS End Date: {2:MM-dd-yyyy}", firstForecastSalesRate.CompanyCode, firstForecastSalesRate.CustomerNumber, firstForecastSalesRate.POSSalesEndDate.Value);
                    sw.WriteLine("Item No.,Trend,POS Wk1 ({0:MM-dd-yyyy}),POS Wk2 ({1:MM-dd-yyyy}),POS Wk3 ({2:MM-dd-yyyy}),POS Wk4 ({3:MM-dd-yyyy}),POS Total,# Store Existing,# Store New,# Store Total,Rate,Compare,Difference,% Difference",
                        firstForecastSalesRate.POSSalesEndDate.Value.AddDays(-21),
                        firstForecastSalesRate.POSSalesEndDate.Value.AddDays(-14),
                        firstForecastSalesRate.POSSalesEndDate.Value.AddDays(-7),
                        firstForecastSalesRate.POSSalesEndDate.Value);
                    foreach (var forecastSalesRate in ForecastSalesRateCollection)
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                            forecastSalesRate.ItemNumber, forecastSalesRate.TrendFactor, forecastSalesRate.POSWeek1Quantity,
                            forecastSalesRate.POSWeek2Quantity, forecastSalesRate.POSWeek3Quantity, forecastSalesRate.POSWeek4Quantity,
                            forecastSalesRate.POSTotal, forecastSalesRate.StoreCountExisting, forecastSalesRate.StoreCountNew,
                            forecastSalesRate.StoreCountTotal, forecastSalesRate.SalesRate, forecastSalesRate.SalesRatePrevious,
                            forecastSalesRate.SalesRateDifference, forecastSalesRate.SalesRateDifferencePercent);
                }
                _forecastSalesRateCollection = null; //release the memory for GC and UI will get a new collection with the UI posWeekEndDateEnd
            }
        }

        public void ExportBonusAndDiscontinued(ExportType exportType, string filePath, bool appendFile)
        {
            using (var sw = new StreamWriter(filePath, appendFile))
            {
                if (BonusAndDiscontinuedCollection.Count <= 0) return;
                var firstBonusAndDiscontinuedByCustomer = BonusAndDiscontinuedCollection[0];
                sw.WriteLine("Company: {0} - Customer: {1}", firstBonusAndDiscontinuedByCustomer.CompanyCode,
                             firstBonusAndDiscontinuedByCustomer.CustomerNumber);
                sw.Write("Item No");
                sw.Write(exportType == ExportType.Bonus
                             ? ((Company) Parent).BuildBonusMonthExportHeader()
                             : ",Discontinued");
                sw.WriteLine();
                foreach (var bonusAndDiscontinuedByCustomer in BonusAndDiscontinuedCollection.Where(bonusAndDiscontinuedByCustomer => exportType != ExportType.Discontinued || !bonusAndDiscontinuedByCustomer.DiscontinuedEffectiveDate.IsNull))
                {
                    if (exportType == ExportType.Bonus)
                    {
                        var hasBonusValue = bonusAndDiscontinuedByCustomer.BonusNumOfDaysCollection.Any(t => !t.IsNull);
                        if (!hasBonusValue)
                            continue;
                    }
                    sw.Write(bonusAndDiscontinuedByCustomer.ItemNumber);
                    if (exportType == ExportType.Discontinued)
                        sw.WriteLine(",{0:MM-dd-yyyy}",
                                     bonusAndDiscontinuedByCustomer.DiscontinuedEffectiveDate.Value);
                    else
                    {
                        foreach (var t in bonusAndDiscontinuedByCustomer.BonusNumOfDaysCollection)
                            sw.Write(",{0}", t);
                        sw.WriteLine();
                    }
                }
            }
        }

        private IThreeYearMonthlyIntegerValue GetBonusItem(SqlString itemNumber, out SqlString bonusItemNumber)
        {
            // bonus item by customer has higher precedence than by company
            foreach (var bonusByCustomer in BonusAndDiscontinuedCollection.Where(bonusByCustomer => (bool) (!bonusByCustomer.ItemNumber.IsNull &&
                                                                                                            bonusByCustomer.ItemNumber.Value.Substring(0, 10) == itemNumber.Value.Substring(0, 10) &&
                                                                                                            bonusByCustomer.ItemNumber != itemNumber)))
            {
                bonusItemNumber = bonusByCustomer.ItemNumber;
                return bonusByCustomer;
            }
            foreach (var bonusByCompany in ((Company)Parent).BonusAndDiscontinuedCollection.Where(bonusByCompany => (bool) (!bonusByCompany.ItemNumber.IsNull &&
                                                                                                                            bonusByCompany.ItemNumber.Value.Substring(0, 10) == itemNumber.Value.Substring(0, 10) &&
                                                                                                                            bonusByCompany.ItemNumber != itemNumber)))
            {
                bonusItemNumber = bonusByCompany.ItemNumber;
                return bonusByCompany;
            }
            bonusItemNumber = SqlString.Null;
            return null;
        }

        internal void GenerateAndSaveForecast()
        {
            using (var transaction = new Transaction())
            {
                // delete the existing collection
                _forecastCollection = null;
                _forecastAction = ForecastAction.Get;
                transaction.Enlist(ForecastCollection);
                ForecastCollection.Delete();

                // generate and save new forecast collection
                _forecastCollection = null;
                _forecastAction = ForecastAction.Generate;
                ForecastCollection.MarkNew();
                transaction.Enlist(ForecastCollection);
                _forecastCollection.Save();
                transaction.Commit();

                // clear to conserve memory
                _forecastCollection = null;
            }
        }

        public static string GetForecastCommentTxtFileName(string fileName)
        {
            var dotPosistion = fileName.LastIndexOf('.');
            return string.Format("{0}_comment.{1}", fileName.Substring(0, dotPosistion), fileName.Substring(dotPosistion + 1));
        }

        public static void WriteForecastToTxtHeaders(StreamWriter swForecast, StreamWriter swForecastComment)
        {
            const string months = "\tPY01\tPY02\tPY03\tPY04\tPY05\tPY06\tPY07\tPY08\tPY09\tPY10\tPY11\tPY12";
            var sb = new StringBuilder();
            sb.Append("Company\tCustomer\tForecast Date\tItem #\tMethod")
                .Append(months)
                .Append(months.Replace('P', 'C'))
                .Append(months.Replace('P', 'N'));
            swForecast.WriteLine(sb.ToString());

            swForecastComment.WriteLine("Company\tCustomer\tForecast Date\tItem #\tMethod\tMonth\tComment Time\tComment");
        }

        public void WriteForecastToText(StreamWriter swForecast, StreamWriter swForecastComment)
        {
            var forecastCommentCollection = new List<ForecastCommentAndOverride>();
            StringBuilder sb;

            foreach (var forecast in _forecastCollection)
            {
                sb = new StringBuilder();
                sb.Append('!').Append(forecast.CompanyCode).Append('\t');
                sb.Append(forecast.CustomerNumber).Append('\t');
                sb.Append(forecast.POSSalesEndDate).Append('\t');
                sb.Append(forecast.ItemNumber).Append('\t');
                sb.Append(forecast.ForecastMethod).Append('\t');
                if (forecast.HasComment)
                    forecastCommentCollection.AddRange(forecast.ForecastCommentAndOverrideCollection.Where(c => !c.Comment.IsNull));

                foreach (var qty in forecast.ForecastQuantityCollection)
                    sb.Append(qty.IsNull ? "" : qty.ToString()).Append('\t');
                sb.Remove(sb.Length - 1, 1);

                swForecast.WriteLine(sb.ToString());
            }

            foreach (var forecastComment in forecastCommentCollection)
            {
                sb = new StringBuilder();
                sb.Append('!').Append(forecastComment.CompanyCode).Append('\t');
                sb.Append(forecastComment.CustomerNumber).Append('\t');
                sb.Append(forecastComment.POSSalesEndDate).Append('\t');
                sb.Append(forecastComment.ItemNumber).Append('\t');
                sb.Append(forecastComment.ForecastMethod).Append('\t');
                sb.Append(forecastComment.ForecastValueKey).Append('\t');
                sb.Append(forecastComment.CommentOverrideDateTime).Append('\t');
                sb.Append(forecastComment.Comment.Value.Replace(Environment.NewLine, "{crlf}"));

                swForecastComment.WriteLine(sb.ToString());
            }
        }

        public void PopulateForecastFromTxt(string fileName)
        {
            _forecastCollection = new Forecast.WithCustomerParentParameteredCollection { Parent = this };

            // populate forecast comment from txt file
            var forecastCommentCollection = new List<ForecastCommentAndOverride>();
            var forecastCommentFileName = GetForecastCommentTxtFileName(fileName);
            var lineCount = 0;
            if (File.Exists(forecastCommentFileName))
            {
                using (var sr = new StreamReader(forecastCommentFileName))
                {
                    sr.ReadLine();
                    lineCount++;
                    while (sr.Peek() >= 0)
                    {
                        var columns = sr.ReadLine().Split('\t');
                        lineCount++;
                        if (columns.Length != 8)
                            throw new FormatException("The number of columns in the forecast comment txt file must be 8. The error is on line " + lineCount + ".");
                        var companyCode = columns[0].Replace("!", "");
                        if (companyCode != _companyCode || columns[1] != _customerNumber || Convert.ToDateTime(columns[2]) != _posSalesEndDate)
                            throw new DataException("Key Data in forecast comment txt file is not consistent. The error is on line " + lineCount + ".");
                        forecastCommentCollection.Add(new ForecastCommentAndOverride
                        {
                            CompanyCode = _companyCode,
                            CustomerNumber = _customerNumber,
                            POSSalesEndDate = Convert.ToDateTime(columns[2]),
                            ItemNumber = columns[3],
                            ForecastMethod = columns[4],
                            ForecastValueKey = columns[5],
                            CommentOverrideDateTime = Convert.ToDateTime(columns[6]),
                            Comment = columns[7].Replace("{crlf}", Environment.NewLine)
                        });
                    }
                }
            }

            // populate forecast from txt file
            using (var sr = new StreamReader(fileName))
            {
                sr.ReadLine();
                lineCount = 1;
                while (sr.Peek() >= 0)
                {
                    var columns = sr.ReadLine().Split('\t');
                    lineCount++;
                    if (columns.Length != 41)
                        throw new FormatException("The number of columns in the forecast txt file must be 41. The error is on line " + lineCount + ".");
                    var companyCode = columns[0].Replace("!", "");
                    if (companyCode != _companyCode || columns[1] != _customerNumber || Convert.ToDateTime(columns[2]) != _posSalesEndDate)
                        throw new DataException("Key data in forecast txt file is not consistent. The error is on line " + lineCount + ".");
                    var forecastKey = new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, columns[3], columns[4]);
                    var forecast = _forecastCollection.Create(forecastKey);
                    for (var i = 5; i < 41; i++)
                    {
                        if (!string.IsNullOrEmpty(columns[i]))
                        {
                            var quantity = Math.Round(Convert.ToDecimal(columns[i]), 0);
                            forecast.ForecastQuantityCollection[i - 5] = Convert.ToInt32(quantity);
                        }
                        else
                            forecast.ForecastQuantityCollection[i - 5] = SqlInt32.Null;
                    }
                    var comments = forecastCommentCollection.Where(
                        c => (c.CompanyCode == forecast.CompanyCode && c.CustomerNumber == forecast.CustomerNumber &&
                              c.POSSalesEndDate == forecast.POSSalesEndDate && c.ItemNumber == forecast.ItemNumber &&
                              c.ForecastMethod == forecast.ForecastMethod).Value).ToArray();
                    if (comments.Length > 0)
                    {
                        forecast.HasComment = true;
                        forecast.ForecastCommentAndOverrideCollection = new ForecastCommentAndOverride.WithForecastParentCollection(forecast);
                        foreach (var comment in comments)
                        {
                            var forecastComment = forecast.ForecastCommentAndOverrideCollection.Create(new ForecastCommentAndOverrideKey
                            {
                                CompanyCode = forecast.CompanyCode,
                                CustomerNumber = forecast.CustomerNumber,
                                POSSalesEndDate = forecast.POSSalesEndDate,
                                ItemNumber = forecast.ItemNumber,
                                ForecastMethod = forecast.ForecastMethod,
                                ForecastValueKey = comment.ForecastValueKey,
                                CommentOverrideDateTime = comment.CommentOverrideDateTime,
                            });
                            forecastComment.Comment = comment.Comment;
                            forecast.ForecastCommentAndOverrideCollection.Add(forecastComment);
                        }
                    }

                    forecast.CreatedDate = DateTime.Today;
                    _forecastCollection.Add(forecast);
                }
            }

            // get the version for the forecast set from db
            if (_forecastCollection.Count > 0)
            {
                _forecastCollection.SetHeader = new ForecastCollectionHeader(_forecastCollection[0].CompanyCode,
                                                                             _forecastCollection[0].CustomerNumber,
                                                                             _forecastCollection[0].POSSalesEndDate);
                ((IPersistenceObject)_forecastCollection.SetHeader).Load();
            }
        }

        private void GenerateForecast()
        {
            // always base on Forecast Parameter
            _forecastCollection = new Forecast.WithCustomerParentParameteredCollection {Parent = this};
            foreach (var param in ForecastParameterCollection)
                GenerateForecastItem(param.ItemNumber, param);

            // get the version for the forecast set from db
            if (_forecastCollection.Count > 0)
            {
                _forecastCollection.SetHeader = new ForecastCollectionHeader(_forecastCollection[0].CompanyCode,
                                                                             _forecastCollection[0].CustomerNumber,
                                                                             _forecastCollection[0].POSSalesEndDate);
                ((IPersistenceObject) _forecastCollection.SetHeader).Load();
            }

            PopulatePastForecast();
            RestoreManualForecast();

            // clear to conserve memory
            _forecastPreviousCollection = null;
            _forecastTrendByCustomerProductGroupItemCollection = null;
            _forecastTrendByCompanyProductGroupItemCollection = null;

            //if (_forecastMethod == "RA")
            //{
            //    _forecastCollection = new Forecast.WithCustomerParentParameteredCollection();
            //    _forecastCollection.Parent = this;
            //    string previousItemNumber = string.Empty;
            //    foreach (ActualSales actualSales in ActualSalesCollection)
            //    {
            //        if (previousItemNumber != actualSales.ItemNumber)
            //        {
            //            ForecastParameter param = ForecastParameterCollection[new ForecastParameterKey(actualSales.CompanyCode, actualSales.CustomerNumber, actualSales.ItemNumber)];
            //            GenerateForecastItem(actualSales.ItemNumber, param);
            //            previousItemNumber = actualSales.ItemNumber.Value;
            //        }
            //    }
            //    PopulatePastForecast();
            //    RestoreManualForecast();
            //    // clear to conserve memory
            //    this._actualSalesCollection = null;
            //}
            //else if (_forecastMethod == "SR")
            //{
            //    _forecastCollection = new Forecast.WithCustomerParentParameteredCollection();
            //    _forecastCollection.Parent = this;
            //    foreach (ForecastParameter param in ForecastParameterCollection)
            //        GenerateForecastItem(param.ItemNumber, param);
            //    PopulatePastForecast();
            //    RestoreManualForecast();
            //    // clear to conserve memory
            //    this._forecastTrendByCustomerProductGroupItemCollection = null;
            //    this._forecastTrendByCompanyProductGroupItemCollection = null;
            //}
        }

        private void GenerateForecastItem(SqlString itemNumber, ForecastParameter param)
        {
            var calendar = Calendar.GetInstance();
            var forecastMonthYYMM = string.Empty;
            var YYMMMonthOverrideStart = string.Empty;
            var YYMMMonthOverrideEnd = string.Empty;
            SqlDecimal trendFactorPlOverride;
            var startMonth = _forecastFutureFrozenMonths.Value < 0 ? _posSalesEndDate.Value.AddMonths(_forecastFutureFrozenMonths.Value).Month : _posSalesEndDate.Value.Month;
            
            var activeForecastMethod = _forecastMethod;
            if (activeForecastMethod == "RA" && !param.ProjectedSalesRateExisting.IsNull && param.ProjectedSalesRateExisting != 0)
                activeForecastMethod = "SR";

            var pipeLine = IsPipeLine(param);
            if (pipeLine)
            {
                for (var month = startMonth; month < startMonth + 36; month++)
                {
                    var forecastMonth = new DateTime(_posSalesEndDate.Value.Year, _posSalesEndDate.Value.Month, 1).AddMonths(month - startMonth + _forecastFutureFrozenMonths.Value + 1);
                    forecastMonthYYMM = calendar.GetYYMM(forecastMonth);
                    if (String.CompareOrdinal(forecastMonthYYMM, calendar.GetYYMM("NY12")) > 0)
                        break;
                    trendFactorPlOverride = param.PlPctCollection[calendar.Get3YearCollectionOffset(calendar.GetPWCForecastMonth(forecastMonth))];
                    if (!trendFactorPlOverride.IsNull && trendFactorPlOverride != 0 && YYMMMonthOverrideStart == string.Empty)
                        YYMMMonthOverrideStart = forecastMonthYYMM;
                    if (!trendFactorPlOverride.IsNull && trendFactorPlOverride != 0 && YYMMMonthOverrideStart != string.Empty)
                        YYMMMonthOverrideEnd = forecastMonthYYMM;
                    if (String.CompareOrdinal(forecastMonthYYMM, calendar.GetYYMM(param.PipelineEnd.ToString())) > 0)
                        break;
                }
            }

            var itemLastDate = GetItemLastDate(_companyCode, _customerNumber, itemNumber);

            SqlString bonusItemNumber;
            var bonusItem = GetBonusItem(itemNumber, out bonusItemNumber);

            var forecastPLKey = new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, itemNumber, "PL");
            var forecastSRorRAKey = new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, itemNumber, activeForecastMethod);
            Forecast forecastPL = null;
            Forecast forecastSRorRA = null;
            Forecast forecastPLBonus = null;
            Forecast forecastSRorRABonus = null;
            var frozenUpToYYMM = calendar.GetYYMM(_posSalesEndDate.Value.AddMonths(_forecastFutureFrozenMonths.Value));

            for (var month = startMonth; month < startMonth + 36; month++)
            {
                var forecastMonth = new DateTime(_posSalesEndDate.Value.Year, _posSalesEndDate.Value.Month, 1).AddMonths(month - startMonth + _forecastFutureFrozenMonths.Value + 1);
                forecastMonthYYMM = calendar.GetYYMM(forecastMonth);
                var itemLastDateCompareResult = -1; // -1 in range, 0 last month, 1 out of range
                if (!itemLastDate.IsNull)
                {
                    itemLastDateCompareResult = String.CompareOrdinal(forecastMonthYYMM, calendar.GetYYMM(itemLastDate.Value));
                    if (itemLastDateCompareResult > 0) // out of range break out of loop
                    {
                        // handle special case when discontinued month = forecastMonth and forecastMonth is 1 month later than current month
                        // ex: discontinued 02/01/09, forecastMonth 02/01/09, current month 01/01/09
                        if (String.CompareOrdinal(calendar.GetYYMM(DateTime.Today), calendar.GetYYMM(itemLastDate.Value)) == 0)
                        {
                            if (forecastSRorRA == null && !param.OneTimeItemFlag)
                            {
                                forecastSRorRA = _forecastCollection.Create(forecastSRorRAKey);
                                forecastSRorRA.CreatedDate = DateTime.Today;
                                _forecastCollection.Add(forecastSRorRA);
                            }
                            if (pipeLine && forecastPL == null)
                            {
                                forecastPL = _forecastCollection.Create(forecastPLKey);
                                forecastPL.CreatedDate = DateTime.Today;
                                _forecastCollection.Add(forecastPL);
                            }
                            if (bonusItem != null)
                            {
                                if (forecastSRorRABonus == null && !param.OneTimeItemFlag)
                                {
                                    forecastSRorRABonus = _forecastCollection.Create(new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, bonusItemNumber, activeForecastMethod));
                                    forecastSRorRABonus.CreatedDate = DateTime.Today;
                                    _forecastCollection.Add(forecastSRorRABonus);
                                }
                                if (pipeLine && forecastPLBonus == null)
                                {
                                    forecastPLBonus = _forecastCollection.Create(new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, bonusItemNumber, "PL"));
                                    forecastPLBonus.CreatedDate = DateTime.Today;
                                    _forecastCollection.Add(forecastPLBonus);
                                }
                            }
                        }
                        break;
                    }
                }
                if (String.CompareOrdinal(forecastMonthYYMM, calendar.GetYYMM("NY12")) > 0)
                    break;
                if (!pipeLine && String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) <= 0)
                    continue;
                var pwcForecastMonth = calendar.GetPWCForecastMonth(forecastMonth);
                var forecastQtyCollectionOffset = calendar.Get3YearCollectionOffset(pwcForecastMonth);
                SqlDecimal trendFactorSR = SqlDecimal.Null, numberOfWeeks = SqlDecimal.Null;
                if (activeForecastMethod == "SR")
                {
                    trendFactorSR = GetTrendFactor(itemNumber, activeForecastMethod, forecastMonth.Month);
                    numberOfWeeks = Decimal.One * DateTime.DaysInMonth(forecastMonth.Year, forecastMonth.Month) / 7;
                }
                SqlInt32 forecastPLQty = SqlInt32.Null, forecastSRorRAQty = SqlInt32.Null;
                if (pipeLine)
                {
                    if (String.CompareOrdinal(forecastMonthYYMM, calendar.GetYYMM(param.PipelineStart.ToString())) < 0) // before pipeline start
                    {
                        if (String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) > 0 && !param.OneTimeItemFlag)
                        {
                            if (activeForecastMethod == "SR")
                                forecastSRorRAQty = SqlDecimal.Round(param.StoreCountExisting * param.ProjectedSalesRateExisting * numberOfWeeks * trendFactorSR / 100, 0).ToSqlInt32();
                            else if (activeForecastMethod == "RA")
                                forecastSRorRAQty = CalculateForecastRA(forecastMonth, itemNumber);
                        }
                    }
                    else if (String.CompareOrdinal(calendar.GetYYMM(param.PipelineEnd.ToString()), forecastMonthYYMM) >= 0) // in pipeline period
                    {
                        trendFactorPlOverride = param.PlPctCollection[calendar.Get3YearCollectionOffset(pwcForecastMonth)];
                        if (trendFactorPlOverride.IsNull || trendFactorPlOverride == 0)
                        {
                            if (String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) > 0 && !param.OneTimeItemFlag)
                            {
                                if (activeForecastMethod == "SR")
                                {
                                    if (String.CompareOrdinal(forecastMonthYYMM, YYMMMonthOverrideStart) < 0) // use before pipeline calculation
                                        forecastSRorRAQty = SqlDecimal.Round(param.StoreCountExisting * param.ProjectedSalesRateExisting * numberOfWeeks * trendFactorSR / 100, 0).ToSqlInt32();
                                    else if (String.CompareOrdinal(forecastMonthYYMM, YYMMMonthOverrideEnd) > 0)
                                        forecastSRorRAQty = SqlDecimal.Round((param.StoreCountNew + param.StoreCountExisting) * param.ProjectedSalesRateNew * numberOfWeeks * trendFactorSR / 100, 0).ToSqlInt32();
                                }
                                else if (activeForecastMethod == "RA")
                                    forecastSRorRAQty = CalculateForecastRA(forecastMonth, itemNumber);
                            }
                        }
                        else
                        {
                            if (activeForecastMethod == "SR")
                            {
                                forecastPLQty = SqlDecimal.Round(param.StoreCountNew * param.InitialQtyPerNewStore * trendFactorPlOverride / 100, 0).ToSqlInt32();
                                if (String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) > 0 && !param.OneTimeItemFlag)
                                    forecastSRorRAQty = SqlDecimal.Round(param.StoreCountExisting * param.ProjectedSalesRateExisting * numberOfWeeks * trendFactorSR / 100, 0).ToSqlInt32();
                            }
                            else if (activeForecastMethod == "RA")
                            {
                                forecastPLQty = SqlDecimal.Round(param.StoreCountNew * param.InitialQtyPerNewStore * trendFactorPlOverride / 100, 0).ToSqlInt32();
                                if (String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) > 0 && !param.OneTimeItemFlag)
                                    forecastSRorRAQty = CalculateForecastRA(forecastMonth, itemNumber);
                            }
                        }
                    }
                    else // after pipeline period
                    {
                        if (String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) > 0 && !param.OneTimeItemFlag)
                        {
                            if (activeForecastMethod == "SR")
                                forecastSRorRAQty = SqlDecimal.Round((param.StoreCountNew + param.StoreCountExisting) * param.ProjectedSalesRateExisting * numberOfWeeks * trendFactorSR / 100, 0).ToSqlInt32();
                            else if (activeForecastMethod == "RA")
                                forecastSRorRAQty = CalculateForecastRA(forecastMonth, param.ItemNumber);
                        }
                    }
                }
                else if (!param.OneTimeItemFlag) // not pipeline
                {
                    if (activeForecastMethod == "SR")
                        forecastSRorRAQty = SqlDecimal.Round((param.StoreCountNew + param.StoreCountExisting) * param.ProjectedSalesRateExisting * numberOfWeeks * trendFactorSR / 100, 0).ToSqlInt32();
                    else if (activeForecastMethod == "RA")
                        forecastSRorRAQty = CalculateForecastRA(forecastMonth, itemNumber);
                }
                //if (!forecastPLQty.IsNull)
                if (pipeLine)
                {
                    if (itemLastDateCompareResult == 0) // last month when discontinued starts, apply the ratio to the qty
                        forecastPLQty = SqlDecimal.Round(forecastPLQty * (new SqlDecimal(itemLastDate.Value.Day) / DateTime.DaysInMonth(itemLastDate.Value.Year, itemLastDate.Value.Month)), 0).ToSqlInt32();

                    if (forecastPL == null)
                    {
                        forecastPL = _forecastCollection.Create(forecastPLKey);
                        forecastPL.CreatedDate = DateTime.Today;
                        _forecastCollection.Add(forecastPL);
                    }
                    forecastPL.ForecastQuantityCollection[forecastQtyCollectionOffset] = forecastPLQty;

                    if (bonusItem != null)
                    {
                        if (forecastPLBonus == null)
                        {
                            forecastPLBonus = _forecastCollection.Create(new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, bonusItemNumber, "PL"));
                            forecastPLBonus.CreatedDate = DateTime.Today;
                            _forecastCollection.Add(forecastPLBonus);
                        }
                        var bonusForecastQty = GetBonusForecastQty(bonusItem, pwcForecastMonth, forecastPLQty);
                        forecastPLBonus.ForecastQuantityCollection[forecastQtyCollectionOffset] = bonusForecastQty;
                        if (!bonusForecastQty.IsNull)
                            forecastPL.ForecastQuantityCollection[forecastQtyCollectionOffset] = forecastPLQty - bonusForecastQty;
                    }
                }
                //if (!forecastSRorRAQty.IsNull)
                if (String.CompareOrdinal(forecastMonthYYMM, frozenUpToYYMM) <= 0 || param.OneTimeItemFlag)
                    continue;

                if (activeForecastMethod == "SR" && !_inflateFactor.IsNull)
                    forecastSRorRAQty = SqlDecimal.Round(forecastSRorRAQty * (_inflateFactor + 100) / 100, 2).ToSqlInt32();

                if (itemLastDateCompareResult == 0) // last month when discontinued starts, apply the ratio to the qty
                    forecastSRorRAQty = SqlDecimal.Round(forecastSRorRAQty * (new SqlDecimal(itemLastDate.Value.Day) / DateTime.DaysInMonth(itemLastDate.Value.Year, itemLastDate.Value.Month)), 0).ToSqlInt32();

                if (forecastSRorRA == null)
                {
                    forecastSRorRA = _forecastCollection.Create(forecastSRorRAKey);
                    forecastSRorRA.CreatedDate = DateTime.Today;
                    _forecastCollection.Add(forecastSRorRA);
                }
                forecastSRorRA.ForecastQuantityCollection[forecastQtyCollectionOffset] = forecastSRorRAQty;

                if (bonusItem != null)
                {
                    if (forecastSRorRABonus == null)
                    {
                        forecastSRorRABonus = _forecastCollection.Create(new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, bonusItemNumber, activeForecastMethod));
                        forecastSRorRABonus.CreatedDate = DateTime.Today;
                        _forecastCollection.Add(forecastSRorRABonus);
                    }
                    var bonusForecastQty = GetBonusForecastQty(bonusItem, pwcForecastMonth, forecastSRorRAQty);
                    forecastSRorRABonus.ForecastQuantityCollection[forecastQtyCollectionOffset] = bonusForecastQty;
                    if (!bonusForecastQty.IsNull)
                        forecastSRorRA.ForecastQuantityCollection[forecastQtyCollectionOffset] = forecastSRorRAQty - bonusForecastQty; //reset the regular forecast to the original - bonus
                }
            }
        }

        private void RestoreManualForecast()
        {
            if (ForecastPreviousCollection.Count <= 0)
                return;

            // restore the manual forecast 
            foreach (var manualForecast in ForecastPreviousCollection)
            {
                var forecastKey = new ForecastKey(manualForecast.CompanyCode, manualForecast.CustomerNumber, _posSalesEndDate, manualForecast.ItemNumber, manualForecast.ForecastMethod);
                var forecast = _forecastCollection[forecastKey];
                if (forecast == null) // if not found with one forecast method then try the other
                {
                    forecastKey.ForecastMethod = forecastKey.ForecastMethod == "SR" ? "RA" : (forecastKey.ForecastMethod == "RA" ? "SR" : forecastKey.ForecastMethod);
                    forecast = _forecastCollection[forecastKey];
                }
                if (forecast == null)
                    continue;

                // cannot retain the original manual forecast CreatedDate
                // because the CreatedDate is used as a based date for exporting forecast and offset for populating past and manual forcast
                //forecast.CreatedDate = manualForecast.CreatedDate;
                var offset = (forecast.CreatedDate.Value.Year - manualForecast.CreatedDate.Value.Year) * 12;
                var calendar = Calendar.GetInstance();
                if (!manualForecast.HasComment && !manualForecast.HasOverride)
                    continue;

                forecast.HasComment = manualForecast.HasComment;
                forecast.HasOverride = manualForecast.HasOverride;
                foreach (var manualCommentAndOverride in manualForecast.ForecastCommentAndOverrideCollection)
                {
                    var forecastQtyCollectionOffset = calendar.Get3YearCollectionOffset(manualCommentAndOverride.ForecastValueKey.Value);
                    if (forecastQtyCollectionOffset + offset >= 36)
                        continue;
                    forecast.ForecastQuantityCollection[forecastQtyCollectionOffset] =
                        manualForecast.ForecastQuantityCollection[forecastQtyCollectionOffset + offset];

                    var commentAndOverrideKey =
                        new ForecastCommentAndOverrideKey((ForecastKey)forecast.ObjectKey,
                                                             manualCommentAndOverride.ForecastValueKey,
                                                             manualCommentAndOverride.CommentOverrideDateTime);
                    var commentAndOverride = forecast.ForecastCommentAndOverrideCollection.Create(commentAndOverrideKey);
                    commentAndOverride.Comment = manualCommentAndOverride.Comment;
                    commentAndOverride.IsOverride = manualCommentAndOverride.IsOverride;
                    forecast.ForecastCommentAndOverrideCollection.Add(commentAndOverride);

                    // need more work in the core for this to work
                    //var commentAndOverride = new ForecastCommentAndOverride();
                    //commentAndOverride.LoadFromObject(manualCommentAndOverride);
                    //commentAndOverride.ObjectKey = commentAndOverrideKey;
                    //forecast.ForecastCommentAndOverrideCollection.Add(commentAndOverride);
                }
            }
        }

        private void PopulatePastForecast()
        {
            if (ForecastPreviousCollection.Count <= 0)
                return;

            var calendar = Calendar.GetInstance();
            var startMonth = _posSalesEndDate.Value.AddMonths(_forecastFutureFrozenMonths.Value).Month;

            // populate past forecast
            var posWeekEndDateEnd = _forecastCollection[0].POSSalesEndDate;
            var previousPosWeekEndDateEnd = _forecastPreviousCollection[0].POSSalesEndDate;
            foreach (var forecast in _forecastCollection)
            {
                var previousForecastKey = new ForecastKey(forecast.CompanyCode, forecast.CustomerNumber, previousPosWeekEndDateEnd, forecast.ItemNumber, forecast.ForecastMethod);
                var previousForecast = _forecastPreviousCollection[previousForecastKey];
                if (previousForecast == null) // if not found on one forecast method then try the other
                {
                    previousForecastKey.ForecastMethod = previousForecastKey.ForecastMethod == "SR" ? "RA" : (previousForecastKey.ForecastMethod == "RA" ? "SR" : previousForecastKey.ForecastMethod);
                    previousForecast = _forecastPreviousCollection[previousForecastKey];
                }
                if (previousForecast == null)
                    continue;

                var forecastSetYearOffset = (forecast.CreatedDate.Value.Year - previousForecast.CreatedDate.Value.Year) * 12;
                for (var month = startMonth; month > startMonth - 36; month--)
                {
                    var forecastMonth = new DateTime(_posSalesEndDate.Value.Year, _posSalesEndDate.Value.Month, 1).AddMonths(month - startMonth + _forecastFutureFrozenMonths.Value);
                    // do not populate past forecast for PL when forecast month is > current month + forecastFutureFrozenMonths
                    if (forecast.ForecastMethod == "PL" &&
                        String.CompareOrdinal(calendar.GetYYMM(forecastMonth), calendar.GetYYMM(posWeekEndDateEnd.Value.AddMonths(_forecastFutureFrozenMonths.Value))) > 0)
                        continue;
                    if (String.CompareOrdinal(calendar.GetYYMM(forecastMonth), calendar.GetYYMM("PY01")) < 0)
                        break;
#if true
                    var forecastQtyCollectionOffset = calendar.Get3YearCollectionOffset(calendar.GetPWCForecastMonth(forecastMonth));
                    if (forecastQtyCollectionOffset + forecastSetYearOffset < 36)
                        forecast.ForecastQuantityCollection[forecastQtyCollectionOffset] = previousForecast.ForecastQuantityCollection[forecastQtyCollectionOffset + forecastSetYearOffset];
#else
                        string PWCForecastMonth = calendar.GetPWCForecastMonth(forecastMonth);
                        switch (PWCForecastMonth)
                        {
                            case "PY01": if (0 + forecastSetYearOffset < 36) forecast.PY01 = previousForecast.ForcastQuantityCollection[0 + forecastSetYearOffset]; break;
                            case "PY02": if (1 + forecastSetYearOffset < 36) forecast.PY02 = previousForecast.ForcastQuantityCollection[1 + forecastSetYearOffset]; break;
                            case "PY03": if (2 + forecastSetYearOffset < 36) forecast.PY03 = previousForecast.ForcastQuantityCollection[2 + forecastSetYearOffset]; break;
                            case "PY04": if (3 + forecastSetYearOffset < 36) forecast.PY04 = previousForecast.ForcastQuantityCollection[3 + forecastSetYearOffset]; break;
                            case "PY05": if (4 + forecastSetYearOffset < 36) forecast.PY05 = previousForecast.ForcastQuantityCollection[4 + forecastSetYearOffset]; break;
                            case "PY06": if (5 + forecastSetYearOffset < 36) forecast.PY06 = previousForecast.ForcastQuantityCollection[5 + forecastSetYearOffset]; break;
                            case "PY07": if (6 + forecastSetYearOffset < 36) forecast.PY07 = previousForecast.ForcastQuantityCollection[6 + forecastSetYearOffset]; break;
                            case "PY08": if (7 + forecastSetYearOffset < 36) forecast.PY08 = previousForecast.ForcastQuantityCollection[7 + forecastSetYearOffset]; break;
                            case "PY09": if (8 + forecastSetYearOffset < 36) forecast.PY09 = previousForecast.ForcastQuantityCollection[8 + forecastSetYearOffset]; break;
                            case "PY10": if (9 + forecastSetYearOffset < 36) forecast.PY10 = previousForecast.ForcastQuantityCollection[9 + forecastSetYearOffset]; break;
                            case "PY11": if (10 + forecastSetYearOffset < 36) forecast.PY11 = previousForecast.ForcastQuantityCollection[10 + forecastSetYearOffset]; break;
                            case "PY12": if (11 + forecastSetYearOffset < 36) forecast.PY12 = previousForecast.ForcastQuantityCollection[11 + forecastSetYearOffset]; break;
                            case "CY01": if (12 + forecastSetYearOffset < 36) forecast.CY01 = previousForecast.ForcastQuantityCollection[12 + forecastSetYearOffset]; break;
                            case "CY02": if (13 + forecastSetYearOffset < 36) forecast.CY02 = previousForecast.ForcastQuantityCollection[13 + forecastSetYearOffset]; break;
                            case "CY03": if (14 + forecastSetYearOffset < 36) forecast.CY03 = previousForecast.ForcastQuantityCollection[14 + forecastSetYearOffset]; break;
                            case "CY04": if (15 + forecastSetYearOffset < 36) forecast.CY04 = previousForecast.ForcastQuantityCollection[15 + forecastSetYearOffset]; break;
                            case "CY05": if (16 + forecastSetYearOffset < 36) forecast.CY05 = previousForecast.ForcastQuantityCollection[16 + forecastSetYearOffset]; break;
                            case "CY06": if (17 + forecastSetYearOffset < 36) forecast.CY06 = previousForecast.ForcastQuantityCollection[17 + forecastSetYearOffset]; break;
                            case "CY07": if (18 + forecastSetYearOffset < 36) forecast.CY07 = previousForecast.ForcastQuantityCollection[18 + forecastSetYearOffset]; break;
                            case "CY08": if (19 + forecastSetYearOffset < 36) forecast.CY08 = previousForecast.ForcastQuantityCollection[19 + forecastSetYearOffset]; break;
                            case "CY09": if (20 + forecastSetYearOffset < 36) forecast.CY09 = previousForecast.ForcastQuantityCollection[20 + forecastSetYearOffset]; break;
                            case "CY10": if (21 + forecastSetYearOffset < 36) forecast.CY10 = previousForecast.ForcastQuantityCollection[21 + forecastSetYearOffset]; break;
                            case "CY11": if (22 + forecastSetYearOffset < 36) forecast.CY11 = previousForecast.ForcastQuantityCollection[22 + forecastSetYearOffset]; break;
                            case "CY12": if (23 + forecastSetYearOffset < 36) forecast.CY12 = previousForecast.ForcastQuantityCollection[23 + forecastSetYearOffset]; break;
                            case "NY01": if (24 + forecastSetYearOffset < 36) forecast.NY01 = previousForecast.ForcastQuantityCollection[24 + forecastSetYearOffset]; break;
                            case "NY02": if (25 + forecastSetYearOffset < 36) forecast.NY02 = previousForecast.ForcastQuantityCollection[25 + forecastSetYearOffset]; break;
                            case "NY03": if (26 + forecastSetYearOffset < 36) forecast.NY03 = previousForecast.ForcastQuantityCollection[26 + forecastSetYearOffset]; break;
                            case "NY04": if (27 + forecastSetYearOffset < 36) forecast.NY04 = previousForecast.ForcastQuantityCollection[27 + forecastSetYearOffset]; break;
                            case "NY05": if (28 + forecastSetYearOffset < 36) forecast.NY05 = previousForecast.ForcastQuantityCollection[28 + forecastSetYearOffset]; break;
                            case "NY06": if (29 + forecastSetYearOffset < 36) forecast.NY06 = previousForecast.ForcastQuantityCollection[29 + forecastSetYearOffset]; break;
                            case "NY07": if (30 + forecastSetYearOffset < 36) forecast.NY07 = previousForecast.ForcastQuantityCollection[30 + forecastSetYearOffset]; break;
                            case "NY08": if (31 + forecastSetYearOffset < 36) forecast.NY08 = previousForecast.ForcastQuantityCollection[31 + forecastSetYearOffset]; break;
                            case "NY09": if (32 + forecastSetYearOffset < 36) forecast.NY09 = previousForecast.ForcastQuantityCollection[32 + forecastSetYearOffset]; break;
                            case "NY10": if (33 + forecastSetYearOffset < 36) forecast.NY10 = previousForecast.ForcastQuantityCollection[33 + forecastSetYearOffset]; break;
                            case "NY11": if (34 + forecastSetYearOffset < 36) forecast.NY11 = previousForecast.ForcastQuantityCollection[34 + forecastSetYearOffset]; break;
                            case "NY12": if (35 + forecastSetYearOffset < 36) forecast.NY12 = previousForecast.ForcastQuantityCollection[35 + forecastSetYearOffset]; break;
                        }
#endif
                }
            }
            // copy past forecast that does not exists in the current forecast set and has values
            var startMonthOffset = calendar.Get3YearCollectionOffset(calendar.GetPWCForecastMonth(_posSalesEndDate.Value.AddMonths(_forecastFutureFrozenMonths.Value)));
            foreach (var previousForecast in _forecastPreviousCollection)
            {
                var forecastKey = new ForecastKey(previousForecast.CompanyCode, previousForecast.CustomerNumber, _posSalesEndDate, previousForecast.ItemNumber, previousForecast.ForecastMethod);
                if (_forecastCollection.ContainsKey(forecastKey))
                    continue;
                forecastKey.ForecastMethod = forecastKey.ForecastMethod == "SR" ? "RA" : (forecastKey.ForecastMethod == "RA" ? "SR" : forecastKey.ForecastMethod);
                if (_forecastCollection.ContainsKey(forecastKey))
                    continue;

                // restore the original previous forecast method
                forecastKey.ForecastMethod = previousForecast.ForecastMethod;

                var forecast = _forecastCollection.Create(forecastKey);
                forecast.CreatedDate = DateTime.Today;
                var forecastSetYearOffset = (forecast.CreatedDate.Value.Year - previousForecast.CreatedDate.Value.Year) * 12;

                var hasValues = false;
                for (var month = calendar.Get3YearCollectionOffset("PY01"); month <= startMonthOffset; month++)
                    if (previousForecast.ForecastQuantityCollection[month + forecastSetYearOffset] != 0)
                    {
                        hasValues = true;
                        forecast.ForecastQuantityCollection[month] = previousForecast.ForecastQuantityCollection[month + forecastSetYearOffset];
                    }
                if (hasValues)
                    _forecastCollection.Add(forecast);
            }
            _forecastCollection.Sort("ItemNumber", SortDirection.Ascending);
        }

        private bool IsPipeLine(ForecastParameter param)
        {
            //    pipeline start falls within POS/ActualSales last date and POS/ActualSales last date + 3 years
        	// or pipeline end   falls within POS/ActualSales last date and POS/ActualSales last date + 3 years
            // the assumption is POS/ActualSales last date is within PY01 - NY12
            var calendar = Calendar.GetInstance();
            return param != null && ((calendar.GetYYMM(_posSalesEndDate.Value).CompareTo(calendar.GetYYMM(param.PipelineStart.ToString())) <= 0 &&
                String.CompareOrdinal(calendar.GetYYMM(_posSalesEndDate.Value.AddYears(3)), calendar.GetYYMM(param.PipelineStart.ToString())) > 0) ||
                (String.CompareOrdinal(calendar.GetYYMM(_posSalesEndDate.Value), calendar.GetYYMM(param.PipelineEnd.ToString())) <= 0 &&
                String.CompareOrdinal(calendar.GetYYMM(_posSalesEndDate.Value.AddYears(3)), calendar.GetYYMM(param.PipelineEnd.ToString())) > 0));
        }

        private SqlDateTime GetItemLastDate(SqlString companyCode, SqlString customerNumber, SqlString itemNumber)
        {
            // the default discontinued is by customer
            var itemLastDate = SqlDateTime.Null;
            var bonusAndDiscontinuedByCustomer = BonusAndDiscontinuedCollection[new BonusAndDiscontinuedByCustomerKey(companyCode, customerNumber, itemNumber)];
            if (bonusAndDiscontinuedByCustomer != null && !bonusAndDiscontinuedByCustomer.DiscontinuedEffectiveDate.IsNull)
                itemLastDate = bonusAndDiscontinuedByCustomer.DiscontinuedEffectiveDate.Value.AddDays(-1);
            // if company discontinued exists and earlier than customer discontinued then use company discontinued.
            var bonusAndDiscontinuedByCompany = ((Company)Parent).BonusAndDiscontinuedCollection[new BonusAndDiscontinuedByCompanyKey(companyCode, itemNumber)];
            if (bonusAndDiscontinuedByCompany != null && !bonusAndDiscontinuedByCompany.DiscontinuedEffectiveDate.IsNull &&
                bonusAndDiscontinuedByCompany.DiscontinuedEffectiveDate < (itemLastDate.IsNull ? SqlDateTime.MaxValue : itemLastDate))
                itemLastDate = bonusAndDiscontinuedByCompany.DiscontinuedEffectiveDate.Value.AddDays(-1);
            return itemLastDate;
        }

        private SqlInt32 CalculateForecastRA(DateTime forecastMonth, SqlString itemNumber)
        {
            var totalQty = SqlInt32.Zero;
            for (var i = _rollingAvageNumberOfMonths.Value; i > 0; i--)
                totalQty += GetForecastRAorActualSales(forecastMonth.AddMonths(-i), itemNumber);
            return SqlDecimal.Round(totalQty.ToSqlDecimal() / _rollingAvageNumberOfMonths, 0).ToSqlInt32();
        }

        private SqlInt32 GetForecastRAorActualSales(DateTime rollingMonth, SqlString itemNumber)
        {
            var returnQty = SqlInt32.Zero;
            if (rollingMonth >= new DateTime(_posSalesEndDate.Value.Year, _posSalesEndDate.Value.Month, 1).AddMonths(_forecastFutureFrozenMonths.Value + 1)) // get "RA" forecast just created or past forecast
            {
                var PWCRollingMonth = Calendar.GetInstance().GetPWCForecastMonth(rollingMonth);
                var forecast = _forecastCollection[new ForecastKey(_companyCode, _customerNumber, _posSalesEndDate, itemNumber, "RA")];
                var calendar = Calendar.GetInstance();
                var forecastQtyCollectionOffset = calendar.Get3YearCollectionOffset(PWCRollingMonth);

                if (forecast != null && !forecast.ForecastQuantityCollection[forecastQtyCollectionOffset].IsNull)
                    returnQty = forecast.ForecastQuantityCollection[forecastQtyCollectionOffset];
                else if (ForecastPreviousCollection.Count > 0)
                {
                    var previousPosWeekEndDateEnd = _forecastPreviousCollection[0].POSSalesEndDate;
                    var previousForecastKey = new ForecastKey(_companyCode, _customerNumber, previousPosWeekEndDateEnd, itemNumber, "RA");
                    var previousForecast = _forecastPreviousCollection[previousForecastKey];
                    if (previousForecast != null && !previousForecast.ForecastQuantityCollection[forecastQtyCollectionOffset].IsNull)
                        returnQty = previousForecast.ForecastQuantityCollection[forecastQtyCollectionOffset];
                }
            }
            else // get actual sales
            {
                var actualSales = ActualSalesCollection[new ActualSalesKey(_companyCode, _customerNumber, itemNumber, rollingMonth)];
                if (actualSales != null && actualSales.Quantity > SqlInt32.Zero)
                    returnQty = actualSales.Quantity;
            }
            return returnQty;
        }

        private static SqlInt32 GetBonusForecastQty(IThreeYearMonthlyIntegerValue bonusItem, string pwcForecastMonth, SqlInt32 forecastQty)
        {
            var calendar = Calendar.GetInstance();
            var bonusNumOfDays = bonusItem.BonusNumOfDaysCollection[calendar.Get3YearCollectionOffset(pwcForecastMonth)];
            return bonusNumOfDays.IsNull ? SqlInt32.Null :
                (SqlInt32)(forecastQty.ToSqlDecimal() * bonusNumOfDays / calendar.GetDaysInMonth(pwcForecastMonth));
        }

        private SqlDecimal GetTrendFactor(SqlString itemNumber, SqlString forecastMethod, int month)
        {
            IForecastTrendValue trend = ((ForecastTrendByItemCollection[new ForecastTrendByCustomerItemKey(CompanyCode, CustomerNumber, itemNumber, forecastMethod)] ??
                                          (IForecastTrendValue)ForecastTrendByCustomerProductGroupItemCollection[new ForecastTrendProductGroupItemKey(itemNumber, forecastMethod)]) ??
                                         ((Company)Parent).ForecastTrendByItemCollection[new ForecastTrendByCompanyItemKey(CompanyCode, itemNumber, forecastMethod)]) ??
                                          ForecastTrendByCompanyProductGroupItemCollection[new ForecastTrendProductGroupItemKey(itemNumber, forecastMethod)];
            if (trend == null)
                return SqlDecimal.Null;

            switch (month % 12 == 0 ? 12 : month % 12)
            {
                case 1: return trend.FactorMonth01;
                case 2: return trend.FactorMonth02;
                case 3: return trend.FactorMonth03;
                case 4: return trend.FactorMonth04;
                case 5: return trend.FactorMonth05;
                case 6: return trend.FactorMonth06;
                case 7: return trend.FactorMonth07;
                case 8: return trend.FactorMonth08;
                case 9: return trend.FactorMonth09;
                case 10: return trend.FactorMonth10;
                case 11: return trend.FactorMonth11;
                case 12: return trend.FactorMonth12;
                default: return SqlDecimal.Null;
            }
        }

        public void UpdateSalesRateOverride(ForecastSalesRate salesRate, bool isOverride, bool isNewSalesRate)
        {
            var commentAndOverrideKey = new ForecastSalesRateCommentAndOverrideKey((ForecastSalesRateKey)salesRate.ObjectKey, DateTime.Now);
            var commentAndOverride = salesRate.ForecastSalesRateCommentAndOverrideCollection.Create(commentAndOverrideKey);
            commentAndOverride.IsOverride = isOverride;
            if (ForecastSalesRateAction == ForecastSalesRateAction.Get && !isNewSalesRate)
                salesRate.ForecastSalesRateCommentAndOverrideCollection.Save(commentAndOverride);
            else
                salesRate.ForecastSalesRateCommentAndOverrideCollection.Add(commentAndOverride);
            salesRate.HasOverride = true;
        }

        public void UpdateForecastOverride(Forecast forecast, string columnName, bool isOverride, bool isNewForecast)
        {
            var commentAndOverrideKey = new ForecastCommentAndOverrideKey((ForecastKey)forecast.ObjectKey, columnName, DateTime.Now);
            var commentAndOverride = forecast.ForecastCommentAndOverrideCollection.Create(commentAndOverrideKey);
            commentAndOverride.IsOverride = isOverride;
            if (ForecastAction == ForecastAction.Get && !isNewForecast)
                forecast.ForecastCommentAndOverrideCollection.Save(commentAndOverride);
            else
                forecast.ForecastCommentAndOverrideCollection.Add(commentAndOverride);
            forecast.HasOverride = true;
        }

        [Serializable]
        public class WithCompanyParentCollection : APersistenceObjectWithParentCollection<CustomerKey, Customer>
        {
            public WithCompanyParentCollection() { }

            public WithCompanyParentCollection(Company parent)
            {
                Parent = parent;
            }

            #region Comparer Classes
            protected class comparer_CustomerNumber : IComparer<Customer>
            {
                public int Compare(Customer x, Customer y)
                {
                    return x.CustomerNumber.CompareTo(y.CustomerNumber);
                }
            }

            protected class comparer_CustomerName : IComparer<Customer>
            {
                public int Compare(Customer x, Customer y)
                {
                    return x.CustomerName.CompareTo(y.CustomerName);
                }
            }
            #endregion
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<CustomerKey, Customer>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(SqlString companyCode, SqlString customerNumber)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"CompanyCode", companyCode},
                                               {"CustomerNumber", customerNumber}
                                           };
            }
        }
    }

#if false
    [Serializable]
    public class CustomerKeyWs : AObjectKey
    {
        public string CompanyCode;
        public string CustomerNumber;

        public CustomerKeyWs() { }

        public CustomerKeyWs(string companyCode, string customerNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
        }

        public override string ToString()
        {
            return new StringBuilder(CompanyCode).Append("|").Append(CustomerNumber).ToString();
        }
    }
    
    /// <summary>
    /// Summary description for Customer.
    /// </summary>
    [Serializable]
    public class CustomerWs : APersistenceObject
    {
        private string _companyCode;
        private string _customerNumber;
        private string _customerName;
        private bool? _distinctForecastNameFlag;
        private string _forecastMethod;
        private decimal? _inflateFactor;
        private short? _forecastFutureFrozenMonths;
        private int _status;

        public CustomerWs() { }

        public CustomerWs(string companyCode, string customerNumber)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(CustomerKeyWs); }
        }

        [NotMapped]
        public string CompanyCodeKey
        {
            get { return ((CustomerKeyWs)ObjectKey).CompanyCode; }
        }

        [NotMapped]
        public string CustomerNumberKey
        {
            get { return ((CustomerKeyWs)ObjectKey).CustomerNumber; }
        }

        [NotMapped]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        #region Mapped Members
        public string CompanyCode
        {
            get { return _companyCode; }
            set
            {
                if (_companyCode != value)
                {
                    _companyCode = value;
                    FieldDataChange("CompanyCode", value);
                }
            }
        }

        public string CustomerNumber
        {
            get { return _customerNumber; }
            set
            {
                if (_customerNumber != value)
                {
                    _customerNumber = value;
                    FieldDataChange("CustomerNumber", value);
                }
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    FieldDataChange("CustomerName", value);
                }
            }
        }

        public bool? DistinctForecastNameFlag
        {
            get { return _distinctForecastNameFlag; }
            set
            {
                if (_distinctForecastNameFlag != value)
                {
                    _distinctForecastNameFlag = value;
                    FieldDataChange("DistinctForecastNameFlag", value);
                }
            }
        }

        public string ForecastMethod
        {
            get { return _forecastMethod; }
            set
            {
                if (_forecastMethod != value)
                {
                    _forecastMethod = value;
                    FieldDataChange("ForecastMethod", value);
                }
            }
        }

        public decimal? InflateFactor
        {
            get { return _inflateFactor; }
            set
            {
                if (_inflateFactor != value)
                {
                    _inflateFactor = value;
                    FieldDataChange("InflateFactor", value);
                }
            }
        }

        public short? ForecastFutureFrozenMonths
        {
            get { return _forecastFutureFrozenMonths; }
            set
            {
                if (_forecastFutureFrozenMonths != value)
                {
                    _forecastFutureFrozenMonths = value;
                    FieldDataChange("ForecastFutureFrozenMonths", value);
                }
            }
        }
        #endregion

        public override bool Validate()
        {
            return (ObjectKey != null && _customerName != null && _forecastMethod != null && _forecastFutureFrozenMonths != null);
        }

        [Serializable]
        public class WithCompanyParentCollection : APersistenceObjectWithParentCollection<CustomerKeyWs, CustomerWs>
        {
            public WithCompanyParentCollection() { }

            public WithCompanyParentCollection(Company parent)
            {
                Parent = parent;
            }

            #region Comparer Classes
            protected class comparer_CustomerNumber : IComparer<Customer>
            {
                public int Compare(Customer x, Customer y)
                {
                    return x.CustomerNumber.CompareTo(y.CustomerNumber);
                }
            }

            protected class comparer_CustomerName : IComparer<Customer>
            {
                public int Compare(Customer x, Customer y)
                {
                    return x.CustomerName.CompareTo(y.CustomerName);
                }
            }
            #endregion
        }
    }
#endif
}
