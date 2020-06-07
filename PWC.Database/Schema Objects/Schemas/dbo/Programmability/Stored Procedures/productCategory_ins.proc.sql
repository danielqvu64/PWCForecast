

CREATE PROCEDURE [dbo].[productCategory_ins]
	@product_category_code varchar(2)
	, @product_category_description varchar(100)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON
INSERT	ProductCategory
	(product_category_code, product_category_description)
VALUES
	(@product_category_code, @product_category_description)

SELECT	@timestamp = timestamp
FROM	ProductCategory
WHERE	product_category_code = @product_category_code

SELECT	@product_category_code


