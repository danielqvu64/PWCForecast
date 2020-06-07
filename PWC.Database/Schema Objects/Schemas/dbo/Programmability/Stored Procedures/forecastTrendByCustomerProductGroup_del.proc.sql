CREATE PROCEDURE [dbo].[forecastTrendByCustomerProductGroup_del]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @product_group_code varchar(4)
	, @forecast_method varchar(2)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @product_group_code = @objectKey.value('/ObjectKey[1]/@ProductGroupCode', 'varchar(4)')
	, @forecast_method = @objectKey.value('/ObjectKey[1]/@ForecastMethod', 'varchar(2)')

DELETE	ForecastTrendByCustomerProductGroup
WHERE	company_code = @company_code
AND		customer_number = @customer_number
AND		product_group_code = @product_group_code
AND		forecast_method = @forecast_method
