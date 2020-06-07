CREATE PROCEDURE [dbo].[actualSalesCollection_sel]
	@objectKey xml
	, @begin_date datetime
	, @end_date datetime
AS
SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')

SELECT	s.company_code, s.customer_number, s.item_number, s.[month], s.quantity
FROM	ActualSales s
WHERE	s.company_code = @company_code
AND	s.customer_number = @customer_number
AND	s.[month] BETWEEN @begin_date AND @end_date
ORDER BY 1, 2, 3, 4
