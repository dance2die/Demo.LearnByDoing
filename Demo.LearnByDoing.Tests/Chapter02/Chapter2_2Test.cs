using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Return Kth to Last:
    /// Implement an algorithm to find the kth to last element of a singly linked list.
    /// </summary>
    public class Chapter2_2Test : BaseTest
    {
        private readonly Chapter2_2 _sut = new Chapter2_2();

        public Chapter2_2Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_2Data))]
        public void TestGettingKthElementToTheLastElements(
            LinkedList<int> input, int k, LinkedList<int> expected)
        {
            LinkedList<int> actual = _sut.GetKthToLastElements(input, k);
            
            Assert.True(expected.SequenceEqual(actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_2Data2))]
        public void TestGettingKthElementToTheLastElementOfASinglyLinkedList(
            Node<int> input, int k, Node<int> expected)
        {
            Node<int> actual = _sut.GetKthToLastElementsOfNode(input, k);

            Assert.True(AreNodesEqual(expected, actual));
        }

        private bool AreNodesEqual(Node<int> expected, Node<int> actual)
        {
            while (expected != null && actual != null)
            {
                if (expected.Data != actual.Data) return false;

                expected = expected.Next;
                actual = actual.Next;

                if ((expected != null && actual == null) || (expected == null && actual != null)) return false;
            }

            return true;
        }
    }

    public class Chapter2_2
    {
        public Node<int> GetKthToLastElementsOfNode(Node<int> input, int k)
        {
            int i = 0;
            while (i < k)
            {
                input = input.Next;
                i++;
            }

            return input;
        }

        public LinkedList<int> GetKthToLastElements(LinkedList<int> input, int k)
        {
            LinkedList<int> result = new LinkedList<int>();

            for (int i = k; i < input.Count; i++)
            {
                result.AddLast(input.ElementAt(i));
            }

            return result;
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public void AddLast<T>(T data)
        {
            Node<T> currentNode = this as Node<T>;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            Node<T> newNode = new Node<T>(data);
            currentNode.Next = newNode;
        }
    }

    public class Chapter2_2Data2 : IEnumerable<object[]>
    {
        private const int UPTO = 5;
        private static readonly Node<int> _input = GetInputNode(1, UPTO);

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { _input, 0, _input },
            new object[] { _input, 1, GetInputNode(2, UPTO) },
            new object[] { _input, 2, GetInputNode(3, UPTO) },
            new object[] { _input, 3, GetInputNode(4, UPTO) },
            new object[] { _input, 4, GetInputNode(5, UPTO) }
        };

        private static Node<int> GetInputNode(int from, int to)
        {
            if (from > to) throw new IndexOutOfRangeException();

            Node<int> head = new Node<int>(from);
            Node<int> result = head;
            int i = from + 1;

            while (i <= to)
            {
                result.Next = new Node<int>(i);
                result = result.Next;
                i++;
            }

            return head;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Chapter2_2Data : IEnumerable<object[]>
    {
        private static readonly LinkedListWithInit<int> _input = new LinkedListWithInit<int> { 1, 2, 3, 4, 5 };

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { _input, 0, _input },
            new object[] { _input, 1, new LinkedListWithInit<int> { 2, 3, 4, 5 } },
            new object[] { _input, 2, new LinkedListWithInit<int> { 3, 4, 5 } },
            new object[] { _input, 3, new LinkedListWithInit<int> { 4, 5 } },
            new object[] { _input, 4, new LinkedListWithInit<int> { 5 } },
            new object[] { _input, 5, new LinkedListWithInit<int> { } }
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
