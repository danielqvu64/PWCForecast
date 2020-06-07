

CREATE PROCEDURE [dbo].[forecastTrendByCustomerItem_ins]
	@company_code varchar(3)
	, @customer_number varchar(10)
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

INSERT	ForecastTrendByCustomerItem
	( company_code
	, customer_number
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
	, factor_month_12 )
VALUES
	( @company_code
	, @customer_number
	, @item_number
	, @forecast_method
	, @factor_month_01
	, @factor_month_02
	, @factor_month_03
	, @factor_month_04
	, @factor_month_05
	, @factor_month_06
	, @factor_month_07
	, @factor_month_08
	, @factor_month_09
	, @factor_month_10
	, @factor_month_11
	, @factor_month_12 )

SELECT	@timestamp = timestamp
FROM	ForecastTrendByCustomerItem
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	item_number = @item_number
AND forecast_method = @forecast_method

SELECT	@company_code + '|' + @customer_number + '|' + @item_number + '|' + @forecast_method


