

CREATE PROCEDURE [dbo].[forecastTrendByCustomerProductGroupCollection_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')

SELECT	company_code
	, customer_number
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
FROM	ForecastTrendByCustomerProductGroup
WHERE	company_code = @company_code
AND	customer_number = @customer_number
ORDER BY 1, 2, 3, 4


