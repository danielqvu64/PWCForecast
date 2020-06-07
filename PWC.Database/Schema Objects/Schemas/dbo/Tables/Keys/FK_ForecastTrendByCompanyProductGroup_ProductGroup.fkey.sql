ALTER TABLE [dbo].[ForecastTrendByCompanyProductGroup]
    ADD CONSTRAINT [FK_ForecastTrendByCompanyProductGroup_ProductGroup] FOREIGN KEY ([product_group_code]) REFERENCES [dbo].[ProductGroup] ([product_group_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

