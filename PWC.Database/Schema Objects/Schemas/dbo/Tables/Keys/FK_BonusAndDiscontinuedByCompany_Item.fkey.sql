﻿ALTER TABLE [dbo].[BonusAndDiscontinuedByCompany]
    ADD CONSTRAINT [FK_BonusAndDiscontinuedByCompany_Item] FOREIGN KEY ([item_number]) REFERENCES [dbo].[Item] ([item_number]) ON DELETE NO ACTION ON UPDATE NO ACTION;

