
CREATE PROCEDURE [dbo].[utlUpdateItemFromBcp] 
AS
/*
insert item
select left(item_number, 11), item_description from itembcp
where left(item_number, 11) not in (select item_number from item)
*/
insert item (item_number)
select distinct left(itembcp.item_number, 11) from itembcp
where not exists (select 1 from item where item.item_number = left(itembcp.item_number, 11))

update item
set item_description = rtrim(ib.item_description)
from item i
join itembcp ib on i.item_number = left(ib.item_number, 11)

update item
set item_description = rtrim(item_description)

dbcc dbreindex(item)