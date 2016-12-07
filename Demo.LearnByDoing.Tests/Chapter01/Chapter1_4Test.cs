using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Tests.Core;
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
    }

    public class Chapter1_4
    {
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
