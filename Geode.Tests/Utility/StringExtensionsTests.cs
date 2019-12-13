using System;
using Xunit;

using Geode.Utility;

namespace Geode.Tests
{
    public class StringExtensionsTests
    {
        [Theory(DisplayName = "ToCssClass returns expected results")]
        [InlineData("Test", "test")]
        [InlineData("Test A", "test-a")]
        [InlineData("Test#3.8^BETA", "test-3-8-beta")]
        public void ToCssClassReturnsExpectedResults(string testString, string expectedResult)
        {
            string result = StringExtensions.ToCssClass(testString);

            Assert.Equal(result, expectedResult);
        }

    }
}
