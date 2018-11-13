﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var maxHeap = BuildMaxHeap(k, pointToDistanceMap);
            for (int i = k; i < points.Length; i++)
            {
                // Replace the biggest with the current smallest
                if (points[i] < maxHeap.Peek())
                {
                    maxHeap.Poll();
                    maxHeap.Add(points[i]);
                }
            }

            foreach (var point in maxHeap)
                yield return point;
        }

        private Dictionary<(int, int), int> BuildPointToDistanceMap((int X, int Y)[] points)
        {
            throw new NotImplementedException();
        }

        private GenericMaxHeap<(int X, int Y)> BuildMaxHeap(int k, Dictionary<(int X, int Y), int> pointToDistanceMap)
        {
            throw new NotImplementedException();
        }
    }

    class GenericMaxHeap<T>
    {

    }
}