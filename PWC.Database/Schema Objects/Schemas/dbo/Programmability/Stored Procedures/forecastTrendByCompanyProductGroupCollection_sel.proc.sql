

CREATE PROCEDURE [dbo].[forecastTrendByCompanyProductGroupCollection_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')

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
ORDER BY 1, 2, 3


