using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    /// <summary>
    /// Extensions class to configure and use CORS integration
    /// </summary>
    public static class CorsExtension
    {
        #region Fields

        private const string PolicyName = "CorsPolicy";

        #endregion

        #region Methods

        /// <summary>
        /// Configure CORS (Cross-Origin Resource Sharing)
        /// </summary>
        /// <param name="services">Collection to register services</param>
        public static void ConfigureCorsIntegration(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

        /// <summary>
        /// Add CORS (Cross-Origin Resource Sharing) to application's request pipeline
        /// </summary>
        /// <param name="app">Interface for application builder</param>
        public static void UseCorsIntegration(this IApplicationBuilder app) => app.UseCors(PolicyName);

        #endregion
    }
}