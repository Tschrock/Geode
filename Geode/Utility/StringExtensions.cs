using System.Text.RegularExpressions;

namespace Geode.Utility
{
    public static class StringExtensions
    {

        private static Regex ToCssClassRegex = new Regex(@"[^a-zA-Z0-9]");

        /// <summary>
        /// Converts a string to a valid CSS class.
        /// This is done by converting it to lowercase and replacing all non-alphanumeric characters with a dash.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The value as a CSS class.</returns>
        public static string ToCssClass(this string value)
        {
            return ToCssClassRegex.Replace(value.ToLowerInvariant(), "-");
        }
    }

}
