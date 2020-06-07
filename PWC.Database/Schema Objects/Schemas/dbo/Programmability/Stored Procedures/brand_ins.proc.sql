

CREATE PROCEDURE [dbo].[brand_ins]
	@brand_code varchar(2)
	, @brand_description varchar(100)
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON
INSERT	Brand
	(brand_code, brand_description)
VALUES
	(@brand_code, @brand_description)

SELECT	@timestamp = timestamp
FROM	Brand
WHERE	brand_code = @brand_code

SELECT	@brand_code


