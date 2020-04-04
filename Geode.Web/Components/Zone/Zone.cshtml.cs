// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;
using Geode.Data;

namespace Geode.ViewComponents
{
    /// <summary>
    /// A zone that holds page blocks.
    /// </summary>
    public class Zone : ViewComponent
    {
        private readonly GeodeContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Zone"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Zone(GeodeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets or sets the name of the zone.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the blocks in the zone.
        /// </summary>
        public IEnumerable<Block> Blocks { get; set; } = Array.Empty<Block>();

        /// <summary>
        /// Renders the zone content.
        /// </summary>
        /// <param name="name">the name of the zone.</param>
        /// <returns>The zone content.</returns>
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            this.Blocks = this.context.Blocks.Where(b => b.Zone == name);
            this.Name = name;
            return this.View("/Components/Zone/Zone.cshtml", this);
        }
    }
}
