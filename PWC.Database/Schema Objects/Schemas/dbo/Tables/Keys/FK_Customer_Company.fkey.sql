ALTER TABLE [dbo].[Customer]
    ADD CONSTRAINT [FK_Customer_Company] FOREIGN KEY ([company_code]) REFERENCES [dbo].[Company] ([company_code]) ON DELETE NO ACTION ON UPDATE NO ACTION;

