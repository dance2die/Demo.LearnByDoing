using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
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
    public class Chapter1_5Test : BaseTest
    {
        private readonly Chapter1_5 _sut = new Chapter1_5();

        public Chapter1_5Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter1_5
    {
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
