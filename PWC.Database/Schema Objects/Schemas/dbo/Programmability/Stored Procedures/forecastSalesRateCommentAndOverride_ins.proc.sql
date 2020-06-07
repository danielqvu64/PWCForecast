
CREATE PROCEDURE [dbo].[forecastSalesRateCommentAndOverride_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)
	, @pos_sales_end_date datetime
	, @date_time datetime
	, @comment varchar(255)
	, @manual_flag bit
AS

SET NOCOUNT ON
INSERT INTO ForecastSalesRateCommentAndOverride
           ( company_code
           , customer_number
           , item_number
           , pos_sales_end_date
           , date_time
           , comment
           , manual_flag)
     VALUES
           ( @company_code
           , @customer_number
           , @item_number
           , @pos_sales_end_date
           , @date_time
           , @comment
           , @manual_flag)

SELECT	@company_code + '|' + @customer_number + '|' + @item_number + '|' + CONVERT(varchar, @pos_sales_end_date, 101) + '|' + CONVERT(varchar, @date_time, 101)

