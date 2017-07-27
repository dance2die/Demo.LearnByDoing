using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/5811aef3acdf4dab5e000251/train/csharp
	/// </summary>
	public class MixbonacciTest : BaseTest
	{
		public MixbonacciTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetTestCases))]
		public void BasicTests(string[] patterns, int n, int[] expected)
		{

		}

		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] { new [] { "fib" }, 0, new int[0] { } };
			yield return new object[] { new [] { "fib" }, 10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 } };
			yield return new object[] { new [] { "pad" }, 10, new int[] { 1, 0, 0, 1, 0, 1, 1, 1, 2, 2 } };
			yield return new object[] { new [] { "jac" }, 10, new int[] { 0, 1, 1, 3, 5, 11, 21, 43, 85, 171 } };
			yield return new object[] { new [] { "pel" }, 10, new int[] { 0, 1, 2, 5, 12, 29, 70, 169, 408, 985 } };
			yield return new object[] { new [] { "tri" }, 10, new int[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 } };
			yield return new object[] { new [] { "tet" }, 10, new int[] { 0, 0, 0, 1, 1, 2, 4, 8, 15, 29 } };
			yield return new object[] { new [] { "fib", "tet" }, 10, new int[] { 0, 0, 1, 0, 1, 0, 2, 1, 3, 1 } };
			yield return new object[] { new [] { "jac", "jac", "pel" }, 10, new int[] { 0, 1, 0, 1, 3, 1, 5, 11, 2, 21 } };
		}

		[Fact]
		public void TestFibonacci()
		{
			int n = 39;
			// from https://oeis.org/A000045
			int[] result = {
				0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657,
				46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352,
				24157817, 39088169
			};

			var actual = new Fibonacci().GetSequence(n);
			Assert.True(result.SequenceEqual(actual));
		}
	}

	public class Fibonacci
	{
		public IEnumerable<int> GetSequence(int n)
		{
			if (n <= 1)
			{
				yield return n;
				yield break;
			}

			int prev1 = 0;
			int prev2 = 1;
			int current = prev1 + prev2;

			yield return prev1;
			yield return prev2;

			for (int i = 3; i <= n; i++)
			{
				current = prev1 + prev2;
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public partial class Kata
	{
		public static BigInteger[] Mixbonacci(string[] pattern, int length)
		{
			return null;
		}
	}
}
