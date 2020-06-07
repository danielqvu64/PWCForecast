

CREATE PROCEDURE [dbo].[forecastSalesRateHeader_upd]
	@objectKey xml
	, @company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
	, @pos_number_of_weeks int
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM ForecastSalesRateHeader WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@company_code_key varchar(3)
	, @customer_number_key varchar(10)
	, @pos_sales_end_date_key datetime

SELECT	@company_code_key = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number_key = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @pos_sales_end_date_key = @objectKey.value('/ObjectKey[1]/@POSSalesEndDate', 'datetime')

UPDATE	ForecastSalesRateHeader
SET company_code = @company_code
	, customer_number = @customer_number
	, pos_sales_end_date = @pos_sales_end_date
	, pos_number_of_weeks = @pos_number_of_weeks
WHERE	company_code = @company_code_key
AND	customer_number = @customer_number_key
AND	pos_sales_end_date = @pos_sales_end_date_key

SELECT	@timestamp = timestamp
FROM	ForecastSalesRateHeader
WHERE	company_code = @company_code_key
AND	customer_number = @customer_number_key
AND	pos_sales_end_date = @pos_sales_end_date_key


