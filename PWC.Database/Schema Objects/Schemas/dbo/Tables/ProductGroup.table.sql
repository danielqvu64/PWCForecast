CREATE TABLE [dbo].[ProductGroup] (
    [product_group_code]        VARCHAR (4)   NOT NULL,
    [product_group_description] VARCHAR (100) NULL,
    [brand_code]                VARCHAR (2)   NOT NULL,
    [product_category_code]     VARCHAR (2)   NOT NULL,
    [timestamp]                 TIMESTAMP     NOT NULL
);

