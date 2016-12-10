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
        [InlineData("spale", "pale", true)]
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
            List<char> c1, c2;

            if (text1.Length <= text2.Length)
            {
                c1 = text1.ToCharArray().ToList();
                c2 = text2.ToCharArray().ToList();
            }
            else
            {
                c1 = text2.ToCharArray().ToList();
                c2 = text1.ToCharArray().ToList();
            }

            List<char> temp1 = new List<char>(c1);
            string c2Text = new string(c2.ToArray());

            for (int i = 0; i < c1.Count; i++)
            {

                if (c1[i] != c2[i])
                {
                    //*** Insert check
                    temp1.Insert(i, c2[i]);
                    if (c2Text == new string(temp1.ToArray()))
                        return true;

                    // reset the list.
                    temp1 = new List<char>(c1);

                    //*** Remove check
                    temp1.RemoveAt(i);
                    if (c2Text == new string(temp1.ToArray()))
                        return true;

                    // reset the list.
                    temp1 = new List<char>(c1);

                    //*** Replace check
                    temp1[i] = c2[i];
                    if (c2Text == new string(temp1.ToArray()))
                        return true;
                }
            }

            // Insert the rest of c2 to temp1 and compare.
            if (c2.Count - c1.Count == 1)
            {
                // reset the list.
                temp1 = new List<char>(c1);

                //** insert the rest
                temp1.Insert(c1.Count, c2[c1.Count]);

                if (c2Text == new string(temp1.ToArray()))
                    return true;
            }


            return false;
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
