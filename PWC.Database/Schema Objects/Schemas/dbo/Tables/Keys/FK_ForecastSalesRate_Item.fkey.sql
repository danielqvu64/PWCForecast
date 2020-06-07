ALTER TABLE [dbo].[ForecastSalesRate]
    ADD CONSTRAINT [FK_ForecastSalesRate_Item] FOREIGN KEY ([item_number]) REFERENCES [dbo].[Item] ([item_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

