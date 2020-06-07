ALTER TABLE [dbo].[ForecastTrendByCompanyProductGroup]
    ADD CONSTRAINT [FK_ForecastTrendByCompanyProductGroup_Company] FOREIGN KEY ([company_code]) REFERENCES [dbo].[Company] ([company_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

