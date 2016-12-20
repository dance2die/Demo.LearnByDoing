using System;
using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
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

        [Theory]
        [ClassData(typeof(Chapter2_3Data_Length))]
        public void TestGettingSinglyLinkedListLength(Node<string> input, int expected)
        {
            int actual = _sut.GetNodeCount(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        public void TestGettingMiddleNodesOnly(Node<string> input, Node<string> expected)
        {

        }
    }

    public class Chapter2_3
    {
        public int GetNodeCount(Node<string> input)
        {
            if (input == null) return 0;

            int count = 0;
            while (input != null)
            {
                input = input.Next;

                count++;
            }

            return count;
        }
    }

    public abstract class Chapter2_3Data : IEnumerable<object[]>
    {
        public abstract List<object[]> Data { get; set; }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected static Node<string> GetInputNode(params string[] nodeData)
        {
            Node<string> head = new Node<string>(nodeData[0]);
            Node<string> result = head;

            for (int i = 1; i < nodeData.Length; i++)
            {
                result.Next = new Node<string>(nodeData[i]);
                result = result.Next;
            }

            return head;
        }
    }

    public class Chapter2_3Data_Length : Chapter2_3Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode("a", "b", "c", "d", "e", "f"), 6 },
            new object[] { GetInputNode("a", "b", "c", "d", "e"), 5 },
            new object[] { GetInputNode("a", "b", "c", "d"), 4 },
            new object[] { GetInputNode("a", "b", "c"), 3 },
        };
    }
}
