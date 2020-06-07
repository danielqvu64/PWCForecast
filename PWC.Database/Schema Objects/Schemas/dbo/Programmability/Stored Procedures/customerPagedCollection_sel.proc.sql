CREATE PROCEDURE [dbo].[customerPagedCollection_sel]
	@objectKey xml
	, @page_size int
	, @page_index int
	, @sorted_field varchar(50)
	, @sort_order varchar(10)
AS

SET NOCOUNT ON;

DECLARE @statement nvarchar(1000)
	, @param_definition nvarchar(100)
	, @company_code varchar(3)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
SELECT	@param_definition = N'@company_code as varchar(3), @page_size as int, @page_index as int'

SELECT @statement = N'WITH customers AS ( 
SELECT	ROW_NUMBER() OVER (ORDER BY {@sorted_field} {@sort_order}) AS row, company_code, customer_number, customer_name, distinct_forecast_name_flag, forecast_method, inflate_factor, forecast_future_frozen_months 
FROM	Customer
WHERE	company_code = @company_code)

SELECT company_code, customer_number, customer_name, distinct_forecast_name_flag, forecast_method, inflate_factor, forecast_future_frozen_months
FROM customers 
WHERE row between (@page_index - 1) * @page_size + 1 AND @page_index * @page_size
ORDER BY {@sorted_field} {@sort_order};'

SELECT @statement = REPLACE(@statement, '{@sorted_field}', @sorted_field)
SELECT @statement = REPLACE(@statement, '{@sort_order}', @sort_order)

--select @statement
EXEC dbo.sp_executesql @statement, @param_definition, @company_code = @company_code, @page_size = @page_size, @page_index = @page_index
