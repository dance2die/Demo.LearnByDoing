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
        [InlineData("pale", "ple", 1)]
        [InlineData("pale", "plee", 2)]
        [InlineData("pales", "pale", 1)]
        [InlineData("pale", "bale", 1)]
        [InlineData("pale", "palee", 1)]
        [InlineData("pale", "baleee", 3)]
        public void TestCharacterDifferenceCount(string text1, string text2, int expected)
        {
            int actual = _sut.GetCharacterDifferenceCount(text1, text2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_5
    {
        public int GetCharacterDifferenceCount(string text1, string text2)
        {
            HashSet<char> set1 = new HashSet<char>(text1.ToCharArray());
            HashSet<char> set2 = new HashSet<char>(text2.ToCharArray());

            IEnumerable<char> intersection = set1.Intersect(set2);

            return text1.Length - intersection.Count();
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
