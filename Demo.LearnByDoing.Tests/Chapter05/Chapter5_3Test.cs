using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// Flip Bit to Win:
    /// You have an integer and you can flip exactly one bit from a 0 to a 1.
    /// Write code to find the length of the longest sequence of 1s you could create.
    /// 
    /// EXAMPLE
    /// Input:  1775 (or: 11011101111)
    /// Output: 8 => Flipping 7th bit turns 1775 to => 110 + 11111111
    /// Hints: #159, #226, #314, #352
    /// </summary>
    public class Chapter5_3Test : BaseTest
    {
        private readonly Chapter5_3 _sut = new Chapter5_3();

        public Chapter5_3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter5_3Data_SequentialCount))]
        public void TestGettingSequentialCount(int number, List<int> expected)
        {
            var actual = _sut.GetOneCount(number).ToList();

            Assert.True(expected.SequenceEqual(actual));
        }

        [Theory]
        [ClassData(typeof(Chapter5_3Data))]
        public void TestGettingLongestSequenceOfOnes(int number, int expected)
        {
            int actual = _sut.GetLongestSequenceOfOnes(number);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter5_3
    {
        public int GetLongestSequenceOfOnes(int number)
        {
            // Get the list containing sequential 1s.
            // e.g.) 110 1110 1111 => 2, 3, 4
            List<int> oneCount = GetOneCount(number).ToList();

            // get the sum of next adjacent item
            // get the max of the sum
            int max = 0;
            for (int i = 0; i < oneCount.Count - 1; i++)
            {
                int sum = oneCount[i] + oneCount[i + 1];
                if (sum > max)
                    max = sum;
            }

            // flipped bit size
            const int flippedBitSize = 1;
            return max + flippedBitSize;
        }

        // 32 bit integer.
        private const int INT_BIT_SIZE = 32;

        public IEnumerable<int> GetOneCount(int number)
        {
            int startValue = 1;
            int sequenceSize = 0;

            Func<int, string> toBin = value => Convert.ToString(value, 2);

            for (int i = 0; i < INT_BIT_SIZE; i++)
            {
                int mask = startValue << i;
                if ((mask & number) >= 1)
                {
                    sequenceSize++;
                }
                else
                {
                    if (sequenceSize != 0)
                        yield return sequenceSize;

                    sequenceSize = 0;
                }
            }
        }
    }

    public class Chapter5_3Data : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {1775, 8}, // 11011101111 => 8
            new object[] {1463, 6}, // 10110110111 => 6
        };
    }

    public class Chapter5_3Data_SequentialCount : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {1775, new List<int> {4, 3, 2}},
            new object[] {1463, new List<int> {3, 2, 2, 1}},
        };
    }
}
