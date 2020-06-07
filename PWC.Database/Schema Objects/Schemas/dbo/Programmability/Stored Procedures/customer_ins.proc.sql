

CREATE PROCEDURE [dbo].[customer_ins]
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @customer_name varchar(100)
	, @distinct_forecast_name_flag bit
	, @forecast_method varchar(2)
	, @inflate_factor decimal(5, 2)
	, @forecast_future_frozen_months smallint
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

INSERT	Customer
	(company_code, customer_number, customer_name, distinct_forecast_name_flag, forecast_method, inflate_factor, forecast_future_frozen_months)
VALUES
	(@company_code, @customer_number, @customer_name, @distinct_forecast_name_flag, @forecast_method, @inflate_factor, @forecast_future_frozen_months)

SELECT	@timestamp = timestamp
FROM	Customer
WHERE	company_code = @company_code
AND	customer_number = @customer_number

SELECT	@company_code + '|' + @customer_number


