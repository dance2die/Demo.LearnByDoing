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
            yield return new object[] { new[] { 1, 2, 3, 8, 9, 24, 33 }, new[] { 8, 33, 9, 1, 24, 3, 2 } };
            yield return new object[] { new[] { 1, 2, 3, 8, 9, 24, 33, 99 }, new[] { 8, 33, 9, 1, 99, 24, 3, 2 } };
        }

        /// <remarks>
        /// Algorithm: 
        ///     while end is not reached,
        ///         while current element is smaller than the previous, move it to the left.
        /// </remarks>
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestInsertionSort(int[] expected, int[] input)
        {
            var actual = InsertionSort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> InsertionSort(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                int curr = input[i];
                for (int j = 0; j < i; j++)
                {
                    int prev = input[j];
                    if (curr < prev)
                    {
                        Swap(input, i, j);
                    }
                }
            }

            return input;
        }

        /// <remarks>
        /// Algorithm: 
        ///     while index is less than the input array length - 1,
        ///         find the smallest element.
        ///         if the smallest element index is larger than the current index, then swap
        /// 
        ///     return the input array.
        /// </remarks>
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestSelectionSort(int[] expected, int[] input)
        {
            var actual = SelectionSort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private int[] SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int min = input[i];
                int minIndex = i;

                for (int j = i + 1; j < input.Length; j++)
                {
                    int curr = input[j];
                    if (curr < min)
                    {
                        min = curr;
                        minIndex = j;
                    }
                }

                Swap(input, i, minIndex);
            }

            return input;
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
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j <= input.Length - 1; j++)
                {
                    if (input[i] > input[j])
                        Swap(input, i, j);
                }
            }

            return input;
        }
        void Swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
