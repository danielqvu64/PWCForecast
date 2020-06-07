CREATE TABLE [dbo].[ApplicationException] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [type]                VARCHAR (50)   NULL,
    [message]             VARCHAR (1024) NULL,
    [stack_trace]         VARCHAR (MAX)  NULL,
    [source]              VARCHAR (50)   NULL,
    [target_site]         VARCHAR (50)   NULL,
    [base_exception_type] VARCHAR (50)   NULL,
    [machine_name]        VARCHAR (50)   NULL,
    [date_time]           DATETIME       NULL,
    [additional_data]     VARCHAR (1024) NULL
);

