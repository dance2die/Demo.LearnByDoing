using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
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
    public class Chapter2_5Test : Chapter2TestBase
    {
        private readonly Chapter2_5 _sut = new Chapter2_5();

        public Chapter2_5Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Reverse))]
        public void TestReverseAdditionOfNodes(Node<int> left, Node<int> right, Node<int> expected)
        {
            Node<int> actual = _sut.AddReverseNodes(left, right);

            Assert.True(AreNodesEqual(expected, actual));
        }
    }

    public class Chapter2_5
    {
        public Node<int> AddReverseNodes(Node<int> left, Node<int> right)
        {
            const int startDigit = 1;
            return ConvertToReverseNode(SumNodes(left, right, startDigit));
        }

        private int SumNodes(Node<int> left, Node<int> right, int digit)
        {
            int nextDigit = digit * 10;

            if (left == null && right.Next != null)
            {
                return SumNodes(new Node<int>(0), right.Next, nextDigit);
            }

            if (left != null && right == null)
            {
                return SumNodes(left.Next, new Node<int>(0), nextDigit);
            }

            if (left == null && right == null) return 0;

            if (left.Next == null && right.Next == null)
            {
                return (left.Data * digit) + (right.Data * digit);
            }

            return SumNodes(left.Next, right.Next, nextDigit);
        }

        private Node<int> ConvertToReverseNode(int value)
        {
            var numbers = value.ToString().ToCharArray().Cast<int>().ToList();
            Node<int> result = new Node<int>(numbers.FirstOrDefault());
            Node<int> head = result;

            foreach (int number in numbers.Skip(1))
            {
                result.Next = new Node<int>(number);
                result = result.Next;
            }

            return head;
        }
    }

    public class Chapter2_5Data_Reverse : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(9, 1), GetInputNode(5), GetInputNode(4, 2) },
            new object[] { GetInputNode(7, 1, 6), GetInputNode(5, 9, 2), GetInputNode(2, 1, 9) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(0, 0, 1), GetInputNode(9, 9, 0, 1) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(0, 1), GetInputNode(9, 0, 0, 1) },
        };
    }

    public class Chapter2_5Data_Forward : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(9), GetInputNode(5), GetInputNode(1, 4) },
            new object[] { GetInputNode(6, 1, 7), GetInputNode(2, 9, 5), GetInputNode(9, 1, 2) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(1, 0, 0), GetInputNode(1, 0, 9, 9) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(1, 0), GetInputNode(1, 0, 0, 9) },
        };
    }
}
