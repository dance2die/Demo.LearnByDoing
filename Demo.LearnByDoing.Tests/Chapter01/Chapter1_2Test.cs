using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// 1.2 Given two strings, write a method to decide if one is a permutation of the other.
    /// </summary>
    public class Chapter1_2Test : BaseTest
    {
        private readonly Chapter1_2 _sut = new Chapter1_2();

        public Chapter1_2Test(ITestOutputHelper output) : base(output)
        {
        }


    }

    public class Chapter1_2
    {
    }
}
