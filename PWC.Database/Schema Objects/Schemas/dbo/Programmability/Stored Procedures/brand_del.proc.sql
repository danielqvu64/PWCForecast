CREATE PROCEDURE [dbo].[brand_del]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@brand_code varchar(2)
SELECT	@brand_code = @objectKey.value('/ObjectKey[1]/@BrandCode', 'varchar(2)')

DELETE	Brand
WHERE	brand_code = @brand_code
