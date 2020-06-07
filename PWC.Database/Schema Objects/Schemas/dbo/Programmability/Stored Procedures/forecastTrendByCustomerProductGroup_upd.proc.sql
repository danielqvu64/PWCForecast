

CREATE PROCEDURE [dbo].[forecastTrendByCustomerProductGroup_upd]
	@objectKey xml
	, @company_code varchar(3)
	, @customer_number varchar(10)
	, @product_group_code varchar(4)
	, @forecast_method varchar(2)
	, @factor_month_01 decimal(5, 2)
	, @factor_month_02 decimal(5, 2)
	, @factor_month_03 decimal(5, 2)
	, @factor_month_04 decimal(5, 2)
	, @factor_month_05 decimal(5, 2)
	, @factor_month_06 decimal(5, 2)
	, @factor_month_07 decimal(5, 2)
	, @factor_month_08 decimal(5, 2)
	, @factor_month_09 decimal(5, 2)
	, @factor_month_10 decimal(5, 2)
	, @factor_month_11 decimal(5, 2)
	, @factor_month_12 decimal(5, 2)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM ForecastTrendByCustomerProductGroup WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@company_code_key varchar(3)
	, @customer_number_key varchar(10)
	, @product_group_code_key varchar(4)
	, @forecast_method_key varchar(2)

SELECT	@company_code_key = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number_key = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @product_group_code_key = @objectKey.value('/ObjectKey[1]/@ProductGroupCode', 'varchar(4)')
	, @forecast_method_key = @objectKey.value('/ObjectKey[1]/@ForecastMethod', 'varchar(2)')

UPDATE	ForecastTrendByCustomerProductGroup
SET company_code = @company_code
	, customer_number = @customer_number
	, product_group_code = @product_group_code
	, forecast_method = @forecast_method
	, factor_month_01 = @factor_month_01
	, factor_month_02 = @factor_month_02
	, factor_month_03 = @factor_month_03
	, factor_month_04 = @factor_month_04
	, factor_month_05 = @factor_month_05
	, factor_month_06 = @factor_month_06
	, factor_month_07 = @factor_month_07
	, factor_month_08 = @factor_month_08
	, factor_month_09 = @factor_month_09
	, factor_month_10 = @factor_month_10
	, factor_month_11 = @factor_month_11
	, factor_month_12 = @factor_month_12
WHERE	company_code = @company_code_key
AND	customer_number = @customer_number_key
AND	product_group_code = @product_group_code_key
AND	forecast_method = @forecast_method_key

SELECT	@timestamp = timestamp
FROM	ForecastTrendByCustomerProductGroup
WHERE	company_code = @company_code_key
AND	customer_number = @customer_number_key
AND	product_group_code = @product_group_code_key
AND	forecast_method = @forecast_method_key


