CREATE PROCEDURE [dbo].[forecastTrendByCustomerProductGroupItemCollection_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
AS

SET NOCOUNT ON

SELECT DISTINCT
	  i.item_number
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
FROM	ForecastTrendByCustomerProductGroup t
JOIN	Item i
	ON	t.product_group_code = i.product_group_code
JOIN	ForecastParameter p
	ON	t.company_code = p.company_code
	AND	t.customer_number = p.customer_number
	AND	i.item_number = p.item_number
WHERE	t.company_code = @company_code
AND	t.customer_number = @customer_number
ORDER BY 1, 2
