
using System;

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
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets
        /// </summary>
        /// <value></value>
        public string Value { get; set; } = "";

    }
}
