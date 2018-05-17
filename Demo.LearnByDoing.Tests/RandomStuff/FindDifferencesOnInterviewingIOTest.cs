using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    /// <summary>
    /// https://start.interviewing.io/interview/9hV9r4HEONf9/replay
    /// 
    /// Find Differences
    /// 
    /// Given two arrays,
    /// [3, 6, 8, 12, 4]
    /// [4, 6, 8, 12]
    /// 
    /// Find an element that's not in both array
    /// Result => 3
    /// </summary>
    public class FindDifferencesOnInterviewingIOTest
    {
        /// <summary>
        /// Using my own blog entry
        /// https://www.slightedgecoder.com/2017/10/07/filtering-stray-number-array/
        /// </summary>
        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestUsingBitwiseOperation(int expected, int[] a1, int[] a2)
        {
            var actual = GetDifferenceUsingBitwiseOperation(a1, a2);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Space Complexity: O(1)
        /// Time Complexity: O(n)
        /// </summary>
        private int GetDifferenceUsingBitwiseOperation(int[] a1, int[] a2)
        {
            int result = 0;

            int upto = Math.Max(a1.Length, a2.Length);
            for (int i = 0; i < upto; i++)
            {
                var left = GetValueAt(a1, i);
                var right = GetValueAt(a2, i);
                result ^= left ^ right;
            }

            return result;
        }

        private int GetValueAt(int[] a, int index)
        {
            return a.Length <= index ? 0 : a[index];
        }

        public static IEnumerable<object[]> GetInput()
        {
            yield return new object[] { 3, new[] { 3, 6, 8, 12, 4 }, new[] { 4, 6, 8, 12 } };
            yield return new object[] { 1, new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 } };
            yield return new object[] { 3, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 4 } };
        }
    }
}
