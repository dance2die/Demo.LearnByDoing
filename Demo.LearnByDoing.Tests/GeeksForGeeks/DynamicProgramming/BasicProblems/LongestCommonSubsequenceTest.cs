using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicProblems
{
    public class LongestCommonSubsequenceTest
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new[] { 'a', 'b', 'c', 'f' }, "abcdaf", "acbcf" };
            yield return new object[] { new[] { 'a', 'a' }, "aaa", "aab" };
            yield return new object[] { new[] { 'b' }, "aba", "dbcc" };
            yield return new object[] { new char[] { }, "aaa", "bbb" };
            yield return new object[] { new char[] { }, "", "" };
            yield return new object[] { new char[] { }, "", null };
            yield return new object[] { new char[] { }, null, "" };
            yield return new object[] { new char[] { }, null, null };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestHappyPaths(char[] expected, string input1, string input2)
        {
            var actual = GetLongestCommonSubsequence(input1, input2);
            Assert.True(expected.SequenceEqual(actual));
        }

        private char[] GetLongestCommonSubsequence(string input1, string input2)
        {
            // Guard against edge cases
            if (new[] { input1, input2 }.Any(string.IsNullOrWhiteSpace)) return new char[] { };

            var m = new int[input1.Length + 1, input2.Length + 1];
            var result = new List<char>();


            return result.ToArray();
        }
    }
}
