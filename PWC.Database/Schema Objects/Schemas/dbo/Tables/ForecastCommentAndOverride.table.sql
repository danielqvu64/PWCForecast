CREATE TABLE [dbo].[ForecastCommentAndOverride] (
    [company_code]       VARCHAR (3)   NOT NULL,
    [customer_number]    VARCHAR (10)  NOT NULL,
    [pos_sales_end_date] DATETIME      NOT NULL,
    [item_number]        VARCHAR (11)  NOT NULL,
    [forecast_method]    VARCHAR (2)   NOT NULL,
    [forecast_value_key] CHAR (5)      NOT NULL,
    [date_time]          DATETIME      NOT NULL,
    [comment]            VARCHAR (255) NULL,
    [manual_flag]        BIT           NULL
);

