CREATE PROCEDURE [dbo].[utlUpdatePOSFromBcp]
AS
SET NOCOUNT ON

DECLARE	@errorNumber int
	, @errorMessage varchar(255)
	, @errorSeverity int
	, @errorState int
	, @errorLine int
	, @errorProcedure varchar(255)
	, @rowBackedUp int
	, @duplicateRowDeleted int
	, @rowInserted int

SELECT @errorNumber = 0
	, @errorMessage = ''
	, @errorSeverity = 0
	, @errorState = 0
	, @errorLine = 0
	, @errorProcedure = 'utlUpdatePOSFromBcp'
	, @rowBackedUp = 0
	, @duplicateRowDeleted = 0
	, @rowInserted = 0

BEGIN TRY
	SELECT	co.organization_code company_code, p.customer_number, left(p.item_number, 11) item_number, w.week_end_date, SUM(CAST(p.quantity as int)) quantity
	INTO	#newPOS
	FROM	POSBcp p
	JOIN	WeekCalendar w
		ON CAST(p.pos_date AS datetime) BETWEEN w.week_start_date AND w.week_end_date
	JOIN CompanyOrganization co
		ON p.company_code = co.company_code
	WHERE P.customer_number in ('1000', '1064')
	GROUP BY co.organization_code, p.customer_number, left(p.item_number, 11), w.week_end_date
	ORDER BY 1, 2, 3, 4

	BEGIN TRANSACTION
	IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'POSPriorToImport') AND type = N'U')
		DROP TABLE POSPriorToImport

	SELECT	*
	INTO	POSPriorToImport
	FROM	POS

	SELECT	@rowBackedUp = @@ROWCOUNT

	DELETE	POS
	FROM	POS p
	JOIN	#newPOS n
		ON	p.company_code = n.company_code
		AND	p.customer_number = n.customer_number
		AND	p.item_number = n.item_number
		AND	p.week_end_date = n.week_end_date

	SELECT	@duplicateRowDeleted = @@ROWCOUNT

	INSERT	POS
	SELECT	company_code, customer_number, item_number, week_end_date, quantity
	FROM	#newPOS
	
	SELECT	@rowInserted = @@ROWCOUNT
	COMMIT TRANSACTION

	DROP TABLE #newPOS
	DBCC DBREINDEX(POS)
END TRY
BEGIN CATCH
	SELECT @errorNumber = ERROR_NUMBER()
	, @errorMessage = ERROR_MESSAGE()
	, @errorSeverity = ERROR_SEVERITY()
	, @errorState = ERROR_STATE()
	, @errorLine = ERROR_LINE()
	, @errorProcedure = ERROR_PROCEDURE()
	
	IF (XACT_STATE()) = -1 
		ROLLBACK TRAN; 
END CATCH

SELECT @errorNumber errorNumber
	, @errorMessage errorMessage
	, @errorSeverity errorSeverity
	, @errorState errorState
	, @errorLine errorLine
	, @errorProcedure errorProcedure
	, @rowBackedUp rowBackedUp
	, @duplicateRowDeleted duplicateRowDeleted
	, @rowInserted rowInserted
