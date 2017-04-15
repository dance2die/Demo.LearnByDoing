using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Algorithms.Dijkstra
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }

        private readonly Dictionary<Node<T>, Edge<T>[]> _vertices = new Dictionary<Node<T>, Edge<T>[]>();

        public void AddVertex(Node<T> node, Edge<T>[] edges)
        {
            if (!_vertices.ContainsKey(node))
                _vertices.Add(node, edges);
        }

        /// <summary>
        /// Using pseudocode in Wikipedia https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Pseudocode
        /// </summary>
        public List<T> GetPathBetween(Node<T> fromNode, Node<T> toNode)
        {
            List<T> path = new List<T>();
            var dist = new Dictionary<Node<T>, int>();
            // unvisited nodes
            var fringe = new List<Node<T>>();

            foreach (KeyValuePair<Node<T>, Edge<T>[]> vertext in _vertices)
            {
                // Unknown distance from source to v
                dist[vertext.Key] = int.MaxValue;   // int.MaxValue => infinity
                foreach (Edge<T> edge in vertext.Value)
                {
                    dist[edge.Node] = int.MaxValue;
                }
                // All nodes initially in Q (unvisited nodes)
                fringe.Add(vertext.Key);
            }

            // Distance from source to source
            //KeyValuePair<Node<T>, int> first = dist.FirstOrDefault(pair => pair.Value == fromNode.Value);
            KeyValuePair<Node<T>, int> first = dist.FirstOrDefault(pair => pair.Key.Value.Equals(fromNode.Value));
            dist[first.Key] = 0;    // distance from itself is 0

            while (fringe.Count > 0)
            {
                // shortest path
                var processed = dist.Where(pair => !path.Contains(pair.Key.Value)).ToList();
                Node<T> m = processed.FirstOrDefault(pair => pair.Value == processed.Min(p => p.Value)).Key;
                int mDist = dist[m];
                fringe.Remove(m);

                if (!_vertices.ContainsKey(m))
                {
                    dist.Remove(m);
                    continue;
                }

                foreach (Edge<T> w in _vertices[m])
                {
                    if (dist[w.Node] == int.MaxValue)
                    {
                        dist[w.Node] = mDist + (mDist + w.Weight);
                        fringe.Add(w.Node);
                    }
                    else
                    {
                        dist[w.Node] = Math.Min(dist[w.Node], mDist + (mDist + w.Weight));
                    }
                }
                path.Add(m.Value);
            }

            return path;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
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

        public override string ToString()
        {
            return $"Node Value: {Node}, Weight: {Weight}";
        }
    }
}
