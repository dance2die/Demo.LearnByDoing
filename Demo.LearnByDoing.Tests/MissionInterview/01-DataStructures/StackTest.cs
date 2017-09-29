using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	/// <summary>
	/// Implementing Stack using SungLinkedList
	/// </summary>
	public class StackTest : BaseTest
	{
		public StackTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestPush()
		{
			var sut = new SungStack<int>();
			sut.Push(1);
			sut.Push(2);
			sut.Push(3);

			int[] expected = {3, 2, 1};
			Assert.True(expected.SequenceEqual(sut.Traverse().ToArray()));
		}
	}

	public class SungStack<T>
	{
		private readonly SungLinkedList<T> _list;
		private int _count;

		public SungStack()
		{
			_list = new SungLinkedList<T>();
			_count = 0;
		}

		public void Push(T value)
		{
			_count++;
			var newNode = new SungNode<T>(value);
			newNode.Next = _list.Head;
			_list.Head = newNode;
		}

		public IEnumerable<T> Traverse()
		{
			return _list.Traverse().Select(o => o.Value);
		}
	}
}
