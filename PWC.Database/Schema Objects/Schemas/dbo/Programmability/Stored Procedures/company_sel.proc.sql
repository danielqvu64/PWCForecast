CREATE PROCEDURE [dbo].[company_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')

SELECT	company_code, company_name
FROM	Company
WHERE	company_code = @company_code
