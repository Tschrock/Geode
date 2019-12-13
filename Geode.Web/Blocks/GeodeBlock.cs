using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;

namespace Geode.Web.Blocks
{
    /// <summary>
    /// The base class for all web-content blocks in Geode's CMS system.
    /// </summary>
    public abstract class GeodeBlock : ViewComponent
    {
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
