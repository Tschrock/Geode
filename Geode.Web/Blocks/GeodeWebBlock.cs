// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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

        public Task<IViewComponentResult> InvokeAsync(Block block)
        {
            this.Block = block;
            Console.WriteLine("BBBBBBBBBBBBBBB");
            return this.Render();
        }

        public abstract Task<IViewComponentResult> Render();

    }
}
