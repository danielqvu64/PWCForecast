

CREATE PROCEDURE [dbo].[productGroup_upd]
	@objectKey xml
	, @product_group_code varchar(4)
	, @product_group_description varchar(100)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM ProductGroup WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@product_group_code_key varchar(4)
SELECT	@product_group_code_key = @objectKey.value('/ObjectKey[1]/@ProductGroupCode', 'varchar(4)')

UPDATE	ProductGroup
	SET product_group_code = @product_group_code
		, product_group_description = @product_group_description
WHERE	product_group_code = @product_group_code_key

SELECT	@timestamp = timestamp
FROM	ProductGroup
WHERE	product_group_code = @product_group_code_key


