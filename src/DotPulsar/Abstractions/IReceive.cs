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

namespace DotPulsar.Abstractions;

/// <summary>
/// An abstraction for receiving a single message.
/// </summary>
public interface IReceive<TMessage>
{
    /// <summary>
    /// Try to receive a single message from the buffer.
    /// </summary>
    /// <param name="message">The received message</param>
    /// <returns>true if successfully received message</returns>
    bool TryReceiveBuffered(out TMessage? message);

    /// <summary>
    /// Receive a single message.
    /// </summary>
    ValueTask<TMessage> Receive(CancellationToken cancellationToken = default);
}
