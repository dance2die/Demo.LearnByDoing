﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.DataStructure.Tree
{
	public class BinaryTreeTraversalsTest
	{
		static BinaryTreeNode GetSampleBinaryTreeNode()
		{
			return new BinaryTreeNode(4)
			{
				Left = new BinaryTreeNode(2)
				{
					Left = new BinaryTreeNode(1),
					Right = new BinaryTreeNode(3)
				},
				Right = new BinaryTreeNode(6)
				{
					Left = new BinaryTreeNode(5),
					Right = new BinaryTreeNode(7)
				}
			};
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstRecursionPreOrderData))]
		public void TestRecursiveDepthFirstPreOrderRecursionSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsPreOrderRecursively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstRecursionInOrderData))]
		public void TestRecursiveDepthFirstInOrderRecursionSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsInOrderRecursively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstRecursionPostOrderData))]
		public void TestRecursiveDepthFirstPostOrderRecursionSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsPostOrderRecursively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		public static IEnumerable<object[]> GetDepthFirstRecursionPreOrderData()
		{
			yield return new object[] { new[] { 4, 2, 1, 3, 6, 5, 7 }, GetSampleBinaryTreeNode() };
		}

		public static IEnumerable<object[]> GetDepthFirstRecursionInOrderData()
		{
			yield return new object[] { new[] { 1, 2, 3, 4, 5, 6, 7 }, GetSampleBinaryTreeNode() };
		}

		public static IEnumerable<object[]> GetDepthFirstRecursionPostOrderData()
		{
			yield return new object[] { new[] { 1, 3, 2, 5, 7, 6, 4 }, GetSampleBinaryTreeNode() };
		}
	}

	public class BinaryTreeNodeTraverser
	{
		public IEnumerable<int> TraverseDfsPreOrderRecursively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			yield return root.Value;
			foreach (var n in TraverseDfsPreOrderRecursively(root.Left).ToList()) yield return n;
			foreach (var n in TraverseDfsPreOrderRecursively(root.Right).ToList()) yield return n;
		}

		public IEnumerable<int> TraverseDfsInOrderRecursively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			foreach (var n in TraverseDfsInOrderRecursively(root.Left).ToList()) yield return n;
			yield return root.Value;
			foreach (var n in TraverseDfsInOrderRecursively(root.Right).ToList()) yield return n;
		}

		public IEnumerable<int> TraverseDfsPostOrderRecursively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			foreach (var n in TraverseDfsPostOrderRecursively(root.Left).ToList()) yield return n;
			foreach (var n in TraverseDfsPostOrderRecursively(root.Right).ToList()) yield return n;
			yield return root.Value;
		}
	}

	public class BinaryTreeNode
	{
		public int Value { get; }
		public BinaryTreeNode Left { get; set; }
		public BinaryTreeNode Right { get; set; }

		public BinaryTreeNode(int value)
		{
			Value = value;
		}

		public BinaryTreeNode InsertLeft(int leftValue)
		{
			Left = new BinaryTreeNode(leftValue);
			return Left;
		}

		public BinaryTreeNode InsertRight(int rightValue)
		{
			Right = new BinaryTreeNode(rightValue);
			return Right;
		}
	}
}
