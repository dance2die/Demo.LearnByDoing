using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class LinkedListTest : BaseTest
	{
		public LinkedListTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestEdgeCases()
		{
			var sut = new SungLinkedList<int>();

			// When nothing's added, there shoun't be *ANY* result.
			Assert.False(sut.Traverse().Any());
		}

		[Fact]
		public void TestLinkedList()
		{
			var sut = new SungLinkedList<int>();

			// Arrange
			sut.Append(1);
			sut.Append(2);
			sut.Append(3);

			// Act
			var actual = sut.Traverse().Select(node => node.Value);

			// Assert
			int[] expected = { 1, 2, 3 };
			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public class SungLinkedList<T>
	{
		public SungNode<T> Head { get; set; }

		public IEnumerable<SungNode<T>> Traverse()
		{
			var current = Head;

			while (current != null)
			{
				yield return current;

				current = current.Next;
			}
		}

		public SungNode<T> Append(T value)
		{
			var newNode = new SungNode<T>(value);

			if (Head == null)
			{
				Head = newNode;
			}
			else
			{
				var lastNode = Traverse().LastOrDefault();
				lastNode.Next = newNode;
			}

			return newNode;
		}

		//public void InsertAt(Node<T> node, T value)
		//{
			
		//}

		//public void Remove(Node<T> node)
		//{
			
		//}
	}

	public class SungNode<T>
	{
		public T Value { get; set; }
		public SungNode<T> Next { get; set; }
		
		public SungNode(T value)
		{
			Value = value;
			Next = null;
		}
	}
}
