using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Tushar Roy
    /// https://www.youtube.com/watch?v=ddTC4Zovtbc
    /// </summary>
    public class TopologicalSortTest
    {
        public static IEnumerable<object[]> GetGraphs()
        {
            yield return new object[]
            {
                new[] {'b', 'd', 'a', 'c', 'e', 'f', 'g', 'h'},
                new Dictionary<char, List<char>>
                {
                    {'a', new List<char> {'c'}},
                    {'b', new List<char> {'d', 'c'}},
                    {'c', new List<char> {'e'}},
                    {'d', new List<char> {'f'}},
                    {'e', new List<char> {'h', 'f'}},
                    {'f', new List<char> {'g'}},
                    {'g', new List<char>()},
                    {'h', new List<char>()},
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void TestRecursiveTopologicalSort(char[] expected, Dictionary<char, List<char>> graph)
        {
            var actual = GetTopologicallySorted(graph);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<char> GetTopologicallySorted(Dictionary<char, List<char>> g)
        {
            var visited = new HashSet<char>();
            var sorted = new Stack<char>();

            foreach (var node in g.Keys)
            {
                if (visited.Contains(node)) continue;

                DepthFirstSearchNeighbors(g, node, visited, sorted);
            }

            return sorted;
        }

        private void DepthFirstSearchNeighbors(Dictionary<char, List<char>> g, char node,
            HashSet<char> visited, Stack<char> sorted)
        {
            visited.Add(node);
            if (!g.ContainsKey(node)) return;

            foreach (var neighbor in g[node])
            {
                if (visited.Contains(neighbor)) continue;

                DepthFirstSearchNeighbors(g, neighbor, visited, sorted);
            }

            sorted.Push(node);
        }
    }
}
