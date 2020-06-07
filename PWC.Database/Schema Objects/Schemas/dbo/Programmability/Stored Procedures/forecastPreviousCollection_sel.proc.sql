
CREATE PROCEDURE [dbo].[forecastPreviousCollection_sel]
	@objectKey xml
	, @pos_sales_end_date datetime
AS

SET NOCOUNT ON
DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @prev_pos_week_end_date_end datetime

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')

SELECT @prev_pos_week_end_date_end = MAX(pos_sales_end_date)
FROM	forecast
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date <= @pos_sales_end_date

SELECT	company_code
	, customer_number
	, pos_sales_end_date
	, item_number
	, forecast_method
	, created_date
	, py_01
	, py_02
	, py_03
	, py_04
	, py_05
	, py_06
	, py_07
	, py_08
	, py_09
	, py_10
	, py_11
	, py_12
	, cy_01
	, cy_02
	, cy_03
	, cy_04
	, cy_05
	, cy_06
	, cy_07
	, cy_08
	, cy_09
	, cy_10
	, cy_11
	, cy_12
	, ny_01
	, ny_02
	, ny_03
	, ny_04
	, ny_05
	, ny_06
	, ny_07
	, ny_08
	, ny_09
	, ny_10
	, ny_11
	, ny_12
	, CASE WHEN EXISTS (SELECT 1 FROM ForecastCommentAndOverride WHERE company_code = Forecast.company_code
																AND customer_number = Forecast.customer_number
																AND pos_sales_end_date = Forecast.pos_sales_end_date
																AND item_number = Forecast.item_number
																AND forecast_method = Forecast.forecast_method
																AND comment IS NULL) THEN 1 ELSE 0 END has_override
	, CASE WHEN EXISTS (SELECT 1 FROM ForecastCommentAndOverride WHERE company_code = Forecast.company_code
																AND customer_number = Forecast.customer_number
																AND pos_sales_end_date = Forecast.pos_sales_end_date
																AND item_number = Forecast.item_number
																AND forecast_method = Forecast.forecast_method
																AND comment IS NOT NULL) THEN 1 ELSE 0 END has_comment
	, timestamp
FROM	Forecast
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date = @prev_pos_week_end_date_end
ORDER BY 1, 2, 3, 4, 5

