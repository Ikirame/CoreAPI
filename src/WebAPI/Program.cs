using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    internal static class Program
    {
        #region Methods

        /// <summary>
        /// Entry point of an ASP.NET Core application.
        /// </summary>
        /// <param name="args">Array with command line arguments</param>
        internal static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Configure an ASP.NET Core application (logging, files, etc...).
        /// </summary>
        /// <param name="args">Array with command line arguments</param>
        /// <returns>Interface of the host created</returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        #endregion
    }
}