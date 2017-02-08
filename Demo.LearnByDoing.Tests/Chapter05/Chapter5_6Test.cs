using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// CONVERSION:
    /// Write a function to determine the number of bits 
    /// you would need to flip to convert integer A to integer B
    /// 
    /// EXAMPLE
    /// Input:  29 (or: 11101), 15 (or 01111)
    /// Output: 2
    /// Hints: #336, #369
    /// </summary>
    public class Chapter5_6Test : BaseTest
    {
        private readonly Chapter5_6 _sut = new Chapter5_6();

        public Chapter5_6Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter5_6Data))]
        public void TestGettingNumberOfFlippedBits(int n1, int n2, int expected)
        {
            
        }
    }

    public class Chapter5_6
    {
    }

    public class Chapter5_6Data : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {29, 15, 2}
        };
    }
}
