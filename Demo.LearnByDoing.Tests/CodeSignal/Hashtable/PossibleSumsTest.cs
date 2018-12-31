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
                new[] {10, 50, 60, 100, 110, 150, 160, 200, 210},
                new[] {10, 50, 100}, new[] {1, 2, 1}
            };
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestHappyPaths(int[] expected, int[] coins, int[] quantity)
        {
            var actual = GetSums(coins, quantity);
            Assert.True(expected.OrderBy(_ => _).SequenceEqual(actual));
        }

        private IEnumerable<int> GetSums(int[] coins, int[] quantity)
        {
            var sums = new HashSet<int>();
            GetSums(coins, quantity, 0, sums, 0);
            return sums.OrderBy(_ => _);
        }

        private int? GetSums(int[] coins, int[] quantity, int startIndex, HashSet<int> sums, int acc)
        {
            if (startIndex >= coins.Length) return null;

            int? sum = null;
            for (int s = startIndex; s < coins.Length; s++)
            {
                for (int q = 1; q <= quantity[startIndex]; q++)
                {
                    for (int e = s; e < coins.Length; e++)
                    {
                        var currentValue = q * coins[s];
                        if (!sums.Contains(currentValue)) sums.Add(currentValue);
                        if (!sums.Contains(currentValue + acc)) sums.Add(currentValue + acc);

                        var nextValue = (GetSums(coins, quantity, s + 1, sums, currentValue + acc) ?? 0);
                        sum = currentValue + nextValue;
                        if (!sums.Contains(sum.Value)) sums.Add(sum.Value);
                        if (!sums.Contains(sum.Value + acc)) sums.Add(sum.Value + acc);
                    }
                }
            }

            return sum;
        }
    }
}