using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using DVu.Library.PersistenceLayer;

namespace PWC.PersistenceLayer
{
    public sealed class Utility
    {
        private static volatile Utility _instance;
        private static readonly object SyncRoot = new object();

        private Utility() { }

        public static Utility GetInstance()
        {
            if (_instance == null)
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Utility();
                }
            return _instance;
        }

        public string GetDefaultSqlServerName()
        {
            var connection = PersistenceFacade.GetInstance().GetDbConnection("PWCConnectionString");
            using (connection)
            {
                return connection.DataSource;
            }
        }

        public List<string> GetSavedSalesRateDateCollection(string companyCode, string customerNumber, long rowCount)
        {
            const string RDBConnectionKey = "PWCConnectionString";
            var pf = PersistenceFacade.GetInstance();
            var connection = pf.GetDbConnection(RDBConnectionKey);
            var command = connection.CreateCommand();
            command.CommandText = "savedSalesRateDateCollection_sel";
            command.CommandType = CommandType.StoredProcedure;
            pf.AddCommandParameter(RDBConnectionKey, command, "company_code", companyCode);
            pf.AddCommandParameter(RDBConnectionKey, command, "customer_number", customerNumber);
            pf.AddCommandParameter(RDBConnectionKey, command, "row_count", rowCount);
            var savedSalesRateDateCollection = new List<string> {"<< select >>"};
            using (var dr = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                    savedSalesRateDateCollection.Add(string.Format("{0:MM/dd/yyyy}", dr["POSSalesEndDate"]));
            }
            return savedSalesRateDateCollection;
        }

        public struct ForecastDateMethod
        {
            public string POSSalesEndDate;
            public string ForecastMethod;
            public string Description
            {
                get { return POSSalesEndDate == string.Empty ? "<< select >>" : string.Format("{0} - {1}", POSSalesEndDate, ForecastMethod); }
            }
            public ForecastDateMethod(string posSalesEndDate, string forecastMethod)
            {
                POSSalesEndDate = posSalesEndDate;
                ForecastMethod = forecastMethod;
            }
        }

        public List<ForecastDateMethod> GetSavedForecastDateCollection(SqlString companyCode, SqlString customerNumber, long rowCount)
        {
            const string RDBConnectionKey = "PWCConnectionString";
            var pf = PersistenceFacade.GetInstance();
            var connection = pf.GetDbConnection(RDBConnectionKey);
            var command = connection.CreateCommand();
            command.CommandText = "savedForecastDateCollection_sel";
            command.CommandType = CommandType.StoredProcedure;
            pf.AddCommandParameter(RDBConnectionKey, command, "company_code", companyCode);
            pf.AddCommandParameter(RDBConnectionKey, command, "customer_number", customerNumber);
            pf.AddCommandParameter(RDBConnectionKey, command, "row_count", rowCount);
            var savedForecastDateCollection = new List<ForecastDateMethod>
                                                  {new ForecastDateMethod(string.Empty, string.Empty)};
            using (var dr = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                    savedForecastDateCollection.Add(new ForecastDateMethod(string.Format("{0:MM/dd/yyyy}", dr["POSSalesEndDate"]), dr["ForecastMethod"].ToString()));
            }
            return savedForecastDateCollection;
        }

        public bool DoesForecastExist(SqlString companyCode, SqlString customerNumber, SqlDateTime posWeekEndDateEnd)
        {
            const string RDBConnectionKey = "PWCConnectionString";
            var pf = PersistenceFacade.GetInstance();
            var connection = pf.GetDbConnection(RDBConnectionKey);
            using (connection)
            {
                var command = connection.CreateCommand();
                command.CommandText = "doesForecastExist_sel";
                command.CommandType = CommandType.StoredProcedure;
                pf.AddCommandParameter(RDBConnectionKey, command, "company_code", companyCode);
                pf.AddCommandParameter(RDBConnectionKey, command, "customer_number", customerNumber);
                pf.AddCommandParameter(RDBConnectionKey, command, "pos_sales_end_date", posWeekEndDateEnd);
                return (int)command.ExecuteScalar() == 1;
            }
        }

        public bool DoesForecastSalesRateExist(SqlString companyCode, SqlString customerNumber, SqlDateTime posWeekEndDateEnd)
        {
            const string RDBConnectionKey = "PWCConnectionString";
            var pf = PersistenceFacade.GetInstance();
            var connection = pf.GetDbConnection(RDBConnectionKey);
            using (connection)
            {
                var command = connection.CreateCommand();
                command.CommandText = "doesForecastSalesRateExist_sel";
                command.CommandType = CommandType.StoredProcedure;
                pf.AddCommandParameter(RDBConnectionKey, command, "company_code", companyCode);
                pf.AddCommandParameter(RDBConnectionKey, command, "customer_number", customerNumber);
                pf.AddCommandParameter(RDBConnectionKey, command, "pos_sales_end_date", posWeekEndDateEnd);
                return (int)command.ExecuteScalar() == 1;
            }
        }

        //public string GetUserAccess()
        //{
        //    const string RDBConnectionKey = "PWCConnectionString";
        //    PersistenceFacade pf = PersistenceFacade.GetInstance();
        //    DbConnection connection = pf.GetDbConnection(RDBConnectionKey);
        //    using (connection)
        //    {
        //        DbCommand command = connection.CreateCommand();
        //        command.CommandText = "userAccessCollection_sel";
        //        command.CommandType = CommandType.StoredProcedure;
        //        DbDataReader dr = command.ExecuteReader();
        //        if (dr.Read())
        //            return dr[0].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}

        //public void UpdateUserAccess()
        //{
        //    const string RDBConnectionKey = "PWCConnectionString";
        //    PersistenceFacade pf = PersistenceFacade.GetInstance();
        //    DbConnection connection = pf.GetDbConnection(RDBConnectionKey);
        //    using (connection)
        //    {
        //        DbCommand command = connection.CreateCommand();
        //        command.CommandText = "userAccess_upd";
        //        command.CommandType = CommandType.StoredProcedure;
        //        pf.AddCommandParameter(RDBConnectionKey, command, "machine_name", Environment.MachineName);
        //        command.ExecuteNonQuery();
        //    }
        //}

        //public void DeleteUserAccess()
        //{
        //    const string RDBConnectionKey = "PWCConnectionString";
        //    PersistenceFacade pf = PersistenceFacade.GetInstance();
        //    DbConnection connection = pf.GetDbConnection(RDBConnectionKey);
        //    using (connection)
        //    {
        //        DbCommand command = connection.CreateCommand();
        //        command.CommandText = "userAccess_del";
        //        command.CommandType = CommandType.StoredProcedure;
        //        pf.AddCommandParameter(RDBConnectionKey, command, "machine_name", Environment.MachineName);
        //        command.ExecuteNonQuery();
        //    }
        //}

        //public void ResetUserAccess()
        //{
        //    const string RDBConnectionKey = "PWCConnectionString";
        //    PersistenceFacade pf = PersistenceFacade.GetInstance();
        //    DbConnection connection = pf.GetDbConnection(RDBConnectionKey);
        //    using (connection)
        //    {
        //        DbCommand command = connection.CreateCommand();
        //        command.CommandText = "userAccessCollection_del";
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}
