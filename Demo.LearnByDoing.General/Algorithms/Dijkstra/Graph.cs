using System.Collections.Generic;

namespace Demo.LearnByDoing.General.Algorithms.Dijkstra
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }

        private readonly Dictionary<Node<T>, Edge<T>[]> _distances = new Dictionary<Node<T>, Edge<T>[]>();

        public void AddVertex(Node<T> node, Edge<T>[] edges)
        {
            if (!_distances.ContainsKey(node))
                _distances.Add(node, edges);
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public class Edge<T>
    {
        public int Weight { get; set; }
        public Node<T> Node { get; set; }

        public Edge(int weight, Node<T> node)
        {
            Weight = weight;
            Node = node;
        }
    }
}
