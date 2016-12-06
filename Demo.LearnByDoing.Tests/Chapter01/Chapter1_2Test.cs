using System;
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
        [InlineData("1", "1", true)]
        [InlineData("abc", "bca", true)]
        [InlineData("12345", "54321", true)]
        [InlineData("cca", "ccc", false)]
        [InlineData("a", "ab", false)]
        [InlineData("hello world!", "!world hell", false)]
        public void CompareIfOneTextIsAPermutationOfTheOther(string text1, string text2, bool expected)
        {
            bool actual = _sut.AreStringsPermutational(text1, text2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_2
    {
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
}
