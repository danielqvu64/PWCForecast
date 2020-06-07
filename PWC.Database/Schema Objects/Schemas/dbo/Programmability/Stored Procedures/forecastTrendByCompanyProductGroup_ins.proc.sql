

CREATE PROCEDURE [dbo].[forecastTrendByCompanyProductGroup_ins]
	@company_code varchar(3)
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

INSERT	ForecastTrendByCompanyProductGroup
	( company_code
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
	, factor_month_12 )
VALUES
	( @company_code
	, @product_group_code
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
FROM	ForecastTrendByCompanyProductGroup
WHERE	company_code = @company_code
AND	product_group_code = @product_group_code
AND forecast_method = @forecast_method

SELECT	@company_code + '|' + @product_group_code + '|' + @forecast_method


