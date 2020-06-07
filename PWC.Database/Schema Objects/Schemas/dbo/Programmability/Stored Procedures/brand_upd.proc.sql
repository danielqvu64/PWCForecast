

CREATE PROCEDURE [dbo].[brand_upd]
	@objectKey xml
	, @brand_code varchar(2)
	, @brand_description varchar(100)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM Brand WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@brand_code_key varchar(2)
SELECT	@brand_code_key = @objectKey.value('/ObjectKey[1]/@BrandCode', 'varchar(2)')

UPDATE	Brand
	SET brand_code = @brand_code
	, brand_description = @brand_description
WHERE	brand_code = @brand_code_key

SELECT	@timestamp = timestamp
FROM	Brand
WHERE	brand_code = @brand_code_key


