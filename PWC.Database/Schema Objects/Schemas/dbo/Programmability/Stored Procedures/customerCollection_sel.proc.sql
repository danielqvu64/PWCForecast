


CREATE PROCEDURE [dbo].[customerCollection_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')

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
ORDER BY 1, 3


