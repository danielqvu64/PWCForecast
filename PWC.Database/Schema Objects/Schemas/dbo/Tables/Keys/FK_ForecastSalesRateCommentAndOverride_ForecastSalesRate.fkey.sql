ALTER TABLE [dbo].[ForecastSalesRateCommentAndOverride]
    ADD CONSTRAINT [FK_ForecastSalesRateCommentAndOverride_ForecastSalesRate] FOREIGN KEY ([company_code], [customer_number], [item_number], [pos_sales_end_date]) REFERENCES [dbo].[ForecastSalesRate] ([company_code], [customer_number], [item_number], [pos_sales_end_date]) ON DELETE NO ACTION ON UPDATE NO ACTION;

