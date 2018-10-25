using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.LeetCode.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/lru-cache/description/
    /// </summary>
    public class LruCacheTest : BaseTest
    {
        private const int CACHE_SIZE = 3;

        public LruCacheTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetEmptyCache()
        {
            yield return new object[] { -1, new LRUCache(CACHE_SIZE) };
        }

        [Theory]
        [MemberData(nameof(GetEmptyCache))]
        public void TestGetEmpty(int expected, LRUCache emptyCache)
        {
            var actual = emptyCache.Get(111);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPutInEmptyCahce()
        {

        }

        [Fact]
        public void TestPutInNotFullCahce()
        {

        }

        [Fact]
        public void TestPutInFullCahce()
        {

        }

        [Fact]
        public void TestGetInCache()
        {

        }
    }

    public class LRUCache
    {
        private const int NOT_IN_CACHE = -1;
        private readonly Dictionary<int, LRUNode> _map;

        public int Capacity { get; set; }

        public LRUCache(int capacity)
        {
            Capacity = capacity;
            _map = new Dictionary<int, LRUNode>(capacity);
        }

        public int Get(int key)
        {
            if (!_map.ContainsKey(key)) return NOT_IN_CACHE;
            throw new NotImplementedException();
        }

        //public void Put(int key, int value)
        //{

        //}
    }

    public class LRUNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public LRUNode Previous { get; set; }
        public LRUNode Next { get; set; }
    }
}
