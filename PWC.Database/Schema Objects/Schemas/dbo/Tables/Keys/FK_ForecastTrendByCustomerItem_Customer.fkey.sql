ALTER TABLE [dbo].[ForecastTrendByCustomerItem]
    ADD CONSTRAINT [FK_ForecastTrendByCustomerItem_Customer] FOREIGN KEY ([company_code], [customer_number]) REFERENCES [dbo].[Customer] ([company_code], [customer_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

