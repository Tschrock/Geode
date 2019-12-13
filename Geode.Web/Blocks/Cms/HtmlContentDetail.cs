using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;
using Geode.Web;

namespace Geode.Web.Blocks.Cms
{
    public class HtmlContentDetail : GeodeBlock
    {
        public override async Task<IViewComponentResult> Render()
        {
            Console.WriteLine(this.Block.Name);
            return View("/Blocks/Cms/HtmlContentDetail.cshtml", "Hello World");
        }

    }
}
