CREATE PROCEDURE [dbo].[posCollection_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)
	, @week_end_date datetime
AS

SET NOCOUNT ON

SELECT	company_code, customer_number, item_number, week_end_date, quantity
FROM	POS
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	item_number = @item_number
AND week_end_date = @week_end_date


