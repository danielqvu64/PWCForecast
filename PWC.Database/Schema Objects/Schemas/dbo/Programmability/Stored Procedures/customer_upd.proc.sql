

CREATE PROCEDURE [dbo].[customer_upd]
	@objectKey xml
	, @company_code varchar(3)
	, @customer_number varchar(10)
	, @customer_name varchar(100)
	, @distinct_forecast_name_flag bit
	, @forecast_method varchar(2)
	, @inflate_factor decimal(5, 2)
	, @forecast_future_frozen_months smallint
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM Customer WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@company_code_key varchar(3)
	, @customer_number_key varchar(10)

SELECT	@company_code_key = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number_key = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')

UPDATE	Customer
SET	company_code = @company_code
	, customer_number = @customer_number
	, customer_name = @customer_name
	, distinct_forecast_name_flag = @distinct_forecast_name_flag
	, forecast_method = @forecast_method
	, inflate_factor = @inflate_factor
	, forecast_future_frozen_months = @forecast_future_frozen_months
WHERE	company_code = @company_code_key
AND		customer_number = @customer_number_key

SELECT	@timestamp = timestamp
FROM	Customer
WHERE	company_code = @company_code_key
AND		customer_number = @customer_number_key


