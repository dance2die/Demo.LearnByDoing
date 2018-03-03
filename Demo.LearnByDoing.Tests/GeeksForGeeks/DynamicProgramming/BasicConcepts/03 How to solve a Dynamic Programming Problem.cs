using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicConcepts
{
    /// <summary>
    /// https://www.geeksforgeeks.org/solve-dynamic-programming-problem/
    /// 
    /// Given 3 numbers {1, 3, 5}, we need to tell
    /// the total number of ways we can form a number 'N' 
    /// using the sum of the given three numbers.
    /// (allowing repetitions and different arrangements).
    /// 
    /// Total number of ways to form 6 is : 8
    /// 1+1+1+1+1+1
    /// 1+1+1+3
    /// 1+1+3+1
    /// 1+3+1+1
    /// 3+1+1+1
    /// 3+3
    /// 1+5
    /// 5+1
    /// </summary>
    public class _03_How_to_solve_a_Dynamic_Programming_Problem
    {
        private readonly NumberOfWays _sut;

        public _03_How_to_solve_a_Dynamic_Programming_Problem()
        {
            _sut = new NumberOfWays();
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestNaiveAnswer(int expected, int n)
        {
            int actual = _sut.GetNumberOfWaysNaiveWay(n);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestMemoizationAnswer(int expected, int n)
        {
            int actual = _sut.GetNumberOfWaysMemoization(n);
            Assert.Equal(expected, actual);
        }


        public static IEnumerable<object[]> GetSamples()
        {
            yield return new object[] { 8, 6 };
            yield return new object[] { 12, 7 };
            yield return new object[] { 19, 8 };
        }

        [Theory]
        [MemberData(nameof(GetBytelandianSamples))]
        public void TestBytelandianGoldCoins(int expected, int n)
        {
            var sut = new BytelandianGoldCoins();
            int actual = sut.GetNumberOfWays(n);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetBytelandianSamples()
        {
            yield return new object[] { 2, 12 };
            yield return new object[] { 2, 13 };
        }

    }

    /// <summary>
    /// http://www.spoj.com/problems/COINS/
    /// </summary>
    public class BytelandianGoldCoins
    {
        private int[] _ways;
        public int GetNumberOfWays(int n)
        {
            if (_ways == null) _ways = new int[n + 1];
            if (n <= 0) return 0;
            if (n > 0) return 1;
            if (_ways[n] != default) return _ways[n];

            Func<int, int> getNextNumber = divisor => divisor > n ? -1 :
                n % divisor == 0 ? n / divisor : -1;
            _ways[n] = GetNumberOfWays(getNextNumber(4)) + GetNumberOfWays(getNextNumber(3)) + GetNumberOfWays(getNextNumber(2));
            return _ways[n];
        }
    }

    public class NumberOfWays
    {
        public int GetNumberOfWaysNaiveWay(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            return GetNumberOfWaysNaiveWay(n - 1) + GetNumberOfWaysNaiveWay(n - 3) + GetNumberOfWaysNaiveWay(n - 5);
        }

        private int[] _ways;
        public int GetNumberOfWaysMemoization(int n)
        {
            if (_ways == null) _ways = new int[n + 1];
            if (n < 0) return 0;
            if (n == 0) return 1;
            if (_ways[n] != default) return _ways[n];

            _ways[n] =
                GetNumberOfWaysMemoization(n - 1) +
                GetNumberOfWaysMemoization(n - 3) +
                GetNumberOfWaysMemoization(n - 5);

            return _ways[n];
        }
    }
}
