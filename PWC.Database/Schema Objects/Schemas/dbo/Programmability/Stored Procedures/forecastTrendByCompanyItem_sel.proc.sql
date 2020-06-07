

CREATE PROCEDURE [dbo].[forecastTrendByCompanyItem_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @item_number varchar(11)
	, @forecast_method varchar(2)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')
	, @forecast_method = @objectKey.value('/ObjectKey[1]/@ForecastMethod', 'varchar(2)')

SELECT	company_code
	, item_number
	, forecast_method
	, factor_month_01
	, factor_month_02
	, factor_month_03
	, factor_month_04
	, factor_month_05
	, factor_month_06
	, factor_month_07
	, factor_month_08
	, factor_month_09
	, factor_month_10
	, factor_month_11
	, factor_month_12
	, timestamp
FROM	ForecastTrendByCompanyItem
WHERE	company_code = @company_code
AND	item_number = @item_number
AND	forecast_method = @forecast_method
ORDER BY 1, 2, 3

