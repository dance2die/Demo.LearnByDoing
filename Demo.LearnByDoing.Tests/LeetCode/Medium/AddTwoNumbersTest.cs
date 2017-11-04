﻿using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Xunit;

namespace Demo.LearnByDoing.Tests.LeetCode.Medium
{
	/// <summary>
	/// https://leetcode.com/problems/add-two-numbers/description/
	/// </summary>
	public class AddTwoNumbersTest
	{
		[Fact]
		public void TestSampleCase()
		{
			var sut = new Solution();
			var left = sut.BuildNode(342);
			var right = sut.BuildNode(465);

			var sumNode = sut.AddTwoNumbers(left, right);
			BigInteger expected = 807;
			Assert.Equal(expected, sut.GetNodeValue(sumNode));
		}
	}

	public class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			var left = GetNodeValue(l1);
			var right = GetNodeValue(l2);
			var sum = left + right;

			return BuildNode(sum);
		}

		public BigInteger GetNodeValue(ListNode n)
		{
			var buffer = new StringBuilder();

			while (n != null)
			{
				buffer.Insert(0, n.val);
				n = n.next;
			}

			return BigInteger.Parse(buffer.ToString());
		}

		public ListNode BuildNode(BigInteger value)
		{
			var digits = GetDigitsReverse(value).ToList();
			var node = new ListNode(digits[0]);
			var head = node;
			digits.Skip(1).Aggregate(node, (acc, digit) =>
			{
				var newNode = new ListNode(digit);
				acc.next = newNode;
				return newNode;
			});

			return head;
		}

		private IEnumerable<int> GetDigitsReverse(BigInteger value)
		{
			return value.ToString().Reverse().Select(c => int.Parse(c.ToString()));
		}
	}

	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}
}
