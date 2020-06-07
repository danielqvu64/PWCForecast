ALTER TABLE [dbo].[Customer]
    ADD CONSTRAINT [DF_Customer_forecast_future_frozen_months] DEFAULT ((0)) FOR [forecast_future_frozen_months];

