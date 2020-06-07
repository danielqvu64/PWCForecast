ALTER TABLE [dbo].[Forecast]
    ADD CONSTRAINT [PK_Forecast] PRIMARY KEY CLUSTERED ([company_code] ASC, [customer_number] ASC, [pos_sales_end_date] ASC, [item_number] ASC, [forecast_method] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

