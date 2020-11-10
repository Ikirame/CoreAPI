using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class IISExtension
    {
        #region Methods

        /// <summary>
        /// Configure IIS (Internet Information Server) integration
        /// </summary>
        /// <param name="services">>Collection to register services</param>
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        /// <summary>
        /// Add IIS (Internet Information Server) integration to application's request pipeline
        /// </summary>
        /// <param name="app">Interface for application builder</param>
        public static void UseIISIntegration(this IApplicationBuilder app) =>
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

        #endregion
    }
}