// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;

namespace Geode.Web.Blocks
{
    /// <summary>
    /// The base class for all web-content blocks in Geode's CMS system.
    /// </summary>
    public abstract class GeodeWebBlock : ViewComponent
    {
        /// <summary>
        /// Gets the underlying block data for this web block.
        /// </summary>
        /// <value>A <see cref="Models.Block"/> value containing the block data.</value>
        public Block? Block { get; internal set; }

        /// <summary>
        /// Renders the web block.
        /// </summary>
        /// <param name="block">The block data.</param>
        /// <returns>The rendered block.</returns>
        public Task<IViewComponentResult> InvokeAsync(Block block)
        {
            this.Block = block;
            return this.Render();
        }

        /// <summary>
        /// Renders the block.
        /// </summary>
        /// <returns>The rendered block.</returns>
        public abstract Task<IViewComponentResult> Render();
    }
}
