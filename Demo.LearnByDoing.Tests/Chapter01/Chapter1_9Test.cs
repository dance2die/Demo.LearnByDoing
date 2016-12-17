using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// String Rotation:
    /// Assume you have a method isSubstring which checks if one word is a substring of another.
    /// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring
    /// (e.g., "waterbottle" is a rotation of "erbottlewat").
    /// </summary>
    public class Chapter1_9Test : BaseTest
    {
        private readonly Chapter1_9 _sut = new Chapter1_9();

        public Chapter1_9Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter1_9
    {
    }
}
