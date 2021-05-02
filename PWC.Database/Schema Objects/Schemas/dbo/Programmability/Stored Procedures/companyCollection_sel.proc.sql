USE PWCForecast
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('companyCollection_sel', 'P'))
	DROP PROCEDURE companyCollection_sel
GO

CREATE PROCEDURE [dbo].[companyCollection_sel]
	@company_code varchar(3)
AS

SET NOCOUNT ON
SELECT	company_code, company_name
FROM	Company
WHERE	@company_code = '' OR company_code = @company_code
ORDER BY 1
GO
