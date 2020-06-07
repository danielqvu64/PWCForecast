ALTER TABLE [dbo].[ForecastTrendByCompanyItem]
    ADD CONSTRAINT [PK_ForecastTrendByCompanyItem] PRIMARY KEY CLUSTERED ([company_code] ASC, [item_number] ASC, [forecast_method] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

