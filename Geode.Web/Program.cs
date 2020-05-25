// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Geode.Data;

namespace Geode.Web
{
    /// <summary>
    /// The main program.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// The main entry point of the program.
        /// </summary>
        /// <param name="args">The arguments passed to the program.</param>
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
        /// /// <param name="args">The program arguments.</param>
        /// <returns>A host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
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
        /// <param name="host">The host.</param>
        private static void CreateDbIfNotExists(IHost host)
        {
            // Create a new service scope
            using var scope = host.Services.CreateScope();

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

                // Rethrow
                throw;
            }
        }
    }
}
