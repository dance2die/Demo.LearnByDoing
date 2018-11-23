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
            yield return new object[] { new[] { 'a', 'b', 'c', 'f' }, "acbcf", "abcdaf" };
            //yield return new object[] { new[] { 'a', 'a' }, "aaa", "aab" };
            //yield return new object[] { new[] { 'b' }, "aba", "dbcc" };
            //yield return new object[] { new char[] { }, "aaa", "bbb" };
            //yield return new object[] { new char[] { }, "", "" };
            //yield return new object[] { new char[] { }, "", null };
            //yield return new object[] { new char[] { }, null, "" };
            //yield return new object[] { new char[] { }, null, null };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestHappyPaths(char[] expected, string text1, string text2)
        {
            var actual = GetLongestCommonSubsequence(text1, text2);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<char> GetLongestCommonSubsequence(string text1, string text2)
        {
            // Guard against edge cases
            if (new[] { text1, text2 }.Any(string.IsNullOrWhiteSpace)) return new char[] { };

            // Generate the matrix
            var matrix = BuildMatrix(text1, text2);

            // Build the path from matrix
            return BuildPath(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private int[,] BuildMatrix(string text1, string text2)
        {
            var m = new int[text1.Length + 1, text2.Length + 1];
            // array is initialized with 0s so this is unncessary
            //// Initialize first indexes in column & row
            //for (int i = 0; i < text1.Length; i++) m[i, 0] = 0;
            //for (int i = 0; i < text2.Length; i++) m[0, i] = 0;

            for (int r = 1; r <= text1.Length; r++)
            {
                for (int c = 1; c <= text2.Length; c++)
                {
                    var rowCharacter = text1[r - 1];
                    var colCharacter = text2[c - 1];

                    // Get the max between top or left cell value
                    var cellValue = Math.Max(m[r - 1, c], m[r, c - 1]);
                    // Set the current cell value to that of top left cell value + 1
                    if (rowCharacter == colCharacter)
                        cellValue = m[r - 1, c - 1] + 1;

                    m[r, c] = cellValue;
                }
            }

            return m;
        }

        private IEnumerable<char> BuildPath(int[,] matrix)
        {
            throw new NotImplementedException();
        }
    }
}
