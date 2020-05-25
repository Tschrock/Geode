// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Geode.Models
{
    /// <summary>
    /// A site for Geode's CMS system.
    /// </summary>
    public class Site : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Site"/> class.
        /// </summary>
        /// <param name="name">The name of the site.</param>
        public Site(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the name of the site. This is used in the CMS management UI and may be used in page content.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a list of domains that match this site.
        /// </summary>
        public IEnumerable<SiteDomain> Domains { get; private set; } = new List<SiteDomain>();
    }
}
