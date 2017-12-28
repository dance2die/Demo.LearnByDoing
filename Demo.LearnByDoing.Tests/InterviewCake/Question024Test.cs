using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/reverse-linked-list
	/// 
	///   Hooray! It's opposite day. Linked lists go the opposite way today.
	/// 
	/// Write a method for reversing a linked list. ↴ Do it in-place. ↴
	/// 
	/// Your method will have one input: the head of the list.
	/// 
	/// Your method should return the new head of the list.
	/// 
	/// Here's a sample linked list node class:
	/// 
	/// public class LinkedListNode
	/// {
	///		public int Value { get; set; }
	///		public LinkedListNode Next { get; set; }
	/// 
	///		public LinkedListNode(int value)
	///		{
	///			Value = value;
	///		}
	/// }
	/// 
	/// </summary>
	public class Question024Test
	{
		[Fact]
		public void TestReverse()
		{
			var root = new LinkedListNode(1) {Next = new LinkedListNode(2) {Next = new LinkedListNode(3)}};
			var expected = new LinkedListNode(3) {Next = new LinkedListNode(2) {Next = new LinkedListNode(1)}};

			var actual = ReverseLinkedList(root);
			Assert.True(expected.Traverse().SequenceEqual(actual.Traverse()));
		}

		private LinkedListNode ReverseLinkedList(LinkedListNode head)
		{
			LinkedListNode prev = null;
			var current = head;
			var next = head.Next;

			while (true)
			{
				current.Next = prev;
				prev = current;
				current = next;
				if (next == null) return prev;
				next = next.Next;
			}
		}

		public class LinkedListNode
		{
			public int Value { get; set; }
			public LinkedListNode Next { get; set; }

			public LinkedListNode(int value)
			{
				Value = value;
			}

			public IEnumerable<int> Traverse()
			{
				var root = this;
				while (root != null)
				{
					yield return root.Value;
					root = root.Next;
				}
			}
		}
	}
}
