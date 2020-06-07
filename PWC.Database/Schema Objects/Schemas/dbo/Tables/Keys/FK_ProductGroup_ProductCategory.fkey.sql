ALTER TABLE [dbo].[ProductGroup]
    ADD CONSTRAINT [FK_ProductGroup_ProductCategory] FOREIGN KEY ([product_category_code]) REFERENCES [dbo].[ProductCategory] ([product_category_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

