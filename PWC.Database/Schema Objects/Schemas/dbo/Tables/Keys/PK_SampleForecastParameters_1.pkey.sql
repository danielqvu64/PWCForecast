ALTER TABLE [dbo].[ForecastParameter]
    ADD CONSTRAINT [PK_SampleForecastParameters_1] PRIMARY KEY CLUSTERED ([company_code] ASC, [customer_number] ASC, [item_number] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

