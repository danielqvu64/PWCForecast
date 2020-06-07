CREATE PROCEDURE [utlGenerateWeekCalendar]
	@year int
	, @1st_week_start_date datetime
AS

SET NOCOUNT ON

DECLARE	@1st_week_end_date datetime
	, @week_no int
SELECT	@1st_week_end_date = DATEADD(DAY, 6, @1st_week_start_date)
	, @week_no = 1

DELETE	WeekCalendar
WHERE	[year] = @year

WHILE @week_no <= 52 BEGIN
	INSERT	WeekCalendar
		([year], week_no, week_start_date, week_end_date)
	VALUES
		(@year, @week_no, @1st_week_start_date, @1st_week_end_date)
	
	--print cast(@year as varchar) + ' ' + cast(@week_no as varchar) + ' ' + cast(@1st_week_start_date as varchar) + ' ' + cast(@1st_week_end_date as varchar)
	SELECT	@week_no = @week_no + 1
		, @1st_week_start_date = DATEADD(DAY, 7, @1st_week_start_date)
		, @1st_week_end_date = DATEADD(DAY, 7, @1st_week_end_date)
END