using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class SungTreeTest : BaseTest
	{
		public SungTreeTest(ITestOutputHelper output) : base(output)
		{
		}

		public static SungBinaryTreeNode<int> GetSampleTree()
		{
			return new SungBinaryTreeNode<int>(1000)
			{
				Left = new SungBinaryTreeNode<int>(500)
				{
					Left = new SungBinaryTreeNode<int>(400)
					{
						Left = new SungBinaryTreeNode<int>(220),
						Right = new SungBinaryTreeNode<int>(260)
					},
					Right = new SungBinaryTreeNode<int>(450)
					{
						Left = new SungBinaryTreeNode<int>(250),
						Right = new SungBinaryTreeNode<int>(280)
					}
				},
				Right = new SungBinaryTreeNode<int>(500)
				{
					Left = new SungBinaryTreeNode<int>(380)
					{
						Left = new SungBinaryTreeNode<int>(210),
						Right = new SungBinaryTreeNode<int>(220)
					},
					Right = new SungBinaryTreeNode<int>(350)
					{
						Left = new SungBinaryTreeNode<int>(230),
						Right = new SungBinaryTreeNode<int>(240)
					}
				}
			};
		}

		public static IEnumerable<object[]> GetPreData()
		{
			yield return new object[] {new List<int>{1000, 500, 400, 220, 260, 450, 250, 280, 500, 380, 210, 220, 350, 230, 240}, GetSampleTree()};
		}

		[Theory]
		[MemberData(nameof(GetPreData))]
		public void TestPreTraversal(List<int> expected, SungBinaryTreeNode<int> root)
		{
			var sut = new SungBinaryTreeTraverser();
			var actual = sut.TraversePre(root);

			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class SungBinaryTreeTraverser
	{
		public IEnumerable<T> TraversePre<T>(SungBinaryTreeNode<T> root)
		{
			if (root == null) yield break;

			yield return root.Value;
			foreach (var value in TraversePre(root.Left)) yield return value;
			foreach (var value in TraversePre(root.Right)) yield return value;
		}
	}

	public class SungBinaryTreeNode<T>
	{
		public T Value { get; set; }
		public SungBinaryTreeNode<T> Left { get; set; }
		public SungBinaryTreeNode<T> Right { get; set; }

		public SungBinaryTreeNode(T value)
		{
			Value = value;
		}

		public SungBinaryTreeNode<T> AddLeft(T value)
		{
			Left = new SungBinaryTreeNode<T>(value);
			return this;
		}

		public SungBinaryTreeNode<T> AddRight(T value)
		{
			Right = new SungBinaryTreeNode<T>(value);
			return this;
		}
	}
}
