
CREATE PROCEDURE [dbo].[forecastSalesRate_upd]
	@objectKey xml
	, @company_code varchar(3)
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

IF NOT EXISTS (SELECT 1 FROM ForecastSalesRate WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@company_code_key varchar(3)
	, @customer_number_key varchar(10)
	, @pos_sales_end_date_key datetime
	, @item_number_key varchar(11)

SELECT	@company_code_key = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number_key = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @pos_sales_end_date_key = @objectKey.value('/ObjectKey[1]/@POSSalesEndDate', 'datetime')
	, @item_number_key = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')

UPDATE	ForecastSalesRate
SET company_code = @company_code
	, customer_number = @customer_number
	, pos_sales_end_date = @pos_sales_end_date
	, item_number = @item_number
	, trend_factor = @trend_factor
	, pos_week_1_quantity = @pos_week_1_quantity
	, pos_week_2_quantity = @pos_week_2_quantity
	, pos_week_3_quantity = @pos_week_3_quantity
	, pos_week_4_quantity = @pos_week_4_quantity
	, store_count_existing = @store_count_existing
	, store_count_new = @store_count_new
	, sales_rate = @sales_rate
	, sales_rate_previous = @sales_rate_previous
WHERE	company_code = @company_code_key
AND	customer_number = @customer_number_key
AND	pos_sales_end_date = @pos_sales_end_date_key
AND	item_number = @item_number_key

SELECT	@timestamp = timestamp
FROM	ForecastSalesRate
WHERE	company_code = @company_code_key
AND	customer_number = @customer_number_key
AND	pos_sales_end_date = @pos_sales_end_date_key
AND	item_number = @item_number_key

