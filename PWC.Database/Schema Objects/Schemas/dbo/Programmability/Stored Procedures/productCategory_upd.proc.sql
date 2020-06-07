

CREATE PROCEDURE [dbo].[productCategory_upd]
	@objectKey xml
	, @product_category_code varchar(2)
	, @product_category_description varchar(100)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM ProductCategory WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@product_category_code_key varchar(2)
SELECT	@product_category_code_key = @objectKey.value('/ObjectKey[1]/@ProductCategoryCode', 'varchar(2)')

UPDATE	ProductCategory
	SET product_category_code = @product_category_code
		, product_category_description = @product_category_description
WHERE	product_category_code = @product_category_code_key

SELECT	@timestamp = timestamp
FROM	ProductCategory
WHERE	product_category_code = @product_category_code_key


