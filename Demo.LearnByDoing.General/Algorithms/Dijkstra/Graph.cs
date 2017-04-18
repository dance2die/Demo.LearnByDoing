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
        /// First implementation was bad. Need to redo.
        /// </summary>
        public List<Node<T>> GetPathBetween2(Node<char> fromNode, Node<char> toNode)
        {
            var s = _vertices;
            var dist = new Dictionary<Node<T>, int>();
            var fringe = new List<Node<T>>();
            var paths = new List<Node<T>>();

            // Initial
            KeyValuePair<Node<T>, Edge<T>[]> first = s.First(pair => pair.Key.Value.Equals(fromNode.Value));
            foreach (var v in _vertices.Where(pair => !pair.Key.Value.Equals(first.Key.Value)))
            {
                foreach (Edge<T> edge in v.Value)
                {
                    dist[edge.Node] = int.MaxValue; // inifinity
                    fringe.Add(edge.Node);
                }
            }

            foreach (Edge<T> edge in first.Value)
            {
                dist[edge.Node] = edge.Weight;
                fringe.Add(edge.Node);
            }

            dist[first.Key] = 0;
            fringe.Add(first.Key);

            while (fringe.Count > 0)
            {
                var notProcessed = dist.Where(pair => !paths.Contains(pair.Key)).ToList();
                if (notProcessed.Count == 0) break;

                // Remove the minimum distance vertex, say m, from the fringe
                // (it is done, the shortest path to it has been found)
                Node<T> m = fringe.First(node =>
                {
                    var min = notProcessed.Min(pair => pair.Value);
                    return dist[node].Equals(min);
                });
                fringe.Remove(m);

                if (_vertices.ContainsKey(m))
                {
                    foreach (Edge<T> w in _vertices[m])
                    {
                        if (dist.ContainsKey(w.Node) && dist[w.Node] == int.MaxValue)
                        {
                            dist[w.Node] = dist[m] + w.Weight;
                            fringe.Add(w.Node);
                        }
                        else
                        {
                            if (dist[w.Node] < dist[m] + w.Weight)
                            {
                                paths.Remove(m);
                            }
                            else
                            {
                                paths.Remove(w.Node);
                            }
                            dist[w.Node] = Math.Min(dist[w.Node], dist[m] + w.Weight);
                        }
                    }
                }

                paths.Add(m);
            }

            return paths;
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
