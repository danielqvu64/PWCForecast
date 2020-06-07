ALTER TABLE [dbo].[Forecast]
    ADD CONSTRAINT [FK_Forecast_ForecastHeader] FOREIGN KEY ([company_code], [customer_number], [pos_sales_end_date]) REFERENCES [dbo].[ForecastHeader] ([company_code], [customer_number], [pos_sales_end_date]) ON DELETE NO ACTION ON UPDATE NO ACTION;

