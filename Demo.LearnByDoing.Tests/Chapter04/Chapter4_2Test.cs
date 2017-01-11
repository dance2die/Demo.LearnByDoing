using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    /// <summary>
    /// MINIMAL TREE:
    /// Given a sorted (increasing order) array with unique integer elements,
    /// write an alogrithm to create a binary search tree with minimal height.
    /// </summary>
    public class Chapter4_2Test : BaseTest
    {
        private readonly Chapter4_2 _sut = new Chapter4_2();

        public Chapter4_2Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter4_2
    {
    }

    public class Chapter4_2Data : Chapter4TestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            
        };
    }
}
