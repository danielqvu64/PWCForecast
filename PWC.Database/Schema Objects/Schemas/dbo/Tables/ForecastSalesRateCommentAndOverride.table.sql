CREATE TABLE [dbo].[ForecastSalesRateCommentAndOverride] (
    [company_code]       VARCHAR (3)   NOT NULL,
    [customer_number]    VARCHAR (10)  NOT NULL,
    [item_number]        VARCHAR (11)  NOT NULL,
    [pos_sales_end_date] DATETIME      NOT NULL,
    [date_time]          DATETIME      NOT NULL,
    [comment]            VARCHAR (255) NULL,
    [manual_flag]        BIT           NULL
);

