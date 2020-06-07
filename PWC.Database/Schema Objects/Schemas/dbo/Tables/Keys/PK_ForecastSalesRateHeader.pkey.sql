ALTER TABLE [dbo].[ForecastSalesRateHeader]
    ADD CONSTRAINT [PK_ForecastSalesRateHeader] PRIMARY KEY CLUSTERED ([company_code] ASC, [customer_number] ASC, [pos_sales_end_date] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

