// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Geode.Web.Routing
{
    /// <summary>
    /// Contains extension methods for using Geode with <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    public static class GeodeEndpointRouteBuilderExtensions
    {
        /// <summary>
        /// Adds endpoints for Geode to the <see cref="IEndpointRouteBuilder"/>.
        /// </summary>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>An <see cref="PageActionEndpointConventionBuilder"/> for endpoints associated with Geode.</returns>
        public static IEndpointConventionBuilder MapGeode(this IEndpointRouteBuilder endpoints)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            EnsureGeodeServices(endpoints);

            return GetOrCreateDataSource(endpoints);
        }

        private static void EnsureGeodeServices(IEndpointRouteBuilder endpoints)
        {
            var marker = endpoints.ServiceProvider.GetService<GeodeEndpointDataSource>();
            if (marker == null)
            {
                throw new InvalidOperationException($"Unable to find the required services. Please add all the required services by calling '{nameof(IServiceCollection)}.AddGeode' inside the call to 'ConfigureServices(...)' in the application startup code.");
            }
        }

        private static GeodeEndpointDataSource GetOrCreateDataSource(IEndpointRouteBuilder endpoints)
        {
            var dataSource = endpoints.DataSources.OfType<GeodeEndpointDataSource>().FirstOrDefault();
            if (dataSource == null)
            {
                dataSource = endpoints.ServiceProvider.GetRequiredService<GeodeEndpointDataSource>();
                endpoints.DataSources.Add(dataSource);
            }

            return dataSource;
        }
    }
}
