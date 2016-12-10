using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// One Away:
    /// There are three types of edits that can be performed on strings:
    /// insert a character,
    /// remove a character,
    /// or replace a character.
    ///  Given two strings, write a function to check if they are onde edit (or zero edits) away.
    /// 
    /// EXAMPLE
    /// pale,   ple     -> true
    /// pales,  pale    -> true
    /// pale,   bale    -> true
    /// pales,  bake    -> false
    /// </summary>
    /// <remarks>
    /// If the number of differences in text is more than one, then it's NOT "one edit away".
    /// </remarks>
    public class Chapter1_5Test : BaseTest
    {
        private readonly Chapter1_5 _sut = new Chapter1_5();

        public Chapter1_5Test(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test the number of differences between two texts.
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("pale", "ple", true)]
        [InlineData("abcd", "abc", true)]
        [InlineData("abd", "abcd", true)]
        [InlineData("ple", "pale", true)]
        [InlineData("pale", "plee", false)]
        [InlineData("plee", "pale", false)]
        [InlineData("pales", "pale", true)]
        [InlineData("pale", "pales", true)]
        [InlineData("pale", "bale", true)]
        [InlineData("bale", "pale", true)]
        [InlineData("pale", "palee", true)]
        [InlineData("palee", "pale", true)]
        [InlineData("pale", "baleee", false)]
        [InlineData("baleee", "pale", false)]
        public void TestCharacterDifferenceCount(string text1, string text2, bool expected)
        {
            bool actual = _sut.IsOneEditAway(text1, text2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_5
    {
        public bool IsOneEditAway(string text1, string text2)
        {
            var c1 = text1.ToCharArray().ToList();
            var c2 = text2.ToCharArray().ToList();

            int differenceCount = 0;

            int length = Math.Min(c1.Count, c2.Count);
            for (int i = 0; i < length; i++)
            {
                if (c1[i] != c2[i])
                    differenceCount++;

                if (differenceCount > 1)
                    return false;
            }

            differenceCount += Math.Max(c1.Count, c2.Count) - length;

            return differenceCount <= 1;
        }
    }

    public class Chapter1_5Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            
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
