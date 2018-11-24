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
        [Fact]
        public void TestHappyPath()
        {
            var graph = new Dictionary<char, List<char>>
            {
                //{'a', new List<char> {'c'}},
                //{'b', new List<char> {'d', 'e'}},
                //{'c', new List<char> {'d'}},
                //{'d', new List<char> {'f'}},
                //{'e', new List<char> {'f'}},
                //{'f', new List<char> {'g'}},
                {'a', new List<char> {'c'}},
                {'b', new List<char> {'d', 'c'}},
                {'c', new List<char> {'e'}},
                {'d', new List<char> {'f'}},
                {'e', new List<char> {'h', 'f'}},
                {'f', new List<char> {'g'}},
                {'g', new List<char>()},
                {'h', new List<char>()},
            };

            var actual = GetTopologicallySorted(graph);
            //var expected = new [] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            var expected = new [] { 'b', 'd', 'a', 'c', 'e', 'f', 'g', 'h' };
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
