CREATE PROCEDURE [dbo].[utlCopyParameterFromBcp]
AS

insert item (item_number)
select distinct item_number from ForecastParameterBcp
where item_number not in (select item_number from item)

dbcc dbreindex(item)

insert Customer (company_code, customer_number)
select distinct co.organization_code, p.customer_number
from ForecastParameterBcp p
join CompanyOrganization co
on p.co_code = co.company_code
where not exists (select 1 from Customer c where c.company_code = co.organization_code and c.customer_number = p.customer_number)

dbcc dbreindex(Customer)

truncate table ForecastParameter

insert ForecastParameter
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
	, pl_pct_ny_12 )
select 
	  o.organization_code
	, CUSTOMER_NUMBER
	, ITEM_NUMBER
	, STORE_COUNT_EXISTING
	, STORE_COUNT_NEW
	, INITIAL_QTY_PER_NEW_STORE
	, PIPELINE_START
	, PIPELINE_END
	, PROJECTED_SALES_RATE_EXISTING
	, PROJECTED_SALES_RATE_NEW
	, PL_PCT_PY_01
	, PL_PCT_PY_02
	, PL_PCT_PY_03
	, PL_PCT_PY_04
	, PL_PCT_PY_05
	, PL_PCT_PY_06
	, PL_PCT_PY_07
	, PL_PCT_PY_08
	, PL_PCT_PY_09
	, PL_PCT_PY_10
	, PL_PCT_PY_11
	, PL_PCT_PY_12
	, PL_PCT_CY_01
	, PL_PCT_CY_02
	, PL_PCT_CY_03
	, PL_PCT_CY_04
	, PL_PCT_CY_05
	, PL_PCT_CY_06
	, PL_PCT_CY_07
	, PL_PCT_CY_08
	, PL_PCT_CY_09
	, PL_PCT_CY_10
	, PL_PCT_CY_11
	, PL_PCT_CY_12
	, PL_PCT_NY_01
	, PL_PCT_NY_02
	, PL_PCT_NY_03
	, PL_PCT_NY_04
	, PL_PCT_NY_05
	, PL_PCT_NY_06
	, PL_PCT_NY_07
	, PL_PCT_NY_08
	, PL_PCT_NY_09
	, PL_PCT_NY_10
	, PL_PCT_NY_11
	, PL_PCT_NY_12
from ForecastParameterBcp p
join CompanyOrganization o
on p.CO_CODE = o.company_code
order by 1, 2, 3

DBCC DBREINDEX(ForecastParameter)
