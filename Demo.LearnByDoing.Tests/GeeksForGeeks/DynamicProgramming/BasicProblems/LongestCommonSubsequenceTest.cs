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
            yield return new object[]
            {
                new[] {'a', 'b', 'c', 'f'}, "abcdaf", "acbcf",
                new[] {'a', 'a'}, "aaa", "aab",
                new[] {'b'}, "aba", "dbcc",
                new char[] { }, "aaa", "bbb",
                // edge cases
                new char[] { }, "", "",
                new char[] { }, "", null,
                new char[] { }, null, "",
                new char[] { }, null, null,
            };
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
            throw new NotImplementedException();
        }
    }
}
