using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeSignal.InterviewPractice.BackTracking
{
    public class ClimbingStairCaseTest : BaseTest
    {
        public ClimbingStairCaseTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[]
            {
                4, 2, new[]
                {
                    new[] {1, 1, 1, 1},
                    new[] {1, 1, 2},
                    new[] {1, 2, 1},
                    new[] {2, 1, 1},
                    new[] {2, 2}
                }
            };

            yield return new object[] { 0, 0, new int[0][] };
            yield return new object[] { 1, 1, new[] { new[] { 1 } } };
            yield return new object[]
            {
                7, 3,
                new[]
                {
                    new[] {1, 1, 1, 1, 1, 1, 1}, new[] {1, 1, 1, 1, 1, 2}, new[] {1, 1, 1, 1, 2, 1},
                    new[] {1, 1, 1, 1, 3},
                    new[] {1, 1, 1, 2, 1, 1}, new[] {1, 1, 1, 2, 2}, new[] {1, 1, 1, 3, 1}, new[] {1, 1, 2, 1, 1, 1},
                    new[] {1, 1, 2, 1, 2}, new[] {1, 1, 2, 2, 1}, new[] {1, 1, 2, 3}, new[] {1, 1, 3, 1, 1},
                    new[] {1, 1, 3, 2}, new[] {1, 2, 1, 1, 1, 1}, new[] {1, 2, 1, 1, 2}, new[] {1, 2, 1, 2, 1},
                    new[] {1, 2, 1, 3}, new[] {1, 2, 2, 1, 1}, new[] {1, 2, 2, 2}, new[] {1, 2, 3, 1},
                    new[] {1, 3, 1, 1, 1}, new[] {1, 3, 1, 2}, new[] {1, 3, 2, 1}, new[] {1, 3, 3},
                    new[] {2, 1, 1, 1, 1, 1}, new[] {2, 1, 1, 1, 2}, new[] {2, 1, 1, 2, 1}, new[] {2, 1, 1, 3},
                    new[] {2, 1, 2, 1, 1}, new[] {2, 1, 2, 2}, new[] {2, 1, 3, 1}, new[] {2, 2, 1, 1, 1},
                    new[] {2, 2, 1, 2}, new[] {2, 2, 2, 1}, new[] {2, 2, 3}, new[] {2, 3, 1, 1},
                    new[] {2, 3, 2}, new[] {3, 1, 1, 1, 1}, new[] {3, 1, 1, 2}, new[] {3, 1, 2, 1},
                    new[] {3, 1, 3}, new[] {3, 2, 1, 1}, new[] {3, 2, 2}, new[] {3, 3, 1}
                }
            };

            yield return new object[]
            {
                5, 2,
                new[]
                {
                    new[] {1, 1, 1, 1, 1}, new[] {1, 1, 1, 2}, new[] {1, 1, 2, 1},
                    new[] {1, 2, 1, 1}, new[] {1, 2, 2}, new[] {2, 1, 1, 1},
                    new[] {2, 1, 2}, new[] {2, 2, 1}
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetData))]

        public void TestClimbingStairCases(int n, int k, int[][] expected)
        {
            var actual = climbingStaircase(n, k);
            Assert.Equal(expected, actual);
        }

        int[][] climbingStaircase(int n, int k)
        {
            var acc = BackTrack(n, n, k);
            return acc.ToArray();
        }

        //IEnumerable<int[]> BackTrack(int n, int k, List<int[]> acc)
        IEnumerable<int[]> BackTrack(int upto, int n, int k)
        {
            Console.WriteLine($"BEGIN n={n}, k={k}");
            if (n < 0)
            {
                yield return new int[0];
                yield break;
            }

            if (n == 1)
            {
                yield return new[] { 1 };
                yield break;
            }

            if (n == 2)
            {
                yield return new[] { 1, 1 };
                yield return new[] { 2 };
                yield break;
            }

            if (n == 3)
            {
                yield return new[] { 1, 1, 1 };
                yield return new[] { 1, 2 };
                yield return new[] { 2, 1 };
                yield break;
            }

            var outter = new List<int[]>();
            for (int i = 1; i <= k; i++)
            {
                foreach (var a in BackTrack(upto, n - i, k).ToList())
                {
                    var inner = new List<int>();
                    Console.WriteLine($"i={i}, a={string.Join(",", a)}");

                    inner.Add(n - (n - i));
                    inner.AddRange(a);

                    if (n == upto) outter.Add(inner.ToArray());
                    else yield return inner.ToArray();
                }
            }

            if (upto == n)
            {
                foreach (var result in outter.ToArray())
                {
                    yield return result;
                }
            }
        }
    }
}