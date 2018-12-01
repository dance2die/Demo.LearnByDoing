﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Part of solution required to calculate k closest point
    /// 
    /// K closest point to the origin - https://www.youtube.com/watch?v=eaYX0Ee0Kcg
    /// Min Heap - https://www.youtube.com/watch?v=t0Cq6tVNRBA
    /// </summary>
    public class MinHeapTest
    {
        [Fact]
        public void TestHeapness()
        {
            var items = new [] {10, 15, 20, 17};
            var expected = new[] {10, 15, 17, 20};
            var sut = new MinHeap();
            sut.AddRange(items);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], sut.Poll());
                //Console.WriteLine(sut.Poll());
            }
        }

        [Fact]
        public void ThrowExceptionWhenExtractingAnEmptyBinaryMinHeap()
        {
            var sut = new BinaryMinHeap<char>();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ExtractMinimum());
        }

        [Fact]
        public void TestBinaryMinHeap()
        {
            var sut = new BinaryMinHeap<char>();
            var a = new BinaryMinHeap<char>.Node{Id = 'a', Weight = 5 };
            var b = new BinaryMinHeap<char>.Node{Id = 'b', Weight = 8 };
            var c = new BinaryMinHeap<char>.Node{Id = 'c', Weight = 12};
            var d = new BinaryMinHeap<char>.Node{Id = 'd', Weight = 22};
            var e = new BinaryMinHeap<char>.Node{Id = 'e', Weight = 33};
            var f = new BinaryMinHeap<char>.Node{Id = 'f', Weight = 13};
            var g = new BinaryMinHeap<char>.Node { Id = 'g', Weight = 20 };

            sut.Add(a);
            sut.Add(b);
            sut.Add(c);
            sut.Add(d);
            sut.Add(e);
            sut.Add(f);
            sut.Add(g);

            e.Weight = 0;
            sut.Decrease(e);

            var expected = new[] {'e', 'a', 'c', 'd', 'b', 'f', 'g'};
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], sut.ExtractMinimum().Id);
            }
        }
    }

    public class BinaryMinHeap<T>
    {
        public class Node
        {
            public T Id { get; set; }
            public int Weight { get; set; }
        }

        private int _size = 0;
        private int _capacity = 10;
        private Node[] _items;
        /// <summary>
        /// Contains a mapping of ID to the position in the array of _items
        /// </summary>
        /// <typeparam name="T">Node.Id</typeparam>
        /// <param name="int">_items index stored for Node.Id</param>
        private Dictionary<T, int> _map;

        public BinaryMinHeap()
        {
            _items = new Node[_capacity];
            _map = new Dictionary<T, int>();
        }

        private void Swap(int index1, int index2)
        {
            var id1 = _items[index1].Id;
            var id2 = _items[index2].Id;
            (_map[id1], _map[id2]) = (_map[id2], _map[id1]);
            (_items[index1], _items[index2]) = (_items[index2], _items[index1]);
        }

        public void Decrease(Node node)
        {
            throw new NotImplementedException();
        }

        public Node ExtractMinimum()
        {
            if (_size == 0) throw new ArgumentOutOfRangeException("Heap is empty so no minimum to extract");

            // This is a MinHeap, thus the first item is always the node with minimum weight.
            var node = _items[0];

            // Replace the first item with the last item, and heapify down...
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();

            return node;
        }

        private void HeapifyDown()
        {
            throw new NotImplementedException();
        }

        public void Add(Node node)
        {
            EnsureExtraCapacity();
            _map[node.Id] = _size;
            _items[_size] = node;
            _size++;
            HeapifyUp();
        }

        /// <summary>
        /// Move the last item as high as possible in the heap
        /// </summary>
        private void HeapifyUp()
        {
            var index = _size;
            var node = _items[index];

            // Swap with parents while the parent is bigger
            while (HasParent(index) && GetParent(index).Weight > node.Weight)
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
        private Node GetParent(int childIndex) => _items[GetParentIndex(childIndex)];
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        /// <summary>
        /// Increase items capacity if needed 
        /// </summary>
        /// <remarks>
        /// Doubling the size of items for now.
        /// </remarks>
        private void EnsureExtraCapacity()
        {
            if (_size < _capacity) return;

            _capacity *= 2;
            var items = new Node[_capacity];
            Array.Copy(_items, items, _items.Length);
            _items = items;
        }
    }

    class MinHeap
    {
        private int Capacity { get; } = 10;
        private int Size { get; set; }

        public int[] Items { get; set; }

        public MinHeap()
        {
            Items = new int[Capacity];
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

            var newItems = new int[Capacity * 2];
            Array.Copy(Items, newItems, Items.Length);
            Items = newItems;
        }

        /// <summary>
        /// Get the minimum value without adjusting the heap
        /// </summary>
        public int Peek()
        {
            if (Size == 0) throw new ArgumentOutOfRangeException();

            // First item contains the minimum value.
            return Items[0];
        }

        /// <summary>
        /// Get the minimum value and re-adjust the heap
        /// </summary>
        public int Poll()
        {
            if (Size == 0) throw new ArgumentOutOfRangeException();

            int item = Items[0];
            Items[0] = Items[Size - 1];
            Size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            Items[Size] = item;
            Size++;
            HeapifyUp();
        }

        public void AddRange(IEnumerable<int> items)
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
