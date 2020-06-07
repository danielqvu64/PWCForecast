

CREATE PROCEDURE [dbo].[forecastTrendByCompanyItem_upd]
	@objectKey xml
	, @company_code varchar(3)
	, @item_number varchar(11)
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

IF NOT EXISTS (SELECT 1 FROM ForecastTrendByCompanyItem WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@company_code_key varchar(3)
	, @item_number_key varchar(11)
	, @forecast_method_key varchar(2)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')
	, @forecast_method = @objectKey.value('/ObjectKey[1]/@ForecastMethod', 'varchar(2)')

UPDATE	ForecastTrendByCompanyItem
SET company_code = @company_code
	, item_number = @item_number
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
AND	item_number = @item_number_key
AND	forecast_method = @forecast_method_key

SELECT	@timestamp = timestamp
FROM	ForecastTrendByCompanyItem
WHERE	company_code = @company_code_key
AND	item_number = @item_number_key
AND	forecast_method = @forecast_method_key


