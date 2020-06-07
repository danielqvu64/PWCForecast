CREATE PROCEDURE [dbo].[productGroup_del]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@product_group_code varchar(4)
SELECT	@product_group_code = @objectKey.value('/ObjectKey[1]/@ProductGroupCode', 'varchar(4)')

DELETE	ProductGroup
WHERE	product_group_code = @product_group_code
