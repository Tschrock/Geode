// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// A page route for Geode's CMS system.
    /// </summary>
    public class PageRoute : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageRoute"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="value">The route.</param>
        public PageRoute(Page page, string value)
        {
            this.Page = page;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageRoute"/> class.
        /// Private constructor for Entity Framework.
        /// </summary>
        private PageRoute()
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
