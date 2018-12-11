using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    public class DijkstraRepriseTest : BaseTest
    {
        public DijkstraRepriseTest(ITestOutputHelper output) : base(output)
        {
        }
        
        [Fact]
        public void TestDijkstraHappyPath()
        {
            var g = new Dictionary<char, List<DijkstraEdge>>
            {
                {'a', new List<DijkstraEdge>
                {
                    new DijkstraEdge('a', 'd', 1),
                    new DijkstraEdge('a', 'b', 3),
                } },
                {'b', new List<DijkstraEdge>
                {
                    new DijkstraEdge('b', 'c', 1),
                    new DijkstraEdge('b', 'd', 3),
                } },
                {'c', new List<DijkstraEdge>
                {
                    new DijkstraEdge('c', 'b', 1),
                    new DijkstraEdge('c', 'd', 1),
                    new DijkstraEdge('c', 'f', 4),
                    new DijkstraEdge('c', 'e', 5),
                } },
                {'d', new List<DijkstraEdge>
                {
                    new DijkstraEdge('d', 'a', 3),
                    new DijkstraEdge('d', 'b', 3),
                    new DijkstraEdge('d', 'c', 1),
                    new DijkstraEdge('d', 'e', 6),
                } },
                {'e', new List<DijkstraEdge>
                {
                    new DijkstraEdge('e', 'd', 6),
                    new DijkstraEdge('e', 'c', 5),
                    new DijkstraEdge('e', 'f', 2),
                } },
                {'f', new List<DijkstraEdge>
                {
                    new DijkstraEdge('f', 'c', 4),
                    new DijkstraEdge('f', 'e', 2),
                } },
            };

            var actual = GetShortestPaths(g);
            Console.WriteLine(actual);
        }

        private bool GetShortestPaths(Dictionary<char,List<DijkstraEdge>> g)
        {
            throw new NotImplementedException();
        }
    }

    internal class DijkstraEdge
    {
        public char V1 { get; set; }
        public char V2 { get; set; }
        public int Weight { get; set; }

        public DijkstraEdge(char v1, char v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }
    }
}