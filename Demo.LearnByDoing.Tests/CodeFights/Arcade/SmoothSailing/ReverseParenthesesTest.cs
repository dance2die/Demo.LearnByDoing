using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeFights.Arcade.SmoothSailing
{
    /// <summary>
    /// https://codefights.com/arcade/intro/level-3/3o6QFqgYSontKsyk4/description
    /// </summary>
    public class ReverseParenthesesTest : BaseTest
    {
        public ReverseParenthesesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSampleCases(string input, string expected)
        {
            var actual = reverseParentheses(input);
            Assert.Equal(expected, actual);
        }

        string reverseParentheses(string s)
        {
            if (s.IndexOf("(") < 0 || s.IndexOf(")") < 0)
                return s;
            return reverse(s);
        }

        string reverse(string s, int depth = 0)
        {
            if (s.Length == 0) return "";
            if (s == "(" || s == ")") return "";
            if (s.IndexOf("(") < 0 || s.IndexOf(")") < 0) return ReverseConcat(s);

            var acc = "";
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '(')
                {
                    var endIndex = GetEndIndex(s, i);
                    var length = endIndex - i - 1;
                    var temp = "";

                    //if (length < 0)
                    //    Console.WriteLine($"i={i}, endIndex={endIndex}, length={length}");
                    //else
                    //    temp = reverse(s.Substring(i + 1, length), depth + 1);

                    temp = reverse(s.Substring(i + 1, length), depth + 1);
                    i += length + 1;

                    _output.WriteLine($"BEFORE temp={temp} i={i}, depth={depth}, s={s}, s[i]={s[i]}, acc={acc}");
                    //temp = s[i] == ')' && depth == 0 ? ReverseConcat(temp) : temp;
                    //temp = s[i] == ')' && depth % 2 == 1 ? ReverseConcat(temp) : temp;
                    _output.WriteLine($"MIDDLE temp={temp} i={i}, depth={depth} s={s}, s[i]={s[i]}, acc={acc}");
                    acc += temp;
                    _output.WriteLine($"AFTER temp={temp} i={i}, depth={depth} s={s}, s[i]={s[i]}, acc={acc}");
                }
                else
                {
                    acc += c;
                }
            }

            return acc;
        }

        string ReverseConcat(string value)
        {
            return string.Concat(value.Reverse());
        }

        int GetEndIndex(string s, int startIndex = 0)
        {
            var count = 0;
            for (var i = startIndex; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                }
                if (s[i] == ')')
                {
                    count--;
                    if (count == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { "a(bcdefghijkl(mno)p)q", "apmnolkjihgfedcbq" };
            //yield return new object[] { "a(bc)de", "acbde" };
            //yield return new object[] { "co(de(fight)s)", "cosfighted" };
            //yield return new object[] { "Where are the parentheses?", "Where are the parentheses?" };
            //yield return new object[] { "Code(Cha(lle)nge)", "CodeegnlleahC" };
            yield return new object[] { "abc(cba)ab(bac)c", "abcabcabcabc" };
            //yield return new object[] { "The ((quick (brown) (fox) jumps over the lazy) dog)", "The god quick nworb xof jumps over the lazy" };
        }
    }
}
