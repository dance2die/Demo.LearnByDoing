using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Partition:
    /// Write code to partition a linked list around a value x, 
    /// such that all nodes less than x come before all nodes greater than or equal to x.
    /// If x is contained within the list, the values of x only need to be after the elements less than x (see below).
    /// The partition element x can appear anywhere in the "right partition";
    /// it does not need to appear between the left and right partitions.
    /// 
    /// EXAMPLE:
    /// Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
    /// Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
    /// </summary>
    public class Chapter2_4Test : BaseTest
    {
        private readonly Chapter2_4 _sut = new Chapter2_4();

        public Chapter2_4Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter2_4
    {
    }

    public class Chapter2_4Data : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            
        };
    }
}
