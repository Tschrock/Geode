// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// A layout for Geode's CMS system.
    /// </summary>
    public class Layout : Entity
    {
        /// <summary>
        /// Gets or sets the name of the layout. This is used in the CMS management UI.
        /// </summary>
        /// <value>A <see cref="string"/> value used as the name of the block.</value>
        public string Name { get; set; } = string.Empty;
    }
}
