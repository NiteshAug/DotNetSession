using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using WebApplication5.Interface;
using WebApplication5.Service;

namespace WebApplication5.CustomLogger
{
    public static class CustomLoggerExtension
    {
        public static void AddLogger(this IServiceCollection services, string loggingConnStr)
        {
            services.AddTransient<ICustomer, CustomerService>();           
        }

        public static void UseLogger(this IApplicationBuilder app, IConfigurationSection config, string applicationName)
        {
            var serviceProvider = app.ApplicationServices;
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>() as ILoggerFactory;
            var loggingSettings = (serviceProvider.GetService<IOptions<AppLoggingSettings>>()).Value;

            Func<CustomLogginOption> appLogRepoFactory = () =>
            {
                // Create a scope repository
                var scope = serviceProvider.CreateScope();
                return scope.ServiceProvider.GetRequiredService<CustomLogginOption>();
            };

            loggerFactory.AddProvider(new CustomLoggerProvider(appLogRepoFactory, loggingSettings, applicationName));
        }
    }
}
