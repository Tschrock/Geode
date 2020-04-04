// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// A domain name for Geode's CMS system.
    /// </summary>
    public class SiteDomain : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDomain"/> class.
        /// </summary>
        /// <param name="site">The <see cref="Site"/>.</param>
        /// <param name="value">The domain name.</param>
        public SiteDomain(Site site, string value)
        {
            this.Site = site;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the site.
        /// </summary>
        public Site Site { get; set; }

        /// <summary>
        /// Gets or sets the domain name.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int Order { get; set; } = 0;
    }
}
