// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Extensions.Primitives;

namespace Geode.Web.Routing
{
    /// <summary>
    /// Signals to a <see cref="IChangeToken"/> that a change has occured.
    /// </summary>
    public sealed class GeodeChangeTokenSource : IDisposable
    {
        private CancellationTokenSource? cancellationTokenSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeodeChangeTokenSource"/> class.
        /// </summary>
        public GeodeChangeTokenSource()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.Token = new CancellationChangeToken(this.cancellationTokenSource.Token);
        }

        /// <summary>
        /// Gets the change token.
        /// </summary>
        public IChangeToken Token { get; private set; }

        /// <summary>
        /// Notifies tokens of a change.
        /// </summary>
        public void NotifyChange()
        {
            var oldCancellationTokenSource = this.cancellationTokenSource;
            this.cancellationTokenSource = new CancellationTokenSource();
            this.Token = new CancellationChangeToken(this.cancellationTokenSource.Token);
            oldCancellationTokenSource?.Cancel();
            oldCancellationTokenSource?.Dispose();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.cancellationTokenSource?.Dispose();
            this.cancellationTokenSource = null;
        }
    }
}
