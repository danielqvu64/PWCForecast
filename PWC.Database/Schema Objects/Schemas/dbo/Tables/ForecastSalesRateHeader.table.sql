CREATE TABLE [dbo].[ForecastSalesRateHeader] (
    [company_code]        VARCHAR (3)  NOT NULL,
    [customer_number]     VARCHAR (10) NOT NULL,
    [pos_sales_end_date]  DATETIME     NOT NULL,
    [pos_number_of_weeks] SMALLINT     NOT NULL,
    [timestamp]           TIMESTAMP    NOT NULL
);

