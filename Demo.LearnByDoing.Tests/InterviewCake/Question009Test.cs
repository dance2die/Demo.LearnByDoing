﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question009Test
	{
		public static IEnumerable<object[]> GetCases()
		{
			var root = new BinaryTreeNode(1);
			yield return new object[] { true, root };

			var root0 = new BinaryTreeNode(1);
			root0.InsertLeft(2);
			yield return new object[] { false, root0 };

			var root01 = new BinaryTreeNode(1).InsertRight(3);
			yield return new object[] { true, root01 };

			var root02 = new BinaryTreeNode(2);
			root02.InsertLeft(1);
			root02.InsertRight(10);
			yield return new object[] { true, root02 };

			var root2 = new BinaryTreeNode(4);
			var l1 = root2.InsertLeft(2);
			var r1 = root2.InsertRight(6);
			l1.InsertLeft(1);
			l1.InsertRight(3);
			r1.InsertLeft(5);
			r1.InsertRight(7);
			yield return new object[] { true, root2 };

			var root3 = new BinaryTreeNode(4);
			root3.InsertLeft(2).InsertLeft(1);
			root3.InsertRight(5);
			yield return new object[] { true, root3 };



			var root4 = new BinaryTreeNode(50);
			var l4 = root4.InsertLeft(30);
			var r4 = root4.InsertRight(80);
			l4.InsertLeft(20);
			l4.InsertRight(60);
			r4.InsertLeft(70);
			r4.InsertRight(90);
			yield return new object[] { false, root4 };

		}

		[Theory]
		[MemberData(nameof(GetCases))]
		void TestBinaryTreeChecker(bool expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeChecker();
			var actual = sut.IsBinarySearchTree(root);
			Assert.Equal(expected, actual);
		}
	}

	class BinaryTreeChecker
	{
		
		public bool IsBinarySearchTree(BinaryTreeNode root)
		{
			var numbers = TraverseInOrder(root).ToList();

			// check that next number is bigger than the previous one.
			int prev = numbers[0];
			for (int i = 1; i < numbers.Count; i++)
			{
				int curr = numbers[i];
				if (curr < prev) return false;

				prev = curr;
			}

			return true;
		}

		private IEnumerable<int> TraverseInOrder(BinaryTreeNode root)
		{
			if (root == null) yield break;

			foreach (var number in TraverseInOrder(root.Left).ToList()) yield return number;
			yield return root.Value;
			foreach (var number in TraverseInOrder(root.Right).ToList()) yield return number;
		}
	}
}
