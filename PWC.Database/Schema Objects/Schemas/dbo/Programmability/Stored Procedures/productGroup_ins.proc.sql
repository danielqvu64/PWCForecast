

CREATE PROCEDURE [dbo].[productGroup_ins]
	@product_group_code varchar(4)
	, @product_group_description varchar(100)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON
INSERT	ProductGroup
	(product_group_code, brand_code, product_category_code, product_group_description)
VALUES
	(@product_group_code, LEFT(@product_group_code, 2), RIGHT(@product_group_code, 2), @product_group_description)

SELECT	@timestamp = timestamp
FROM	ProductGroup
WHERE	product_group_code = @product_group_code

SELECT	@product_group_code


