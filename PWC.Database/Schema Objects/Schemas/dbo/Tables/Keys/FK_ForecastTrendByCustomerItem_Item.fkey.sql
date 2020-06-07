ALTER TABLE [dbo].[ForecastTrendByCustomerItem]
    ADD CONSTRAINT [FK_ForecastTrendByCustomerItem_Item] FOREIGN KEY ([item_number]) REFERENCES [dbo].[Item] ([item_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

