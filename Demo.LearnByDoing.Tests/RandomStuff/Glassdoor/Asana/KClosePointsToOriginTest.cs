using System;
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
            var maxHeap = BuildMaxHeapMap(k, pointToDistanceMap);
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

        private GenericMaxHeap<(int X, int Y, double Distance)> BuildMaxHeapMap(int k, Dictionary<(int X, int Y), double> pointToDistanceMap)
        {
            throw new NotImplementedException();
        }
    }

    class GenericMaxHeap<T>
    {
        public T Peek()
        {
            throw new NotImplementedException();
        }

        public T Poll()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool HasItem()
        {
            throw new NotImplementedException();
        }
    }
}
