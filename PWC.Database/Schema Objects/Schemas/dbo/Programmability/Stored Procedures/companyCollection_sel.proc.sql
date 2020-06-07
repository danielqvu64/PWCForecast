CREATE PROCEDURE [dbo].[companyCollection_sel]
	@company_code varchar(3)
AS

SET NOCOUNT ON
SELECT	company_code, company_name
FROM	Company
WHERE	company_code = @company_code
ORDER BY 1
