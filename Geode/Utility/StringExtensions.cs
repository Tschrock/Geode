// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Geode.Utility
{
    /// <summary>
    /// Contains extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The Regex for <see cref="ToCssClass"/>.
        /// </summary>
        private static readonly Regex ToCssClassRegex = new Regex(@"[^a-zA-Z0-9]");

        /// <summary>
        /// Converts a string to a valid CSS class.
        /// This is done by converting it to lowercase and replacing all non-alphanumeric characters with a dash.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The value as a CSS class.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "It's a GUID")]
        public static string ToCssClass(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return ToCssClassRegex.Replace(value.ToLowerInvariant(), "-");
        }
    }
}
