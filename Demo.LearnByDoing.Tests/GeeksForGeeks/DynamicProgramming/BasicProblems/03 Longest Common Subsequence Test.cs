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
            //yield return new object[] { "ABCDGH", " AEDFHR", 3 };
            //yield return new object[] { "ABC", " AC", 2 };
            // http://lcs-demo.sourceforge.net/
            //yield return new object[] { "AACDDC", " AADBAA", 3 };   // AAD
            //yield return new object[] { "DCDCDD", " CCACCD", 3 };   // CCD
            yield return new object[] { "CDAABDBCDB", " CADCACBBDB", 7 };   // CDABBDB
            //yield return new object[]
            //{
            //    "LRBBMQBHCDARZOWKKYHIDDQSCDXRJMOWFRXSJYBLDBEFSARCBYNECDYGGXXPKLORELLNMPAPQFWKHOPKMCO",
            //    "QHNWNKUEWHSQMGBBUQCLJJIVSWMDKQTBXIXMVTRRBLJPTNSNFWZQFJMAFADRRWSOFSBCNUVQHFFBSAQXWPQCAC",
            //    25
            //};
        }
    }

    public class _03_Longest_Common_Subsequence
    {
        public int GetLongestCommonSubsequence(string text1, string text2)
        {
            int nextColumnIndex = 0;
            int sequenceLength = 0;

            var row = "";
            var col = "";

            for (int r = 0; r < text1.Length; r++)
            {
                for (int c = nextColumnIndex; c < text2.Length; c++)
                {
                    var rowValue = text1[r];
                    var colValue = text2[c];

                    if (rowValue == colValue)
                    {
                        nextColumnIndex = c + 1;
                        sequenceLength++;

                        row += rowValue;
                        col += colValue;

                        break;
                    }
                }
            }

            return sequenceLength;
        }
    }
}
