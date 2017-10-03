using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
