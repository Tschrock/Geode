// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// An email address.
    /// </summary>
    public class Email : Entity
    {
        /// <summary>
        /// Gets or sets a value indicating whether the email is active.
        /// </summary>
        /// <value>A <see cref="bool"/> value that indicating whether the email is active.</value>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the email value.
        /// </summary>
        /// <value>A <see cref="string"/> value that contains the email address.</value>
        public string Value { get; set; } = string.Empty;
    }
}
