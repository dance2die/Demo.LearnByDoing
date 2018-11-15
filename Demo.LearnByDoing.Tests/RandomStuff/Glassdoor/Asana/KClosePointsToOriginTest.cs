﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Reference: https://www.youtube.com/watch?v=eaYX0Ee0Kcg
    /// MinHeap: https://www.youtube.com/watch?v=t0Cq6tVNRBA
    /// </summary>
    public class KClosePointsToOriginTest
    {
        [Fact]
        public void TestHappyPath()
        {
            var points = new[]
            {
                (X: -2, Y: 4),
                (X: 0, Y: -2),
                (X: -1, Y: 0),
                (X: 3, Y: 5),
                (X: -2, Y: -3),
                (X: 3, Y: 2),
            };
            var expected = new[]
            {
                (X: -2, Y: -3),
                (X: 0, Y: -2),
                (X: -1, Y: 0),
            };
            const int k = 3;
            var actual = GetKClosestPointsToOrigin(k, points);

            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<(int, int)> GetKClosestPointsToOrigin(int k, (int X, int Y)[] points)
        {
            var pointToDistanceMap = BuildPointToDistanceMap(points);
            var maxHeap = BuildMaxHeapMap(k, points);
            for (int i = k; i < points.Length; i++)
            {
                // Replace the biggest with the current smallest
                if (pointToDistanceMap[points[i]] < maxHeap.Peek().Distance)
                {
                    maxHeap.Poll();
                    maxHeap.Add((points[i].X, points[i].Y, pointToDistanceMap[points[i]]));
                }
            }

            while (maxHeap.HasItem())
            {
                var (x, y, _) = maxHeap.Poll();
                yield return (x, y);
            }
        }

        private Dictionary<(int, int), double> BuildPointToDistanceMap((int x, int y)[] points)
        {
            return points.ToDictionary(point => point, CalculateDistance);
        }

        private double CalculateDistance((int X, int Y) point) => Math.Sqrt(point.X * point.X + point.Y * point.Y);

        private GenericMaxHeap<(int X, int Y, double Distance)> BuildMaxHeapMap(int k, (int X, int Y)[] points)
        {
            return points
                .Take(k)
                .Aggregate(new GenericMaxHeap<(int X, int Y, double Distance)>(),
                    (heap, point) =>
                    {
                        heap.Add((point.X, point.Y, CalculateDistance(point)));
                        return heap;
                    });
        }
    }

    class GenericMaxHeap<T>
    {
        private T[] _items;
        private int _size = 10;

        public GenericMaxHeap()
        {
            _items = new T[_size];
        }

        public T Peek()
        {
            if (_size == 0) throw new ArgumentOutOfRangeException();

            return _items[0];
        }

        public T Poll()
        {
            if (_size == 0) throw new ArgumentOutOfRangeException();

            // move last item to the front and heapify down
            var item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();

            return item;
        }

        public bool HasItem() => _size > 0;

        public void Add(T item)
        {
            // Add it to the end and heapify up!
            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        /// <summary>
        /// Move the last item to as high as it can move up
        /// </summary>
        /// <remarks>
        /// While there is a parent, which is less than the current item,
        ///     replace the parent with the current item by moving it up.
        ///     set the current index to that of the parent.
        /// </remarks>
        private void HeapifyUp()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Move the first item to as low as it can in the tree
        /// </summary>
        /// <remarks>
        /// while the child exists (check left child only)
        ///     Get the larger child's index between Left & Right child
        ///     if the current item is bigger than the larger child's value, then break out of the loop
        ///     else swap the larger child with the current item
        /// </remarks>
        private void HeapifyDown()
        {
            throw new NotImplementedException();
        }
    }
}
