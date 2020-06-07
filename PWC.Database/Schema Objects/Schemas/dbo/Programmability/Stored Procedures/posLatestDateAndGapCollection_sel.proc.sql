CREATE PROCEDURE [dbo].posLatestDateAndGapCollection_sel
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @week_end_date datetime
	, @num_of_weeks smallint
AS

SET NOCOUNT ON

IF @num_of_weeks IS NULL
	SELECT @num_of_weeks = 4

CREATE TABLE #output (
	company_code varchar(3)
	, customer_number varchar(10)
	, latest_week_end_date datetime
	, num_of_weeks smallint
	, gap_flag bit )
	
IF @week_end_date IS NULL
	INSERT #output
	SELECT company_code, customer_number, max(week_end_date), @num_of_weeks, 0
	FROM POS
	WHERE company_code = @company_code
	AND customer_number = @customer_number
	GROUP BY company_code, customer_number
ELSE
	INSERT #output
	SELECT DISTINCT company_code, customer_number, @week_end_date, @num_of_weeks, 0
	FROM Customer
	WHERE company_code = @company_code
	AND customer_number = @customer_number

DECLARE @week_no smallint
SELECT @week_no = 0
WHILE @week_no < @num_of_weeks BEGIN
	UPDATE #output
	SET gap_flag = 1
	FROM #output
	WHERE NOT EXISTS (SELECT 1 FROM POS
					WHERE #output.company_code = pos.company_code
					AND #output.customer_number = pos.customer_number
					AND pos.week_end_date = DATEADD(DAY, -7 * @week_no, #output.latest_week_end_date))
	AND gap_flag = 0
	SELECT @week_no = @week_no + 1
END

SELECT * FROM #output

DROP TABLE #output
