

using System;

namespace Geode.Models
{
    /// <summary>
    /// A block for Geode's CMS system.
    /// </summary>
    public class Entity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
