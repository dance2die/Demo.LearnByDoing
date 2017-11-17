using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
	public class RecursionTest : BaseTest
	{
		public RecursionTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(new []{1,2,3}, 6)]
		[InlineData(new []{2, 4, 8}, 14)]
		[InlineData(new []{-1, 0, 1}, 0)]
		public void TestSumming(int[] input, int expected)
		{
			var sut = new RecursionStuff();
			int actual = sut.GetSum(input);
			Assert.Equal(expected, actual);
		}
	}

	public class RecursionStuff
	{
		public int GetSum(int[] input)
		{
			return GetSumRecursively(input, input.Length - 1);
		}

		private int GetSumRecursively(int[] input, int i)
		{
			if (i == 0) return input[i];

			return input[i] + GetSumRecursively(input, i - 1);
		}
	}
}
