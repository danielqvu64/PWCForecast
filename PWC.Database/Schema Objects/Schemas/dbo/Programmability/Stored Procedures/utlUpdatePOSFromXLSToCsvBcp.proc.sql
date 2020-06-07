
CREATE PROCEDURE [dbo].[utlUpdatePOSFromXLSToCsvBcp]
AS
SET NOCOUNT ON

DECLARE	@errorNumber int
	, @errorMessage varchar(255)
	, @errorSeverity int
	, @errorState int
	, @errorLine int
	, @errorProcedure varchar(255)

SELECT @errorNumber = 0
	, @errorMessage = ''
	, @errorSeverity = 0
	, @errorState = 0
	, @errorLine = 0
	, @errorProcedure = 'utlUpdatePOSFromXLSToCsvBcp'

BEGIN TRY
TRUNCATE TABLE POSXlsBcp

INSERT POSXlsBcp (F1, F2, F3, F4, F5)
SELECT F1, F2, F3, F4, F5 FROM POSXlsToCsvBcp

END TRY
BEGIN CATCH
	SELECT @errorNumber = ERROR_NUMBER()
	, @errorMessage = ERROR_MESSAGE()
	, @errorSeverity = ERROR_SEVERITY()
	, @errorState = ERROR_STATE()
	, @errorLine = ERROR_LINE()
	, @errorProcedure = ERROR_PROCEDURE()
	
	IF XACT_STATE() = -1 
		ROLLBACK TRAN; 
END CATCH

IF @errorNumber = 0
	EXEC utlUpdatePOSFromXLSBcp
ELSE
	SELECT @errorNumber errorNumber
		, @errorMessage errorMessage
		, @errorSeverity errorSeverity
		, @errorState errorState
		, @errorLine errorLine
		, @errorProcedure errorProcedure

