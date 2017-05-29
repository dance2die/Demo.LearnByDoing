using System;
using System.Linq;

namespace Demo.LearnByDoing.General.LinkedList
{
	public class ReverseLinkedListProgram
	{
		public static void Main(string[] args)
		{
			Console.WriteLine($"{BuildLinkedList()} to {ReverseIteratively(BuildLinkedList())}");
			//Console.WriteLine(ReverseRecursively(BuildLinkedList()));
		}

		private static Node<int> ReverseIteratively(Node<int> head)
		{
			Node<int> curr = head;
			Node<int> prev = null;

			do
			{
				var next = curr.Next;
				curr.Next = prev;
				prev = curr;
				if (next == null) break;
				curr = next;
			} while (true);

			return curr;
		}

		private static Node<int> BuildLinkedList()
		{
			Node<int> root = new Node<int>(1, null);
			var head = root;

			foreach (var i in Enumerable.Range(2, 4))
			{
				root.Next = new Node<int>(i, null);
				root = root.Next;
			}

			return head;
		}
	}
}
