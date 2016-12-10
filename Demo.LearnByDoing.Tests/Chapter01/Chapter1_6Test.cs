using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// String Comparison:
    /// Implement a method to perform basic string compression using the counts of repeated characters.
    /// For example, the string aabcccccaaa would become a2b1c53.
    /// If "compressed" string would not become smaller than the original string, your method should return the original string.
    /// You can assume the string has only uppercase and lowercase letters (1-z).
    /// </summary>
    public class Chapter1_6Test : BaseTest
    {
        private readonly Chapter1_6 _sut = new Chapter1_6();

        public Chapter1_6Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter1_6
    {
    }

    public class Chapter1_6Data : IEnumerable<object[]>
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
