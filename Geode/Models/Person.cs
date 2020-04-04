// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Geode.Models
{
    /// <summary>
    /// A Person.
    /// </summary>
    public class Person : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="connectionStatus">The person's connection status.</param>
        public Person(ConnectionStatus connectionStatus)
        {
            this.ConnectionStatus = connectionStatus;
        }

        // Names are hard: https://www.w3.org/International/questions/qa-personal-names

        // Americanized Name - The name is split into it's various parts.

        /// <summary>
        /// Gets or sets the prefix for the person's name (Like Mr, Mrs, Ms, Dr).
        /// </summary>
        public string Prefix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first part of the person's name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the middle part of the person's name.
        /// </summary>
        public string MiddleName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last part of the person's name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name the person prefers using in casual conversation.
        /// </summary>
        public string NickName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the suffix for the person's name (Like Jr, III, Esq).
        /// </summary>
        public string Suffix { get; set; } = string.Empty;

        // International-Friendly Name - The full name is stored with use-based variants.

        /// <summary>
        /// Gets or sets the person's full legal name. Used in legal settings like background checks.
        /// </summary>
        public string LegalName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the person's preferred full name. Used in formal and technical settings like showing them in a list.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the person's preferred short name. Used in informal settings like sending an email.
        /// </summary>
        public string ShortName { get; set; } = string.Empty;

        // Birth Info

        /// <summary>
        /// Gets or sets the year the person was born.
        /// </summary>
        public int? BirthYear { get; set; } = null;

        /// <summary>
        /// Gets or sets the month the person was born.
        /// </summary>
        public int? BirthMonth { get; set; } = null;

        /// <summary>
        /// Gets or sets the day the person was born.
        /// </summary>
        public int? BirthDay { get; set; } = null;

        // Deceased Info

        /// <summary>
        /// Gets or sets a value indicating whether the person is deceased.
        /// </summary>
        public bool IsDeceased { get; set; } = false;

        /// <summary>
        /// Gets or sets the year the person died.
        /// </summary>
        public int? DeceasedYear { get; set; } = null;

        /// <summary>
        /// Gets or sets the month the person died.
        /// </summary>
        public int? DeceasedMonth { get; set; } = null;

        /// <summary>
        /// Gets or sets the day of the month the person died.
        /// </summary>
        public int? DeceasedDay { get; set; } = null;

        // Current Status

        /// <summary>
        /// Gets or sets the connection status of the person.
        /// </summary>
        /// <value>A <see cref="ConnectionStatus"/> value.</value>
        public ConnectionStatus ConnectionStatus { get; set; }
    }
}
