CREATE TABLE [dbo].[POSPriorToImport] (
    [company_code]    VARCHAR (3)  NOT NULL,
    [customer_number] VARCHAR (10) NOT NULL,
    [item_number]     VARCHAR (11) NOT NULL,
    [week_end_date]   DATETIME     NOT NULL,
    [quantity]        INT          NOT NULL
);

