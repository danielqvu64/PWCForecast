CREATE PROCEDURE [dbo].[utlUpdatePOSFromACNeilsenBcp]
	@company_code varchar(3)
	, @customer_number varchar(10)
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
	, @itemSuffix char(3)

SELECT @errorNumber = 0
	, @errorMessage = ''
	, @errorSeverity = 0
	, @errorState = 0
	, @errorLine = 0
	, @errorProcedure = 'utlUpdatePOSFromACNeilsenBcp'
	, @rowBackedUp = 0
	, @duplicateRowDeleted = 0
	, @rowInserted = 0

SELECT @itemSuffix = ISNULL(item_suffix, '-00')
FROM	Company
WHERE	company_code = @company_code

BEGIN TRY
	DECLARE @date1 datetime
		, @date2 datetime
		, @date3 datetime
		, @date4 datetime
		, @date5 datetime
		
	SELECT @date1 = CAST(RIGHT(Column3, 8) AS datetime)
		, @date2 = CAST(RIGHT(Column4, 8) AS datetime)
		, @date3 = CAST(RIGHT(Column5, 8) AS datetime)
		, @date4 = CAST(RIGHT(Column6, 8) AS datetime)
		, @date5 = CAST(RIGHT(Column7, 8) AS datetime)
	FROM ACNeilsenPOSBcp
	WHERE Column2 = 'UNIVERSAL PROD CODE'

	CREATE TABLE #tempPOS
		( item_number varchar(11)
		, pos_date datetime
		, quantity int )

	DECLARE @Column2 nvarchar(50)
		, @Column3 nvarchar(50)
		, @Column4 nvarchar(50)
		, @Column5 nvarchar(50)
		, @Column6 nvarchar(50)
		, @Column7 nvarchar(50)

	--select @date1, @date2, @date3, @date4, @date5

	DECLARE cursorPOS CURSOR FAST_FORWARD FOR
	SELECT Column2, Column3, Column4, Column5, Column6, Column7
	FROM ACNeilsenPOSBcp
	WHERE Column2 <> 'UNIVERSAL PROD CODE'
	AND Column2 > '!'

	OPEN cursorPOS
	FETCH NEXT FROM cursorPOS INTO @Column2, @Column3, @Column4, @Column5, @Column6, @Column7
	WHILE (@@fetch_status <> -1) BEGIN
		IF (@@fetch_status <> -2) BEGIN
			IF @Column3 > '!'
				INSERT #tempPOS
				SELECT '01-' + RIGHT(@Column2, 5) + @itemSuffix, @date1, CAST(@Column3 AS int)
			IF @Column4 > '!'
				INSERT #tempPOS
				SELECT '01-' + RIGHT(@Column2, 5) + @itemSuffix, @date2, CAST(@Column4 AS int)
			IF @Column5 > '!'
				INSERT #tempPOS
				SELECT '01-' + RIGHT(@Column2, 5) + @itemSuffix, @date3, CAST(@Column5 AS int)
			IF @Column6 > '!'
				INSERT #tempPOS
				SELECT '01-' + RIGHT(@Column2, 5) + @itemSuffix, @date4, CAST(@Column6 AS int)
			IF @Column7 > '!'
				INSERT #tempPOS
				SELECT '01-' + RIGHT(@Column2, 5) + @itemSuffix, @date5, CAST(@Column7 AS int)

		END
		FETCH NEXT FROM cursorPOS INTO @Column2, @Column3, @Column4, @Column5, @Column6, @Column7
	END

	CLOSE cursorPOS
	DEALLOCATE cursorPOS

	SELECT @company_code company_code
		, @customer_number customer_number
		, item_number
		, w.week_end_date
		, SUM(quantity) quantity
	INTO #newPOS
	FROM #tempPOS
	JOIN WeekCalendar w
		ON	pos_date BETWEEN w.week_start_date AND w.week_end_date
	GROUP BY item_number, w.week_end_date
	ORDER BY 1, 2, 3, 4

	--select * from #tempPOS
	--select * from #newPOS

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

	DROP TABLE #tempPOS
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
