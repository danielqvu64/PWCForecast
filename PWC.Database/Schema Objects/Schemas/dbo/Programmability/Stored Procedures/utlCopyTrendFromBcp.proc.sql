CREATE PROCEDURE [dbo].[utlCopyTrendFromBcp] 
AS

insert item (item_number)
select distinct item_number from ForecastTrendFactorBcp
where item_number not in (select item_number from item)

dbcc dbreindex(item)

truncate table ForecastTrendFactor

insert ForecastTrendFactor
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
from ForecastTrendFactorBcp tb
join companyorganization co
on tb.co_code = co.company_code

dbcc dbreindex(ForecastTrendFactor)
