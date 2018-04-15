﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeFights.Arcade.ThroughTheFog
{
    /// <summary>
    /// https://codefights.com/arcade/intro/level-7/PTWhv2oWqd6p4AHB9
    /// </summary>
    public class StringsRearrangementTest
    {
        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSamples(bool expected, string[] a)
        {
            var actual = stringsRearrangement(a);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { false, new[] { "aba", "bbb", "bab" } };
            yield return new object[] { true, new[] { "ab", "bb", "aa" } };
            yield return new object[] { false, new[] { "q", "q" } };
            yield return new object[] { true, new[] { "zzzzab", "zzzzbb", "zzzzaa" } };
            yield return new object[] { false, new[] { "ab", "ad", "ef", "eg" } };
            yield return new object[] { true, new[] { "abc", "bef", "bcc", "bec", "bbc", "bdc" } };
            yield return new object[] { true, new[] { "abc", "abx", "axx", "abx", "abc" } };
            yield return new object[] { true, new[] { "f", "g", "a", "h" } };
        }

        bool stringsRearrangement(string[] a)
        {
            var result = new List<string>(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                var curr = a[i];
                for (int j = i; j < a.Length; j++)
                {
                    if (i == j) continue;

                    var next = a[j];
                    if (IsDifferentByOne(curr, next))
                    {
                        Console.WriteLine($"Diff by one; curr={curr}, next={next}");
                        result.Add(curr);
                        result.Add(next);
                        Console.WriteLine($"i={i}, j={j}   result={string.Join(",", result)}");
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            Console.WriteLine($"result={string.Join(",", result)}");

            return result.Distinct().Count() == a.Length;
        }

        bool IsDifferentByOne(string s1, string s2)
        {
            bool wasDifferent = false;
            for (int i = 0; i < s1.Length; i++)
            {
                var c1 = s1[i];
                var c2 = s2[i];
                if (c1 == c2) continue;

                if (wasDifferent) return false;
                wasDifferent = true;
            }
            return true;
        }




    }
}
