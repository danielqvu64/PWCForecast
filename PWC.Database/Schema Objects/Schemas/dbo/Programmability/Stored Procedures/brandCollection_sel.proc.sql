

CREATE PROCEDURE [dbo].[brandCollection_sel]
	@brand_code varchar(2)
	, @brand_description varchar(100)
AS

SET NOCOUNT ON
SELECT	brand_code, brand_description, timestamp
FROM	Brand
WHERE	brand_code LIKE ISNULL('%' + @brand_code + '%', brand_code)
AND	((@brand_description IS NOT NULL AND brand_description LIKE '%' + @brand_description + '%')
	OR @brand_description IS NULL)
ORDER BY brand_code


