CREATE TABLE [dbo].[ActualSalesPriorToImport] (
    [company_code]    VARCHAR (3)  NOT NULL,
    [customer_number] VARCHAR (4)  NOT NULL,
    [item_number]     VARCHAR (11) NOT NULL,
    [month]           DATETIME     NOT NULL,
    [quantity]        INT          NOT NULL
);

