ALTER TABLE [dbo].[ProductGroup]
    ADD CONSTRAINT [FK_ProductGroup_Brand] FOREIGN KEY ([brand_code]) REFERENCES [dbo].[Brand] ([brand_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

