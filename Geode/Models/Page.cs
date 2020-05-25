// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace Geode.Models
{
    /// <summary>
    /// A page for Geode's CMS system.
    /// </summary>
    public class Page : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="site">The Site for the page.</param>
        /// <param name="layout">The Layout for the page.</param>
        public Page(Site site, Layout layout)
        {
            this.Site = site;
            this.Layout = layout;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// Private constructor for Entity Framework.
        /// </summary>
        private Page()
        {
            this.Site = null!;
            this.Layout = null!;
        }

        /// <summary>
        /// Gets or sets the internal name of the page. This is used in the CMS management UI.
        /// </summary>
        public string InternalName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the browser title for the page. This is used as the title of the page in the browser.
        /// </summary>
        public string BrowserTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the page title of the page. This is used in the page content if the current theme and layout support it.
        /// </summary>
        public string PageTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the page. This is used in the CMS management UI and may be used by Themes in some places.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Site the page is a part of.
        /// </summary>
        public Site Site { get; set; }

        /// <summary>
        /// Gets or sets the layout to use on the page.
        /// </summary>
        public Layout Layout { get; set; }

        /// <summary>
        /// Gets the routes used by the page.
        /// </summary>
        public List<SiteRoute> Routes { get; private set; } = new List<SiteRoute>();
    }
}
