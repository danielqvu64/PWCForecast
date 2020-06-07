CREATE PROCEDURE [dbo].[forecastTrendByCompanyItem_del]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @item_number varchar(11)
	, @forecast_method varchar(2)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')
	, @forecast_method = @objectKey.value('/ObjectKey[1]/@ForecastMethod', 'varchar(2)')

DELETE	ForecastTrendByCompanyItem
WHERE	company_code = @company_code
AND		item_number = @item_number
AND		forecast_method = @forecast_method
