// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// A page route for Geode's CMS system.
    /// </summary>
    public class SiteRoute : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteRoute"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="value">The route.</param>
        public SiteRoute(Page page, string value)
        {
            this.Page = page;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteRoute"/> class.
        /// Private constructor for Entity Framework.
        /// </summary>
        private SiteRoute()
        {
            this.Page = null!;
        }

        /// <summary>
        /// Gets or sets the <see cref="Page"/>.
        /// </summary>
        public Page Page { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}
