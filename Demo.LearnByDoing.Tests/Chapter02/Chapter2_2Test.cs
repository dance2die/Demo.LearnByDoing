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
        public void TestGettingKthElementToTheLastElementOfASinglyLinkedList(
            LinkedList<int> input, int k, LinkedList<int> expected)
        {
            LinkedList<int> actual = _sut.GetKthToLastElements(input, k);

            Assert.True(expected.SequenceEqual(actual));
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

    public class Chapter2_2Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }, 0, new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }, 1, new LinkedListWithInit<int> { 2, 3, 4, 5 }
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }, 2, new LinkedListWithInit<int> { 3, 4, 5 }
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }, 3, new LinkedListWithInit<int> { 4, 5 }
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }, 4, new LinkedListWithInit<int> { 5 }
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3, 4, 5 }, 5, new LinkedListWithInit<int> { }
            },
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
