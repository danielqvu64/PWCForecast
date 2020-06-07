CREATE PROCEDURE [dbo].[utlCopyDiscontinuedItems]
AS

insert item (item_number)
select distinct item_number from DiscontinuedItemsBcp d
where not exists (select 1 from item i where i.item_number = d.item_number)

DBCC DBREINDEX(item)

truncate table BonusAndDiscontinuedByCompany

insert BonusAndDiscontinuedByCompany
	(company_code, item_number, discontinued_effective_date)
select
	co.organization_code, d.item_number, d.discontinue_date
from DiscontinuedItemsBcp d
join CompanyOrganization co on d.co_code = co.company_code
where d.customer_number = ''

truncate table BonusAndDiscontinuedByCustomer

insert BonusAndDiscontinuedByCustomer
	(company_code, customer_number, item_number, discontinued_effective_date)
select
	co.organization_code, d.customer_number, d.item_number, d.discontinue_date
from DiscontinuedItemsBcp d
join CompanyOrganization co on d.co_code = co.company_code
where d.customer_number <> ''

select * from DiscontinuedItemsBcp where co_code not in (select company_code from CompanyOrganization)

select count(1) from DiscontinuedItemsBcp where co_code not in (select company_code from CompanyOrganization)
select count(1) from BonusAndDiscontinuedByCompany
select count(1) from BonusAndDiscontinuedByCustomer
select count(1) from DiscontinuedItemsBcp

DBCC DBREINDEX(BonusAndDiscontinuedByCompany)
DBCC DBREINDEX(BonusAndDiscontinuedByCustomer)
