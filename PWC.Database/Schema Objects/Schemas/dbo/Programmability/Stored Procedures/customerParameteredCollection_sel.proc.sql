

CREATE PROCEDURE [dbo].[customerParameteredCollection_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
AS

SET NOCOUNT ON

SELECT	company_code
	, customer_number
	, customer_name
	, distinct_forecast_name_flag
	, forecast_method
	, inflate_factor
	, forecast_future_frozen_months
	, timestamp
FROM	Customer
WHERE	company_code = ISNULL(@company_code, company_code)
AND		customer_number = ISNULL(@customer_number, customer_number)


