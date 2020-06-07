

CREATE PROCEDURE [dbo].[forecastSalesRateHeader_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @pos_sales_end_date = @objectKey.value('/ObjectKey[1]/@POSSalesEndDate', 'datetime')

SELECT	company_code
	, customer_number
	, pos_sales_end_date
	, pos_number_of_weeks
	, timestamp
FROM	ForecastSalesRateHeader
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date = @pos_sales_end_date


