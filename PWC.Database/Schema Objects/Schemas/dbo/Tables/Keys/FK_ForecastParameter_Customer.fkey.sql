ALTER TABLE [dbo].[ForecastParameter]
    ADD CONSTRAINT [FK_ForecastParameter_Customer] FOREIGN KEY ([company_code], [customer_number]) REFERENCES [dbo].[Customer] ([company_code], [customer_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

