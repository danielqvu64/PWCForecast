CREATE PROCEDURE [dbo].[productPrefixCollection_sel]
	@product_prefix_code varchar(2)
	, @product_prefix_description varchar(100)
AS

SET NOCOUNT ON
SELECT	product_prefix_code, product_prefix_description
FROM	ProductPrefix
WHERE	product_prefix_code LIKE ISNULL('%' + @product_prefix_code + '%', product_prefix_code)
AND	((product_prefix_description IS NOT NULL AND product_prefix_description LIKE ISNULL('%' + @product_prefix_description + '%', product_prefix_description))
	OR product_prefix_description IS NULL)
ORDER BY product_prefix_code
