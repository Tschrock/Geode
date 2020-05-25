// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;

namespace Geode.Models
{
    /// <summary>
    /// A block for Geode's CMS system.
    /// </summary>
    public class Block : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="page">The Page the block is on.</param>
        /// <param name="zone">The zone the block is in.</param>
        /// <param name="order">The order of the block.</param>
        /// <param name="name">The name of the block.</param>
        /// <param name="blockTypeName">The type of the block.</param>
        public Block(Page page, string zone, int order, string name, string blockTypeName)
        {
            this.Page = page;
            this.Zone = zone;
            this.Order = order;
            this.Name = name;
            this.BlockTypeName = blockTypeName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// Private constructor for Entity Framework.
        /// </summary>
        private Block()
        {
            this.Page = null!;
        }

        /// <summary>
        /// Gets or sets the name of the block. This is used in the CMS management UI and may also be displayed as part of a block's content.
        /// </summary>
        /// <value>A <see cref="string"/> value to use as the name of the block.</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the <see cref="Type"/> that should be used to render this block.
        /// </summary>
        /// <value>A <see cref="string"/> value indicating the type that should be used to render this block.</value>
        public string BlockTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the <see cref="Type"/> that should be used to render this block.
        /// </summary>
        /// <returns>A <see cref="Type"/> that should be used to render this block.</returns>
        public Type? BlockType
        {
            get { return Type.GetType(this.BlockTypeName); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Models.Page"/> the block is on.
        /// </summary>
        /// <value>The <see cref="Models.Page"/> the block is on.</value>
        public Page Page { get; set; }

        /// <summary>
        /// Gets or sets the Page Zone the block is in.
        /// </summary>
        /// <value>A <see cref="string"/> value that names the zone where the block should be placed.</value>
        public string Zone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>An <see cref="int"/> value describing the block's order in relation to other blocks in the same zone.</value>
        public int Order { get; set; } = 0;
    }
}
