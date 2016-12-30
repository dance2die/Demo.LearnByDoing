using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Intersection:
    /// Given two (singly) linked lists, determine if the two lists intersect.
    /// Return the intersecting node. Note that the intersection is defined based on reference, not value.
    /// That is, if the kth node of the first linked list is the exact same node (by reference)
    /// as the jth node of the second linked list, then they are intersecting
    /// </summary>
    public class Chapter2_7Test : Chapter2TestBase
    {
        private readonly Chapter2_7 _sut = new Chapter2_7();

        public Chapter2_7Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_7Data))]
        public void TestNodeIntersection(Tuple<Node<int>, Node<int>> nodes, bool expected)
        {
            
        }
    }

    public class Chapter2_7
    {
    }

    public class Chapter2_7Data : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetNodes1(), true },
            new object[] { GetNodes2(), true },
            new object[] { GetNodes3(), false },
            new object[] { GetNodes4(), false },
        };

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 intersections with node1 at value 2.
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes1()
        {
            var node1 = GetInputNode(1, 5);
            var node2 = node1.Next;

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 1 -> 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 intersections with node1 at value 1.
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes2()
        {
            var node1 = GetInputNode(1, 5);
            var node2 = node1;

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 doesn't intersect with node 1
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes3()
        {
            var node1 = GetInputNode(1, 5);
            var node2 = GetInputNode(2, 5);

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 1 -> 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 doesn't intersect with node 1
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes4()
        {
            var node1 = GetInputNode(1, 5);
            var node2 = GetInputNode(1, 5);

            return Tuple.Create(node1, node2);
        }
    }
}
