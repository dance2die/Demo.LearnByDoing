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
    class MaxHeapTest
    {
        [Fact]
        public void TestHeapness()
        {
            var items = new[] { 10, 15, 20, 17 };
            var expected = new[] { 20, 17, 15, 10 };
            var sut = new MaxHeap();
            sut.AddRange(items);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], sut.Poll());
                //Console.WriteLine(sut.Poll());
            }
        }
    }

    class MaxHeap
    {
        private int _capacity = 10;
        private int _size = 0;
        private int[] _items;

        public MaxHeap()
        {
            _items = new int[_capacity];
        }

        public int Peek()
        {
            if (_items.Length == 0) throw new ArgumentOutOfRangeException();

            return _items[0];
        }

        public int Poll()
        {
            if (_items.Length == 0) throw new ArgumentOutOfRangeException();

            var item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        private void EnsureExtraCapacity()
        {
            if (_size < _capacity) return;

            var newItems = new int[_capacity * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

        public void AddRange(IEnumerable<int> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
