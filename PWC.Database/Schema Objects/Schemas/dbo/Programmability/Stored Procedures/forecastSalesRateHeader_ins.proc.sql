

CREATE PROCEDURE [dbo].[forecastSalesRateHeader_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
	, @pos_number_of_weeks int
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

INSERT	ForecastSalesRateHeader
	( company_code
	, customer_number
	, pos_sales_end_date
	, pos_number_of_weeks)
VALUES
	( @company_code
	, @customer_number
	, @pos_sales_end_date
	, @pos_number_of_weeks)

SELECT	@timestamp = timestamp
FROM	ForecastSalesRateHeader
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	pos_sales_end_date = @pos_sales_end_date

SELECT	@company_code + '|' + @customer_number + '|' + CONVERT(varchar, @pos_sales_end_date, 101)


