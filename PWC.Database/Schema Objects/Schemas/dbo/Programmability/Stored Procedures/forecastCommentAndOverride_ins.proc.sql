
CREATE PROCEDURE [dbo].[forecastCommentAndOverride_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @pos_sales_end_date datetime
	, @item_number varchar(11)
	, @forecast_method varchar(2)
	, @forecast_value_key varchar(4)
	, @date_time datetime
	, @comment varchar(255)
	, @manual_flag bit
AS

SET NOCOUNT ON
INSERT INTO ForecastCommentAndOverride
           ( company_code
           , customer_number
           , pos_sales_end_date
           , item_number
           , forecast_method
           , forecast_value_key
           , date_time
           , comment
           , manual_flag)
     VALUES
           ( @company_code
           , @customer_number
           , @pos_sales_end_date
           , @item_number
           , @forecast_method
           , @forecast_value_key
           , @date_time
           , @comment
           , @manual_flag)

SELECT	@company_code + '|' + @customer_number + '|' + CONVERT(varchar, @pos_sales_end_date, 101) + '|' + @item_number + '|' + @forecast_method + '|' + @forecast_value_key + '|' + CONVERT(varchar, @date_time, 101)

