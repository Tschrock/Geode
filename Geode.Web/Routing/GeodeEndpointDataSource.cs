// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

using Geode.Models;
using Geode.Data;

namespace Geode.Web.Routing
{
    /// <summary>
    /// An EndpointDataSource for the Geode's CMS framework.
    /// </summary>
    public sealed class GeodeEndpointDataSource : EndpointDataSource, IEndpointConventionBuilder, IDisposable
    {
        private readonly GeodeChangeTokenSource changeTokenSource = new GeodeChangeTokenSource();

        private readonly List<SiteRoute> pageRouteCache = new List<SiteRoute>();

        private readonly List<Action<EndpointBuilder>> conventions = new List<Action<EndpointBuilder>>();

        private readonly IServiceScopeFactory scopeFactory;

        public GeodeEndpointDataSource(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        private void UpdateEndpoints()
        {
            using var scope = this.scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GeodeContext>();
        }

        /// <inheritdoc/>
        public override IReadOnlyList<Endpoint> Endpoints => throw new System.NotImplementedException();

        /// <inheritdoc/>
        public void Add(Action<EndpointBuilder> convention)
        {
            this.conventions.Add(convention);
        }

        /// <inheritdoc/>
        public override IChangeToken GetChangeToken() => this.changeTokenSource.Token;

        /// <inheritdoc/>
        public void Dispose()
        {
            this.changeTokenSource.Dispose();
        }
    }
}
