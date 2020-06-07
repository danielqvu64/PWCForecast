CREATE TABLE [dbo].[ForecastHeader] (
    [company_code]       VARCHAR (3)  NOT NULL,
    [customer_number]    VARCHAR (10) NOT NULL,
    [pos_sales_end_date] DATETIME     NOT NULL,
    [timestamp]          TIMESTAMP    NOT NULL
);

