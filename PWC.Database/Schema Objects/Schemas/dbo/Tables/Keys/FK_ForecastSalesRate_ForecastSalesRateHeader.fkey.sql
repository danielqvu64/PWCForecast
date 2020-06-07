ALTER TABLE [dbo].[ForecastSalesRate]
    ADD CONSTRAINT [FK_ForecastSalesRate_ForecastSalesRateHeader] FOREIGN KEY ([company_code], [customer_number], [pos_sales_end_date]) REFERENCES [dbo].[ForecastSalesRateHeader] ([company_code], [customer_number], [pos_sales_end_date]) ON DELETE NO ACTION ON UPDATE NO ACTION;

