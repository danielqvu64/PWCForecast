CREATE PROCEDURE [dbo].[forecastSalesRateCollection_GenAndSave]
	@objectKey xml
	, @pos_number_of_weeks smallint
	, @pos_sales_end_date datetime
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

IF NOT EXISTS (SELECT 1 FROM ForecastSalesRate WHERE company_code = @company_code AND customer_number = @customer_number AND pos_sales_end_date = @pos_sales_end_date)
INSERT	ForecastSalesRate
SELECT	param.company_code
	, param.customer_number
	, @pos_sales_end_date pos_sales_end_date
	, param.item_number
	, @pos_number_of_weeks pos_number_of_weeks
	, CASE @trend_month
		WHEN 1 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_01 ELSE trendProductGroup.factor_month_01 END ELSE trendCustomer.factor_month_01 END
		WHEN 2 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_02 ELSE trendProductGroup.factor_month_02 END ELSE trendCustomer.factor_month_02 END
		WHEN 3 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_03 ELSE trendProductGroup.factor_month_03 END ELSE trendCustomer.factor_month_03 END
		WHEN 4 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_04 ELSE trendProductGroup.factor_month_04 END ELSE trendCustomer.factor_month_04 END
		WHEN 5 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_05 ELSE trendProductGroup.factor_month_05 END ELSE trendCustomer.factor_month_05 END
		WHEN 6 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_06 ELSE trendProductGroup.factor_month_06 END ELSE trendCustomer.factor_month_06 END
		WHEN 7 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_07 ELSE trendProductGroup.factor_month_07 END ELSE trendCustomer.factor_month_07 END
		WHEN 8 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_08 ELSE trendProductGroup.factor_month_08 END ELSE trendCustomer.factor_month_08 END
		WHEN 9 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_09 ELSE trendProductGroup.factor_month_09 END ELSE trendCustomer.factor_month_09 END
		WHEN 10 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_10 ELSE trendProductGroup.factor_month_10 END ELSE trendCustomer.factor_month_10 END
		WHEN 11 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_11 ELSE trendProductGroup.factor_month_11 END ELSE trendCustomer.factor_month_11 END
		WHEN 12 THEN CASE WHEN trendCustomer.item_number IS NULL THEN CASE WHEN trendProductGroup.product_group_code IS NULL THEN trendCompany.factor_month_12 ELSE trendProductGroup.factor_month_12 END ELSE trendCustomer.factor_month_12 END
		/*
		WHEN 1 THEN ISNULL(ISNULL(trendCustomer.factor_month_01, trendProductGroup.factor_month_01), trendCompany.factor_month_01)
		WHEN 2 THEN ISNULL(ISNULL(trendCustomer.factor_month_02, trendProductGroup.factor_month_02), trendCompany.factor_month_02)
		WHEN 3 THEN ISNULL(ISNULL(trendCustomer.factor_month_03, trendProductGroup.factor_month_03), trendCompany.factor_month_03)
		WHEN 4 THEN ISNULL(ISNULL(trendCustomer.factor_month_04, trendProductGroup.factor_month_04), trendCompany.factor_month_04)
		WHEN 5 THEN ISNULL(ISNULL(trendCustomer.factor_month_05, trendProductGroup.factor_month_05), trendCompany.factor_month_05)
		WHEN 6 THEN ISNULL(ISNULL(trendCustomer.factor_month_06, trendProductGroup.factor_month_06), trendCompany.factor_month_06)
		WHEN 7 THEN ISNULL(ISNULL(trendCustomer.factor_month_07, trendProductGroup.factor_month_07), trendCompany.factor_month_07)
		WHEN 8 THEN ISNULL(ISNULL(trendCustomer.factor_month_08, trendProductGroup.factor_month_08), trendCompany.factor_month_08)
		WHEN 9 THEN ISNULL(ISNULL(trendCustomer.factor_month_09, trendProductGroup.factor_month_09), trendCompany.factor_month_09)
		WHEN 10 THEN ISNULL(ISNULL(trendCustomer.factor_month_10, trendProductGroup.factor_month_10), trendCompany.factor_month_10)
		WHEN 11 THEN ISNULL(ISNULL(trendCustomer.factor_month_11, trendProductGroup.factor_month_11), trendCompany.factor_month_11)
		WHEN 12 THEN ISNULL(ISNULL(trendCustomer.factor_month_12, trendProductGroup.factor_month_12), trendCompany.factor_month_12)
		*/
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
	, NULL manual_flag
FROM ForecastParameter param
LEFT JOIN ForecastTrendByCompanyItem trendCompany
	ON param.company_code = trendCompany.company_code
	AND param.item_number = trendCompany.item_number
	AND trendCompany.forecast_method = 'SR'
LEFT JOIN ForecastTrendByCustomerItem trendCustomer
	ON param.company_code = trendCustomer.company_code
	AND param.customer_number = trendCustomer.customer_number
	AND param.item_number = trendCustomer.item_number
	AND trendCustomer.forecast_method = 'SR'
LEFT JOIN ProductGroupItem pi
	ON param.item_number = pi.item_number
LEFT JOIN ForecastTrendByCompanyProductGroup trendProductGroup
	ON pi.product_group_code = trendProductGroup.product_group_code
	AND trendProductGroup.forecast_method = 'SR'
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
