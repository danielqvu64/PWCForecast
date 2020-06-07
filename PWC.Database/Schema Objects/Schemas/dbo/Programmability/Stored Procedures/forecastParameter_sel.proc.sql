

CREATE PROCEDURE [dbo].[forecastParameter_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')

SELECT	company_code
	, customer_number
	, item_number
	, store_count_existing
	, store_count_new
	, initial_qty_per_new_store
	, pipeline_start
	, pipeline_end
	, projected_sales_rate_existing
	, projected_sales_rate_new
	, one_time_item_flag
	, pl_pct_py_01
	, pl_pct_py_02
	, pl_pct_py_03
	, pl_pct_py_04
	, pl_pct_py_05
	, pl_pct_py_06
	, pl_pct_py_07
	, pl_pct_py_08
	, pl_pct_py_09
	, pl_pct_py_10
	, pl_pct_py_11
	, pl_pct_py_12
	, pl_pct_cy_01
	, pl_pct_cy_02
	, pl_pct_cy_03
	, pl_pct_cy_04
	, pl_pct_cy_05
	, pl_pct_cy_06
	, pl_pct_cy_07
	, pl_pct_cy_08
	, pl_pct_cy_09
	, pl_pct_cy_10
	, pl_pct_cy_11
	, pl_pct_cy_12
	, pl_pct_ny_01
	, pl_pct_ny_02
	, pl_pct_ny_03
	, pl_pct_ny_04
	, pl_pct_ny_05
	, pl_pct_ny_06
	, pl_pct_ny_07
	, pl_pct_ny_08
	, pl_pct_ny_09
	, pl_pct_ny_10
	, pl_pct_ny_11
	, pl_pct_ny_12
	, timestamp
FROM	ForecastParameter
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	item_number = @item_number

