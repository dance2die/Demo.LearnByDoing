using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    public class BfsGraphTraversalTest : BaseTest
    {
        public BfsGraphTraversalTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [MemberData(nameof(GetBfsData))]
        public static void TestBfs(Dictionary<char, List<char>> graph, char[] expected)
        {
            var actual = TraverseBfs(graph).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        private static IEnumerable<char> TraverseBfs(Dictionary<char, List<char>> graph)
        {
            var q = new Queue<char>();
            var visited = new HashSet<char>();

            q.Enqueue('a');
            visited.Add('a');

            while (q.Count > 0)
            {
                var v = q.Dequeue();
                foreach (var neighbor in graph[v])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        q.Enqueue(neighbor);
                    }
                }
            }

            return visited;
        }

        public static IEnumerable<object[]> GetBfsData()
        {
            yield return new object[] {GetAdjanceDictionary(), new [] {'a', 'b', 'd', 'g', 'e', 'f', 'c', 'h'}};
        }

        public static Dictionary<char, List<char>> GetAdjanceDictionary()
        {
            return new Dictionary<char, List<char>>
            {
                {'a', new List<char> {'b', 'd', 'g'}},
                {'b', new List<char> {'e', 'f'}},
                {'e', new List<char> {'b', 'g'}},
                {'g', new List<char> {'a', 'e'}},
                {'d', new List<char> {'a', 'f'}},
                {'f', new List<char> {'b', 'd', 'c'}},
                {'c', new List<char> {'f', 'h'}},
                {'h', new List<char> {'c'}},
            };
        }
    }
}
