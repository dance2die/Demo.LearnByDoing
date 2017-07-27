using System;
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

		[Fact]
		public void TestPell()
		{
			int n = 31;
			// from https://oeis.org/A000045
			BigInteger[] result =
			{
				0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860, 33461, 80782, 195025, 470832, 1136689, 2744210, 6625109,
				15994428, 38613965, 93222358, 225058681, 543339720, 1311738121, 3166815962, 7645370045, 18457556052, 44560482149,
				107578520350, 259717522849
			};

			var pell = new Pell();
			var actual = pell.GetSequence(n).ToList();
			Assert.True(result.SequenceEqual(actual));
			Assert.Equal(0, actual[0]);
			Assert.Equal(1, actual[1]);
			Assert.Equal(2, actual[2]);
			Assert.Equal(5, actual[3]);
			Assert.Equal(12, actual[4]);
			Assert.Equal(107578520350, actual[30]);
			Assert.Equal(259717522849, actual[31]);
		}

		[Fact]
		public void TestTribonacci()
		{
			int n = 37;
			// from https://oeis.org/A000045
			BigInteger[] result =
			{
				0, 0, 1, 1, 2, 4, 7, 13, 24, 44, 81, 149, 274, 504, 927, 1705, 3136, 5768, 10609, 19513, 35890, 66012, 121415,
				223317, 410744, 755476, 1389537, 2555757, 4700770, 8646064, 15902591, 29249425, 53798080, 98950096, 181997601,
				334745777, 615693474, 1132436852
			};

			var tribonacci = new Tribonacci();
			var actual = tribonacci.GetSequence(n).ToList();
			Assert.True(result.SequenceEqual(actual));
			Assert.Equal(0, actual[0]);
			Assert.Equal(0, actual[1]);
			Assert.Equal(1, actual[2]);
			Assert.Equal(1, actual[3]);
			Assert.Equal(2, actual[4]);
			Assert.Equal(4, actual[5]);
			Assert.Equal(615693474, actual[36]);
			Assert.Equal(1132436852, actual[37]);
		}

		[Fact]
		public void TestTetranacci()
		{
			int n = 37;
			// from https://oeis.org/A000045
			BigInteger[] result =
			{
				0, 0, 0, 1, 1, 2, 4, 8, 15, 29, 56, 108, 208, 401, 773, 1490, 2872, 5536, 10671, 20569, 39648, 76424, 147312,
				283953, 547337, 1055026, 2033628, 3919944, 7555935, 14564533, 28074040, 54114452, 104308960, 201061985, 387559437,
				747044834, 1439975216, 2775641472
			};

			var tetranacci = new Tetranacci();
			var actual = tetranacci.GetSequence(n).ToList();
			Assert.True(result.SequenceEqual(actual));
			Assert.Equal(0, actual[0]);
			Assert.Equal(0, actual[1]);
			Assert.Equal(0, actual[2]);
			Assert.Equal(1, actual[3]);
			Assert.Equal(1, actual[4]);
			Assert.Equal(2, actual[5]);
			Assert.Equal(4, actual[6]);
			Assert.Equal(8, actual[7]);
			Assert.Equal(1439975216, actual[36]);
			Assert.Equal(2775641472, actual[37]);
		}

		[Fact]
		public void TestFactory()
		{
			var types = new []
			{
				"fib", "pad", "jac",
				"pel", "tri", "tet",
			};

			var classes = new[]
			{
				typeof(Fibonacci), typeof(Padovan), typeof(Jacobsthal),
				typeof(Pell), typeof(Tribonacci), typeof(Tetranacci),
			};

			for (int i = 0; i < types.Length; i++)
			{
				var type = types[i];
				IGetSequence strategy = Kata.GetNacciStrategy(type);

				var @class = classes[i];
				Assert.True(strategy.GetType() == @class);
			}
		}

		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] { new[] { "fib" }, 0, new BigInteger[] { } };
			yield return new object[] { new[] { "fib" }, 10, new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 } };
			yield return new object[] { new[] { "pad" }, 10, new BigInteger[] { 1, 0, 0, 1, 0, 1, 1, 1, 2, 2 } };
			yield return new object[] { new[] { "jac" }, 10, new BigInteger[] { 0, 1, 1, 3, 5, 11, 21, 43, 85, 171 } };
			yield return new object[] { new[] { "pel" }, 10, new BigInteger[] { 0, 1, 2, 5, 12, 29, 70, 169, 408, 985 } };
			yield return new object[] { new[] { "tri" }, 10, new BigInteger[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 } };
			yield return new object[] { new[] { "tet" }, 10, new BigInteger[] { 0, 0, 0, 1, 1, 2, 4, 8, 15, 29 } };
			yield return new object[] { new[] { "fib", "tet" }, 10, new BigInteger[] { 0, 0, 1, 0, 1, 0, 2, 1, 3, 1 } };
			yield return new object[] { new [] { "jac", "jac", "pel" }, 10, new BigInteger[] { 0, 1, 0, 1, 3, 1, 5, 11, 2, 21 } };
		}

		[Theory]
		[MemberData(nameof(GetTestCases))]
		public void BasicTests(string[] patterns, int n, BigInteger[] expected)
		{
			var actual = Kata.Mixbonacci(patterns, n);
			Assert.True(expected.SequenceEqual(actual));
		}
	}

	public partial class Kata
	{
		public static BigInteger[] Mixbonacci(string[] patterns, int n)
		{
			// Build sequence map
			var patternList = patterns.ToList();
			var sequenceMap = patternList
				.Distinct()
				.Select(pattern => new { Pattern = pattern, Strategy = Kata.GetNacciStrategy(pattern) })
				.ToDictionary(obj => obj.Pattern, obj => obj.Strategy.GetSequence(n).ToList());

			//var patternCountMap = Enumerable.Repeat(0, patterns.Length).ToArray();
			Dictionary<string, int> patternCountMap = new Dictionary<string, int>();
			foreach (string pattern in patterns)
			{
				if (!patternCountMap.ContainsKey(pattern))
					patternCountMap.Add(pattern, 0);
			}

			var actual = new List<BigInteger>(n);
			for (int i = 0; i < n; i++)
			{
				int patternIndex = i % patterns.Length;
				string pattern = patterns[patternIndex];
				int mapIndex = patternCountMap[pattern]++;

				actual.Add(sequenceMap[pattern][mapIndex]);
			}

			return actual.ToArray();
		}

		public static IGetSequence GetNacciStrategy(string pattern)
		{
			switch (pattern)
			{
				case "fib": return new Fibonacci();
				case "pad": return new Padovan();
				case "jac": return new Jacobsthal();
				case "pel": return new Pell();
				case "tri": return new Tribonacci();
				case "tet": return new Tetranacci();
				default: throw new Exception();
			}
		}
	}

	public class Tetranacci : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 3)
			{
				if (n == 0) yield return 0;
				if (n == 1) yield return 0;
				if (n == 2) yield return 0;
				if (n == 3) yield return 1;

				yield break;
			}

			BigInteger prev0 = 0;
			BigInteger prev1 = 0;
			BigInteger prev2 = 0;
			BigInteger prev3 = 1;

			yield return prev0;
			yield return prev1;
			yield return prev2;

			for (int i = 3; i <= n; i++)
			{
				var current = prev0 + prev1 + prev2 + prev3;

				prev3 = prev2;
				prev2 = prev1;
				prev1 = prev0;
				prev0 = current;

				yield return current;
			}

		}
	}

	public class Tribonacci : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 2)
			{
				if (n == 0) yield return 0;
				if (n == 1) yield return 0;
				if (n == 2) yield return 1;

				yield break;
			}

			BigInteger prev0 = 0;
			BigInteger prev1 = 0;
			BigInteger prev2 = 1;

			yield return prev0;
			yield return prev1;

			for (int i = 2; i <= n; i++)
			{
				var current = prev0 + prev1 + prev2;

				prev2 = prev1;
				prev1 = prev0;
				prev0 = current;

				yield return current;
			}

		}
	}

	public class Pell : IGetSequence
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
				var current = (2 * prev2) + prev1;
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}

		}
	}

	public class Jacobsthal : IGetSequence
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

	public class Padovan : IGetSequence
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

	public class Fibonacci : IGetSequence
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
				var current = prev1 + prev2;
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public interface IGetSequence
	{
		IEnumerable<BigInteger> GetSequence(int n);
	}
}
