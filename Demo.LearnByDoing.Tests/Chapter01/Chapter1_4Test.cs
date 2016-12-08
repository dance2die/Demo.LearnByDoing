﻿using System;
using System.Collections;
using System.Collections.Generic;
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
        // Taco Cat or Atco Cta
        [InlineData("Tact Coa", true)]
        [InlineData("aab", true)]
        [InlineData("aabbcc", true)]
        // Racecar
        [InlineData("raccear", true)]
        // Kayak
        [InlineData("yakka", true)]
        [InlineData("ybbakka", true)]
        [InlineData("abcab", true)]
        [InlineData("abbbc", false)]
        [InlineData("ab", false)]
        [InlineData("abc", false)]
        [InlineData("abcd", false)]
        [InlineData("abcde", false)]
        public void CheckIfTextCanBeAPalindrome(string text, bool expected)
        {
            bool actual = _sut.GetPalindromes(text).Count() > 1;

            Assert.Equal(expected, actual);
        }

        //[Theory]
        //// Taco Cat or Atco Cta
        //[InlineData("Tact Coa", true)]
        //[InlineData("aab", true)]
        //[InlineData("aabbcc", true)]
        //// Racecar
        //[InlineData("raccear", true)]
        //// Kayak
        //[InlineData("yakka", true)]
        //[InlineData("ybbakka", true)]
        //[InlineData("abcab", true)]
        //[InlineData("abbbc", false)]
        //[InlineData("ab", false)]
        //[InlineData("abc", false)]
        //[InlineData("abcd", false)]
        //[InlineData("abcde", false)]
        //public void TestForPalindromenessOfText(string text, bool expected)
        //{
        //    bool actual = _sut.
        //}
    }

    public class Chapter1_4
    {
        public IEnumerable<string> GetPalindromes(string text)
        {
            yield break;
        }

        public bool IsPalindrome(string text)
        {
            // By definition, if one letter is a palindrome
            if (text.Length == 1) return true;

            Func<char, bool> isNotSpace = c => c != ' ';

            string reverseWithoutSpace = new string(text.Where(isNotSpace).Reverse().ToArray()).ToLower();
            string textWithoutSpace = new string(text.Where(isNotSpace).ToArray()).ToLower();

            return textWithoutSpace == reverseWithoutSpace;
        }
    }

    public class Chapter1_4Data : IEnumerable<object[]>
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
