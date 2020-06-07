CREATE PROCEDURE [dbo].actualSalesLatestDateAndGapCollection_sel
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @actual_sales_end_date datetime
	, @rolling_average_number_of_months tinyint
AS

SET NOCOUNT ON

IF @rolling_average_number_of_months IS NULL
	SELECT @rolling_average_number_of_months = 3

CREATE TABLE #output (
	company_code varchar(3)
	, customer_number varchar(10)
	, latest_actual_sales_end_date datetime
	, rolling_average_number_of_months tinyint
	, gap_flag bit )
	
IF @actual_sales_end_date IS NULL
	INSERT #output
	SELECT s.company_code, s.customer_number, MAX(s.[month]), @rolling_average_number_of_months, 0
	FROM ActualSales s
	JOIN ForecastParameter p
	ON	s.company_code = p.company_code
	AND	s.customer_number = p.customer_number
	AND	s.item_number = p.item_number
	WHERE s.company_code = @company_code
	AND s.customer_number = @customer_number
	GROUP BY s.company_code, s.customer_number
ELSE
	INSERT #output
	SELECT DISTINCT company_code, customer_number, @actual_sales_end_date, @rolling_average_number_of_months, 0
	FROM Customer
	WHERE company_code = @company_code
	AND customer_number = @customer_number

DECLARE @month_no tinyint
SELECT @month_no = 0
WHILE @month_no < @rolling_average_number_of_months BEGIN
	UPDATE #output
	SET gap_flag = 1
	FROM #output
	WHERE NOT EXISTS (SELECT 1
					FROM ActualSales s
					JOIN ForecastParameter p
					ON	s.company_code = p.company_code
					AND	s.customer_number = p.customer_number
					AND	s.item_number = p.item_number
					WHERE #output.company_code = s.company_code
					AND #output.customer_number = s.customer_number
					AND DATEPART(YEAR, s.[month]) = DATEPART(YEAR, DATEADD(MONTH, -@month_no, #output.latest_actual_sales_end_date))
					AND DATEPART(MONTH, s.[month]) = DATEPART(MONTH, DATEADD(MONTH, -@month_no, #output.latest_actual_sales_end_date)))
	AND gap_flag = 0
	SELECT @month_no = @month_no + 1
END

SELECT * FROM #output

DROP TABLE #output
