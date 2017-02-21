using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.MyCodeSchool.ProgrammingInterviewQuestions
{
    public class CountOccurencesTest : BaseTest
    {
        private readonly CountOccurences _sut = new CountOccurences();

        public CountOccurencesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(CountOccurencesFirstIndexData))]
        public void TestGettingFirstIndexes(int[] a, int value, int expected)
        {
            int actual = _sut.FindFirstIndex(a, value);

            Assert.Equal(expected, actual);
        }

        //[Theory]
        //[ClassData(typeof(CountOccurencesData))]
        //public void TestCountOfElementInASortedList(int[] a, int value, int expected)
        //{
        //    int actual = _sut.GetCountUsinBinarySearch(a, value);

        //    Assert.Equal(expected, actual);
        //}
    }

    public class CountOccurences
    {
        public int FindFirstIndex(int[] a, int value)
        {
            int low = 0;
            int high = a.Length - 1;
            int result = int.MinValue;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int middleValue = a[mid];

                if (value == middleValue)
                {
                    result = mid;
                    high = mid - 1;
                }
                else if (value < middleValue)
                {
                    high = mid - 1;
                }
                else // value > middleValue
                {
                    low = mid + 1;
                }
            }

            return result;
        }

        //public int GetCountUsinBinarySearch(int[] a, int value)
        //{
        //    int firstIndex = FindFirst(a, value);
        //    int lastIndex = FindLast(a, value);

        //    return lastIndex - firstIndex + 1;
        //}
    }

    public class CountOccurencesFirstIndexData : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 1, 0},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 3, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 5, 4},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 9, 9},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 11, 11},
        };
    }

    public class CountOccurencesLastIndexData : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 1, 1},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 3, 3},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 5, 8},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 9, 10},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 11, 11},
        };
    }

    public class CountOccurencesData : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 1, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 3, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 5, 5},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 9, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 11, 1},
        };
    }
}
