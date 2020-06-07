CREATE PROCEDURE [dbo].[utlUpdateTrendByCompanyProductGroupFromBcp]
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
	, @errorProcedure = 'utlUpdateTrendByCompanyProductGroupFromBcp'
	, @rowBackedUp = 0
	, @duplicateRowDeleted = 0
	, @rowInserted = 0

BEGIN TRY
	BEGIN TRANSACTION
	IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'ForecastTrendByCompanyProductGroupPriorToImport') AND type = N'U')
		DROP TABLE ForecastTrendByCompanyProductGroupPriorToImport

	SELECT	*
	INTO	ForecastTrendByCompanyProductGroupPriorToImport
	FROM	ForecastTrendByCompanyProductGroup

	SELECT	@rowBackedUp = @@ROWCOUNT

	DELETE	ForecastTrendByCompanyProductGroup
	FROM	ForecastTrendByCompanyProductGroup a
	JOIN	ForecastTrendByCompanyProductGroupBcp b
		ON	a.company_code = b.company_code
		AND	a.product_group_code = b.product_group_code
		AND	a.forecast_method = b.forecast_method

	SELECT	@duplicateRowDeleted = @@ROWCOUNT

	INSERT	ForecastTrendByCompanyProductGroup
		( company_code
		, product_group_code
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
		, product_group_code
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
	FROM ForecastTrendByCompanyProductGroupBcp

	SELECT	@rowInserted = @@ROWCOUNT
	COMMIT TRANSACTION

	DBCC DBREINDEX(ForecastTrendByCompanyProductGroup)
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
