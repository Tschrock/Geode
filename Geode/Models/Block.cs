

using System;

namespace Geode.Models
{
    /// <summary>
    /// A block for Geode's CMS system.
    /// </summary>
    public class Block : Entity
    {
        public string Name { get; set; }
        public string BlockTypeName { get; set; }
        public Type? BlockType { get { return Type.GetType(this.BlockTypeName); } }
        public Block(string Name, string BlockTypeName)
        {
            this.Name = Name;
            this.BlockTypeName = BlockTypeName;
        }
    }
}
