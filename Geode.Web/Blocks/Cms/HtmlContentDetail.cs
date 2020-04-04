// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Geode.Web.Blocks.Cms
{
    /// <summary>
    /// A block that shows HTML content.
    /// </summary>
    public class HtmlContentDetail : GeodeWebBlock
    {
        /// <summary>
        /// Gets or sets the content to display.
        /// </summary>
        public string HtmlContent { get; set; } = "<p>Hello World</p>";

        /// <summary>
        /// Renders the web block.
        /// </summary>
        /// <returns>A Task containing the result of rendering the web block.</returns>
        public override async Task<IViewComponentResult> Render()
        {
            Console.WriteLine(this.Block.Name);
            return this.View("/Blocks/Cms/HtmlContentDetail.cshtml", this);
        }
    }
}
