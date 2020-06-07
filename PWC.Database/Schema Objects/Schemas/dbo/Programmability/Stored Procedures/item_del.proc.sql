CREATE PROCEDURE [dbo].[item_del]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@item_number varchar(11)
SELECT	@item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')

DELETE	Item
WHERE	item_number = @item_number
