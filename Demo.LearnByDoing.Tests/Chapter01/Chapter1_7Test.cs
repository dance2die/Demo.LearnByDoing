using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Rotate Matrix:
    /// Given an image represented by an NxN matrix, 
    /// where each piexel in the image is 4 bytes, 
    /// write a method to rotate the image by 90 degrees. 
    /// Can you do this in place?
    /// </summary>
    public class Chapter1_7Test : BaseTest
    {
        private readonly Chapter1_7 _sut = new Chapter1_7();

        public Chapter1_7Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter1_7
    {
    }

    public class Chapter1_7Data : IEnumerable<object[]>
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
