using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicProblems
{
    public class _03_Longest_Common_Subsequence_Test
    {
        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSampleCases(string text1, string text2, int expected)
        {
            var sut = new _03_Longest_Common_Subsequence();
            var actual = sut.GetLongestCommonSubsequence(text1, text2);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { "ABCDGH", " AEDFHR", 3 };
            yield return new object[] { "ABC", " AC", 2 };
        }
    }

    public class _03_Longest_Common_Subsequence
    {
        public int GetLongestCommonSubsequence(string text1, string text2)
        {
            int nextColumnIndex = 0;
            int sequenceLength = 0;

            for (int r = 0; r < text1.Length; r++)
            {
                for (int c = nextColumnIndex; c < text2.Length; c++)
                {
                    var rowValue = text1[r];
                    var colValue = text2[c];
                    if (rowValue == colValue)
                    {
                        nextColumnIndex++;
                        sequenceLength++;
                        break;
                    }
                }
            }

            return sequenceLength;
        }
    }
}
