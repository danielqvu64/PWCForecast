CREATE PROCEDURE [dbo].[actualSalesReportCollection_sel]
	@company_code varchar(3)
	, @customer_number_from varchar(10)
	, @customer_number_to varchar(10)
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

CREATE TABLE #discontinuedItem
	( company_code varchar(3)
	, customer_number varchar(10)
	, item_number varchar(11) )

INSERT #discontinuedItem
SELECT DISTINCT company_code, customer_number, item_number
FROM BonusAndDiscontinuedByCustomer
WHERE company_code = @company_code
AND	((@customer_number_from IS NOT NULL AND customer_number >= @customer_number_from)
	OR @customer_number_from IS NULL)
AND	((@customer_number_to IS NOT NULL AND customer_number <= @customer_number_to)
	OR @customer_number_to IS NULL)
AND discontinued_effective_date <= @start_date

INSERT #discontinuedItem (company_code, item_number)
SELECT DISTINCT company_code, item_number
FROM BonusAndDiscontinuedByCompany
WHERE company_code = @company_code
AND discontinued_effective_date <= @start_date
AND NOT EXISTS (SELECT 1 FROM #discontinuedItem
				WHERE BonusAndDiscontinuedByCompany.company_code = #discontinuedItem.company_code
				AND #discontinuedItem.customer_number IS NULL
				AND BonusAndDiscontinuedByCompany.item_number = #discontinuedItem.item_number)

SELECT s.company_code
	, @group_by group_by
	, CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE s.item_number END group_by_code
	, [month]
	, SUM(quantity) quantity
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
AND NOT EXISTS (SELECT 1 FROM #discontinuedItem di
				WHERE s.company_code = di.company_code
				AND ((di.customer_number IS NOT NULL AND ISNULL(c.customer_number, 'zzzz') = di.customer_number)
					OR di.customer_number IS NULL)
				AND s.item_number = di.item_number)
GROUP BY s.company_code, CASE WHEN @group_by = 'brand' THEN pg.brand_code ELSE s.item_number END, [month]
ORDER BY 1, 3, 4

DROP TABLE #discontinuedItem
