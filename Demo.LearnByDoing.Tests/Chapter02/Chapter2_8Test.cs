using System.Collections.Generic;
using Xunit;
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

        [Theory]
        [ClassData(typeof(Chapter2_8Data))]
        public void TestDetectingNodeLoopStart(Node<string> node, string expected)
        {
            Assert.False(true);
        }
    }

    public class Chapter2_8
    {
    }

    public class Chapter2_8Data : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetLoopingNode1(), "C" },
            new object[] { GetLoopingNode2(), "B" }
        };

        private static Node<string> GetLoopingNode1()
        {
            Node<string> result = new Node<string>("A");

            result.Next = new Node<string>("B");
            Node<string> loopStart = new Node<string>("C");
            result.Next = loopStart;
            result.Next = new Node<string>("D");
            result.Next = new Node<string>("E");
            result.Next = loopStart;

            return result;
        }

        private static Node<string> GetLoopingNode2()
        {
            Node<string> result = new Node<string>("A");

            Node<string> loopStart = new Node<string>("B");
            result.Next = loopStart;
            result.Next = new Node<string>("C");
            result.Next = new Node<string>("D");
            result.Next = loopStart;

            return result;
        }
    }
}
