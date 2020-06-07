ALTER TABLE [dbo].[ForecastTrendByCustomerProductGroup]
    ADD CONSTRAINT [PK_ForecastTrendByCustomeProductGroup] PRIMARY KEY CLUSTERED ([company_code] ASC, [customer_number] ASC, [product_group_code] ASC, [forecast_method] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

