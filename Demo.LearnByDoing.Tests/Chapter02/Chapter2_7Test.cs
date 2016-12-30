using System;
using System.Collections.Generic;
using System.Linq;
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
            bool actual = _sut.AreNodesIntersecting(nodes.Item1, nodes.Item2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter2_7
    {
        public bool AreNodesIntersecting(Node<int> node1, Node<int> node2)
        {
            if (node1 == node2) return true;

            return AreIntersecting(node1, node2).AreIntersecting;
        }

        private NodeResult<int> AreIntersecting(Node<int> node1, Node<int> node2)
        {
            if (node1 == node2) return new NodeResult<int>(node1, node2, true);
            if (node1.Next != null && node2.Next == null) return new NodeResult<int>(node1, node2, false);
            if (node1.Next == null && node2.Next != null) return new NodeResult<int>(node1, node2, false);

            var areIntersecting = AreIntersecting(node1, node2.Next).AreIntersecting ||
                                  AreIntersecting(node1.Next, node2).AreIntersecting;
            return new NodeResult<int>(node1, node2, areIntersecting);

            //if (node1.Next == null && node2.Next == null) return new NodeResult<int>(node1, node2, false);
            //if (node1.Next != null && node2.Next == null) return new NodeResult<int>(node1.Next, node2, false);
            //if (node1.Next == null && node2.Next != null) return new NodeResult<int>(node1, node2.Next, false);
            //if (node1.Next != null && node2.Next !=null) return new NodeResult<int>(node1.Next, node2.Next, false);

            ////if (node1 == null && node2 != null) return new NodeResult<int>(new Node<int>(0), node2.Next, false);
            ////if (node1 != null && node2 == null) return new NodeResult<int>(node1.Next, new Node<int>(0), false);
            ////if (node1 != null && node2 != null) return new NodeResult<int>(node1.Next, node2.Next, false);
            //////if (node1 == null && node2 == null) return new NodeResult<int>(new Node<int>(0), node2.Next, false);

            //return new NodeResult<int>(new Node<int>(0), new Node<int>(0), false);
        }
    }

    internal class NodeResult<T>
    {
        public Node<T> Node1 { get; set; }
        public Node<T> Node2 { get; set; }
        public bool AreIntersecting { get; set; }

        public NodeResult(Node<T> node1, Node<T> node2, bool areIntersecting)
        {
            Node1 = node1;
            Node2 = node2;
            AreIntersecting = areIntersecting;
        }
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
        /// where node2 intersects with node1 at value 2.
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes1()
        {
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = node1.Next;

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 1 -> 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 intersects with node1 at value 1.
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes2()
        {
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
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
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = GetInputNode(Enumerable.Range(2, 4).ToArray());

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
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = GetInputNode(Enumerable.Range(1, 5).ToArray());

            return Tuple.Create(node1, node2);
        }
    }
}
