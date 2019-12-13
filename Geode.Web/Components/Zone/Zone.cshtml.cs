using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;
using Geode.Data;

namespace Geode.ViewComponents
{
    public class Zone : ViewComponent
    {
        private readonly GeodeContext _context;

        public Zone(GeodeContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name)
        {

            Console.WriteLine("Zone: " + name);
            // TODO: Get the zone's blocks from the database/cache
            IEnumerable<Block> blocks;
            switch (name)
            {
                case "Feature":
                    blocks = _context.Blocks;
                    break;
                case "Main":
                    blocks = new Block[] { new Block("Test Block 1", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web") };
                    break;
                default:
                    blocks = new Block[0];
                    break;
            }

            return View("/Components/Zone/Zone.cshtml", new Model(name, blocks));
        }

        public class Model
        {
            public string Name { get; set; }
            public IEnumerable<Block> Blocks { get; set; }
            public Model(string Name, IEnumerable<Block> Blocks)
            {
                this.Name = Name;
                this.Blocks = Blocks;
            }
        }

    }
}
