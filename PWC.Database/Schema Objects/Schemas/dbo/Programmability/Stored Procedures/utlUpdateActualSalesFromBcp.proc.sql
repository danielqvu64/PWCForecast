CREATE PROCEDURE [dbo].[utlUpdateActualSalesFromBcp]
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
	, @errorProcedure = 'utlUpdateActualSalesFromBcp'
	, @rowBackedUp = 0
	, @duplicateRowDeleted = 0
	, @rowInserted = 0

BEGIN TRY
	SELECT	company_code, customer_number, LEFT(item_number, 11) item_number, CAST([month] + '-01-' + [year] AS datetime) [month], SUM(CAST(quantity AS int)) quantity
	INTO	#sales
	FROM	ActualSalesBcp
	GROUP BY company_code, customer_number, LEFT(item_number, 11), [year], [month]
	
	BEGIN TRANSACTION
	IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'ActualSalesPriorToImport') AND type = N'U')
		DROP TABLE ActualSalesPriorToImport

	SELECT	*
	INTO	ActualSalesPriorToImport
	FROM	ActualSales

	SELECT	@rowBackedUp = @@ROWCOUNT

	DELETE	ActualSales
	FROM	ActualSales a
	JOIN	#sales b
		ON	a.company_code = b.company_code
		AND	a.customer_number = b.customer_number
		AND	a.item_number = b.item_number
		AND	a.[month] = b.[month]

	SELECT	@duplicateRowDeleted = @@ROWCOUNT

	INSERT	ActualSales
	SELECT	company_code, customer_number, item_number, [month], quantity
	FROM	#sales
	
	SELECT	@rowInserted = @@ROWCOUNT
	COMMIT TRANSACTION

	DBCC DBREINDEX(ActualSales)
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

DROP TABLE #sales

SELECT @errorNumber errorNumber
	, @errorMessage errorMessage
	, @errorSeverity errorSeverity
	, @errorState errorState
	, @errorLine errorLine
	, @errorProcedure errorProcedure
	, @rowBackedUp rowBackedUp
	, @duplicateRowDeleted duplicateRowDeleted
	, @rowInserted rowInserted
