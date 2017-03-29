using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.LinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

        public override string ToString()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            Node<T> node = this;

            while (node.Next != null)
            {
                nodes.Add(node);
                node = node.Next;
            }

            return string.Join("->", nodes.Select(val => val.Value.ToString()));
        }
    }
}
