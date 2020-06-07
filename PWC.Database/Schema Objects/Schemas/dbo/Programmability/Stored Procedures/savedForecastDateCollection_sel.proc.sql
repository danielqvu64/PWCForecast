CREATE PROCEDURE [dbo].[savedForecastDateCollection_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @row_count bigint = 12
AS

SET NOCOUNT ON

SELECT DISTINCT TOP (@row_count) 
	f.pos_sales_end_date POSSalesEndDate
	, c.forecast_method ForecastMethod
FROM Forecast f
JOIN Customer c
	ON f.company_code = c.company_code
	AND f.customer_number = c.customer_number
WHERE f.company_code = @company_code
AND f.customer_number = ISNULL(@customer_number, f.customer_number)
AND c.forecast_method in ('SR', 'RA')
ORDER BY 1 DESC
