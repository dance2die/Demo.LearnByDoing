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
}
