using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Zero Matrix:
    /// Write an algorithm such that if an element in an MxN matrix is 0, 
    /// its entire row and column are set to 0
    /// </summary>
    public class Chapter1_8Test : BaseTest
    {
        private readonly Chapter1_8 _sut = new Chapter1_8();

        public Chapter1_8Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        //[ClassData(typeof(Chapter1_8Data))]
        //public void TestGettingZeroPositions(int[,] matrix, int matrix1)
        public void TestGettingZeroPositionCoordinates()
        {
            var matrix = new[,] { { 0, 1, 2 }, { 3, 0, 5 } };
            var expected = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 1),
            };

            var actual = _sut.GetZeroPositions(matrix).ToList();

            if (expected.Count != actual.Count)
                Assert.True(false, "length not the same");

            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i].Item1 != actual[i].Item1 || expected[i].Item2 != actual[i].Item2)
                {
                    Assert.True(false, "item not the same!");
                }
            }

            Assert.True(true, "Test passes!");
        }
    }

    public class Chapter1_8
    {
        public IEnumerable<Tuple<int, int>> GetZeroPositions(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        yield return new Tuple<int, int>(i, j);
                }
            }
        }
    }

    public class Chapter1_8Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new[,] { { 0, 1, 2 }, { 3, 4, 5 } },
                1
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
