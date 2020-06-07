

CREATE PROCEDURE [dbo].[brand_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@brand_code varchar(2)
SELECT	@brand_code = @objectKey.value('/ObjectKey[1]/@BrandCode', 'varchar(2)')

SELECT brand_code, brand_description, timestamp
FROM	Brand
WHERE	brand_code = @brand_code


