CREATE PROCEDURE [dbo].[forecastReportCollection_sel]
	@company_code varchar(3)
	, @customer_number_from varchar(4)
	, @customer_number_to varchar(4)
	, @brand_code_from varchar(2)
	, @brand_code_to varchar(2)
	, @product_category_code_from varchar(2)
	, @product_category_code_to varchar(2)
	, @group_by varchar(10)
	, @forecast_methods varchar(10)
	, @forecast_year int
AS
SET NOCOUNT ON

DECLARE @start_date datetime
	, @end_date datetime

SELECT @start_date = '01/01/' + CAST(@forecast_year AS varchar)
	, @end_date = '12/31/' + CAST(@forecast_year AS varchar)

SELECT company_code, customer_number, MAX(pos_sales_end_date) pos_sales_end_date
INTO #posSalesEndDate
FROM Forecast f
WHERE company_code = @company_code
AND	((@customer_number_from IS NOT NULL AND f.customer_number >= @customer_number_from)
	OR @customer_number_from IS NULL)
AND	((@customer_number_to IS NOT NULL AND f.customer_number <= @customer_number_to)
	OR @customer_number_to IS NULL)
GROUP BY company_code, customer_number

CREATE TABLE #forecastReport
	( company_code varchar(3)
	, group_by varchar(10)
	, group_by_code varchar(11)
	, forecast_month_01_quantity int
	, forecast_month_02_quantity int
	, forecast_month_03_quantity int
	, forecast_month_04_quantity int
	, forecast_month_05_quantity int
	, forecast_month_06_quantity int
	, forecast_month_07_quantity int
	, forecast_month_08_quantity int
	, forecast_month_09_quantity int
	, forecast_month_10_quantity int
	, forecast_month_11_quantity int
	, forecast_month_12_quantity int )
	
INSERT #forecastReport	
SELECT f.company_code
	, @group_by group_by
	, CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE f.item_number END group_by_code
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_01, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_01, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_01, 0)) END forecast_month_01_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_02, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_02, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_02, 0)) END forecast_month_02_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_03, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_03, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_03, 0)) END forecast_month_03_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_04, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_04, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_04, 0)) END forecast_month_04_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_05, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_05, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_05, 0)) END forecast_month_05_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_06, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_06, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_06, 0)) END forecast_month_06_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_07, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_07, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_07, 0)) END forecast_month_07_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_08, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_08, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_08, 0)) END forecast_month_08_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_09, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_09, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_09, 0)) END forecast_month_09_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_10, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_10, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_10, 0)) END forecast_month_10_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_11, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_11, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_11, 0)) END forecast_month_11_quantity
	, CASE @forecast_year - AVG(DATEPART(YEAR, created_date))
	  WHEN -1 THEN SUM(ISNULL(py_12, 0))
	  WHEN  0 THEN SUM(ISNULL(cy_12, 0))
	  WHEN  1 THEN SUM(ISNULL(ny_12, 0)) END forecast_month_12_quantity
FROM Forecast f
JOIN #posSalesEndDate endDate
	ON f.company_code = endDate.company_code
	AND f.customer_number = endDate.customer_number
	AND f.pos_sales_end_date = endDate.pos_sales_end_date
JOIN Item i
	ON f.item_number = i.item_number
LEFT JOIN ProductGroup pg
	ON i.product_group_code = pg.product_group_code
WHERE f.company_code = @company_code
AND	((@customer_number_from IS NOT NULL AND f.customer_number >= @customer_number_from)
	OR @customer_number_from IS NULL)
AND	((@customer_number_to IS NOT NULL AND f.customer_number <= @customer_number_to)
	OR @customer_number_to IS NULL)
AND CHARINDEX(forecast_method, @forecast_methods) > 0
AND	((@brand_code_from IS NOT NULL AND pg.brand_code >= @brand_code_from)
	OR @brand_code_from IS NULL)
AND	((@brand_code_to IS NOT NULL AND pg.brand_code <= @brand_code_to)
	OR @brand_code_to IS NULL)
AND	((@product_category_code_from IS NOT NULL AND pg.product_category_code >= @product_category_code_from)
	OR @product_category_code_from IS NULL)
AND	((@product_category_code_to IS NOT NULL AND pg.product_category_code <= @product_category_code_to)
	OR @product_category_code_to IS NULL)
GROUP BY f.company_code, CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE f.item_number END

DROP TABLE #posSalesEndDate

CREATE TABLE #discontinuedItem
( company_code varchar(3)
, customer_number varchar(4)
, item_number varchar(11) )

INSERT #discontinuedItem
SELECT DISTINCT company_code, customer_number, di.item_number
FROM BonusAndDiscontinuedByCustomer di
WHERE company_code = @company_code
AND	((@customer_number_from IS NOT NULL AND di.customer_number >= @customer_number_from)
	OR @customer_number_from IS NULL)
AND	((@customer_number_to IS NOT NULL AND di.customer_number <= @customer_number_to)
	OR @customer_number_to IS NULL)
AND di.discontinued_effective_date <= @start_date

INSERT #discontinuedItem (company_code, item_number)
SELECT DISTINCT company_code, di.item_number
FROM BonusAndDiscontinuedByCompany di
WHERE di.company_code = @company_code
AND di.discontinued_effective_date <= @start_date
AND NOT EXISTS (SELECT 1 FROM #discontinuedItem
				WHERE #discontinuedItem.company_code = di.company_code
				AND #discontinuedItem.customer_number IS NULL
				AND #discontinuedItem.item_number = di.item_number)

INSERT #forecastReport
SELECT DISTINCT s.company_code
	, @group_by group_by  
	, CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE s.item_number END group_by_code
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
	, 0
FROM ActualSales s
JOIN Item i
	ON s.item_number = i.item_number
LEFT JOIN ProductGroup pg
	ON i.product_group_code = pg.product_group_code
LEFT JOIN Customer c
	ON s.company_code = c.company_code
	AND s.customer_number = c.customer_number
WHERE s.company_code = @company_code
AND	s.customer_number <> '1610'
AND	((@customer_number_from IS NOT NULL AND ISNULL(c.customer_number, 'zzzz') >= @customer_number_from)
	OR @customer_number_from IS NULL)
AND	((@customer_number_to IS NOT NULL AND ISNULL(c.customer_number, 'zzzz') <= @customer_number_to)
	OR @customer_number_to IS NULL)
AND [month] BETWEEN @start_date AND @end_date
AND	((@brand_code_from IS NOT NULL AND pg.brand_code >= @brand_code_from)
	OR @brand_code_from IS NULL)
AND	((@brand_code_to IS NOT NULL AND pg.brand_code <= @brand_code_to)
	OR @brand_code_to IS NULL)
AND	((@product_category_code_from IS NOT NULL AND pg.product_category_code >= @product_category_code_from)
	OR @product_category_code_from IS NULL)
AND	((@product_category_code_to IS NOT NULL AND pg.product_category_code <= @product_category_code_to)
	OR @product_category_code_to IS NULL)
AND NOT EXISTS (SELECT 1 FROM #forecastReport fr
				WHERE fr.company_code = s.company_code
				AND fr.group_by_code = CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE s.item_number END)
AND NOT EXISTS (SELECT 1 FROM #discontinuedItem di
				WHERE di.company_code = s.company_code
				AND ((di.customer_number IS NOT NULL AND ISNULL(c.customer_number, 'zzzz') = di.customer_number)
					OR di.customer_number IS NULL)
				AND di.item_number = CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE s.item_number END)

DROP TABLE #discontinuedItem
	
SELECT * FROM #forecastReport ORDER BY 1, 3
DROP TABLE #forecastReport
