

CREATE PROCEDURE [dbo].[forecastTrendByCompanyProductGroup_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @product_group_code varchar(4)
	, @forecast_method varchar(2)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @product_group_code = @objectKey.value('/ObjectKey[1]/@ProductGroupCode', 'varchar(4)')
	, @forecast_method = @objectKey.value('/ObjectKey[1]/@ForecastMethod', 'varchar(2)')

SELECT	company_code
	, product_group_code
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
FROM	ForecastTrendByCompanyProductGroup
WHERE	company_code = @company_code
AND	product_group_code = @product_group_code
AND	forecast_method = @forecast_method


