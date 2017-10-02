using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/parse-a-linked-list-from-a-string/train/csharp
	/// </summary>
	public class ParseALinkedListFromAStringTest
	{
		public void SampleTest()
		{
			Assert.Equal(new Node(1, new Node(2, new Node(3))), Kata.Parse("1 -> 2 -> 3 -> null"));
			Assert.Equal(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16))))), Kata.Parse("0 -> 1 -> 4 -> 9 -> 16 -> null"));
			Assert.Equal(null, Kata.Parse("null"));
		}
	}

	public static partial class Kata
	{
		public static Node Parse(string nodes)
		{
			return null;
		}
	}

	public class Node : Object
	{
		public int Data;
		public Node Next;

		public Node(int data, Node next = null)
		{
			this.Data = data;
			this.Next = next;
		}

		public override bool Equals(Object obj)
		{
			// Check for null values and compare run-time types.
			if (obj == null || GetType() != obj.GetType()) { return false; }

			return this.ToString() == obj.ToString();
		}

		public override string ToString()
		{
			List<int> result = new List<int>();
			Node curr = this;

			while (curr != null)
			{
				result.Add(curr.Data);
				curr = curr.Next;
			}

			return String.Join(" -> ", result) + " -> null";
		}
	}
}
