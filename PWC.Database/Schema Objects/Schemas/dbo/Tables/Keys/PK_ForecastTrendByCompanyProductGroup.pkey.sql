ALTER TABLE [dbo].[ForecastTrendByCompanyProductGroup]
    ADD CONSTRAINT [PK_ForecastTrendByCompanyProductGroup] PRIMARY KEY CLUSTERED ([company_code] ASC, [product_group_code] ASC, [forecast_method] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

