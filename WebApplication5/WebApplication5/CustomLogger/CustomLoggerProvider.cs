using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;

namespace WebApplication5.CustomLogger
{
    [ProviderAlias("LoggerProvider")]
    public class CustomLoggerProvider : ILoggerProvider
    {
        private Func<CustomLogginOption> _repoFactory;
        public readonly CustomLogginOption _options;
        private AppLoggingSettings logSettings;
        private Func<string, LogLevel, bool> _filter;
        private string _appName = "Microsoft.AspNetCore";

        public CustomLoggerProvider(Func<CustomLogginOption> repoFactory, AppLoggingSettings loggingSettings, string applicationName)
        {
            _repoFactory = repoFactory;
            _filter = (category, logLevel) =>
            {
                var matchedCategory = loggingSettings.LogLevels.FirstOrDefault();
                if (matchedCategory == null)
                {
                    matchedCategory = loggingSettings.LogLevels.FirstOrDefault();
                }

                if (matchedCategory == null)
                {
                    return false;
                }

                if ((matchedCategory.Levels?.Count ?? 0) > 0)
                {
                    return matchedCategory.Levels.Contains(logLevel);
                }
                else
                {
                    return logLevel != LogLevel.None && logLevel >= matchedCategory.MinLevel;
                }
            }; ;
            _appName = applicationName;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogging(_options, categoryName);
        }

        public void Dispose()
        {
            _repoFactory = null;
        }
    }
}
