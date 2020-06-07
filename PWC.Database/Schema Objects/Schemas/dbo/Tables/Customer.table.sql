CREATE TABLE [dbo].[Customer] (
    [company_code]                  VARCHAR (3)    NOT NULL,
    [customer_number]               VARCHAR (10)   NOT NULL,
    [customer_name]                 VARCHAR (100)  NULL,
    [distinct_forecast_name_flag]   BIT            NULL,
    [forecast_method]               VARCHAR (2)    NOT NULL,
    [inflate_factor]                DECIMAL (5, 2) NULL,
    [forecast_future_frozen_months] SMALLINT       NOT NULL,
    [timestamp]                     TIMESTAMP      NOT NULL
);

