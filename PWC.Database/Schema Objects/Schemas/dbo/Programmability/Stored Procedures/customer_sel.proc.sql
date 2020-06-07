

CREATE PROCEDURE [dbo].[customer_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')

SELECT	company_code
	, customer_number
	, customer_name
	, distinct_forecast_name_flag
	, forecast_method
	, inflate_factor
	, forecast_future_frozen_months
	, timestamp
FROM	Customer
WHERE	company_code = @company_code
AND		customer_number = @customer_number


