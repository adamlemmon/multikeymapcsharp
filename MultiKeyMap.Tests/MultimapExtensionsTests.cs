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
using FluentAssertions;
using GitHub.Protobufel.MultiKeyMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiKeyMapTests
{
    [TestClass]
    public class MultiKeyMapExtensionsTests
    {
        [TestMethod]
        public void CopyFromMultiKeyMapToEmptyTest()
        {
            CopyFromMultiKeyMapToEmptyHelper<int, int[], string>(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 4, 5 } }, new[] { "1", "2", "3" });
            CopyFromMultiKeyMapToEmptyHelper<long, List<long>, bool>(new[]{ new List<long>(){ 1, 2 }, new List<long>(){ 3, 4 },
                new List<long>(){ 2, 4, 5 } }, new[] { true, false, true });
        }

        private void CopyFromMultiKeyMapToEmptyHelper<T, K, V>(K[] keys, V[] values) where K : class, IEnumerable<T>
        {
            var source = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);
            var target = MultiKeyMaps.CreateMultiKeyDictionary<T, K, V>();

            var result = MultiKeyMapCopyExtensions.CopyFrom(target, source);

            result.Should().NotBeNull().And.BeSameAs(target).And.Equal(source);
        }

        [TestMethod]
        public void CopyFromMultiKeyMapToDuplicateTest()
        {
            CopyFromMultiKeyMapToDuplicateHelper<int, int[], string>(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 4, 5 } }, new[] { "1", "2", "3" });
            CopyFromMultiKeyMapToDuplicateHelper<long, List<long>, bool>(new[]{ new List<long>(){ 1, 2 }, new List<long>(){ 3, 4 },
                new List<long>(){ 2, 4, 5 } }, new[] { true, false, true });
        }

        private void CopyFromMultiKeyMapToDuplicateHelper<T, K, V>(K[] keys, V[] values) where K : class, IEnumerable<T>
        {
            var source = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);
            var target = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);

            Action act = () => MultiKeyMapCopyExtensions.CopyFrom(target, source);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void CopyFromDictionaryToEmptyTest()
        {
            CopyFromDictionaryToEmptyHelper<int, int[], string>(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 4, 5 } }, new[] { "1", "2", "3" });
            CopyFromDictionaryToEmptyHelper<long, List<long>, bool>(new[]{ new List<long>(){ 1, 2 }, new List<long>(){ 3, 4 },
                new List<long>(){ 2, 4, 5 } }, new[] { true, false, true });
        }

        private void CopyFromDictionaryToEmptyHelper<T, K, V>(K[] keys, V[] values) where K : class, IEnumerable<T>
        {
            var source = TestHelpers.CreateDictionary<T, K, V>(keys, values);
            var target = MultiKeyMaps.CreateMultiKeyDictionary<T, K, V>();

            var result = MultiKeyMapCopyExtensions.CopyFrom(target, source);

            result.Should().NotBeNull().And.BeSameAs(target).And.Equal(source);
        }

        [TestMethod]
        public void CopyFromDictionaryToDuplicateTest()
        {
            CopyFromDictionaryToDuplicateHelper<int, int[], string>(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 4, 5 } }, new[] { "1", "2", "3" });
            CopyFromDictionaryToDuplicateHelper<long, List<long>, bool>(new[]{ new List<long>(){ 1, 2 }, new List<long>(){ 3, 4 },
                new List<long>(){ 2, 4, 5 } }, new[] { true, false, true });
        }

        private void CopyFromDictionaryToDuplicateHelper<T, K, V>(K[] keys, V[] values) where K : class, IEnumerable<T>
        {
            var source = TestHelpers.CreateDictionary<T, K, V>(keys, values);
            var target = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);

            Action act = () => MultiKeyMapCopyExtensions.CopyFrom(target, source);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void OfMultiKeyMapToDuplicateTest()
        {
            OfMultiKeyMapToDuplicateHelper<int, int[], string>(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 4, 5 } }, new[] { "1", "2", "3" });
            OfMultiKeyMapToDuplicateHelper<long, List<long>, bool>(new[]{ new List<long>(){ 1, 2 }, new List<long>(){ 3, 4 },
                new List<long>(){ 2, 4, 5 } }, new[] { true, false, true });
        }

        private void OfMultiKeyMapToDuplicateHelper<T, K, V>(K[] keys, V[] values) where K : class, IEnumerable<T>
        {
            var source = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);
            var target = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);

            var result = MultiKeyMapCopyExtensions.Of(target, source);
            result.Should().NotBeNull().And.BeSameAs(target).And.Equal(source);
        }

        [TestMethod]
        public void OfDictionaryToDuplicateTest()
        {
            OfDictionaryToDuplicateHelper<int, int[], string>(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 4, 5 } }, new[] { "1", "2", "3" });
            OfDictionaryToDuplicateHelper<long, List<long>, bool>(new[]{ new List<long>(){ 1, 2 }, new List<long>(){ 3, 4 },
                new List<long>(){ 2, 4, 5 } }, new[] { true, false, true });
        }

        private void OfDictionaryToDuplicateHelper<T, K, V>(K[] keys, V[] values) where K : class, IEnumerable<T>
        {
            var source = TestHelpers.CreateDictionary<T, K, V>(keys, values);
            var target = TestHelpers.CreateMultiKeyMap<T, K, V>(keys, values);

            var result = MultiKeyMapCopyExtensions.Of(target, source);
            result.Should().NotBeNull().And.BeSameAs(target).And.Equal(source);
        }
    }
}
