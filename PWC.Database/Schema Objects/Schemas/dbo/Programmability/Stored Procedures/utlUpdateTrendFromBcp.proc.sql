CREATE PROCEDURE [dbo].[utlUpdateTrendFromBcp] 
AS

insert item (item_number)
select distinct item_number from ForecastTrendFactorByCompanyBcp
where item_number not in (select item_number from item)

dbcc dbreindex(item)

truncate table ForecastTrendFactorByCompany

insert ForecastTrendFactorByCompany
select co.organization_code
	, tb.item_number
	, tb.forecast_method
	, tb.factor_month_01
	, tb.factor_month_02
	, tb.factor_month_03
	, tb.factor_month_04
	, tb.factor_month_05
	, tb.factor_month_06
	, tb.factor_month_07
	, tb.factor_month_08
	, tb.factor_month_09
	, tb.factor_month_10
	, tb.factor_month_11
	, tb.factor_month_12
from ForecastTrendFactorByCompanyBcp tb
join companyorganization co
on tb.co_code = co.company_code
where not exists (
	select 1 from ForecastTrendFactorByCompany t
	where t.company_code = co.organization_code
	and t.item_number = tb.item_number
	and t.forecast_method = tb.forecast_method)
and forecast_method = 'SR'

dbcc dbreindex(ForecastTrendFactorByCompany)
