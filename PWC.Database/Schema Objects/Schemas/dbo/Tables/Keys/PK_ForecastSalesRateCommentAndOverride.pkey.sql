ALTER TABLE [dbo].[ForecastSalesRateCommentAndOverride]
    ADD CONSTRAINT [PK_ForecastSalesRateCommentAndOverride] PRIMARY KEY CLUSTERED ([company_code] ASC, [customer_number] ASC, [item_number] ASC, [pos_sales_end_date] ASC, [date_time] DESC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

