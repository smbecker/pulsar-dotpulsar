/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace DotPulsar.Extensions;

using DotPulsar.Abstractions;

/// <summary>
/// Extensions for IReader.
/// </summary>
public static class ReaderExtensions
{
    /// <summary>
    /// Wait for the state to change to a specific state.
    /// </summary>
    /// <returns>
    /// The current state.
    /// </returns>
    /// <remarks>
    /// If the state change to a final state, then all awaiting tasks will complete.
    /// </remarks>
    public static async ValueTask<ReaderStateChanged> StateChangedTo(this IReader reader, ReaderState state, CancellationToken cancellationToken = default)
    {
        var currentState = await reader.State.OnStateChangeTo(state, cancellationToken).ConfigureAwait(false);
        return new ReaderStateChanged(reader, currentState);
    }

    /// <summary>
    /// Wait for the state to change to a specific state with a delay.
    /// </summary>
    /// <returns>
    /// The current state.
    /// </returns>
    /// <remarks>
    /// If the state change to a final state, then all awaiting tasks will complete.
    /// </remarks>
    public static async ValueTask<ReaderStateChanged> StateChangedTo(this IReader reader, ReaderState state, TimeSpan delay, CancellationToken cancellationToken = default)
    {
        var currentState = await reader.State.OnStateChangeTo(state, delay, cancellationToken).ConfigureAwait(false);
        return new ReaderStateChanged(reader, currentState);
    }

    /// <summary>
    /// Wait for the state to change from a specific state.
    /// </summary>
    /// <returns>
    /// The current state.
    /// </returns>
    /// <remarks>
    /// If the state change to a final state, then all awaiting tasks will complete.
    /// </remarks>
    public static async ValueTask<ReaderStateChanged> StateChangedFrom(this IReader reader, ReaderState state, CancellationToken cancellationToken = default)
    {
        var currentState = await reader.State.OnStateChangeFrom(state, cancellationToken).ConfigureAwait(false);
        return new ReaderStateChanged(reader, currentState);
    }

    /// <summary>
    /// Wait for the state to change from a specific state with a delay.
    /// </summary>
    /// <returns>
    /// The current state.
    /// </returns>
    /// <remarks>
    /// If the state change to a final state, then all awaiting tasks will complete.
    /// </remarks>
    public static async ValueTask<ReaderStateChanged> StateChangedFrom(this IReader reader, ReaderState state, TimeSpan delay, CancellationToken cancellationToken = default)
    {
        var currentState = await reader.State.OnStateChangeFrom(state, delay, cancellationToken).ConfigureAwait(false);
        return new ReaderStateChanged(reader, currentState);
    }
}
