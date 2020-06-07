
CREATE PROCEDURE [dbo].[utlYearTransitionProcess]
AS
SET NOCOUNT ON

DECLARE	@errorNumber int
	, @errorMessage varchar(255)
	, @errorSeverity int
	, @errorState int
	, @errorLine int
	, @errorProcedure varchar(255)
	, @createdDate as varchar(10)

SELECT @errorNumber = 0
	, @errorMessage = ''
	, @errorSeverity = 0
	, @errorState = 0
	, @errorLine = 0
	, @errorProcedure = 'utlYearTransitionProcess'
	, @createdDate = cast(year(getdate()) AS varchar) + '-01-01'
	
SELECT company_code
	, customer_number
	, MAX(pos_sales_end_date) pos_sales_end_date
INTO #last_pos_sales_end_date
FROM Forecast
GROUP BY company_code, customer_number

BEGIN TRY
	BEGIN TRANSACTION

	UPDATE ForecastParameter
	SET pipeline_start = null
	WHERE pipeline_start like 'PY%'

	UPDATE ForecastParameter
	SET pipeline_end = null
	WHERE pipeline_end like 'PY%'

	UPDATE ForecastParameter
	SET pipeline_start = replace(pipeline_start, 'CY', 'PY')
	WHERE pipeline_start like 'CY%'

	UPDATE ForecastParameter
	SET pipeline_start = replace(pipeline_start, 'NY', 'CY')
	WHERE pipeline_start like 'NY%'

	UPDATE ForecastParameter
	SET pipeline_end = replace(pipeline_end, 'CY', 'PY')
	WHERE pipeline_end like 'CY%'

	UPDATE ForecastParameter
	SET pipeline_end = replace(pipeline_end, 'NY', 'CY')
	WHERE pipeline_end like 'NY%'

	UPDATE ForecastParameter
	SET pipeline_start = 'PY01'
	WHERE pipeline_start is null

	UPDATE ForecastParameter
	SET pipeline_end = 'PY01'
	WHERE pipeline_end is null

	UPDATE ForecastParameter
	SET   pl_pct_py_01 = pl_pct_cy_01
		, pl_pct_py_02 = pl_pct_cy_02
		, pl_pct_py_03 = pl_pct_cy_03
		, pl_pct_py_04 = pl_pct_cy_04
		, pl_pct_py_05 = pl_pct_cy_05
		, pl_pct_py_06 = pl_pct_cy_06
		, pl_pct_py_07 = pl_pct_cy_07
		, pl_pct_py_08 = pl_pct_cy_08
		, pl_pct_py_09 = pl_pct_cy_09
		, pl_pct_py_10 = pl_pct_cy_10
		, pl_pct_py_11 = pl_pct_cy_11
		, pl_pct_py_12 = pl_pct_cy_12

		, pl_pct_cy_01 = pl_pct_ny_01
		, pl_pct_cy_02 = pl_pct_ny_02
		, pl_pct_cy_03 = pl_pct_ny_03
		, pl_pct_cy_04 = pl_pct_ny_04
		, pl_pct_cy_05 = pl_pct_ny_05
		, pl_pct_cy_06 = pl_pct_ny_06
		, pl_pct_cy_07 = pl_pct_ny_07
		, pl_pct_cy_08 = pl_pct_ny_08
		, pl_pct_cy_09 = pl_pct_ny_09
		, pl_pct_cy_10 = pl_pct_ny_10
		, pl_pct_cy_11 = pl_pct_ny_11
		, pl_pct_cy_12 = pl_pct_ny_12

		, pl_pct_ny_01 = null
		, pl_pct_ny_02 = null
		, pl_pct_ny_03 = null
		, pl_pct_ny_04 = null
		, pl_pct_ny_05 = null
		, pl_pct_ny_06 = null
		, pl_pct_ny_07 = null
		, pl_pct_ny_08 = null
		, pl_pct_ny_09 = null
		, pl_pct_ny_10 = null
		, pl_pct_ny_11 = null
		, pl_pct_ny_12 = null

	UPDATE BonusAndDiscontinuedByCompany
	SET   py_01 = cy_01
		, py_02 = cy_02
		, py_03 = cy_03
		, py_04 = cy_04
		, py_05 = cy_05
		, py_06 = cy_06
		, py_07 = cy_07
		, py_08 = cy_08
		, py_09 = cy_09
		, py_10 = cy_10
		, py_11 = cy_11
		, py_12 = cy_12

		, cy_01 = ny_01
		, cy_02 = ny_02
		, cy_03 = ny_03
		, cy_04 = ny_04
		, cy_05 = ny_05
		, cy_06 = ny_06
		, cy_07 = ny_07
		, cy_08 = ny_08
		, cy_09 = ny_09
		, cy_10 = ny_10
		, cy_11 = ny_11
		, cy_12 = ny_12

		, ny_01 = null
		, ny_02 = null
		, ny_03 = null
		, ny_04 = null
		, ny_05 = null
		, ny_06 = null
		, ny_07 = null
		, ny_08 = null
		, ny_09 = null
		, ny_10 = null
		, ny_11 = null
		, ny_12 = null

	UPDATE BonusAndDiscontinuedByCustomer
	SET   py_01 = cy_01
		, py_02 = cy_02
		, py_03 = cy_03
		, py_04 = cy_04
		, py_05 = cy_05
		, py_06 = cy_06
		, py_07 = cy_07
		, py_08 = cy_08
		, py_09 = cy_09
		, py_10 = cy_10
		, py_11 = cy_11
		, py_12 = cy_12

		, cy_01 = ny_01
		, cy_02 = ny_02
		, cy_03 = ny_03
		, cy_04 = ny_04
		, cy_05 = ny_05
		, cy_06 = ny_06
		, cy_07 = ny_07
		, cy_08 = ny_08
		, cy_09 = ny_09
		, cy_10 = ny_10
		, cy_11 = ny_11
		, cy_12 = ny_12

		, ny_01 = null
		, ny_02 = null
		, ny_03 = null
		, ny_04 = null
		, ny_05 = null
		, ny_06 = null
		, ny_07 = null
		, ny_08 = null
		, ny_09 = null
		, ny_10 = null
		, ny_11 = null
		, ny_12 = null

	DELETE ForecastCommentAndOverride
	FROM ForecastCommentAndOverride f
	JOIN #last_pos_sales_end_date l
		ON  f.company_code = l.company_code
		AND f.customer_number = l.customer_number
		AND f.pos_sales_end_date = l.pos_sales_end_date
	WHERE f.forecast_value_key like 'PY%'

	UPDATE ForecastCommentAndOverride
	SET	forecast_value_key = replace(forecast_value_key, 'CY', 'PY')
	FROM ForecastCommentAndOverride f
	JOIN #last_pos_sales_end_date l
		ON  f.company_code = l.company_code
		AND f.customer_number = l.customer_number
		AND f.pos_sales_end_date = l.pos_sales_end_date
	WHERE f.forecast_value_key like 'CY%'
	
	UPDATE ForecastCommentAndOverride
	SET	forecast_value_key = replace(forecast_value_key, 'NY', 'CY')
	FROM ForecastCommentAndOverride f
	JOIN #last_pos_sales_end_date l
		ON  f.company_code = l.company_code
		AND f.customer_number = l.customer_number
		AND f.pos_sales_end_date = l.pos_sales_end_date
	WHERE f.forecast_value_key like 'NY%'
	
	UPDATE Forecast
	SET   created_date = @createdDate
		, py_01 = cy_01
		, py_02 = cy_02
		, py_03 = cy_03
		, py_04 = cy_04
		, py_05 = cy_05
		, py_06 = cy_06
		, py_07 = cy_07
		, py_08 = cy_08
		, py_09 = cy_09
		, py_10 = cy_10
		, py_11 = cy_11
		, py_12 = cy_12

		, cy_01 = ny_01
		, cy_02 = ny_02
		, cy_03 = ny_03
		, cy_04 = ny_04
		, cy_05 = ny_05
		, cy_06 = ny_06
		, cy_07 = ny_07
		, cy_08 = ny_08
		, cy_09 = ny_09
		, cy_10 = ny_10
		, cy_11 = ny_11
		, cy_12 = ny_12

		, ny_01 = null
		, ny_02 = null
		, ny_03 = null
		, ny_04 = null
		, ny_05 = null
		, ny_06 = null
		, ny_07 = null
		, ny_08 = null
		, ny_09 = null
		, ny_10 = null
		, ny_11 = null
		, ny_12 = null
	FROM Forecast f
	JOIN #last_pos_sales_end_date l
		ON  f.company_code = l.company_code
		AND f.customer_number = l.customer_number
		AND f.pos_sales_end_date = l.pos_sales_end_date
		
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT @errorNumber = ERROR_NUMBER()
		, @errorMessage = ERROR_MESSAGE()
		, @errorSeverity = ERROR_SEVERITY()
		, @errorState = ERROR_STATE()
		, @errorLine = ERROR_LINE()
		, @errorProcedure = ERROR_PROCEDURE()
	
	IF (XACT_STATE()) = -1 
		ROLLBACK TRAN

	RAISERROR ('Error Message Detail, Message: %s, Number: %d, Severity: %d, State: %d, Line#: %d, Proc: %s' -- Message text.
		, @errorSeverity -- Severity.
		, @errorState -- State.
		, @errorMessage
		, @errorNumber
		, @errorSeverity
		, @errorState
		, @errorLine
		, @errorProcedure)
END CATCH

DROP TABLE #last_pos_sales_end_date
