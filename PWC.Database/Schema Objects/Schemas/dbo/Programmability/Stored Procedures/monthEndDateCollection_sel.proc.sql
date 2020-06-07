CREATE PROCEDURE [dbo].[monthEndDateCollection_sel]
AS

SET NOCOUNT ON

SELECT	CONVERT(varchar, week_end_date, 101) month_end_date, week_end_date -- include year - 2 month 1
FROM	weekcalendar
WHERE	week_no = 52
AND	[year] = DATEPART(YEAR, GETDATE()) - 2

UNION

SELECT	CONVERT(varchar, week_end_date, 101) month_end_date, week_end_date
FROM	weekcalendar
WHERE	(week_no % 4) = 0
AND	[year] BETWEEN DATEPART(YEAR, GETDATE()) - 1 and DATEPART(YEAR, GETDATE()) + 1
AND CASE WHEN [year] = DATEPART(YEAR, GETDATE()) + 1 AND week_no = 52 THEN 0 ELSE 1 END = 1 -- exclude year + 1 month 12

ORDER BY 2
