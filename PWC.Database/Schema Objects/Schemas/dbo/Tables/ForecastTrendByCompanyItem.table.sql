CREATE TABLE [dbo].[ForecastTrendByCompanyItem] (
    [company_code]    VARCHAR (3)    NOT NULL,
    [item_number]     VARCHAR (11)   NOT NULL,
    [forecast_method] CHAR (2)       NOT NULL,
    [factor_month_01] DECIMAL (5, 2) NOT NULL,
    [factor_month_02] DECIMAL (5, 2) NOT NULL,
    [factor_month_03] DECIMAL (5, 2) NOT NULL,
    [factor_month_04] DECIMAL (5, 2) NOT NULL,
    [factor_month_05] DECIMAL (5, 2) NOT NULL,
    [factor_month_06] DECIMAL (5, 2) NOT NULL,
    [factor_month_07] DECIMAL (5, 2) NOT NULL,
    [factor_month_08] DECIMAL (5, 2) NOT NULL,
    [factor_month_09] DECIMAL (5, 2) NOT NULL,
    [factor_month_10] DECIMAL (5, 2) NOT NULL,
    [factor_month_11] DECIMAL (5, 2) NOT NULL,
    [factor_month_12] DECIMAL (5, 2) NOT NULL,
    [timestamp]       TIMESTAMP      NOT NULL
);

