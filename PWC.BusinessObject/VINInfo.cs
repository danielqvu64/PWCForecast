using System;
using System.Collections.Specialized;
using DVu.Library.PersistenceInterface;
using DVu.Library.BusinessObject;
using PWC.PersistenceInterface;

namespace PWC.BusinessObject
{
    public class VINInfoKey : AObjectKey
    {
        public string VIN;

        public VINInfoKey() { }

        public VINInfoKey(string VIN)
        {
            this.VIN = VIN;
        }

        public override string ToString()
        {
            return VIN;
        }
    }

    /// <summary>
    /// Summary description for VINInfo.
    /// </summary>
    [Serializable]
    public class VINInfo : APersistenceObject
    {
        private string _dealer;
        private string _ETAEndDate;
        private string _ETARevisedYesNo;
        private string _ETAStartDate;
        private string _extColor;
        private string _intColor;
        private string _lastUpdateDate;
        private string _locationCity;
        private string _locationState;
        private string _model;
        private string _modelDescription;
        private string _shipDate;
        private string _status;
        private string _VIN;

        public VINInfo() { }

        public VINInfo(string VIN)
        {
            this.VIN = VIN;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(VINInfoKey); }
        }

        #region Mapped Members
        public string Dealer
        {
            get { return _dealer; }
            set
            {
                if (_dealer != value)
                {
                    _dealer = value;
                    FieldDataChange("Dealer", value);
                }
            }
        }

        public string ETAEndDate
        {
            get { return _ETAEndDate; }
            set
            {
                if (_ETAEndDate != value)
                {
                    _ETAEndDate = value;
                    FieldDataChange("ETAEndDate", value);
                }
            }
        }

        public string ETARevisedYesNo
        {
            get { return _ETARevisedYesNo; }
            set
            {
                if (_ETARevisedYesNo != value)
                {
                    _ETARevisedYesNo = value;
                    FieldDataChange("ETARevisedYesNo", value);
                }
            }
        }

        public string ETAStartDate
        {
            get { return _ETAStartDate; }
            set
            {
                if (_ETAStartDate != value)
                {
                    _ETAStartDate = value;
                    FieldDataChange("ETAStartDate", value);
                }
            }
        }

        public string ExtColor
        {
            get { return _extColor; }
            set
            {
                if (_extColor != value)
                {
                    _extColor = value;
                    FieldDataChange("ExtColor", value);
                }
            }
        }

        public string IntColor
        {
            get { return _intColor; }
            set
            {
                if (_intColor != value)
                {
                    _intColor = value;
                    FieldDataChange("IntColor", value);
                }
            }
        }

        public string LastUpdateDate
        {
            get { return _lastUpdateDate; }
            set
            {
                if (_lastUpdateDate != value)
                {
                    _lastUpdateDate = value;
                    FieldDataChange("LastUpdateDate", value);
                }
            }
        }

        public string LocationCity
        {
            get { return _locationCity; }
            set
            {
                if (_locationCity != value)
                {
                    _locationCity = value;
                    FieldDataChange("LocationCity", value);
                }
            }
        }

        public string LocationState
        {
            get { return _locationState; }
            set
            {
                if (_locationState != value)
                {
                    _locationState = value;
                    FieldDataChange("LocationState", value);
                }
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    FieldDataChange("Model", value);
                }
            }
        }

        public string ModelDescription
        {
            get { return _modelDescription; }
            set
            {
                if (_modelDescription != value)
                {
                    _modelDescription = value;
                    FieldDataChange("ModelDescription", value);
                }
            }
        }

        public string ShipDate
        {
            get { return _shipDate; }
            set
            {
                if (_shipDate != value)
                {
                    _shipDate = value;
                    FieldDataChange("ShipDate", value);
                }
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    FieldDataChange("Status", value);
                }
            }
        }

        public string VIN
        {
            get { return _VIN; }
            set
            {
                if (_VIN != value)
                {
                    _VIN = value;
                    FieldDataChange("VIN", value);
                }
            }
        }
        #endregion

        public override bool Validate()
        {
            return (ObjectKey != null);
        }

        [Serializable]
        public class ParameteredCollection : APersistenceObjectCollection<VINInfoKey, VINInfo>
        {
            public ParameteredCollection() { }

            public ParameteredCollection(HondaMessageHeaderType hondaMessageHeader, IncomingParameters incomingParameters)
            {
                ParameterCollection = new HybridDictionary
                                           {
                                               {"HondaMessageHeader", hondaMessageHeader},
                                               {"IncomingParameters", incomingParameters}
                                           };
            }
        }
    }
}
