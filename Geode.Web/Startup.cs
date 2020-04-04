// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Geode.Data;
using Geode.Utility;
using Geode.Web.Configuration;

namespace Geode.Web
{
    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the Razor Pages service
            services.AddRazorPages();

            // If HSTS is enabled
            var hstsConfig = this.Configuration.GetSection("HSTS");
            if (hstsConfig.GetValue("Enable", true))
            {
                // Add the HSTS configuration
                services.AddHsts(options =>
                {
                    options.Preload = hstsConfig.GetValue("Preload", false);
                    options.IncludeSubDomains = hstsConfig.GetValue("IncludeSubDomains", false);
                    options.MaxAge = TimeSpan.FromSeconds(hstsConfig.GetValue("MaxAge", 60));
                    options.ExcludedHosts.AddRange(hstsConfig.GetValue("ExcludedHosts", Array.Empty<string>()));
                });
            }

            // If HTTPS Redirection is enabled
            var httpsConfig = this.Configuration.GetSection("RedirectHTTPS");
            if (httpsConfig.GetValue("Enable", true))
            {
                // Add the HTTPS Redirection configuration
                services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = httpsConfig.GetValue("RedirectStatusCode", StatusCodes.Status308PermanentRedirect);
                    options.HttpsPort = httpsConfig.GetValue<int?>("HttpsPort", null);
                });
            }

            // Add the Database Context
            var connectionString = this.Configuration.GetConnectionString("GeodeContext");
            services.AddDbContext<GeodeContext>(options => options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web host environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // If HSTS is enabled
            if (this.Configuration.GetValue("HSTS:Enable", true))
            {
                app.UseHsts();
            }

            // If HTTPS Redirection is enabled
            if (this.Configuration.GetValue("RedirectHTTPS:Enable", true))
            {
                app.UseHttpsRedirection();
            }

            // If WWW Redirection is enabled
            var wwwConfig = this.Configuration.GetSection("RedirectWWW");
            if (wwwConfig.GetValue("Enable", true))
            {
                var options = new RewriteOptions();
                options.Add(new RedirectWwwRule(
                    wwwConfig.GetValue("Action", RedirectWwwRule.Action.Remove),
                    wwwConfig.GetValue("RedirectStatusCode", StatusCodes.Status308PermanentRedirect)));
                app.UseRewriter(options);
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
