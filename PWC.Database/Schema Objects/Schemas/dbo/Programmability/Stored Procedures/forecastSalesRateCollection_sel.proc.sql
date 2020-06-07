
CREATE PROCEDURE [dbo].[forecastSalesRateCollection_sel]
	@objectKey xml
	, @pos_number_of_weeks smallint
	, @pos_sales_end_date datetime
	, @forecast_sales_rate_action varchar(10)
	, @is_getting_previous_override bit
AS

SET NOCOUNT ON
DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @week_end_date_1 datetime
	, @week_end_date_2 datetime
	, @week_end_date_3 datetime
	, @week_end_date_4 datetime
	, @trend_month int

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')

IF @pos_number_of_weeks >= 1
	SET	@week_end_date_4 = @pos_sales_end_date
IF @pos_number_of_weeks >= 2
	SET	@week_end_date_3 = DATEADD(DAY, -7, @pos_sales_end_date)
IF @pos_number_of_weeks >= 3
	SET	@week_end_date_2 = DATEADD(DAY, -14, @pos_sales_end_date)
IF @pos_number_of_weeks = 4
	SET	@week_end_date_1 = DATEADD(DAY, -21, @pos_sales_end_date)

SET	@trend_month = DATEPART(MONTH, @pos_sales_end_date)

IF @forecast_sales_rate_action = 'get' BEGIN
	IF @is_getting_previous_override = 1
		SELECT @pos_sales_end_date = MAX(pos_sales_end_date)
		FROM	ForecastSalesRate
		WHERE	company_code = @company_code
		AND	customer_number = @customer_number
		AND	pos_sales_end_date <= @pos_sales_end_date

	SELECT	company_code
		, customer_number
		, pos_sales_end_date
		, item_number
		, trend_factor
		, pos_week_1_quantity
		, pos_week_2_quantity
		, pos_week_3_quantity
		, pos_week_4_quantity
		, store_count_existing
		, store_count_new
		, sales_rate
		, sales_rate_previous
		, CASE WHEN EXISTS (SELECT 1 FROM ForecastSalesrateCommentAndOverride WHERE company_code = ForecastSalesRate.company_code
																			AND customer_number = ForecastSalesRate.customer_number
																			AND item_number = ForecastSalesRate.item_number
																			AND pos_sales_end_date = ForecastSalesRate.pos_sales_end_date
																			AND comment IS NULL) THEN 1 ELSE 0 END has_override
		, CASE WHEN EXISTS (SELECT 1 FROM ForecastSalesrateCommentAndOverride WHERE company_code = ForecastSalesRate.company_code
																			AND customer_number = ForecastSalesRate.customer_number
																			AND item_number = ForecastSalesRate.item_number
																			AND pos_sales_end_date = ForecastSalesRate.pos_sales_end_date
																			AND comment IS NOT NULL) THEN 1 ELSE 0 END has_comment
		, timestamp
	FROM ForecastSalesRate
	WHERE company_code = @company_code
	AND	customer_number = @customer_number
	AND	pos_sales_end_date = @pos_sales_end_date
	AND (@is_getting_previous_override = 0 OR (@is_getting_previous_override = 1 AND EXISTS (SELECT 1 FROM ForecastSalesrateCommentAndOverride WHERE company_code = ForecastSalesRate.company_code
																			AND customer_number = ForecastSalesRate.customer_number
																			AND item_number = ForecastSalesRate.item_number
																			AND pos_sales_end_date = ForecastSalesRate.pos_sales_end_date)))
	ORDER BY 1, 2, 3, 4
END ELSE
	SELECT	param.company_code
		, param.customer_number
		, @pos_sales_end_date pos_sales_end_date
		, param.item_number
		, CASE @trend_month
			WHEN  1 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_01 ELSE trendCompanyItem.factor_month_01 END ELSE trendCustomerProductGroup.factor_month_01 END ELSE trendCustomerItem.factor_month_01 END
			WHEN  2 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_02 ELSE trendCompanyItem.factor_month_02 END ELSE trendCustomerProductGroup.factor_month_02 END ELSE trendCustomerItem.factor_month_02 END
			WHEN  3 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_03 ELSE trendCompanyItem.factor_month_03 END ELSE trendCustomerProductGroup.factor_month_03 END ELSE trendCustomerItem.factor_month_03 END
			WHEN  4 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_04 ELSE trendCompanyItem.factor_month_04 END ELSE trendCustomerProductGroup.factor_month_04 END ELSE trendCustomerItem.factor_month_04 END
			WHEN  5 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_05 ELSE trendCompanyItem.factor_month_05 END ELSE trendCustomerProductGroup.factor_month_05 END ELSE trendCustomerItem.factor_month_05 END
			WHEN  6 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_06 ELSE trendCompanyItem.factor_month_06 END ELSE trendCustomerProductGroup.factor_month_06 END ELSE trendCustomerItem.factor_month_06 END
			WHEN  7 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_07 ELSE trendCompanyItem.factor_month_07 END ELSE trendCustomerProductGroup.factor_month_07 END ELSE trendCustomerItem.factor_month_07 END
			WHEN  8 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_08 ELSE trendCompanyItem.factor_month_08 END ELSE trendCustomerProductGroup.factor_month_08 END ELSE trendCustomerItem.factor_month_08 END
			WHEN  9 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_09 ELSE trendCompanyItem.factor_month_09 END ELSE trendCustomerProductGroup.factor_month_09 END ELSE trendCustomerItem.factor_month_09 END
			WHEN 10 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_10 ELSE trendCompanyItem.factor_month_10 END ELSE trendCustomerProductGroup.factor_month_10 END ELSE trendCustomerItem.factor_month_10 END
			WHEN 11 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_11 ELSE trendCompanyItem.factor_month_11 END ELSE trendCustomerProductGroup.factor_month_11 END ELSE trendCustomerItem.factor_month_11 END
			WHEN 12 THEN CASE WHEN trendCustomerItem.item_number IS NULL THEN CASE WHEN trendCustomerProductGroup.product_group_code IS NULL THEN CASE WHEN trendCompanyItem.item_number IS NULL THEN trendCompanyProductGroup.factor_month_12 ELSE trendCompanyItem.factor_month_12 END ELSE trendCustomerProductGroup.factor_month_12 END ELSE trendCustomerItem.factor_month_12 END
		END trend_factor
		, POS1.quantity pos_week_1_quantity
		, POS2.quantity pos_week_2_quantity
		, POS3.quantity pos_week_3_quantity
		, POS4.quantity pos_week_4_quantity
		, param.store_count_existing
		, param.store_count_new
		, NULL sales_rate
		, (SELECT TOP 1 sales_rate
			FROM ForecastSalesRate rate
			WHERE rate.company_code = @company_code
			AND rate.customer_number = @customer_number
			AND	rate.item_number = param.item_number
			AND rate.pos_sales_end_date < @pos_sales_end_date
			ORDER BY rate.pos_sales_end_date DESC) sales_rate_previous
		, 0 has_override
		, 0 has_comment
		, NULL timestamp
	FROM ForecastParameter param
	JOIN Company
		ON param.company_code = company.company_code
	LEFT JOIN ForecastTrendByCompanyItem trendCompanyItem
		ON param.company_code = trendCompanyItem.company_code
		AND param.item_number = trendCompanyItem.item_number
		AND trendCompanyItem.forecast_method = 'SR'
	LEFT JOIN ForecastTrendByCustomerItem trendCustomerItem
		ON param.company_code = trendCustomerItem.company_code
		AND param.customer_number = trendCustomerItem.customer_number
		AND param.item_number = trendCustomerItem.item_number
		AND trendCustomerItem.forecast_method = 'SR'
	LEFT JOIN Item i
		ON param.item_number = i.item_number
	LEFT JOIN ForecastTrendByCompanyProductGroup trendCompanyProductGroup
		ON param.company_code = trendCompanyProductGroup.company_code
		AND i.product_group_code = trendCompanyProductGroup.product_group_code
		AND trendCompanyProductGroup.forecast_method = 'SR'
	LEFT JOIN ForecastTrendByCustomerProductGroup trendCustomerProductGroup
		ON param.company_code = trendCustomerProductGroup.company_code
		ANd param.customer_number = trendCustomerProductGroup.customer_number
		AND i.product_group_code = trendCustomerProductGroup.product_group_code
		AND trendCustomerProductGroup.forecast_method = 'SR'
	LEFT JOIN POS POS1
		ON param.company_code = POS1.company_code
		AND param.customer_number = POS1.customer_number
		AND param.item_number = POS1.item_number
		AND POS1.week_end_date = @week_end_date_1
	LEFT JOIN POS POS2
		ON param.company_code = POS2.company_code
		AND param.customer_number = POS2.customer_number
		AND param.item_number = POS2.item_number
		AND POS2.week_end_date = @week_end_date_2
	LEFT JOIN POS POS3
		ON param.company_code = POS3.company_code
		AND param.customer_number = POS3.customer_number
		AND param.item_number = POS3.item_number
		AND POS3.week_end_date = @week_end_date_3
	LEFT JOIN POS POS4
		ON param.company_code = POS4.company_code
		AND param.customer_number = POS4.customer_number
		AND param.item_number = POS4.item_number
		AND POS4.week_end_date = @week_end_date_4
	WHERE param.company_code = @company_code
	AND param.customer_number = @customer_number
	ORDER BY 1, 2, 3, 4

