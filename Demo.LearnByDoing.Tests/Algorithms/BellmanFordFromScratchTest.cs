using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Demo.LearnByDoing.Core.Graph;
using Demo.LearnByDoing.General.Algorithms.Graph;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// Implement Bellman-Ford from scratch
    /// 
    /// OverView: https://www.youtube.com/watch?v=obWXjtg0L64&t=139s
    /// Implementation: https://www.youtube.com/watch?v=-mOEd_3gTK0
    /// </summary>
    public class BellmanFordFromScratchTest
    {
        [Theory]
        [MemberData(nameof(GetSamples))]
        void TestSamplesForShortestPath(BellmanFordPaths expected, Graph<char> graph)
        {
            var actual = GetShortestPaths(graph);

            Assert.True(expected.ShortestPaths.SequenceEqual(actual.ShortestPaths));
            Assert.True(expected.Parents.SequenceEqual(actual.Parents));
        }

        private BellmanFordPaths GetShortestPaths(Graph<char> graph)
        {
            throw new NotImplementedException();
        }

        class BellmanFordPaths
        {
            public Dictionary<Node<char>, int> ShortestPaths { get; set; }
            public Dictionary<Node<char>, Node<char>> Parents { get; set; }
        }

        public static IEnumerable<object[]> GetSamples()
        {
            var s = new Node<char>('S');
            var a = new Node<char>('A');
            var b = new Node<char>('B');
            var c = new Node<char>('C');
            var d = new Node<char>('D');
            var e = new Node<char>('E');

            var g1 = new Graph<char>();
            g1.AddVertex(s, new[] { new Edge<char>(10, a), new Edge<char>(8, e) });
            g1.AddVertex(a, new[] { new Edge<char>(2, c) });
            g1.AddVertex(b, new[] { new Edge<char>(1, a) });
            g1.AddVertex(c, new[] { new Edge<char>(-2, b) });
            g1.AddVertex(d, new[] { new Edge<char>(-1, c), new Edge<char>(-4, a) });
            g1.AddVertex(e, new[] { new Edge<char>(1, d) });

            yield return new object[]
            {
                new BellmanFordPaths
                {
                    ShortestPaths = new Dictionary<Node<char>, int>
                    {
                        {new Node<char>('S'), 0},{new Node<char>('A'), 5},{new Node<char>('B'), 5},
                        {new Node<char>('C'), 7},{new Node<char>('D'), 9},{new Node<char>('E'), 8},
                    },
                    Parents = new Dictionary<Node<char>, Node<char>>
                    {
                        { d, a }, { c, b }, { a, c }, { e, d }, { s,e }
                    }
                },g1
            };
        }
    }
}
