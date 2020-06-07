ALTER TABLE [dbo].[ForecastTrendByCompanyItem]
    ADD CONSTRAINT [FK_ForecastTrendByCompanyItem_Company] FOREIGN KEY ([company_code]) REFERENCES [dbo].[Company] ([company_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

