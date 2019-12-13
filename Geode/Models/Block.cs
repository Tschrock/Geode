

using System;

namespace Geode.Models
{
    /// <summary>
    /// A block for Geode's CMS system.
    /// </summary>
    public class Block
    {
        public string Name { get; set; }
        public Type BlockType { get; set; }
        public int Count { get; set; }
        public Block()
        {
            var blockType = Type.GetType("Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web");

            if (blockType == null) throw new Exception("Could not load block type");

            this.Name = "A Block";
            this.BlockType = blockType;
            this.Count = 10;
        }
    }
}
