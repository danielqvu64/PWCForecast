ALTER TABLE [dbo].[ForecastTrendByCompanyItem]
    ADD CONSTRAINT [FK_ForecastTrendByCompanyItem_Item] FOREIGN KEY ([item_number]) REFERENCES [dbo].[Item] ([item_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

