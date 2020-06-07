drop proc [utlUpdateActualSalesFromOracle]
go
create procedure [dbo].[utlUpdateActualSalesFromOracle]
as

declare @cutoffDate datetime
select @cutoffDate = dateadd(year, -2, getdate())

select oraActualSales.company_code, oraActualSales.customer_number, oraActualSales.item_number, oraActualSales.[month], cast(oraActualSales.quantity as int) quantity
into #allBut803
from openquery([Oracle PRD], 'SELECT company_code, customer_number, SUBSTR(item, 1, 11) item_number, TO_DATE(CAST(booking_month AS VARCHAR2(2)) || ''/01/'' || CAST(booking_year AS VARCHAR2(2)), ''MM/DD/YY'') month, SUM(monthly_sales) quantity FROM APPS.XXPWC_MONTHLY_SHIPMENTS_V WHERE company_code <> ''803'' GROUP BY company_code, customer_number, SUBSTR(item, 1, 11), booking_year, booking_month') oraActualSales
where oraActualSales.[month] >= @cutoffDate

create table #actualSales ( company_code char(3), customer_number varchar(10), item_number varchar(15), [month] datetime, quantity int)

-- company 001 start
insert #actualSales
select company_code, 'ZZZZ' customer_number, item_number, [month], sum(quantity) quantity
from #allBut803
where company_code = '001'
and customer_number not in ('1000', '1064', '1118', '1197', '1226', '1264', '1278', '1335', '9165', '1367', '91118')
group by company_code, item_number, [month]

insert #actualSales
select * from #allBut803
where company_code = '001'
and customer_number in ('1000', '1064', '1118', '1197', '1226', '1264', '1278')

insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select company_code, '1335', item_number, [month], sum(quantity)
from #allBut803
where company_code = '001'
and customer_number in ('1335', '9165')
group by company_code, item_number, [month]

insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select company_code, '1367', item_number, [month], sum(quantity)
from #allBut803
where company_code = '001'
and customer_number in ('1367', '91118')
group by company_code, item_number, [month]
-- company 001 end

-- company 002 start
insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select company_code, 'ZZZZ' customer_number, item_number, [month], sum(quantity) quantity
from #allBut803
where company_code = '002'
and customer_number not in ('1682', '1542')
group by company_code, item_number, [month]

insert #actualSales
select * from #allBut803
where company_code = '002'
and customer_number in ('1682', '1542')
-- company 002 end

-- company 301 start
insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select company_code, 'ZZZZ' customer_number, item_number, [month], sum(quantity) quantity
from #allBut803
where company_code = '301'
group by company_code, item_number, [month]
-- company 301 end

-- company 701 start
insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select company_code, 'ZZZZ' customer_number, item_number, [month], sum(quantity) quantity
from #allBut803
where company_code = '701'
group by company_code, item_number, [month]
-- company 701 end

-- company 801 start
insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select company_code, 'ZZZZ' customer_number, item_number, [month], sum(quantity) quantity
from #allBut803
where company_code = '801'
group by company_code, item_number, [month]
-- company 801 end

-- company 803 start
insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select '803' company_code, oraActualSales.customer_number + '-D' customer_number, oraActualSales.item_number, oraActualSales.[month], cast(oraActualSales.quantity as int) quantity
from openquery([Oracle PRD], 'SELECT company_code, customer_number, SUBSTR(item, 1, 11) item_number, TO_DATE(CAST(booking_month AS VARCHAR2(2)) || ''/01/'' || CAST(booking_year AS VARCHAR2(2)), ''MM/DD/YY'') month, SUM(monthly_sales) quantity FROM APPS.XXPWC_MONTHLY_SHIPMENTS_803_V WHERE company_code = ''803'' AND organization_divisions = ''803: Swiss - Domestic'' GROUP BY company_code, customer_number, SUBSTR(item, 1, 11), booking_year, booking_month') oraActualSales
where oraActualSales.[month] >= @cutoffDate

insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select '803' company_code, oraActualSales.customer_number + '-E' customer_number, oraActualSales.item_number, oraActualSales.[month], cast(oraActualSales.quantity as int) quantity
from openquery([Oracle PRD], 'SELECT company_code, customer_number, SUBSTR(item, 1, 11) item_number, TO_DATE(CAST(booking_month AS VARCHAR2(2)) || ''/01/'' || CAST(booking_year AS VARCHAR2(2)), ''MM/DD/YY'') month, SUM(monthly_sales) quantity FROM APPS.XXPWC_MONTHLY_SHIPMENTS_803_V WHERE company_code = ''803'' AND organization_divisions = ''803: Swiss - Export'' GROUP BY company_code, customer_number, SUBSTR(item, 1, 11), booking_year, booking_month') oraActualSales
where oraActualSales.[month] >= @cutoffDate
-- company 803 end

-- company 805 start
insert #actualSales (company_code, customer_number, item_number, [month], quantity)
select '805' company_code, oraActualSales.customer_number, oraActualSales.item_number, oraActualSales.[month], cast(oraActualSales.quantity as int) quantity
from openquery([Oracle PRD], 'SELECT company_code, customer_number, SUBSTR(item, 1, 11) item_number, TO_DATE(CAST(booking_month AS VARCHAR2(2)) || ''/01/'' || CAST(booking_year AS VARCHAR2(2)), ''MM/DD/YY'') month, SUM(monthly_sales) quantity FROM APPS.XXPWC_MONTHLY_SHIPMENTS_803_V WHERE company_code = ''803'' AND organization_divisions = ''805: Germany'' GROUP BY company_code, customer_number, SUBSTR(item, 1, 11), booking_year, booking_month') oraActualSales
where oraActualSales.[month] >= @cutoffDate
-- company 805 end

insert ActualSales
select *
from #actualSales
where not exists (select 1 from ActualSales where #actualSales.company_code = ActualSales.company_code
				and #actualSales.customer_number = ActualSales.customer_number
				and #actualSales.item_number = ActualSales.item_number
				and #actualSales.[month] = ActualSales.[month])
print 'Rows inserted: ' + cast(@@rowcount as varchar)

update ActualSales
set quantity = t.quantity
from #actualSales t
join ActualSales s
on t.company_code = s.company_code
and t.customer_number = s.customer_number
and t.item_number = s.item_number
and t.[month] = s.[month]
and t.quantity <> s.quantity
print 'Rows updated: ' + cast(@@rowcount as varchar)

delete ActualSales
where [month] < @cutoffDate
print 'Rows deleted: ' + cast(@@rowcount as varchar)

drop table #actualSales
drop table #allBut803

dbcc dbreindex(ActualSales)
go
