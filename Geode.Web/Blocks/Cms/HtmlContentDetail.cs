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
            return View("/Blocks/Cms/HtmlContentDetail.cshtml", new Model { Title = this.Block.Name, Content = "<p>Hello World</p>" });
        }

        public class Model
        {
            public string Title { get; set; } = "";
            public string Content { get; set; } = "";
        }

    }
}
