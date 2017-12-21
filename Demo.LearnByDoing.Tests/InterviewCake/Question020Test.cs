using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/largest-stack
	/// 
	/// You want to be able to access the largest element in a stack. 
	/// 
	/// Use the built-in Stack class to implement a new class MaxStack with a method GetMax() 
	/// that returns the largest element in the stack. GetMax() should not remove the item.
	/// 
	/// Your stacks will contain only integers. 
	/// </summary>
	public class Question020Test
	{
		public static IEnumerable<object[]> GetSampleData()
		{
			yield return new object[] {new [] {1, 3, 2, 10, 99, -1, 7, 8, 35}, 99};
			yield return new object[] {new [] {9, 8, 7, 6, 5}, 9};
			yield return new object[] {new [] {1, 2, 3, 4, 5}, 5};
			yield return new object[] {new [] {1, 2, 3, 2, 1}, 3};
		}

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleCases(int[] input, int expected)
		{
			var sut = new MaxStack();
			foreach (int value in input)
			{
				sut.Push(value);
			}

			int actual = sut.GetMax();
			Assert.Equal(expected, actual);
		}
	}

	public class MaxStack
	{
		private int _max = int.MinValue;
		private readonly Stack<int> _stack = new Stack<int>();

		public int Push(int value)
		{
			if (value > _max)
				_max = value;
			_stack.Push(value);

			return value;
		}

		public int GetMax()
		{
			return _max;
		}
	}
}
