ALTER TABLE [dbo].[Item]
    ADD CONSTRAINT [FK_Item_ProductGroup] FOREIGN KEY ([product_group_code]) REFERENCES [dbo].[ProductGroup] ([product_group_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

