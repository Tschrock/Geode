// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// A connection status.
    /// </summary>
    public class ConnectionStatus : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStatus"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public ConnectionStatus(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="ConnectionStatus"/> is active.
        /// </summary>
        /// <value>A <see cref="bool"/> value that indicating whether the <see cref="ConnectionStatus"/> is active.</value>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the name of the <see cref="ConnectionStatus"/>.
        /// </summary>
        /// <value>A <see cref="string"/> value.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the <see cref="ConnectionStatus"/>.
        /// </summary>
        /// <value>A <see cref="string"/> value describing the <see cref="ConnectionStatus"/>.</value>
        public string Description { get; set; }
    }
}
