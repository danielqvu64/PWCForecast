

CREATE PROCEDURE [dbo].[bonusAndDiscontinuedByCustomer_ins]
	  @company_code varchar(3)
	, @customer_number varchar(10)
	, @item_number varchar(11)
	, @discontinued_effective_date datetime
	, @py_01 int
	, @py_02 int
	, @py_03 int
	, @py_04 int
	, @py_05 int
	, @py_06 int
	, @py_07 int
	, @py_08 int
	, @py_09 int
	, @py_10 int
	, @py_11 int
	, @py_12 int
	, @cy_01 int
	, @cy_02 int
	, @cy_03 int
	, @cy_04 int
	, @cy_05 int
	, @cy_06 int
	, @cy_07 int
	, @cy_08 int
	, @cy_09 int
	, @cy_10 int
	, @cy_11 int
	, @cy_12 int
	, @ny_01 int
	, @ny_02 int
	, @ny_03 int
	, @ny_04 int
	, @ny_05 int
	, @ny_06 int
	, @ny_07 int
	, @ny_08 int
	, @ny_09 int
	, @ny_10 int
	, @ny_11 int
	, @ny_12 int
	, @timestamp timestamp OUTPUT
AS

SET NOCOUNT ON

INSERT	BonusAndDiscontinuedByCustomer
	( company_code
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
	, ny_12 )
VALUES
	( @company_code
	, @customer_number
	, @item_number
	, @discontinued_effective_date
	, @py_01
	, @py_02
	, @py_03
	, @py_04
	, @py_05
	, @py_06
	, @py_07
	, @py_08
	, @py_09
	, @py_10
	, @py_11
	, @py_12
	, @cy_01
	, @cy_02
	, @cy_03
	, @cy_04
	, @cy_05
	, @cy_06
	, @cy_07
	, @cy_08
	, @cy_09
	, @cy_10
	, @cy_11
	, @cy_12
	, @ny_01
	, @ny_02
	, @ny_03
	, @ny_04
	, @ny_05
	, @ny_06
	, @ny_07
	, @ny_08
	, @ny_09
	, @ny_10
	, @ny_11
	, @ny_12 )

SELECT	@timestamp = timestamp
FROM	BonusAndDiscontinuedByCustomer
WHERE	company_code = @company_code
AND	customer_number = @customer_number
AND	item_number = @item_number

SELECT	@company_code + '|' + @customer_number + '|' + @item_number


