﻿/*
Copyright 2017 David Tesler

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;

namespace GitHub.Protobufel.MultiKeyMap
{
    /// <summary>
    /// Represents a generic IDictionary of composite keys and the methods to query it by any combination of sub-keys in any order.  
    /// </summary>
    /// <typeparam name="T">The type of sub-keys to query by and compose the full keys of</typeparam>
    /// <typeparam name="K">The type of the composite keys comprising some enumerable of sub-keys of type T</typeparam>
    /// <typeparam name="V">The type of values in the dictionary</typeparam>
    public interface IMultiKeyMap<T, K, V> : IDictionary<K, V> where K : class, IEnumerable<T>
    {
        /// <summary>
        /// Gets all values  for which their full keys contain the partial key set in any order.
        /// </summary>
        /// <param name="partialKey">The combination of the sub-keys to search for.</param>
        /// <param name="values">A non-live non-empty sequence of the values satisfying the partial key criteria, or the default value of the result type if not found.</param>
        /// <returns>true if the partial key is found, false otherwise.</returns>
        bool TryGetValuesByPartialKey(IEnumerable<T> partialKey, out IEnumerable<V> values);

        /// <summary>
        /// Gets all KeyValuePairs for which their full keys contain the partial key set in any order.
        /// </summary>
        /// <param name="partialKey">The combination of the sub-keys to search for.</param>
        /// <param name="entries">A non-live non-empty sequence of the KeyValuePair(-s) satisfying the partial key criteria, or the default value of the result type if not found.</param>
        /// <returns>true if the partial key is found, false otherwise.</returns>
        bool TryGetEntriesByPartialKey(IEnumerable<T> partialKey, out IEnumerable<KeyValuePair<K, V>> entries);

        /// <summary>
        /// Gets all full keys that contain the partial key set in any order.
        /// </summary>
        /// <param name="partialKey">The combination of the sub-keys to search for.</param>
        /// <param name="fullKeys">A non-live non-empty set of the full keys satisfying the partial key criteria, or the default value of the result type if not found.</param>
        /// <returns>true if the partial key is found, false otherwise.</returns>
        bool TryGetFullKeysByPartialKey(IEnumerable<T> partialKey, out IEnumerable<K> fullKeys);

        /// <summary>
        /// Gets all values  for which their full keys contain the partial key set in any order.
        /// </summary>
        /// <param name="partialKey">The list of the sub-keys to search for.</param>
        /// <param name="positions">The list of positions corresponding to the list of partialKey's sub-keys, wherein the negative position signifies non-positional 
        /// sub-key to search for anywhere within the full key, otherwise, its exact position within the full key. The size of this list can be smaller than 
        /// the partialKey list, meaning the rest of the partialKey sub-keys are non-positional.</param>
        /// <param name="values">A non-live non-empty sequence of the values satisfying the partial key criteria, or the default value of the result type if not found.</param>
        /// <returns>true if the partial key is found, false otherwise.</returns>
        bool TryGetValuesByPartialKey(IEnumerable<T> partialKey, IEnumerable<int> positions, out IEnumerable<V> values);

        /// <summary>
        /// Gets all KeyValuePairs for which their full keys contain the partial key set in any order.
        /// </summary>
        /// <param name="partialKey">The list of the sub-keys to search for.</param>
        /// <param name="positions">The list of positions corresponding to the list of partialKey's sub-keys, wherein the negative position signifies non-positional 
        /// sub-key to search for anywhere within the full key, otherwise, its exact position within the full key. The size of this list can be smaller than 
        /// the partialKey list, meaning the rest of the partialKey sub-keys are non-positional.</param>
        /// <param name="entries">A non-live non-empty sequence of the KeyValuePair(-s) satisfying the partial key criteria, or the default value of the result type if not found.</param>
        /// <returns>true if the partial key is found, false otherwise.</returns>
        bool TryGetEntriesByPartialKey(IEnumerable<T> partialKey, IEnumerable<int> positions, out IEnumerable<KeyValuePair<K, V>> entries);

        /// <summary>
        /// Gets all full keys that contain the partial key set in any order.
        /// </summary>
        /// <param name="partialKey">The list of the sub-keys to search for.</param>
        /// <param name="positions">The list of positions corresponding to the list of partialKey's sub-keys, wherein the negative position signifies non-positional 
        /// sub-key to search for anywhere within the full key, otherwise, its exact position within the full key. The size of this list can be smaller than 
        /// the partialKey list, meaning the rest of the partialKey sub-keys are non-positional.</param>
        /// <param name="fullKeys">A non-live non-empty set of the full keys satisfying the partial key criteria, or the default value of the result type if not found.</param>
        /// <returns>true if the partial key is found, false otherwise.</returns>
        bool TryGetFullKeysByPartialKey(IEnumerable<T> partialKey, IEnumerable<int> positions, out IEnumerable<K> fullKeys);
    }
}
