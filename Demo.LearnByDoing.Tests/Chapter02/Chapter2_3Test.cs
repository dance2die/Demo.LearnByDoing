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
    public class Chapter2_3Test : Chapter2TestBase
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
        [ClassData(typeof(Chapter2_3Data_Middle))]
        public void TestGettingMiddleNodesOnly(Node<string> input, Node<string> expected)
        {
            Node<string> actual = _sut.GetMiddleNodes(input);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_3Data_RemoveMiddle))]
        public void TestRemovingMiddleNode(string middleValue, Node<string> input, Node<string> expected)
        {
            Node<string> actual = _sut.RemoveMiddelValue(middleValue, input);

            Assert.True(AreNodesEqual(expected, actual));
        }
    }

    public class Chapter2_3
    {
        public Node<string> RemoveMiddelValue(string middleValue, Node<string> input)
        {
            return null;
        }

        public Node<string> GetMiddleNodes(Node<string> input)
        {
            const int minimumLength = 3;

            int nodeCount = GetNodeCount(input);
            if (nodeCount < minimumLength) throw new ArgumentOutOfRangeException(nameof(input), "Input should have at least 3 nodes!");

            // skip the first node and start from the 2nd node.
            input = input.Next;
            Node<string> tempNode = new Node<string>(input.Data);
            Node<string> head = tempNode;

            for (int i = 0; i < nodeCount - minimumLength; i++)
            {
                input = input.Next;
                tempNode.Next = new Node<string>(input.Data);

                tempNode = tempNode.Next;
            }

            return head;
        }

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

    public class Chapter2_3Data_RemoveMiddle : Chapter2_3Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { "b", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "c", "d", "e", "f") },
            new object[] { "c", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "b", "d", "e", "f") },
            new object[] { "d", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "b", "c", "e", "f") },
            new object[] { "e", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "b", "c", "d", "f") },
        };
    }

    public class Chapter2_3Data_Middle : Chapter2_3Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("b", "c", "d", "e") },
            new object[] { GetInputNode("a", "b", "c", "d", "e"), GetInputNode("b", "c", "d") },
            new object[] { GetInputNode("a", "b", "c", "d"), GetInputNode("b", "c") },
            new object[] { GetInputNode("a", "b", "c"), GetInputNode("b") },
        };
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
