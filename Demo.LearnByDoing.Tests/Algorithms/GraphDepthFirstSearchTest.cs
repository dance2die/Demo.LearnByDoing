using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// http://techieme.in/depth-first-traversal/
    /// https://github.com/officialdharam/techieme/blob/master/graph-theory/DepthFirst.java
    /// </summary>
    public class GraphDepthFirstSearchTest
    {
        [Theory]
        [MemberData(nameof(GetAdjacencyLists))]
        public static void TestDfsHappyPath(int[] expected, Dictionary<int, int[]> graph)
        {
            int[] actual = DfsAdjacencyList(graph);
            Assert.True(expected.SequenceEqual(actual));
        }

        private static int[] DfsAdjacencyList(Dictionary<int, int[]> graph)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<object[]> GetAdjacencyLists()
        {
            yield return new object[]
            {
                new[] {1, 2, 3, 4, 7, 8, 6, 5, 9},
                new Dictionary<int, int[]>
                {
                    {1, new[] {2, 4, 7}},
                    {2, new[] {3}},
                    {3, new[] {4}},
                    {1, new[] {1}},
                    {7, new[] {8, 6}},
                    {6, new[] {5, 9}},
                    {6, new[] {9}},
                    {9, new[] {6}},
                }
            };
        }
    }
}
