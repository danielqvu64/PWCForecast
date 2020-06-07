

CREATE PROCEDURE [dbo].[forecastParameter_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)
	, @store_count_existing int
	, @store_count_new int
	, @initial_qty_per_new_store decimal(7, 2)
	, @pipeline_start varchar(4)
	, @pipeline_end varchar(4)
	, @projected_sales_rate_existing decimal(5, 2)
	, @projected_sales_rate_new decimal(5, 2)
	, @one_time_item_flag bit
	, @pl_pct_py_01 decimal(5, 2)
	, @pl_pct_py_02 decimal(5, 2)
	, @pl_pct_py_03 decimal(5, 2)
	, @pl_pct_py_04 decimal(5, 2)
	, @pl_pct_py_05 decimal(5, 2)
	, @pl_pct_py_06 decimal(5, 2)
	, @pl_pct_py_07 decimal(5, 2)
	, @pl_pct_py_08 decimal(5, 2)
	, @pl_pct_py_09 decimal(5, 2)
	, @pl_pct_py_10 decimal(5, 2)
	, @pl_pct_py_11 decimal(5, 2)
	, @pl_pct_py_12 decimal(5, 2)
	, @pl_pct_cy_01 decimal(5, 2)
	, @pl_pct_cy_02 decimal(5, 2)
	, @pl_pct_cy_03 decimal(5, 2)
	, @pl_pct_cy_04 decimal(5, 2)
	, @pl_pct_cy_05 decimal(5, 2)
	, @pl_pct_cy_06 decimal(5, 2)
	, @pl_pct_cy_07 decimal(5, 2)
	, @pl_pct_cy_08 decimal(5, 2)
	, @pl_pct_cy_09 decimal(5, 2)
	, @pl_pct_cy_10 decimal(5, 2)
	, @pl_pct_cy_11 decimal(5, 2)
	, @pl_pct_cy_12 decimal(5, 2)
	, @pl_pct_ny_01 decimal(5, 2)
	, @pl_pct_ny_02 decimal(5, 2)
	, @pl_pct_ny_03 decimal(5, 2)
	, @pl_pct_ny_04 decimal(5, 2)
	, @pl_pct_ny_05 decimal(5, 2)
	, @pl_pct_ny_06 decimal(5, 2)
	, @pl_pct_ny_07 decimal(5, 2)
	, @pl_pct_ny_08 decimal(5, 2)
	, @pl_pct_ny_09 decimal(5, 2)
	, @pl_pct_ny_10 decimal(5, 2)
	, @pl_pct_ny_11 decimal(5, 2)
	, @pl_pct_ny_12 decimal(5, 2)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

INSERT	ForecastParameter
	( company_code
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
	, pl_pct_ny_12)
VALUES
	( @company_code
	, @customer_number
	, @item_number
	, @store_count_existing
	, @store_count_new
	, @initial_qty_per_new_store
	, @pipeline_start
	, @pipeline_end
	, @projected_sales_rate_existing
	, @projected_sales_rate_new
	, @one_time_item_flag
	, @pl_pct_py_01
	, @pl_pct_py_02
	, @pl_pct_py_03
	, @pl_pct_py_04
	, @pl_pct_py_05
	, @pl_pct_py_06
	, @pl_pct_py_07
	, @pl_pct_py_08
	, @pl_pct_py_09
	, @pl_pct_py_10
	, @pl_pct_py_11
	, @pl_pct_py_12
	, @pl_pct_cy_01
	, @pl_pct_cy_02
	, @pl_pct_cy_03
	, @pl_pct_cy_04
	, @pl_pct_cy_05
	, @pl_pct_cy_06
	, @pl_pct_cy_07
	, @pl_pct_cy_08
	, @pl_pct_cy_09
	, @pl_pct_cy_10
	, @pl_pct_cy_11
	, @pl_pct_cy_12
	, @pl_pct_ny_01
	, @pl_pct_ny_02
	, @pl_pct_ny_03
	, @pl_pct_ny_04
	, @pl_pct_ny_05
	, @pl_pct_ny_06
	, @pl_pct_ny_07
	, @pl_pct_ny_08
	, @pl_pct_ny_09
	, @pl_pct_ny_10
	, @pl_pct_ny_11
	, @pl_pct_ny_12)

SELECT	@timestamp = timestamp
FROM	ForecastParameter
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	item_number = @item_number

SELECT	@company_code + '|' + @customer_number + '|' + @item_number

