using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Geode.Data;

namespace Geode.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build the web host
            var host = CreateHostBuilder(args).Build();

            // Make sure the database exists
            CreateDbIfNotExists(host);

            // Run the app
            host.Run();
        }

        /// <summary>
        /// Creates a host builder.
        /// </summary>
        /// <param name="args">The program arguments</param>
        /// <returns>A host builder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) {

            // Create the Builder
            var hostBuilder = Host.CreateDefaultBuilder(args);

            // Configure defaults
            hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                // Use Geode.Web.Startup as the startup class
                webBuilder.UseStartup<Startup>();
            });

            // Return the builder
            return hostBuilder;
        }

        /// <summary>
        /// Attempts to create the database if it doesn't exist.
        /// </summary>
        /// <param name="host">The host</param>
        private static void CreateDbIfNotExists(IHost host)
        {
            // Create a new service scope
            using (var scope = host.Services.CreateScope())
            {
                // Get the services provider
                var services = scope.ServiceProvider;

                try
                {
                    // Get a GeodeContext
                    var context = services.GetRequiredService<GeodeContext>();

                    // Make sure the database is created and initialized
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    // Get the logger service
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    // Log the error
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
