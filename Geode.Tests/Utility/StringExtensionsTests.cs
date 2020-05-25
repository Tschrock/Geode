// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;

using Xunit;

using Geode.Utility;

namespace Geode.Tests
{
    /// <summary>
    /// Contains tests for the <see cref="StringExtensions"/> class.
    /// </summary>
    public class StringExtensionsTests
    {
        /// <summary>
        /// Tests that <see cref="StringExtensions.ToCssClass"/> returns the expected results.
        /// </summary>
        /// <param name="testString">The string to test.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Theory(DisplayName = "ToCssClass returns expected results")]
        [InlineData("Test", "test")]
        [InlineData("Test A", "test-a")]
        [InlineData("Test#3.8^BETA", "test-3-8-beta")]
        public void ToCssClassReturnsExpectedResults(string testString, string expectedResult)
        {
            string result = StringExtensions.ToCssClass(testString);

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Tests that <see cref="StringExtensions.ToCssClass"/> throws on null values.
        /// This shouldn't happen within the project, but external code may attempt to use it on a null value.
        /// </summary>
        [Fact(DisplayName = "ToCssClass throws on null values")]
        public void ToCssClassThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => StringExtensions.ToCssClass(null!));
        }
    }
}
