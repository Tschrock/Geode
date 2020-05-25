// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Geode.Web.Routing
{
    /// <summary>
    /// Contains extension methods for using Geode with <see cref="IServiceCollection"/>.
    /// </summary>
    public static class GeodeServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services for pages to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        public static void AddGeode(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddSingleton<GeodeEndpointDataSource>();
        }
    }
}
