ALTER TABLE [dbo].[ForecastCommentAndOverride]
    ADD CONSTRAINT [FK_ForecastCommentAndOverride_Forecast] FOREIGN KEY ([company_code], [customer_number], [pos_sales_end_date], [item_number], [forecast_method]) REFERENCES [dbo].[Forecast] ([company_code], [customer_number], [pos_sales_end_date], [item_number], [forecast_method]) ON DELETE NO ACTION ON UPDATE NO ACTION;

