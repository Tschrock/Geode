
using System;

namespace Geode.Models
{
    /// <summary>
    /// A Person.
    /// </summary>
    public class Person : Entity
    {

        // Names are hard: https://www.w3.org/International/questions/qa-personal-names

        /**
         * Americanized - The name is split into it's various parts. This is what most sites use.
         */

        /// <summary>
        /// The prefix for the person's name (Like Mr, Mrs, Ms, Dr).
        /// </summary>
        public string Prefix { get; set; } = "";

        /// <summary>
        /// The first part of the person's name.
        /// </summary>
        public string FirstName { get; set; } = "";

        /// <summary>
        /// The middle part of the person's name.
        /// </summary>
        public string MiddleName { get; set; } = "";

        /// <summary>
        /// The last part of the person's name.
        /// </summary>
        public string LastName { get; set; } = "";

        /// <summary>
        /// The name the person prefers using in casual conversation.
        /// </summary>
        public string NickName { get; set; } = "";

        /// <summary>
        /// The suffix for the person's name (Like Jr, III, Esq).
        /// </summary>
        public string Suffix { get; set; } = "";

        /**
         * International-friendly - the full name is stored with use-based variants.
         */

        /// <summary>
        /// The person's full legal name. Used in legal settings like background checks.
        /// </summary>
        public string LegalName { get; set; } = "";

        /// <summary>
        /// The person's preferred full name. Used in formal and technical settings like showing them in a list.
        /// </summary>
        public string FullName { get; set; } = "";

        /// <summary>
        /// The person's preferred short name. Used in informal settings like sending an email.
        /// </summary>
        public string ShortName { get; set; } = "";

        /// <summary>
        /// The year the person was born.
        /// </summary>
        public int? BirthYear { get; set; } = null;

        /// <summary>
        /// The month the person was born.
        /// </summary>
        public int? BirthMonth { get; set; } = null;

        /// <summary>
        /// The day of the month the person was born.
        /// </summary>
        public int? BirthDay { get; set; } = null;

        /// <summary>
        /// If the person is deceased.
        /// </summary>
        public bool IsDeceased { get; set; } = false;

        /// <summary>
        /// The year the person died.
        /// </summary>
        public int? DeceasedYear { get; set; } = null;

        /// <summary>
        /// The month the person died.
        /// </summary>
        public int? DeceasedMonth { get; set; } = null;

        /// <summary>
        /// The day of the month the person died.
        /// </summary>
        public int? DeceasedDay { get; set; } = null;

    }
}
