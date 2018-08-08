using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.Sorting
{
    public class SortTest
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 }, new[] { 5, 2, 3, 4, 1 } };
            yield return new object[] { new[] { 11, 22, 33, 44, 55 }, new[] { 55, 44, 33, 22, 11 } };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestBubbleSort(int[] expected, int[] input)
        {
            var actual = BubbleSort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        /// <summary>
        /// Sort using BubbleSort
        /// </summary>
        /// <remarks>
        /// Algorithm:
        ///     for i = 1 to n - 1
        ///         for j = 0 to n - 2
        ///             if next > prev then swap next & prev
        /// </remarks>
        private IEnumerable<int> BubbleSort(int[] input)
        {
            Action<int[], int, int> swap = (a, i, j) =>
            {
                var temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            };

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j <= input.Length - 1; j++)
                {
                    if (input[i] > input[j])
                        swap(input, i, j);
                }
            }

            return input;
        }
    }
}
