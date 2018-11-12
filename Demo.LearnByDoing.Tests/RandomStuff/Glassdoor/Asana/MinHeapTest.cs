using System;
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
                //Assert.Equal(expected[i], sut.Poll());
                Console.WriteLine(sut.Poll());
            }
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

        private void HeapifyDown()
        {
            var index = Size - 1;
            while (HashParent(index) && Parent(index) > Items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        private void HeapifyUp()
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
