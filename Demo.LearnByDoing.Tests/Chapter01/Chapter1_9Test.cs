using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// String Rotation:
    /// Assume you have a method isSubstring which checks if one word is a substring of another.
    /// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring
    /// (e.g., "waterbottle" is a rotation of "erbottlewat").
    /// </summary>
    /// <remarks>
    /// Sung's algorithm (cheated because I saw the hints):
    /// Combine S2 with itself: erbottlewat -> erbottlewaterbottlewat
    /// Check if S1 is substring of S2.
    /// </remarks>
    public class Chapter1_9Test : BaseTest
    {
        private readonly Chapter1_9 _sut = new Chapter1_9();

        public Chapter1_9Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_9Data))]
        public void TestIfSubstringIsRotation(string s1, string s2, bool expected)
        {
            bool actual = _sut.IsRotationSubstring(s1, s2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_9
    {
        public bool IsRotationSubstring(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2)) return false;

            var s2Concatenated = s2 + s2;
            int startIndex = s2Concatenated.IndexOf(s1);
            if (startIndex < 0) return false;

            return s2Concatenated.Substring(startIndex, s1.Length) == s1;
        }
    }

    public class Chapter1_9Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "waterbottle", "erbottlewat", true },
            new object[] { "abcde", "bcdea", true },
            new object[] { "eabcd", "abcde", true },
            // different length
            new object[] { "aaabbb", "aaabb", false },
            // completely different: not even a rotation
            new object[] { "12345", "54322", false },
            new object[] { "a", "b", false },
            // Empty case tests
            new object[] { "", "b", false },
            new object[] { "a", "", false },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
