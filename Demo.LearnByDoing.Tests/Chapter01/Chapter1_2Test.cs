using System;
using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// 1.2 Given two strings, write a method to decide if one is a permutation of the other.
    /// </summary>
    public class Chapter1_2Test : BaseTest
    {
        private readonly Chapter1_2 _sut = new Chapter1_2();

        public Chapter1_2Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_2Data))]
        public void CompareIfOneTextIsAPermutationOfTheOther(string text1, string text2, bool expected)
        {
            bool actual = _sut.AreStringsPermutational(text1, text2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter1_2Data))]
        public void CompareIfOneTextIsAPermutationOfTheOtherUsingHashSet(string text1, string text2, bool expected)
        {
            bool actual = _sut.AreStringsPermutationalUsingHashSet(text1, text2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_2
    {
        public bool AreStringsPermutationalUsingHashSet(string text1, string text2)
        {
            if (text1.Length != text2.Length) return false;

            return false;
        }

        public bool AreStringsPermutational(string text1, string text2)
        {
            if (text1.Length != text2.Length) return false;

            string sortedText1 = SortAlphabetically(text1);
            string sortedText2 = SortAlphabetically(text2);

            return sortedText1 == sortedText2;
        }

        private string SortAlphabetically(string text)
        {
            var charArray = text.ToCharArray();
            Array.Sort(charArray);

            return new string(charArray);
        }
    }

    /// <summary>
    /// Data for testing permutations
    /// </summary>
    /// <remarks>
    /// http://stackoverflow.com/a/22093968/4035
    /// </remarks>
    public class Chapter1_2Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "1", "1", true },
            new object[] {"abc", "bca", true },
            new object[] {"12345", "54321", true },
            new object[] {"cca", "ccc", false },
            new object[] {"a", "ab", false },
            new object[] { "hello world!", "!world hell", false },
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
