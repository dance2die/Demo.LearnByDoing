using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// String Comparison:
    /// Implement a method to perform basic string compression using the counts of repeated characters.
    /// For example, the string aabcccccaaa would become a2b1c5a3.
    /// If "compressed" string would not become smaller than the original string, your method should return the original string.
    /// You can assume the string has only uppercase and lowercase letters (1-z).
    /// </summary>
    public class Chapter1_6Test : BaseTest
    {
        private readonly Chapter1_6 _sut = new Chapter1_6();

        public Chapter1_6Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_6Data))]
        public void TestCompression(string text, string expected)
        {
            string actual = _sut.CompressText(text);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_6
    {
        public string CompressText(string text)
        {
            // To save time.
            if (string.IsNullOrWhiteSpace(text) || text.Length == 1) return text;

            string[] compressed = new string[text.Length];

            // Set initial text to $prevChar
            // for reach $currChar in $text
            // if $prevChar == $currChar, then 
            //      increase $charCount
            // else 
            //      Add $prevChar to $compressed with $charCount
            //      Set $prevChar to $currChar
            //      reset $charCount to 1
            //
            // After the loop is over, add the $prevChar to $compressed with $charCount
            // return stringified $compressed

            char prevChar = text[0];
            int compressedIndex = 0;
            int charCount = 1;
            // we are adding two strings into array, current character and the number of occurrences.
            const int indexOffset = 2;

            // Skip the first character.
            foreach (char currChar in text.Skip(1))
            {
                if (prevChar == currChar)
                {
                    charCount++;
                }
                else
                {
                    if (compressedIndex + indexOffset > text.Length) return text;

                    compressed[compressedIndex] = prevChar.ToString();
                    compressed[compressedIndex + 1] = charCount.ToString();

                    prevChar = currChar;
                    charCount = 1;

                    compressedIndex += indexOffset;
                }
            }

            // Set the last character's data
            compressed[compressedIndex] = prevChar.ToString();
            compressed[compressedIndex + 1] = charCount.ToString();

            return string.Join("", compressed);
        }
    }

    public class Chapter1_6Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "aabcccccaaa", "a2b1c5a3" },
            new object[] { "aaabcccccaaa", "a3b1c5a3" },
            new object[] { "aaabcaaa", "a3b1c1a3" },
            new object[] { "aabbcc", "a2b2c2" },
            new object[] { "abcd", "abcd" },
            new object[] { "a", "a" },
            new object[] { "aa", "a2" },
            new object[] { "", "" },
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
