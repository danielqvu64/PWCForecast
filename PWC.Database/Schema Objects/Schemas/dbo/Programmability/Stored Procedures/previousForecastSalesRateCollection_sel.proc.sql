
CREATE PROCEDURE [dbo].[previousForecastSalesRateCollection_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)
	, @pos_sales_end_date datetime
AS

SET NOCOUNT ON

SELECT TOP 1
		company_code
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
		, sales_rate_previous
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
AND	item_number = @item_number
AND	pos_sales_end_date < @pos_sales_end_date
ORDER BY pos_sales_end_date DESC

