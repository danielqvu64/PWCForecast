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
    public class ForecastKey : CustomerKey
    {
        public SqlDateTime POSSalesEndDate;
        public SqlString ItemNumber;
        public SqlString ForecastMethod;

        public ForecastKey() { }

        public ForecastKey(SqlString companyCode, SqlString customerNumber, SqlDateTime posSalesEndDate, SqlString itemNumber, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posSalesEndDate;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString()).Append("|");
            sb.Append(POSSalesEndDate.IsNull ? POSSalesEndDate.ToString() : POSSalesEndDate.Value.ToString("MM/dd/yyyy"));
            sb.Append("|").Append(ItemNumber.ToString()).Append("|").Append(ForecastMethod.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// Summary description for Forecast.
    /// </summary>
    [Serializable]
    public class Forecast : APersistenceObject, IRowVersion
    {
        private SqlString _companyCode;
        private SqlString _customerNumber;
        private SqlDateTime _posSalesEndDate;
        private SqlString _itemNumber;
        private SqlString _forecastMethod;
        private readonly SqlInt32[] _forecastQuantityCollection = new SqlInt32[36];
        private ForecastCommentAndOverride.WithForecastParentCollection _forecastCommentAndOverrideCollection;
        private SqlDateTime _createdDate;
        private SqlBoolean _hasOverride = SqlBoolean.False;
        private SqlBoolean _hasComment = SqlBoolean.False;

        public Forecast() { }

        public Forecast(SqlString companyCode, SqlString customerNumber, SqlDateTime posSalesEndDate, SqlString itemNumber, SqlString forecastMethod)
        {
            CompanyCode = companyCode;
            CustomerNumber = customerNumber;
            POSSalesEndDate = posSalesEndDate;
            ItemNumber = itemNumber;
            ForecastMethod = forecastMethod;
        }

        [NotMapped]
        public override Type ObjectKeyType
        {
            get { return typeof(ForecastKey); }
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

#if false
        public SqlInt32 PY01
        {
            get { return py01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py01.CompareTo(value) != 0)
                    AttributeChange();
                py01 = value;
            }
        }

        public SqlInt32 PY02
        {
            get { return py02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py02.CompareTo(value) != 0)
                    AttributeChange();
                py02 = value;
            }
        }

        public SqlInt32 PY03
        {
            get { return py03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py03.CompareTo(value) != 0)
                    AttributeChange();
                py03 = value;
            }
        }

        public SqlInt32 PY04
        {
            get { return py04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py04.CompareTo(value) != 0)
                    AttributeChange();
                py04 = value;
            }
        }

        public SqlInt32 PY05
        {
            get { return py05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py05.CompareTo(value) != 0)
                    AttributeChange();
                py05 = value;
            }
        }

        public SqlInt32 PY06
        {
            get { return py06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py06.CompareTo(value) != 0)
                    AttributeChange();
                py06 = value;
            }
        }

        public SqlInt32 PY07
        {
            get { return py07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py07.CompareTo(value) != 0)
                    AttributeChange();
                py07 = value;
            }
        }

        public SqlInt32 PY08
        {
            get { return py08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py08.CompareTo(value) != 0)
                    AttributeChange();
                py08 = value;
            }
        }

        public SqlInt32 PY09
        {
            get { return py09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py09.CompareTo(value) != 0)
                    AttributeChange();
                py09 = value;
            }
        }

        public SqlInt32 PY10
        {
            get { return py10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py10.CompareTo(value) != 0)
                    AttributeChange();
                py10 = value;
            }
        }

        public SqlInt32 PY11
        {
            get { return py11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py11.CompareTo(value) != 0)
                    AttributeChange();
                py11 = value;
            }
        }

        public SqlInt32 PY12
        {
            get { return py12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (py12.CompareTo(value) != 0)
                    AttributeChange();
                py12 = value;
            }
        }

        public SqlInt32 CY01
        {
            get { return cy01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy01.CompareTo(value) != 0)
                    AttributeChange();
                cy01 = value;
            }
        }

        public SqlInt32 CY02
        {
            get { return cy02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy02.CompareTo(value) != 0)
                    AttributeChange();
                cy02 = value;
            }
        }

        public SqlInt32 CY03
        {
            get { return cy03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy03.CompareTo(value) != 0)
                    AttributeChange();
                cy03 = value;
            }
        }

        public SqlInt32 CY04
        {
            get { return cy04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy04.CompareTo(value) != 0)
                    AttributeChange();
                cy04 = value;
            }
        }

        public SqlInt32 CY05
        {
            get { return cy05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy05.CompareTo(value) != 0)
                    AttributeChange();
                cy05 = value;
            }
        }

        public SqlInt32 CY06
        {
            get { return cy06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy06.CompareTo(value) != 0)
                    AttributeChange();
                cy06 = value;
            }
        }

        public SqlInt32 CY07
        {
            get { return cy07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy07.CompareTo(value) != 0)
                    AttributeChange();
                cy07 = value;
            }
        }

        public SqlInt32 CY08
        {
            get { return cy08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy08.CompareTo(value) != 0)
                    AttributeChange();
                cy08 = value;
            }
        }

        public SqlInt32 CY09
        {
            get { return cy09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy09.CompareTo(value) != 0)
                    AttributeChange();
                cy09 = value;
            }
        }

        public SqlInt32 CY10
        {
            get { return cy10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy10.CompareTo(value) != 0)
                    AttributeChange();
                cy10 = value;
            }
        }

        public SqlInt32 CY11
        {
            get { return cy11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy11.CompareTo(value) != 0)
                    AttributeChange();
                cy11 = value;
            }
        }

        public SqlInt32 CY12
        {
            get { return cy12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (cy12.CompareTo(value) != 0)
                    AttributeChange();
                cy12 = value;
            }
        }

        public SqlInt32 NY01
        {
            get { return ny01; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny01.CompareTo(value) != 0)
                    AttributeChange();
                ny01 = value;
            }
        }

        public SqlInt32 NY02
        {
            get { return ny02; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny02.CompareTo(value) != 0)
                    AttributeChange();
                ny02 = value;
            }
        }

        public SqlInt32 NY03
        {
            get { return ny03; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny03.CompareTo(value) != 0)
                    AttributeChange();
                ny03 = value;
            }
        }

        public SqlInt32 NY04
        {
            get { return ny04; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny04.CompareTo(value) != 0)
                    AttributeChange();
                ny04 = value;
            }
        }

        public SqlInt32 NY05
        {
            get { return ny05; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny05.CompareTo(value) != 0)
                    AttributeChange();
                ny05 = value;
            }
        }

        public SqlInt32 NY06
        {
            get { return ny06; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny06.CompareTo(value) != 0)
                    AttributeChange();
                ny06 = value;
            }
        }

        public SqlInt32 NY07
        {
            get { return ny07; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny07.CompareTo(value) != 0)
                    AttributeChange();
                ny07 = value;
            }
        }

        public SqlInt32 NY08
        {
            get { return ny08; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny08.CompareTo(value) != 0)
                    AttributeChange();
                ny08 = value;
            }
        }

        public SqlInt32 NY09
        {
            get { return ny09; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny09.CompareTo(value) != 0)
                    AttributeChange();
                ny09 = value;
            }
        }

        public SqlInt32 NY10
        {
            get { return ny10; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny10.CompareTo(value) != 0)
                    AttributeChange();
                ny10 = value;
            }
        }

        public SqlInt32 NY11
        {
            get { return ny11; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny11.CompareTo(value) != 0)
                    AttributeChange();
                ny11 = value;
            }
        }

        public SqlInt32 NY12
        {
            get { return ny12; }
            set
            {
                // use CompareTo for proper null value comparision
                if (ny12.CompareTo(value) != 0)
                    AttributeChange();
                ny12 = value;
            }
        }
#endif

        public SqlDateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_createdDate.CompareTo(value) != 0)
                {
                    _createdDate = value;
                    FieldDataChange("CreatedDate", value);
                }
            }
        }

        public SqlInt32 PY01
        {
            get { return _forecastQuantityCollection[0]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[0].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[0] = value;
                    FieldDataChange("PY01", value);
                }
            }
        }

        public SqlInt32 PY02
        {
            get { return _forecastQuantityCollection[1]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[1].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[1] = value;
                    FieldDataChange("PY02", value);
                }
            }
        }

        public SqlInt32 PY03
        {
            get { return _forecastQuantityCollection[2]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[2].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[2] = value;
                    FieldDataChange("PY03", value);
                }
            }
        }

        public SqlInt32 PY04
        {
            get { return _forecastQuantityCollection[3]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[3].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[3] = value;
                    FieldDataChange("PY04", value);
                }
            }
        }

        public SqlInt32 PY05
        {
            get { return _forecastQuantityCollection[4]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[4].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[4] = value;
                    FieldDataChange("PY05", value);
                }
            }
        }

        public SqlInt32 PY06
        {
            get { return _forecastQuantityCollection[5]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[5].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[5] = value;
                    FieldDataChange("PY06", value);
                }
            }
        }

        public SqlInt32 PY07
        {
            get { return _forecastQuantityCollection[6]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[6].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[6] = value;
                    FieldDataChange("PY07", value);
                }
            }
        }

        public SqlInt32 PY08
        {
            get { return _forecastQuantityCollection[7]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[7].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[7] = value;
                    FieldDataChange("PY08", value);
                }
            }
        }

        public SqlInt32 PY09
        {
            get { return _forecastQuantityCollection[8]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[8].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[8] = value;
                    FieldDataChange("PY09", value);
                }
            }
        }

        public SqlInt32 PY10
        {
            get { return _forecastQuantityCollection[9]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[9].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[9] = value;
                    FieldDataChange("PY10", value);
                }
            }
        }

        public SqlInt32 PY11
        {
            get { return _forecastQuantityCollection[10]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[10].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[10] = value;
                    FieldDataChange("PY11", value);
                }
            }
        }

        public SqlInt32 PY12
        {
            get { return _forecastQuantityCollection[11]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[11].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[11] = value;
                    FieldDataChange("PY12", value);
                }
            }
        }

        public SqlInt32 CY01
        {
            get { return _forecastQuantityCollection[12]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[12].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[12] = value;
                    FieldDataChange("CY01", value);
                }
            }
        }

        public SqlInt32 CY02
        {
            get { return _forecastQuantityCollection[13]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[13].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[13] = value;
                    FieldDataChange("CY02", value);
                }
            }
        }

        public SqlInt32 CY03
        {
            get { return _forecastQuantityCollection[14]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[14].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[14] = value;
                    FieldDataChange("CY03", value);
                }
            }
        }

        public SqlInt32 CY04
        {
            get { return _forecastQuantityCollection[15]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[15].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[15] = value;
                    FieldDataChange("CY04", value);
                }
            }
        }

        public SqlInt32 CY05
        {
            get { return _forecastQuantityCollection[16]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[16].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[16] = value;
                    FieldDataChange("CY05", value);
                }
            }
        }

        public SqlInt32 CY06
        {
            get { return _forecastQuantityCollection[17]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[17].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[17] = value;
                    FieldDataChange("CY06", value);
                }
            }
        }

        public SqlInt32 CY07
        {
            get { return _forecastQuantityCollection[18]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[18].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[18] = value;
                    FieldDataChange("CY07", value);
                }
            }
        }

        public SqlInt32 CY08
        {
            get { return _forecastQuantityCollection[19]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[19].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[19] = value;
                    FieldDataChange("CY08", value);
                }
            }
        }

        public SqlInt32 CY09
        {
            get { return _forecastQuantityCollection[20]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[20].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[20] = value;
                    FieldDataChange("CY09", value);
                }
            }
        }

        public SqlInt32 CY10
        {
            get { return _forecastQuantityCollection[21]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[21].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[21] = value;
                    FieldDataChange("CY10", value);
                }
            }
        }

        public SqlInt32 CY11
        {
            get { return _forecastQuantityCollection[22]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[22].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[22] = value;
                    FieldDataChange("CY11", value);
                }
            }
        }

        public SqlInt32 CY12
        {
            get { return _forecastQuantityCollection[23]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[23].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[23] = value;
                    FieldDataChange("CY12", value);
                }
            }
        }

        public SqlInt32 NY01
        {
            get { return _forecastQuantityCollection[24]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[24].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[24] = value;
                    FieldDataChange("NY01", value);
                }
            }
        }

        public SqlInt32 NY02
        {
            get { return _forecastQuantityCollection[25]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[25].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[25] = value;
                    FieldDataChange("NY02", value);
                }
            }
        }

        public SqlInt32 NY03
        {
            get { return _forecastQuantityCollection[26]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[26].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[26] = value;
                    FieldDataChange("NY03", value);
                }
            }
        }

        public SqlInt32 NY04
        {
            get { return _forecastQuantityCollection[27]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[27].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[27] = value;
                    FieldDataChange("NY04", value);
                }
            }
        }

        public SqlInt32 NY05
        {
            get { return _forecastQuantityCollection[28]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[28].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[28] = value;
                    FieldDataChange("NY05", value);
                }
            }
        }

        public SqlInt32 NY06
        {
            get { return _forecastQuantityCollection[29]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[29].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[29] = value;
                    FieldDataChange("NY06", value);
                }
            }
        }

        public SqlInt32 NY07
        {
            get { return _forecastQuantityCollection[30]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[30].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[30] = value;
                    FieldDataChange("NY07", value);
                }
            }
        }

        public SqlInt32 NY08
        {
            get { return _forecastQuantityCollection[31]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[31].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[31] = value;
                    FieldDataChange("NY08", value);
                }
            }
        }

        public SqlInt32 NY09
        {
            get { return _forecastQuantityCollection[32]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[32].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[32] = value;
                    FieldDataChange("NY09", value);
                }
            }
        }

        public SqlInt32 NY10
        {
            get { return _forecastQuantityCollection[33]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[33].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[33] = value;
                    FieldDataChange("NY10", value);
                }
            }
        }

        public SqlInt32 NY11
        {
            get { return _forecastQuantityCollection[34]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[34].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[34] = value;
                    FieldDataChange("NY11", value);
                }
            }
        }

        public SqlInt32 NY12
        {
            get { return _forecastQuantityCollection[35]; }
            set
            {
                // use CompareTo for proper null value comparision
                if (_forecastQuantityCollection[35].CompareTo(value) != 0)
                {
                    _forecastQuantityCollection[35] = value;
                    FieldDataChange("NY12", value);
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

        [NotMapped]
        public SqlInt32[] ForecastQuantityCollection
        { get { return _forecastQuantityCollection; } }

        public override bool Validate()
        {
            if (ObjectKey == null)
                return false;
            return (!_companyCode.IsNull &&
                !_customerNumber.IsNull &&
                !_posSalesEndDate.IsNull &&
                !_itemNumber.IsNull &&
                !_forecastMethod.IsNull);
        }

        public bool GetOverride(string forecastValueKey)
        {
            if (!HasOverride)
                return false;

            var manualOverride = ForecastCommentAndOverrideCollection.OrderByDescending(commentAndOverride => commentAndOverride.CommentOverrideDateTime).FirstOrDefault(commentAndOverride => (bool)(commentAndOverride.ForecastValueKey == forecastValueKey && commentAndOverride.Comment.IsNull));
            return (bool)(manualOverride != null && manualOverride.IsOverride);
        }

        public List<ForecastCommentAndOverride> GetComments(string forecastValuekey)
        {
            return ForecastCommentAndOverrideCollection.Where(commentAndOverride => (bool)(commentAndOverride.ForecastValueKey == forecastValuekey && !commentAndOverride.Comment.IsNull)).OrderByDescending(commentAndOverride => commentAndOverride.CommentOverrideDateTime).ToList();
        }

        [NotMapped]
        public ForecastCommentAndOverride.WithForecastParentCollection ForecastCommentAndOverrideCollection
        {
            get
            {
                if (_forecastCommentAndOverrideCollection == null)
                {
                    _forecastCommentAndOverrideCollection = new ForecastCommentAndOverride.WithForecastParentCollection(this);
                    _forecastCommentAndOverrideCollection.Load();
                }
                return _forecastCommentAndOverrideCollection;
            }
            set { _forecastCommentAndOverrideCollection = value; }
        }

        [Serializable]
        public abstract class ACollection : APersistenceObjectWithParentCollection<ForecastKey, Forecast>
        {
            public bool ContainForecastMethod(string forecastMethod)
            {
                foreach (Forecast forecast in this)
                    if (forecast._forecastMethod == forecastMethod)
                        return true;
                return false;
            }

            #region Comparer Classes
            protected class comparer_ItemNumber : IComparer<Forecast>
            {
                public int Compare(Forecast x, Forecast y)
                {
                    return x.ItemNumber.CompareTo(y.ItemNumber);
                }
            }

            protected class comparer_ForecastMethod : IComparer<Forecast>
            {
                public int Compare(Forecast x, Forecast y)
                {
                    return x.ForecastMethod.CompareTo(y.ForecastMethod);
                }
            }
            #endregion
        }

        [Serializable]
        public class WithCustomerParentParameteredCollection : ACollection, ISetVersion
        {
            public WithCustomerParentParameteredCollection() { }

            public WithCustomerParentParameteredCollection(Customer parent, SqlDateTime posWeekEndDateEnd, ForecastAction forecastAction)
            {
                Parent = parent;
                ParameterCollection = new HybridDictionary
                                           {
                                               {"POSSalesEndDate", posWeekEndDateEnd},
                                               {"ForecastAction", forecastAction.ToString()}
                                           };
                SetHeader = new ForecastCollectionHeader(parent.CompanyCode, parent.CustomerNumber, posWeekEndDateEnd);
            }

            public IRowVersion SetHeader { get; set; }
        }

        [Serializable]
        public class WithCustomerParentPreviousCollection : ACollection
        {
            public WithCustomerParentPreviousCollection() { }

            public WithCustomerParentPreviousCollection(Customer parent, SqlDateTime posWeekEndDateEnd)
            {
                Parent = parent;
                ParameterCollection = new HybridDictionary { {"POSSalesEndDate", posWeekEndDateEnd} };
            }
        }
    }
}
