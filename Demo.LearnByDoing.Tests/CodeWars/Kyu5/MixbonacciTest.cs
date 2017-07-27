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
			// from https://oeis.org/A000045
			BigInteger[] result = {
				0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657,
				46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352,
				24157817, 39088169
			};

			var fibonacci = new Fibonacci();
			var actual = fibonacci.GetSequence(38).ToList();
			Assert.True(result.SequenceEqual(actual));
			Assert.Equal(0, actual[0]);
			Assert.Equal(1, actual[1]);
			Assert.Equal(1, actual[2]);
			Assert.Equal(2, actual[3]);
		}

		[Fact]
		public void TestPadovan()
		{
			int n = 49;
			// from https://oeis.org/A000045
			BigInteger[] result =
			{
				1, 0, 0, 1, 0, 1, 1, 1, 2, 2, 3, 4, 5, 7, 9, 12, 16, 21, 28, 37, 49, 65, 86, 114, 151, 200, 265, 351, 465, 616, 816,
				1081, 1432, 1897, 2513, 3329, 4410, 5842, 7739, 10252, 13581, 17991, 23833, 31572, 41824, 55405, 73396, 97229,
				128801, 170625
			};

			var padovan = new Padovan();
			var actual = padovan.GetSequence(n).ToList();
			Assert.True(result.SequenceEqual(actual));
			Assert.Equal(616, actual[29]);
			Assert.Equal(13581, actual[40]);
			Assert.Equal(170625, actual[49]);
		}

		[Fact]
		public void TestJacobsthal()
		{
			int n = 34;
			// from https://oeis.org/A000045
			BigInteger[] result =
			{
				0, 1, 1, 3, 5, 11, 21, 43, 85, 171, 341, 683, 1365, 2731, 5461, 10923, 21845, 43691, 87381, 174763, 349525, 699051,
				1398101, 2796203, 5592405, 11184811, 22369621, 44739243, 89478485, 178956971, 357913941, 715827883, 1431655765,
				2863311531, 5726623061
			};

			var jacobsthal = new Jacobsthal();
			var actual = jacobsthal.GetSequence(n).ToList();
			Assert.True(result.SequenceEqual(actual));
			Assert.Equal(0, actual[0]);
			Assert.Equal(1, actual[1]);
			Assert.Equal(1, actual[2]);
			Assert.Equal(3, actual[3]);
			Assert.Equal(5, actual[4]);
			Assert.Equal(349525, actual[20]);
			Assert.Equal(5726623061, actual[34]);
		}
	}

	public class Jacobsthal
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 1)
			{
				yield return n;
				yield break;
			}

			BigInteger prev1 = 0;
			BigInteger prev2 = 1;

			yield return prev1;
			yield return prev2;

			for (int i = 2; i <= n; i++)
			{
				var current = prev2 + (2 * prev1);
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public class Padovan
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 2)
			{
				if (n == 0) yield return 1;
				if (n == 1) yield return 0;
				if (n == 2) yield return 0;

				yield break;
			}

			BigInteger prev0 = 1;
			BigInteger prev1 = 0;
			BigInteger prev2 = 0;
			BigInteger current = prev0 + prev1;

			yield return prev0;
			yield return prev1;
			yield return prev2;

			for (int i = 3; i <= n; i++)
			{
				current = prev0 + prev1;
				yield return current;

				prev0 = prev1;
				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public class Fibonacci
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 1)
			{
				yield return n;
				yield break;
			}

			BigInteger prev1 = 0;
			BigInteger prev2 = 1;
			BigInteger current = prev1 + prev2;

			yield return prev1;
			yield return prev2;

			for (int i = 2; i <= n; i++)
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
