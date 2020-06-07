

CREATE PROCEDURE [dbo].[item_upd]
	@objectKey xml
	, @item_number varchar(11)
	, @item_description varchar(150)
	, @product_group_code varchar(4)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT 1 FROM Item WHERE timestamp = @timestamp) BEGIN
    RAISERROR ('Timestamp mismatched', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

DECLARE	@item_number_key varchar(11)
SELECT	@item_number_key = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')

UPDATE	item
	SET item_number = @item_number
	, item_description = @item_description
	, product_group_code = @product_group_code
WHERE	item_number = @item_number_key

SELECT	@timestamp = timestamp
FROM	Item
WHERE	item_number = @item_number_key


