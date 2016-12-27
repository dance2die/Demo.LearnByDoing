using System;
using System.Collections.Generic;
using System.Linq;
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
            Node<int> actual = _sut.AddNodesReverse(left, right);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Padding))]
        public void TestPadZeroToIncreaseNodeLength(int length, Node<int> node, Node<int> expected)
        {
            Node<int> actual = _sut.PadZeroNodes(length, node);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Length))]
        public void TestNodeLengths(Node<int> node, int expected)
        {
            int actual = _sut.GetNodeLength(node);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Forward))]
        public void TestForwardAdditionOfNodes(Node<int> left, Node<int> right, Node<int> expected)
        {
            Node<int> actual = _sut.AddNodesForwards(left, right);

            _output.WriteLine("expected: {0}\nactual: {1}", expected, actual);
            Assert.True(AreNodesEqual(expected, actual));
        }
    }

    public class Chapter2_5
    {
        public Node<int> AddNodesForwards(Node<int> left, Node<int> right)
        {
            int leftLength = GetNodeLength(left);
            int rightLength = GetNodeLength(right);

            if (leftLength > rightLength)
                right = PadZeroNodes(leftLength, right);

            if (leftLength < rightLength)
                left = PadZeroNodes(rightLength, left);


            int startDigit = (int) Math.Pow(10.0, Math.Max(leftLength, rightLength) - 1);
            const int startNumber = 0;
            return ConvertToForwardNode(SumNodesForward(left, right, startDigit, startNumber));
        }

        private int SumNodesForward(Node<int> left, Node<int> right, int digit, int accum)
        {
            int nextDigit = digit / 10;
            var zeroNode = new Node<int>(0);

            if (left == null && right == null) return accum;

            var sum = (left.Data + right.Data) * digit;
            if (left.Next == null && right.Next == null) return accum + sum;
            if (left.Next != null && right.Next == null) return SumNodesForward(left.Next, zeroNode, nextDigit, accum + sum);
            if (left.Next == null && right.Next != null) return SumNodesForward(zeroNode, right.Next, nextDigit, accum + sum);
            if (left.Next != null && right.Next != null) return SumNodesForward(left.Next, right.Next, nextDigit, accum + sum);

            return SumNodesForward(left.Next, right.Next, nextDigit, accum + sum);
        }

        public Node<int> AddNodesReverse(Node<int> left, Node<int> right)
        {
            const int startDigit = 1;
            const int startNumber = 0;
            return ConvertToReverseNode(SumNodes(left, right, startDigit, startNumber));
        }

        public int GetNodeLength(Node<int> node)
        {
            Node<int> copy = node;
            int count = 0;
            while (copy != null)
            {
                count++;

                copy = copy.Next;
            }

            return count;
        }

        /// <param name="length">It's 1-based!</param>
        public Node<int> PadZeroNodes(int length, Node<int> node)
        {
            Node<int> head = node;

            for (int i = 1; i < length; i++)
            {
                node = node?.Next;
                if (node == null)
                {
                    var zeroNode = new Node<int>(0);
                    zeroNode.Next = head;
                    head = zeroNode;
                }

            }

            return head;
        }

        private int SumNodes(Node<int> left, Node<int> right, int digit, int accum)
        {
            int nextDigit = digit * 10;
            var zeroNode = new Node<int>(0);

            if (left == null && right == null) return accum;

            var sum = (left.Data + right.Data) * digit;
            if (left.Next == null && right.Next == null) return accum + sum;
            if (left.Next != null && right.Next == null) return SumNodes(left.Next, zeroNode, nextDigit, accum + sum);
            if (left.Next == null && right.Next != null) return SumNodes(zeroNode, right.Next, nextDigit, accum + sum);
            if (left.Next != null && right.Next != null) return SumNodes(left.Next, right.Next, nextDigit, accum + sum);

            return SumNodes(left.Next, right.Next, nextDigit, accum + sum);
        }

        private Node<int> ConvertToReverseNode(int value)
        {
            var numbers = value.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).Reverse().ToList();
            Node<int> result = new Node<int>(numbers.FirstOrDefault());
            Node<int> head = result;

            foreach (int number in numbers.Skip(1))
            {
                result.Next = new Node<int>(number);
                result = result.Next;
            }

            return head;
        }

        private Node<int> ConvertToForwardNode(int value)
        {
            var numbers = value.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
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

    public class Chapter2_5Data_Padding : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { 1, GetInputNode(5), GetInputNode(5) },
            new object[] { 2, GetInputNode(5), GetInputNode(0, 5) },
            new object[] { 3, GetInputNode(5), GetInputNode(0, 0, 5) },
            new object[] { 4, GetInputNode(5), GetInputNode(0, 0, 0, 5) },
            //new object[] { 2, GetInputNode(0, 5), GetInputNode(0, 5) },
            //new object[] { 3, GetInputNode(0, 5), GetInputNode(0, 0, 5) },
            //new object[] { 4, GetInputNode(0, 5), GetInputNode(0, 0, 0, 5) },
            new object[] { 3, GetInputNode(1, 5), GetInputNode(0, 1, 5) },
            new object[] { 4, GetInputNode(1, 5), GetInputNode(0, 0, 1, 5) },
            new object[] { 4, GetInputNode(2, 1, 5), GetInputNode(0, 2, 1, 5) },
        };
    }

    public class Chapter2_5Data_Length : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(9), 1 },
            new object[] { GetInputNode(7, 1), 2 },
            new object[] { GetInputNode(9, 9, 9), 3 },
            new object[] { GetInputNode(9, 9, 1, 2), 4 },  
            new object[] { GetInputNode(9, 9, 1, 2, 6), 5 },
        };
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
            new object[] { GetInputNode(1, 9), GetInputNode(5), GetInputNode(2, 4) },
            new object[] { GetInputNode(6, 1, 7), GetInputNode(2, 9, 5), GetInputNode(9, 1, 2) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(1, 0, 0), GetInputNode(1, 0, 9, 9) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(1, 0), GetInputNode(1, 0, 0, 9) },
        };
    }
}
