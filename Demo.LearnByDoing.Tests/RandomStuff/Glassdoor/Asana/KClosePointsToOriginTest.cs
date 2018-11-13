using System;
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
            var expected = new[] {2, 1, 0};
            var actual = GetKClosestPointsToOrigin(points);

            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> GetKClosestPointsToOrigin((int X, int Y)[] points)
        {
            throw new NotImplementedException();
        }
    }

    class GenericMaxHeap<T>
    {

    }
}
