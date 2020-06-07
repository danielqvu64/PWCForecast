ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [PWCForecast_log], FILENAME = '$(DefaultLogPath)$(DatabaseName).ldf', MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

