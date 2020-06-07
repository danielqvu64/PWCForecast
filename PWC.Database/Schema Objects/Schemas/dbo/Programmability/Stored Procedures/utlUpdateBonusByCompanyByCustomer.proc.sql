CREATE PROCEDURE utlUpdateBonusByCompanyByCustomer
AS

declare @organization_code varchar(3)
	, @customer_number varchar(4)
	, @replacement_item_number varchar(11)
	, @start_date datetime
	, @end_date datetime

declare bonusCompanyCursor cursor fast_forward for
select co.organization_code
	, rib.replacement_item_number
	, rib.start_date
	, rib.end_date
from ReplacementItemsBcp rib
join CompanyOrganization co
on rib.co_code = co.company_code
where customer_number is null

open bonusCompanyCursor

fetch next from bonusCompanyCursor into
	@organization_code
	, @replacement_item_number
	, @start_date
	, @end_date

while @@fetch_status = 0 begin
	if not exists (select 1 from BonusAndDiscontinuedByCompany where company_code = @organization_code and item_number = @replacement_item_number)
		insert BonusAndDiscontinuedByCompany (company_code, item_number)
		values (@organization_code, @replacement_item_number)

	update BonusAndDiscontinuedByCompany
	set	  cy_01 = case when datepart(month, @start_date) =  1 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_01 end
		, cy_02 = case when datepart(month, @start_date) =  2 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_02 end
		, cy_03 = case when datepart(month, @start_date) =  3 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_03 end
		, cy_04 = case when datepart(month, @start_date) =  4 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_04 end
		, cy_05 = case when datepart(month, @start_date) =  5 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_05 end
		, cy_06 = case when datepart(month, @start_date) =  6 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_06 end
		, cy_07 = case when datepart(month, @start_date) =  7 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_07 end
		, cy_08 = case when datepart(month, @start_date) =  8 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_08 end
		, cy_09 = case when datepart(month, @start_date) =  9 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_09 end
		, cy_10 = case when datepart(month, @start_date) = 10 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_10 end
		, cy_11 = case when datepart(month, @start_date) = 11 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_11 end
		, cy_12 = case when datepart(month, @start_date) = 12 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_12 end
		, ny_01 = case when datepart(month, @start_date) =  1 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_01 end
		, ny_02 = case when datepart(month, @start_date) =  2 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_02 end
		, ny_03 = case when datepart(month, @start_date) =  3 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_03 end
		, ny_04 = case when datepart(month, @start_date) =  4 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_04 end
		, ny_05 = case when datepart(month, @start_date) =  5 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_05 end
		, ny_06 = case when datepart(month, @start_date) =  6 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_06 end
		, ny_07 = case when datepart(month, @start_date) =  7 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_07 end
		, ny_08 = case when datepart(month, @start_date) =  8 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_08 end
		, ny_09 = case when datepart(month, @start_date) =  9 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_09 end
		, ny_10 = case when datepart(month, @start_date) = 10 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_10 end
		, ny_11 = case when datepart(month, @start_date) = 11 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_11 end
		, ny_12 = case when datepart(month, @start_date) = 12 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_12 end
	where company_code = @organization_code
	and item_number = @replacement_item_number
	
	fetch next from bonusCompanyCursor into
		@organization_code
		, @replacement_item_number
		, @start_date
		, @end_date
end

close bonusCompanyCursor
deallocate bonusCompanyCursor

declare bonusCustomerCursor cursor fast_forward for
select co.organization_code
	, rib.customer_number
	, rib.replacement_item_number
	, rib.start_date
	, rib.end_date
from ReplacementItemsBcp rib
join CompanyOrganization co
on rib.co_code = co.company_code
where customer_number is not null

open bonusCustomerCursor

fetch next from bonusCustomerCursor into
	@organization_code
	, @customer_number
	, @replacement_item_number
	, @start_date
	, @end_date

while @@fetch_status = 0 begin
	if not exists (select 1 from BonusAndDiscontinuedByCustomer where company_code = @organization_code and customer_number = @customer_number and item_number = @replacement_item_number)
		insert BonusAndDiscontinuedByCustomer (company_code, customer_number, item_number)
		values (@organization_code, @customer_number, @replacement_item_number)

	update BonusAndDiscontinuedByCustomer
	set	  cy_01 = case when datepart(month, @start_date) =  1 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_01 end
		, cy_02 = case when datepart(month, @start_date) =  2 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_02 end
		, cy_03 = case when datepart(month, @start_date) =  3 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_03 end
		, cy_04 = case when datepart(month, @start_date) =  4 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_04 end
		, cy_05 = case when datepart(month, @start_date) =  5 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_05 end
		, cy_06 = case when datepart(month, @start_date) =  6 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_06 end
		, cy_07 = case when datepart(month, @start_date) =  7 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_07 end
		, cy_08 = case when datepart(month, @start_date) =  8 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_08 end
		, cy_09 = case when datepart(month, @start_date) =  9 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_09 end
		, cy_10 = case when datepart(month, @start_date) = 10 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_10 end
		, cy_11 = case when datepart(month, @start_date) = 11 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_11 end
		, cy_12 = case when datepart(month, @start_date) = 12 and datepart(year, @start_date) = 2008 then datediff(day, @start_date, @end_date) + 1 else cy_12 end
		, ny_01 = case when datepart(month, @start_date) =  1 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_01 end
		, ny_02 = case when datepart(month, @start_date) =  2 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_02 end
		, ny_03 = case when datepart(month, @start_date) =  3 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_03 end
		, ny_04 = case when datepart(month, @start_date) =  4 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_04 end
		, ny_05 = case when datepart(month, @start_date) =  5 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_05 end
		, ny_06 = case when datepart(month, @start_date) =  6 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_06 end
		, ny_07 = case when datepart(month, @start_date) =  7 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_07 end
		, ny_08 = case when datepart(month, @start_date) =  8 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_08 end
		, ny_09 = case when datepart(month, @start_date) =  9 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_09 end
		, ny_10 = case when datepart(month, @start_date) = 10 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_10 end
		, ny_11 = case when datepart(month, @start_date) = 11 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_11 end
		, ny_12 = case when datepart(month, @start_date) = 12 and datepart(year, @start_date) = 2009 then datediff(day, @start_date, @end_date) + 1 else ny_12 end
	where company_code = @organization_code
	and customer_number = @customer_number
	and item_number = @replacement_item_number
	
fetch next from bonusCustomerCursor into
	@organization_code
	, @customer_number
	, @replacement_item_number
	, @start_date
	, @end_date
end

close bonusCustomerCursor
deallocate bonusCustomerCursor

dbcc dbreindex(BonusAndDiscontinuedByCompany)
dbcc dbreindex(BonusAndDiscontinuedByCustomer)

-- validate BonusAndDiscontinuedByCompany
select distinct co.organization_code
	, rib.replacement_item_number
from ReplacementItemsBcp rib
join CompanyOrganization co
on rib.co_code = co.company_code
where customer_number is null

select * from BonusAndDiscontinuedByCompany
where right(item_number, 1) <> '0'

select * from BonusAndDiscontinuedByCompany
where discontinued_effective_date is null

-- validate BonusAndDiscontinuedByCustomer
select distinct co.organization_code
	, rib.customer_number
	, rib.replacement_item_number
from ReplacementItemsBcp rib
join CompanyOrganization co
on rib.co_code = co.company_code
where customer_number is not null

select * from BonusAndDiscontinuedByCustomer
where right(item_number, 1) <> '0'

select * from BonusAndDiscontinuedByCustomer
where discontinued_effective_date is null
