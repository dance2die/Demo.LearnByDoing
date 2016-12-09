using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Palindrome Permutation:
    /// Given a string, write a function to check if it is a permutation of a palindrome.
    /// A palindrome is a word or phrase that is the same forwards and backwards. 
    /// A permutation is a rearrangement of letters.
    /// The palindrome does not need to be limited to just dictionary words.
    /// 
    /// EXAMPLE
    /// Input:  Tact Coa
    /// Output  True (permutations: "taco cat", "atco cta", etc.)
    /// </summary>
    public class Chapter1_4Test : BaseTest
    {
        private readonly Chapter1_4 _sut = new Chapter1_4();

        public Chapter1_4Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("Tact Coa", false)]
        [InlineData("taco cat", true)]
        [InlineData("atco cta", true)]
        [InlineData("race car", true)]
        [InlineData("civic", true)]
        [InlineData("aabbcc bbaa", true)]
        [InlineData("aa", true)]
        [InlineData("a", true)]
        [InlineData("ab", false)]
        [InlineData("abc", false)]
        [InlineData("abcd", false)]
        public void IsPalindrome(string text, bool expected)
        {
            bool actual = _sut.IsPalindrome(text);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter1_4Data))]
        public void CheckIfTextCanBeAPalindrome(string text, bool expected)
        {
            bool actual = _sut.HasPalindrome(text);

            Assert.Equal(expected, actual);
        }

        //[Theory]
        //public void TestForPalindromenessOfText(string text, bool expected)
        //{
        //    bool actual = _sut.
        //}
    }

    public class Chapter1_4
    {
        /// <summary>
        /// Check if the text can have a palindrome sequence.
        /// </summary>
        public bool HasPalindrome(string text)
        {
            if (text.Length == 1) return true;
            if (text.Length == 2 && text[0] == text[1]) return true;

            // It's palindrome if there exists
            // 1.) even number of characters for each character
            // 2.) even number of characters except for one character.

            // Test 1. even number of characters for each character
            var grouped = text
                .ToLower()
                .ToCharArray()
                .Where(IsNotSpace)
                .GroupBy(c => c)
                .Select(group => new 
                {
                    Character = group.Key,
                    Count = group.Count()
                })
                .ToList();

            Func<int, bool> isOdd = number => number % 2 == 1;

            var totalOddCount = grouped.Count(group => isOdd(group.Count));
            switch (totalOddCount)
            {
                case 0:
                case 1:
                    return true;
                default:
                    Debug.Assert(totalOddCount > 1);
                    return false;
            }
        }

        public bool IsPalindrome(string text)
        {
            // By definition, if one letter is a palindrome
            if (text.Length == 1) return true;

            string reverseWithoutSpace = new string(text.Where(IsNotSpace).Reverse().ToArray()).ToLower();
            string textWithoutSpace = new string(text.Where(IsNotSpace).ToArray()).ToLower();

            return textWithoutSpace == reverseWithoutSpace;
        }

        private bool IsNotSpace(char c)
        {
            return c != ' ';
        }
    }

    public class Chapter1_4Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            // Taco Cat or Atco Cta
            new object[] {"Tact Coa", true},
            new object[] {"aab", true},
            new object[] {"aabbcc", true},
            // Racecar
            new object[] {"raccear", true},
            // Kayak
            new object[] {"yakka", true},
            new object[] {"ybbakka", true},
            new object[] {"abcab", true},
            new object[] {"abbbc", false},
            new object[] {"ab", false},
            new object[] {"abc", false},
            new object[] {"abcd", false},
            new object[] {"abcde", false},
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
