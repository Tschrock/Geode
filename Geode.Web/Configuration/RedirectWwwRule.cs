// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;

namespace Geode.Web.Configuration
{
    /// <summary>
    /// A rewrite rule to add or remove the "www." at the begining of hostnames.
    /// </summary>
    internal class RedirectWwwRule : IRule
    {
        /// <summary>
        /// The action to take.
        /// </summary>
        private readonly Action action;

        /// <summary>
        /// The status code to use when redirecting.
        /// </summary>
        private readonly int statusCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectWwwRule"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="statusCode">The status code.</param>
        public RedirectWwwRule(Action action, int statusCode)
        {
            this.action = action;
            this.statusCode = statusCode;
        }

        /// <summary>
        /// The type of action to take.
        /// </summary>
        public enum Action
        {
            /// <summary>
            /// Indicates that the rule should add "www." to the begining of hostnames.
            /// </summary>
            Add,

            /// <summary>
            /// Indicates that the rule should remove "www." from the begining of hostnames.
            /// </summary>
            Remove,
        }

        /// <summary>
        /// Sets up a redirect.
        /// </summary>
        /// <param name="context">The rewrite context.</param>
        /// <param name="newHost">The new host value.</param>
        /// <param name="statusCode">The status code to use.</param>
        public static void DoHostRedirect(RewriteContext context, string newHost, int statusCode)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            var newUrl = UriHelper.BuildAbsolute(
                request.Scheme,
                new HostString(newHost),
                request.PathBase,
                request.Path,
                request.QueryString);

            response.StatusCode = statusCode;
            response.Headers[HeaderNames.Location] = newUrl;
            context.Result = RuleResult.EndResponse;
        }

        /// <summary>
        /// Applies the rule to an HTTP request.
        /// </summary>
        /// <param name="context">The rewrite context for the HTTP request.</param>
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var host = request.Host.Value;

            var startsWithWWW = host.StartsWith("www.", StringComparison.OrdinalIgnoreCase);

            if (startsWithWWW && this.action == Action.Remove)
            {
                DoHostRedirect(context, host.Remove(0, 4), this.statusCode);
                return;
            }
            else if (!startsWithWWW && this.action == Action.Add)
            {
                DoHostRedirect(context, "www." + host, this.statusCode);
                return;
            }

            context.Result = RuleResult.ContinueRules;
        }
    }
}
