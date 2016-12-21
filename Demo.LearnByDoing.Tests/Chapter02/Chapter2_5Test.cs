using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Sum Lists:
    /// You have two numers represented by a linked list,
    /// where each node contains a single digit.
    /// The digits are stored in reverse order, such that the 1's digit is at the head of the list.
    /// Write a function that adds the two numbers and returns the sum as a linked list.
    /// 
    /// EXAMPLE
    /// Input:  (7 -> 1 -> 6) + (5 -> 9 -> 2). That is 617 + 295
    /// Output: 2 -> 1 -> 9. That is, 912
    /// 
    /// FOLLOW UP
    /// Suppose the digits are stored in forward order. Repeat the above problem.
    /// EXAMPLE
    /// Input:  (6 -> 1 -> 7) + (2 -> 9 -> 5). That is, 617 + 295.
    /// Output: 9 -> 1 -> 2. That is 912.
    /// </summary>
    public class Chapter2_5Test : BaseTest
    {
        private readonly Chapter2_5 _sut = new Chapter2_5();

        public Chapter2_5Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter2_5
    {
    }

    public class Chapter2_5Data_Reverse : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(7, 1, 6), GetInputNode(5, 9, 2), GetInputNode(2, 1, 9) }
        };
    }

    public class Chapter2_5Data_Forward : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(6, 1, 7), GetInputNode(2, 9, 5), GetInputNode(9, 1, 2) }
        };
    }
}
