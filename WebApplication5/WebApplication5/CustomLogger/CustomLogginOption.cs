using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebApplication5.CustomLogger
{
    public class CustomLogginOption
    {
        public const int MaxThreadLength = 255;
        public const int MaxLoggerLength = 255;
        public const int MaxLevelLength = 50;
        public const int MaxApplicationLength = 255;
        public const int MaxHostLength = 50;
        public const int MaxIpAddressLength = 50;
        public const int MaximumExceptionLength = 4000;
        public const int MaximumMessageLength = 8000;
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string HostAddress { get; set; }
        public string Application { get; set; }
        public string IpAddress { get; set; }
    }
    public class AppLogLevel
    {
        public string Name { get; set; } = "Application";
        public LogLevel MinLevel { get; set; } = LogLevel.Debug;
        public List<LogLevel> Levels { get; set; } = new List<LogLevel>();
    }

    public class AppLoggingSettings
    {
        public string ConnectionStringName { get; set; } = "Logging";
        public List<AppLogLevel> LogLevels { get; set; } = new List<AppLogLevel>();
    }

}
