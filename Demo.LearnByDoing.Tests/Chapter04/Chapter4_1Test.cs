using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    /// <summary>
    /// ROUTE BETWEEN NODES:
    /// Given a directred graph, design an algorithm to find out 
    /// whether there is a route between two nodes.
    /// </summary>
    public class Chapter4_1Test : BaseTest
    {
        private readonly Chapter4_1 _sut = new Chapter4_1();

        public Chapter4_1Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter4_1Data))]
        public void TestDepthFirstSearchToFindRouteBetweenTwoNodes(
            bool expected, Graph<int> graph, Node<int> node1, Node<int> node2)
        {
            bool actual = _sut.ExistsRouteUsingDfs(graph, node1, node2);

            Assert.Equal(expected, actual);
        }
    }


    public class Chapter4_1
    {
        /// <summary>
        /// Find if a route between two nodes in the specified graph using DFS (Depth First Search) algorithm.
        /// </summary>
        /// <param name="graph">Graph containing all nodes</param>
        /// <param name="node1">"From" node</param>
        /// <param name="node2">"To" node</param>
        /// <returns>True if route exists, false, otherwise</returns>
        public bool ExistsRouteUsingDfs<T>(Graph<T> graph, Node<T> node1, Node<T> node2)
        {
            return SearchDfs(node1, node2);
        }

        private bool SearchDfs<T>(Node<T> node1, Node<T> node2)
        {
            if (node1 == null || node2 == null) return false;
            if (node1 == node2) return true;

            node1.IsVisited = true;

            foreach (Node<T> childNode in node1.Children)
            {
                if (!childNode.IsVisited)
                    return SearchDfs(childNode, node2);
            }

            return false;
        }
    }

    public class Chapter4_1Data : Chapter4TestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { false, GetGraph(), GetGraph().Nodes[0], GetGraph().Nodes[GetGraph().Nodes.Count - 1] },
            new object[] { true, GetGraph(), GetGraph().Nodes[0], GetGraph().Nodes[GetGraph().Nodes.Count - 1] },
        };

        /// <summary>
        /// 1 : 2
        /// 2 : 3
        /// 3 : 
        /// 4 : 2
        /// </summary>
        private static Graph<int> GetGraph()
        {
            var graph = new Graph<int>();
            
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);

            graph.Nodes.Add(n1);
            graph.Nodes.Add(n2);
            graph.Nodes.Add(n3);
            graph.Nodes.Add(n4);

            n1.Children.Add(n2);
            n2.Children.Add(n3);
            n4.Children.Add(n2);

            return graph;
        }
    }
}
