

CREATE PROCEDURE [dbo].[bonusAndDiscontinuedByCustomer_sel]
	@objectKey xml
AS

SET NOCOUNT ON

DECLARE	@company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)

SELECT	@company_code = @objectKey.value('/ObjectKey[1]/@CompanyCode', 'varchar(3)')
	, @customer_number = @objectKey.value('/ObjectKey[1]/@CustomerNumber', 'varchar(10)')
	, @item_number = @objectKey.value('/ObjectKey[1]/@ItemNumber', 'varchar(11)')

SELECT	company_code
	, customer_number
	, item_number
	, discontinued_effective_date
	, py_01
	, py_02
	, py_03
	, py_04
	, py_05
	, py_06
	, py_07
	, py_08
	, py_09
	, py_10
	, py_11
	, py_12
	, cy_01
	, cy_02
	, cy_03
	, cy_04
	, cy_05
	, cy_06
	, cy_07
	, cy_08
	, cy_09
	, cy_10
	, cy_11
	, cy_12
	, ny_01
	, ny_02
	, ny_03
	, ny_04
	, ny_05
	, ny_06
	, ny_07
	, ny_08
	, ny_09
	, ny_10
	, ny_11
	, ny_12
	, timestamp
FROM	BonusAndDiscontinuedByCustomer
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	item_number = @item_number


