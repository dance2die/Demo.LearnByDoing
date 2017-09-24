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

			// When something not in the list is removed, then there shouldn't be anything returned.
			Assert.Null(sut.Remove(null));

			// When something not in the list is removed, then there shouldn't be anything returned.
			Assert.Null(sut.Remove(new SungNode<int>(1)));
		}

		[Fact]
		public void TestInsertAndTraversal()
		{
			// Arrange
			var sut = new SungLinkedList<int>();
			sut.Append(1);
			sut.Append(2);
			sut.Append(3);

			// Act
			var actual = sut.Traverse().Select(node => node.Value);

			// Assert
			int[] expected = { 1, 2, 3 };
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestInsertAt()
		{
			// Arrange
			var sut = new SungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			sut.Append(3);

			// Act: Insert at 2
			sut.InsertAt(node, 10);

			// Assert
			int[] expected = {1, 2, 10, 3};
			var actual = sut.Traverse().Select(n => n.Value);
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestRemoving()
		{
			// Arrange
			var sut = new SungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			sut.Append(3);

			// Act: Remove 2.
			sut.Remove(node);

			// Assert
			int[] expected = { 1, 3 };
			var actual = sut.Traverse().Select(n => n.Value);
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

		public SungNode<T> InsertAt(SungNode<T> node, T value)
		{
			var newNode = new SungNode<T>(value) {Next = node.Next};
			node.Next = newNode;
			return newNode;
		}

		public SungNode<T> Remove(SungNode<T> node)
		{
			// if the node to remove is not found, then return null.
			if (Traverse().All(n => n.Equals(node))) return null;

			return null;
		}
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

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			return Value.Equals(((SungNode<T>) obj).Value);
		}

		protected bool Equals(SungNode<T> other)
		{
			return EqualityComparer<T>.Default.Equals(Value, other.Value) && Equals(Next, other.Next);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (EqualityComparer<T>.Default.GetHashCode(Value) * 397) ^ (Next != null ? Next.GetHashCode() : 0);
			}
		}
	}
}
