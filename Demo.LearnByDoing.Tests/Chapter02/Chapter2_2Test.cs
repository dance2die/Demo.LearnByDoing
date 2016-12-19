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
        [ClassData(typeof(Chapter2_2Data))]
        public void TestGettingKthElementToTheLastElementOfASinglyLinkedList(
            Node<int> input, int k, Node<int> expected)
        {
            //Node<int> actual = _sut.GetKthToLastElementsOfNode(input, k);
            
            
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        private T _data;

        public Node(T data)
        {
            _data = data;
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

    public class Chapter2_2
    {
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

    public class Chapter2_2Data2 : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                
            }
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
