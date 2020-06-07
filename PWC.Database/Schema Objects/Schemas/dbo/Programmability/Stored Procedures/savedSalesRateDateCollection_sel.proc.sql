CREATE PROCEDURE [dbo].[savedSalesRateDateCollection_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @row_count bigint = 12
AS

SET NOCOUNT ON

SELECT DISTINCT TOP (@row_count) pos_sales_end_date POSSalesEndDate
FROM ForecastSalesRate
WHERE company_code = @company_code
AND customer_number = @customer_number
ORDER BY 1 DESC
