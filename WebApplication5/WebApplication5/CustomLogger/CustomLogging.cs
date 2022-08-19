using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace WebApplication5.CustomLogger
{
    public class CustomLogging : ILogger
    {
        private readonly string _name;
        public readonly CustomLogginOption _options;
        protected readonly CustomLoggerProvider _customLoggerProvider;

        public CustomLogging(CustomLogginOption options, string categoryName)
        {
            _options = options;
            _name = categoryName;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            try
            {
                if (!IsEnabled(logLevel))
                {
                    return;
                }

                if (formatter == null)
                {
                    throw new ArgumentNullException(nameof(formatter));
                }

                var message = exception == null ?
                    formatter(state, exception) :
                    $"{formatter(state, exception)}{Environment.NewLine}{Environment.NewLine}{exception}";

                if (string.IsNullOrWhiteSpace(message))
                {
                    return;
                }

                var hostAddress = Dns.GetHostName();
                var ipAddress = Dns
                    .GetHostEntry(hostAddress)
                    .AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork)
                    .FirstOrDefault();

                var model = new CustomLogginOption()
                {
                    Date = DateTime.UtcNow,
                    Application = Trim($"{_name}", CustomLogginOption.MaxApplicationLength),
                    Message = Trim(message, CustomLogginOption.MaximumMessageLength),
                    Exception = Trim($"{exception}", CustomLogginOption.MaximumExceptionLength),
                    Level = Trim($"{logLevel}", CustomLogginOption.MaxLoggerLength),
                    Logger = Trim($"{_name}", CustomLogginOption.MaxLoggerLength),
                    Thread = Trim($"{eventId}", CustomLogginOption.MaxThreadLength),
                    IpAddress = Trim($"{ipAddress}", CustomLogginOption.MaxIpAddressLength),
                    HostAddress = Trim($"{hostAddress}", CustomLogginOption.MaxHostLength)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static string Trim(string value, int maximumLength)
        {
            return value.Length > maximumLength ? value.Substring(0, maximumLength) : value;
        }
    }
}
