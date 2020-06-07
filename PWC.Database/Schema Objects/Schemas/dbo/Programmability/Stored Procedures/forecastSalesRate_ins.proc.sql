
CREATE PROCEDURE [dbo].[forecastSalesRate_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
	, @item_number varchar(11)
	, @trend_factor decimal(5, 2)
	, @pos_week_1_quantity int
	, @pos_week_2_quantity int
	, @pos_week_3_quantity int
	, @pos_week_4_quantity int
	, @store_count_existing int
	, @store_count_new int
	, @sales_rate decimal(5, 2)
	, @sales_rate_previous decimal(5, 2)
	, @has_override bit
	, @has_comment bit
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

INSERT	ForecastSalesRate
	( company_code
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
	, sales_rate_previous)
VALUES
	( @company_code
	, @customer_number
	, @pos_sales_end_date
	, @item_number
	, @trend_factor
	, @pos_week_1_quantity
	, @pos_week_2_quantity
	, @pos_week_3_quantity
	, @pos_week_4_quantity
	, @store_count_existing
	, @store_count_new
	, @sales_rate
	, @sales_rate_previous)

SELECT	@timestamp = timestamp
FROM	ForecastSalesRate
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date = @pos_sales_end_date
AND	item_number = @item_number

SELECT	@company_code + '|' + @customer_number + '|' + CONVERT(varchar, @pos_sales_end_date, 101) + '|' + @item_number

