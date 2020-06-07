ALTER TABLE [dbo].[ForecastSalesRate]
    ADD CONSTRAINT [FK_ForecastSalesRate_WeekCalendar] FOREIGN KEY ([pos_sales_end_date]) REFERENCES [dbo].[WeekCalendar] ([week_end_date]) ON DELETE NO ACTION ON UPDATE NO ACTION;

