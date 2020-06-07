

CREATE PROCEDURE [dbo].[productGroupCollection_sel]
	@product_group_code varchar(4)
	, @brand_code varchar(2)
	, @product_category_code varchar(2)
	, @product_group_description varchar(100)
AS

SET NOCOUNT ON

SELECT	product_group_code, product_group_description, timestamp
FROM	ProductGroup
WHERE	product_group_code = ISNULL(@product_group_code, product_group_code)
AND	brand_code = ISNULL(@brand_code, brand_code)
AND	product_category_code = ISNULL(@product_category_code, product_category_code)
AND	((@product_group_description IS NOT NULL AND product_group_description LIKE '%' + @product_group_description + '%')
	OR @product_group_description IS NULL)
ORDER BY 1


