using System;

namespace PWC.BusinessObject
{
    /// <summary>
    /// Summary description for Calendar.
    /// </summary>
    public sealed class Calendar
    {
        private static volatile Calendar _instance;
        private static readonly object SyncRoot = new object();

        private Calendar() { }

        public static Calendar GetInstance()
        {
            if (_instance == null)
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Calendar();
                }
            return _instance;
        }

        private readonly string _previousYear = (DateTime.Today.Year - 1).ToString().Substring(2);
        private readonly string _currentYear = DateTime.Today.Year.ToString().Substring(2);
        private readonly string _nextYear = (DateTime.Today.Year + 1).ToString().Substring(2);

        private void GetPrevCurrNextYear(out string previousYear, out string currentYear, out string nextYear, DateTime CYDate)
        {
            // based on passed in CYDate
            previousYear = (CYDate.Year - 1).ToString("0000").Substring(2);
            currentYear = CYDate.Year.ToString("0000").Substring(2);
            nextYear = (CYDate.Year + 1).ToString("0000").Substring(2);
        }

        public string GetMMdash01dashYY(string PWCforecastMonth, DateTime CYDate)
        {
            // forecastMonth is in "PY##", "CY##", "NY##" format
            // based on passed in CYDate
            string YYMM = GetYYMM(PWCforecastMonth, CYDate);
            return string.Format("{0}-01-{1}", YYMM.Substring(2), YYMM.Substring(0, 2)); 
        }

        public string Get01slashMMslashYY(string PWCforecastMonth, DateTime CYDate)
        {
            // PWCforecastMonth is in "PY##", "CY##", "NY##" format
            // based on passed in CYDate
            string YYMM = GetYYMM(PWCforecastMonth, CYDate);
            return string.Format("01/{0}/{1}", YYMM.Substring(2), YYMM.Substring(0, 2));
        }

        public string GetMMMYYYY(string PWCforecastMonth, DateTime CYDate)
        {
            return GetDateFromForecastMonth(PWCforecastMonth, CYDate).ToString("MMM yyyy");
        }

        public string GetYYMM(string PWCforecastMonth, DateTime CYDate)
        {
            string previousYear, currentYear, nextYear;
            GetPrevCurrNextYear(out previousYear, out currentYear, out nextYear, CYDate);
            return PWCforecastMonth.Replace("PY", previousYear).Replace("CY", currentYear).Replace("NY", nextYear);
        }
        
        public string GetYYMM(string PWCforecastMonth)
        {
            // PWCforecastMonth is in "PY##", "CY##", "NY##" format
            return PWCforecastMonth.Replace("PY", _previousYear).Replace("CY", _currentYear).Replace("NY", _nextYear);
        }

        public DateTime GetDateFromForecastMonth(string PWCforecastMonth, DateTime CYDate)
        {
            string YYMM = GetYYMM(PWCforecastMonth, CYDate);
            return DateTime.Parse(string.Format("{0}/1/{1}", YYMM.Substring(2, 2), YYMM.Substring(0, 2)));
        }

        public DateTime GetDateFromForecastMonth(string PWCforecastMonth)
        {
            string YYMM = GetYYMM(PWCforecastMonth);
            return DateTime.Parse(string.Format("{0}/1/{1}", YYMM.Substring(2, 2), YYMM.Substring(0, 2)));
        }

        public int GetDaysInMonth(string PWCForecastMonth)
        {
            // PWCForecastMonth is in "PY##", "CY##", "NY##" format
            string YYMM = PWCForecastMonth.Replace("PY", _previousYear).Replace("CY", _currentYear).Replace("NY", _nextYear);
            return DateTime.DaysInMonth(int.Parse(YYMM.Substring(0, 2)), int.Parse(YYMM.Substring(2, 2)));
        }

        public string GetYYMM(DateTime date)
        {
            return new System.Text.StringBuilder(date.Year.ToString("0000").Substring(2)).Append(date.Month.ToString("00")).ToString();
        }

        public string GetPWCForecastMonth(DateTime date)
        {
            string year = date.Year.ToString("0000").Substring(2);
            if (year == _previousYear)
                return string.Format("PY{0}", date.Month.ToString("00"));
            else if (year == _currentYear)
                return string.Format("CY{0}", date.Month.ToString("00"));
            else if (year == _nextYear)
                return string.Format("NY{0}", date.Month.ToString("00"));
            else
                throw new ApplicationException("Year is not in PY-NY range.");
        }

        public string GetNexYearPWCForecastMonth(string PWCForecastMonth)
        {
            string nextYearPWCForecastMonth = PWCForecastMonth.Replace("CY", "NY");
            nextYearPWCForecastMonth = nextYearPWCForecastMonth.Replace("PY", "CY");
            return nextYearPWCForecastMonth;
        }

        public string GetPriorYearPWCForecastMonth(string PWCForecastMonth)
        {
            string priorYearPWCForecastMonth = PWCForecastMonth.Replace("CY", "PY");
            priorYearPWCForecastMonth = priorYearPWCForecastMonth.Replace("NY", "CY");
            return priorYearPWCForecastMonth;
        }

        public string GetNexMonthPWCForecastMonth(string PWCForecastMonth)
        {
            if (PWCForecastMonth == "NY12")
                return PWCForecastMonth;
            string YYMMMonth = GetYYMM(PWCForecastMonth);
            DateTime month = new DateTime(int.Parse(YYMMMonth.Substring(0, 2)), int.Parse(YYMMMonth.Substring(2)), 1);
            return GetPWCForecastMonth(month.AddMonths(1));
        }

        public string GetPriorMonthPWCForecastMonth(string PWCForecastMonth)
        {
            if (PWCForecastMonth == "PY01")
                return PWCForecastMonth;
            string YYMMMonth = GetYYMM(PWCForecastMonth);
            DateTime month = new DateTime(int.Parse(YYMMMonth.Substring(0, 2)), int.Parse(YYMMMonth.Substring(2)), 1);
            return GetPWCForecastMonth(month.AddMonths(-1));
        }

        public int Get3YearCollectionOffset(string PWCForecastMonth)
        {
            int yearOffset = 0;
            switch (PWCForecastMonth.Substring(0, 2))
            {
                case "PY": yearOffset = 0; break;
                case "CY": yearOffset = 12; break;
                case "NY": yearOffset = 24; break;
                default: throw new ApplicationException("Invalid PWCForecastMonth");
            }
            return yearOffset + int.Parse(PWCForecastMonth.Substring(2, 2)) - 1;
        }
    }
}
