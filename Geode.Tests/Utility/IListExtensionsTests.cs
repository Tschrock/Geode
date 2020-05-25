// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;

using Xunit;

using Geode.Utility;

namespace Geode.Utility
{
    /// <summary>
    /// Contains tests for the <see cref="IListExtensions"/> class.
    /// </summary>
    public class IListExtensionsTests
    {
        /// <summary>
        /// Tests that <see cref="IListExtensions.AddRange"/> returns the expected results.
        /// Note: <see cref="List{T}"/> can't be a const, so we can't use it as data for a Theory. So instead we'll manually check each test case.
        /// </summary>
        [Fact(DisplayName = "AddRange returns expected results")]
        public void AddRangeReturnsExpectedResults()
        {
            this.TestAddRangeReturnsExpectedResults(new List<int> { 1, 2 }, new int[] { 3, 4 }, new int[] { 1, 2, 3, 4 });
            this.TestAddRangeReturnsExpectedResults(new List<int> { }, new int[] { 3, 4 }, new int[] { 3, 4 });

            this.TestAddRangeReturnsExpectedResults(new List<int> { 1, 2 }, new int[] { }, new int[] { 1, 2 });
            this.TestAddRangeReturnsExpectedResults(new List<int> { }, new int[] { }, new int[] { });

            this.TestAddRangeReturnsExpectedResults(new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 1, 2, 3, 4 });
            this.TestAddRangeReturnsExpectedResults(new int[] { }, new int[] { 3, 4 }, new int[] { 1, 2, 3, 4 });

            this.TestAddRangeReturnsExpectedResults(new int[] { 1, 2 }, new int[] { }, new int[] { 1, 2 });
            this.TestAddRangeReturnsExpectedResults(new int[] { }, new int[] { }, new int[] { });
        }

        /// <summary>
        /// Tests that <see cref="IListExtensions.AddRange"/> thhrows the expected Exception.
        /// Note: <see cref="List{T}"/> can't be a const, so we can't use it as data for a Theory. So instead we'll manually check each test case.
        /// </summary>
        [Fact(DisplayName = "AddRange returns expected results")]
        public void AddRangeThrowsExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => IListExtensions.AddRange(null!, new int[] { }));
            Assert.Throws<ArgumentNullException>(() => IListExtensions.AddRange(new int[] { }, null!));
            Assert.Throws<ArgumentNullException>(() => IListExtensions.AddRange<int>(null!, null!));
        }

        /// <summary>
        /// Tests that <see cref="IListExtensions.AddRange"/> returns the expected results.
        /// </summary>
        /// <param name="testListA">The primary list.</param>
        /// <param name="testListB">The secondary list.</param>
        /// <param name="expectedResult">The expected result.</param>
        private void TestAddRangeReturnsExpectedResults<T>(IList<T> testListA, IEnumerable<T> testListB, IEnumerable expectedResult)
        {
            IListExtensions.AddRange(testListA, testListB);
            Assert.Equal(expectedResult, testListA);
        }
    }
}
