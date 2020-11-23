using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions.Modules
{
    /// <summary>
    /// Extensions class to configure and use Swagger module
    /// </summary>
    public static class SwaggerExtension
    {
        #region Fields

        private const string SpecificationsToken = "Swagger:Specifications";

        private static IList<OpenApiInfo> Specifications { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Get the endpoint from the OpenApiInfo data
        /// </summary>
        /// <param name="apiInfo">OpenApiInfo instance</param>
        /// <returns>Endpoint created</returns>
        private static string GetEndpoint(this OpenApiInfo apiInfo) => $"/swagger/{apiInfo.Version}/swagger.json";

        /// <summary>
        /// Configure specifications for the Swagger module
        /// </summary>
        /// <param name="services">Collection to register services</param>
        /// <param name="configuration">Configuration file loaded with settings</param>
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            Specifications = configuration.GetSection(SpecificationsToken).Get<IList<OpenApiInfo>>();
            if (Specifications is null) return;

            services.AddSwaggerGen(options =>
            {
                foreach (var specification in Specifications)
                    options.SwaggerDoc(specification.Version, specification);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Add specifications to the Swagger module
        /// </summary>
        /// <param name="app">Interface for application builder</param>
        public static void UseSwaggerModule(this IApplicationBuilder app)
        {
            if (Specifications is null) return;

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var specification in Specifications)
                    options.SwaggerEndpoint(specification.GetEndpoint(), specification.Title);
            });
        }

        #endregion
    }
}