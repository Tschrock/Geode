// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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
        /// Renders the zone content.
        /// </summary>
        /// <param name="name">the name of the zone.</param>
        /// <returns>The zone content.</returns>
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            var blocks = this.context.Blocks.Where(b => b.Zone == name);
            return this.View("/Components/Zone/Zone.cshtml", new Model(name, blocks));
        }

        /// <summary>
        /// The model for rendering the zone.
        /// </summary>
        internal class Model
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Model"/> class.
            /// </summary>
            /// <param name="name">The zone name.</param>
            /// <param name="blocks">The zone blocks.</param>
            public Model(string name, IEnumerable<Block> blocks)
            {
                this.Name = name;
                this.Blocks = blocks;
            }

            /// <summary>
            /// Gets or sets the name of the zone.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the blocks in the zone.
            /// </summary>
            public IEnumerable<Block> Blocks { get; set; }
        }
    }
}
