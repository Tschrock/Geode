// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Geode.Models
{
    /// <summary>
    /// A generic entity.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Gets the Id of the entity.
        /// </summary>
        /// <value>An <see cref="int"/> value used as the unique key in the database.</value>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the Guid of the entity.
        /// </summary>
        /// <value>A <see cref="System.Guid"/> value that uniquely identifies the entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", Justification = "It's a GUID")]
        public Guid Guid { get; private set; }

        /// <summary>
        /// Gets or sets when the entity was created.
        /// </summary>
        /// <value>A <see cref="System.DateTime"/> value storing the date and time the entity was created.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the last time the entity was modified.
        /// </summary>
        /// <value>A <see cref="System.DateTime"/> value storing the date and time the entity was last modified.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifiedDateTime { get; set; }
    }
}
