CREATE procedure [dbo].[utlUpdatePOSFromOracle]
as

declare @cutoffDate datetime
select @cutoffDate = dateadd(month, -3, getdate())

select co.organization_code, oraPOS.customer_number, sku, w.week_end_date, sum(cast(qty as int)) qty
into #oraPOSSummary
from openquery ([oracle prd], 'select * from APPS.XXPWC_POS_DATA_V') oraPOS
join CompanyOrganization co on oraPOS.company = co.company_code
join WeekCalendar w on cast(oraPOS.pos_date as datetime) between w.week_start_date AND w.week_end_date
where cast(oraPOS.pos_date as datetime) >= @cutoffDate
and oraPOS.customer_number in ('1000', '1064')
and oraPOS.sku is not null
group by co.organization_code, oraPOS.customer_number, sku, w.week_end_date

insert POS
select organization_code, customer_number, sku, week_end_date, qty
from #oraPOSSummary
where not exists (select 1 from POS where #oraPOSSummary.organization_code = POS.company_code 
					and #oraPOSSummary.customer_number = POS.customer_number
					and #oraPOSSummary.sku = POS.item_number
					and #oraPOSSummary.week_end_date = POS.week_end_date)
print 'Rows inserted: ' + cast(@@rowcount as varchar)

update POS
set quantity = #oraPOSSummary.qty
from POS
join #oraPOSSummary
on POS.company_code = #oraPOSSummary.organization_code
and POS.customer_number = #oraPOSSummary.customer_number
and POS.item_number = #oraPOSSummary.sku
and POS.week_end_date = #oraPOSSummary.week_end_date
and POS.quantity <> #oraPOSSummary.qty
print 'Rows updated: ' + cast(@@rowcount as varchar)

delete POS
where week_end_date < @cutoffDate
print 'Rows deleted: ' + cast(@@rowcount as varchar)

drop table #oraPOSSummary

dbcc dbreindex(POS)
