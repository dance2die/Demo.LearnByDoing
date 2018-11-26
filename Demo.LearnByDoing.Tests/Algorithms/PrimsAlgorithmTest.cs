using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// "Prim's Algorithm Minimum Spanning Tree Graph Algorithm" by Tushar Roy
    /// video: https://youtu.be/oP2-8ysT3QQ
    /// source: https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/PrimMST.java
    /// </summary>
    public class PrimsAlgorithmTest
    {
        [Fact]
        public void TestPrims()
        {
            var g = new Dictionary<char, List<Edge>>
            {
                {'a', new List<Edge>
                {
                    new Edge('a', 'd', 1),
                    new Edge('a', 'b', 3),
                } },
                {'b', new List<Edge>
                {
                    new Edge('b', 'c', 1),
                    new Edge('b', 'd', 3),
                } },
                {'c', new List<Edge>
                {
                    new Edge('c', 'b', 1),
                    new Edge('c', 'd', 1),
                    new Edge('c', 'f', 4),
                    new Edge('c', 'e', 5),
                } },
                {'d', new List<Edge>
                {
                    new Edge('d', 'a', 3),
                    new Edge('d', 'b', 3),
                    new Edge('d', 'c', 1),
                    new Edge('d', 'e', 6),
                } },
                {'e', new List<Edge>
                {
                    new Edge('e', 'd', 6),
                    new Edge('e', 'c', 5),
                    new Edge('e', 'f', 2),
                } },
                {'f', new List<Edge>
                {
                    new Edge('f', 'c', 4),
                    new Edge('f', 'e', 2),
                } },
            };

            var actual = GetMinimumSpanningTreeEdges(g);
            Console.WriteLine(actual);
        }

        private IEnumerable<Edge> GetMinimumSpanningTreeEdges(Dictionary<char, List<Edge>> g)
        {
            throw new NotImplementedException();
        }
    }

    internal class Edge
    {
        public char V1 { get; set; }
        public char V2 { get; set; }
        public int Weight { get; set; }

        public Edge(char v1, char v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }
    }
}
