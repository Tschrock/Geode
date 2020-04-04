// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;

namespace Geode.Utility
{
    /// <summary>
    /// Contains extension methods for <see cref="IList"/>.
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="IList"/>.
        /// </summary>
        /// <param name="list">The <see cref="IList"/>.</param>
        /// <param name="collection">
        ///     The collection whose elements should be added to the end of the <see cref="IList"/>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.
        /// </param>
        /// <typeparam name="T">The type of the <see cref="IList"/>.</typeparam>
        /// <exception cref="ArgumentNullException">collection is null.</exception>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (list is List<T> asList)
            {
                asList.AddRange(collection);
            }
            else
            {
                foreach (var item in collection)
                {
                    list.Add(item);
                }
            }
        }
    }
}
