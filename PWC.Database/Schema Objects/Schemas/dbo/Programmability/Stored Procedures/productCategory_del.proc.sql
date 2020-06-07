CREATE PROCEDURE [dbo].[productCategory_del]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@product_category_code varchar(2)
SELECT	@product_category_code = @objectKey.value('/ObjectKey[1]/@ProductCategoryCode', 'varchar(2)')

DELETE	ProductCategory
WHERE	product_category_code = @product_category_code
