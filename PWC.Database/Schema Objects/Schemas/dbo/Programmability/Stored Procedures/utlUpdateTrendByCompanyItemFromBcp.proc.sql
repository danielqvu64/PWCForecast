CREATE PROCEDURE [dbo].[utlUpdateTrendByCompanyItemFromBcp]
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
	, @errorProcedure = 'utlUpdateTrendByCompanyItemFromBcp'
	, @rowBackedUp = 0
	, @duplicateRowDeleted = 0
	, @rowInserted = 0

BEGIN TRY
	BEGIN TRANSACTION
	IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'ForecastTrendByCompanyItemPriorToImport') AND type = N'U')
		DROP TABLE ForecastTrendByCompanyItemPriorToImport

	SELECT	*
	INTO	ForecastTrendByCompanyItemPriorToImport
	FROM	ForecastTrendByCompanyItem

	SELECT	@rowBackedUp = @@ROWCOUNT

	DELETE	ForecastTrendByCompanyItem
	FROM	ForecastTrendByCompanyItem a
	JOIN	ForecastTrendByCompanyItemBcp b
		ON	a.company_code = b.company_code
		AND	a.item_number = b.item_number
		AND	a.forecast_method = b.forecast_method

	SELECT	@duplicateRowDeleted = @@ROWCOUNT

	INSERT	ForecastTrendByCompanyItem
		( company_code
		, item_number
		, forecast_method 
		, factor_month_01 
		, factor_month_02 
		, factor_month_03 
		, factor_month_04 
		, factor_month_05 
		, factor_month_06 
		, factor_month_07 
		, factor_month_08 
		, factor_month_09 
		, factor_month_10 
		, factor_month_11 
		, factor_month_12 )
	SELECT
		  company_code
		, item_number
		, forecast_method 
		, factor_month_01 
		, factor_month_02 
		, factor_month_03 
		, factor_month_04 
		, factor_month_05 
		, factor_month_06 
		, factor_month_07 
		, factor_month_08 
		, factor_month_09 
		, factor_month_10 
		, factor_month_11 
		, factor_month_12 
	FROM ForecastTrendByCompanyItemBcp

	SELECT	@rowInserted = @@ROWCOUNT
	COMMIT TRANSACTION

	DBCC DBREINDEX(ForecastTrendByCompanyItem)
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
