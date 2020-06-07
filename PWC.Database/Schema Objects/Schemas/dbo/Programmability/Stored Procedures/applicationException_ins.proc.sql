CREATE PROCEDURE [dbo].[applicationException_ins]
	@type varchar(50)
	, @message varchar(1024)
	, @stack_trace varchar(max)
	, @source varchar(50)
	, @target_site varchar(50)
	, @base_exception_type varchar(50)
	, @machine_name varchar(50)
	, @date_time datetime
	, @additional_data varchar(1024) = null
AS

INSERT	ApplicationException
	( [type]
	, [message]
	, stack_trace
	, source
	, target_site
	, base_exception_type
	, machine_name
	, date_time
	, additional_data )
VALUES
	( @type
	, @message
	, @stack_trace
	, @source
	, @target_site
	, @base_exception_type
	, @machine_name
	, @date_time
	, @additional_data )
