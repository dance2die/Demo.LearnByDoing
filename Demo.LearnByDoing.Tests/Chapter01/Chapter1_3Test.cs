using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// URLify: Wirte a method to replace all spaces in a string with '%20'. 
    /// You may assume that the string has sufficient space at the end to hold the additional characters, 
    /// and that you are given the "true" length of the string. 
    /// (Note: If implementing in Java, please use a chracter array so that you can perform this operation in place.)
    /// 
    /// EXAMPLE
    /// Input       "Mr John Smith    ", 13
    /// Output      "Mr%20John%20Smith"
    /// </summary>
    public class Chapter1_3Test : BaseTest
    {
        private readonly Chapter1_3 _sut = new Chapter1_3();

        public Chapter1_3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_3Data))]
        public void TestUrlifyingText(string text, int trueLength, string expected)
        {
            string actual = _sut.UrlifyString(text, trueLength);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_3
    {
        public string UrlifyString(string text, int trueLength)
        {
            // Get substring "s" upto trueLength.
            // Count the number of empty strings in "s"
            // Create a new character array "result" where length = non-space character count + (space count * 3)

            // foreach character "c" in "s"
            // if "c" == space, then insert "%20" into "result" taking up three indexes.
            // else insert "c" into "result".


            char[] upto = text.Substring(0, trueLength).ToCharArray();

            int spaceCount = upto.Where(c => c == ' ').Count();
            int nonSpaceCount = upto.Length - spaceCount;

            char[] encodedSpace = { '%', '2', '0' };
            int resultLength = nonSpaceCount + (spaceCount * encodedSpace.Length);
            char[] result = new char[resultLength];

            // offset caused by adding "%20" instead of space.
            int offset = 0;
            for (int i = 0; i < upto.Length; i++)
            {
                var c = upto[i];

                if (c == ' ')
                {
                    result[i + offset] = '%';
                    result[i + 1 + offset] = '2';
                    result[i + 2 + offset] = '0';

                    offset += 2;
                }
                else
                {
                    result[i + offset] = c;
                }
            }

            return new string(result);
        }
    }

    public class Chapter1_3Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "Mr John Smith    ", 13, "Mr%20John%20Smith" },
            new object[] { "Hello World    ", 11, "Hello%20World" },
            new object[] { "Hello World    ", 12, "Hello%20World%20" },
            new object[] { "Hello World    ", 13, "Hello%20World%20%20" },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
