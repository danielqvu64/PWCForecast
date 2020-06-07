CREATE PROCEDURE [dbo].[doesForecastExist_sel]
	@company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
AS

SET NOCOUNT ON

IF EXISTS (
	SELECT	1
	FROM	Forecast
	WHERE	company_code = @company_code
	AND	customer_number = @customer_number
	AND	pos_sales_end_date = @pos_sales_end_date )
	SELECT	1
ELSE
	SELECT	0
