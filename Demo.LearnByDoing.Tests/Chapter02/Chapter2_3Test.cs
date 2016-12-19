using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Delete Middle Node:
    /// Implement an algorithm to delete a node in the middle
    /// (i.e., any node but the first and last node, not necessarily the exact middle)
    /// of a singly linked list, given only access to that node
    /// 
    /// EXAMPLE
    /// Input:  the node c from the linked list 
    ///         a -> b -> c -> d -> e -> f
    /// Result: nothing is returned, but the new linked list looks like 
    ///         a -> b -> d -> e -> f 
    /// </summary>
    public class Chapter2_3Test : BaseTest
    {
        private readonly Chapter2_3 _sut = new Chapter2_3();

        public Chapter2_3Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter2_3
    {
    }
}
