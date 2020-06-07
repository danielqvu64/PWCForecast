using System.Data.SqlTypes;

namespace PWC.PersistenceInterface
{
    public interface IThreeYearMonthlyIntegerValue
    {
        SqlInt32[] BonusNumOfDaysCollection { get; }
        SqlInt32 PY01 { get; set; }
        SqlInt32 PY02 { get; set; }
        SqlInt32 PY03 { get; set; }
        SqlInt32 PY04 { get; set; }
        SqlInt32 PY05 { get; set; }
        SqlInt32 PY06 { get; set; }
        SqlInt32 PY07 { get; set; }
        SqlInt32 PY08 { get; set; }
        SqlInt32 PY09 { get; set; }
        SqlInt32 PY10 { get; set; }
        SqlInt32 PY11 { get; set; }
        SqlInt32 PY12 { get; set; }
        SqlInt32 CY01 { get; set; }
        SqlInt32 CY02 { get; set; }
        SqlInt32 CY03 { get; set; }
        SqlInt32 CY04 { get; set; }
        SqlInt32 CY05 { get; set; }
        SqlInt32 CY06 { get; set; }
        SqlInt32 CY07 { get; set; }
        SqlInt32 CY08 { get; set; }
        SqlInt32 CY09 { get; set; }
        SqlInt32 CY10 { get; set; }
        SqlInt32 CY11 { get; set; }
        SqlInt32 CY12 { get; set; }
        SqlInt32 NY01 { get; set; }
        SqlInt32 NY02 { get; set; }
        SqlInt32 NY03 { get; set; }
        SqlInt32 NY04 { get; set; }
        SqlInt32 NY05 { get; set; }
        SqlInt32 NY06 { get; set; }
        SqlInt32 NY07 { get; set; }
        SqlInt32 NY08 { get; set; }
        SqlInt32 NY09 { get; set; }
        SqlInt32 NY10 { get; set; }
        SqlInt32 NY11 { get; set; }
        SqlInt32 NY12 { get; set; }
    }

    public interface IForecastTrendValue
    {
        SqlDecimal FactorMonth01 { get; set; }
        SqlDecimal FactorMonth02 { get; set; }
        SqlDecimal FactorMonth03 { get; set; }
        SqlDecimal FactorMonth04 { get; set; }
        SqlDecimal FactorMonth05 { get; set; }
        SqlDecimal FactorMonth06 { get; set; }
        SqlDecimal FactorMonth07 { get; set; }
        SqlDecimal FactorMonth08 { get; set; }
        SqlDecimal FactorMonth09 { get; set; }
        SqlDecimal FactorMonth10 { get; set; }
        SqlDecimal FactorMonth11 { get; set; }
        SqlDecimal FactorMonth12 { get; set; }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "HondaMessageHeaderType", Namespace = "http://www.honda.com/header")]
    [System.SerializableAttribute()]
    public partial class HondaMessageHeaderType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BusinessIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CollectedTimestampField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SiteIDField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BusinessID
        {
            get
            {
                return this.BusinessIDField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BusinessIDField, value) != true))
                {
                    this.BusinessIDField = value;
                    this.RaisePropertyChanged("BusinessID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CollectedTimestamp
        {
            get
            {
                return this.CollectedTimestampField;
            }
            set
            {
                if ((this.CollectedTimestampField.Equals(value) != true))
                {
                    this.CollectedTimestampField = value;
                    this.RaisePropertyChanged("CollectedTimestamp");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageID
        {
            get
            {
                return this.MessageIDField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MessageIDField, value) != true))
                {
                    this.MessageIDField = value;
                    this.RaisePropertyChanged("MessageID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SiteID
        {
            get
            {
                return this.SiteIDField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SiteIDField, value) != true))
                {
                    this.SiteIDField = value;
                    this.RaisePropertyChanged("SiteID");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "IncomingParameters", Namespace = "http://www.honda.com/VTRServiceParameters")]
    [System.SerializableAttribute()]
    public partial class IncomingParameters : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DealerDivisionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DealerNoField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SearchVINField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SortCriteriaField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SortOrderField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DealerDivision
        {
            get
            {
                return this.DealerDivisionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DealerDivisionField, value) != true))
                {
                    this.DealerDivisionField = value;
                    this.RaisePropertyChanged("DealerDivision");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DealerNo
        {
            get
            {
                return this.DealerNoField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DealerNoField, value) != true))
                {
                    this.DealerNoField = value;
                    this.RaisePropertyChanged("DealerNo");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SearchVIN
        {
            get
            {
                return this.SearchVINField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SearchVINField, value) != true))
                {
                    this.SearchVINField = value;
                    this.RaisePropertyChanged("SearchVIN");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SortCriteria
        {
            get
            {
                return this.SortCriteriaField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SortCriteriaField, value) != true))
                {
                    this.SortCriteriaField = value;
                    this.RaisePropertyChanged("SortCriteria");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SortOrder
        {
            get
            {
                return this.SortOrderField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SortOrderField, value) != true))
                {
                    this.SortOrderField = value;
                    this.RaisePropertyChanged("SortOrder");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "HondaMessageFaultType", Namespace = "http://www.honda.com/hondaFault")]
    [System.SerializableAttribute()]
    public partial class HondaMessageFaultType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FaultCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FaultDescriptionField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultCode
        {
            get
            {
                return this.FaultCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FaultCodeField, value) != true))
                {
                    this.FaultCodeField = value;
                    this.RaisePropertyChanged("FaultCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultDescription
        {
            get
            {
                return this.FaultDescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FaultDescriptionField, value) != true))
                {
                    this.FaultDescriptionField = value;
                    this.RaisePropertyChanged("FaultDescription");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

#if false
    [FieldMapInterfaceAttribute]
    public interface ICompany
    {
        SqlString CompanyCode { get; set; }
        SqlString CompanyName { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface ICompanyCollection
    {
        ICompany[] CompanyCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface ICustomer
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        // Test Nullable value types
        //string CustomerNumberTest { get; set; }
        //bool? DistinctForecastNameFlagTest { get; set; }
        //decimal? InflateFactorTest { get; set; }
        //short? ForecastFutureFrozenMonthsTest { get; set; }
        SqlString CustomerName { get; set; }
        SqlBoolean DistinctForecastNameFlag { get; set; }
        SqlString ForecastMethod { get; set; }
        SqlDecimal InflateFactor { get; set; }
        SqlInt16 ForecastFutureFrozenMonths { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface ICustomerCollection
    {
        ICustomer[] CustomerCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IItem
    {
        SqlString ItemNumber { get; set; }
        SqlString ItemDescription { get; set; }
        SqlString ProductGroupCode { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IItemCollection
    {
        IItem[] ItemCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IBrand
    {
        SqlString BrandCode { get; set; }
        SqlString BrandDescription { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IBrandCollection
    {
        IBrand[] BrandCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductPrefix
    {
        SqlString ProductPrefixCode { get; set; }
        SqlString ProductPrefixDescription { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductPrefixCollection
    {
        IProductPrefix[] ProductPrefixCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductCategory
    {
        SqlString ProductCategoryCode { get; set; }
        SqlString ProductCategoryDescription { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductCategoryCollection
    {
        IProductCategory[] ProductCategoryCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductGroup
    {
        SqlString ProductGroupCode { get; set; }
        SqlString ProductGroupDescription { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductGroupCollection
    {
        IProductGroup[] ProductGroupCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductGroupItem
    {
        SqlString ProductGroupCode { get; set; }
        SqlString ItemNumber { get; set; }
        SqlString ItemDescription { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IProductGroupItemCollection
    {
        IProductGroupItem[] ProductGroupItemCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastSalesRate
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlDateTime POSSalesEndDate { get; set; }
        SqlString ItemNumber { get; set; }
        SqlInt16 POSNumberOfWeeks { get; set; }
        SqlDecimal TrendFactor { get; set; }
        SqlInt32 POSWeek1Quantity { get; set; }
        SqlInt32 POSWeek2Quantity { get; set; }
        SqlInt32 POSWeek3Quantity { get; set; }
        SqlInt32 POSWeek4Quantity { get; set; }
        SqlInt32 StoreCountExisting { get; set; }
        SqlInt32 StoreCountNew { get; set; }
        SqlDecimal SalesRate { get; set; }
        SqlDecimal SalesRatePrevious { get; set; }
        SqlBoolean ManualFlag { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastSalesRateCollection
    {
        IForecastSalesRate[] ForecastSalesRateCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastParameter
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlString ItemNumber { get; set; }
        SqlInt32 StoreCountExisting { get; set; }
        SqlInt32 StoreCountNew { get; set; }
        SqlDecimal InitialQtyPerNewStore { get; set; }
        SqlString PipelineStart { get; set; }
        SqlString PipelineEnd { get; set; }
        SqlDecimal ProjectedSalesRateExisting { get; set; }
        SqlDecimal ProjectedSalesRateNew { get; set; }
        SqlBoolean OneTimeItemFlag { get; set; }
        SqlDecimal PlPctPY01 { get; set; }
        SqlDecimal PlPctPY02 { get; set; }
        SqlDecimal PlPctPY03 { get; set; }
        SqlDecimal PlPctPY04 { get; set; }
        SqlDecimal PlPctPY05 { get; set; }
        SqlDecimal PlPctPY06 { get; set; }
        SqlDecimal PlPctPY07 { get; set; }
        SqlDecimal PlPctPY08 { get; set; }
        SqlDecimal PlPctPY09 { get; set; }
        SqlDecimal PlPctPY10 { get; set; }
        SqlDecimal PlPctPY11 { get; set; }
        SqlDecimal PlPctPY12 { get; set; }
        SqlDecimal PlPctCY01 { get; set; }
        SqlDecimal PlPctCY02 { get; set; }
        SqlDecimal PlPctCY03 { get; set; }
        SqlDecimal PlPctCY04 { get; set; }
        SqlDecimal PlPctCY05 { get; set; }
        SqlDecimal PlPctCY06 { get; set; }
        SqlDecimal PlPctCY07 { get; set; }
        SqlDecimal PlPctCY08 { get; set; }
        SqlDecimal PlPctCY09 { get; set; }
        SqlDecimal PlPctCY10 { get; set; }
        SqlDecimal PlPctCY11 { get; set; }
        SqlDecimal PlPctCY12 { get; set; }
        SqlDecimal PlPctNY01 { get; set; }
        SqlDecimal PlPctNY02 { get; set; }
        SqlDecimal PlPctNY03 { get; set; }
        SqlDecimal PlPctNY04 { get; set; }
        SqlDecimal PlPctNY05 { get; set; }
        SqlDecimal PlPctNY06 { get; set; }
        SqlDecimal PlPctNY07 { get; set; }
        SqlDecimal PlPctNY08 { get; set; }
        SqlDecimal PlPctNY09 { get; set; }
        SqlDecimal PlPctNY10 { get; set; }
        SqlDecimal PlPctNY11 { get; set; }
        SqlDecimal PlPctNY12 { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastParameterCollection
    {
        IForecastParameter[] ForecastParameterCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendValue
    {
        SqlDecimal FactorMonth01 { get; set; }
        SqlDecimal FactorMonth02 { get; set; }
        SqlDecimal FactorMonth03 { get; set; }
        SqlDecimal FactorMonth04 { get; set; }
        SqlDecimal FactorMonth05 { get; set; }
        SqlDecimal FactorMonth06 { get; set; }
        SqlDecimal FactorMonth07 { get; set; }
        SqlDecimal FactorMonth08 { get; set; }
        SqlDecimal FactorMonth09 { get; set; }
        SqlDecimal FactorMonth10 { get; set; }
        SqlDecimal FactorMonth11 { get; set; }
        SqlDecimal FactorMonth12 { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCompanyItem : IForecastTrendValue
    {
        SqlString CompanyCode { get; set; }
        SqlString ItemNumber { get; set; }
        SqlString ForecastMethod { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCompanyItemCollection
    {
        IForecastTrendByCompanyItem[] ForecastTrendByCompanyItemCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCompanyProductGroup : IForecastTrendValue
    {
        SqlString CompanyCode { get; set; }
        SqlString ProductGroupCode { get; set; }
        SqlString ForecastMethod { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCompanyProductGroupCollection
    {
        IForecastTrendByCompanyProductGroup[] ForecastTrendByCompanyProductGroupCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendProductGroupItem : IForecastTrendValue
    {
        SqlString ItemNumber { get; set; }
        SqlString ForecastMethod { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendProductGroupItemCollection
    {
        IForecastTrendProductGroupItem[] ForecastTrendProductGroupItemCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCustomerItem : IForecastTrendValue
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlString ItemNumber { get; set; }
        SqlString ForecastMethod { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCustomerItemCollection
    {
        IForecastTrendByCustomerItem[] ForecastTrendByCustomerItemCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCustomerProductGroup : IForecastTrendValue
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlString ProductGroupCode { get; set; }
        SqlString ForecastMethod { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastTrendByCustomerProductGroupCollection
    {
        IForecastTrendByCustomerProductGroup[] ForecastTrendByCustomerProductGroupCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IPos
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlString ItemNumber { get; set; }
        SqlDateTime WeekEndDate { get; set; }
        SqlInt32 Quantity { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IPosCollection
    {
        IPos[] PosCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IActualSales
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlString ItemNumber { get; set; }
        SqlDateTime Month { get; set; }
        SqlInt32 Quantity { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IActualSalesCollection
    {
        IActualSales[] ActualSalesCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IActualSalesReport
    {
        SqlString CompanyCode { get; set; }
        SqlString GroupByCode { get; set; }
        SqlDateTime Month { get; set; }
        SqlInt32 Quantity { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IActualSalesReportCollection
    {
        IActualSalesReport[] ActualSalesReportCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IThreeYearMonthlyIntegerValue
    {
        SqlInt32 PY01 { get; set; }
        SqlInt32 PY02 { get; set; }
        SqlInt32 PY03 { get; set; }
        SqlInt32 PY04 { get; set; }
        SqlInt32 PY05 { get; set; }
        SqlInt32 PY06 { get; set; }
        SqlInt32 PY07 { get; set; }
        SqlInt32 PY08 { get; set; }
        SqlInt32 PY09 { get; set; }
        SqlInt32 PY10 { get; set; }
        SqlInt32 PY11 { get; set; }
        SqlInt32 PY12 { get; set; }
        SqlInt32 CY01 { get; set; }
        SqlInt32 CY02 { get; set; }
        SqlInt32 CY03 { get; set; }
        SqlInt32 CY04 { get; set; }
        SqlInt32 CY05 { get; set; }
        SqlInt32 CY06 { get; set; }
        SqlInt32 CY07 { get; set; }
        SqlInt32 CY08 { get; set; }
        SqlInt32 CY09 { get; set; }
        SqlInt32 CY10 { get; set; }
        SqlInt32 CY11 { get; set; }
        SqlInt32 CY12 { get; set; }
        SqlInt32 NY01 { get; set; }
        SqlInt32 NY02 { get; set; }
        SqlInt32 NY03 { get; set; }
        SqlInt32 NY04 { get; set; }
        SqlInt32 NY05 { get; set; }
        SqlInt32 NY06 { get; set; }
        SqlInt32 NY07 { get; set; }
        SqlInt32 NY08 { get; set; }
        SqlInt32 NY09 { get; set; }
        SqlInt32 NY10 { get; set; }
        SqlInt32 NY11 { get; set; }
        SqlInt32 NY12 { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecast : IThreeYearMonthlyIntegerValue
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlDateTime POSSalesEndDate { get; set; }
        SqlString ItemNumber { get; set; }
        SqlString ForecastMethod { get; set; }
        SqlDateTime CreatedDate { get; set; }
        SqlBoolean ManualFlag { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastCollection
    {
        IForecast[] ForecastCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastReport
    {
        SqlString CompanyCode { get; set; }
        SqlString GroupBy { get; set; }
        SqlString GroupByCode { get; set; }
        SqlInt32 ForecastMonth01Quantity { get; set; }
        SqlInt32 ForecastMonth02Quantity { get; set; }
        SqlInt32 ForecastMonth03Quantity { get; set; }
        SqlInt32 ForecastMonth04Quantity { get; set; }
        SqlInt32 ForecastMonth05Quantity { get; set; }
        SqlInt32 ForecastMonth06Quantity { get; set; }
        SqlInt32 ForecastMonth07Quantity { get; set; }
        SqlInt32 ForecastMonth08Quantity { get; set; }
        SqlInt32 ForecastMonth09Quantity { get; set; }
        SqlInt32 ForecastMonth10Quantity { get; set; }
        SqlInt32 ForecastMonth11Quantity { get; set; }
        SqlInt32 ForecastMonth12Quantity { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IForecastReportCollection
    {
        IForecastReport[] ForecastReportCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IBonusAndDiscontinuedByCompany : IThreeYearMonthlyIntegerValue
    {
        SqlString CompanyCode { get; set; }
        SqlString ItemNumber { get; set; }
        SqlDateTime DiscontinuedEffectiveDate { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IBonusAndDiscontinuedByCompanyCollection
    {
        IBonusAndDiscontinuedByCompany[] BonusAndDiscontinuedByCompanyCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IBonusAndDiscontinuedByCustomer : IThreeYearMonthlyIntegerValue
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlString ItemNumber { get; set; }
        SqlDateTime DiscontinuedEffectiveDate { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IBonusAndDiscontinuedByCustomerCollection
    {
        IBonusAndDiscontinuedByCustomer[] BonusAndDiscontinuedByCustomerCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IPosLatestDateAndGap
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlDateTime LatestWeekEndDate { get; set; }
        SqlInt16 NumOfWeeks { get; set; }
        SqlBoolean GapFlag { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IPosLatestDateAndGapCollection
    {
        IPosLatestDateAndGap[] PosLatestDateAndGapCollection { get; }
    }

    [FieldMapInterfaceAttribute]
    public interface IActualSalesLatestDateAndGap
    {
        SqlString CompanyCode { get; set; }
        SqlString CustomerNumber { get; set; }
        SqlDateTime LatestActualSalesEndDate { get; set; }
        SqlByte RollingAverageNumberOfMonths { get; set; }
        SqlBoolean GapFlag { get; set; }
    }

    [FieldMapInterfaceAttribute]
    public interface IActualSalesLatestDateAndGapCollection
    {
        IActualSalesLatestDateAndGap[] ActualSalesLatestDateAndGapCollection { get; }
    }
#endif
}
