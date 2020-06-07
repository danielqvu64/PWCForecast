

CREATE PROCEDURE [dbo].[item_ins]
	@item_number varchar(11)
	, @item_description varchar(150)
	, @product_group_code varchar(4)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON
INSERT	Item
	(item_number, item_description, product_group_code)
VALUES
	(@item_number, @item_description, @product_group_code)

SELECT	@timestamp = timestamp
FROM	Item
WHERE	item_number = @item_number

SELECT	@item_number


