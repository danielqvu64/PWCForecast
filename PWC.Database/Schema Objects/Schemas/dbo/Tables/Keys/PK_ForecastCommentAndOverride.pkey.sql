ALTER TABLE [dbo].[ForecastCommentAndOverride]
    ADD CONSTRAINT [PK_ForecastCommentAndOverride] PRIMARY KEY CLUSTERED ([company_code] ASC, [customer_number] ASC, [pos_sales_end_date] ASC, [item_number] ASC, [forecast_method] ASC, [forecast_value_key] ASC, [date_time] DESC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

