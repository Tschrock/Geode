using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;
using Geode.Web;

namespace Geode.Web.Blocks.Cms
{
    /// <summary>
    /// A block that shows HTML content.
    /// </summary>
    public class HtmlContentDetail : GeodeWebBlock
    {
        /// <summary>
        /// Renders the web block.
        /// </summary>
        /// <returns>A Task containing the result of rendering the web block.</returns>
        public override async Task<IViewComponentResult> Render()
        {
            Console.WriteLine(this.Block.Name);
            return this.View("/Blocks/Cms/HtmlContentDetail.cshtml", new Model
            {
                Title = this.Block.Name,
                Content = "<p>Hello World</p>",
            });
        }

        /// <summary>
        /// The model for rendering the <see cref="HtmlContentDetail"/>.
        /// </summary>
        internal class Model
        {
            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            public string Title { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the content.
            /// </summary>
            public string Content { get; set; } = string.Empty;
        }

    }
}
