using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeFights.Arcade.ThroughTheFog
{
    /// <summary>
    /// https://codefights.com/arcade/intro/level-7/PTWhv2oWqd6p4AHB9
    /// </summary>
    public class StringsRearrangementTest : BaseTest
    {
        public StringsRearrangementTest(ITestOutputHelper output) : base(output)
        {
        }

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

            var perms = GetPermutations(a, new List<string>()).ToList();
            foreach (var s in a)
            {
                if (perms.Any(perm => IsDifferentByOne(s, perm))) return true;
            }

            return false;

            //var result = new List<string>(a.Length) { a[0] };
            //var input = new List<string>(a.Skip(1));

            //for (int i = 1; i < input.Count; i++)
            //{
            //    var curr = a[i];


            //    _output.WriteLine($"curr={curr}, DifferentByOne = {string.Join(",", result.Where(t => IsDifferentByOne(curr, t)))}");
            //    //if (result.Any(t => IsDifferentByOne(curr, t)))
            //    if (result.Any(t => input.Any(ti => IsDifferentByOne(t, ti))))
            //    {
            //        result.Add(curr);
            //        input.Remove(curr);
            //        i--;
            //    }
            //    else
            //    {
            //        _output.WriteLine($"no different curr={curr}, DifferentByOne = {string.Join(",", result.Where(t => IsDifferentByOne(curr, t)))}");
            //    }
            //}
            //_output.WriteLine($"result={string.Join(",", result)}");

            //return result.Distinct().Count() == a.Length;
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

        private static IEnumerable<string> GetPermutations(string[] words)
        {
            return GetPermutations(words, new List<string>());
        }

        private static IEnumerable<string> GetPermutations(IEnumerable<string> words, IEnumerable<string> prefix)
        {
            if (words.Count() == 0)
            {
                foreach (var p in prefix)
                    yield return p;
            }

            var wordList = words.ToList();
            for (int i = 0; i < wordList.Count; i++)
            {
                //string remainder = str.Substring(0, i) + str.Substring(i + 1);
                var remainder = wordList.Take(i).Concat(wordList.Skip(i + 1));
                //var nextPrefix = prefix + str[i];
                var nextPrefix = prefix.Concat(new[] {wordList[i]});

                foreach (var permutation in GetPermutations(remainder, nextPrefix).ToList())
                    yield return permutation;
            }
        }

        //private static IEnumerable<string> Permutation(IEnumerable<string> words, IEnumerable<string> prefix)
        //{
        //    if (words.Count() == 0)
        //    {
        //        //Console.WriteLine(prefix);
        //        return prefix;
        //    }

        //    var result = new List<string>();
        //    var wordList = words.ToList();
        //    for (int i = 0; i < wordList.Count; i++)
        //    {
        //        string[] remainder = wordList.Take(i).Concat(wordList.Skip(i)).ToArray();
        //        result.AddRange(Permutation(remainder,  prefix.Concat(new []{ wordList[i] })));
        //    }

        //    return result.ToArray();
        //}

        //private IEnumerable<string> GetPermutations(string[] a)
        //{
        //    return FillPermutations(a).SelectMany(_ => _);
        //}

        //private IEnumerable<string[]> FillPermutations(string[] a)
        //{
        //    if (a.Length == 1) yield return a[0];
        //    else if (a.Length == 2)
        //    {
        //        yield return a[0];
        //        yield return a[1];
        //        yield return a[0];
        //        //yield return new string(new[] { a[1], a[0] });
        //    }
        //    else
        //    {
        //        for (int i = 0; i < a.Length; i++)
        //        {
        //            string prefix = a[i].ToString();
        //            string left = a.Take(0, i);
        //            string right = a.Substring(i + 1);
        //            string newInput = left + right;

        //            foreach (var rest in FillPermutations(newInput))
        //            {
        //                yield return prefix + rest;
        //            }
        //        }
        //    }
        //}
    }
}
