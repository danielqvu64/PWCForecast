
CREATE PROCEDURE [dbo].[forecastSalesRate_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
	, @item_number varchar(11)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @pos_sales_end_date = @objectKey.value('/ObjectKey[1]/@POSSalesEndDate', 'datetime')
	, @item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')

SELECT	company_code
	, customer_number
	, pos_sales_end_date
	, item_number
	, trend_factor
	, pos_week_1_quantity
	, pos_week_2_quantity
	, pos_week_3_quantity
	, pos_week_4_quantity
	, store_count_existing
	, store_count_new
	, sales_rate
	, NULL sales_rate_previous
	, CASE WHEN EXISTS (SELECT 1 FROM ForecastSalesrateCommentAndOverride WHERE company_code = ForecastSalesRate.company_code
																		AND customer_number = ForecastSalesRate.customer_number
																		AND item_number = ForecastSalesRate.item_number
																		AND pos_sales_end_date = ForecastSalesRate.pos_sales_end_date
																		AND comment IS NULL) THEN 1 ELSE 0 END has_override
	, CASE WHEN EXISTS (SELECT 1 FROM ForecastSalesrateCommentAndOverride WHERE company_code = ForecastSalesRate.company_code
																		AND customer_number = ForecastSalesRate.customer_number
																		AND item_number = ForecastSalesRate.item_number
																		AND pos_sales_end_date = ForecastSalesRate.pos_sales_end_date
																		AND comment IS NOT NULL) THEN 1 ELSE 0 END has_comment
	, timestamp
FROM	ForecastSalesRate
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date = @pos_sales_end_date
AND	item_number = @item_number
