using System;
using System.Collections.Generic;

namespace Demo.LearnByDoing.General.Algorithms.Dijkstra
{
    public class DijkstraProgram
    {
        public static void Main(string[] args)
        {
            Graph<char> graph = CreateSampleGraph();
            List<char> paths = graph.GetPathBetween(new Node<char>('A'), new Node<char>('G'));
            paths.ForEach(c => Console.Write("{0} => ", c));
        }

        /// <summary>
        /// Create a graph based on https://youtu.be/zXfDYaahsNA
        /// </summary>
        /// <returns></returns>
        private static Graph<char> CreateSampleGraph()
        {
            Graph<char> graph = new Graph<char>();

            var a = new Node<char>('A');
            var b = new Node<char>('B');
            var c = new Node<char>('C');
            var d = new Node<char>('D');
            var e = new Node<char>('E');
            var f = new Node<char>('F');
            var g = new Node<char>('G');

            graph.AddVertex(a, new[] { new Edge<char>(5, b), new Edge<char>(10, c) });
            graph.AddVertex(b, new[] { new Edge<char>(3, e), new Edge<char>(6, d) });
            graph.AddVertex(d, new[] { new Edge<char>(6, f) });
            graph.AddVertex(e, new[] { new Edge<char>(2, c), new Edge<char>(2, d), new Edge<char>(2, g) });
            graph.AddVertex(g, new[] { new Edge<char>(2, f) });

            return graph;
        }
    }
}
