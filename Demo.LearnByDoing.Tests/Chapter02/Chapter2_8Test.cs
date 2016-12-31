using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Loop Detection:
    /// 
    /// Given a circular linked list, implement an algorithm that returns the node at the beginning of the loop.
    /// 
    /// DEFINITION
    /// Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node,
    /// so as to make a loop in the linked list.
    /// 
    /// EXAMPLE
    /// Input:  A -> B -> C -> D -> E -> C [the same C as earlier]
    /// Output: C
    /// </summary>
    public class Chapter2_8Test : Chapter2TestBase
    {
        private readonly Chapter2_8 _sut = new Chapter2_8();

        public Chapter2_8Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter2_8
    {
    }
}
