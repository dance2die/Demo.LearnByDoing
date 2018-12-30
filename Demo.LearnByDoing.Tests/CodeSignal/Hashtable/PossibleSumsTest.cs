using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeSignal.Hashtable
{
    /// <summary>
    /// Question on
    /// https://app.codesignal.com/interview-practice/task/rMe9ypPJkXgk3MHhZ
    /// </summary>
    public class PossibleSumsTest : BaseTest
    {
        public PossibleSumsTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetSamples()
        {
            yield return new object[]
            {
                new[] {50, 60, 150, 160, 100, 110, 200, 210, 10, 100, 110}, 
                new[] {10, 50, 100}, new[] {1, 2, 1}
            };
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestHappyPaths(int[] expected, int[] coins, int[] quantity)
        {
            var actual = GetSums(coins, quantity);
            Assert.True(expected.OrderBy(_=>_).SequenceEqual(actual));
        }

        private IEnumerable<int> GetSums(int[] coins, int[] quantity)
        {
            var sums = new HashSet<int>();
            GetSums(coins, quantity, 0, sums);
            return sums.OrderBy(_ => _);
        }

        private int? GetSums(int[] coins, int[] quantity, int startIndex, HashSet<int> sums)
        {
            if (startIndex >= coins.Length) return null;

            for (int s = startIndex; s < coins.Length; s++)
            {
                for (int q = 1; q <= quantity.Length; q++)
                {
                    for (int e = s; e < coins.Length; e++)
                    {
                        var current = q * coins[s];
                        if (!sums.Contains(current)) sums.Add(current);

                        int sum = 0;
                        sum += current + GetSums(coins, quantity, s + 1, sums) ?? 0;
                        if (!sums.Contains(sum)) sums.Add(sum);
                    }
                }
            }

            return null;
        }
    }
}