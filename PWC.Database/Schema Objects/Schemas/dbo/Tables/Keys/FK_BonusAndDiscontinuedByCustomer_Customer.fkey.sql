ALTER TABLE [dbo].[BonusAndDiscontinuedByCustomer]
    ADD CONSTRAINT [FK_BonusAndDiscontinuedByCustomer_Customer] FOREIGN KEY ([company_code], [customer_number]) REFERENCES [dbo].[Customer] ([company_code], [customer_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

