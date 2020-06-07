ALTER TABLE [dbo].[BonusAndDiscontinuedByCustomer]
    ADD CONSTRAINT [FK_BonusAndDiscontinuedByCustomer_Item] FOREIGN KEY ([item_number]) REFERENCES [dbo].[Item] ([item_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

