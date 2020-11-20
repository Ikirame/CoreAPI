using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebAPI.Extensions
{
    public static class LoggingExtension
    {
        /// <summary>
        /// Configure serilog logging system
        /// </summary>
        /// <param name="services">Collection to register services</param>
        /// <param name="configuration">Configuration file loaded with settings</param>
        public static void AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            var newConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(newConfiguration, true);
            });
        }
    }
}