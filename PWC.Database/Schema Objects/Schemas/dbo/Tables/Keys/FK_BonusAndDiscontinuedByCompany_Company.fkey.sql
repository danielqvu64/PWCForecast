ALTER TABLE [dbo].[BonusAndDiscontinuedByCompany]
    ADD CONSTRAINT [FK_BonusAndDiscontinuedByCompany_Company] FOREIGN KEY ([company_code]) REFERENCES [dbo].[Company] ([company_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

