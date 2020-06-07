ALTER TABLE [dbo].[ForecastParameter]
    ADD CONSTRAINT [FK_ForecastParameter_Item] FOREIGN KEY ([item_number]) REFERENCES [dbo].[Item] ([item_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

