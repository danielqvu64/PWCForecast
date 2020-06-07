

CREATE PROCEDURE [dbo].[forecastHeader_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

INSERT	ForecastHeader
	( company_code
	, customer_number
	, pos_sales_end_date)
VALUES
	( @company_code
	, @customer_number
	, @pos_sales_end_date)

SELECT	@timestamp = timestamp
FROM	ForecastHeader
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date = @pos_sales_end_date

SELECT	@company_code + '|' + @customer_number + '|' + CONVERT(varchar, @pos_sales_end_date, 101)


