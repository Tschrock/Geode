using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Geode.Models;

namespace Geode.ViewComponents
{
    public class Zone : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            // TODO: Get the zone's blocks from the database/cache
            IEnumerable<Block> blocks;
            switch (name)
            {
                case "Feature":
                    blocks = new Block[] { new Block() };
                    break;
                case "Main":
                    blocks = new Block[] { new Block() };
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
