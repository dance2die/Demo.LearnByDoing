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
    /// 
    /// NOT YET IMPLEMENTED.
    /// Need to implment a MinHeap data structure first.
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

            //var actual = GetMinimumSpanningTreeEdges(g);
            //Console.WriteLine(actual);
        }

        //private IEnumerable<Edge> GetMinimumSpanningTreeEdges(Dictionary<char, List<Edge>> g)
        //{
        //    var heap = new PrimsHeap();
        //    var vertexToEdge = new Dictionary<char, List<Edge>>();
        //    //FillHeap(heap, g);

        //    var firstVertex = g.First().Key;

        //}
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

    internal class PrimsHeap
    {
        private int Capacity { get; } = 10;
        private int Size { get; set; }

        public char[] Items { get; set; }

        public PrimsHeap()
        {
            Items = new char[Capacity];
        }

        private int GetLeftChildIndex(int parentIndex) => (2 * parentIndex) + 1;
        private int GetRightChildIndex(int parentIndex) => (2 * parentIndex) + 2;
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool HasLeftChild(int parentIndex) => GetLeftChildIndex(parentIndex) < Size;
        private bool HasRightChild(int parentIndex) => GetRightChildIndex(parentIndex) < Size;
        private bool HashParent(int childIndex) => GetParentIndex(childIndex) >= 0;

        private int LeftChild(int index) => Items[GetLeftChildIndex(index)];
        private int RightChild(int index) => Items[GetRightChildIndex(index)];
        private int Parent(int index) => Items[GetParentIndex(index)];

        private void Swap(int indexOne, int indexTwo)
        {
            (Items[indexTwo], Items[indexOne]) = (Items[indexOne], Items[indexTwo]);
        }

        private void EnsureExtraCapacity()
        {
            if (Size < Capacity) return;

            var newItems = new char[Capacity * 2];
            Array.Copy(Items, newItems, Items.Length);
            Items = newItems;
        }

        /// <summary>
        /// Get the minimum value without adjusting the heap
        /// </summary>
        public char Peek()
        {
            if (Size == 0) throw new ArgumentOutOfRangeException();

            // First item contains the minimum value.
            return Items[0];
        }

        /// <summary>
        /// Get the minimum value and re-adjust the heap
        /// </summary>
        public char Extract()
        {
            if (Size == 0) throw new ArgumentOutOfRangeException();

            char item = Items[0];
            Items[0] = Items[Size - 1];
            Size--;
            HeapifyDown();
            return item;
        }

        public void Add(char item)
        {
            EnsureExtraCapacity();
            Items[Size] = item;
            Size++;
            HeapifyUp();
        }

        public void AddRange(IEnumerable<char> items)
        {
            foreach (var item in items) Add(item);
        }

        private void HeapifyUp()
        {
            var index = Size - 1;
            while (HashParent(index) && Parent(index) > Items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (Items[index] < Items[smallerChildIndex]) break;

                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }
    }
}
