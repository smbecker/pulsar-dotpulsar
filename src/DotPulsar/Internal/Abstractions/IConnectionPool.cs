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

namespace DotPulsar.Internal.Abstractions;

using DotPulsar.Internal.PulsarApi;
using System.Text.RegularExpressions;

public interface IConnectionPool : IAsyncDisposable
{
    ValueTask<IConnection> FindConnectionForTopic(string topic, CancellationToken cancellationToken = default);

    ValueTask<uint> GetNumberOfPartitions(string topic, CancellationToken cancellationToken = default);

    ValueTask<IEnumerable<string>> GetTopicsOfNamespace(CommandGetTopicsOfNamespace.Mode mode, Regex topicsPattern, CancellationToken cancellationToken = default);
}
