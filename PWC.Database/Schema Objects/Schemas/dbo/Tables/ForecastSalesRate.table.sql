CREATE TABLE [dbo].[ForecastSalesRate] (
    [company_code]         VARCHAR (3)    NOT NULL,
    [customer_number]      VARCHAR (10)   NOT NULL,
    [pos_sales_end_date]   DATETIME       NOT NULL,
    [item_number]          VARCHAR (11)   NOT NULL,
    [trend_factor]         DECIMAL (5, 2) NULL,
    [pos_week_1_quantity]  INT            NULL,
    [pos_week_2_quantity]  INT            NULL,
    [pos_week_3_quantity]  INT            NULL,
    [pos_week_4_quantity]  INT            NULL,
    [store_count_existing] INT            NULL,
    [store_count_new]      INT            NULL,
    [sales_rate]           DECIMAL (5, 2) NULL,
    [sales_rate_previous]  DECIMAL (5, 2) NULL,
    [timestamp]            TIMESTAMP      NOT NULL
);

