using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class DoublyLinkedListTest : BaseTest
	{
		public DoublyLinkedListTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestEdgeCases()
		{
			var sut = new DoublySungLinkedList<int>();

			// When nothing's added, there shoun't be *ANY* result.
			Assert.False(sut.Traverse().Any());

			//// When something not in the list is removed, then there shouldn't be anything returned.
			//Assert.Null(sut.Remove(null));

			//// When something not in the list is removed, then there shouldn't be anything returned.
			//Assert.Null(sut.Remove(new DoublySungNode<int>(1)));
		}

		[Fact]
		public void TestInsertAndTraversal()
		{
			// Arrange
			var sut = new DoublySungLinkedList<int>();
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
		public void TestTraversalCallback()
		{
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			sut.Append(2);
			sut.Append(3);

			int[] expected = { 1, 2, 3 };
			Assert.True(expected.SequenceEqual(sut.Traverse((curr, last) => false).Select(n => n.Value)));
			Assert.Empty(sut.Traverse((curr, last) => true));
		}

		[Fact]
		public void TestInsertAt()
		{
			// Arrange
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			sut.Append(3);

			// Act: Insert at 2
			sut.InsertAt(node, 10);

			// Assert
			int[] expected = { 1, 2, 10, 3 };
			var actual = sut.Traverse().Select(n => n.Value);
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestRemoving()
		{
			// Arrange
			var sut = new DoublySungLinkedList<int>();
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

		[Fact]
		public void TestPreviousNode()
		{
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			var node2 = sut.Append(3);

			// Test append
			Assert.True(node.Previous.Value == 1);

			// Test remove
			sut.Remove(node);
			Assert.True(node2.Previous.Value == 1);

			// Test insertAt
			var newNode = sut.InsertAt(node2, 5);
			Assert.True(newNode.Previous.Value == 3);
		}
	}

	public class DoublySungLinkedList<T>
	{
		public DoublySungNode<T> Head { get; set; }

		public IEnumerable<DoublySungNode<T>> Traverse(Func<DoublySungNode<T>, DoublySungNode<T>, bool> callback = null)
		{
			var current = Head;
			DoublySungNode<T> last = null;

			while (current != null)
			{
				var callbackResult = callback != null && callback(current, last);
				if (callbackResult) break;

				yield return current;

				last = current;
				current = current.Next;
			}
		}

		public DoublySungNode<T> Append(T value)
		{
			var newNode = new DoublySungNode<T>(value);

			if (Head == null)
			{
				Head = newNode;
			}
			else
			{
				var lastNode = Traverse().LastOrDefault();
				lastNode.Next = newNode;
				newNode.Previous = lastNode;
			}

			return newNode;
		}

		public DoublySungNode<T> InsertAt(DoublySungNode<T> node, T value)
		{
			var newNode = new DoublySungNode<T>(value)
			{
				Next = node.Next,
				Previous = node
			};

			if (node.Next != null) node.Next.Previous = newNode;
			node.Next = newNode;

			return newNode;
		}

		public void Remove(DoublySungNode<T> node)
		{
			if (Head.Equals(node))
			{
				Head.Next = Head.Next;
			}
			else
			{
				if (node.Previous != null)
				{
					node.Previous.Next = node.Next;
				}

				if (node.Next != null)
				{
					node.Next.Previous = node.Previous;
				}
			}
		}
	}

	public class DoublySungNode<T>
	{
		public T Value { get; set; }
		public DoublySungNode<T> Next { get; set; }
		public DoublySungNode<T> Previous { get; set; }

		public DoublySungNode(T value)
		{
			Value = value;
			Next = null;
			Previous = null;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			return Value.Equals(((DoublySungNode<T>)obj).Value);
		}

		protected bool Equals(DoublySungNode<T> other)
		{
			return EqualityComparer<T>.Default.Equals(Value, other.Value) && Equals(Next, other.Next) && Equals(Previous, other.Previous);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = EqualityComparer<T>.Default.GetHashCode(Value);
				hashCode = (hashCode * 397) ^ (Next != null ? Next.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Previous != null ? Previous.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
