

CREATE PROCEDURE [dbo].[productCategoryCollection_sel]
	@product_category_code varchar(2)
	, @product_category_description varchar(100)
AS

SET NOCOUNT ON
SELECT	product_category_code, product_category_description, timestamp
FROM	ProductCategory
WHERE	product_category_code LIKE ISNULL('%' + @product_category_code + '%', product_category_code)
AND	((@product_category_description IS NOT NULL AND product_category_description LIKE '%' + @product_category_description + '%')
	OR @product_category_description IS NULL)
ORDER BY product_category_code


